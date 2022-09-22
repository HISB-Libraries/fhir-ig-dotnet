using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationCauseOfDeathPart1Profile
{
    /// <summary>
    /// Class with Observation extensions for ObservationCauseOfDeathPart1Profile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-part1
    /// </summary>
    public static class ObservationCauseOfDeathConditionPart1Extensions
    {
        public static ObservationCauseOfDeathPart1 ObservationCauseOfDeathPart1(this Observation observation)
        {
            return new ObservationCauseOfDeathPart1(observation);
        }
    }
}
