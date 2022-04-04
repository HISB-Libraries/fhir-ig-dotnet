using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    /// <summary>
    /// Observation Component extension for FHIR observation.component with DataAbsentReason
    /// </summary>
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

        public static Observation.ComponentComponent GetOrAddComponent(this List<Observation.ComponentComponent> componentComponents, string system, string code, string display)
        {
            var component = componentComponents.Find(
                c => c.Code.Coding.Exists(coding => coding.Code == code && coding.System == system));

            if (component == null)
            {
                component = new Observation.ComponentComponent()
                {
                    Code = new CodeableConcept(system, code, display, null)
                };
                componentComponents.Add(component);
            }

            return component;
        }

        public static Observation.ComponentComponent GetComponent(this List<Observation.ComponentComponent> componentComponents, string system, string code)
        {
            var component = componentComponents.Find(c => c.Code.Coding.Exists(coding => coding.Code == code && coding.System == system));
            return component;
        }

    }
}
