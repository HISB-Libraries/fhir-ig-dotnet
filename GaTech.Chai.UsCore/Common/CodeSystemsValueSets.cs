using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.Common
{
	public class CodeSystemsValueSets
	{
        public class UsCoreDocumentReferenceType
        {
            public static string officialUrl = "http://terminology.hl7.org/CodeSystem/v3-NullFlavor";

            public static Coding UNK = new(officialUrl, "UNK", "unknown");
        }

        public class UsCoreDocumentReferenceCategory
        {
            public static string officialUrl = "http://hl7.org/fhir/us/core/CodeSystem/us-core-documentreference-category";

            public static Coding ClinicalNote = new(officialUrl, "clinical-note", "Clinical Note");
        }

    }
}

