using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Cbs.CbsLabTestReportProfile
{
    /// <summary>
    /// Case Based Surveillance Lab Test Report Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-diagnosticreport
    /// </summary>
    public class CbsLabTestReport
    {
        readonly DiagnosticReport diagnosticReport;

        internal CbsLabTestReport(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Lab Test Report Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-diagnosticreport
        /// </summary>
        public static DiagnosticReport Create()
        {
            var diagnosticReport = new DiagnosticReport();
            diagnosticReport.CbsLabTestReport().AddProfile();
            diagnosticReport.Category.Add(new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0074", "LAB"));

            return diagnosticReport;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Lab Test Report profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-diagnosticreport";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Lab Test Report Profile.
        /// </summary>
        public void AddProfile()
        {
            diagnosticReport.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Lab Test Report Profile.
        /// </summary>
        public void RemoveProfile()
        {
            diagnosticReport.RemoveProfile(ProfileUrl);
        }
    }
}