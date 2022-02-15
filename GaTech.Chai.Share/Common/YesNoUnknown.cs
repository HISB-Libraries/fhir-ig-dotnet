using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.Common
{
    /// <summary>
    /// Yes No Unknown (YNU) (2.16.840.1.114222.4.11.888)
    /// Value set used to respond to any question that can be answered Yes, No, or Unknown.
    /// </summary>
    public static class YesNoUnknown
    {
        public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.888";

        public static CodeableConcept Yes => Encode("Y", "Yes");
        public static CodeableConcept No => Encode("N", "No");
        public static CodeableConcept Unknown => Encode("U", "Unknown");
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}
