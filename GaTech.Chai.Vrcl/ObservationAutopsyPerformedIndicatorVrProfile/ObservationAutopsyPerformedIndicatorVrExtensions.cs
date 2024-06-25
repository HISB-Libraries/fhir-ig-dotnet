using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl
{
    /// <summary>
    /// Class with Observation extensions for ObservationAutopsyPerformedIndicatorVrProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-autopsy-performed-indicator
    /// </summary>
    public static class ObservationAutopsyPerformedIndicatorVrExtensions
    {
        public static ObservationAutopsyPerformedIndicatorVr ObservationAutopsyPerformedIndicatorVr(this Observation observation)
        {
            return new ObservationAutopsyPerformedIndicatorVr(observation);
        }
    }
}
