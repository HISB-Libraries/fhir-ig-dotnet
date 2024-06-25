using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// Class with Observation extensions for Us Core LabResultObservation Profile
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
