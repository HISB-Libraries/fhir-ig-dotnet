using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsLabObservationProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Lab Observation profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-observation
    /// </summary>
    public static class CbsLabObservationExtensions
    {
        public static CbsLabObservation CbsLabObservation(this Observation observation)
        {
            return new CbsLabObservation(observation);
        }
    }

}
