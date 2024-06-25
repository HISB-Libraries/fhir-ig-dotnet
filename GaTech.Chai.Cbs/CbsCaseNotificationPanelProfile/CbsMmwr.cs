using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Morbidity and Mortality Weekly Report (MMWR) Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-mmwr
    /// </summary>
    public class CbsMmwr : CbsCaseNotificationPanel
    {
        internal CbsMmwr(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-mmwr";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Morbidity and Mortality Weekly Report (MMWR) Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-mmwr
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsMmwr().AddProfile();
            observation.Code = new CodeableConcept("http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "MMWR");
            return observation;
        }

        /// <summary>
        /// MMWR Week 
        /// </summary>
        public int? MMWRWeek
        {
            get => (this.observation.Component.GetComponent("http://loinc.org", "77991-8")?.Value as Integer)?.Value;
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77991-8", null);
                componentComponent.Value = new Integer(value);
            }
        }

        /// <summary>
        /// MMWR Year
        /// </summary>
        public int? MMWRYear
        {
            get => (this.observation.Component.GetComponent("http://loinc.org", "77992-6")?.Value as Integer)?.Value;
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77992-6", null);
                componentComponent.Value = new Integer(value);
            }
        }
    }
}
