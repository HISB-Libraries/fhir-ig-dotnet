using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

/// <summary>
/// Class with Bundle extensions for the BundleDocumentNvdrs
/// </summary>
public static class BundleDocumentNvdrsExtensions
{
    public static BundleDocumentNvdrs BundleDocumentNvdrs(this Bundle bundle)
    {
        return new BundleDocumentNvdrs(bundle);
    }
}
