using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.MdiToEdrsDocumentBundleProfile
{
    /// <summary>
    /// Class with Bundle extensions for Case Based Surveillance Document Bundle Profile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs
    /// </summary>
    public static class MdiToEdrsDocumentBundleExtensions
    {
    {
        public static MdiToEdrsDocumentBundle MdiToEdrsDocumentBundle(this Bundle bundle)
        {
            return new MdiToEdrsDocumentBundle(bundle);
        }
    }
}
