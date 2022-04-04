using System;
using Hl7.Fhir.Model;

/// <summary>
/// MDI ValueSets
/// </summary>
namespace GaTech.Chai.Mdi.Common
{
    public class MdiCodeSystem
    {
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

    public class MdiVsMannerOfDeath
    {
        public static CodeableConcept NaturalDeath = new CodeableConcept("http://snomed.info/sct", "38605008", "Natural death (event)", null);
        public static CodeableConcept AccidentalDeath = new CodeableConcept("http://snomed.info/sct", "7878000", "Accidental death (event)", null);
        public static CodeableConcept Suicide = new CodeableConcept("http://snomed.info/sct", "44301001", "Suicide (event)", null);
        public static CodeableConcept Homicide = new CodeableConcept("http://snomed.info/sct", "27935005", "Homicide (event)", null);
        public static CodeableConcept PatientAwaitingInvestigation = new CodeableConcept("http://snomed.info/sct", "185973002", "Patient awaiting investigation (finding)", null);
        public static CodeableConcept DeathmannerUndetermined = new CodeableConcept("http://snomed.info/sct", " 65037004", "Death, manner undetermined (event)", null);
    }

    public class MdiVsDeathPregnancyStatus
    {
        public static CodeableConcept NotPregnantPastYear = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "1", "Not pregnant within past year", null);
        public static CodeableConcept PregnantAtTimeOfDeath = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "2", "Pregnant at time of death", null);
        public static CodeableConcept NotpregnantButPregnant42DaysOfDeath = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "3", "Not pregnant, but pregnant within 42 days of death", null);
        public static CodeableConcept NotPregnantButPregnant43DaysTo1YearBeforeDeath = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "4", "Not pregnant, but pregnant 43 days to 1 year before death", null);
        public static CodeableConcept UnknownIfPregnantPastYear = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "9", "Unknown if pregnant within the past year", null);
        public static CodeableConcept NA = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", " NA", "Not applicable", null);
    }

    public class MdiVsContributoryTobaccoUse
    {
        public static CodeableConcept Yes = new CodeableConcept("http://snomed.info/sct", "373066001", "Yes", null);
        public static CodeableConcept No = new CodeableConcept("http://snomed.info/sct", "373067005	", "No", null);
        public static CodeableConcept Probably = new CodeableConcept("http://snomed.info/sct", "2931005", "Probably", null);
        public static CodeableConcept Unknown = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "Unknown", null);
        public static CodeableConcept NotAsked = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NASK", "not asked", null);
    }

}
