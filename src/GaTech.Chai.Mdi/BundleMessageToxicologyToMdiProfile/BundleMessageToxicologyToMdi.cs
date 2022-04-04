using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.BundleMessageToxicologyToMdiProfile
{
    /// <summary>
    /// BundleMessageToxicologyToMdiProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi
    /// </summary>
    public class BundleMessageToxicologyToMdi
    {
        readonly Bundle bundle;

        internal BundleMessageToxicologyToMdi(Bundle bundle)
        {
            this.bundle = bundle;
            bundle.Type = Bundle.BundleType.Message;
        }

        /// <summary>
        /// Factory for BundleMessageToxicologyToMdi Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi
        /// </summary>
        public static Bundle Create()
        {
            var bundle = new Bundle();
            bundle.BundleMessageToxicologyToMdi().AddProfile();
            return bundle;
        }

        /// <summary>
        /// The official URL for the BundleMessageToxicologyToMdi profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi";

        /// <summary>
        /// Set profile BundleMessageToxicologyToMdiProfile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for BundleMessageToxicologyToMdiProfile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

    }
}