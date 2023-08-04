using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ObservationAutopsyPerformedIndicatorProfile
{
    /// <summary>
    /// Class with Observation extensions for ObservationAutopsyPerformedIndicatorProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-autopsy-performed-indicator
    /// </summary>
    public static class ObservationAutopsyPerformedIndicatorExtensions
    {
        public static ObservationAutopsyPerformedIndicator ObservationAutopsyPerformedIndicator(this Observation observation)
        {
            return new ObservationAutopsyPerformedIndicator(observation);
        }
    }
}
