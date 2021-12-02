using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    public class CbsPatientRace
    {
        readonly Patient patient;

        internal CbsPatientRace(Patient patient)
        {
            this.patient = patient;
        }

        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-race";

        public Coding Category
        {
            set
            {
                var raceExt = AddOrUpdateRaceExtension();
                raceExt.Extension.AddOrUpdateExtension(new Extension("ombCategory", value));
            }
            get
            {
                var raceExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-race");
                return raceExt?.GetExtension("ombCategory").Value as Coding;
            }
        }

        public string Description
        {
            set
            {
                var raceExt = AddOrUpdateRaceExtension();
                raceExt.Extension.AddOrUpdateExtension(new Extension("text", new FhirString(value)));
            }
            get
            {
                var raceExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-race");
                return (raceExt?.GetExtension("text").Value as FhirString).ToString();
            }
        }

        public string Other
        {
            set
            {
                var raceExt = AddOrUpdateRaceExtension();
                raceExt.Extension.AddOrUpdateExtension(new Extension("other", new FhirString(value)));
            }
            get
            {
                var raceExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-race");
                return (raceExt?.GetExtension("other").Value as FhirString).ToString();
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
                var raceExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-race");
                if (raceExt == null)
                    return Array.Empty<Coding>();
                return from r in raceExt.Extension
                       where r.Url == "detailed"
                       select r.Value as Coding;
            }
        }


        private Extension AddOrUpdateRaceExtension()
        {
            var raceExt = new Extension() { Url = ProfileUrl };
            patient.Extension.AddOrUpdateExtension(raceExt);
            return raceExt;
        }

        /// <summary>
        /// http://terminology.hl7.org/CodeSystem/v2-0005
        /// </summary>
        public static class RaceCategory
        {
            /// <summary>
            /// Create coding for http://terminology.hl7.org/CodeSystem/v2-0005
            /// </summary>
            /// <param name="code"></param>
            /// <param name="text"></param>
            /// <returns></returns>
            public static Coding Encode(string code, string text)
            {
                return new Coding("http://terminology.hl7.org/CodeSystem/v2-0005", code)
                { Display = text };
            }
        }

        /// <summary>
        /// https://build.fhir.org/ig/HL7/US-Core//ValueSet-detailed-race.html
        /// </summary>
        public static class DetailedRace
        {
            /// <summary>
            /// Create coding for https://build.fhir.org/ig/HL7/US-Core//ValueSet-detailed-race.html
            /// </summary>
            /// <param name="code"></param>
            /// <param name="text"></param>
            /// <returns></returns>
            public static Coding Encode(string code, string text)
            {
                return new Coding("urn:oid:2.16.840.1.113883.6.238", code) { Display = text };
            }
        }
    }
}
