using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.UsCore.DiagnosticReportLabProfile;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.DiagnosticReportToxicologyLabResultToMdiProfile
{
    /// <summary>
    /// DiagnosticReportToxicologyLabResultToMdiProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi
    /// </summary>
    public class DiagnosticReportToxicologyLabResultToMdi
    {
        readonly DiagnosticReport diagnosticReport;
        readonly static Dictionary<string, Resource> resources = new();

        internal DiagnosticReportToxicologyLabResultToMdi(DiagnosticReport diagnosticReport)
        {
            this.diagnosticReport = diagnosticReport;
            diagnosticReport.UsCoreDiagnosticReportLab().AddProfile();
        }

        /// <summary>
        /// Factory for DiagnosticReportToxicologyLabResultToMdiProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi
        /// </summary>
        public static DiagnosticReport Create()
        {
            var diagnosticReport = new DiagnosticReport();
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddProfile();
            return diagnosticReport;
        }

        /// <summary>
        /// Factory for DiagnosticReportToxicologyLabResultToMdiProfile with subject
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi
        /// </summary>
        public static DiagnosticReport Create(Patient subject)
        {
            var diagnosticReport = new DiagnosticReport();

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddProfile();
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().SubjectAsResource = subject;

            return diagnosticReport;
        }

        /// <summary>
        /// The official URL for the DiagnosticReportToxicologyLabResultToMdi profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/DiagnosticReport-toxicology-to-mdi";

        /// <summary>
        /// Set profile for the DiagnosticReportToxicologyLabResultToMdiProfile
        /// </summary>
        public void AddProfile()
        {
            diagnosticReport.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for DiagnosticReportToxicologyLabResultToMdiProfile
        /// </summary>
        public void RemoveProfile()
        {
            diagnosticReport.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Get and Set subject as Patient
        /// </summary>
        public Patient SubjectAsResource
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.diagnosticReport.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.diagnosticReport.Subject = value.AsReference();
                resources[value.AsReference().Reference] = value;
            }
        }

        /// <summary>
        /// Adding Performer
        /// </summary>
        public void AddPerformer(Resource performer)
        {
            if (!this.diagnosticReport.Performer.Contains(performer.AsReference()))
            {
                this.diagnosticReport.Performer.Add(performer.AsReference());
            }

            resources[performer.AsReference().Reference] = performer;
        }

        /// <summary>
        /// Adding Performer
        /// </summary>
        public void AddSpecimen(Specimen specimen)
        {
            if (!this.diagnosticReport.Specimen.Contains(specimen.AsReference()))
            {
                this.diagnosticReport.Specimen.Add(specimen.AsReference());
            }

            resources[specimen.AsReference().Reference] = specimen;
        }

        /// <summary>
        /// Adding Performer
        /// </summary>
        public void AddResult(Observation result)
        {
            if (!this.diagnosticReport.Result.Contains(result.AsReference()))
            {
                this.diagnosticReport.Result.Add(result.AsReference());
            }

            resources[result.AsReference().Reference] = result;
        }

        /// <summary>
        /// Tracking Number (EdrsFileNumber) extension identifier. IG allows multiple numbers.
        /// Check system, value for existence.
        /// </summary>
        public (string, string) EdrsFileNumber
        {
            get
            {
                foreach (Extension ext in this.diagnosticReport.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "edrs-file-number");
                    if (coding != null)
                    {
                        return ((ext.Value as Identifier).System, (ext.Value as Identifier).Value);
                    }
                }

                return (null, null);
            }

            set
            {
                Extension ext = new Extension() { Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number" };
                ext.Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.EdrsFileNumber, System = value.Item1, Value = value.Item2 };
                this.diagnosticReport.Extension.AddOrUpdateExtension(ext);
            }
        }

        /// <summary>
        /// Tracking Number (MDI Case Number) extension identifier
        /// </summary>
        public (string, string) MdiCaseNumber
        {
            get
            {
                foreach (Extension ext in this.diagnosticReport.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "mdi-case-number");
                    if (coding != null)
                    {
                        return ((ext.Value as Identifier).System, (ext.Value as Identifier).Value);
                    }
                }

                return (null, null);
            }

            set
            {
                Extension ext = new()
                {
                    Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number",
                    Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.MdiCaseNumber, System = value.Item1, Value = value.Item2 }
                };
                this.diagnosticReport.Extension.AddOrUpdateExtension(ext);
            }
        }

        /// <summary>
        /// Tracking Number (Toxicology Laboratory Case Number) extension identifier
        /// </summary>
        public (string, string) ToxLabCaseNumber
        {
            get
            {
                foreach (Extension ext in this.diagnosticReport.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "tox-lab-case-number");
                    if (coding != null)
                    {
                        return ((ext.Value as Identifier).System, (ext.Value as Identifier).Value);
                    }
                }

                return (null, null);
            }

            set
            {
                Extension ext = new()
                {
                    Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number",
                    Value = new Identifier() { Type = MdiCodeSystem.MdiCodes.ToxLabCaseNumber, System = value.Item1, Value = value.Item2 }
                };
                this.diagnosticReport.Extension.AddOrUpdateExtension(ext);
            }
        }

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}