using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.LabResultObservationProfile
{
    /// <summary>
    /// Class with Observation extensions for US Core Lab Result profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab
    /// </summary>
    public static class UsCoreLabResultObservationExtensions
    {
        public static UsCoreLabResultObservation UsCoreLabResultObservation(this Observation observation)
        {
            return new UsCoreLabResultObservation(observation);
        }
    }
}
