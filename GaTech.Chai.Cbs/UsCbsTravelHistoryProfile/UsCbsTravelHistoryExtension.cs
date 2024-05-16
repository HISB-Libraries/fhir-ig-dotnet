using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.TravelHistoryProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Travel History Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-travel-history
    /// </summary>
    public static class UsCbsTravelHistoryExtension
    {
        public static UsCbsTravelHistory UsCbsTravelHistory(this Observation observation)
        {
            return new UsCbsTravelHistory(observation);
        }
    }
}
