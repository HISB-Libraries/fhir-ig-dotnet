using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with DiagnosticReport extensions for DiagnosticReportToxicologyLabResultToMdiProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi
    /// </summary>
    public static class DiagnosticReportToxicologyLabResultToMdiExtensions
    {
        public static DiagnosticReportToxicologyLabResultToMdi DiagnosticReportToxicologyLabResultToMdi(this DiagnosticReport diagnosticReport)
        {
            return new DiagnosticReportToxicologyLabResultToMdi(diagnosticReport);
        }
    }
}
