using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.DiagnosticReportLabProfile
{
    /// <summary>
    /// Class with Encounter extensions for Case Based Surveillance Encounter profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-diagnosticreport-lab
    /// </summary>
    public static class UsCoreDiagnosticReportExtensions
    {
        public static UsCoreDiagnosticReportLab UsCoreDiagnosticReportLab(this DiagnosticReport diagnosticReport)
        {
            return new UsCoreDiagnosticReportLab(diagnosticReport);
        }
    }
}
