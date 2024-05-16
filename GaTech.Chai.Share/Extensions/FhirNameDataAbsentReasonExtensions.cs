using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Share.Extensions
{
    /// <summary>
    /// HumanName extension for FHIR Name DataAbsentReason
    /// </summary>
    public static class FhirNameDataAbsentReasonExtensions
    {
        public static void AddDataAbsentReason(this HumanName humanName, Code code)
        {
            humanName.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);
        }

        public static Code GetDataAbsentReason(this HumanName humanName)
        {
            return humanName.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
        }
    }
}
