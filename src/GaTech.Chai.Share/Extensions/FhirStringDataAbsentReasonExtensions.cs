using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    /// <summary>
    /// String extension for DataAbsentReason
    /// </summary>
    public static class FhirStringDataAbsentReasonExtensions
    {
        public static void AddDataAbsentReason(this FhirString fhirString, Code code)
        {
            fhirString.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);
        }

        public static Code GetDataAbsentReason(this FhirString fhirString)
        {
            return fhirString.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
        }
    }
}
