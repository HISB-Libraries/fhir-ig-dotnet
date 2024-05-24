using System;
using System.Linq;
using GaTech.Chai.Share.Common;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using static Hl7.Fhir.Model.Composition;

namespace GaTech.Chai.Share.Extensions;

public static class FhirAddReferencesToBundleEntryExtensions
{
    public static void AddRefsInCompositionToEntry(this Bundle bundle, Composition composition)
    {
        Resource resource = Record.GetResources()[composition.Subject.Reference] ?? throw (new MissingMemberException("Subject resource is not available in Record."));
        bool exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
        if (!exists)
        {
            bundle.AddResourceEntry(resource, resource.AsReference().Reference);
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
                exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
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
                exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
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
                    exists = bundle.FindEntry(resource.AsReference()).Any<Bundle.EntryComponent>();
                    if (!exists)
                    {
                        bundle.AddResourceEntry(resource, resource.AsReference().Reference);
                    }

                    // if the resource is observation, we may have focus being used.
                    if (resource is Observation obs)
                    {
                        if (!obs.Focus.IsNullOrEmpty())
                        {
                            foreach (ResourceReference reference in obs.Focus)
                            {
                                exists = bundle.FindEntry(reference).Any<Bundle.EntryComponent>();
                                if (!exists)
                                {
                                    Resource focusResource = Record.GetResources()[reference.Reference];
                                    bundle.AddResourceEntry(focusResource, focusResource.AsReference().Reference);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
