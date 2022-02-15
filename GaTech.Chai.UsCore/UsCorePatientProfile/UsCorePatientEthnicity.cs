﻿using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.UsCorePatientProfile
{
    public class UsCorePatientEthnicity
    {
        readonly Patient patient;

        internal UsCorePatientEthnicity(Patient patient)
        {
            this.patient = patient;
        }

        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-ethnicity";

        public Coding Category
        {
            set
            {
                var ethnicityExt = AddOrUpdateEthnicityExtension();
                ethnicityExt.Extension.AddOrUpdateExtension(new Extension("ombCategory", value));
            }
            get
            {
                var ethnicityExt = patient.GetExtension("http://hl7.org/fhir/us/core/StructureDefinition/us-core-ethnicity");
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
                var ethnicityExt = patient.GetExtension("http://hl7.org/fhir/us/core/StructureDefinition/us-core-ethnicity");
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
                var ethnicityExt = patient.GetExtension("http://hl7.org/fhir/us/core/StructureDefinition/us-core-ethnicity");
                return (ethnicityExt?.GetExtension("text").Value as FhirString).ToString();
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
            /// Create coding for http://hl7.org/fhir/us/core/ValueSet/omb-ethnicity-category
            /// </summary>
            /// <param name="code"></param>
            /// <param name="text"></param>
            /// <returns></returns>
            public static Coding Encode(string code, string text)
            {
                return new Coding("urn:oid:2.16.840.1.113883.6.238", code)
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