using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Share
{
    /// <summary>
    /// List Extension extension for FHIR extension data
    /// </summary>
    public static class FhirExtensionExtensions
    {
        public static Extension AddOrUpdateExtension(this List<Extension> extensions, Extension extension, bool allowDuplicateUrl = false)
        {
            var ext = extensions.Find(e => e.Url == extension.Url);
            if (ext == null || allowDuplicateUrl == true)
            {
                extensions.Add(extension);
                ext = extension;
            }
            else
                ext.Value = extension.Value;
            return ext;
        }

        public static void AddOrUpdateExtension(this List<Extension> extensions, string url, DataType value)
        {
            extensions.AddOrUpdateExtension(new Extension(url, value));
        }
    }
}
