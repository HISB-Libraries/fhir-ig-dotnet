using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    public static class FhirCodeableConceptDataAbsentReasonExtensions
    {
        public static void AddDataAbsentReason(this CodeableConcept codeableConcept, Code code)
        {
            codeableConcept.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);
        }

        public static Code GetDataAbsentReason(this CodeableConcept codeableConcept)
        {
            return codeableConcept.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
        }
    }
}
