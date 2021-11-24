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

        internal CbsPatient(Patient p)
        {
            this.patient = p;
            this.patientRace = new CbsPatientRace(p);
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
        public CbsPatientRace Race
        {
            get
            {
                return patientRace;
            }
        }

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
        /// Patient Birth Place
        /// http://hl7.org/fhir/StructureDefinition/patient-birthPlace
        /// </summary>
        public CodeableConcept BirthSex
        {
            get => patient.GetExtension(
                    "http://hl7.org/fhir/StructureDefinition/patient-birth-sex")?.Value as CodeableConcept;
            set => patient.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/patient-birth-sex", value);
        }

        /// <summary>
        /// Get Reference to Resource
        /// </summary>
        /// <returns></returns>
        public ResourceReference AsReference()
        {
            if (string.IsNullOrEmpty(patient.Id))
                patient.Id = Guid.NewGuid().ToString();
            return new ResourceReference("Patient/" + patient.Id);
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Patient profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient";

        /// <summary>
        /// Set the assertion that a patient object conforms to the Case Based Surveillance Patient Profile.
        /// </summary>
        /// <param name="patient"></param>
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
    }
}