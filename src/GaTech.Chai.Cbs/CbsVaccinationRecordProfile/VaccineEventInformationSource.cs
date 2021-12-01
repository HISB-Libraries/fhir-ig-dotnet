using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsVaccinationRecordProfile
{
    /// <summary>
    /// Vaccine Event Information Source (2.16.840.1.114222.4.11.7450)
    /// Identifies the source of information for this immunization record or, more generically,
    /// whether the immunization being reported has just been administered (new) or came from other records (historical)
    /// </summary>
    public static class VaccineEventInformationSource
    {
        public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.7450";

        /// <summary>
        /// Computer record of patient (record artifact)
        /// </summary>
        public static CodeableConcept ComputerRecordOfPatient => Encode("184225006", "Computer record of patient (record artifact)");

        /// <summary>
        /// Historical information - from birth certificate
        /// </summary>
        public static CodeableConcept FromBirthCertificate => Encode("6", "Historical information - from birth certificate");

        /// <summary>
        /// Historical information - from other provider
        /// </summary>
        public static CodeableConcept FromOtherProvider => Encode("2", "Historical information - from other provider");

        /// <summary>
        /// Historical information - from other registry
        /// </summary>
        public static CodeableConcept FromOtherRegistry => Encode("5", "Historical information - from other registry");

        /// <summary>
        /// Historical information - from patient or parent's recall
        /// </summary>
        public static CodeableConcept FromPatientRecall => Encode("PHC1435", "Historical information - from patient or parent's recall");

        /// <summary>
        /// Historical information - from patient or parent's written record
        /// </summary>
        public static CodeableConcept FromPatientRecord => Encode("PHC1436", "Historical information - from patient or parent's written record");

        /// <summary>
        /// Historical information - from public agency
        /// </summary>
        public static CodeableConcept FromPublicAgency => Encode("08", "Historical information - from public agency");

        /// <summary>
        /// Historical information - from school record
        /// </summary>
        public static CodeableConcept FromSchoolRecord => Encode("07", "Historical information - from school record");

        /// <summary>
        /// Historical information - source unspecified
        /// </summary>
        public static CodeableConcept FromUnspecifiedSource => Encode("01", "Historical information - source unspecified");

        /// <summary>
        /// Immunization Information System
        /// </summary>
        public static CodeableConcept ImmunizationInformationSystem => Encode("01", "Immunization Information System");

        /// <summary>
        /// New immunization record
        /// </summary>
        public static CodeableConcept NewImmunizationRecord => Encode("00", "New immunization record");

        /// <summary>
        /// Other
        /// </summary>
        public static CodeableConcept Other => Encode("OTH", "Other");

        /// <summary>
        /// Primary Care Provider
        /// </summary>
        public static CodeableConcept PrimaryCareProvider => Encode("PP", "Primary Care Provider");

        /// <summary>
        /// Other
        /// </summary>
        public static CodeableConcept Unknown => Encode("UNK", "Unknown");

        /// <summary>
        /// Encode entry for Vaccine Event Information Source (2.16.840.1.114222.4.11.7450)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}