using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.FhirIg.Extensions
{
    public static class FhirIdentiferExtensions
    {
        public static void AddOrUpdateIdentifier(this List<Identifier> identifiers,
            string system, string code, Identifier identifier)
        {
            if (!identifier.Type?.Coding?.Exists(c => c.System == system && c.Code == code) == true)
                identifier.Type.Coding.Add(new Coding() { System = system, Code = code });

            var id = identifiers.GetIdentifier(system, code);
            if (id != null)
                identifiers.Remove(id);

            identifiers.Add(identifier);
        }

        public static Identifier GetIdentifier(this List<Identifier> identifiers,
            string system, string code)
        {
            return identifiers.Find(i => i.Type?.Coding?.Exists(c => c.System == system && c.Code == code) == true);
        }
    }
}
