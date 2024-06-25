using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Cbs.SpecimenProfile
{
    /// <summary>
    /// Case Based Surveillance Specimen Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-specimen
    /// </summary>
    public class CbsSpecimen
    {
        readonly Specimen specimen;

        internal CbsSpecimen(Specimen specimen)
        {
            this.specimen = specimen;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Specimen Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-specimen
        /// </summary>
        public static Specimen Create()
        {
            var specimen = new Specimen();
            specimen.CbsSpecimen().AddProfile();
            return specimen;
        }

        /// <summary>
        /// Set profile for Case Based Surveillance Specimen Profile
        /// </summary>
        public void AddProfile()
        {
            specimen.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile Case Based Surveillance Specimen Profile
        /// </summary>
        public void RemoveProfile()
        {
            specimen.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Specimen Role
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-specimen-role
        /// </summary>
        public CodeableConcept SpecimenRole
        {
            get => specimen.GetExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-specimen-role")?.Value as CodeableConcept;
            set => specimen.Extension.AddOrUpdateExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-specimen-role", value);
        }

        /// <summary>
        /// PlacerAssignedId extension
        /// </summary>
        public Identifier PlacerAssignedId
        {
            get => specimen.Identifier.GetIdentifier(
                    "http://terminology.hl7.org/CodeSystem/v2-0203", "PLAC");
            set => specimen.Identifier.AddOrUpdateIdentifier(
                    "http://terminology.hl7.org/CodeSystem/v2-0203", "PLAC", value);
        }

        /// <summary>
        /// FillerAssignedId extension
        /// </summary>
        public Identifier FillerAssignedId
        {
            get => specimen.Identifier.GetIdentifier(
                    "http://terminology.hl7.org/CodeSystem/v2-0203", "FILL");
            set => specimen.Identifier.AddOrUpdateIdentifier(
                     "http://terminology.hl7.org/CodeSystem/v2-0203", "FILL", value);
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Specimen profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-specimen";

        /// <summary>
        /// Specimen Role (2.16.840.1.114222.4.11.1046)
        /// The role of the sample. If this field is not populated, then the specimen described has no special,
        /// or specific, role other than serving as the focus of the observation
        /// </summary>
        public static class Roles
        {
            public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.1046";

            public static CodeableConcept BlindSample => Encode("B", "Blind Sample");
            public static CodeableConcept Calibrator => Encode("C", "Calibrator");
            public static CodeableConcept ControlSpecimen => Encode("Q", "Control specimen");
            public static CodeableConcept ElectronicQC => Encode("E", "Electronic QC, used with manufactured reference providing signals that simulate QC results");
            public static CodeableConcept Group => Encode("G", "Group (where a specimen consists of multiple individual elements that are not individually identified)");
            public static CodeableConcept Patient => Encode("P", "Patient (default if blank component value)");
            public static CodeableConcept Pool => Encode("L", "Pool (aliquots of individual specimens combined to form a single specimen representing all of the components.)");
            public static CodeableConcept Replicate => Encode("R", "Replicate (of patient sample as a control)");
            public static CodeableConcept SpecimenUsedForTestingOperatorProficiency => Encode("O", "Specimen used for testing Operator Proficiency");
            public static CodeableConcept SpecimenUsedForTestingOrganizationProficiency => Encode("F", "Specimen used for testing proficiency of the organization performing the testing (Filler)");
            public static CodeableConcept VerifyingCalibrator => Encode("V", "Verifying Calibrator, used for periodic calibration checks");
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
        }

        /// <summary>
        /// Specimen Type (2.16.840.1.114222.4.11.946)
        /// Specimen based on SNOMED hierarchy (123038009) 
        /// </summary>
        public static class Types
        {
            public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.946";
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
        }

        /// <summary>
        /// Body site (2.16.840.1.114222.4.11.967)
        /// Body site from which specimen taken or where disease or injury occurs. This is based on the SNOMED hierarchy (Anatomical Structure - 91723000) 
        /// </summary>
        public static class BodySites
        {
            public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.967";
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
        }
    }
}