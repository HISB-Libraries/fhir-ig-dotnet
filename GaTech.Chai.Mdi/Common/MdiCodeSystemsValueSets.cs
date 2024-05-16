using System;
using System.Buffers.Text;
using Hl7.Fhir.Model;

/// <summary>
/// MDI ValueSets
/// </summary>
namespace GaTech.Chai.Mdi.Common
{
    public class MdiCodeSystem
    {
        public class MdiCodes
        {
            public const string officialUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-vr-codes";

            public static CodeableConcept AdditionalDemographics = new(officialUrl, "demographics", "Additional Demographics Section", null);
            public static CodeableConcept Circumstances = new(officialUrl, "circumstances", "Circumstances of the Death Section", null);
            public static CodeableConcept Jurisdiction = new(officialUrl, "jurisdiction", "Jurisdiction Section", null);
            public static CodeableConcept CauseManner = new(officialUrl, "cause-manner", "Cause and Manner of Death Section", null);
            public static CodeableConcept MedicalHistory = new(officialUrl, "medical-history", "Medical History Section", null);
            public static CodeableConcept ExamAutopsy = new(officialUrl, "exam-autopsy", "Exam/Autopsy Section", null);
            public static CodeableConcept MdiCaseNumber = new(officialUrl, "mdi-case-number", "MDI Case Number", null);
            public static CodeableConcept EdrsFileNumber = new(officialUrl, "edrs-file-number", "EDRS File Number", null);
            public static CodeableConcept ToxLabCaseNumber = new(officialUrl, "tox-lab-case-number", "Toxicology Laboratory Case Number", null);
            public static CodeableConcept MdiCaseNotesSummary = new(officialUrl, "mdi-case-notes-summary", "MDI Case Notes Summary", null);
            public static CodeableConcept MdiCaseHistory = new(officialUrl, "mdi-case-history", "MDI Case History", null);
            public static Coding ToxResultReport = new(officialUrl, "tox-result-report", "Toxicology Lab Results");
            public static CodeableConcept Narratives = new(officialUrl, "narratives", "Narratives", null);
            public static CodeableConcept Exact = new(officialUrl, "exact", "Exact", null);
            public static CodeableConcept Approximate = new(officialUrl, "approximate", "Approximate", null);
            public static CodeableConcept CourtAppointed = new(officialUrl, "court-appointed", "Court Appointed", null);
            public static CodeableConcept Injury = new(officialUrl, "injury", "Injury Location", null);
            public static CodeableConcept Death = new(officialUrl, "death", "Death Location", null);
        }

        public class DeathPregnancyStatus
        {
            public const string officialUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status";

            public static CodeableConcept NotPregnantPastYear = new(officialUrl, "1", "Not pregnant within past year", null);
            public static CodeableConcept PregnantAtTimeOfDeath = new(officialUrl, "2", "Pregnant at time of death", null);
            public static CodeableConcept NotpregnantButPregnant42DaysOfDeath = new(officialUrl, "3", "Not pregnant, but pregnant within 42 days of death", null);
            public static CodeableConcept NotPregnantButPregnant43DaysTo1YearBeforeDeath = new(officialUrl, "4", "Not pregnant, but pregnant 43 days to 1 year before death", null);
            public static CodeableConcept UnknownIfPregnantPastYear = new(officialUrl, "9", "Unknown if pregnant within the past year", null);
            public static CodeableConcept NA = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NA", "Not applicable", null);
        }
    }

    public class MdiVsYesNoUnknown
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-yes-no-unknown";

        public static CodeableConcept Yes = new("http://terminology.hl7.org/CodeSystem/v2-0136", "Y", "Yes", null);
        public static CodeableConcept No = new("http://terminology.hl7.org/CodeSystem/v2-0136", "N", "No", null);
        public static CodeableConcept UNK = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "unknown", null);
    }

    public class MdiVsYesNoUnknownNotApplicable
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-yes-no-unknown-not-applicable";

        public static CodeableConcept Yes = new("http://terminology.hl7.org/CodeSystem/v2-0136", "Y", "Yes", null);
        public static CodeableConcept No = new("http://terminology.hl7.org/CodeSystem/v2-0136", "N", "No", null);
        public static CodeableConcept UNK = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "unknown", null);
        public static CodeableConcept NA = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NA", "not applicable", null);
    }

    public class MdiVsMannerOfDeath
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-manner-of-death";

        public static CodeableConcept NaturalDeath = new ("http://snomed.info/sct", "38605008", "Natural death (event)", null);
        public static CodeableConcept AccidentalDeath = new ("http://snomed.info/sct", "7878000", "Accidental death (event)", null);
        public static CodeableConcept Suicide = new ("http://snomed.info/sct", "44301001", "Suicide (event)", null);
        public static CodeableConcept Homicide = new ("http://snomed.info/sct", "27935005", "Homicide (event)", null);
        public static CodeableConcept PatientAwaitingInvestigation = new ("http://snomed.info/sct", "185973002", "Patient awaiting investigation (finding)", null);
        public static CodeableConcept DeathmannerUndetermined = new ("http://snomed.info/sct", "65037004", "Death, manner undetermined (event)", null);
    }

    public class MdiVsContributoryTobaccoUse
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-contributory-tobacco-use";

        public static CodeableConcept Yes = new ("http://snomed.info/sct", "373066001", "Yes", null);
        public static CodeableConcept No = new ("http://snomed.info/sct", "373067005	", "No", null);
        public static CodeableConcept Probably = new ("http://snomed.info/sct", "2931005", "Probably", null);
        public static CodeableConcept Unknown = new ("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "Unknown", null);
        public static CodeableConcept NotAsked = new ("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NI", "no information", null);
    }

    public class MdiVsCertifierTypes
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-certifier-types";

        public static CodeableConcept MedicalExaminerCornerExamination = new("http://snomed.info/sct", "455381000124109", "Medical Examiner/Coroner-On the basis of examination, and/or investigation, in my opinion, death occurred at the time, date, and place, and due to the cause(s) and manner stated", null);
        public static CodeableConcept PronouncingAndCertifyingPhysican = new("http://snomed.info/sct", "434641000124105", "Pronouncing & Certifying physician-To the best of my knowledge, death occurred at the time, date, and place, and due to the cause(s) and manner stated", null);
        public static CodeableConcept CertifyingPhysician = new("http://snomed.info/sct", "434651000124107", "Certifying physician-To the best of my knowledge, death occurred due to the cause(s) and manner stated", null);
        public static CodeableConcept Other = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "OTH", "Other", null);
    }

    public class MdiVsPlaceOfDeath
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-place-of-death";

        public static CodeableConcept DeadOnArrivalAtHospital = new("http://snomed.info/sct", "63238001", "Dead on arrival at hospital", null);
        public static CodeableConcept DeathInHome = new ("http://snomed.info/sct", "440081000124100", "Death in home", null);
        public static CodeableConcept DeathInHospice = new ("http://snomed.info/sct", "440071000124103", "Death in hospice", null);
        public static CodeableConcept DeathInHospital = new ("http://snomed.info/sct", "16983000", "Death in hospital", null);
        public static CodeableConcept DeathInHospitalEmergencyDeptOrOutpatient = new("http://snomed.info/sct", "450391000124102", "Death in hospital-based emergency department or outpatient department", null);
        public static CodeableConcept DeathInNursingHomeOrLongTermCareFacility = new("http://snomed.info/sct", "450381000124100", "Death in nursing home or long term care facility", null);
        public static CodeableConcept Other = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "OTH", "Other", null);
        public static CodeableConcept UNK = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "UNK", null);        
    }

    public class MdiVsDateEstablishmentApproach
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-date-establishment-approach";

        public static CodeableConcept Exact = new("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "exact", "Exact", null);
        public static CodeableConcept Approximate = new("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "approximate", "Approximate", null);
        public static CodeableConcept CourtAppointed = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "court-appointed", "Court Appointed", null);
    }
}
