using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// US Core Immunization Profile
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
        /// Set profile for US Core Immunization Profile
        /// </summary>
        public void AddProfile()
        {
            this.immunization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Core Immunization Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.immunization.RemoveProfile(ProfileUrl);
        }
    }
}
