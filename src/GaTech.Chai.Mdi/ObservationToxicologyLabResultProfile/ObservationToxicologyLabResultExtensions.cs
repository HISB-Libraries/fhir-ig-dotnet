using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationToxicologyLabResultProfile
{
    /// <summary>
    /// Class with Observation extensions for US Core Lab Result profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab
    /// </summary>
    public static class ObservationToxicologyLabResultExtensions
    {
        public static ObservationToxicologyLabResult ObservationToxicologyLabResult(this Observation observation)
        {
            return new ObservationToxicologyLabResult(observation);
        }
    }
}
