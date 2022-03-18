using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.Common
{
    public class MdiCodeSystem
    {
        public MdiCodeSystem()
        {
        }

        public static CodeableConcept Demographics = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "demographics", "Demographics Section", null);
        public static CodeableConcept Circumstances = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "circumstances", "Circumstances of the Death Section", null);
        public static CodeableConcept Jurisdiction = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "jurisdiction", "Jurisdiction Section", null);
        public static CodeableConcept CauseManner = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "cause-manner", "Cause and Manner of Death Section", null);
        public static CodeableConcept MedicalHistory = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "medical-history", "Medical History Section", null);
        public static CodeableConcept ExamAutopsy = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "exam-autopsy", "Exam/Autopsy Section", null);
        public static CodeableConcept MdiCaseNumber = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "mdi-case-number", "MDI Case Number", null);
        public static CodeableConcept EdrsFileNumber = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "edrs-file-number", "EDRS File Number", null);
        public static CodeableConcept ToxLabCaseNumber = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "tox-lab-case-number", "Toxicology Laboratory Case Number", null);
        public static CodeableConcept MdiCaseNotesSummary = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "mdi-case-notes-summary", "MDI Case Notes Summary", null);
        public static CodeableConcept MdiCaseHistory = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "mdi-case-history", "MDI Case History", null);
        public static CodeableConcept ToxResultReport = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "tox-result-report", "Toxicology Lab Results", null);
        public static CodeableConcept Narratives = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "narratives", "Narratives", null);
        public static CodeableConcept Exact = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "exact", "Exact", null);
        public static CodeableConcept Approximate = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "approximate", "Approximate", null);
        public static CodeableConcept CourtAppointed = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", " court-appointed", "Court Appointed", null);
    }

    public class MdiVsYesNoNotApplicable
    {
        public static CodeableConcept Yes = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0136", "Y", "Yes", null);
        public static CodeableConcept No = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0136", "N", "No", null);
        public static CodeableConcept NA = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NA", "not applicable", null);
    }
}
