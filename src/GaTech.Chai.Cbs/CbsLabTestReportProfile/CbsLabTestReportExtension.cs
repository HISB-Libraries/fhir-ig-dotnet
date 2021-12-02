using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsLabTestReportProfile
{
    /// <summary>
    /// Class with Immunization extensions for Case Based Surveillance Lab Test Report Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-diagnosticreport
    /// </summary>
    public static class CbsLabTestReportExtension
    {
        public static CbsLabTestReport CbsLabTestReport(this DiagnosticReport diagnosticReport)
        {
            return new CbsLabTestReport(diagnosticReport);
        }
    }
}
