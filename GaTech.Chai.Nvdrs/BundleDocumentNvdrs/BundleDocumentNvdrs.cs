using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Share.Common;

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
    /// Factory for BundleDocumentMdiAndEdrsProfile with composition and identifier
    /// http://temp.draft.org/StructureDefinition/Bundle-document-nvdrs
    /// </summary>
    public static Bundle Create()
    {
        Bundle bundle = new();
        bundle.BundleDocumentNvdrs().AddFixedValues();
        bundle.BundleDocumentNvdrs().AddProfile();

        return bundle;
    }

    public void AddFixedValues()
    {
        bundle.Type = Bundle.BundleType.Document;
    }

    /// <summary>
    /// The official URL for the BundleDocumentNvdrsProfile, used to assert conformance.
    /// </summary>
    public const string ProfileUrl = "http://temp.draft.org/StructureDefinition/Bundle-document-nvdrs";

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


}