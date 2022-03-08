using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.TravelHistoryProfile
{
    /// <summary>
    /// Class with Encounter extensions for Public Health Encounter profile.
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-travel-history
    /// </summary>
    public static class UsPublicHealthTravelHistoryExtensions
    {
        public static UsPublicHealthTravelHistory UsPublicHealthTravelHistory(this Observation observation)
        {
            return new UsPublicHealthTravelHistory(observation);
        }
    }
}
