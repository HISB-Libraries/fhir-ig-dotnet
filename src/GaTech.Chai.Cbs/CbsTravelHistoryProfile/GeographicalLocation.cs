using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsConditionProfile
{
    /// <summary>
    /// Geographical location (2.16.840.1.114222.4.11.3201)
    /// Locations out of US (Birth Country) and jurisdictions within US (states) that are potentially
    /// relevent to current condition. This value set is based upon ISO 3166 (Countries) as well as FIPS 5-2 (States).
    /// </summary>
    public static class GeographicalLocation
    {
        public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.3201";

        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}