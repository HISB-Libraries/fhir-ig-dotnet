using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCbs.ImmunizationProfile
{
    /// <summary>
    /// Case Based Surveillance Lab Condition Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-immunization
    /// </summary>
    public class UsCbsImmunization
    {
        readonly Immunization immunization;

        internal UsCbsImmunization(Immunization immunization)
        {
            this.immunization = immunization;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Immunization Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-immunization
        /// </summary>
        public static Immunization Create()
        {
            var immunization = new Immunization();
            immunization.UsCbsImmunization().AddProfile();
            return immunization;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Immunization profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-immunization";

        /// <summary>
        /// Set the assertion that an condition object conforms to the Case Based Surveillance Lab Condition profile.
        /// </summary>
        public void AddProfile()
        {
            this.immunization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the Case Based Surveillance Lab Condition profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.immunization.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Valueset for vaccine codes.
        /// See for more info: https://phinvads.cdc.gov/vads/ViewValueSet.action?oid=2.16.840.1.114222.4.11.7331
        /// </summary>
        public static class VaccineAdministerd_MMR
        {
            public static CodeableConcept MR => new CodeableConcept("urn:oid:2.16.840.1.113883.12.292", "04", "measles and rubella virus vaccine", null);
            public static CodeableConcept Measles => new CodeableConcept("urn:oid:2.16.840.1.113883.12.292", "05", "measles virus vaccine", null);
            public static CodeableConcept MMR => new CodeableConcept("urn:oid:2.16.840.1.113883.12.292", "03", "measles, mumps and rubella virus vaccine", null);
            public static CodeableConcept MMRV => new CodeableConcept("urn:oid:2.16.840.1.113883.12.292", "94", "measles, mumps, rubella, and varicella virus vaccine", null);
            public static CodeableConcept mumps => new CodeableConcept ("urn:oid:2.16.840.1.113883.12.292", "07", "mumps virus vaccine", null);
            public static CodeableConcept noVaccineAdministered => new CodeableConcept("urn:oid:2.16.840.1.113883.5.1008", "OTH", "no vaccine administered", null);
            public static CodeableConcept Other => new CodeableConcept("urn:oid:2.16.840.1.113883.5.1008", "OTH", "other", null);
            public static CodeableConcept Rubella => new CodeableConcept("urn:oid:2.16.840.1.113883.12.292", "06", "rubella virus vaccine", null);
            public static CodeableConcept RubellaMumps => new CodeableConcept("urn:oid:2.16.840.1.113883.12.292", "38", "rubella and mumps virus vaccine", null);
            public static CodeableConcept Unknown => new CodeableConcept("urn:oid:2.16.840.1.113883.12.292", "999", "unknown vaccine or immune globulin", null);
        }

        public static class VaccineEventInformationSource_NND
        {
            public static CodeableConcept MedicalRecord => new CodeableConcept("http://snomed.info/sct", "184225006", "Medical record", null);
            public static CodeableConcept HistInfoFromBirthCert => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.293", "06", "Historical information - from birth certificate", null);
            public static CodeableConcept HistInfoFromOtherProvider => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.293", "02", "Historical information - from other provider", null);
            public static CodeableConcept HistInfoFromOtherRegistry => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.293", "05", "Historical information - from other registry", null);
            public static CodeableConcept HistInfoFromPatOrParsRecall => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC1435", "Historical information - from patient or parent's recall", null);
            public static CodeableConcept HistInfoFromPatOrParsWrittenRec => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC1436", "Historical information - from patient or parent's written record", null);
            public static CodeableConcept HistInfoFromPublicAgency => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.293", "08", "Historical information - from public agency", null);
            public static CodeableConcept HistInfoFromSchoolRecord => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.293", "07", "Historical information - from school record", null);
            public static CodeableConcept HistInfoFromSourceUnspecified => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.293", "01", "Historical information - source unspecified", null);
            public static CodeableConcept ImmunizationInfoSystem => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC1936", "Immunization Information System", null);
            public static CodeableConcept NewImmunizationRecord => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.293", "00", "New immunization record", null);
            public static CodeableConcept Other => new CodeableConcept("urn:oid:2.16.840.1.113883.5.1008", "OTH", "other", null);
            public static CodeableConcept PrimaryCareProvider => new CodeableConcept("urn:oid:2.16.840.1.113883.12.443", "PP", "Primary Care Provider", null);
            public static CodeableConcept Unknown => new CodeableConcept("urn:oid:2.16.840.1.113883.5.1008", "UNK", "unknown", null);
        }
    }
}
