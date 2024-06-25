using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// Class with Observation extensions for VrdrInjuryIncidentProfile
    /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-injury-incident
    /// </summary>
    public static class VrdrInjuryIncidentExtensions
    {
        public static VrdrInjuryIncident VrdrInjuryIncident(this Observation observation)
        {
            return new VrdrInjuryIncident(observation);
        }
    }
}
