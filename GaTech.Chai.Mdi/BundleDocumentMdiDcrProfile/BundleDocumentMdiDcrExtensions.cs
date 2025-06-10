using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Bundle extensions for the BundleDocumentMdiDcrProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-and-edrs
    /// </summary>
    public static class BundleDocumentMdiDcrExtensions
    {
        public static BundleDocumentMdiDcr BundleDocumentMdiDcr(this Bundle bundle)
        {
            return new BundleDocumentMdiDcr(bundle);
        }
    }
}
