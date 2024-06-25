using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// Class with Observation extensions for VrdrCauseOfDeathPart2Profile
    /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-cause-of-death-part2
    /// </summary>
    public static class VrdrCauseOfDeathPart2Extensions
    {
        public static VrdrCauseOfDeathPart2 VrdrCauseOfDeathPart2(this Observation observation)
        {
            return new VrdrCauseOfDeathPart2(observation);
        }
    }
}
