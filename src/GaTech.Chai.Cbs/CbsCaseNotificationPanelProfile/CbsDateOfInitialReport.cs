using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// CBS Date Of Initial Report Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-date-initial-report
    /// </summary>
    public class CbsDateOfInitialReport : CbsCaseNotificationPanel
    {
        internal CbsDateOfInitialReport(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-date-initial-report";
        }

        /// <summary>
        /// Factory for CBS Date Of Initial Report Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-date-initial-report
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsDateOfInitialReport().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77970-2", "Date of Initial Report", null);
            return observation;
        }

        public FhirDateTime Value
        {
            get => this.observation.Value as FhirDateTime;
            set => this.observation.Value = value;
        }
    }
}
