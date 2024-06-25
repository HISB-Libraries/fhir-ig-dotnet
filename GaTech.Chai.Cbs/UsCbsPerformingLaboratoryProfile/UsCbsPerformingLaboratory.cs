using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using GaTech.Chai.UsPublicHealth;
using GaTech.Chai.UsCore;

namespace GaTech.Chai.UsCbs.PerformingLaboratoryProfile
{
    /// <summary>
    /// US Case Based Surveillance Performing Laboratory Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-performing-lab
    /// </summary>
    public class UsCbsPerformingLaboratory
    {
        readonly Organization organization;

        internal UsCbsPerformingLaboratory(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for US Case Based Surveillance Performing Laboratory Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-performing-lab
        /// </summary>
        public static Organization Create()
        {
            var organization = new Organization();
            organization.UsCbsPerformingLaboratory().AddProfile();
            organization.Type.Add(new CodeableConcept("http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "LAB"));
            organization.UsPublicHealthOrganization().AddProfile();
            organization.UsCoreOrganization().AddProfile();

            return organization;
        }

        /// <summary>
        /// The official URL for the US Case Based Surveillance Performing Laboratory Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-performing-lab";

        /// <summary>
        /// Set profile for US Case Based Surveillance Performing Laboratory Profile
        /// </summary>
        public void AddProfile()
        {
            organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Case Based Surveillance Performing Laboratory Profile
        /// </summary>
        public void RemoveProfile()
        {
            organization.RemoveProfile(ProfileUrl);
        }

        public void SetNameDataAbsentReason(Code reason)
        {
            organization.NameElement = new FhirString();
            organization.NameElement.AddDataAbsentReason(reason);
        }
    }
}