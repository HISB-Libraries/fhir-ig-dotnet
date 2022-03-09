using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Reporting County Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-county
    /// </summary>
    public class CbsReportingCounty : CbsCaseNotificationPanel
    {
        internal CbsReportingCounty(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-county";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Reporting County Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-county
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsReportingCounty().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77967-8", "Reporting County", null);
            return observation;
        }

        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set => this.observation.Value = value;
        }
    }
}
