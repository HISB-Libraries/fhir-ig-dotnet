using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using GaTech.Chai.UsPublicHealth;

namespace GaTech.Chai.UsCbs.PatientProfile
{
    /// <summary>
    /// US Case Based Surveillance Patient Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-patient
    /// </summary>
    public class UsCbsPatient
    {
        readonly Patient patient;

        internal UsCbsPatient(Patient p)
        {
            this.patient = p;
            p.UsPublicHealthPatient().AddProfile();
        }

        /// <summary>
        /// Factory for US Case Based Surveillance Patient Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-patient
        /// </summary>
        public static Patient Create()
        {
            var patient = new Patient();
            patient.UsCbsPatient().AddProfile();
            return patient;
        }

        /// <summary>
        /// The official URL for the US Case Based Surveillance Patient Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-patient";

        /// <summary>
        /// Set profile for US Case Based Surveillance Patient Profile
        /// </summary>
        public void AddProfile()
        {
            patient.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Case Based Surveillance Patient Profile
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