using System;
using System.Collections.Generic;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.TravelHistoryProfile
{
    /// <summary>
    /// US Core Public Health Travel History Profile Extensions
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-travel-history
    /// </summary>
    public class UsPublicHealthTravelHistory
    {
        readonly Observation observation;
        readonly TravelLocation travelLocation;
        readonly TravelPurpose travelPurpose;

        internal UsPublicHealthTravelHistory(Observation observation)
        {
            this.observation = observation;
            this.travelLocation = new TravelLocation(observation);
            this.travelPurpose = new TravelPurpose(observation);
        }

        /// <summary>
        /// Factory for US Core Public Health Encounter Profile
        /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-travel-history
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.UsPublicHealthTravelHistory().AddProfile();
            observation.Code = new CodeableConcept("http://snomed.info/sct", "420008001", "Travel");
            observation.UsPublicHealthTravelHistory().TravelLocation.AddComponent();

            return observation;
        }

        public TravelLocation TravelLocation => this.travelLocation;

        public TravelPurpose TravelPurpose => this.travelPurpose;

        /// <summary>
        /// The official URL for Public Health Encounter profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-travel-history";

        /// <summary>
        /// Set the assertion that an condition object conforms to the US Core Condition profile.
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the US Core Condition profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
