using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    public static class FhirTelecomDataAbsentReasonExtensions
    {
        public static void AddDataAbsentReason(this ContactPoint contactPoint, Code code)
        {
            contactPoint.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);
        }

        public static Code GetDataAbsentReason(this ContactPoint contactPoint)
        {
            return contactPoint.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
        }
    }
}
