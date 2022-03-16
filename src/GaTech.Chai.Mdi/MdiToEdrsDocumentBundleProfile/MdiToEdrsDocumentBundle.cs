using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.MdiToEdrsDocumentBundleProfile
{
    /// <summary>
    /// Medicolegal Death Investigation Document Bundle Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs
    /// </summary>
    public class MdiToEdrsDocumentBundle
    {
        readonly Bundle bundle;

        internal MdiToEdrsDocumentBundle(Bundle bundle)
        {
            this.bundle = bundle;
            bundle.Type = Bundle.BundleType.Document;
        }

        /// <summary>
        /// Factory for Medicolegal Death Investigation Document Bundle Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs
        /// </summary>
        public static Bundle Create()
        {
            var bundle = new Bundle();
            bundle.MdiToEdrsDocumentBundle().AddProfile();
            return bundle;
        }

        /// <summary>
        /// The official URL for the Medicolegal Death Investigation Document Bundle profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs";

        /// <summary>
        /// Set the assertion that a questionnaire object conforms to the Medicolegal Death Investigation Document Bundle Profile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a questionnaire object conforms to the Medicolegal Death Investigation Document Bundle Profile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

    }
}