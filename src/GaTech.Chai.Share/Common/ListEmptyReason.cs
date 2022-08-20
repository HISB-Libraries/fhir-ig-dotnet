using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Common
{
    /// <summary>
    /// ListEmptyReason
    /// Reason code for the empty list
    /// </summary>
    public static class ListEmptyReason
    {
        public static CodeableConcept Nilknown => new CodeableConcept("http://terminology.hl7.org/CodeSystem/list-empty-reason", "nilknown", "Nil Known", null);
        public static CodeableConcept Notasked => new CodeableConcept("http://terminology.hl7.org/CodeSystem/list-empty-reason", "notasked", "Not Asked", null);
        public static CodeableConcept Withheld => new CodeableConcept("http://terminology.hl7.org/CodeSystem/list-empty-reason", "withheld", "Information Withheld", null);
        public static CodeableConcept Unavailable => new CodeableConcept("http://terminology.hl7.org/CodeSystem/list-empty-reason", "unavailable", "Unavailable", null);
        public static CodeableConcept Notstarted => new CodeableConcept("http://terminology.hl7.org/CodeSystem/list-empty-reason", "notstarted", "Not Started", null);
        public static CodeableConcept Closed => new CodeableConcept("http://terminology.hl7.org/CodeSystem/list-empty-reason", "closed", "Closed", null);
    }
}
