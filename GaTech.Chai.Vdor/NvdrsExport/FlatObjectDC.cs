using System.Text.Json.Nodes;
using GaTech.Chai.Vdor;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public class FlatObjectDC : FlatObject
{
    public FlatObjectDC(string outputFileFormat = "flat", string filename = "DC_2026.json", string? path = null) : base(filename, path)
    {
        if (!"DC".Equals(FlatType))
        {
            throw new NotSupportedException("This flat object only support DC flat format");
        }
    }

    public override void MapToNVDRS(Bundle bundle)
    {
        if (bundle.Meta != null && bundle.Meta.Profile != null && bundle.Meta.Profile.Any())
        {
            Boolean isOk = false;
            foreach (string profile in bundle.Meta.Profile)
            {
                if (VdorDocumentBundle.ProfileUrl.Equals(profile))
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
            Composition? composition = bundle.VdorDocumentBundle().VdorComposition;

            // Mapping Process with a simple iteration over the data array.
            foreach (JsonNode? data in DataArray)
            { }
        }
    }
}
