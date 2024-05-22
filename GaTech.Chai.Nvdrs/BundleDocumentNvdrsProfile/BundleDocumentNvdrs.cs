using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Nvdrs.CompositionNVDRSProfile;
using GaTech.Chai.Share.Common;
using static Hl7.Fhir.Model.Composition;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Nvdrs;

/// <summary>
/// </summary>
public class BundleDocumentNvdrs
{
    readonly Bundle bundle;

    internal BundleDocumentNvdrs(Bundle bundle)
    {
        this.bundle = bundle;
    }

    /// <summary>
    /// Factory for BundleDocumentNvdrsProfile
    /// http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-document-bundle
    /// </summary>
    public static Bundle Create()
    {
        Bundle bundle = new();
        bundle.BundleDocumentNvdrs().AddFixedValues();
        bundle.BundleDocumentNvdrs().AddProfile();

        return bundle;
    }

    /// <summary>
    /// Factory for BundleDocumentNvdrsProfile with Composition
    /// http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-document-bundle
    /// </summary>
    public static Bundle Create(Composition composition)
    {
        Bundle bundle = new();
        bundle.BundleDocumentNvdrs().NVDRSComposition = composition ?? throw new Exception("Composition cannot be null for MDIandEdrs Bundle entry[0].");
        bundle.BundleDocumentNvdrs().AddProfile();
        bundle.BundleDocumentNvdrs().AddFixedValues();

        return bundle;
    }

    public void AddFixedValues()
    {
        bundle.Type = Bundle.BundleType.Document;
        if (bundle.Timestamp == null)
        {
            bundle.Timestamp = DateTime.Now;
        }

        bundle.Identifier ??= new("urn:gtri:heat-hisp:nvdrs-testing", Uuid.Generate().Value);
    }

    /// <summary>
    /// The official URL for the BundleDocumentNvdrsProfile, used to assert conformance.
    /// </summary>
    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-document-bundle";

    /// <summary>
    /// Set the profile URL.
    /// </summary>
    public void AddProfile()
    {
        bundle.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear the profile URL.
    /// </summary>
    public void RemoveProfile()
    {
        bundle.RemoveProfile(ProfileUrl);
    }

    private void AddReferencesInCompositionToEntry(Composition composition)
    {
        Resource resource = Record.GetResources()[composition.Subject.Reference];
        if (resource == null)
        {
            throw (new MissingMemberException("Subject resource is not available in Record."));
        }

        if (resource != null)
        {
            bool exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
            if (!exists)
            {
                bundle.AddResourceEntry(resource, resource.AsReference().Reference);
            }
        }

        if (!composition.Author.IsNullOrEmpty() && composition.Author[0].Reference != null)
        {
            resource = Record.GetResources()[composition.Author[0].Reference];
            if (resource == null)
            {
                throw (new MissingMemberException("Author[0] resource is not available in Record."));
            }

            if (resource != null)
            {
                bool exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
                if (!exists)
                {
                    bundle.AddResourceEntry(resource, resource.AsReference().Reference);
                }
            }
        }

        if (!composition.Attester.IsNullOrEmpty() && composition.Attester[0].Party != null && composition.Attester[0].Party.Reference != null)
        {
            resource = Record.GetResources()[composition.Attester[0].Party.Reference];
            if (resource == null)
            {
                throw (new MissingMemberException("Attester[0] resource is not available in Record."));
            }

            if (resource != null)
            {
                bool exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
                if (!exists)
                {
                    bundle.AddResourceEntry(resource, resource.AsReference().Reference);
                }
            }
        }

        foreach (SectionComponent section in composition.Section)
        {
            foreach (ResourceReference sectionEntryReference in section.Entry)
            {
                resource = Record.GetResources()[sectionEntryReference.Reference];
                if (resource == null)
                {
                    throw (new MissingMemberException(sectionEntryReference.Reference + " resource is not available in Record."));
                }
                if (resource != null)
                {
                    bool exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
                    if (!exists)
                    {
                        bundle.AddResourceEntry(resource, resource.AsReference().Reference);
                    }

                    // if the resource is observation, we may have focus being used.
                    if (resource is Observation obs)
                    {
                        if (!obs.Focus.IsNullOrEmpty())
                        {
                            exists = bundle.FindEntry(obs.Focus[0]).Any<Bundle.EntryComponent>();
                            if (!exists)
                            {
                                Resource focusResource = Record.GetResources()[obs.Focus[0].Reference];
                                bundle.AddResourceEntry(focusResource, focusResource.AsReference().Reference);
                            }
                        }
                    }
                }
            }
        }
    }
    public Composition NVDRSComposition
    {
        get
        {
            return this.bundle.Entry?[0].Resource as Composition;
        }
        set
        {
            // First check if the composition is
            // a http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs profile.
            if (!value.hasProfile(CompositionNVDRS.ProfileUrl))
            {
                throw (new ArgumentException("The composition must have Composition-mdi-to-edrs as a profile."));
            }

            // First entry MUST be composition
            // Check if composition already exists.
            if (bundle.Entry.Any<Bundle.EntryComponent>())
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
            AddReferencesInCompositionToEntry(value);
        }
    }

    // Below is to support NVDRS raw data export.
    public void ExportToNVDRS(FlatObject myFlatObject)
    {
        myFlatObject.MapToNVDRS(bundle);
        myFlatObject.ExportToFile();
    }
}