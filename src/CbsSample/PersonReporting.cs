using System;
using GaTech.Chai.Cbs.CbsPersonReportingToCDCProfile;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class PersonReporting
    {
        public PersonReporting()
        {
        }

        public static Practitioner Create(String family, String given)
        {
            Practitioner practitioner = CbsPersonReportingToCDC.Create();
            practitioner.Name.Add(new HumanName().WithGiven(given).AndFamily(family));

            return practitioner;
        }
    }
}
