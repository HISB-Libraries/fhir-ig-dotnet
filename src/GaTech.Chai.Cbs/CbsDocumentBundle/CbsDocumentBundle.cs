using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsDocumentBundleProfile
{
    /// <summary>
    /// Case Based Surveillance Document Bundle Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-document-bundle
    /// </summary>
    public class CbsDocumentBundle
    {
        readonly Bundle bundle;

        internal CbsDocumentBundle(Bundle bundle)
        {
            this.bundle = bundle;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Document Bundle Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-document-bundle
        /// </summary>
        public static Bundle Create()
        {
            var bundle = new Bundle();
            bundle.CbsDocumentBundle().AddProfile();
            bundle.Type = Bundle.BundleType.Document;
            return bundle;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Document Bundle profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-document-bundle";

        /// <summary>
        /// Set the assertion that a questionnaire object conforms to the Case Based Surveillance Document Bundle Profile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a questionnaire object conforms to the Case Based Surveillance Document Bundle Profile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

    }
}