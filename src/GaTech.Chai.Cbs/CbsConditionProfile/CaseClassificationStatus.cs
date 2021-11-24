using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsConditionProfile
{
    /// <summary>
    /// Case Classification Status (2.16.840.1.114222.4.11.968)
    /// Indicates how the Nationally Notifiable Disease case was classified at its close
    /// </summary>
    public static class CaseClassificationStatus
    {
        public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.968";

        public static CodeableConcept ConfirmedPresent => new CodeableConcept(ValueSetOid, "410605003", "Confirmed present", null);
        public static CodeableConcept NotACase => new CodeableConcept(ValueSetOid, "PHC178", "Not a Case", null);
        public static CodeableConcept ProbableDiagnosis => new CodeableConcept(ValueSetOid, "2931005", "Probable diagnosis", null);
        public static CodeableConcept Suspected => new CodeableConcept(ValueSetOid, "415684004", "Suspected", null);
        public static CodeableConcept Unknown => new CodeableConcept(ValueSetOid, "UNK", "Unknown", null);
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}