using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.DocumentBundleProfile
{
    /// <summary>
    /// Class with Bundle extensions for Case Based Surveillance Document Bundle Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-document-bundle
    /// </summary>
    public static class CbsDocumentBundleExtensions
    {
        public static CbsDocumentBundle CbsDocumentBundle(this Bundle bundle)
        {
            return new CbsDocumentBundle(bundle);
        }
    }
}
