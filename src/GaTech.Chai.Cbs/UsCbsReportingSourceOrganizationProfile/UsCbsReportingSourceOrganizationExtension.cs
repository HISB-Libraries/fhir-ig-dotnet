using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.ReportingSourceOrganizationProfile
{
    /// <summary>
    /// Class with Organziation extensions for Case Based Surveillance Performing Laboratory Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-performing-lab
    /// </summary>
    public static class UsCbsReportingSourceOrganizationExtension
    {
        public static UsCbsReportingSourceOrganization UsCbsReportingSourceOrganization(this Organization organization)
        {
            return new UsCbsReportingSourceOrganization(organization);
        }
    }
}
