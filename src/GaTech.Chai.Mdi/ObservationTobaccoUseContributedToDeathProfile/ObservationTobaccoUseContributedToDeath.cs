using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationTobaccoUseContributedToDeathProfile
{
    /// <summary>
    /// MDI ObservationTobaccoUseContributedToDeath Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death
    /// </summary>
    public class ObservationTobaccoUseContributedToDeath
    {
        readonly Observation observation;

        internal ObservationTobaccoUseContributedToDeath(Observation observation)
        {
            this.observation = observation;
            this.observation.Status = ObservationStatus.Final;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69443-0", "Did tobacco use contribute to death", null);
        }

        /// <summary>
        /// Factory for MDI ObservationTobaccoUseContributedToDeath Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationTobaccoUseContributedToDeath().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the MDI ObservationTobaccoUseContributedToDeath profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death";

        /// <summary>
        /// Set the assertion that conforms to the ObservationTobaccoUseContributedToDeath profile.
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that conforms to the MDI ObservationHowDeathInjuryOccurred profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
