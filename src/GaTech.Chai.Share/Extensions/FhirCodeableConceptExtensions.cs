using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    public static class FhirCodeableConceptCategoryExtensions
    {
        public static void SetCategory(this List<CodeableConcept> codeableConcepts, Coding coding)
        {
            foreach (CodeableConcept categoryConcept in codeableConcepts)
            {
                Coding extCoding = categoryConcept?.Coding.Find(e => e.System == coding.System && e.Code == coding.Code);
                if (coding != null)
                {
                    // we have this category already. 
                    return;
                }
            }

            codeableConcepts.Add(new CodeableConcept() { Coding = new List<Coding> { coding } });
        }

        public static CodeableConcept GetCategory(this List<CodeableConcept> codeableConcepts, Coding coding)
        {
            foreach (CodeableConcept categoryConcept in codeableConcepts)
            {
                Coding extCoding = categoryConcept?.Coding.Find(e => e.System == coding.System && e.Code == coding.Code);
                if (extCoding != null)
                {
                    return categoryConcept;
                }
            }

            return null;
        }

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
