using Hl7.Fhir.Model;

namespace GaTech.Chai.Share.Extensions
{
    /// <summary>
    /// DataAbsentReason extension for Reference
    /// </summary>
    public static class FhirReferenceDataAbsentReasonExtensions
    {
        public static void AddDataAbsentReason(this ResourceReference reference, Code code)
        {
            reference.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);
        }

        public static Code GetDataAbsentReason(this ResourceReference reference)
        {
            return reference.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
        }
    }
}
