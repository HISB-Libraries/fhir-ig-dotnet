using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.Common
{
    public static class ObservationCodeExtensions
    {
        public static Boolean IsObservationCode(this Observation observation, string code)
        {
            if ("CauseOfDeathPart1".Equals(code)
                && "69453-9".Equals(observation.Code?.Coding?[0].Code)
                && "http://loinc.org".Equals(observation.Code?.Coding?[0].System)) {
                return true;
            } else if ("ContributingCauseOfDeathPart2".Equals(code)
                && "69441-4".Equals(observation.Code?.Coding?[0].Code)
                && "http://loinc.org".Equals(observation.Code?.Coding?[0].System)) {
                return true;
            }

            return false;
        }
    }
}

