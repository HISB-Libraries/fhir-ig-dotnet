using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationMannerOfDeathProfile
{
    /// <summary>
    /// Class with Observation extensions for ObservationMannerOfDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death
    /// </summary>
    public static class ObservationMannerOfDeathExtensions
    {
        public static ObservationMannerOfDeath ObservationMannerOfDeath(this Observation observation)
        {
            return new ObservationMannerOfDeath(observation);
        }
    }
}
