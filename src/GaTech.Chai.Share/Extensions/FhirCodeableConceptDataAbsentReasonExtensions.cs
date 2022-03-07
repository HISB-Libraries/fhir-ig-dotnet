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
                    // we have LAB category already. 
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
    }
}
