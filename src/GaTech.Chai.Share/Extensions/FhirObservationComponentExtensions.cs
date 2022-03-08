using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    public static class FhirObservationComponentExtensions
    {
        public static void AddDataAbsentReason(this Observation.ComponentComponent componentComponent, Code code)
        {
            componentComponent.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);

            // This is a data absent reason for value[x] missing. Thus, value[x] must be null.
            // Set it to null in case that some values exist
            componentComponent.Value = null;
        }

        public static Code GetDataAbsentReason(this Observation.ComponentComponent componentComponent)
        {
            return componentComponent.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
        }
    }
}
