using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsCaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Morbidity and Mortality Weekly Report (MMWR) 
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
            observation.Status = ObservationStatus.Final;
            var catCode = new CodeableConcept("http://loinc.org", "78000-7");
            catCode.Coding.First().Display = "Case notification panel [CDC.PHIN]";
            observation.Category.Add(catCode);
            observation.Code = new CodeableConcept(
                "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "MMWR");
            return observation;
        }

        /// <summary>
        /// MMWR Week 
        /// </summary>
        public int? MMWRWeek
        {
            get
            {
                var component = GetComponent("77991-8");
                return (component?.Value as Integer)?.Value;
            }
            set
            {
                var component = GetOrAddComponent("77991-8");
                component.Value = new Integer(value);
            }
        }

        /// <summary>
        /// MMWR Year
        /// </summary>
        public int? MMWRYear
        {
            get
            {
                var component = GetComponent("77992-6");
                return (component?.Value as Integer)?.Value;
            }
            set
            {
                var component = GetOrAddComponent("77992-6");
                component.Value = new Integer(value);
            }
        }

        private string loincUrl = "http://loinc.org";

        private Observation.ComponentComponent AddComponent(string code)
        {
            var component = new Observation.ComponentComponent()
            {
                Code = new CodeableConcept(loincUrl, code)
            };
            observation.Component.Add(component);
            return component;
        }

        private Observation.ComponentComponent GetOrAddComponent(string code)
        {
            var component = GetComponent(code);
            if (component == null)
                component = AddComponent(code);
            return component;
        }

        private Observation.ComponentComponent GetComponent(string code)
        {
            var component = observation.Component.Find(
                c => c.Code.Coding.Exists(coding => coding.Code == code && coding.System == loincUrl));
            return component;
        }
    }
}
