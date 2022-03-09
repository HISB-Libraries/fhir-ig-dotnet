using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Date of Initial Report Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-county
    /// </summary>
    public class CbsEarliestDateReported : CbsCaseNotificationPanel
    {
        internal CbsEarliestDateReported(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-county";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Date of Initial Report Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-county
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsEarliestDateReported().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77972-8", "Earliest Date Reported to County", null);
            return observation;
        }

        public FhirDateTime Value
        {
            get => this.observation.Value as FhirDateTime;
            set => this.observation.Value = value;
        }
    }
}
