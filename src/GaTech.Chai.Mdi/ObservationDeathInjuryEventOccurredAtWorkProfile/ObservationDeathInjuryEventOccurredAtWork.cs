using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationDeathInjuryEventOccurredAtWorkProfile
{
    /// <summary>
    /// MDI ObservationDeathInjuryEventOccurredAtWork Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-injury-at-work
    /// </summary>
    public class ObservationDeathInjuryEventOccurredAtWork
    {
        readonly Observation observation;

        internal ObservationDeathInjuryEventOccurredAtWork(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69444-8", "Did death result from injury at work", null);
        }

        /// <summary>
        /// Factory for MDI ObservationDeathInjuryEventOccurredAtWork Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-injury-at-work
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationDeathInjuryEventOccurredAtWork().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the MDI ObservationDeathInjuryEventOccurredAtWork profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-injury-at-work";

        /// <summary>
        /// Set the assertion that conforms to the ObservationDeathInjuryEventOccurredAtWork profile.
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that conforms to the MDI ObservationDeathInjuryEventOccurredAtWork profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
