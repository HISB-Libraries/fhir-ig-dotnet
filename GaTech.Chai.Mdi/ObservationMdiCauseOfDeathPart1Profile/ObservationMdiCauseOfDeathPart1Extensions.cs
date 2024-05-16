using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationMdiCauseOfDeathPart1Profile
{
    /// <summary>
    /// Class with Observation extensions for ObservationCauseOfDeathPart1Profile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-part1
    /// </summary>
    public static class ObservationMdiCauseOfDeathPart1Extensions
    {
        public static ObservationMdiCauseOfDeathPart1 ObservationMdiCauseOfDeathPart1(this Observation observation)
        {
            return new ObservationMdiCauseOfDeathPart1(observation);
        }
    }
}
