using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationDeathDateProfile
{
    /// <summary>
    /// ObservationDeathDateProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
    /// </summary>
    public class ObservationDeathDate
    {
        readonly Observation observation;

        internal ObservationDeathDate(Observation observation)
        {
            this.observation = observation;
            this.observation.Status = ObservationStatus.Final;
            this.observation.Code = new CodeableConcept("http://loinc.org", "81956-5", "Date and time of death [TimeStamp]", null);
        }

        /// <summary>
        /// Factory for ObservationDeathDateProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationDeathDate().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for ObservationDeathDateProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date";

        /// <summary>
        /// Set profile for the ObservationDeathDateProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationDeathDateProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Observation Location Extension
        /// </summary>
        public ResourceReference ObservationLocation
        {
            get => this.observation.GetExtension("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-observation-location")?.Value as ResourceReference;
            set => this.observation.Extension.AddOrUpdateExtension("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-observation-location", value);
        }
        
        /// <summary>
        /// Date and time pronounced dead.
        /// </summary>
        public FhirDateTime DateAndTimePronouncedDead
        {
            get => this.observation.Component?.GetComponent("http://loinc.org", "80616-6").Value as FhirDateTime;
            set
            {
                this.observation.Component.GetOrAddComponent("http://loinc.org", "80616-6", "Date and time pronounced dead [US Standard Certificate of Death]").Value = value;
            }
        }
    }
}
