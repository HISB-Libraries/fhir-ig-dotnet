using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsCore.LabResultObservationProfile;

namespace GaTech.Chai.Mdi.ObservationToxicologyLabResultProfile
{
    /// <summary>
    /// ObservationToxicologyLabResultProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result
    /// </summary>
    public class ObservationToxicologyLabResult
    {
        readonly Observation observation;

        internal ObservationToxicologyLabResult(Observation observation)
        {
            this.observation = observation;
            this.observation.UsCoreLabResultObservation().AddProfile();
        }

        /// <summary>
        /// Factory for ObservationToxicologyLabResultProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationToxicologyLabResult().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationToxicologyLabResultProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result";

        /// <summary>
        /// Set profile for ObservationToxicologyLabResultProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationToxicologyLabResultProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
