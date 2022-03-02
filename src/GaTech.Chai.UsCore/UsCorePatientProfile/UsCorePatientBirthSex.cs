using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.UsCorePatientProfile
{
    public class UsCorePatientBirthSex
    {
        readonly Patient patient;

        internal UsCorePatientBirthSex(Patient patient)
        {
            this.patient = patient;
        }

        public const string ExtUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-birthsex";

        public Code Extension
        {
            set
            {
                var bithSexExt = AddOrUpdateBirthSexExtension();
                bithSexExt.Value = value as Code;
            }
            get
            {
                var bithSexExt = patient.GetExtension(ExtUrl);
                return bithSexExt?.Value as Code;
            }
        }

        private Extension AddOrUpdateBirthSexExtension()
        {
            var birthSExExt = new Extension() { Url = ExtUrl };
            return patient.Extension.AddOrUpdateExtension(birthSExExt);
        }

        /// <summary>
        /// http://hl7.org/fhir/us/core/ValueSet/birthsex
        /// </summary>
        public static class BirthSexValueSet
        {
            /// <summary>
            /// Create coding for http://terminology.hl7.org/CodeSystem/v3-AdministrativeGender
            /// or http://terminology.hl7.org/CodeSystem/v3-NullFlavor
            /// </summary>
            /// <param name="code"></param>
            /// <param name="text"></param>
            /// <returns></returns>
            public static Coding Encode(string code, string text)
            {
                return new Coding("http://terminology.hl7.org/CodeSystem/v3-AdministrativeGender", code)
                { Display = text };
            }

            public static Coding EncodeUnks(string code, string text)
            {
                return new Coding("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", code)
                { Display = text };
            }
        }
    }
}
