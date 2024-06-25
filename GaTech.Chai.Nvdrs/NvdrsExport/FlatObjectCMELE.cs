﻿using System.Text.Json.Nodes;
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
                else if ("DeathDateDay".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathAbuseCME".Equals(data!["name"]!.GetValue<string>()))
                {
                    foreach (Resource resource in circumstanceResources)
                    {
                        if (resource is Observation obs)
                        {
                            if (NvdrsCustomCs.DeathAbuse.Matches(obs.Code))
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
                else if ("DeathFriendOrFamilyOtherCME".Equals(data!["name"]!.GetValue<string>()))
                {
                    foreach (Resource resource in circumstanceResources)
                    {
                        if (resource is Observation obs)
                        {
                            if (NvdrsCustomCs.CurrentDepressedMood.Matches(obs.Code))
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
                else if ("WeaponType".Equals(data!["name"]!.GetValue<string>()))
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
                else if ("Firearm Caliber".Equals(data!["name"]!.GetValue<string>()))
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
                else if ("Firearm Gauge".Equals(data!["name"]!.GetValue<string>()))
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
                else if ("Firearm Make".Equals(data!["name"]!.GetValue<string>()))
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
                else if ("Firearm Model".Equals(data!["name"]!.GetValue<string>()))
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
                else if ("Firearm Stolen".Equals(data!["name"]!.GetValue<string>()))
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
