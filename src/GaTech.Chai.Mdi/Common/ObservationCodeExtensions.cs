using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.Common
{
    public static class ObservationCodeExtensions
    {
        public static Boolean IsObservationCauseOfDeathPart1(this Observation observation)
        {
            if ("69453-9".Equals(observation.Code?.Coding?[0].Code)
                && "http://loinc.org".Equals(observation.Code?.Coding?[0].System)) {
                return true;
            }

            return false;
        }

        public static Boolean IsObservationContributingCauseOfDeathPart2(this Observation observation)
        {
            if ("69441-4".Equals(observation.Code?.Coding?[0].Code)
                && "http://loinc.org".Equals(observation.Code?.Coding?[0].System)) {
                return true;
            }

            return false;
        }
    }
}

