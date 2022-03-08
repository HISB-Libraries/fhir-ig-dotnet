using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    public static class FhirTelecomExtensions
    {
        public static void AddDataAbsentReason(this ContactPoint contactPoint, Code code)
        {
            contactPoint.Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", code);
        }

        public static Code GetDataAbsentReason(this ContactPoint contactPoint)
        {
            return contactPoint.GetExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
        }

        public static void AddTelecom(this List<ContactPoint> contactPoints, ContactPoint.ContactPointSystem system, ContactPoint.ContactPointUse use, string value)
        {
            ContactPoint cp = contactPoints?.Find(t => t.System == system && t.Value == value);
            if (cp == null)
            {
                contactPoints.Add(new ContactPoint() { System = system, Use = use, Value = value });
            }
        }

        public static List<ContactPoint> GetTelecom(this List<ContactPoint> contactPoints, ContactPoint.ContactPointSystem system)
        {
            return contactPoints?.FindAll(t => t.System == system);
        }
    }
}
