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
            public const string profileUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes";

            public static CodeableConcept AdditionalDemographics = new(profileUrl, "demographics", "Demographics Section", null);
            public static CodeableConcept Circumstances = new(profileUrl, "circumstances", "Circumstances of the Death Section", null);
            public static CodeableConcept Jurisdiction = new(profileUrl, "jurisdiction", "Jurisdiction Section", null);
            public static CodeableConcept CauseManner = new(profileUrl, "cause-manner", "Cause and Manner of Death Section", null);
            public static CodeableConcept MedicalHistory = new(profileUrl, "medical-history", "Medical History Section", null);
            public static CodeableConcept ExamAutopsy = new(profileUrl, "exam-autopsy", "Exam/Autopsy Section", null);
            public static CodeableConcept MdiCaseNumber = new(profileUrl, "mdi-case-number", "MDI Case Number", null);
            public static CodeableConcept EdrsFileNumber = new(profileUrl, "edrs-file-number", "EDRS File Number", null);
            public static CodeableConcept ToxLabCaseNumber = new(profileUrl, "tox-lab-case-number", "Toxicology Laboratory Case Number", null);
            public static CodeableConcept MdiCaseNotesSummary = new(profileUrl, "mdi-case-notes-summary", "MDI Case Notes Summary", null);
            public static CodeableConcept MdiCaseHistory = new(profileUrl, "mdi-case-history", "MDI Case History", null);
            public static CodeableConcept ToxResultReport = new(profileUrl, "tox-result-report", "Toxicology Lab Results", null);
            public static CodeableConcept Narratives = new(profileUrl, "narratives", "Narratives", null);
            public static CodeableConcept Exact = new(profileUrl, "exact", "Exact", null);
            public static CodeableConcept Approximate = new(profileUrl, "approximate", "Approximate", null);
            public static CodeableConcept CourtAppointed = new(profileUrl, "court-appointed", "Court Appointed", null);
            public static CodeableConcept Injury = new(profileUrl, "injury", "Injury Location", null);
            public static CodeableConcept Death = new(profileUrl, "death", "Death Location", null);
        }

        public class LocalComponentCodes
        {
            public const string profileUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-local-component-codes";

            public static CodeableConcept Position = new(profileUrl, "position", "position", null);
            public static CodeableConcept LineNumber = new(profileUrl, "lineNumber", "lineNumber", null);
            public static CodeableConcept ECodeIndicator = new(profileUrl, "eCodeIndicator", "e Code Indicator", null);
            public static CodeableConcept WouldBeUnderlyingCauseOfDeathWithoutPregnancy = new(profileUrl, "wouldBeUnderlyingCauseOfDeathWithoutPregnancy", "Would be underlying cause of death without pregnancy", null);
            public static CodeableConcept EmergingIssue1_1 = new(profileUrl, "EmergingIssue1_1", "EmergingIssue1_1", null);
            public static CodeableConcept EmergingIssue1_2 = new(profileUrl, "EmergingIssue1_2", "EmergingIssue1_2", null);
            public static CodeableConcept EmergingIssue1_3 = new(profileUrl, "EmergingIssue1_3", "EmergingIssue1_3", null);
            public static CodeableConcept EmergingIssue1_4 = new(profileUrl, "EmergingIssue1_4", "EmergingIssue1_4", null);
            public static CodeableConcept EmergingIssue1_5 = new(profileUrl, "EmergingIssue1_5", "EmergingIssue1_5", null);
            public static CodeableConcept EmergingIssue1_6 = new(profileUrl, "EmergingIssue1_6", "EmergingIssue1_6", null);
            public static CodeableConcept EmergingIssue1_7 = new(profileUrl, "EmergingIssue1_7", "EmergingIssue1_7", null);
            public static CodeableConcept EmergingIssue1_8 = new(profileUrl, "EmergingIssue1_8", "EmergingIssue1_8", null);
            public static CodeableConcept EmergingIssue8_1 = new(profileUrl, "EmergingIssue8_1", "EmergingIssue8_1", null);
            public static CodeableConcept EmergingIssue8_2 = new(profileUrl, "EmergingIssue8_2", "EmergingIssue8_2", null);
            public static CodeableConcept EmergingIssue8_3 = new(profileUrl, "EmergingIssue8_3", "EmergingIssue8_3", null);
            public static CodeableConcept EmergingIssue20 = new(profileUrl, "EmergingIssue20", "EmergingIssue20", null);
            public static CodeableConcept FirstEditedCode = new(profileUrl, "FirstEditedCode", "First Edited Race Code", null);
            public static CodeableConcept SecondEditedCode = new(profileUrl, "SecondEditedCode", "Second Edited Race Code", null);
            public static CodeableConcept ThirdEditedCode = new(profileUrl, "ThirdEditedCode", "Third Edited Race Code", null);
            public static CodeableConcept FourthEditedCode = new(profileUrl, "FourthEditedCode", "Fourth Edited Race Code", null);
            public static CodeableConcept FifthEditedCode = new(profileUrl, "FifthEditedCode", "Fifth Edited Race Code", null);
            public static CodeableConcept SixthEditedCode = new(profileUrl, "SixthEditedCode", "Sixth Edited Race Code", null);
            public static CodeableConcept SeventhEditedCode = new(profileUrl, "SeventhEditedCode", "Seventh Edited Race Code", null);
            public static CodeableConcept EighthEditedCode = new(profileUrl, " EighthEditedCode", "Eighth Edited Race Code", null);
            public static CodeableConcept FirstAmericanIndianCode = new(profileUrl, "FirstAmericanIndianCode", "First Edited American Indian Race Code", null);
            public static CodeableConcept SecondAmericanIndianCode = new(profileUrl, "SecondAmericanIndianCode", "Second Edited American Indian Race Code", null);
            public static CodeableConcept FirstOtherAsianCode = new(profileUrl, "FirstOtherAsianCode", "First Edited Other Asian Race Code", null);
            public static CodeableConcept SecondOtherAsianCode = new(profileUrl, "SecondOtherAsianCode", "Second Edited Other Asian Race Race Code", null);
            public static CodeableConcept FirstOtherPacificIslanderCode = new(profileUrl, "FirstOtherPacificIslanderCode", "First Edited Other Pacific Islander Race Code", null);
            public static CodeableConcept SecondOtherPacificIslanderCode = new(profileUrl, " SecondOtherPacificIslanderCode", "First Edited Other Pacific Islander Race Code", null);
            public static CodeableConcept FirstOtherRaceCode = new(profileUrl, "FirstOtherRaceCode", "First Edited Other Race Code", null);
            public static CodeableConcept SecondOtherRaceCode = new(profileUrl, " SecondOtherRaceCode", "First Edited Other Race Code", null);
            public static CodeableConcept RaceRecode40 = new(profileUrl, "RaceRecode40", "Race Recode 40", null);
            public static CodeableConcept HispanicCode = new(profileUrl, " HispanicCode", "Hispanic Code", null);
            public static CodeableConcept HispanicCodeForLiteral = new(profileUrl, "HispanicCodeForLiteral", "Hispanic Code for Literal", null);
            public static CodeableConcept RACEMVR = new(profileUrl, " RACEMVR", "Race Missing Value Reason", null);
            public static CodeableConcept HispanicMexican = new(profileUrl, "HispanicMexican", "Hispanic Mexican", null);
            public static CodeableConcept HispanicPuertoRican = new(profileUrl, " HispanicPuertoRican", "Hispanic Puerto Rican", null);
            public static CodeableConcept HispanicCuban = new(profileUrl, "HispanicCuban", "Hispanic Cuban", null);
            public static CodeableConcept HispanicOther = new(profileUrl, " HispanicOther", "Hispanic Other", null);
            public static CodeableConcept HispanicLiteral = new(profileUrl, "HispanicLiteral", "Hispanic Literal", null);
            public static CodeableConcept White = new(profileUrl, " White", "White", null);
            public static CodeableConcept BlackOrAfricanAmerican = new(profileUrl, "BlackOrAfricanAmerican", "Black Or African American", null);
            public static CodeableConcept AmericanIndianOrAlaskanNative = new(profileUrl, " AmericanIndianOrAlaskanNative", "American Indian Or Alaska Native", null);
            public static CodeableConcept AsianIndian = new(profileUrl, "AsianIndian", "Asian Indian", null);
            public static CodeableConcept Chinese = new(profileUrl, "Chinese", "Chinese", null);
            public static CodeableConcept Filipino = new(profileUrl, "Filipino", "Filipino", null);
            public static CodeableConcept Japanese = new(profileUrl, "Japanese", "Japanese", null);
            public static CodeableConcept Korean = new(profileUrl, "Korean", "Korean", null);
            public static CodeableConcept Vietnamese = new(profileUrl, "Vietnamese", "Vietnamese", null);
            public static CodeableConcept OtherAsian = new(profileUrl, "OtherAsian", "OtherAsian", null);
            public static CodeableConcept NativeHawaiian = new(profileUrl, "NativeHawaiian", "Native Hawaiian", null);
            public static CodeableConcept GuamanianOrChamorro = new(profileUrl, "GuamanianOrChamorro", "Guamanian Or Chamorro", null);
            public static CodeableConcept Samoan = new(profileUrl, "Samoan", "Samoan", null);
            public static CodeableConcept OtherPacificIslander = new(profileUrl, "OtherPacificIslander", "Other Pacific Islander", null);
            public static CodeableConcept OtherRace = new(profileUrl, "OtherRace", "Other Race", null);
            public static CodeableConcept FirstAmericanIndianOrAlaskanNativeLiteral = new(profileUrl, "FirstAmericanIndianOrAlaskanNativeLiteral", "First American Indian Or Alaska Native Literal", null);
            public static CodeableConcept SecondAmericanIndianOrAlaskanNativeLiteral = new(profileUrl, "SecondAmericanIndianOrAlaskanNativeLiteral", "Second American Indian Or Alaska Native Literal", null);
            public static CodeableConcept FirstOtherAsianLiteral = new(profileUrl, "FirstOtherAsianLiteral", "First Other Asian Literal", null);
            public static CodeableConcept SecondOtherAsianLiteral = new(profileUrl, "SecondOtherAsianLiteral", "Second Other Asian Literal", null);
            public static CodeableConcept FirstOtherPacificIslanderLiteral = new(profileUrl, "FirstOtherPacificIslanderLiteral", "First Other Pacific Islander Literal", null);
            public static CodeableConcept SecondOtherPacificIslanderLiteral = new(profileUrl, "SecondOtherPacificIslanderLiteral", "Second Other Pacific Islander Literal", null);
            public static CodeableConcept FirstOtherRaceLiteral = new(profileUrl, "FirstOtherRaceLiteral", "First Other Race Literal", null);
            public static CodeableConcept SecondOtherRaceLiteral = new(profileUrl, "SecondOtherRaceLiteral", "Second Other Race Literal", null);
        }
    }

    public class MdiVsYesNoNotApplicable
    {
        public static CodeableConcept Yes = new ("http://terminology.hl7.org/CodeSystem/v2-0136", "Y", "Yes", null);
        public static CodeableConcept No = new ("http://terminology.hl7.org/CodeSystem/v2-0136", "N", "No", null);
        public static CodeableConcept NA = new ("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NA", "not applicable", null);
    }

    public class MdiVsMannerOfDeath
    {
        public static CodeableConcept NaturalDeath = new ("http://snomed.info/sct", "38605008", "Natural death (event)", null);
        public static CodeableConcept AccidentalDeath = new ("http://snomed.info/sct", "7878000", "Accidental death (event)", null);
        public static CodeableConcept Suicide = new ("http://snomed.info/sct", "44301001", "Suicide (event)", null);
        public static CodeableConcept Homicide = new ("http://snomed.info/sct", "27935005", "Homicide (event)", null);
        public static CodeableConcept PatientAwaitingInvestigation = new ("http://snomed.info/sct", "185973002", "Patient awaiting investigation (finding)", null);
        public static CodeableConcept DeathmannerUndetermined = new ("http://snomed.info/sct", " 65037004", "Death, manner undetermined (event)", null);
    }

    public class MdiVsDeathPregnancyStatus
    {
        public static CodeableConcept NotPregnantPastYear = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "1", "Not pregnant within past year", null);
        public static CodeableConcept PregnantAtTimeOfDeath = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "2", "Pregnant at time of death", null);
        public static CodeableConcept NotpregnantButPregnant42DaysOfDeath = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "3", "Not pregnant, but pregnant within 42 days of death", null);
        public static CodeableConcept NotPregnantButPregnant43DaysTo1YearBeforeDeath = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "4", "Not pregnant, but pregnant 43 days to 1 year before death", null);
        public static CodeableConcept UnknownIfPregnantPastYear = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status", "9", "Unknown if pregnant within the past year", null);
        public static CodeableConcept NA = new ("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", " NA", "Not applicable", null);
    }

    public class MdiVsContributoryTobaccoUse
    {
        public static CodeableConcept Yes = new ("http://snomed.info/sct", "373066001", "Yes", null);
        public static CodeableConcept No = new ("http://snomed.info/sct", "373067005	", "No", null);
        public static CodeableConcept Probably = new ("http://snomed.info/sct", "2931005", "Probably", null);
        public static CodeableConcept Unknown = new ("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "Unknown", null);
        public static CodeableConcept NotAsked = new ("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NASK", "not asked", null);
    }

    public class MdiPlaceOfDeath
    {
        public const string profileUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-place-of-death";

        public static CodeableConcept DoaAtHospital = new("http://snomed.info/sct", "63238001", "Dead on arrival at hospital", null);
        public static CodeableConcept DeathInHome = new ("http://snomed.info/sct", "440081000124100", "Death in home", null);
        public static CodeableConcept DeathInHospice = new ("http://snomed.info/sct", "440071000124103", "Death in hospice", null);
        public static CodeableConcept DeathInHospital = new ("http://snomed.info/sct", "16983000", "Death in hospital", null);
        public static CodeableConcept DeathInHospitalEmergencyDeptOrOutpatient = new("http://snomed.info/sct", "450391000124102", "Death in hospital-based emergency department or outpatient department", null);
        public static CodeableConcept DeathInNursingHomeOrLongTermCareFacility = new("http://snomed.info/sct", "450381000124100", "Death in nursing home or long term care facility", null);
        public static CodeableConcept Other = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "OTH", "Other", null);
        public static CodeableConcept UNK = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "UNK", null);        
    }

    public class DateEstablishmentApproach
    {
        public const string profileUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-place-of-death";

        public static CodeableConcept Exact = new("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "exact", "Exact", null);
        public static CodeableConcept Approximate = new("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "approximate", "Approximate", null);
        public static CodeableConcept CourtAppointed = new ("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "court-appointed", "Court Appointed", null);
    }
}
