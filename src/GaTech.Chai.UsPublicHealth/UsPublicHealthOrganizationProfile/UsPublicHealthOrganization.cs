using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.OrganizationProfile
{
    /// <summary>
    /// US Core Organization Profile Extensions
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-organization
    /// </summary>
    public class UsPublicHealthOrganization
    {
        readonly Organization organization;

        internal UsPublicHealthOrganization(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for US Core Organization Profile
        /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-organization
        /// </summary>
        public static Organization Create()
        {
            var organization = new Organization();
            organization.UsPublicHealthOrganization().AddProfile();
            return organization;
        }

        /// <summary>
        /// The official URL for the US Core Organization profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-organization";

        /// <summary>
        /// Set the assertion that an organization object conforms to the US Core Organization profile.
        /// </summary>
        public void AddProfile()
        {
            this.organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an ogranization object conforms to the US Core Organization profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.organization.RemoveProfile(ProfileUrl);
        }
    }
}
