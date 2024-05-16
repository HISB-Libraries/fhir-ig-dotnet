using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;

namespace GaTech.Chai.UsCore.PractitionerRoleProfile
{
    /// <summary>
    /// UsCorePractitionerRole Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitionerrole
    /// </summary>
    public class UsCorePractitionerRole
    {
        readonly PractitionerRole practitionerRole;

        internal UsCorePractitionerRole(PractitionerRole practitionerRole)
        {
            this.practitionerRole = practitionerRole;
        }

        /// <summary>
        /// Factory for UsCorePractitionerRole Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitionerrole
        /// </summary>
        public static PractitionerRole Create()
        {
            var practitionerRole = new PractitionerRole();
            practitionerRole.UsCorePractitionerRole().AddProfile();
            return practitionerRole;
        }

        /// <summary>
        /// The official URL for the UsCorePractitionerRole profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitionerrole";

        /// <summary>
        /// Set profile for UsCorePractitionerRole Profile
        /// </summary>
        public void AddProfile()
        {
            this.practitionerRole.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for UsCorePractitionerRole Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.practitionerRole.RemoveProfile(ProfileUrl);
        }
    }
}
