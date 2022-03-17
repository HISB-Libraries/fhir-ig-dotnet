using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ListCauseOfDeathPathwayProfile
{
    /// <summary>
    /// Class with List extensions for List-Cause Of Death Pathway Profile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/List-cause-of-death-pathway
    /// </summary>
    public static class MdiToEdrsDocumentBundleExtensions
    {
        public static ListCauseOfDeathPathway ListCauseOfDeathPathway(this List list)
        {
            return new ListCauseOfDeathPathway(list);
        }
    }
}
