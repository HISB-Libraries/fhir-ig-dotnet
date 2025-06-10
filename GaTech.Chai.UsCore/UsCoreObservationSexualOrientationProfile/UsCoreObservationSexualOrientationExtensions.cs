using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// Class with Location extensions for Us Core Location profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner
    /// </summary>
    public static class UsCoreObservationSexualOrientationExtensions
    {
        public static UsCoreObservationSexualOrientation UsCoreObservationSexualOrientation(this Observation observation)
        {
            return new UsCoreObservationSexualOrientation(observation);
        }
    }
}
