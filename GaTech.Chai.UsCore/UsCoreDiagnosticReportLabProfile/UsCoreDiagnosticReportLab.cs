using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// US Core DiagnosticReport Profile
    /// hhttp://hl7.org/fhir/us/core/StructureDefinition/us-core-diagnosticreport-lab
    /// </summary>
    public class UsCoreDiagnosticReportLab
    {
        readonly DiagnosticReport diagnosticReport;

        internal UsCoreDiagnosticReportLab(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
            this.diagnosticReport.Category.SetCategory(new Coding("http://terminology.hl7.org/CodeSystem/v2-0074", "LAB", "Laboratory"));
        }

        /// <summary>
        /// Factory for US Core DiagnosticReport Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-diagnosticreport-lab
        /// </summary>
        public static DiagnosticReport Create()
        {
            var diagnosticReport = new DiagnosticReport();
            diagnosticReport.UsCoreDiagnosticReportLab().AddProfile();
            return diagnosticReport;
        }

        /// <summary>
        /// The official URL for the US Core DiagnosticReport profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-diagnosticreport-lab";

        /// <summary>
        /// Set profile for US Core DiagnosticReport profile
        /// </summary>
        public void AddProfile()
        {
            this.diagnosticReport.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Core DiagnosticReport profile
        /// </summary>
        public void RemoveProfile()
        {
            this.diagnosticReport.RemoveProfile(ProfileUrl);
        }
    }
}
