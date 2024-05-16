using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;

namespace GaTech.Chai.Cbs.DocumentBundleProfile
{
    /// <summary>
    /// Case Based Surveillance Document Bundle Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-document-bundle
    /// </summary>
    public class CbsDocumentBundle
    {
        readonly Bundle bundle;

        internal CbsDocumentBundle(Bundle bundle)
        {
            this.bundle = bundle;
            bundle.Type = Bundle.BundleType.Document;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Document Bundle Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-document-bundle
        /// </summary>
        public static Bundle Create()
        {
            var bundle = new Bundle();
            bundle.CbsDocumentBundle().AddProfile();
            return bundle;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Document Bundle profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-document-bundle";

        /// <summary>
        /// Set profile for Case Based Surveillance Document Bundle Profile
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Case Based Surveillance Document Bundle Profile
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

    }
}