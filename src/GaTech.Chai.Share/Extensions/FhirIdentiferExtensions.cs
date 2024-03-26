using System;
using System.Collections.Generic;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Share.Extensions
{
    /// <summary>
    /// List Identifier extenstion for FHIR Identifier data
    /// </summary>
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

        public static Identifier GetIdentifier(this List<Identifier> identifiers, Coding coding)
        {
            return identifiers.Find(i => i.Type?.Coding?.Exists(c => c.System == coding.System && c.Code == coding.Code) == true);
        }

        public static List<Identifier> GetIdentifiers(this List<Identifier> identifiers, Coding coding)
        {
            return identifiers.FindAll(i => i.Type?.Coding?.Exists(c => c.System == coding.System && c.Code == coding.Code) == true);
        }

        public static void AddOrUpdateIdentifier(this List<Identifier> identifiers, string system, string value)
        {
            var id = identifiers.Find(c => c.System == system);
            if (id != null)
            {
                identifiers.Remove(id);
            }

            identifiers.Add(new Identifier(system, value));
        }

        public static void AddOrUpdateIdentifier(this List<Identifier> identifiers, Coding coding, string system, string value)
        {
            List<Identifier> _identifiers = identifiers.GetIdentifiers(coding);
            var id = _identifiers.Find(c => c.System == system);
            if (id != null)
            {
                identifiers.Remove(id);
            }

            identifiers.Add(new Identifier(){ Type = new CodeableConcept() { Coding = new List<Coding> { coding } }, System = system, Value = value } );
        }

        public static void AddOrUpdateIdentifier(this List<Identifier> identifiers, Coding coding, string value)
        {
            Identifier _identifier = identifiers.GetIdentifier(coding);
            if (_identifier != null)
            {
                identifiers.Remove(_identifier);
            }

            identifiers.Add(new Identifier() { Type = new CodeableConcept() { Coding = new List<Coding> { coding } }, Value = value });
        }

    }
}
