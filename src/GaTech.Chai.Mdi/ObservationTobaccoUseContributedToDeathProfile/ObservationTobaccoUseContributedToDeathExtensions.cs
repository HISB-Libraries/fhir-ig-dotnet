using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationTobaccoUseContributedToDeathProfile
{
    /// <summary>
    /// Class with Observation extensions for ObservationTobaccoUseContributedToDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death
    /// </summary>
    public static class ObservationTobaccoUseContributedToDeathExtensions
    {
        public static ObservationTobaccoUseContributedToDeath ObservationTobaccoUseContributedToDeath(this Observation observation)
        {
            return new ObservationTobaccoUseContributedToDeath(observation);
        }
    }
}
