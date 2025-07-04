using System;
using System.Buffers.Text;
using GaTech.Chai.Vrdr;
using Hl7.Fhir.Model;

/// <summary>
/// MDI ValueSets
/// </summary>
namespace GaTech.Chai.Mdi
{
    public class MdiCodeSystem
    {
        public class MdiCodes
        {
            public const string officialUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/cs-mdi-codes";

            public static CodeableConcept DeathCertificateDataReviewDoc = new(officialUrl, "death-certificate-data-review-doc", "Death Certificate Data Review Document", null);
            public static CodeableConcept AdditionalDemographics = new(officialUrl, "demographics", "Demographics Section", null);
            public static CodeableConcept Circumstances = new(officialUrl, "circumstances", "Circumstances of the Death Section", null);
            public static CodeableConcept Jurisdiction = new(officialUrl, "jurisdiction", "Jurisdiction Section", null);
            public static CodeableConcept CauseManner = new(officialUrl, "cause-manner", "Cause and Manner of Death Section", null);
            public static CodeableConcept MedicalHistory = new(officialUrl, "medical-history", "Medical History Section", null);
            public static CodeableConcept ExamAutopsy = new(officialUrl, "exam-autopsy", "Exam/Autopsy Section", null);
            public static CodeableConcept Narratives = new(officialUrl, "narratives", "Narratives Section", null);
            public static CodeableConcept CremationClearanceInfo = new(officialUrl, "cremation-clearance-info", "Cremation Clearance Information Section", null);
            public static CodeableConcept DeathCertificateDataReview = new(officialUrl, "death-certificate-data-review", "Death Certificate Data Review Results Section", null);
            public static CodeableConcept MdiCaseNumber = new(officialUrl, "mdi-case-number", "MDI Case Number", null);
            public static CodeableConcept EdrsFileNumber = new(officialUrl, "edrs-file-number", "EDRS File Number", null);
            public static CodeableConcept ToxLabCaseNumber = new(officialUrl, "tox-lab-case-number", "Toxicology Laboratory Case Number", null);
            public static CodeableConcept FuneralHomeCaseNumber = new(officialUrl, "funeral-home-case-number", "Funeral Home Case Number", null);
            public static Coding ToxResultReport = new(officialUrl, "tox-result-report", "Toxicology Lab Results");
            public static Coding DeathCertificateReviewEvent = new(officialUrl, "death-certificate-review-event");
            public static CodeableConcept EmbalmedObs = new(officialUrl, "embalmed-obs", "Embalmed Observation", null);
            public static CodeableConcept CommunicableDiseaseObs = new(officialUrl, "communicable-disease-obs", "Communicable Disease Observation", null);
            public static CodeableConcept MedInfoDataQualityObs = new(officialUrl, "med-info-data-quality-obs", "Medical Information Data Quality Observation", null);
            public static CodeableConcept PersonalInfoDataQualityObs = new(officialUrl, "personal-info-data-quality-obs", "Personal Information Data Quality Observation", null);
            public static CodeableConcept Crematorium = new(officialUrl, "crematorium", "Crematorium", null);
            // 
            // public static CodeableConcept MdiCaseNotesSummary = new(officialUrl, "mdi-case-notes-summary", "MDI Case Notes Summary", null);
            // public static CodeableConcept MdiCaseHistory = new(officialUrl, "mdi-case-history", "MDI Case History", null);
            // public static CodeableConcept Exact = new(officialUrl, "exact", "Exact", null);
            // public static CodeableConcept Approximate = new(officialUrl, "approximate", "Approximate", null);
            // public static CodeableConcept CourtAppointed = new(officialUrl, "court-appointed", "Court Appointed", null);
            // public static CodeableConcept Injury = new(officialUrl, "injury", "Injury Location", null);
            // public static CodeableConcept Death = new(officialUrl, "death", "Death Location", null);
        }

        // Moved to VRDR
        // public class DeathPregnancyStatus 
        // {
        //     public const string officialUrl = "http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-death-pregnancy-status";

        //     public static CodeableConcept NotPregnantPastYear = new(officialUrl, "1", "Not pregnant within past year", null);
        //     public static CodeableConcept PregnantAtTimeOfDeath = new(officialUrl, "2", "Pregnant at time of death", null);
        //     public static CodeableConcept NotpregnantButPregnant42DaysOfDeath = new(officialUrl, "3", "Not pregnant, but pregnant within 42 days of death", null);
        //     public static CodeableConcept NotPregnantButPregnant43DaysTo1YearBeforeDeath = new(officialUrl, "4", "Not pregnant, but pregnant 43 days to 1 year before death", null);
        //     public static CodeableConcept UnknownIfPregnantPastYear = new(officialUrl, "9", "Unknown if pregnant within the past year", null);
        //     public static CodeableConcept NA = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NA", "Not applicable", null);
        // }

        public class CsDeathCertReviewExample
        {
            public const string officialUrl = " http://hl7.org/fhir/us/mdi/CodeSystem/cs-death-cert-review-example";

            public static CodeableConcept DcMedDataQReq = new(officialUrl, "DC_MED_DATA_Q_REQ", "Death Certificate Medical Data Quality Review Request", null);
            public static CodeableConcept DcMedDataQRsp = new(officialUrl, "DC_MED_DATA_Q_RSP", "Death Certificate Medical Data Quality Review Response", null);
            public static CodeableConcept DcPerDataQReq = new(officialUrl, "DC_PER_DATA_Q_REQ", "Death Certificate Personal Data Quality Review Request", null);
            public static CodeableConcept DcPerDataQRsp = new(officialUrl, "DC_PER_DATA_Q_RSP", "Death Certificate Personal Data Quality Review Response", null);
            public static CodeableConcept CremCReq = new(officialUrl, "CREM_C_REQ", "Cremation Clearance Request", null);
            public static CodeableConcept CremCRsp = new(officialUrl, "CREM_C_RSP", "Cremation Clearance Response", null);
            public static CodeableConcept DeathCertCert = new(officialUrl, "DEATH_CERT_CERT", "Certified", null);
            public static CodeableConcept DeathCertNotCert = new(officialUrl, "DEATH_CERT_NOT_CERT", "Not Certified", null);
            public static CodeableConcept DeathCertReg = new(officialUrl, "DEATH_CERT_REG", "Registered", null);
            public static CodeableConcept DeathCertNotReg = new(officialUrl, "DEATH_CERT_NOT_REG", "Not Registered", null);
            public static CodeableConcept MedInfDqMedicalValid = new(officialUrl, "MED_INF_DQ_MEDICAL_VALID", "Medical Data Valid", null);
            public static CodeableConcept MedInfDqMedicalValidWithExceptions = new(officialUrl, "MED_INF_DQ_MEDICAL_VALID_WITH_EXCEPTIONS", "Medical Data Valid With Exceptions", null);
            public static CodeableConcept MedInfDqMedicalInvalid = new(officialUrl, "MED_INF_DQ_MEDICAL_INVALID", "Medical Data Invalid", null);
            public static CodeableConcept PerInfDqPersonalValid = new(officialUrl, "PER_INF_DQ_PERSONAL_VALID", "Personal Valid", null);
            public static CodeableConcept PerInfDqPersonalValidWithExceptions = new(officialUrl, "PER_INF_DQ_PERSONAL_VALID_WITH_EXCEPTIONS", "Personal Valid With Exceptions", null);
            public static CodeableConcept PerInfDqPersonalInvalid = new(officialUrl, "PER_INF_DQ_PERSONAL_INVALID", "Personal Invalid", null);
            public static CodeableConcept CremCRequested = new(officialUrl, "CREM_C_REQUESTED", "Requested", null);
            public static CodeableConcept CremCPending = new(officialUrl, "CREM_C_PENDING", "Pending", null);
            public static CodeableConcept CremCRejected = new(officialUrl, "CREM_C_REJECTED", "Rejected", null);
            public static CodeableConcept CremCApproved = new(officialUrl, "CREM_C_APPROVED", "Approved", null);
            public static CodeableConcept CremCSigned = new(officialUrl, "CREM_C_SIGNED", "Signed", null);
            public static CodeableConcept CremCUnsigned = new(officialUrl, "CREM_C_UNSIGNED", "Unsigned", null);
            public static CodeableConcept MeAffirmCertificationAffirmed = new(officialUrl, "ME_AFFIRM_CERTIFICATION_AFFIRMED", "ME Certification Affirmation Affirmed", null);
            public static CodeableConcept MeAffirmCertificationNotAffirmed = new(officialUrl, "ME_AFFIRM_CERTIFICATION_NOT_AFFIRMED", "ME Certification Affirmation Not Affirmed", null);
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

        public static CodeableConcept NaturalDeath = new("http://snomed.info/sct", "38605008", "Natural death (event)", null);
        public static CodeableConcept AccidentalDeath = new("http://snomed.info/sct", "7878000", "Accidental death (event)", null);
        public static CodeableConcept Suicide = new("http://snomed.info/sct", "44301001", "Suicide (event)", null);
        public static CodeableConcept Homicide = new("http://snomed.info/sct", "27935005", "Homicide (event)", null);
        public static CodeableConcept PatientAwaitingInvestigation = new("http://snomed.info/sct", "185973002", "Patient awaiting investigation (finding)", null);
        public static CodeableConcept DeathmannerUndetermined = new("http://snomed.info/sct", "65037004", "Death, manner undetermined (event)", null);
    }

    public class MdiVsContributoryTobaccoUse
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-contributory-tobacco-use";

        public static CodeableConcept Yes = new("http://snomed.info/sct", "373066001", "Yes", null);
        public static CodeableConcept No = new("http://snomed.info/sct", "373067005	", "No", null);
        public static CodeableConcept Probably = new("http://snomed.info/sct", "2931005", "Probably", null);
        public static CodeableConcept Unknown = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "Unknown", null);
        public static CodeableConcept NotAsked = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "NI", "no information", null);
    }

    public class MdiVsCertifierTypes
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-certifier-types";

        public static CodeableConcept MedicalExaminerCornerExamination = new("http://snomed.info/sct", "455381000124109", "Death certification by medical examiner or coroner (procedure)", null);
        public static CodeableConcept PronouncingAndCertifyingPhysican = new("http://snomed.info/sct", "434641000124105", "Death certification and verification by physician (procedure)", null);
        public static CodeableConcept CertifyingPhysician = new("http://snomed.info/sct", "434651000124107", "Death certification by physician (procedure)", null);
        public static CodeableConcept Other = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "OTH", "Other", null);
    }

    public class MdiVsPlaceOfDeath
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/ValueSet-place-of-death";

        public static CodeableConcept DeadOnArrivalAtHospital = new("http://snomed.info/sct", "63238001", "Dead on arrival at hospital", null);
        public static CodeableConcept DeathInHome = new("http://snomed.info/sct", "440081000124100", "Death in home", null);
        public static CodeableConcept DeathInHospice = new("http://snomed.info/sct", "440071000124103", "Death in hospice", null);
        public static CodeableConcept DeathInHospital = new("http://snomed.info/sct", "16983000", "Death in hospital", null);
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
        public static CodeableConcept CourtAppointed = new("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "court-appointed", "Court Appointed", null);
    }

    public class MdiCompositionSections
    {
        public static CodeableConcept AdditionalDemographics = MdiCodeSystem.MdiCodes.AdditionalDemographics;
        public static CodeableConcept Circumstances = MdiCodeSystem.MdiCodes.Circumstances;
        public static CodeableConcept Jurisdiction = MdiCodeSystem.MdiCodes.Jurisdiction;
        public static CodeableConcept CauseManner = MdiCodeSystem.MdiCodes.CauseManner;
        public static CodeableConcept MedicalHistory = MdiCodeSystem.MdiCodes.MedicalHistory;
        public static CodeableConcept ExamAutopsy = MdiCodeSystem.MdiCodes.ExamAutopsy;
        public static CodeableConcept Narratives = MdiCodeSystem.MdiCodes.Narratives;
    }

    public class MdiDcrCompositionSections
    {
        public static CodeableConcept DecedentDemographics = VrdrDocumentSectionCs.DecedentDemographics;
        public static CodeableConcept DeathInvestigation = VrdrDocumentSectionCs.DeathInvestigation;
        public static CodeableConcept DeathCertification = VrdrDocumentSectionCs.DeathCertification;
        public static CodeableConcept DecedentDisposition = VrdrDocumentSectionCs.DecedentDisposition;
        public static CodeableConcept DeathCertificateDataReview = MdiCodeSystem.MdiCodes.DeathCertificateDataReview;
        public static CodeableConcept CremationClearanceInfo = MdiCodeSystem.MdiCodes.CremationClearanceInfo;
    }

    public class VsTrackingNumberType
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-tracking-number-type";

        public static CodeableConcept MdiCaseNumber = MdiCodeSystem.MdiCodes.MdiCaseNumber;
        public static CodeableConcept EdrsFileNumber = MdiCodeSystem.MdiCodes.EdrsFileNumber;
        public static CodeableConcept ToxLabCaseNumber = MdiCodeSystem.MdiCodes.ToxLabCaseNumber;
        public static CodeableConcept FuneralHomeCaseNumber = MdiCodeSystem.MdiCodes.FuneralHomeCaseNumber;
    }

    public class VsDcrReason
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-dcr-reason";

        public static CodeableConcept DcMedDataQReq = MdiCodeSystem.CsDeathCertReviewExample.DcMedDataQReq;
        public static CodeableConcept DcMedDataQRsp = MdiCodeSystem.CsDeathCertReviewExample.DcMedDataQRsp;
        public static CodeableConcept DcPerDataQReq = MdiCodeSystem.CsDeathCertReviewExample.DcPerDataQReq;
        public static CodeableConcept DcPerDataQRsp = MdiCodeSystem.CsDeathCertReviewExample.DcPerDataQRsp;
        public static CodeableConcept CremCReq = MdiCodeSystem.CsDeathCertReviewExample.CremCReq;
        public static CodeableConcept CremCRsp = MdiCodeSystem.CsDeathCertReviewExample.CremCRsp;
    }

    public class VsCertifiedWorkflow
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-certified-workflow";

        public static CodeableConcept DeathCertCert = MdiCodeSystem.CsDeathCertReviewExample.DeathCertCert;
        public static CodeableConcept DeathCertNotCert = MdiCodeSystem.CsDeathCertReviewExample.DeathCertNotCert;
    }

    public class VsCremationClearanceStatus
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-cremation-clearance-status";

        public static CodeableConcept CremCRequested = MdiCodeSystem.CsDeathCertReviewExample.CremCRequested;
        public static CodeableConcept CremCPending = MdiCodeSystem.CsDeathCertReviewExample.CremCPending;
        public static CodeableConcept CremCRejected = MdiCodeSystem.CsDeathCertReviewExample.CremCRejected;
        public static CodeableConcept CremCApproved = MdiCodeSystem.CsDeathCertReviewExample.CremCApproved;
    }

    public class VsMeCertAffirmation
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-me-cert-affirmation";

        public static CodeableConcept MeAffirmCertificationAffirmed = MdiCodeSystem.CsDeathCertReviewExample.MeAffirmCertificationAffirmed;
        public static CodeableConcept MeAffirmCertificationNotAffirmed = MdiCodeSystem.CsDeathCertReviewExample.MeAffirmCertificationNotAffirmed;
    }

    public class VsSignatureStatus
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-signature-status";

        public static CodeableConcept CremCSigned = MdiCodeSystem.CsDeathCertReviewExample.CremCSigned;
        public static CodeableConcept CremCUnsigned = MdiCodeSystem.CsDeathCertReviewExample.CremCUnsigned;
    }

    public class VsMedDqReview
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-med-dq-review";

        public static CodeableConcept MedInfDqMedicalValid = MdiCodeSystem.CsDeathCertReviewExample.MedInfDqMedicalValid;
        public static CodeableConcept MedInfDqMedicalValidWithExceptions = MdiCodeSystem.CsDeathCertReviewExample.MedInfDqMedicalValidWithExceptions;
        public static CodeableConcept MedInfDqMedicalInvalid = MdiCodeSystem.CsDeathCertReviewExample.MedInfDqMedicalInvalid;
    }

    public class VsPerDqReview
    {
        public const string officialUrl = "http://hl7.org/fhir/us/mdi/ValueSet/vs-per-dq-review";

        public static CodeableConcept PerInfDqPersonalValid = MdiCodeSystem.CsDeathCertReviewExample.PerInfDqPersonalValid;
        public static CodeableConcept PerInfDqPersonalValidWithExceptions = MdiCodeSystem.CsDeathCertReviewExample.PerInfDqPersonalValidWithExceptions;
        public static CodeableConcept PerInfDqPersonalInvalid = MdiCodeSystem.CsDeathCertReviewExample.PerInfDqPersonalInvalid;
    }
}
