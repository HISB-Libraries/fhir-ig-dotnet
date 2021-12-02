using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsReportingSourceOrganizationProfile
{
    /// <summary>
    /// Class with Organziation extensions for Case Based Surveillance Performing Laboratory Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-performing-lab
    /// </summary>
    public static class CbsReportingSourceOrganizationExtension
    {
        public static CbsReportingSourceOrganization CbsReportingSourceOrganization(this Organization organization)
        {
            return new CbsReportingSourceOrganization(organization);
        }
    }
}
