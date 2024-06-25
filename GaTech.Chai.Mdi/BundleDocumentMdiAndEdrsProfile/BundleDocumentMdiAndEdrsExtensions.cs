using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Bundle extensions for the BundleDocumentMdiAndEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-and-edrs
    /// </summary>
    public static class BundleDocumentMdiAndEdrsExtensions
    {
        public static BundleDocumentMdiAndEdrs BundleDocumentMdiAndEdrs(this Bundle bundle)
        {
            return new BundleDocumentMdiAndEdrs(bundle);
        }
    }
}
