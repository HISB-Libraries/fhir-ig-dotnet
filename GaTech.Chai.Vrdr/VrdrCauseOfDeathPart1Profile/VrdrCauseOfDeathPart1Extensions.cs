using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    public static class VrdrCauseOfDeathPart1Extensions
    {
        public static VrdrCauseOfDeathPart1 VrdrCauseOfDeathPart1(this Observation observation)
        {
            return new VrdrCauseOfDeathPart1(observation);
        }
    }
}
