using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// Class with Observation extensions for ObservationDecedentPregnancyProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy
    /// </summary>
    public static class ObservationDecedentPregnancyExtensions
    {
        public static VrdrDecedentPregnancyStatus VrdrDecedentPregnancyStatus(this Observation observation)
        {
            return new VrdrDecedentPregnancyStatus(observation);
        }
    }
}
