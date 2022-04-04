using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsPublicHealth.OrganizationProfile
{
    /// <summary>
    /// US Public Health Organization Profile
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
        /// Factory for US Public Health Organization Profile
        /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-organization
        /// </summary>
        public static Organization Create()
        {
            var organization = new Organization();
            organization.UsPublicHealthOrganization().AddProfile();
            return organization;
        }

        /// <summary>
        /// The official URL for the US Public Health Organization Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-organization";

        /// <summary>
        /// Set profile for US Public Health Organization Profile
        /// </summary>
        public void AddProfile()
        {
            this.organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Public Health Organization Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.organization.RemoveProfile(ProfileUrl);
        }
    }
}
