using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;

namespace GaTech.Chai.UsCbs.LabDiagnosticReportProfile
{
    /// <summary>
    /// US Case Based Surveillance Lab Diagnostic Report Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-diagnosticreport
    /// </summary>
    public class UsCbsLabDiagnosticReport
    {
        readonly DiagnosticReport diagnosticReport;

        internal UsCbsLabDiagnosticReport(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
            diagnosticReport.UsCoreDiagnosticReportLab().AddProfile();
        }

        /// <summary>
        /// Factory for US Case Based Surveillance Lab Diagnostic Report Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-diagnosticreport
        /// </summary>
        public static DiagnosticReport Create()
        {
            var diagnosticReport = new DiagnosticReport();
            diagnosticReport.UsCbsLabDiagnosticReport().AddProfile();
            return diagnosticReport;
        }

        /// <summary>
        /// The official URL for the Us Case Based Surveillance Lab Diagnostic Report Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-diagnosticreport";

        /// <summary>
        /// Set profile for US Case Based Surveillance Lab Diagnostic Report Profile
        /// </summary>
        public void AddProfile()
        {
            this.diagnosticReport.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Case Based Surveillance Lab Diagnostic Report Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.diagnosticReport.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Set data-absent-reason to effective[x]
        /// </summary>
        public void SetEffectiveDataAbsentReason()
        {
            EffectiveDataAbsentReason = new Code("masked");
        }
        public Code EffectiveDataAbsentReason
        {
            get => diagnosticReport.Effective?.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
            set
            {
                diagnosticReport.Effective = new FhirDateTime();
                diagnosticReport.Effective?.Extension.AddOrUpdateExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason", value);
            }
        }
    }
}
