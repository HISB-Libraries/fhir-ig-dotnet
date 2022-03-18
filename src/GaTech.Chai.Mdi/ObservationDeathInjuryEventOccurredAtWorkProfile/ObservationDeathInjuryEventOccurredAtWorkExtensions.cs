using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationDeathInjuryEventOccurredAtWorkProfile
{
    /// <summary>
    /// Class with Observation extensions for Observation DeathInjury Event Occurred At Work profile.
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-injury-at-work
    /// </summary>
    public static class ObservationDeathInjuryEventOccurredAtWorkExtensions
    {
        public static ObservationDeathInjuryEventOccurredAtWork ObservationDeathInjuryEventOccurredAtWork(this Observation observation)
        {
            return new ObservationDeathInjuryEventOccurredAtWork(observation);
        }
    }
}
