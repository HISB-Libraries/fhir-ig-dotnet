using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.UsCbs.ReportingSourceOrganizationProfile;

namespace CbsProfileInitialization
{
    public class ReportingSource
    {
        public ReportingSource()
        {
        }

        public static Organization Create(CodeableConcept source, Address address)
        {
            Organization organization = UsCbsReportingSourceOrganization.Create();
            organization.Type.Add(source);
            organization.Address.Add(address);

            organization.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "myorg@reportingagent.org");
            return organization;
        }
    }
}
