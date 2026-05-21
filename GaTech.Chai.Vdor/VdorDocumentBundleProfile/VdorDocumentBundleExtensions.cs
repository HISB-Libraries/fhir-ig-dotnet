using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

/// <summary>
/// Class with Bundle extensions for the BundleDocumentVdorProfile
/// </summary>
public static class VdorDocumentBundleExtensions
{
    public static VdorDocumentBundle VdorDocumentBundle(this Bundle bundle)
    {
        return new VdorDocumentBundle(bundle);
    }
}
