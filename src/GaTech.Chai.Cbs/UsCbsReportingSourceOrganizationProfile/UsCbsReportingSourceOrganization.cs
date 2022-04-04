using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsPublicHealth.OrganizationProfile;
using static Hl7.Fhir.Model.ContactPoint;
using GaTech.Chai.UsCore.OrganizationProfile;

namespace GaTech.Chai.UsCbs.ReportingSourceOrganizationProfile
{
    /// <summary>
    /// US Case Based Surveillance Reporting Source Organization Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-reporting-source-organization
    /// </summary>
    public class UsCbsReportingSourceOrganization
    {
        readonly Organization organization;

        internal UsCbsReportingSourceOrganization(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for US Case Based Surveillance Reporting Source Organization Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-reporting-source-organization
        /// </summary>
        public static Organization Create()
        {
            var organization = new Organization();
            organization.UsCbsReportingSourceOrganization().AddProfile();
            organization.UsPublicHealthOrganization().AddProfile();
            organization.UsCoreOrganization().AddProfile();

            organization.Active = true;
            organization.Name = "Reporting Source";

            return organization;
        }

        /// <summary>
        /// The official URL for the US Case Based Surveillance Reporting Source Organization Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-reporting-source-organization";

        /// <summary>
        /// Set profile for US Case Based Surveillance Reporting Source Organization Profile
        /// </summary>
        public void AddProfile()
        {
            organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Case Based Surveillance Reporting Source Organization Profile
        /// </summary>
        public void RemoveProfile()
        {
            organization.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Set data-absent-reason extension to Telecom
        /// </summary>
        public void SetTelecomDataAbsentReason()
        {
            TelecomDataAbsentReason = new Code("unknown");
        }
        public Code TelecomDataAbsentReason
        {
            get => organization.Telecom?[0].GetDataAbsentReason();
            set
            {
                if (organization.Telecom == null || organization.Telecom.Count == 0)
                {
                    organization.Telecom.Add(new ContactPoint());
                }
                organization.Telecom[0].AddDataAbsentReason(value);
            }
        }

        /// <summary>
        /// Set Phone number to Telecom
        /// </summary>
        public (ContactPointUse?, string) TelecomPhone
        {
            get
            {
                ContactPoint cp = organization.Telecom?.Find(t => t.System == ContactPoint.ContactPointSystem.Phone);
                if (cp != null)
                    return (cp.Use, cp.Value);
                else
                    return (null, null);
            }
            set => organization.Telecom?.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Phone, Use = value.Item1, Value = value.Item2 });
        }

        /// <summary>
        /// Set Phone number to Email
        /// </summary>
        public (ContactPointUse?, string) TelecomEmail
        {
            get
            {
                ContactPoint cp = organization.Telecom?.Find(t => t.System == ContactPoint.ContactPointSystem.Email);
                if (cp != null)
                    return (cp.Use, cp.Value);
                else
                    return (null, null);
            }
            set => organization.Telecom?.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Email, Use = value.Item1, Value = value.Item2 });
        }

    }
}