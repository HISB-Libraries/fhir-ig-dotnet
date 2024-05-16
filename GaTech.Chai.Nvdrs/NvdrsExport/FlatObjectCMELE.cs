using System.Text.Json;
using System.Text.Json.Nodes;
using GaTech.Chai.Mdi.BundleDocumentMdiAndEdrsProfile;
using GaTech.Chai.Mdi.CompositionMdiAndEdrsProfile;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Vrdr.VrdrInjuryIncidentProfile;
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

    public new void MapToNVDRS(Bundle bundle)
    {
        if (bundle.Meta != null && bundle.Meta.Profile != null && bundle.Meta.Profile.Any())
        {
            Boolean isOk = false;
            foreach (string profile in bundle.Meta.Profile)
            {
                if (BundleDocumentMdiAndEdrs.ProfileUrl.Equals(profile))
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
            Composition composition = (Composition)bundle.Entry[0].Resource;

            // Mapping Process with a simple iteration over the data array.
            foreach (JsonNode? data in DataArray) {
                if ("InitialOfLastName".Equals(data!["name"]!.GetValue<string>()))
                {
                    if (Record.GetResources().TryGetValue(composition.Subject.Reference, out Resource? resource))
                    {
                        Patient patient = (Patient) resource;
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
                } else if ("BirthDayofMonth".Equals(data["name"]))
                {

                }
            }
        }

        // Map the MDI or VRDR bundle document to NVDRS flat object.

    }
}
