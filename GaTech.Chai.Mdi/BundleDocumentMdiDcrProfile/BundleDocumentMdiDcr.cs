using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// This Bundle profile represents a Document Bundle from deathe certificate review. 
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-dcr
    /// </summary>
    public class BundleDocumentMdiDcr
    {
        readonly Bundle bundle;

        readonly static Dictionary<string, Resource> resources = new();

        internal BundleDocumentMdiDcr(Bundle bundle)
        {
            this.bundle = bundle;
        }

        /// <summary>
        /// Factory for BundleDocumentMdiDcrProfile with composition and identifier
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-dcr
        /// </summary>
        public static Bundle Create(Identifier identifier, Composition composition)
        {
            Bundle bundle = new()
            {
                Identifier = identifier ?? throw new Exception("Identifier cannot be null for MDI DCR Document Bundle.")
            };

            bundle.BundleDocumentMdiDcr().CompositionMDIDCR = composition ?? throw new Exception("Composition cannot be null for MDI DCR Document Bundle entry[0].");
            bundle.BundleDocumentMdiDcr().AddProfile();
            bundle.BundleDocumentMdiDcr().AddFixedValues();

            return bundle;
        }

        public static Bundle Create()
        {
            Bundle bundle = new();
            bundle.BundleDocumentMdiDcr().AddProfile();
            bundle.BundleDocumentMdiDcr().AddFixedValues();

            return bundle;
        }

        public void AddFixedValues()
        {
            bundle.Type = Bundle.BundleType.Document;
        }

        public void ImportResourcesInEntry()
        {
            foreach (Bundle.EntryComponent entry in this.bundle.Entry)
            {
                if (entry.Resource != null)
                {
                    Record.GetResources()[entry.Resource.AsReference().Reference] = entry.Resource;
                }
            }
        }

        /// <summary>
        /// The official URL for the BundleDocumentMdiDcrProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-dcr";

        /// <summary>
        /// Set the profile URL for the BundleDocumentMdiDcrProfile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the profile URL for the BundleDocumentMdiDcrProfile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

        public Resource FindResourceInEntry(ResourceReference reference)
        {
            if (reference == null) return null;
            IEnumerable<Resource> entryResources = this.bundle.GetResources();
            if (entryResources.Any())
            {
                IEnumerable<Resource> retResource = from e in entryResources
                                                    where e.AsReference().Reference.Equals(reference.Reference)
                                                    select e;
                if (retResource.Any())
                {
                    return retResource.First<Resource>();
                }
            }

            return null;
        }

        public Composition 	CompositionMDIDCR
        {
            get
            {
                return this.bundle.Entry?[0].Resource as Composition;
            }
            set
            {
                // First check if the composition is
                // a http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-dcr profile.
                if (!value.hasProfile(CompositionMdiDcr.ProfileUrl))
                {
                    throw (new ArgumentException("The composition must have Composition-mdi-dcr as a profile."));
                }

                // First entry MUST be composition
                // Check if composition already exists.
                if (bundle.Entry.Count != 0)
                {
                    Resource resource = this.bundle.Entry[0].Resource;
                    if (resource is Composition)
                    {
                        // There exists one.... we will be replacing this.
                        this.bundle.Entry.RemoveAt(0);
                    }
                }

                Bundle.EntryComponent entryComponent = new()
                {
                    Resource = value,
                    FullUrl = value.AsReference().Reference
                };

                bundle.Entry.Insert(0, entryComponent);

                // Add references in composition to bundle entry.
                bundle.AddRefsInCompositionToEntry(value);
            }
        }
        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}