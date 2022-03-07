using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.Common
{
    public class UsCbsTemporaryCodeSystem
    {
        public static string CodeSystemUrl = "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system";

        public UsCbsTemporaryCodeSystem()
        {
        }

        public static CodeableConcept UsualResidence => new CodeableConcept(CodeSystemUrl, "Usual-Residence", "Usual Residence", null);
        public static CodeableConcept AddressAtTimeOfDiagnosis => new CodeableConcept(CodeSystemUrl, "Address-at-Diagnosis", "Address at time of Diagnosis", null);
        public static CodeableConcept LocationOfExposure => new CodeableConcept(CodeSystemUrl, "Location-of-Exposure", "Location of Exposure", null);
        public static CodeableConcept LocalSubjectID => new CodeableConcept(CodeSystemUrl, "Local-Subject-ID", "Local Subject ID", null);
        public static CodeableConcept LocalRecordID => new CodeableConcept(CodeSystemUrl, "Local-Record-ID", "Local Record ID", null);
        public static CodeableConcept StateCaseIdentifier => new CodeableConcept(CodeSystemUrl, "State-Case-Identifier", "State Case Identifier", null);
        public static CodeableConcept LegacyCaseIdentifier => new CodeableConcept(CodeSystemUrl, "Legacy-Case-Identifier", "Legacy Case Identifier", null);
        public static CodeableConcept Laboratory => new CodeableConcept(CodeSystemUrl, "LAB", "Laboratory", null);
        public static CodeableConcept MMWR => new CodeableConcept(CodeSystemUrl, "MMWR", "MMWR Week/Year", null);
        public static CodeableConcept CaseOutbreakNameAndIndicator => new CodeableConcept(CodeSystemUrl, "case-outbreak", "Case Outbreak Name and Indicator", null);
        public static CodeableConcept CBSEpiQuestionnairePanel => new CodeableConcept(CodeSystemUrl, "epi-questionnaire", "Case Based Surveillance Epi Questionnaire Panel", null);
        public static CodeableConcept STDProgramQuestionnairePanel => new CodeableConcept(CodeSystemUrl, "std-program-questionnaire-panel", "STD Program Questionnaire Panel", null);
        public static CodeableConcept UndefinedEpiQuestionnaireCannonicalNamecode => new CodeableConcept(CodeSystemUrl, "undefined-epi-questionnaire-cannonical-name-code", "Undefined Epi Questionnaire Cannonical Name code", null);
        public static CodeableConcept PreviouslyReportedCase => new CodeableConcept(CodeSystemUrl, "previously-reported", "Previously Reported Case", null);
        public static CodeableConcept ConnectedOutbreakCase => new CodeableConcept(CodeSystemUrl, "connected-outbreak", "Connected Outbreak Case", null);
        public static CodeableConcept ParentInCongenitalSyphilis => new CodeableConcept(CodeSystemUrl, "parent-congential-syphilis", "Parent in Congenital Syphilis", null);
        public static CodeableConcept ConditionOnsetDateTime => new CodeableConcept(CodeSystemUrl, "conditionOnsetDateTime", "Condition.onsetDateTime", null);
        public static CodeableConcept ConditionOnsetDatePeriodStart => new CodeableConcept(CodeSystemUrl, "conditionOnsetDatePeriodStart", "Condition.onsetDatePeriod.start", null);
        public static CodeableConcept SexualOrientationAndGenderIdentity => new CodeableConcept(CodeSystemUrl, "sogi", "Sexual Orientation and Gender Identity", null);
        public static CodeableConcept HousingInsecurityOrResidenceCharacteristics => new CodeableConcept(CodeSystemUrl, "housing-or-residence", "Housing Insecurity or Residence Characteristics", null);
        public static CodeableConcept EducationLevel => new CodeableConcept(CodeSystemUrl, "education", "Education Level", null);
        public static CodeableConcept FoodInsecurity => new CodeableConcept(CodeSystemUrl, "food-insecurity", "Food Insecurity", null);
        public static CodeableConcept ConditionOfInterestReportableCondition => new CodeableConcept(CodeSystemUrl, "condition-of-interest", "Condition of Interest/Reportable Condition", null);
        public static CodeableConcept CaseNotificationPanel => new CodeableConcept(CodeSystemUrl, "case-notification-panel", "Case Notification Panel", null);
        public static CodeableConcept ReportingEntities => new CodeableConcept(CodeSystemUrl, "reporting-entities", "Reporting Entities", null);
        public static CodeableConcept HistoryOfEncounters => new CodeableConcept(CodeSystemUrl, "history-of-encounters", "History of Encounters (Hospitalizations)", null);
        public static CodeableConcept EpiObservations => new CodeableConcept(CodeSystemUrl, "epi-observations", "Epi Observations", null);
        public static CodeableConcept OccupationalData => new CodeableConcept(CodeSystemUrl, "occupational-data", "Occupational Data", null);
        public static CodeableConcept TravelHistory => new CodeableConcept(CodeSystemUrl, "travel-history", "Travel History", null);
        public static CodeableConcept SocialDeterminantsOfHealth => new CodeableConcept(CodeSystemUrl, "social-determinants-of-health", "Social Determinants of Health", null);
        public static CodeableConcept LaboratoryRelated => new CodeableConcept(CodeSystemUrl, "lab-related", "Laboratory Related", null);
        public static CodeableConcept MedicationAdministered => new CodeableConcept(CodeSystemUrl, "medication-administered", "Medication Administered", null);
        public static CodeableConcept Vaccinations => new CodeableConcept(CodeSystemUrl, "vaccinations", "Vaccinations", null);
        public static CodeableConcept RelatedPersons => new CodeableConcept(CodeSystemUrl, "related-persons", "Related Persons", null);
        public static CodeableConcept VitalRecordsReporting => new CodeableConcept(CodeSystemUrl, "vital-records", "Vital Records Reporting (Death, Birth, or Fetal Death)", null);
        public static CodeableConcept LabInterpretiveReport => new CodeableConcept(CodeSystemUrl, "lab-interpretative-report", "Lab Interpretive Report", null);
    }
}
