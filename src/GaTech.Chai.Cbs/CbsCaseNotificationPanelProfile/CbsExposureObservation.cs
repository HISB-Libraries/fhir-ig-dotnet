using System;
using System.Linq;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
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
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsExposureObservation().AddProfile();
            observation.Code = new CodeableConcept("http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "Location-of-Exposure");
            return observation;
        }

        /// <summary>
        /// Country Of Exposure (2.16.840.1.114222.4.11.828)
        /// Codes representing country of origin, nationality, citizenship, address country
        /// </summary>
        public CodeableConcept CountryOfExposure
        {
            get => this.observation.Component.GetComponent("http://loinc.org", "77984-3")?.Value as CodeableConcept;
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77984-3", null);
                componentComponent.Value = value;
            }
        }

        /// <summary>
        /// State or Province of Exposure (2.16.840.1.114222.4.11.7158)
        /// Indicates the state in which the disease was potentially acquired.
        /// </summary>
        public CodeableConcept StateOrProvinceOfExposure
        {
            get => this.observation.Component.GetComponent("http://loinc.org", "77985-0")?.Value as CodeableConcept;
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77985-0", null);
                componentComponent.Value = value;
            }
        }

        /// <summary>
        /// City of Exposure.
        /// Indicates the city in which the disease was potentially acquired.
        /// </summary>
        public string CityOfExposure
        {
            get => this.observation.Component.GetComponent("http://loinc.org", "77986-8")?.Value.ToString();
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77986-8", null);
                componentComponent.Value = new FhirString(value);
            }
        }

        /// <summary>
        /// County of Exposure.
        /// Indicates the city in which the disease was potentially acquired.
        /// </summary>
        public string CountyOfExposure
        {
            get => this.observation.Component.GetComponent("http://loinc.org", "77987-6")?.Value.ToString();
            set
            {
                Observation.ComponentComponent componentComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "77987-6", null);
                componentComponent.Value = new FhirString(value);
            }
        }
    }
}
