using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPersonReportingToCDCProfile
{
    /// <summary>
    /// Class with Practioner extensions for Case Based Surveillance Person Reporting To CDC Profile Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
    /// </summary>
    public static class CbsPersonReportingToCDCExtension
    {
        public static CbsPersonReportingToCDC CbsPersonReportingToCDC(this Practitioner practitioner)
        {
            return new CbsPersonReportingToCDC(practitioner);
        }
    }
}
