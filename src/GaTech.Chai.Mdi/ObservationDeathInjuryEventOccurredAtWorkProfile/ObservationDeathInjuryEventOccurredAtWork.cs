using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationDeathInjuryEventOccurredAtWorkProfile
{
    /// <summary>
    /// ObservationDeathInjuryEventOccurredAtWorkProfile
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
        /// Factory for ObservationDeathInjuryEventOccurredAtWorkProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-injury-at-work
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationDeathInjuryEventOccurredAtWork().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationDeathInjuryEventOccurredAtWorkProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-injury-at-work";

        /// <summary>
        /// Set profile for ObservationDeathInjuryEventOccurredAtWorkProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationDeathInjuryEventOccurredAtWorkProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
