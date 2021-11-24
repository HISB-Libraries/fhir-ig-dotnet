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

        public static CodeableConcept Female => new CodeableConcept(ValueSetOid, "F", "Female", null);
        public static CodeableConcept Male => new CodeableConcept(ValueSetOid, "M", "Male", null);
        public static CodeableConcept Unknown => new CodeableConcept(ValueSetOid, "U", "Unknown", null);
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}