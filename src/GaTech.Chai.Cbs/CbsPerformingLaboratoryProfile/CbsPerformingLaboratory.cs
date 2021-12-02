using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsPerformingLaboratoryProfile
{
    /// <summary>
    /// Case Based Surveillance Performing Laboratory Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-performing-lab
    /// </summary>
    public class CbsPerformingLaboratory
    {
        readonly Organization organization;

        internal CbsPerformingLaboratory(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Performing Laboratory Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-performing-lab
        /// </summary>
        public static Organization Create()
        {
            var organization = new Organization();
            organization.CbsPerformingLaboratory().AddProfile();
            organization.Type.Add(new CodeableConcept("http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "LAB"));

            return organization;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Performing Laboratory profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-performing-lab";

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
    }
}