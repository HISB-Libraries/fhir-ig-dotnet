using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsTravelHistoryProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Travel History Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-travel-history
    /// </summary>
    public static class CbsTravelHistoryExtension
    {
        public static CbsTravelHistory CbsTravelHistory(this Observation observation)
        {
            return new CbsTravelHistory(observation);
        }
    }
}
