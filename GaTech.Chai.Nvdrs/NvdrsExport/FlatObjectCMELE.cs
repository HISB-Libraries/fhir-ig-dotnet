using System.Text.Json.Nodes;
using GaTech.Chai.Nvdrs.Common;
using GaTech.Chai.Nvdrs.CompositionNVDRSProfile;
using GaTech.Chai.Nvdrs.ObservationFirearm;
using GaTech.Chai.Share.Common;
using Hl7.Fhir.Model;

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
            Composition composition = bundle.BundleDocumentNvdrs().NVDRSComposition;

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
                else if ("Firearm Stolen".Equals(data!["name"]!.GetValue<string>()))
                {
                    List<Resource> resources = composition.CompositionNVDRS().GetSectionByCode(NvdrsCodeSystem.NvdrsSectionCodes.Weapons);
                    foreach (Resource resource in resources)
                    {
                        if (resource is Observation)
                        {
                            Observation obs = (Observation)resource;
                            if (obs.Meta != null)
                            {
                                foreach (string profile in obs.Meta.Profile)
                                {
                                    if (ObservationFirearm.ObservationFirearm.ProfileUrl.Equals(profile))
                                    {
                                        if ("Y".Equals(obs.ObservationFirearm().FirearmStolen?.Coding[0].Code))
                                        {
                                            data["value"] = "Y";
                                        }
                                        else
                                        {
                                            data["value"] = "N";
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Map the MDI or VRDR bundle document to NVDRS flat object.

    }
}
