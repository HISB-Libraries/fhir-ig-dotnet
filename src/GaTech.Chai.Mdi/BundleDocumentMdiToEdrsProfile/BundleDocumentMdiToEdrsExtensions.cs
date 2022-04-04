using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.BundleDocumentMdiToEdrsProfile
{
    /// <summary>
    /// Class with Bundle extensions for the BundleDocumentMdiToEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs
    /// </summary>
    public static class BundleDocumentMdiToEdrsExtensions
    {
        public static BundleDocumentMdiToEdrs BundleDocumentMdiToEdrs(this Bundle bundle)
        {
            return new BundleDocumentMdiToEdrs(bundle);
        }
    }
}
