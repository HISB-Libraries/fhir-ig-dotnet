using System;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;
using GaTech.Chai.UsCbs.LabDiagnosticReportProfile;
using GaTech.Chai.UsCore;

namespace CbsProfileInitialization
{
    public class HAICALabDiagnosticReport
    {
        public HAICALabDiagnosticReport()
        {
        }

        public static DiagnosticReport Create(Patient patient, Observation observation)
        {
            var diagnosticReport = UsCbsLabDiagnosticReport.Create();
            diagnosticReport.UsCoreDiagnosticReportLab().AddProfile();

            diagnosticReport.Subject = patient.AsReference();
            diagnosticReport.UsCbsLabDiagnosticReport().SetEffectiveDataAbsentReason();
            diagnosticReport.Result.Add(observation.AsReference());

            return diagnosticReport;
        }
    }
}
