using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Transmission Mode Observation Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-transmission-mode
    /// </summary>
    public class CbsTransmissionMode : CbsCaseNotificationPanel
    {
        internal CbsTransmissionMode(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-transmission-mode";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Transmission Mode Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-transmission-mode
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsTransmissionMode().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77989-2", "Disease transmission mode", null);
            return observation;
        }

        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set => this.observation.Value = value;
        }
    }
}
