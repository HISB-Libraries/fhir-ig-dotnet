using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.Common
{
    public class MdiValueSet
    {
        public MdiValueSet()
        {
        }


        public static CodeableConcept MdiCaseNumber = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "mdi-case-number", "MDI Case Number", null);
        public static CodeableConcept EdrsFileNumber = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "edrs-file-number", "EDRS File Number", null);
        public static CodeableConcept ToxLabCaseNumber = new CodeableConcept("http://hl7.org/fhir/us/mdi/CodeSystem/CodeSystem-mdi-codes", "tox-lab-case-number", "Toxicology Laboratory Case Number", null);
    }
}
