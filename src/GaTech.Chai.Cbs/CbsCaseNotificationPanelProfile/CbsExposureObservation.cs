using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsCaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Exposure Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-exposure-observation
    /// </summary>
    public class CbsExposureObservation : CbsCaseNotificationPanel
    {
        internal CbsExposureObservation(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-exposure-observation";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Exposure Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-exposure-observation
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsExposureObservation().AddProfile();
            observation.Status = ObservationStatus.Final;
            var catCode = new CodeableConcept("http://loinc.org", "78000-7");
            catCode.Coding.First().Display = "Case notification panel [CDC.PHIN]";
            observation.Category.Add(catCode);
            observation.Code = new CodeableConcept(
                "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "Location-of-Exposure");
            return observation;
        }

        /// <summary>
        /// Country Of Exposure (2.16.840.1.114222.4.11.828)
        /// Codes representing country of origin, nationality, citizenship, address country
        /// </summary>
        public CodeableConcept CountryOfExposure
        {
            get
            {
                var component = GetComponent("77984-3");
                return component?.Value as CodeableConcept;
            }
            set
            {
                var component = GetOrAddComponent("77984-3");
                component.Value = value;
            }
        }

        /// <summary>
        /// State or Province of Exposure (2.16.840.1.114222.4.11.7158)
        /// Indicates the state in which the disease was potentially acquired.
        /// </summary>
        public CodeableConcept StateOrProvinceOfExposure
        {
            get
            {
                var component = GetComponent("77985-0");
                return component?.Value as CodeableConcept;
            }
            set
            {
                var component = GetOrAddComponent("77985-0");
                component.Value = value;
            }
        }

        /// <summary>
        /// City of Exposure.
        /// Indicates the city in which the disease was potentially acquired.
        /// </summary>
        public string CityOfExposure
        {
            get
            {
                var component = GetComponent("77986-8");
                return (component?.Value as FhirString)?.Value;
            }
            set
            {
                var component = GetOrAddComponent("77986-8");
                component.Value = new FhirString(value);
            }
        }

        /// <summary>
        /// County of Exposure.
        /// Indicates the city in which the disease was potentially acquired.
        /// </summary>
        public string CountyOfExposure
        {
            get
            {
                var component = GetComponent("77987-6");
                return (component?.Value as FhirString)?.Value;
            }
            set
            {
                var component = GetOrAddComponent("77987-6");
                component.Value = new FhirString(value);
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
