using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsTravelHistoryProfile
{
    /// <summary>
    /// Case Classification Status (2.16.840.1.114222.4.11.968)
    /// Indicates how the Nationally Notifiable Disease case was classified at its close
    /// </summary>
    public static class CaseClassificationStatus
    {
        public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.968";

        public static CodeableConcept ConfirmedPresent => Encode("410605003", "Confirmed present");
        public static CodeableConcept NotACase => Encode("PHC178", "Not a Case");
        public static CodeableConcept ProbableDiagnosis => Encode("2931005", "Probable diagnosis");
        public static CodeableConcept Suspected => Encode("415684004", "Suspected");
        public static CodeableConcept Unknown => Encode("UNK", "Unknown");
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}