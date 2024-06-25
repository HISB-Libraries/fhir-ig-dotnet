using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// US Core Patient Race Extension Helper
    /// </summary>
    public class UsCorePatientRace
    {
        readonly Patient patient;

        internal UsCorePatientRace(Patient patient)
        {
            this.patient = patient;
        }

        public const string ExtUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-race";

        public Coding Category
        {
            set
            {
                var raceExt = AddOrUpdateRaceExtension();
                raceExt.Extension.AddOrUpdateExtension(new Extension("ombCategory", value));
            }
            get
            {
                var raceExt = patient.GetExtension(ExtUrl);
                return raceExt?.GetExtension("ombCategory").Value as Coding;
            }
        }

        public IEnumerable<Coding> ExtendedRaceCodes
        {
            set
            {
                var raceExt = AddOrUpdateRaceExtension();
                raceExt.Extension.RemoveAll(r => r.Url == "detailed");
                raceExt.Extension.AddRange(
                    from extCode in value
                    select new Extension("detailed", extCode));
            }
            get
            {
                var raceExt = patient.GetExtension(ExtUrl);
                if (raceExt == null)
                    return Array.Empty<Coding>();
                return from r in raceExt.Extension
                       where r.Url == "detailed"
                       select r.Value as Coding;
            }
        }

        public string RaceText
        {
            set
            {
                var raceExt = AddOrUpdateRaceExtension();
                raceExt.Extension.AddOrUpdateExtension(new Extension("text", new FhirString(value)));
            }
            get
            {
                var raceExt = patient.GetExtension(ExtUrl);
                return (raceExt?.GetExtension("text").Value as FhirString).ToString();
            }
        }

        private Extension AddOrUpdateRaceExtension()
        {
            var raceExt = new Extension() { Url = ExtUrl };
            return patient.Extension.AddOrUpdateExtension(raceExt);
        }

        /// <summary>
        /// http://hl7.org/fhir/us/core/ValueSet/omb-race-category
        /// </summary>
        public static class RaceCoding
        {
            /// <summary>
            /// Create coding for urn:oid:2.16.840.1.113883.6.238 or http://terminology.hl7.org/CodeSystem/v3-NullFlavor
            /// </summary>
            /// <param name="code"></param>
            /// <param name="text"></param>
            /// <returns></returns>
            public static Coding Encode(string code, string text)
            {
                string default_system = "urn:oid:2.16.840.1.113883.6.238";

                if ("ASKU".Equals(code) || "OTH".Equals(code) || "UNK".Equals(code))
                {
                    default_system = "http://terminology.hl7.org/CodeSystem/v3-NullFlavor";
                }
                return new Coding(default_system, code)
                { Display = text };
            }
        }
    }
}
