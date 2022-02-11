using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    /// <summary>
    /// Case Based Surveillance Patient Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient
    /// </summary>
    public class CbsPatient
    {
        readonly Patient patient;
        readonly CbsPatientRace patientRace;
        readonly CbsPatientEthnicity patientEthnicity;

        internal CbsPatient(Patient p)
        {
            this.patient = p;
            this.patientRace = new CbsPatientRace(p);
            this.patientEthnicity = new CbsPatientEthnicity(p);
        }

        /// <summary>
        /// Factory for Case Based Surveillance Patient Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient
        /// </summary>
        public static Patient Create()
        {
            var patient = new Patient();
            patient.CbsPatient().AddProfile();
            return patient;
        }

        /// <summary>
        /// Patient Race
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-race
        /// </summary>
        public CbsPatientRace Race => patientRace;

        /// <summary>
        /// Patient Race
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-ethnicity
        /// </summary>
        public CbsPatientEthnicity Ethnicity => patientEthnicity;

        /// <summary>
        /// Patient Birth Sex
        /// http://hl7.org/fhir/StructureDefinition/patient-birth-sex
        /// </summary>
        public Address BirthPlace
        {
            get => patient.GetExtension(
                    "http://hl7.org/fhir/StructureDefinition/patient-birthPlace")?.Value as Address;
            set => patient.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/patient-birthPlace", value);
        }

        /// <summary>
        /// Patient Gender Identity
        /// http://hl7.org/fhir/StructureDefinition/patient-genderIdentity
        /// </summary>
        public CodeableConcept GenderIdentity
        {
            get => patient.GetExtension(
                    "http://hl7.org/fhir/StructureDefinition/patient-genderIdentity")?.Value as CodeableConcept;
            set => patient.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/patient-genderIdentity", value);
        }

        /// <summary>
        /// Patient Birth Sex
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-birthsex
        /// </summary>
        public CodeableConcept BirthSex
        {
            get => patient.GetExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-birthsex")?.Value as CodeableConcept;
            set => patient.Extension.AddOrUpdateExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-birthsex", value);
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Patient profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient";

        /// <summary>
        /// Set the assertion that a patient object conforms to the Case Based Surveillance Patient Profile.
        /// </summary>
        public void AddProfile()
        {
            patient.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a patient object conforms to the Case Based Surveillance Patient Profile.
        /// </summary>
        public void RemoveProfile()
        {
            patient.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Sex (MFU) (2.16.840.1.114222.4.11.1038)
        /// Constrained list of sex codes in use by public health
        /// </summary>
        public static class Sex
        {
            public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.1038";

            public static CodeableConcept Female => Encode("F", "Female");
            public static CodeableConcept Male => Encode("M", "Male");
            public static CodeableConcept Unknown => Encode("U", "Unknown");
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
        }
    }
}