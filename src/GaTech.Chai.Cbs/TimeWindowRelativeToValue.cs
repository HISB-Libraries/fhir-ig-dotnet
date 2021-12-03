using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs
{
    /// <summary>
    /// CBS Time Window Relative To Value Set (http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system)
    /// Codes for specific resource elements referenced by the CBS Program Specific Time Window extension, to convey to which element in the referenced resource a time window is relative.
    /// </summary>
    public static class TimeWindowRelativeToValue
    {
        public const string ValueSetOid = "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system";

        public static CodeableConcept ConditionOnsetDateTime => Encode("conditionOnsetDateTime", "Condition.onsetDateTime");
        public static CodeableConcept ConditionOnsetDatePeriodStart => Encode("conditionOnsetDatePeriodStart", "Condition.onsetDatePeriod.start");
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}
