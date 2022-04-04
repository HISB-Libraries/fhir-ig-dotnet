using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationHowDeathInjuryOccurredProfile
{
    /// <summary>
    /// Class with Observation extensions for ObservationHowDeathInjuryOccurredProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-injury-at-work
    /// </summary>
    public static class ObservationHowDeathInjuryOccurredExtensions
    {
        public static ObservationHowDeathInjuryOccurred ObservationHowDeathInjuryOccurred(this Observation observation)
        {
            return new ObservationHowDeathInjuryOccurred(observation);
        }
    }
}
