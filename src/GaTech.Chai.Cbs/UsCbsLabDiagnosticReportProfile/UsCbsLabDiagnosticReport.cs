using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsCore.DiagnosticReportLabProfile;

namespace GaTech.Chai.UsCbs.LabDiagnosticReportProfile
{
    /// <summary>
    /// Case Based Surveillance Lab Condition Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-diagnosticreport
    /// </summary>
    public class UsCbsLabDiagnosticReport
    {
        readonly DiagnosticReport diagnosticReport;

        internal UsCbsLabDiagnosticReport(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Lab Condition Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-diagnosticreport
        /// </summary>
        public static DiagnosticReport Create()
        {
            var diagnosticReport = new DiagnosticReport();
            diagnosticReport.UsCbsLabDiagnosticReport().AddProfile();
            diagnosticReport.UsCoreDiagnosticReportLab().AddProfile();
            return diagnosticReport;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Lab Condition profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-diagnosticreport";

        /// <summary>
        /// Set the assertion that an condition object conforms to the Case Based Surveillance Lab Condition profile.
        /// </summary>
        public void AddProfile()
        {
            this.diagnosticReport.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the Case Based Surveillance Lab Condition profile.
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
