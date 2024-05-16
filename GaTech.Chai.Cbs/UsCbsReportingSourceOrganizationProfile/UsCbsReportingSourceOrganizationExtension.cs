using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.ReportingSourceOrganizationProfile
{
    /// <summary>
    /// Class with Organziation extensions for US Case Based Surveillance Reporting Source Organization Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-reporting-source-organization
    /// </summary>
    public static class UsCbsReportingSourceOrganizationExtension
    {
        public static UsCbsReportingSourceOrganization UsCbsReportingSourceOrganization(this Organization organization)
        {
            return new UsCbsReportingSourceOrganization(organization);
        }
    }
}
