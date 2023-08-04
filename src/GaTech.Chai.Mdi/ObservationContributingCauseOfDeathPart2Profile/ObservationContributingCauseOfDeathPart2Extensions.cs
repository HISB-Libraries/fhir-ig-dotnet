using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationContributingCauseOfDeathPart2Profile
{
    /// <summary>
    /// Class with Observation extensions for ObservationContributingCauseOfDeathPart2Profile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-contributing-cause-of-death-part2
    /// </summary>
    public static class ObservationContributingCauseOfDeathPart2Extensions
    {
        public static ObservationContributingCauseOfDeathPart2 ObservationContributingCauseOfDeathPart2(this Observation observation)
        {
            return new ObservationContributingCauseOfDeathPart2(observation);
        }
    }
}
