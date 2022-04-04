using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationToxicologyLabResultProfile
{
    /// <summary>
    /// Class with Observation extensions for ObservationToxicologyLabResultProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result
    /// </summary>
    public static class ObservationToxicologyLabResultExtensions
    {
        public static ObservationToxicologyLabResult ObservationToxicologyLabResult(this Observation observation)
        {
            return new ObservationToxicologyLabResult(observation);
        }
    }
}
