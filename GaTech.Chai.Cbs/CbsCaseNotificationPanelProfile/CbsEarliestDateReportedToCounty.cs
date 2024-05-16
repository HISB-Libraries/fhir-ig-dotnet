using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// CBS Earliest Date Reported To County Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-county
    /// </summary>
    public class CbsEarliestDateReportedToCounty : CbsCaseNotificationPanel
    {
        internal CbsEarliestDateReportedToCounty(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-county";
        }

        /// <summary>
        /// Factory for CBS Earliest Date Reported To County Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-earliest-date-reported-to-county
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsEarliestDateReportedToCounty().AddProfile();
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
