using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance National Reporting Jurisdiction Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-national-reporting-jurisdiction
    /// </summary>
    public class CbsNationalReportingJurisdiction : CbsCaseNotificationPanel
    {
        internal CbsNationalReportingJurisdiction(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-national-reporting-jurisdiction";
        }

        /// <summary>
        /// Factory for Case Based Surveillance National Reporting Jurisdiction Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-national-reporting-jurisdiction
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsNationalReportingJurisdiction().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77968-6", "National Reporting Jurisdiction", null);
            return observation;
        }

        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set => this.observation.Value = value;
        }
    }
}
