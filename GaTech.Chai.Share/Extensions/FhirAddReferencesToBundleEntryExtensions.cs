using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using static Hl7.Fhir.Model.Composition;

namespace GaTech.Chai.Share;

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

        // Get Event
        if (!composition.Event.IsNullOrEmpty())
        {
            EventComponent myEvent = composition.Event[0];
            if (!myEvent.Detail.IsNullOrEmpty())
            {
                ResourceReference myDetail = myEvent.Detail[0];
                if (!myDetail.IsNullOrEmpty())
                {
                    Resource myDetailResource = Record.GetResources()[myDetail.Reference];
                    if (myDetailResource != null)
                    {
                        bundle.AddResourceEntry(myDetailResource, myDetailResource.AsReference().Reference);
                    }
                }
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

                                    if (focusResource is Observation obs_)
                                    {
                                        foreach (Extension ext in obs_.Extension)
                                        {
                                            if (ext.Extension.Count > 0)
                                            {
                                                AddExtensionReferenceToEntry(ext, bundle);
                                            }
                                        }
                                    }
                                    else if (focusResource is Composition comp_)
                                    {
                                        bundle.AddRefsInCompositionToEntry(comp_);
                                    }
                                }
                            }
                        }

                        foreach (Extension ext in obs.Extension)
                        {
                            if (ext.Extension.Count > 0)
                            {
                                AddExtensionReferenceToEntry(ext, bundle);
                            }
                        }
                    }
                    else if (resource is Composition comp)
                    {
                        bundle.AddRefsInCompositionToEntry(comp);
                    }
                }
            }
        }
    }

    static void AddExtensionReferenceToEntry(Extension ext, Bundle bundle)
    {
        if (ext.Value is ResourceReference reference)
        {
            Resource resource = Record.GetResources()[reference.Reference];
            bundle.AddResourceEntry(resource, resource.AsReference().Reference);
        }

        if (ext.Extension.Count > 0)
        {
            foreach (Extension ext_ in ext.Extension)
            {
                AddExtensionReferenceToEntry(ext_, bundle);
            }
        }
    }
}
