using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// Class with Observation extensions for ObservationMannerOfDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death
    /// </summary>
    public static class VrdrMannerOfDeathExtensions
    {
        public static VrdrMannerOfDeath VrdrMannerOfDeath(this Observation observation)
        {
            return new VrdrMannerOfDeath(observation);
        }
    }
}
