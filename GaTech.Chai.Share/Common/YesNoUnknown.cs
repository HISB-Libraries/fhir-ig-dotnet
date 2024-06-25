using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Share
{
    /// <summary>
    /// Yes No Unknown (YNU) https://phinvads.cdc.gov/vads/ViewValueSet.action?oid=2.16.840.1.114222.4.11.888
    /// Value set used to respond to any question that can be answered Yes, No, or Unknown.
    /// </summary>
    public static class YesNoUnknown
    {
        public static CodeableConcept Yes => new CodeableConcept("urn:oid:2.16.840.1.113883.12.136", "Y", "Yes", null);
        public static CodeableConcept No => new CodeableConcept("urn:oid:2.16.840.1.113883.12.136", "N", "No", null);
        public static CodeableConcept Unknown => new CodeableConcept("urn:oid:2.16.840.1.113883.5.1008", "UNK", "Unknown", null);
    }
}
