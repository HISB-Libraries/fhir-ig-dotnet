using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.PractitionerProfile
{
    /// <summary>
    /// Class with Encounter extensions for Case Based Surveillance Encounter profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner
    /// </summary>
    public static class UsCorePractitionerExtensions
    {
        public static UsCorePractitioner UsCorePractitioner(this Practitioner practitioner)
        {
            return new UsCorePractitioner(practitioner);
        }
    }
}
