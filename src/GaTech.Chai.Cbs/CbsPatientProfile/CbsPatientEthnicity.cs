using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    public class CbsPatientEthnicity
    {
        readonly Patient patient;

        internal CbsPatientEthnicity(Patient patient)
        {
            this.patient = patient;
        }

        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-ethnicity";

        public Coding Category
        {
            set
            {
                var ethnicityExt = AddOrUpdateEthnicityExtension();
                ethnicityExt.Extension.AddOrUpdateExtension(new Extension("ombCategory", value));
            }
            get
            {
                var ethnicityExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-ethnicity");
                return ethnicityExt?.GetExtension("ombCategory").Value as Coding;
            }
        }

        public string Description
        {
            set
            {
                var ethnicityExt = AddOrUpdateEthnicityExtension();
                ethnicityExt.Extension.AddOrUpdateExtension(new Extension("text", new FhirString(value)));
            }
            get
            {
                var ethnicityExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-ethnicity");
                return (ethnicityExt?.GetExtension("text").Value as FhirString).ToString();
            }
        }

        public string Other
        {
            set
            {
                var ethnicityExt = AddOrUpdateEthnicityExtension();
                ethnicityExt.Extension.AddOrUpdateExtension(new Extension("other", new FhirString(value)));
            }
            get
            {
                var ethnicityExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-ethnicity");
                return (ethnicityExt?.GetExtension("other").Value as FhirString).ToString();
            }
        }

        public IEnumerable<Coding> ExtendedEthnicityCodes
        {
            set
            {
                var ethnicityExt = AddOrUpdateEthnicityExtension();
                ethnicityExt.Extension.RemoveAll(r => r.Url == "detailed");
                ethnicityExt.Extension.AddRange(
                    from extCode in value
                    select new Extension("detailed", extCode));
            }
            get
            {
                var ethnicityExt = patient.GetExtension("http://cbsig.chai.gatech.edu/StructureDefinition/cbs-ethnicity");
                if (ethnicityExt == null)
                    return Array.Empty<Coding>();
                return from r in ethnicityExt.Extension
                       where r.Url == "detailed"
                       select r.Value as Coding;
            }
        }


        private Extension AddOrUpdateEthnicityExtension()
        {
            var ethnicityExt = new Extension() { Url = ProfileUrl };
            return patient.Extension.AddOrUpdateExtension(ethnicityExt);
        }

        /// <summary>
        /// http://terminology.hl7.org/CodeSystem/v2-0005
        /// </summary>
        public static class EthnicityCategory
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
        /// https://build.fhir.org/ig/HL7/US-Core/ValueSet-detailed-ethnicity.html
        /// </summary>
        public static class DetailedEthnicity
        {
            /// <summary>
            /// Create coding for https://build.fhir.org/ig/HL7/US-Core/ValueSet-detailed-ethnicity.html
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
