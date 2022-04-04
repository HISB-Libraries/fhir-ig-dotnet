using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.TravelHistoryProfile
{
    /// <summary>
    /// Class with Observation extensions for US Public Health Travel History Profile
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
