using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;

namespace GaTech.Chai.Cbs.QuestionnaireProfile
{
    /// <summary>
    /// Case Based Surveillance Questionnaire Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-questionnaire
    /// </summary>
    public class CbsQuestionnaire
    {
        readonly Questionnaire questionnaire;

        internal CbsQuestionnaire(Questionnaire questionnaire)
        {
            this.questionnaire = questionnaire;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Questionnaire Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-questionnaire
        /// </summary>
        public static Questionnaire Create()
        {
            var questionnaire = new Questionnaire();
            questionnaire.CbsQuestionnaire().AddProfile();
            return questionnaire;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Questionnaire profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-questionnaire";

        /// <summary>
        /// Set profile for Case Based Surveillance Questionnaire Profile
        /// </summary>
        public void AddProfile()
        {
            questionnaire.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Case Based Surveillance Questionnaire Profile
        /// </summary>
        public void RemoveProfile()
        {
            questionnaire.RemoveProfile(ProfileUrl);
        }

    }
}