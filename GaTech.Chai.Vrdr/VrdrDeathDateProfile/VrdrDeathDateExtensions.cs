using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// Class with Observation extensions for ObservationDeathDateProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
    /// </summary>
    public static class VrdrDeathDateExtensions
    {
        public static VrdrDeathDate VrdrDeathDate(this Observation observation)
        {
            return new VrdrDeathDate(observation);
        }
    }
}
