using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.PatientProfile
{
    /// <summary>
    /// Us Core Patient Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-patient
    /// </summary>
    public class UsCorePatient
    {
        readonly Patient patient;
        readonly UsCorePatientRace patientRace;
        readonly UsCorePatientEthnicity patientEthnicity;
        readonly UsCorePatientBirthSex patientBirthSex;

        internal UsCorePatient(Patient p)
        {
            this.patient = p;
            this.patientRace = new UsCorePatientRace(p);
            this.patientEthnicity = new UsCorePatientEthnicity(p);
            this.patientBirthSex = new UsCorePatientBirthSex(p);
        }

        /// <summary>
        /// Factory for Us Core Patient Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-patient
        /// </summary>
        public static Patient Create()
        {
            var patient = new Patient();
            patient.UsCorePatient().AddProfile();
            return patient;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Patient profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-patient";

        /// <summary>
        /// Set profile for Us Core Patient Profile
        /// </summary>
        public void AddProfile()
        {
            patient.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Us Core Patient Profile
        /// </summary>
        public void RemoveProfile()
        {
            patient.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Patient Race
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-race
        /// </summary>
        public UsCorePatientRace Race => patientRace;

        /// <summary>
        /// Patient Race
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-ethnicity
        /// </summary>
        public UsCorePatientEthnicity Ethnicity => patientEthnicity;

        /// <summary>
        /// Patient Birth Sex
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-birthsex
        /// </summary>
        ///
        public UsCorePatientBirthSex BirthSex => patientBirthSex;

        /// <summary>
        /// Sex (MFU) (2.16.840.1.114222.4.11.1038)
        /// Constrained list of sex codes in use by public health
        /// </summary>
        public static class PHVSSex
        {
            public const string adminSexCodeSystem = "urn:oid:2.16.840.1.113883.12.1";

            public static CodeableConcept Female => Encode("F", "Female");
            public static CodeableConcept Male => Encode("M", "Male");
            public static CodeableConcept Unknown => Encode("U", "Unknown");
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(adminSexCodeSystem, value, display, null);
        }
    }
}