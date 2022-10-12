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
            public const string officialUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes";

            public static CodeableConcept AdditionalDemographics = new(officialUrl, "demographics", "Demographics Section", null);
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

        public class LocalComponentCodes
        {
            public const string officialUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-local-component-codes";

            public static CodeableConcept Position = new(officialUrl, "position", "position", null);
            public static CodeableConcept LineNumber = new(officialUrl, "lineNumber", "lineNumber", null);
            public static CodeableConcept ECodeIndicator = new(officialUrl, "eCodeIndicator", "e Code Indicator", null);
            public static CodeableConcept WouldBeUnderlyingCauseOfDeathWithoutPregnancy = new(officialUrl, "wouldBeUnderlyingCauseOfDeathWithoutPregnancy", "Would be underlying cause of death without pregnancy", null);
            public static CodeableConcept EmergingIssue1_1 = new(officialUrl, "EmergingIssue1_1", "EmergingIssue1_1", null);
            public static CodeableConcept EmergingIssue1_2 = new(officialUrl, "EmergingIssue1_2", "EmergingIssue1_2", null);
            public static CodeableConcept EmergingIssue1_3 = new(officialUrl, "EmergingIssue1_3", "EmergingIssue1_3", null);
            public static CodeableConcept EmergingIssue1_4 = new(officialUrl, "EmergingIssue1_4", "EmergingIssue1_4", null);
            public static CodeableConcept EmergingIssue1_5 = new(officialUrl, "EmergingIssue1_5", "EmergingIssue1_5", null);
            public static CodeableConcept EmergingIssue1_6 = new(officialUrl, "EmergingIssue1_6", "EmergingIssue1_6", null);
            public static CodeableConcept EmergingIssue1_7 = new(officialUrl, "EmergingIssue1_7", "EmergingIssue1_7", null);
            public static CodeableConcept EmergingIssue1_8 = new(officialUrl, "EmergingIssue1_8", "EmergingIssue1_8", null);
            public static CodeableConcept EmergingIssue8_1 = new(officialUrl, "EmergingIssue8_1", "EmergingIssue8_1", null);
            public static CodeableConcept EmergingIssue8_2 = new(officialUrl, "EmergingIssue8_2", "EmergingIssue8_2", null);
            public static CodeableConcept EmergingIssue8_3 = new(officialUrl, "EmergingIssue8_3", "EmergingIssue8_3", null);
            public static CodeableConcept EmergingIssue20 = new(officialUrl, "EmergingIssue20", "EmergingIssue20", null);
            public static CodeableConcept FirstEditedCode = new(officialUrl, "FirstEditedCode", "First Edited Race Code", null);
            public static CodeableConcept SecondEditedCode = new(officialUrl, "SecondEditedCode", "Second Edited Race Code", null);
            public static CodeableConcept ThirdEditedCode = new(officialUrl, "ThirdEditedCode", "Third Edited Race Code", null);
            public static CodeableConcept FourthEditedCode = new(officialUrl, "FourthEditedCode", "Fourth Edited Race Code", null);
            public static CodeableConcept FifthEditedCode = new(officialUrl, "FifthEditedCode", "Fifth Edited Race Code", null);
            public static CodeableConcept SixthEditedCode = new(officialUrl, "SixthEditedCode", "Sixth Edited Race Code", null);
            public static CodeableConcept SeventhEditedCode = new(officialUrl, "SeventhEditedCode", "Seventh Edited Race Code", null);
            public static CodeableConcept EighthEditedCode = new(officialUrl, " EighthEditedCode", "Eighth Edited Race Code", null);
            public static CodeableConcept FirstAmericanIndianCode = new(officialUrl, "FirstAmericanIndianCode", "First Edited American Indian Race Code", null);
            public static CodeableConcept SecondAmericanIndianCode = new(officialUrl, "SecondAmericanIndianCode", "Second Edited American Indian Race Code", null);
            public static CodeableConcept FirstOtherAsianCode = new(officialUrl, "FirstOtherAsianCode", "First Edited Other Asian Race Code", null);
            public static CodeableConcept SecondOtherAsianCode = new(officialUrl, "SecondOtherAsianCode", "Second Edited Other Asian Race Race Code", null);
            public static CodeableConcept FirstOtherPacificIslanderCode = new(officialUrl, "FirstOtherPacificIslanderCode", "First Edited Other Pacific Islander Race Code", null);
            public static CodeableConcept SecondOtherPacificIslanderCode = new(officialUrl, " SecondOtherPacificIslanderCode", "First Edited Other Pacific Islander Race Code", null);
            public static CodeableConcept FirstOtherRaceCode = new(officialUrl, "FirstOtherRaceCode", "First Edited Other Race Code", null);
            public static CodeableConcept SecondOtherRaceCode = new(officialUrl, " SecondOtherRaceCode", "First Edited Other Race Code", null);
            public static CodeableConcept RaceRecode40 = new(officialUrl, "RaceRecode40", "Race Recode 40", null);
            public static CodeableConcept HispanicCode = new(officialUrl, " HispanicCode", "Hispanic Code", null);
            public static CodeableConcept HispanicCodeForLiteral = new(officialUrl, "HispanicCodeForLiteral", "Hispanic Code for Literal", null);
            public static CodeableConcept RACEMVR = new(officialUrl, " RACEMVR", "Race Missing Value Reason", null);
            public static CodeableConcept HispanicMexican = new(officialUrl, "HispanicMexican", "Hispanic Mexican", null);
            public static CodeableConcept HispanicPuertoRican = new(officialUrl, " HispanicPuertoRican", "Hispanic Puerto Rican", null);
            public static CodeableConcept HispanicCuban = new(officialUrl, "HispanicCuban", "Hispanic Cuban", null);
            public static CodeableConcept HispanicOther = new(officialUrl, " HispanicOther", "Hispanic Other", null);
            public static CodeableConcept HispanicLiteral = new(officialUrl, "HispanicLiteral", "Hispanic Literal", null);
            public static CodeableConcept White = new(officialUrl, " White", "White", null);
            public static CodeableConcept BlackOrAfricanAmerican = new(officialUrl, "BlackOrAfricanAmerican", "Black Or African American", null);
            public static CodeableConcept AmericanIndianOrAlaskanNative = new(officialUrl, " AmericanIndianOrAlaskanNative", "American Indian Or Alaska Native", null);
            public static CodeableConcept AsianIndian = new(officialUrl, "AsianIndian", "Asian Indian", null);
            public static CodeableConcept Chinese = new(officialUrl, "Chinese", "Chinese", null);
            public static CodeableConcept Filipino = new(officialUrl, "Filipino", "Filipino", null);
            public static CodeableConcept Japanese = new(officialUrl, "Japanese", "Japanese", null);
            public static CodeableConcept Korean = new(officialUrl, "Korean", "Korean", null);
            public static CodeableConcept Vietnamese = new(officialUrl, "Vietnamese", "Vietnamese", null);
            public static CodeableConcept OtherAsian = new(officialUrl, "OtherAsian", "OtherAsian", null);
            public static CodeableConcept NativeHawaiian = new(officialUrl, "NativeHawaiian", "Native Hawaiian", null);
            public static CodeableConcept GuamanianOrChamorro = new(officialUrl, "GuamanianOrChamorro", "Guamanian Or Chamorro", null);
            public static CodeableConcept Samoan = new(officialUrl, "Samoan", "Samoan", null);
            public static CodeableConcept OtherPacificIslander = new(officialUrl, "OtherPacificIslander", "Other Pacific Islander", null);
            public static CodeableConcept OtherRace = new(officialUrl, "OtherRace", "Other Race", null);
            public static CodeableConcept FirstAmericanIndianOrAlaskanNativeLiteral = new(officialUrl, "FirstAmericanIndianOrAlaskanNativeLiteral", "First American Indian Or Alaska Native Literal", null);
            public static CodeableConcept SecondAmericanIndianOrAlaskanNativeLiteral = new(officialUrl, "SecondAmericanIndianOrAlaskanNativeLiteral", "Second American Indian Or Alaska Native Literal", null);
            public static CodeableConcept FirstOtherAsianLiteral = new(officialUrl, "FirstOtherAsianLiteral", "First Other Asian Literal", null);
            public static CodeableConcept SecondOtherAsianLiteral = new(officialUrl, "SecondOtherAsianLiteral", "Second Other Asian Literal", null);
            public static CodeableConcept FirstOtherPacificIslanderLiteral = new(officialUrl, "FirstOtherPacificIslanderLiteral", "First Other Pacific Islander Literal", null);
            public static CodeableConcept SecondOtherPacificIslanderLiteral = new(officialUrl, "SecondOtherPacificIslanderLiteral", "Second Other Pacific Islander Literal", null);
            public static CodeableConcept FirstOtherRaceLiteral = new(officialUrl, "FirstOtherRaceLiteral", "First Other Race Literal", null);
            public static CodeableConcept SecondOtherRaceLiteral = new(officialUrl, "SecondOtherRaceLiteral", "Second Other Race Literal", null);
        }

        public class DeathPregnancyStatus
        {
            public const string officialUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status";

            public static CodeableConcept NotPregnantPastYear = new(officialUrl, "1", "Not pregnant within past year", null);
            public static CodeableConcept PregnantAtTimeOfDeath = new(officialUrl, "2", "Pregnant at time of death", null);
            public static CodeableConcept NotpregnantButPregnant42DaysOfDeath = new(officialUrl, "3", "Not pregnant, but pregnant within 42 days of death", null);
            public static CodeableConcept NotPregnantButPregnant43DaysTo1YearBeforeDeath = new(officialUrl, "4", "Not pregnant, but pregnant 43 days to 1 year before death", null);
            public static CodeableConcept UnknownIfPregnantPastYear = new(officialUrl, "9", "Unknown if pregnant within the past year", null);
            public static CodeableConcept NA = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", " NA", "Not applicable", null);
        }
    }

    public class MdiVsYesNoNotApplicable
    {
        public static CodeableConcept Yes = new ("http://terminology.hl7.org/CodeSystem/v2-0136", "Y", "Yes", null);
        public static CodeableConcept No = new ("http://terminology.hl7.org/CodeSystem/v2-0136", "N", "No", null);
        public static CodeableConcept NA = new ("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NA", "not applicable", null);
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

    public class MdiVsTransportationIncidentRole
    {
        public static CodeableConcept VehicleDriver = new("http://snomed.info/sct", "236320001", "Vehicle driver", null);
        public static CodeableConcept Passenger = new("http://snomed.info/sct", "257500003", "Passenger", null);
        public static CodeableConcept Pedestrian = new("http://snomed.info/sct", "257518000", "Pedestrian", null);
        public static CodeableConcept OTH = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "OTH", "Other", null);
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
        public static CodeableConcept DeathmannerUndetermined = new ("http://snomed.info/sct", " 65037004", "Death, manner undetermined (event)", null);
    }

    public class MdiVsContributoryTobaccoUse
    {
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
        public static CodeableConcept PronouncingAndCertifyingPhysican = new("http://snomed.info/sct", "434641000124105	", "Pronouncing & Certifying physician-To the best of my knowledge, death occurred at the time, date, and place, and due to the cause(s) and manner stated", null);
        public static CodeableConcept CertifyingPhysician = new("http://snomed.info/sct", "434651000124107", "Certifying physician-To the best of my knowledge, death occurred due to the cause(s) and manner stated", null);
        public static CodeableConcept Other = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "OTH", "Other ", null);
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
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-place-of-death";

        public static CodeableConcept Exact = new("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "exact", "Exact", null);
        public static CodeableConcept Approximate = new("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "approximate", "Approximate", null);
        public static CodeableConcept CourtAppointed = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "court-appointed", "Court Appointed", null);
    }
}
