using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationHowDeathInjuryOccurredProfile
{
    /// <summary>
    /// ObservationHowDeathInjuryOccurredProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred
    /// </summary>
    public class ObservationHowDeathInjuryOccurred
    {
        readonly Observation observation;

        internal ObservationHowDeathInjuryOccurred(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "11374-6", "Injury incident description Narrative", null);
        }

        /// <summary>
        /// Factory for ObservationHowDeathInjuryOccurredProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationHowDeathInjuryOccurred().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationHowDeathInjuryOccurredProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred";

        /// <summary>
        /// Set profile for ObservationHowDeathInjuryOccurredProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationHowDeathInjuryOccurredProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
