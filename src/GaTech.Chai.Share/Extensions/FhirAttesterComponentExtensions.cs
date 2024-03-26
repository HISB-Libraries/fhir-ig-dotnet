using System;
using Hl7.Fhir.Model;
using static Hl7.Fhir.Model.Composition;

namespace GaTech.Chai.Share.Extensions
{
    public static class FhirAttesterComponentExtensions
    {
            public static void AddDataAbsentReason(this AttesterComponent attesterComponent, Code code)
            {
                attesterComponent.Extension.AddOrUpdateExtension(
                        "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);
            }

            public static Code GetDataAbsentReason(this AttesterComponent attesterComponent)
            {
                return attesterComponent.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
            }
    }
}
