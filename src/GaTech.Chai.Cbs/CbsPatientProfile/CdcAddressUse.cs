using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    /// <summary>
    /// Additional codes for Address.use
    /// Codes for Address.use which are used as slice discriminators to capture address history at relevant points in time to case surveillance
    /// </summary>
    public static class CdcAddressUse
    {
        public const string ValueSetUrl = "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system";

        public static CodeableConcept AddressAtDiagnosis => Encode("Address-at-Diagnosis", "Address at time of Diagnosis");
        public static CodeableConcept UsualResidence => Encode("Usual-Residence", "Usual Residence");
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetUrl, value, display, null);
    }
}