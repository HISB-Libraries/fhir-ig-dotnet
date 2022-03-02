using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Cbs.CbsReportingSourceOrganizationProfile
{
    /// <summary>
    /// Case Based Surveillance Reporting Source Organization Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-source-organization
    /// </summary>
    public class CbsReportingSourceOrganization
    {
        readonly Organization organization;

        internal CbsReportingSourceOrganization(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Reporting Source Organization Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-source-organization
        /// </summary>
        public static Organization Create()
        {
            var organization = new Organization();
            organization.CbsReportingSourceOrganization().AddProfile();
            organization.Name = "Reporting Source";

            return organization;
        }


        /// <summary>
        /// Factory for Case Based Surveillance Reporting Source Organization Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-source-organization
        /// </summary>            
        public static Organization Create(string typeSystem, string typeValue)
        {
            var organization = new Organization();
            organization.CbsReportingSourceOrganization().AddProfile();
            organization.Name = "Reporting Source";
            organization.Type.Add(CbsReportingSourceOrganization.ReportingSourceType.Encode(typeSystem, typeValue));

            return organization;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Reporting Source Organization profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-reporting-source-organization";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Reporting Source Organization Profile.
        /// </summary>
        public void AddProfile()
        {
            organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Reporting Source Organization Profile.
        /// </summary>
        public void RemoveProfile()
        {
            organization.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Reporting Source Type (2.16.840.1.114222.4.11.3036)
        /// Codes specifying the type of facility or provider associated with the source of information sent to Public Health.
        /// </summary>
        public static class ReportingSourceType
        {
            public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.3036";

            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
        }
    }
}