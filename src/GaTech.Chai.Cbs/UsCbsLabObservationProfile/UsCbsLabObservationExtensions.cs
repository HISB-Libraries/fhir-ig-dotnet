using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCbs.LabObservationProfile
{
    /// <summary>
    /// Class with Observation extensions for US Case Based Surveillance Lab Observation profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-observation
    /// </summary>
    public static class UsCbsLabObservationExtensions
    {
        public static UsCbsLabObservation UsCbsLabObservation(this Observation observation)
        {
            return new UsCbsLabObservation(observation);
        }
    }

}
