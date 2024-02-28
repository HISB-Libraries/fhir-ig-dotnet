using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Collections.Generic;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.Mdi.ObservationCauseOfDeathPart1Profile;
using GaTech.Chai.Mdi.CompositionMdiAndEdrsProfile;
using static Hl7.Fhir.Model.Composition;
using System.Linq;

namespace GaTech.Chai.Mdi.BundleDocumentMdiAndEdrsProfile
{
    /// <summary>
    /// BundleDocumentMdiAndEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-and-edrs
    /// </summary>
    public class BundleDocumentMdiAndEdrs
    {
        readonly Bundle bundle;

        internal BundleDocumentMdiAndEdrs(Bundle bundle)
        {
            this.bundle = bundle;

            if (bundle.Entry != null && bundle.Entry.Count > 0)
            {
                Resource resource = bundle.Entry[0].Resource;
                if (resource != null && resource is Composition)
                {
                    AddResourcesToComposition((Composition)resource);
                }
                else
                {
                    throw new ArgumentNullException("MDI-and-EDRS profile Bundle Document requires Bundle.entry[0] to be Composition.");
                }
            }
        }

        /// <summary>
        /// Factory for BundleDocumentMdiAndEdrsProfile with composition and identifier
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-and-edrs
        /// </summary>
        public static Bundle Create(Identifier identifier, Composition composition)
        {
            var bundle = new Bundle();
            bundle.Type = Bundle.BundleType.Document;

            if (identifier == null)
            {
                throw new ArgumentNullException("Identifier cannot be null for MDIandEdrs Bundle.");
            }
                
            if (composition == null)
            {
                throw new ArgumentNullException("Composition cannot be null for MDIandEdrs Bundle entry[0].");
            }

            bundle.Identifier = identifier;

            bundle.BundleDocumentMdiAndEdrs().MDItoEDRSComposition = composition;
            bundle.BundleDocumentMdiAndEdrs().AddProfile();

            return bundle;
        }

        /// <summary>
        /// The official URL for the BundleDocumentMdiAndEdrsProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-and-edrs";

        /// <summary>
        /// Set the profile URL for the BundleDocumentMdiAndEdrsProfile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the profile URL for the BundleDocumentMdiAndEdrsProfile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

        public string COD1A
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().COD1A;
            }
        }

        public string INTERVAL1A
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().INTERVAL1A;
            }
        }

        public string COD1B
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().COD1B;
            }
        }

        public string INTERVAL1B
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().INTERVAL1B;
            }
        }
        public string COD1C
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().COD1C;
            }
        }

        public string INTERVAL1C
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().INTERVAL1C;
            }
        }
        public string COD1D
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().COD1D;
            }
        }

        public string INTERVAL1D
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                return composition.CompositionMdiAndEdrs().INTERVAL1D;
            }
        }

        public (string, string) CauseOfDeathPart1A
        {
            get
            {
                foreach (Resource resource in bundle.GetResources())
                {
                    if (resource is Observation)
                    {
                        Observation ob = (Observation)resource;
                        if (ob.IsObservationCode("CauseOfDeathPart1"))
                        {
                            if (ob.ObservationCauseOfDeathPart1().LineNumber.Value == 1)
                            {
                                return (ob.ObservationCauseOfDeathPart1().ValueText, ob.ObservationCauseOfDeathPart1().Interval);
                            }
                        }
                    }
                }

                return (null, null);
            }
        }

        public (string, string) CauseOfDeathPart1B
        {
            get
            {
                Composition composition = (Composition)this.bundle.Entry[0]?.Resource;
                
                foreach (Resource resource in bundle.GetResources())
                {
                    if (resource is Observation)
                    {
                        Observation ob = (Observation)resource;
                        if (ob.IsObservationCode("CauseOfDeathPart1"))
                        {
                            if (ob.ObservationCauseOfDeathPart1().LineNumber.Value == 2)
                            {
                                return (ob.ObservationCauseOfDeathPart1().ValueText, ob.ObservationCauseOfDeathPart1().Interval);
                            }
                        }
                    }
                }

                return (null, null);
            }
        }

        public (string, string) CauseOfDeathPart1C
        {
            get
            {
                foreach (Resource resource in bundle.GetResources())
                {
                    if (resource is Observation)
                    {
                        Observation ob = (Observation)resource;
                        if (ob.IsObservationCode("CauseOfDeathPart1"))
                        {
                            if (ob.ObservationCauseOfDeathPart1().LineNumber.Value == 3)
                            {
                                return (ob.ObservationCauseOfDeathPart1().ValueText, ob.ObservationCauseOfDeathPart1().Interval);
                            }
                        }
                    }
                }

                return (null, null);
            }
        }

        public (string, string) CauseOfDeathPart1D
        {
            get
            {
                foreach (Resource resource in bundle.GetResources())
                {
                    if (resource is Observation)
                    {
                        Observation ob = (Observation)resource;
                        if (ob.IsObservationCode("CauseOfDeathPart1"))
                        {
                            if (ob.ObservationCauseOfDeathPart1().LineNumber.Value == 4)
                            {
                                return (ob.ObservationCauseOfDeathPart1().ValueText, ob.ObservationCauseOfDeathPart1().Interval);
                            }
                        }
                    }
                }

                return (null, null);
            }
        }

        public Resource FindResourceInEntry(ResourceReference reference)
        {
            if (reference == null) return null;
            IEnumerable<Resource> entryResources = this.bundle.GetResources();
            if (entryResources.Count <Resource>() > 0)
            {
                IEnumerable<Resource> retResource = from e in entryResources
                                                    where e.AsReference().Reference.Equals(reference.Reference)
                                                    select e;
                if (retResource.Count<Resource>() > 0)
                {
                    return retResource.First<Resource>();
                }
            }

            return null;
        }

        private void AddResourcesToComposition (Composition composition)
        {
            Resource resource = FindResourceInEntry(composition.Subject);
            if (resource != null)
            {
                composition.CompositionMdiAndEdrs().AddResources(composition.Subject.Reference, resource);
            }

            resource = FindResourceInEntry(composition.Author[0]);
            if (resource != null)
            {
                composition.CompositionMdiAndEdrs().AddResources(composition.Author[0].Reference, resource);
            }

            resource = FindResourceInEntry(composition.Attester[0].Party);
            if (resource != null)
            {
                composition.CompositionMdiAndEdrs().AddResources(composition.Attester[0].Party.Reference, resource);
            }

            foreach (SectionComponent section in composition.Section)
            {
                foreach (ResourceReference sectionEntryReference in section.Entry)
                {
                    resource = FindResourceInEntry(sectionEntryReference);
                    if (resource != null)
                    {
                        composition.CompositionMdiAndEdrs().AddResources(sectionEntryReference.Reference, resource);
                    }
                }
            }

        }

        public Composition MDItoEDRSComposition
        {
            get
            {
                Composition composition = (Composition)bundle.Entry?[0].Resource;
                if (composition != null)
                {
                    Dictionary<string, Resource> entryResources = composition.CompositionMdiAndEdrs().GetResources();
                    if (entryResources.Count > 0)
                    {
                        return composition;
                    }
                    else
                    {
                        // add resources in composition.
                        AddResourcesToComposition(composition);
                    }
                }

                return composition;
            }
            set
            {
                // First check if the composition is
                // a http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs profile.
                if (!value.hasProfile(CompositionMdiAndEdrs.ProfileUrl))
                {
                    Console.WriteLine("Bundle-document-mdi-to-edrs requires the composition to be http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs profile");
                    throw (new ArgumentException("DocumentMdiToEdrs bundle must have Composition-mdi-to-edrs."));
                }

                // First entry MUST be composition
                bundle.Entry.Clear();
                bundle.AddResourceEntry(value, value.AsReference().Reference);
                //bundle.Entry.Add(new Bundle.EntryComponent() { FullUrl = value.AsReference().Reference, Resource = value });

                // We have sections in the composition. Add them to entries if we have them.
                Dictionary<string, Resource> entryResources = value.CompositionMdiAndEdrs().GetResources();
                foreach (var urlAndResource in entryResources)
                {
                    bundle.AddResourceEntry(urlAndResource.Value, urlAndResource.Key);
                }
            }
        }
    }
}