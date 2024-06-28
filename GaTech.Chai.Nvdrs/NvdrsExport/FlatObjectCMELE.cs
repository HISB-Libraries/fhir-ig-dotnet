using System.Text.Json.Nodes;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Nvdrs;

public class FlatObjectCMELE : FlatObject
{
    public FlatObjectCMELE(string filename) : base(filename)
    {
        if (!"CMELEFormat".Equals(FlatType))
        {
            throw new NotSupportedException("This flat object only support CMELE flat format");
        }
    }

    public Observation? FindWeaponTypeObservation(Composition composition)
    {
        List<Resource> resources = composition.NvdrsComposition().GetSectionByCode(NvdrsCustomCs.Weapons);
        foreach (Resource resource in resources)
        {
            if (resource is Observation weaponObs)
            {
                if (!weaponObs.Code.IsNullOrEmpty())
                {
                    List<Coding> codings = weaponObs.Code.Coding;
                    if (!codings.IsNullOrEmpty())
                    {
                        if (NvdrsWeaponsCategoryVs.WeaponType.Coding[0].Code.Equals(codings[0].Code))
                        {
                            return weaponObs;
                        }
                    }
                }
            }
        }

        return null;
    }

    public Observation? FindFirearmObservation(Composition composition, Observation weaponTypeObservation)
    {
        foreach (ResourceReference focusReference in weaponTypeObservation.Focus)
        {
            Record.GetResources().TryGetValue(focusReference.Reference, out Resource? focusResource);
            if (focusResource == null) continue;

            if (focusResource is Observation focusObservation)
            {
                Meta meta = focusObservation.Meta;
                if (meta == null) continue;

                foreach (string profile in meta.Profile)
                {
                    if (NvdrsFirearm.ProfileUrl.Equals(profile))
                    {

                        return focusObservation;
                    }
                }
            }
        }

        return null;
    }

    protected void SetWoundResponse(JsonNode data, List<Resource> injuryAndDeathResources, CodeableConcept WoundTypeCode)
    {
        foreach (Resource resource in injuryAndDeathResources)
        {
            if (resource is Observation obs)
            {
                if (WoundTypeCode.Matches(obs.Code))
                {
                    CodeableConcept? cc = obs.Value as CodeableConcept;
                    if (cc != null)
                    {
                        if (cc == NvdrsWoundLocationValuesVs.Unknown)
                        {
                            StringWriteToData(data, "9");
                        }
                        else
                        {
                            string resp = cc.Coding[0].Code;
                            StringWriteToData(data, resp[resp.Length - 1].ToString());
                        }
                    }
                }
            }
        }
    }

    protected void SetCircumstanceYN(JsonNode data, List<Resource> circumstanceResources, CodeableConcept YNTypeCode)
    {
        foreach (Resource resource in circumstanceResources)
        {
            if (resource is Observation obs)
            {
                if (YNTypeCode.Matches(obs.Code))
                {
                    if (obs.Value is CodeableConcept cc)
                    {
                        if (cc.Coding[0].Code.Equals("Y"))
                        {
                            data["value"] = "1";
                        }
                        else
                        {
                            data["value"] = "0";
                        }
                    }
                }
            }
        }
    }

    public override void MapToNVDRS(Bundle bundle)
    {
        if (bundle.Meta != null && bundle.Meta.Profile != null && bundle.Meta.Profile.Any())
        {
            Boolean isOk = false;
            foreach (string profile in bundle.Meta.Profile)
            {
                if (NvdrsDocumentBundle.ProfileUrl.Equals(profile))
                {
                    isOk = true;
                    break;
                }
            }

            if (!isOk)
            {

                throw new NotSupportedException("This flat object only support MDI FHIR Data");
            }

            // Now Map the NVDRS FHIR CME Document to NVDRS. This is manual mapping.
            Composition composition = bundle.NvdrsDocumentBundle().NVDRSComposition ?? throw new Exception("Composition missing in Bundle document.");
            Observation? weaponTypeObservation = FindWeaponTypeObservation(composition);
            Observation? firearmObservation;
            if (weaponTypeObservation != null)
            {
                firearmObservation = FindFirearmObservation(composition, weaponTypeObservation);
            }
            else
            {
                firearmObservation = null;
            }

            // get the list of entries in the circumstance section
            List<Resource> circumstanceResources = composition.NvdrsComposition().GetSectionByCode(NvdrsCustomCs.Circumstances);

            // get the list of entries in the Injury and Death section
            List<Resource> injuryAndDeathResources = composition.NvdrsComposition().GetSectionByCode(NvdrsCustomCs.InjuryAndDeath);

            // Mapping Process with a simple iteration over the data array.
            foreach (JsonNode? data in DataArray)
            {
                if ("ForceNewRecord".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (composition.NvdrsComposition().ForceNewRecord)
                    {
                        data["value"] = "Y";
                    }
                    else
                    {
                        data["value"] = "N";
                    }
                }
                else if ("OverwriteConflicts".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (composition.NvdrsComposition().OverwriteConflicts)
                    {
                        data["value"] = "Y";
                    }
                    // else
                    // {
                    //     data["value"] = "N";
                    // }
                }
                else if ("IncidentYear".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (composition.NvdrsComposition().IncidentYear != null)
                    {
                        string incidentYearDate = composition.NvdrsComposition().IncidentYear!.Value;
                        string[] incidentdatepart = incidentYearDate.Split('-');
                        StringWriteToData(data, incidentdatepart[0]);
                        // data["value"] = incidentdatepart[0];
                    }
                }
                else if ("IncidentNumber".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("VictimNumber".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("LastFourDCNumber".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("LastFourCMENumber".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("InitialOfLastName".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (Record.GetResources().TryGetValue(composition.Subject.Reference, out Resource? resource))
                    {
                        Patient patient = (Patient)resource;
                        if (patient.Name != null)
                        {
                            foreach (var name in patient.Name)
                            {
                                string lastName = name.Family;
                                if (lastName != null)
                                {
                                    data["value"] = lastName[0].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ("BirthDayofMonth".Equals(data["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathMannerAbstractor".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathMannerDC".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathMannerCME".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathDateYear".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathDateMonth".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathDateDay".Equals(data!["name"]!.GetValue<string>())) //43
                {

                }
                else if ("NumberBullets".Equals(data!["name"]!.GetValue<string>())) // 423
                {
                    foreach (Resource resource in injuryAndDeathResources)
                    {
                        if (resource is Observation obs)
                        {
                            if (NvdrsCustomCs.NumberOfBullets.Matches(obs.Code))
                            {
                                int? numBullets = obs.NvdrsNumberOfBullets().NumOfBullets;
                                if (numBullets != null)
                                {
                                    StringWriteToData(data, numBullets.ToString());
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ("WoundToHead".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToHead);
                }
                else if ("WoundToFace".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToFace);
                }
                else if ("WoundToNeck".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToNeck);
                }
                else if ("WoundToUpperExtremity".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToUpperExtremity);
                }
                else if ("WoundToSpine".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToSpine);
                }
                else if ("WoundToThorax".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToThorax);
                }
                else if ("WoundToAbdomen".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToAbdomen);
                }
                else if ("WoundToLowerExtremity".Equals(data!["name"]!.GetValue<string>()))
                {
                    SetWoundResponse(data, injuryAndDeathResources, NvdrsCustomCs.WoundToLowerExtremity);
                }
                else if ("CircumstancesKnownCME".Equals(data!["name"]!.GetValue<string>())) // 433
                {

                }
                else if ("DeathAbuseCME".Equals(data!["name"]!.GetValue<string>())) // 719
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.DeathAbuse);
                }
                else if ("DeathFriendOrFamilyOtherCME".Equals(data!["name"]!.GetValue<string>())) // 720
                {
                }
                else if ("DepressedMoodCME".Equals(data!["name"]!.GetValue<string>())) // 721
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.CurrentDepressedMood);
                }
                else if ("RandomViolenceCME".Equals(data!["name"]!.GetValue<string>())) // 824
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.RandomViolence);
                }
                else if ("WeaponType".Equals(data!["name"]!.GetValue<string>())) // 1251
                {
                    if (weaponTypeObservation != null)
                    {
                        if (weaponTypeObservation.Value is CodeableConcept concept)
                        {
                            string weaponTypeCode = concept.Coding[0].Code;
                            StringWriteToData(data, weaponTypeCode.Substring(10));
                        }
                    }
                }
                else if ("FirearmType".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (firearmObservation != null)
                    {
                        CodeableConcept? firearmType = firearmObservation.NvdrsFirearm().FirearmType;
                        if (!firearmType.IsNullOrEmpty())
                        {
                            StringWriteToData(data, firearmType!.Coding[0].Code.Substring(11));
                        }
                    }
                }
                else if ("FirearmCaliber".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (firearmObservation != null)
                    {
                        string? firearmCaliber = firearmObservation.NvdrsFirearm().FirearmCaliber;
                        if (firearmCaliber != null)
                        {
                            StringWriteToData(data, firearmCaliber);
                        }
                    }
                }
                else if ("FirearmGauge".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (firearmObservation != null)
                    {
                        string? firearmGauge = firearmObservation.NvdrsFirearm().FirearmGauge;
                        if (firearmGauge != null)
                        {
                            StringWriteToData(data, firearmGauge);
                        }
                    }
                }
                else if ("FirearmMake".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (firearmObservation != null)
                    {
                        DataType? firearmMake = firearmObservation.NvdrsFirearm().FirearmMake;
                        if (!firearmMake.IsNullOrEmpty())
                        {
                            if (firearmMake is CodeableConcept concept)
                            {
                                StringWriteToData(data, concept!.Coding[0].Code);
                            }
                            else
                            {
                                StringWriteToData(data, (firearmMake as FhirString)!.ToString()!);
                            }
                        }
                    }
                }
                else if ("FirearmModel".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (firearmObservation != null)
                    {
                        string? fireModel = firearmObservation.NvdrsFirearm().FirearmModel;
                        if (fireModel != null)
                        {
                            StringWriteToData(data, fireModel);
                        }
                    }
                }
                else if ("FirearmStolen".Equals(data!["name"]!.GetValue<string>())) // 1274
                {
                    if (firearmObservation != null)
                    {
                        if ("Y".Equals(firearmObservation.NvdrsFirearm().FirearmStolen?.Coding[0].Code))
                        {
                            data["value"] = "1";
                        }
                        else if ("N".Equals(firearmObservation.NvdrsFirearm().FirearmStolen?.Coding[0].Code))
                        {
                            data["value"] = "0";
                        }
                        else if ("UNK".Equals(firearmObservation.NvdrsFirearm().FirearmStolen?.Coding[0].Code))
                        {
                            data["value"] = "9";
                        }
                        else
                        {
                            data["value"] = "8";
                        }
                    }
                }
            }
        }

        // Map the MDI or VRDR bundle document to NVDRS flat object.

    }
}
