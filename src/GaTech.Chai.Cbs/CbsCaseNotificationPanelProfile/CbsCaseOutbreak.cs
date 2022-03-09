using System;
using System.Linq;
using GaTech.Chai.Cbs.Common;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Exposure Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-outbreak
    /// </summary>
    public class CbsCaseOutbreak : CbsCaseNotificationPanel
    {
        internal CbsCaseOutbreak(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-outbreak";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Exposure Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-outbreak
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsCaseOutbreak().AddProfile();
            observation.Code = UsCbsTemporaryCodeSystem.CaseOutbreakNameAndIndicator;

            return observation;
        }

        public string OutbreakName
        {
            get => this.observation.Component.GetComponent("http://loinc.org", "77981-9").Value.ToString();
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77981-9", "Case Outbreak Name");
                componentComponent.Value = new FhirString(value);
            }
        }

        public CodeableConcept OutbreakIndicator
        {
            get => this.observation.Component.GetComponent("http://loinc.org", "77980-1").Value as CodeableConcept;
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77980-1", "Case is associated with a known outbreak");
                componentComponent.Value = value;
            }

        }
    }
}
