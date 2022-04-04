using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationConditionContributingToDeathProfile
{
    /// <summary>
    /// Class with Observation extensions for ObservationConditionContributingToDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-condition-contributing-to-death
    /// </summary>
    public static class ObservationConditionContributingToDeathExtensions
    {
        public static ObservationConditionContributingToDeath ObservationConditionContributingToDeath(this Observation observation)
        {
            return new ObservationConditionContributingToDeath(observation);
        }
    }
}
