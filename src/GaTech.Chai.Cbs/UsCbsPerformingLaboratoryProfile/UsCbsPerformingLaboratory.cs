using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsCore.OrganizationProfile;
using GaTech.Chai.Share.Extensions;

namespace GaTech.Chai.UsCbs.PerformingLaboratoryProfile
{
    /// <summary>
    /// Case Based Surveillance Performing Laboratory Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-performing-lablab
    /// </summary>
    public class UsCbsPerformingLaboratory
    {
        readonly Organization organization;

        internal UsCbsPerformingLaboratory(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Performing Laboratory Profile
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
        /// The official URL for the Case Based Surveillance Performing Laboratory profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-performing-lab";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Performing Laboratory Profile.
        /// </summary>
        public void AddProfile()
        {
            organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Performing Laboratory Profile.
        /// </summary>
        public void RemoveProfile()
        {
            organization.RemoveProfile(ProfileUrl);
        }

        public void SetNameDataAbsentReason(DataAbsentReason reason)
        {
            organization.NameElement = new FhirString();
            organization.NameElement.AddDataAbsentReason(new Code(reason.GetEnumCode()));
        }
    }
}