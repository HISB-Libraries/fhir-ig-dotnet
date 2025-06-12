using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Observation extensions for ObservationCommunicableDiseaseProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-communicable-disease
    /// </summary>
    public static class ObservationCommunicableDiseaseExtensions
    {
        public static ObservationCommunicableDisease ObservationCommunicableDisease(this Observation observation)
        {
            return new ObservationCommunicableDisease(observation);
        }
    }
}
