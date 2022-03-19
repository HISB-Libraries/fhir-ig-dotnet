using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using static Hl7.Fhir.Model.Composition;
using GaTech.Chai.Mdi.Common;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.CompositionMditoEdrsProfile
{
    /// <summary>
    /// Medicolegal Deathh Investigation Composition Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs
    /// </summary>
    public class CompositionMdiToEdrs
    {
        readonly Composition composition;

        internal CompositionMdiToEdrs(Composition composition)
        {
            this.composition = composition;

            composition.Type = new CodeableConcept("http://loinc.org", "86807-5");
        }

        /// <summary>
        /// Factory for Medicolegal Deathh Investigation Composition Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs
        /// </summary>
        public static Composition Create()
        {
            var composition = new Composition();
            composition.CompositionMdiToEdrs().AddProfile();
            return composition;
        }

        /// <summary>
        /// The official URL for the Medicolegal Deathh Investigation Composition profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs";

        /// <summary>
        /// Set the assertion that a questionnaire object conforms to the Case Based Surveillance Composition Profile.
        /// </summary>
        public void AddProfile()
        {
            composition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a questionnaire object conforms to the Case Based Surveillance Composition Profile.
        /// </summary>
        public void RemoveProfile()
        {
            composition.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// MDI Case Number
        /// </summary>
        public string MdiCaseNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "mdi-case-number");
                    if (coding != null)
                    {
                        return ext.Value.ToString();
                    }
                }

                return null;
            }

            set
            {
                Extension ext = new Extension() { Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number" };
                ext.Value = new Identifier() { Type = MdiCodeSystem.MdiCaseNumber, Value = value };
                this.composition.Extension.AddOrUpdateExtension(ext);
            }
        }

        /// <summary>
        /// MDI Case Number
        /// </summary>
        public string EdrsFileNumber
        {
            get
            {
                foreach (Extension ext in this.composition.GetExtensions("http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number"))
                {
                    Coding coding = (ext.Value as Identifier).Type?.Coding?.Find(e => e.System == "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes" && e.Code == "edrs-file-number");
                    if (coding != null)
                    {
                        return ext.Value.ToString();
                    }
                }

                return null;
            }

            set
            {
                Extension ext = new Extension() { Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number" };
                ext.Value = new Identifier() { Type = MdiCodeSystem.EdrsFileNumber, Value = value };
                this.composition.Extension.AddOrUpdateExtension(ext);
            }
        }


        /// <summary>
        /// Condition of Interest
        /// </summary>
        public SectionComponent Demographics
        {
            get => GetOrAddSection("demographics", null);
            set => AddOrUpdateSection("demographics", null, value);
        }

        /// <summary>
        /// Circumstances
        /// </summary>
        public SectionComponent Circumstances
        {
            get => GetOrAddSection("circumstances", null);
            set => AddOrUpdateSection("circumstances", null, value);
        }

        /// <summary>
        /// Jurisdiction
        /// </summary>
        public SectionComponent Jurisdiction
        {
            get => GetOrAddSection("jurisdiction", null);
            set => AddOrUpdateSection("jurisdiction", null, value);
        }

        /// <summary>
        /// cause-manner
        /// </summary>
        public SectionComponent CauseManner
        {
            get => GetOrAddSection("cause-manner", null);
            set => AddOrUpdateSection("cause-manner", null, value);
        }

        /// <summary>
        /// Epi Observations
        /// </summary>
        public SectionComponent MedicalHistory
        {
            get => GetOrAddSection("medical-history", null);
            set => AddOrUpdateSection("medical-history", null, value);
        }

        /// <summary>
        /// Exam Autopsy
        /// </summary>
        public SectionComponent ExamAutopsy
        {
            get => GetOrAddSection("exam-autopsy", null);
            set => AddOrUpdateSection("exam-autopsy", null, value);
        }

        /// <summary>
        /// Narratives
        /// </summary>
        public SectionComponent Narratives
        {
            get => GetOrAddSection("narratives", null);
            set => AddOrUpdateSection("narratives", null, value);
        }

        protected SectionComponent GetOrAddSection(Coding coding)
        {
            return composition.Section.GetOrAddSection(coding.System, coding.Code,
                    coding.Display, coding.Display);
        }

        protected SectionComponent GetOrAddSection(string code, string display)
        {
            return composition.Section.GetOrAddSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", code,
                    display, display);
        }

        protected SectionComponent GetOrAddSection(string code, string display, string title)
        {
            return composition.Section.GetOrAddSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes",
                    code, title, display);
        }

        protected void AddOrUpdateSection(string code, string display, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", code,
                    display, display, section);
        }

        protected void AddOrUpdateSection(string code, string display, string title, Composition.SectionComponent section)
        {
            composition.Section.AddOrUpdateSection(
                    "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes",
                    code, title, display, section);
        }
    }
}