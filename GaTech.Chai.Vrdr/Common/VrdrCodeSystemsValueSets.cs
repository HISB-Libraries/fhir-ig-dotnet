using System;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using static GaTech.Chai.Share.CodeSystems;

namespace GaTech.Chai.Vrdr
{
    public class CodeSystemDeathPregnancyStatus
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/CodeSystem-death-pregnancy-status";

        public static CodeableConcept NotPregnantPastYear = new(officialUrl, "1", "Not pregnant within past year", null);
        public static CodeableConcept PregnantAtTimeOfDeath = new(officialUrl, "2", "Pregnant at time of death", null);
        public static CodeableConcept NotpregnantButPregnant42DaysOfDeath = new(officialUrl, "3", "Not pregnant, but pregnant within 42 days of death", null);
        public static CodeableConcept NotPregnantButPregnant43DaysTo1YearBeforeDeath = new(officialUrl, "4", "Not pregnant, but pregnant 43 days to 1 year before death", null);
        public static CodeableConcept NotReportedOnCertificate = new(officialUrl, "7", "Not reported on certificate", null);
        public static CodeableConcept UnknownIfPregnantPastYear = new(officialUrl, "9", "Unknown if pregnant within the past year", null);
        public static CodeableConcept NA = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NA", "Not applicable", null);
    }

    public class VrdrComponentCs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/vrdr-component-cs";

        public static CodeableConcept Position = new(officialUrl, "position", "position", null);
        public static CodeableConcept LineNumber = new(officialUrl, "lineNumber", "line number", null);
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
        public static CodeableConcept EighthEditedCode = new(officialUrl, "EighthEditedCode", "Eighth Edited Race Code", null);
        public static CodeableConcept FirstAmericanIndianCode = new(officialUrl, "FirstAmericanIndianCode", "First Edited American Indian Race Code", null);
        public static CodeableConcept SecondAmericanIndianCode = new(officialUrl, "SecondAmericanIndianCode", "Second Edited American Indian Race Code", null);
        public static CodeableConcept FirstOtherAsianCode = new(officialUrl, "FirstOtherAsianCode", "First Edited Other Asian Race Code", null);
        public static CodeableConcept SecondOtherAsianCode = new(officialUrl, "SecondOtherAsianCode", "Second Edited Other Asian Race Race Code", null);
        public static CodeableConcept FirstOtherPacificIslanderCode = new(officialUrl, "FirstOtherPacificIslanderCode", "First Edited Other Pacific Islander Race Code", null);
        public static CodeableConcept SecondOtherPacificIslanderCode = new(officialUrl, "SecondOtherPacificIslanderCode", "First Edited Other Pacific Islander Race Code", null);
        public static CodeableConcept FirstOtherRaceCode = new(officialUrl, "FirstOtherRaceCode", "First Edited Other Race Code", null);
        public static CodeableConcept SecondOtherRaceCode = new(officialUrl, "SecondOtherRaceCode", "First Edited Other Race Code", null);
        public static CodeableConcept RaceRecode40 = new(officialUrl, "RaceRecode40", "Race Recode 40", null);
        public static CodeableConcept HispanicCode = new(officialUrl, "HispanicCode", "Hispanic Code", null);
        public static CodeableConcept HispanicCodeForLiteral = new(officialUrl, "HispanicCodeForLiteral", "Hispanic Code for Literal", null);
        public static CodeableConcept RACEMVR = new(officialUrl, "RACEMVR", "Race Missing Value Reason", null);
        public static CodeableConcept HispanicMexican = new(officialUrl, "HispanicMexican", "Hispanic Mexican", null);
        public static CodeableConcept HispanicPuertoRican = new(officialUrl, "HispanicPuertoRican", "Hispanic Puerto Rican", null);
        public static CodeableConcept HispanicCuban = new(officialUrl, "HispanicCuban", "Hispanic Cuban", null);
        public static CodeableConcept HispanicOther = new(officialUrl, "HispanicOther", "Hispanic Other", null);
        public static CodeableConcept HispanicLiteral = new(officialUrl, "HispanicLiteral", "Hispanic Literal", null);
        public static CodeableConcept White = new(officialUrl, "White", "White", null);
        public static CodeableConcept BlackOrAfricanAmerican = new(officialUrl, "BlackOrAfricanAmerican", "Black Or African American", null);
        public static CodeableConcept AmericanIndianOrAlaskanNative = new(officialUrl, "AmericanIndianOrAlaskanNative", "American Indian Or Alaska Native", null);
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

    public class VrdrDocumentSectionCs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/vrdr-document-section-cs";

        public static CodeableConcept DecedentDemographics = new(officialUrl, "DecedentDemographics", "Decedent Demographics", null);
        public static CodeableConcept DeathInvestigation = new(officialUrl, "DeathInvestigation", "Death Investigation", null);
        public static CodeableConcept DeathCertification = new(officialUrl, "DeathCertification", "Death Certification", null);
        public static CodeableConcept DecedentDisposition = new(officialUrl, "DecedentDisposition", "Decedent Disposition", null);
        public static CodeableConcept CodedContent = new(officialUrl, "CodedContent", "Coded Content", null);
    }

    public class VrdrDeathPregnancyStatusVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/ValueSet/vrdr-death-pregnancy-status-vs";

        public static CodeableConcept NotPregnantPastYear = CodeSystemDeathPregnancyStatus.NotPregnantPastYear;
        public static CodeableConcept PregnantAtTimeOfDeath = CodeSystemDeathPregnancyStatus.PregnantAtTimeOfDeath;
        public static CodeableConcept NotpregnantButPregnant42DaysOfDeath = CodeSystemDeathPregnancyStatus.NotpregnantButPregnant42DaysOfDeath;
        public static CodeableConcept NotPregnantButPregnant43DaysTo1YearBeforeDeath = CodeSystemDeathPregnancyStatus.NotPregnantButPregnant43DaysTo1YearBeforeDeath;
        public static CodeableConcept NotReportedOnCertificate = CodeSystemDeathPregnancyStatus.NotReportedOnCertificate;
        public static CodeableConcept UnknownIfPregnantPastYear = CodeSystemDeathPregnancyStatus.UnknownIfPregnantPastYear;
        public static CodeableConcept NA = CodeSystemDeathPregnancyStatus.NA;
    }


    public class VrdrTransportationIncidentRoleVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/ValueSet/vrdr-transportation-incident-role-vs";

        public static CodeableConcept VehicleDriver = new(UriString.SCT, "236320001", "Vehicle driver", null);
        public static CodeableConcept Passenger = new(UriString.SCT, "257500003", "Passenger", null);
        public static CodeableConcept Pedestrian = new(UriString.SCT, "257518000", "Pedestrian", null);
        public static CodeableConcept Other = V3NullFlavor.Other;
        public static CodeableConcept Unknown = V3NullFlavor.Unknown;
        public static CodeableConcept NotApplicable = V3NullFlavor.NotApplicable;
    }

    public class ValueSetAdministrativeGenderMaxVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/ValueSet/ValueSet-administrative-gender-max-vs";

        public static CodeableConcept F = V3AdministrativeGender.F;
        public static CodeableConcept M = V3AdministrativeGender.M;
        public static CodeableConcept UnknownV3 = V3NullFlavor.Unknown;
        public static CodeableConcept Female = new(AdministrativeGender.Female.GetEnumSystem(), AdministrativeGender.Female.GetEnumCode(), AdministrativeGender.Female.GetEnumDescription(), null);
        public static CodeableConcept Mail = new(AdministrativeGender.Male.GetEnumSystem(), AdministrativeGender.Male.GetEnumCode(), AdministrativeGender.Male.GetEnumDescription(), null);
        public static CodeableConcept UnknownAdministrative = new(AdministrativeGender.Unknown.GetEnumSystem(), AdministrativeGender.Unknown.GetEnumCode(), AdministrativeGender.Unknown.GetEnumDescription(), null);
    }

    public class VrdrMannerOfDeathVs
    {
        public static CodeableConcept NaturalDeath = new(UriString.SCT, "38605008", "Natural death", null);
        public static CodeableConcept AccidentalDeath = new(UriString.SCT, "7878000", "Accidental death", null);
        public static CodeableConcept Suicide = new(UriString.SCT, "44301001", "Suicide", null);
        public static CodeableConcept Homicide = new(UriString.SCT, "27935005", "Homicide", null);
        public static CodeableConcept PatientAwaitingInvestigation = new(UriString.SCT, "185973002", "Patient awaiting investigation", null);
        public static CodeableConcept DeathMannerUndetermined = new(UriString.SCT, "65037004", "Death, manner undetermined", null);
    }

    public class VrdrCs
    {
        public static CodeableConcept MannerOfDeathLoinc = new(UriString.LOINC, "69449-7");
        public static CodeableConcept DeathCertificationSCT = new(UriString.SCT, "308646001");
        public static CodeableConcept CauseOfDeath = new(UriString.LOINC, "69453-9");
        public static CodeableConcept AgeAtDeath = new(UriString.LOINC, "39016-1");
        public static CodeableConcept InjuryIncident = new(UriString.LOINC, "11374-6");
    }

    public class VrdrCertifierTypesVs
    {
        public static CodeableConcept DeathCertByCME = new(UriString.SCT, "455381000124109", "Death certification by medical examiner or coroner (procedure)", null);
        public static CodeableConcept DeathCertAndVerifByPhysician = new(UriString.SCT, "434641000124105", "Death certification and verification by physician (procedure)", null);
        public static CodeableConcept DeathCertByPhysician = new(UriString.SCT, "434651000124107", "Death certification by physician (procedure)", null);
        public static CodeableConcept Other = V3NullFlavor.Other;
    }

    public class VrdrDateOfDeathDeterminationMethodsCs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/vrdr-date-of-death-determination-methods-cs";

        public static CodeableConcept Exact = new(officialUrl, "exact", "Exact", null);
        public static CodeableConcept Approximate = new(officialUrl, "approximate", "Approximate", null);
        public static CodeableConcept Presumed = new(officialUrl, "presumed", "Presumed Date of Death", null);
        public static CodeableConcept CourtAppointed = new(officialUrl, "court-appointed", "Court Appointed", null);
    }

    public class VrdrDateOfDeathDeterminationMethodsVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vrdr/ValueSet/vrdr-date-of-death-determination-methods-vs";

        public static CodeableConcept Exact = VrdrDateOfDeathDeterminationMethodsCs.Exact;
        public static CodeableConcept Approximate = VrdrDateOfDeathDeterminationMethodsCs.Approximate;
        public static CodeableConcept Presumed = VrdrDateOfDeathDeterminationMethodsCs.Presumed;
        public static CodeableConcept CourtAppointed = VrdrDateOfDeathDeterminationMethodsCs.CourtAppointed;
    }

    public class VrdrLocationTypeCs
    {
        public static string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/vrdr-location-type-cs";

        public static CodeableConcept InjuryLocation = new(officialUrl, "injury", "Injury Location", null);
        public static CodeableConcept DispositionLocation = new(officialUrl, "disposition", "Disposition Location", null);
        public static CodeableConcept DeathLocation = new(officialUrl, "death", "Death Location", null);
    }

    public class VrdrInjuryIncidentComponentsCs
    {
        public static CodeableConcept PlaceOfInjury = new(UriString.LOINC, "69450-5");
        public static CodeableConcept WorkInjuryIndicator = new(UriString.LOINC, "69444-8");
        public static CodeableConcept TransportationRole = new(UriString.LOINC, "69451-3");
    }

    public class VrdrOrganizationTypeCs
    {
        public static string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/vrdr-organization-type-cs";

        public static CodeableConcept FuneralHome = new(officialUrl, "funeralhome", "Funeral Home", null);
    }

    public class VrdrMethodOfDispositionVs
    {
        public static string officialUrl = "http://hl7.org/fhir/us/vrdr/ValueSet/vrdr-method-of-disposition-vs";

        public static CodeableConcept Entombment = new(UriString.SCT, "449931000124108", "Entombment", null);

        public static CodeableConcept RemovalFromState = new(UriString.SCT, "449941000124103", "Removal from state", null);
        public static CodeableConcept Donation = new(UriString.SCT, "449951000124101", "Donation", null);
        public static CodeableConcept Cremation = new(UriString.SCT, "449961000124104", "Cremation", null);
        public static CodeableConcept Burial = new(UriString.SCT, "449971000124106", "Burial", null);
        public static CodeableConcept Other = V3NullFlavor.Other;
        public static CodeableConcept Unknown = V3NullFlavor.Unknown;
    }

    public class VrdrCodeSystemsValueSets
    {
        public const string OccupationCdcSoc2018Oid = "urn:oid:2.16.840.1.114222.4.5.338";
        public const string IndustryCdcNaics2017Oid = "urn:oid:2.16.840.1.114222.4.5.337";
    }

    public class VrdrFilingFormatCs
    {
        public static string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/vrdr-filing-format-cs";

        public static CodeableConcept Electronic = new(officialUrl, "electronic", "Electronic", null);
        public static CodeableConcept Paper = new(officialUrl, "paper", "Paper", null);
        public static CodeableConcept Mixed = new(officialUrl, "mixed", "Mixed", null);
    }

    public class VrdrReplaceStatusCs
    {
        public static string officialUrl = "http://hl7.org/fhir/us/vrdr/CodeSystem/vrdr-replace-status-cs";

        public static CodeableConcept Original = new(officialUrl, "original", "original record", null);
        public static CodeableConcept Updated = new(officialUrl, "updated", "updated record", null);
        public static CodeableConcept UpdatedNotforNCHS = new(officialUrl, "updated_notforNCHS", "updated record not for nchs", null);
    }

    public class VrdrDeathCertificationEventVs
    {
        public static string officialUrl = "http://hl7.org/fhir/us/vrdr/ValueSet/vrdr-death-certification-event-vs";

        public static CodeableConcept DeathCertificate = new(UriString.SCT, "307930005", "Death certificate");
    }

    public class VrdrDeathCertificationEventMaxVs
    {
        public static string officialUrl = "http://hl7.org/fhir/us/vrdr/ValueSet/vrdr-death-certification-event-max-vs";

        public static CodeableConcept DeathCertificate = new(UriString.SCT, "307930005", "Death certificate");
        public static CodeableConcept DiagnosticProcedure = new(UriString.SCT, "103693007", "Death procedure");
    }
}
