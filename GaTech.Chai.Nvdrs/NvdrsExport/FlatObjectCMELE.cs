using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;
using GaTech.Chai.Vrdr;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Nvdrs;

public class FlatObjectCMELE : FlatObject
{
    public FlatObjectCMELE() : base("ExportConfigCMELE.json")
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

    protected void SetDemographicsYNUnk(JsonNode data, List<Resource> deomgraphidwResources, CodeableConcept YNUnkTypeCode)
    {
        foreach (Resource resource in deomgraphidwResources)
        {
            if (resource is Observation obs)
            {
                if (YNUnkTypeCode.Matches(obs.Code))
                {
                    if (obs.Value is CodeableConcept cc)
                    {
                        if (cc.Coding[0].Code.Equals("Y"))
                        {
                            data["value"] = "1";
                        }
                        else if (cc.Coding[0].Code.Equals("N"))
                        {
                            data["value"] = "0";
                        }
                        else
                        {
                            data["value"] = "9";
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

    protected void SetInjuryAndDeathYNUnk(JsonNode data, List<Resource> injuryAndDeathResources, CodeableConcept YNUnkTypeCode)
    {
        foreach (Resource resource in injuryAndDeathResources)
        {
            if (resource is Observation obs)
            {
                if (YNUnkTypeCode.Matches(obs.Code))
                {
                    if (obs.Value is CodeableConcept cc)
                    {
                        if (cc.Coding[0].Code.Equals("Y"))
                        {
                            data["value"] = "1";
                        }
                        else if (cc.Coding[0].Code.Equals("N"))
                        {
                            data["value"] = "0";
                        }
                        else
                        {
                            data["value"] = "9";
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

            // get the list of entries in the Injury and Death section
            List<Resource> deomgraphidwResources = composition.NvdrsComposition().GetSectionByCode(NvdrsCustomCs.Demographics);

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
                    if (!composition.NvdrsComposition().ForceNewRecord)
                    {
                        if (composition.NvdrsComposition().IncidentYear != null)
                        {
                            string incidentYearDate = composition.NvdrsComposition().IncidentYear!.Value;
                            string[] incidentdatepart = incidentYearDate.Split('-');
                            StringWriteToData(data, incidentdatepart[0]);
                            data["value"] = incidentdatepart[0];
                        }
                    }
                }
                else if ("IncidentNumber".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (!composition.NvdrsComposition().ForceNewRecord)
                    {

                        if (composition.NvdrsComposition().IncidentNumber != null)
                        {
                            StringWriteToData(data, composition.NvdrsComposition().IncidentNumber, Alignment.RIGHT);
                        }
                    }
                }
                else if ("VictimNumber".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (!composition.NvdrsComposition().ForceNewRecord)
                    {

                        Identifier? additionalId = composition.NvdrsComposition().GetAdditionalIdentifier(NvdrsCustomUris.victimnumberIdentifierUrl);
                        if (additionalId != null)
                        {
                            StringWriteToData(data, additionalId.Value, Alignment.RIGHT);
                        }
                    }
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
                    if (Record.GetResources().TryGetValue(composition.Subject.Reference, out Resource? resource))
                    {
                        Patient patient = (Patient)resource;
                        if (patient.BirthDate != null)
                        {
                            string[] birthDateParts = patient.BirthDate.Split('-');
                            if (birthDateParts.Length > 1)
                            {
                                StringWriteToData(data, birthDateParts[1]);
                            }
                        }
                    }
                }
                else if ("DeathMannerAbstractor".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathMannerDC".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathMannerCME".Equals(data!["name"]!.GetValue<string>()))
                {
                    foreach (Bundle.EntryComponent entry in bundle.Entry)
                    {
                        if (entry.Resource is Observation obs)
                        {
                            if (VrdrCs.MannerOfDeathLoinc.Matches(obs.Code))
                            {
                                if (VrdrMannerOfDeathVs.NaturalDeath.Matches(obs.Value))
                                {
                                    data["value"] = "1";
                                }
                                else if (VrdrMannerOfDeathVs.AccidentalDeath.Matches(obs.Value))
                                {
                                    data["value"] = "2";
                                }
                                else if (VrdrMannerOfDeathVs.Suicide.Matches(obs.Value))
                                {
                                    data["value"] = "3";
                                }
                                else if (VrdrMannerOfDeathVs.Homicide.Matches(obs.Value))
                                {
                                    data["value"] = "4";
                                }
                                else if (VrdrMannerOfDeathVs.PatientAwaitingInvestigation.Matches(obs.Value))
                                {
                                    data["value"] = "5";
                                }
                                else if (VrdrMannerOfDeathVs.DeathMannerUndetermined.Matches(obs.Value))
                                {
                                    data["value"] = "6";
                                }
                            }
                        }
                    }
                }
                else if ("DeathDateYear".Equals(data!["name"]!.GetValue<string>()))
                {

                }
                else if ("DeathDateMonth".Equals(data!["name"]!.GetValue<string>())) // 41
                {

                }
                else if ("DeathDateDay".Equals(data!["name"]!.GetValue<string>())) // 43
                {

                }
                else if ("InjuryLocation".Equals(data!["name"]!.GetValue<string>())) // 106-107
                {

                }
                else if ("InjuredAtWork".Equals(data!["name"]!.GetValue<string>())) // 108
                {
                    SetInjuryAndDeathYNUnk(data, injuryAndDeathResources, VrdrInjuryIncidentComponentsCs.WorkInjuryIndicator);
                }
                else if ("EMSPresent".Equals(data!["name"]!.GetValue<string>())) // 110
                {
                    SetInjuryAndDeathYNUnk(data, injuryAndDeathResources, NvdrsCustomCs.EmsAtScene);
                }
                else if ("VictimInCustody".Equals(data!["name"]!.GetValue<string>())) // 111
                {
                    SetInjuryAndDeathYNUnk(data, injuryAndDeathResources, NvdrsCustomCs.VictimInCustodyWhenInjured);
                }
                else if ("SexVictim".Equals(data!["name"]!.GetValue<string>())) // 136
                {
                    if (Record.GetResources().TryGetValue(composition.Subject.Reference, out Resource? resource))
                    {
                        Patient patient = (Patient)resource;
                        if (patient.VrdrDecedent().NVSSSexAtDeath != null)
                        {
                            if ("M".Equals(patient.VrdrDecedent().NVSSSexAtDeath.Coding[0].Code) ||
                                "male".Equals(patient.VrdrDecedent().NVSSSexAtDeath.Coding[0].Code))
                            {
                                StringWriteToData(data, "1");
                            }
                            else if ("F".Equals(patient.VrdrDecedent().NVSSSexAtDeath.Coding[0].Code) ||
                                "female".Equals(patient.VrdrDecedent().NVSSSexAtDeath.Coding[0].Code))
                            {
                                StringWriteToData(data, "2");
                            }
                            else
                            {
                                StringWriteToData(data, "9");
                            }
                        }
                        else if (patient.Gender != null)
                        {
                            if (patient.Gender == AdministrativeGender.Male)
                            {
                                StringWriteToData(data, "1");
                            }
                            else if (patient.Gender == AdministrativeGender.Female)
                            {
                                StringWriteToData(data, "2");
                            }
                            else
                            {
                                StringWriteToData(data, "9");
                            }
                        }
                    }
                }
                else if ("EthnicityVictim".Equals(data!["name"]!.GetValue<string>())) // 143
                {
                    if (Record.GetResources().TryGetValue(composition.Subject.Reference, out Resource? resource))
                    {
                        Patient patient = (Patient)resource;
                        Extension patientExt = patient.GetExtension(UsCorePatientEthnicity.ExtUrl);
                        if (patientExt != null)
                        {
                            Extension patientEthnicityExt = patientExt.GetExtension("ombCategory");
                            Coding? ethnicityExtCoding = patientEthnicityExt.Value as Coding;
                            if (ethnicityExtCoding != null)
                            {
                                if ("2186-5".Equals(ethnicityExtCoding.Code))
                                {
                                    data["value"] = "0";
                                }
                                else if ("2135-2".Equals(ethnicityExtCoding.Code))
                                {
                                    data["value"] = "1";
                                }
                                else if ("UNK".Equals(ethnicityExtCoding.Code))
                                {
                                    data["value"] = "9";
                                }
                            }
                        }
                    }
                }
                else if ("RaceWhiteVictim".Equals(data!["name"]!.GetValue<string>())) // 144
                {
                    if (Record.GetResources().TryGetValue(composition.Subject.Reference, out Resource? resource))
                    {
                        Patient patient = (Patient)resource;
                        Extension patientExt = patient.GetExtension(UsCorePatientRace.ExtUrl);
                        if (patientExt != null)
                        {
                            Extension patientRaceExt = patientExt.GetExtension("ombCategory");
                            Coding? raceExtCoding = patientRaceExt.Value as Coding;
                            if (raceExtCoding != null)
                            {
                                if ("2106-3".Equals(raceExtCoding.Code))
                                {
                                    data["value"] = "Y";
                                }
                            }
                        }
                    }
                }
                else if ("Homeless".Equals(data!["name"]!.GetValue<string>())) // 160
                {
                    SetDemographicsYNUnk(data, deomgraphidwResources, NvdrsCustomCs.HomelessAtDeath);
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
                else if ("WoundToHead".Equals(data!["name"]!.GetValue<string>())) // 425
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
                else if ("WoundToSpine".Equals(data!["name"]!.GetValue<string>())) // 429
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
                    if (circumstanceResources.Count > 0)
                    {
                        data["value"] = "1";
                    }
                }
                else if ("AbusedAsChildCME".Equals(data!["name"]!.GetValue<string>())) // 434
                {

                }
                else if ("AlcoholProblemCME".Equals(data!["name"]!.GetValue<string>())) // 435
                {
                    SetCircumstanceYN(data, circumstanceResources, CodeSystems.HistoryOfAlcoholUse);
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
                else if ("DriveByShootingCME".Equals(data!["name"]!.GetValue<string>())) // 724
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.DriveByShooting);
                }
                else if ("GangRelatedCME".Equals(data!["name"]!.GetValue<string>())) // 730
                {
                    foreach (Resource resource in circumstanceResources)
                    {
                        if (resource is Observation obs)
                        {
                            if (NvdrsCustomCs.GangRelated.Matches(obs.Code))
                            {
                                if (obs.Value is CodeableConcept cc)
                                {
                                    string gangRelated = cc.Coding[0].Code;
                                    StringWriteToData(data, gangRelated[11..]);
                                }
                            }
                        }
                    }
                }
                else if ("GunPlayingCME".Equals(data!["name"]!.GetValue<string>())) // 737
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.PlayWithFirearm);
                }
                else if ("RandomViolenceCME".Equals(data!["name"]!.GetValue<string>())) // 824
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.RandomViolence);
                }
                else if ("SchoolProblemCME".Equals(data!["name"]!.GetValue<string>())) // 828
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.SchoolProblem);
                }
                else if ("SuicideAttemptHistoryCME".Equals(data!["name"]!.GetValue<string>())) // 832
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.HistoryOfSuicideAttempts);
                }
                else if ("SuicideNoteCME".Equals(data!["name"]!.GetValue<string>())) // 834
                {
                    foreach (Bundle.EntryComponent entry in bundle.Entry)
                    {
                        if (entry.Resource is Observation obs)
                        {
                            if (NvdrsCustomCs.SuicideNote.Matches(obs.Code))
                            {
                                if (obs.VdrsSuicideNote().SuicideNote != null && obs.VdrsSuicideNote().SuicideNote.Trim().Length > 0)
                                {
                                    data["value"] = "1";
                                    break;
                                }
                            }
                        }
                    }
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
                else if ("FirearmModel".Equals(data!["name"]!.GetValue<string>())) // 1266
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
                else if ("GunLoaded".Equals(data!["name"]!.GetValue<string>())) // 1270
                {
                    if (firearmObservation != null)
                    {
                        if ("Y".Equals(firearmObservation.NvdrsFirearm().FirearmStoredLoaded?.Coding[0].Code))
                        {
                            data["value"] = "1";
                        }
                        else if ("N".Equals(firearmObservation.NvdrsFirearm().FirearmStoredLoaded?.Coding[0].Code))
                        {
                            data["value"] = "0";
                        }
                        else if ("UNK".Equals(firearmObservation.NvdrsFirearm().FirearmStoredLoaded?.Coding[0].Code))
                        {
                            data["value"] = "9";
                        }
                        else
                        {
                            data["value"] = "8";
                        }
                    }
                }
                else if ("GunOwner".Equals(data!["name"]!.GetValue<string>())) // 1271
                {
                    if (firearmObservation != null)
                    {

                        (CodeableConcept? ownerCC, string? ownerNarr, Resource? ownerResource) = firearmObservation.NvdrsFirearm().FireamrOwner;
                        if (ownerCC != null)
                        {
                            string ownerCode = ownerCC.Coding[0].Code;
                            StringWriteToData(data, ownerCode[8..]);
                        }
                    }
                }
                else if ("GunStoredLocked".Equals(data!["name"]!.GetValue<string>())) // 1273
                {
                    if (firearmObservation != null)
                    {
                        if ("Y".Equals(firearmObservation.NvdrsFirearm().FirearmStoredLocked?.Coding[0].Code))
                        {
                            data["value"] = "1";
                        }
                        else if ("N".Equals(firearmObservation.NvdrsFirearm().FirearmStoredLocked?.Coding[0].Code))
                        {
                            data["value"] = "0";
                        }
                        else if ("UNK".Equals(firearmObservation.NvdrsFirearm().FirearmStoredLocked?.Coding[0].Code))
                        {
                            data["value"] = "9";
                        }
                        else
                        {
                            data["value"] = "8";
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
                else if ("IsHistorySelfHarmCME".Equals(data!["name"]!.GetValue<string>())) // 1309
                {
                    SetCircumstanceYN(data, circumstanceResources, NvdrsCustomCs.SelfHarm);
                }
            }
        }

        // Map the MDI or VRDR bundle document to NVDRS flat object.

    }
}
