using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using static Hl7.Fhir.Model.Composition;

namespace GaTech.Chai.Share;

public static class FhirBundleImportToLibraryExtensions
{
    public static void ImportToLibrary(this Bundle bundle)
    {
        foreach (Bundle.EntryComponent entry in bundle.Entry)
        {
            Resource resource = entry.Resource;
            if (resource != null)
            {
                Record.GetResources().Add(resource.AsReference().Reference, resource);
            }
        }
    }
}
