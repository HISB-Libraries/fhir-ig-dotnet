using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Age At Case Investigateion Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-age-at-investigation
    /// </summary>
    public class CbsAgeAtCaseInvestigation : CbsCaseNotificationPanel
    {
        internal CbsAgeAtCaseInvestigation(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-age-at-investigation";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Age At Case Investigateion Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-age-at-investigation
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsAgeAtCaseInvestigation().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77998-3", "Age at time of case investigation", null);
            return observation;
        }

        public Quantity Value
        {
            get => this.observation.Value as Quantity;
            set => this.observation.Value = value;
        }
    }
}
