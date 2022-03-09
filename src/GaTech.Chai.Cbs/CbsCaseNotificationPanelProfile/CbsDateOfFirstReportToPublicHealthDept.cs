using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Exposure Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-date-reported-to-phd
    /// </summary>
    public class CbsDateOfFirstReportToPublicHealthDept : CbsCaseNotificationPanel
    {
        internal CbsDateOfFirstReportToPublicHealthDept(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-date-reported-to-phd";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Exposure Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-date-reported-to-phd
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsDateOfFirstReportToPublicHealthDept().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77995-9", "Date of first report to public health department", null);
            return observation;
        }

        public FhirDateTime Value
        {
            get => this.observation.Value as FhirDateTime;
            set => this.observation.Value = value;
        }
    }
}
