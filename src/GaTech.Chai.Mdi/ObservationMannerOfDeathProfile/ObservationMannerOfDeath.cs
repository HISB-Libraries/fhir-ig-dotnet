using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationMannerOfDeathProfile
{
    /// <summary>
    /// ObservationMannerOfDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death
    /// </summary>
    public class ObservationMannerOfDeath
    {
        readonly Observation observation;

        internal ObservationMannerOfDeath(Observation observation)
        {
            this.observation = observation;
            this.observation.Status = ObservationStatus.Final;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69449-7", "Manner of death", null);
        }

        /// <summary>
        /// Factory for ObservationMannerOfDeathProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationMannerOfDeath().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for ObservationMannerOfDeathProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death";

        /// <summary>
        /// Set profile for ObservationMannerOfDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationMannerOfDeathProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
