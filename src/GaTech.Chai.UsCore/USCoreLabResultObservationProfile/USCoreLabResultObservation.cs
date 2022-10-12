using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;

namespace GaTech.Chai.UsCore.LabResultObservationProfile
{
    /// <summary>
    /// Us Core LabResultObservation Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab
    /// </summary>
    public class UsCoreLabResultObservation
    {
        readonly Observation observation;

        internal UsCoreLabResultObservation(Observation observation)
        {
            this.observation = observation;
            this.observation.Category.SetCategory(new Coding("http://terminology.hl7.org/CodeSystem/observation-category", "laboratory", "Laboratory"));
        }

        /// <summary>
        /// Factory for Us Core LabResultObservation Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.UsCoreLabResultObservation().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the Us Core LabResultObservation Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab";

        /// <summary>
        /// Set profile for Us Core LabResultObservation Profile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Us Core LabResultObservation Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
