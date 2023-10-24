using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Collections.Generic;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.Mdi.ObservationCauseOfDeathPart1Profile;
using GaTech.Chai.Mdi.CompositionMdiAndEdrsProfile;

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
            bundle.Type = Bundle.BundleType.Document;
        }

        /// <summary>
        /// Factory for BundleDocumentMdiAndEdrsProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-and-edrs
        /// </summary>
        public static Bundle Create()
        {
            var bundle = new Bundle();
            bundle.BundleDocumentMdiAndEdrs().AddProfile();

            return bundle;
        }

        /// <summary>
        /// Factory for BundleDocumentMdiAndEdrsProfile with composition and identifier
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-and-edrs
        /// </summary>
        public static Bundle Create(Identifier identifier, Composition composition)
        {
            var bundle = new Bundle();
            bundle.BundleDocumentMdiAndEdrs().AddProfile();

            if (identifier != null) bundle.Identifier = identifier;
            if (composition != null) bundle.BundleDocumentMdiAndEdrs().MDItoEDRSComposition = composition;

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
                Dictionary<string, Resource> entryResources = value.CompositionMdiAndEdrs().GetResourcesInSections();
                foreach (var urlAndResource in entryResources)
                {
                    bundle.AddResourceEntry(urlAndResource.Value, urlAndResource.Key);
                }
            }
        }
    }
}