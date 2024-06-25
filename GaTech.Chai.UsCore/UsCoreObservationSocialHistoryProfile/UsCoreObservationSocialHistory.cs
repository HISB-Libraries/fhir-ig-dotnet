using GaTech.Chai.Share;
using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// Us Core UsCoreObservationSocialHistory Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab
    /// </summary>
    public class UsCoreObservationSocialHistory
    {
        readonly Observation observation;

        internal UsCoreObservationSocialHistory(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for Us Core LabResultObservation Profile
        /// "http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-social-history";
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.Category = new List<CodeableConcept>() {
                CodeSystemsValueSets.UsCoreSocialHistoryCategory
            };

            observation.UsCoreObservationSocialHistory().AddProfile();

            return observation;
        }

        /// <summary>
        /// The official URL for the UsCoreObservationSocialHistory Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-social-history";

        /// <summary>
        /// Set profile for UsCoreObservationSocialHistory Profile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for UsCoreObservationSocialHistory Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
