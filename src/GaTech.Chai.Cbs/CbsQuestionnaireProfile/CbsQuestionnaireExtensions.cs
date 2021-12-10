using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsQuestionnaireProfile
{
    /// <summary>
    /// Class with Questionnaire extensions for Case Based Surveillance Questionnaire Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-questionnaire
    /// </summary>
    public static class CbsQuestionnaireExtensions
    {
        public static CbsQuestionnaire CbsQuestionnaire(this Questionnaire questionnaire)
        {
            return new CbsQuestionnaire(questionnaire);
        }
    }
}
