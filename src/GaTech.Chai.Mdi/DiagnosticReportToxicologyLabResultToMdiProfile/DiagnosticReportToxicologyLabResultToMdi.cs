using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.UsCore.DiagnosticReportLabProfile;

namespace GaTech.Chai.Mdi.DiagnosticReportToxicologyLabResultToMdiProfile
{
    /// <summary>
    /// DiagnosticReportToxicologyLabResultToMdi Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi
    /// </summary>
    public class DiagnosticReportToxicologyLabResultToMdi
    {
        readonly DiagnosticReport diagnosticReport;

        internal DiagnosticReportToxicologyLabResultToMdi(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
        }

        /// <summary>
        /// Factory for DiagnosticReportToxicologyLabResultToMdi Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi
        /// </summary>
        public static DiagnosticReport Create()
        {
            var diagnosticReport = new DiagnosticReport();
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddProfile();
            diagnosticReport.UsCoreDiagnosticReportLab().AddProfile();
            return diagnosticReport;
        }

        /// <summary>
        /// The official URL for the DiagnosticReportToxicologyLabResultToMdi profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi";

        /// <summary>
        /// Set the assertion that a questionnaire object conforms to the Case Based Surveillance Composition Profile.
        /// </summary>
        public void AddProfile()
        {
            diagnosticReport.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a questionnaire object conforms to the Case Based Surveillance Composition Profile.
        /// </summary>
        public void RemoveProfile()
        {
            diagnosticReport.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Toxicology case number identifier. IG allows multiple numbers.
        /// Check system, value for existence.
        /// </summary>
        public (string, string) ToxCaseNumber
        {
            get
            {
                Identifier id = this.diagnosticReport.Identifier.GetIdentifier(MdiCodeSystem.ToxLabCaseNumber.Coding[0]);
                return (id.System, id.Value);
            }
            set
            {
                this.diagnosticReport.Identifier.AddOrUpdateIdentifier(MdiCodeSystem.ToxLabCaseNumber.Coding[0], value.Item1, value.Item2);
            }
        }
    }
}