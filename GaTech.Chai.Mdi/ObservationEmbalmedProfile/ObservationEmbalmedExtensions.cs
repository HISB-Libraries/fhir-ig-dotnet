using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Observation extensions for Observation - Embalmed
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-embalmed
    /// </summary>
    public static class ObservationEmbalmedExtensions
    {
        public static ObservationEmbalmed ObservationEmbalmed(this Observation observation)
        {
            return new ObservationEmbalmed(observation);
        }
    }
}
