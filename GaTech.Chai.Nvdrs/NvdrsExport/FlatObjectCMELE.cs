using System.ComponentModel;
using System.Text.Json.Nodes;
using GaTech.Chai.Nvdrs.Common;
using GaTech.Chai.Nvdrs.CompositionNVDRSProfile;
using GaTech.Chai.Nvdrs.ObservationFirearm;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;
using Hl7.Fhir.Specification.Snapshot;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Nvdrs;

public class FlatObjectCMELE : FlatObject
{
    public FlatObjectCMELE(string filename) : base(filename)
    {
        if (!"LECMEFormat".Equals(FlatType))
        {
            throw new NotSupportedException("This flat object only support CMELE flat format");
        }
    }

    public Observation? FindWeaponTypeObservation(Composition composition)
    {
        List<Resource> resources = composition.CompositionNVDRS().GetSectionByCode(NvdrsCodeSystem.NvdrsSectionCodes.Weapons);
        foreach (Resource resource in resources)
        {
            if (resource is Observation weaponObs)
            {
                if (!weaponObs.Code.IsNullOrEmpty())
                {
                    List<Coding> codings = weaponObs.Code.Coding;
                    if (!codings.IsNullOrEmpty())
                    {
                        if (NvdrsCodeSystem.NvdrsResourceCodes.WeaponType.Coding[0].Code.Equals(codings[0].Code))
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
                    if (ObservationFirearm.ObservationFirearm.ProfileUrl.Equals(profile))
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
                if (BundleDocumentNvdrs.ProfileUrl.Equals(profile))
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
            Composition composition = bundle.BundleDocumentNvdrs().NVDRSComposition ?? throw new Exception("Composition missing in Bundle document.");
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

            // Mapping Process with a simple iteration over the data array.
            foreach (JsonNode? data in DataArray)
            {
                if ("ForceNewRecord".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (composition.CompositionNVDRS().ForceNewRecord)
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
                    if (composition.CompositionNVDRS().OverwriteConflicts)
                    {
                        data["value"] = "Y";
                    }
                    else
                    {
                        data["value"] = "N";
                    }
                }
                else if ("IncidentYear".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (composition.CompositionNVDRS().IncidentYear != null)
                    {
                        string incidentYearDate = composition.CompositionNVDRS().IncidentYear!.Value;
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
                else if ("Weapon Type".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (weaponTypeObservation != null)
                    {
                        if (weaponTypeObservation.Value is CodeableConcept concept)
                        {
                            string weaponTypeCode = concept.Coding[0].Code;
                            StringWriteToData(data, weaponTypeCode);
                        }
                    }
                }
                else if ("Firearm Type".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (firearmObservation != null)
                    {
                        CodeableConcept? firearmType = firearmObservation.ObservationFirearm().FirearmType;
                        if (!firearmType.IsNullOrEmpty())
                        {
                            StringWriteToData(data, firearmType!.Coding[0].Code);
                        }
                    }
                }
                else if ("Firearm Caliber".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (firearmObservation != null)
                    {
                        string? firearmCaliber = firearmObservation.ObservationFirearm().FirearmCaliber;
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
                        string? firearmGauge = firearmObservation.ObservationFirearm().FirearmGauge;
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
                        DataType? firearmMake = firearmObservation.ObservationFirearm().FirearmMake;
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
                        string? fireModel = firearmObservation.ObservationFirearm().FirearmModel;
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
                        if ("Y".Equals(firearmObservation.ObservationFirearm().FirearmStolen?.Coding[0].Code))
                        {
                            data["value"] = "Y";
                        }
                        else
                        {
                            data["value"] = "N";
                        }
                    }
                }
            }
        }

        // Map the MDI or VRDR bundle document to NVDRS flat object.

    }
}
