using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// US Core Practitioner Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner
    /// </summary>
    public class UsCorePractitioner
    {
        readonly Practitioner practitioner;

        internal UsCorePractitioner(Practitioner practitioner)
        {
            this.practitioner = practitioner;
        }

        /// <summary>
        /// Factory for US Core Practitioner Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner
        /// </summary>
        public static Practitioner Create()
        {
            var practitioner = new Practitioner();
            return practitioner;
        }

        /// <summary>
        /// The official URL for the US Core Practitioner profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner";

        /// <summary>
        /// Set profile for US Core Practitioner Profile
        /// </summary>
        public void AddProfile()
        {
            this.practitioner.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Core Practitioner Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.practitioner.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// NPI property to set and get the NPI from Practitioner Identifier
        /// </summary>
        public string NPI
        {
            get => this.practitioner.Identifier?.Find(c => c.System == "http://hl7.org/fhir/sid/us-npi")?.Value.ToString();
            set
            {
                this.practitioner.Identifier.AddOrUpdateIdentifier("http://hl7.org/fhir/sid/us-npi", value);
            }
        }
    }
}
