using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.PatientProfile
{
    /// <summary>
    /// US Core Patient Ethnicity Extension Helper
    /// </summary>
    public class UsCorePatientEthnicity
    {
        readonly Patient patient;

        internal UsCorePatientEthnicity(Patient patient)
        {
            this.patient = patient;
        }

        public const string ExtUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-ethnicity";

        public Coding Category
        {
            set
            {
                var ethnicityExt = AddOrUpdateEthnicityExtension();
                ethnicityExt.Extension.AddOrUpdateExtension(new Extension("ombCategory", value));
            }
            get
            {
                var ethnicityExt = patient.GetExtension(ExtUrl);
                return ethnicityExt?.GetExtension("ombCategory").Value as Coding;
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
                var ethnicityExt = patient.GetExtension(ExtUrl);
                if (ethnicityExt == null)
                    return Array.Empty<Coding>();
                return from r in ethnicityExt.Extension
                       where r.Url == "detailed"
                       select r.Value as Coding;
            }
        }

        public string EthnicityText
        {
            set
            {
                var ethnicityExt = AddOrUpdateEthnicityExtension();
                ethnicityExt.Extension.AddOrUpdateExtension(new Extension("text", new FhirString(value)));
            }
            get
            {
                var ethnicityExt = patient.GetExtension(ExtUrl);
                return (ethnicityExt?.GetExtension("text").Value as FhirString).ToString();
            }
        }

        private Extension AddOrUpdateEthnicityExtension()
        {
            var ethnicityExt = new Extension() { Url = ExtUrl };
            return patient.Extension.AddOrUpdateExtension(ethnicityExt);
        }

        /// <summary>
        /// Detailed coding of Ethnicity
        /// </summary>
        public static class EthnicityCoding
        {
            /// <summary>
            /// Create coding for ombCategory
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
