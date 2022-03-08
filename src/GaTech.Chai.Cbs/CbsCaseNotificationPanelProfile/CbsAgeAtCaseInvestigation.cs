using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Exposure Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-age-at-investigation
    /// </summary>
    public class CbsAgeAtCaseInvestigation : CbsCaseNotificationPanel
    {
        internal CbsAgeAtCaseInvestigation(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-age-at-investigation";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Exposure Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-age-at-investigation
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsAgeAtCaseInvestigation().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77998-3", "Age at time of case investigation");
            return observation;
        }

        private string loincUrl = "http://loinc.org";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Case Notification Panel Profile.
        /// </summary>
        public void AddProfile()
        {
            AddProfile(ProfileUrl);
        }

        public void AddProfile(String profileUrl)
        {
            observation.AddProfile(profileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Case Notification Panel Profile.
        /// </summary>
        public void RemoveProfile()
        {
            observation.RemoveProfile(ProfileUrl);
        }

    }
}
