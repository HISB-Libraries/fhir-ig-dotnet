using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.LabDiagnosticReportProfile
{
    /// <summary>
    /// Class with Observation extensions for US Case Based Surveillance Lab Diagnostic Report Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-diagnosticreport
    /// </summary>
    public static class UsCbsLabDiagnosticReportExtensions
    {
        public static UsCbsLabDiagnosticReport UsCbsLabDiagnosticReport(this DiagnosticReport diagnosticReport)
        {
            return new UsCbsLabDiagnosticReport(diagnosticReport);
        }
    }
}
