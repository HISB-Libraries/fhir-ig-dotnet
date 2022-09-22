using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using System.Collections.Generic;
using GaTech.Chai.Mdi.CompositionMditoEdrsProfile;

namespace GaTech.Chai.Mdi.BundleDocumentMdiToEdrsProfile
{
    /// <summary>
    /// BundleDocumentMdiToEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs
    /// </summary>
    public class BundleDocumentMdiToEdrs
    {
        readonly Bundle bundle;

        internal BundleDocumentMdiToEdrs(Bundle bundle)
        {
            this.bundle = bundle;
            bundle.Type = Bundle.BundleType.Document;
        }

        /// <summary>
        /// Factory for BundleDocumentMdiToEdrsProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs
        /// </summary>
        public static Bundle Create(Composition composition, Identifier identifier)
        {
            var bundle = new Bundle();
            bundle.BundleDocumentMdiToEdrs().AddProfile();

            if (composition != null) bundle.BundleDocumentMdiToEdrs().MDItoEDRSComposition = composition;
            if (identifier != null) bundle.Identifier = identifier;

            return bundle;
        }

        public static Bundle Create()
        {
            var bundle = new Bundle();
            bundle.BundleDocumentMdiToEdrs().AddProfile();

            return bundle;
        }

        /// <summary>
        /// The official URL for the BundleDocumentMdiToEdrsProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-to-edrs";

        /// <summary>
        /// Set the profile URL for the BundleDocumentMdiToEdrsProfile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the profile URL for the BundleDocumentMdiToEdrsProfile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

        public Composition MDItoEDRSComposition
        {
            get
            {
                return (Composition) bundle.Entry?[0].Resource;
            }
            set
            {
                // First check if the composition is
                // a http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs profile.
                if (!value.hasProfile("http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs"))
                {
                    Console.WriteLine("Bundle-document-mdi-to-edrs requires the composition to be http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs profile");
                    throw (new ArgumentException("DocumentMdiToEdrs bundle must have Composition-mdi-to-edrs."));
                }

                // First entry MUST be composition
                bundle.Entry.Add(new Bundle.EntryComponent() { FullUrl = value.AsReference().Reference, Resource = value });

                // We have sections in the composition. Add them to entries if we have them.
                Dictionary<string, Resource> entryResources = value.CompositionMdiToEdrs().GetResourcesInSections();
                foreach (var urlAndResource in entryResources)
                {
                    bundle.Entry.Add(new Bundle.EntryComponent() { FullUrl = urlAndResource.Key, Resource = urlAndResource.Value });
                }
            }
        }
    }
}