using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using static Hl7.Fhir.Model.Composition;
using GaTech.Chai.Mdi.Common;

namespace GaTech.Chai.Mdi.MditoEdrsCompositionProfile
{
    /// <summary>
    /// Medicolegal Deathh Investigation Composition Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs
    /// </summary>
    public class MdiToEdrsComposition
    {
        readonly Composition composition;

        internal MdiToEdrsComposition(Composition composition)
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
            composition.CbsComposition().AddProfile();
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
                ext.Value = new Identifier() { Type = MdiValueSet.MdiCaseNumber, Value = value };
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
                ext.Value = new Identifier() { Type = MdiValueSet.EdrsFileNumber, Value = value };
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
        /// Encounters
        /// </summary>
        public SectionComponent Encounters
        {
            get => GetOrAddSection("history-of-encounters", "History of Encounters (Hospitalizations)");
            set => AddOrUpdateSection("history-of-encounters", "History of Encounters (Hospitalizations)", value);
        }

        /// <summary>
        /// Case Notification
        /// </summary>
        public SectionComponent CaseNotification
        {
            get => GetOrAddSection("case-notification-panel", "Case Notification Panel");
            set => AddOrUpdateSection("case-notification-panel", "Case Notification Panel", value);
        }

        /// <summary>
        /// Reporting Entities
        /// </summary>
        public SectionComponent ReportingEntities
        {
            get => GetOrAddSection("reporting-entities", "Reporting Entities");
            set => AddOrUpdateSection("reporting-entities", "Reporting Entities", value);
        }

        /// <summary>
        /// Epi Observations
        /// </summary>
        public SectionComponent EpiObservations
        {
            get => GetOrAddSection("epi-observations", "Epi Observations");
            set => AddOrUpdateSection("epi-observations", "Epi Observations", value);
        }

        /// <summary>
        /// Occupational Data
        /// </summary>
        public SectionComponent OccupationalData
        {
            get => GetOrAddSection("occupational-data", "Occupational Data");
            set => AddOrUpdateSection("occupational-data", "Occupational Data", value);
        }

        /// <summary>
        /// Travel History
        /// </summary>
        public SectionComponent TravelHistory
        {
            get => GetOrAddSection("travel-history", "Travel History");
            set => AddOrUpdateSection("travel-history", "Travel History", value);
        }

        /// <summary>
        /// Social Determinants of Health
        /// </summary>
        public SectionComponent Sdoh
        {
            get => GetOrAddSection("social-determinants-of-health", "Social Determinants of Health");
            set => AddOrUpdateSection("social-determinants-of-health", "Social Determinants of Healthy", value);
        }

        /// <summary>
        /// Lab Related - (Case Based Surveillance Lab Test Report | Case Based Surveillance Lab Observation |
        /// Case Based Surveillance Performing Laboratory | Case Based Surveillance Specimen)
        /// </summary>
        public SectionComponent LabRelated
        {
            get => GetOrAddSection("lab-related", "Laboratory Related", "Laboratory Related Resources");
            set => AddOrUpdateSection("lab-related", "Laboratory Related", "Laboratory Related Resources", value);
        }

        /// <summary>
        /// Medication Administered
        /// </summary>
        public SectionComponent MedicationAdministered
        {
            get => GetOrAddSection("medication-administered", "Medication Administered");
            set => AddOrUpdateSection("medication-administered", "Medication Administered", value);
        }

        /// <summary>
        /// Vaccination
        /// </summary>
        public SectionComponent Vaccination
        {
            get => GetOrAddSection("vaccinations", "Vaccinations");
            set => AddOrUpdateSection("vaccinations", "Vaccinations", value);
        }

        /// <summary>
        /// Vital Records
        /// </summary>
        public SectionComponent VitalRecords
        {
            get => GetOrAddSection("vital-records", "Vital Records Reporting", "Vital Records Reporting (Death, Birth, or Fetal Death)");
            set => AddOrUpdateSection("vital-records", "Vital Records Reporting", "Vital Records Reporting (Death, Birth, or Fetal Death)", value);
        }

        /// <summary>
        /// Related Person
        /// </summary>
        public SectionComponent RelatedPerson
        {
            get => GetOrAddSection("related-persons", "Related Person");
            set => AddOrUpdateSection("related-persons", "Related Person", value);
        }

        /// <summary>
        /// Vital Records Reporting
        /// </summary>
        public SectionComponent VitalRecordsReporting
        {
            get => GetOrAddSection("vital-records", "Vital Records Reporting (Death, Birth, or Fetal Death)");
            set => AddOrUpdateSection("vital-records", "Vital Records Reporting (Death, Birth, or Fetal Death)", "Vital Records Reporting", value);
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