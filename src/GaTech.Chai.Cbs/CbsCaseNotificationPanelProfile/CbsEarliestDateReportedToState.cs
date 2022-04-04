using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// CBS Earliest Date Reported To State Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-state
    /// </summary>
    public class CbsEarliestDateReportedToState : CbsCaseNotificationPanel
    {
        internal CbsEarliestDateReportedToState(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-state";
        }

        /// <summary>
        /// Factory for CBS Earliest Date Reported To State Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-state
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsEarliestDateReportedToState().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77973-6", "Earliest Date Reported to State", null);
            return observation;
        }

        public FhirDateTime Value
        {
            get => this.observation.Value as FhirDateTime;
            set => this.observation.Value = value;
        }
    }
}
