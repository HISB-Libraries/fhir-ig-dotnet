using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.ImmunizationProfile
{
    /// <summary>
    /// US Core Immunization Profile Extensions
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-immunization
    /// </summary>
    public class UsCoreImmunization
    {
        readonly Immunization immunization;

        internal UsCoreImmunization(Immunization immunization)
        {
            this.immunization = immunization;
        }

        /// <summary>
        /// Factory for US Core Immunization Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-immunization
        /// </summary>
        public static Immunization Create()
        {
            var immunization = new Immunization();
            immunization.UsCoreImmunization().AddProfile();
            return immunization;
        }

        /// <summary>
        /// The official URL for the US Core Immunization profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-immunization";

        /// <summary>
        /// Set the assertion that an Immunization object conforms to the Case Based Surveillance Immunization profile.
        /// </summary>
        public void AddProfile()
        {
            this.immunization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an Immunization object conforms to the Case Based Surveillance Immunization profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.immunization.RemoveProfile(ProfileUrl);
        }
    }
}
