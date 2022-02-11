using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.CbsReportingSourceOrganizationProfile;

namespace CbsProfileInitialization
{
    public class ReportingSource
    {
        public ReportingSource()
        {
        }

        public static Organization Create(CodeableConcept source, Address address)
        {
            Organization organization = CbsReportingSourceOrganization.Create();
            organization.Name = "Reporting Source";
            organization.Type.Add(source);
            organization.Address.Add(address);

            return organization;
        }
    }
}
