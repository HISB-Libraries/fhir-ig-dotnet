using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    /// <summary>
    /// Birth Sex from Sex (MFU) (2.16.840.1.114222.4.11.1038)
    /// Constrained list of sex codes in use by public health
    /// </summary>
    public static class BirthSex
    {
        public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.1038";

        public static CodeableConcept Female => Encode("F", "Female");
        public static CodeableConcept Male => Encode("M", "Male");
        public static CodeableConcept Unknown => Encode("U", "Unknown");
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}