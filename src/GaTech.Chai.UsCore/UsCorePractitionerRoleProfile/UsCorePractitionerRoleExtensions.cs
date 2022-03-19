using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.PractitionerRoleProfile
{
    /// <summary>
    /// Class with PractitionerRole extensions for UsCorePractitionerRole profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitionerrole
    /// </summary>
    public static class UsCorePractitionerExtensions
    {
        public static UsCorePractitionerRole UsCorePractitionerRole(this PractitionerRole practitionerRole)
        {
            return new UsCorePractitionerRole(practitionerRole);
        }
    }
}
