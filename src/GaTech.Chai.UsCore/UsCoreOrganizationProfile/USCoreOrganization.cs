using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;

namespace GaTech.Chai.UsCore.OrganizationProfile
{
    /// <summary>
    /// US Core Organization Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-organization
    /// </summary>
    public class UsCoreOrganization
    {
        readonly Organization organization;

        internal UsCoreOrganization(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for US Core Organization Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-organization
        /// </summary>
        public static Organization Create()
        {
            var organization = new Organization();
            organization.UsCoreOrganization().AddProfile();
            return organization;
        }

        /// <summary>
        /// The official URL for the US Core Organization profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-organization";

        /// <summary>
        /// Set profile for US Core Organization Profile
        /// </summary>
        public void AddProfile()
        {
            this.organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Core Organization Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.organization.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// System values for NPI and CLIA for the organiazation
        /// </summary>
        public static string NPISystem = "http://hl7.org/fhir/sid/us-npi";
        public static string CLIA = "urn:oid:2.16.840.1.113883.4.7";

    }
}
