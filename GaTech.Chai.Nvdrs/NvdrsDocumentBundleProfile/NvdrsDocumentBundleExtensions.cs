using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

/// <summary>
/// Class with Bundle extensions for the BundleDocumentNvdrs
/// </summary>
public static class BundleDocumentNvdrsExtensions
{
    public static NvdrsDocumentBundle NvdrsDocumentBundle(this Bundle bundle)
    {
        return new NvdrsDocumentBundle(bundle);
    }
}
