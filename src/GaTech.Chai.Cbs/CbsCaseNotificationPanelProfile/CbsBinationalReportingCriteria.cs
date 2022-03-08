using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Exposure Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-binational-reporting-criteria
    /// </summary>
    public class CbsBinationalReportingCriteria : CbsCaseNotificationPanel
    {
        internal CbsBinationalReportingCriteria(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-binational-reporting-criteria";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Exposure Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-binational-reporting-criteria
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsBinationalReportingCriteria().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77988-4", "Binational reporting criteria [CDC.PHIN]", null);
            return observation;
        }

        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set => this.observation.Value = value;
        }
    }
}
