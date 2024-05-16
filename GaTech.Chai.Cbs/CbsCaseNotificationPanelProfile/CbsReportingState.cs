using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Reporting State Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-state
    /// </summary>
    public class CbsReportingState : CbsCaseNotificationPanel
    {
        internal CbsReportingState(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-state";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Reporting State Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-state
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsReportingState().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77966-0", "Reporting State", null);
            return observation;
        }

        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set => this.observation.Value = value;
        }
    }
}
