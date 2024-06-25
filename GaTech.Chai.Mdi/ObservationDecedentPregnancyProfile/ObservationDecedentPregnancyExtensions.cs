using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Observation extensions for ObservationDecedentPregnancyProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy
    /// </summary>
    public static class ObservationDecedentPregnancyExtensions
    {
        public static ObservationDecedentPregnancy ObservationDecedentPregnancy(this Observation observation)
        {
            return new ObservationDecedentPregnancy(observation);
        }
    }
}
