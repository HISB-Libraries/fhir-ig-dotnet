using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Linq;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Case Notification Panel Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-notification-panel
    /// </summary>
    public class CbsCaseNotificationPanel
    {
        protected readonly Observation observation;

        internal CbsCaseNotificationPanel(Observation observation)
        {
            this.observation = observation;
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-notification-panel";
            observation.Status = ObservationStatus.Final;
            observation.Category.SetCategory(new Coding("http://loinc.org", "78000-7", "Case notification panel [CDC.PHIN]"));
        }

        /// <summary>
        /// Factory for Case Based Surveillance Case Notification Panel Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-notification-panel
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Case Notification Panel profile, used to assert conformance.
        /// </summary>
        public virtual string ProfileUrl
        {
            get; protected set;
        }

        /// <summary>
        /// Set Profile for Case Based Surveillance Case Notification Panel Profile
        /// </summary>
        public void AddProfile()
        {
            observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Case Based Surveillance Case Notification Panel Profile
        /// </summary>
        public void RemoveProfile()
        {
            observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// CBS Case Notification Panel Value Set
        /// http://cbsig.chai.gatech.edu/ValueSet/CBSCaseNotificationPanelVS
        /// Codes found in the case notification panel that are otherwise not captured in other CBS profiles
        /// </summary>
        public class CaseNotificationPanelValues
        {
            public const string LoincUrl = "http://loinc.org";
            public const string TempCodeUrl = "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system";

            public static CodeableConcept AdmissionDate => Loinc("8656-1", "Admission Date");
            public static CodeableConcept AgeatCaseInvestigation => Loinc("77998-3", "Age at time of case investigation");
            public static CodeableConcept BinationalReportingCriteria => Loinc("77988-4", "Binational Reporting Criteria");
            public static CodeableConcept CaseClassStatusCode => Loinc("77990-0", "Case Class Status Code");
            public static CodeableConcept CaseDiseaseImportedCode => Loinc("77982-7", "Case Disease Imported Code");
            public static CodeableConcept CaseInvestigationStartDate => Loinc("77979-3", "Case Investigation Start Date");
            public static CodeableConcept CaseOutbreakIndicator => Loinc("77980-1", "Case Outbreak Indicator");
            public static CodeableConcept CaseOutbreakName => Loinc("77981-9", "Case Outbreak Name");
            public static CodeableConcept CityOfExposure => Loinc("77986-8", "City of Exposure");
            public static CodeableConcept Comment => Loinc("77999-1", "Comment");
            public static CodeableConcept CountryOfBirth => Loinc("78746-5", "Country of Birth");
            public static CodeableConcept CountryOfExposure => Loinc("77984-3", "Country of Exposure");
            public static CodeableConcept CountryOfUsualResidence => Loinc("77983-5", "Country of Usual Residence");
            public static CodeableConcept CountyOfExposure => Loinc("77987-6", "County of Exposure");
            public static CodeableConcept CaseAssociatedWithKnownOutbreak => Loinc("77980-1", "Case is associated with a known outbreak");
            public static CodeableConcept DateCDCWasFirstVerballyNotifiedofThisCase => Loinc("77994-2", "Date CDC Was First Verbally Notified of This Case");
            public static CodeableConcept DateFirstReportedtoPHD => Loinc("77970-2", "Date First Reported to PHD");
            public static CodeableConcept DateOfIllnessOnset => Loinc("77995-9", "Date of Illness Onset");
            public static CodeableConcept DateReported => Loinc("77995-9", "Date of first report to public health department");
            public static CodeableConcept DiseaseTransmissionMode => Loinc("77989-2", "Disease transmission mode");
            public static CodeableConcept DurationofHospitalStayinDays => Loinc("78033-8", "Duration of Hospital Stay in Days");
            public static CodeableConcept EarliestDateReportedtoCounty => Loinc("77972-8", "Earliest Date Reported to County");
            public static CodeableConcept EarliestDateReportedtoState => Loinc("77973-6", "Earliest Date Reported to State");
            public static CodeableConcept Hospitalized => Loinc("77974-4", "Hospitalized");
            public static CodeableConcept ImmediateNationalNotifiableCondition => Loinc("77965-2", "Immediate National Notifiable Condition");
            public static CodeableConcept JurisdictionCode => Loinc("77969-4", "Jurisdiction Code");
            public static CodeableConcept NationalReportingJurisdiction => Loinc("77968-6", "National Reporting Jurisdiction");
            public static CodeableConcept PregnancyStatus => Loinc("77996-7", "Pregnancy status at time of illness or condition");
            public static CodeableConcept ReportingCounty => Loinc("77967-8", "Reporting County");
            public static CodeableConcept ReportingSourceTypeCode => Loinc("48766-0", "Reporting Source Type Code");
            public static CodeableConcept ReportingSourceZIPCode => Loinc("52831-5", "Reporting Source ZIP Code");
            public static CodeableConcept ReportingState => Loinc("77966-0", "Reporting State");
            public static CodeableConcept StateCaseIdentifier => Loinc("77993-4", "State Case Identifier");
            public static CodeableConcept StateOrProvinceOfExposure => Loinc("77985-0", "State or Province of Exposure");
            public static CodeableConcept SubjectDied => Loinc("77978-5", "Subject Died");

            public static CodeableConcept MMWR => TempCode("MMWR", "MMWR Week/Year");
            public static CodeableConcept LocationOfExposure => TempCode("Location-of-Exposure", "Location of Exposure");

            public static CodeableConcept Loinc(string value, string display) => new CodeableConcept(LoincUrl, value, display, null);
            public static CodeableConcept TempCode(string value, string display) => new CodeableConcept(TempCodeUrl, value, display, null);
        }
    }
}