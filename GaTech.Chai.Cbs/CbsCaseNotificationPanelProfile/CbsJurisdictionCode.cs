using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Jurisdiction Code Observation Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-jurisdiction-code
    /// </summary>
    public class CbsJurisdictionCode : CbsCaseNotificationPanel
    {
        internal CbsJurisdictionCode(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-jurisdiction-code";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Jurisdiction Code Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-jurisdiction-code
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsJurisdictionCode().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77969-4", "Jurisdiction Code", null);
            return observation;
        }

        public string Value
        {
            get => this.observation.Value.ToString();
            set => this.observation.Value = new FhirString(value);
        }
    }
}
