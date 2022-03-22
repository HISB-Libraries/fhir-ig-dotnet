using System;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.PatientProfile
{
    public class UsPublicHealthTribalAffiliation
    {
        readonly Patient patient;

        internal UsPublicHealthTribalAffiliation(Patient patient)
        {
            this.patient = patient;
        }

        public const string ExtUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-tribal-affiliation-extension";

        public Coding TribeName
        {
            set
            {
                var tribeExt = AddOrUpdateTribeExtension();
                tribeExt.Extension.AddOrUpdateExtension(new Extension("TribeName", value));
            }
            get
            {
                var tribeExt = patient.GetExtension("http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-tribal-affiliation-extension");
                return tribeExt?.GetExtension("TribeName").Value as Coding;
            }
        }

        public FhirBoolean EnrolledTribeMember
        {
            set
            {
                var enrolledTribeExt = AddOrUpdateTribeExtension();
                enrolledTribeExt.Extension.AddOrUpdateExtension(new Extension("EnrolledTribeMember", value));
            }
            get
            {
                var enrolledTribeExt = patient.GetExtension("http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-tribal-affiliation-extension");
                return enrolledTribeExt?.GetExtension("EnrolledTribeMember").Value as FhirBoolean;
            }
        }

        private Extension AddOrUpdateTribeExtension()
        {
            var raceExt = new Extension() { Url = ExtUrl };
            return patient.Extension.AddOrUpdateExtension(raceExt);
        }

        /// <summary>
        /// TribalEntityUS ValueSet
        /// </summary>
        public static class TribalEntityUS
        {
            public const string tribalEntityUsSystem = "http://terminology.hl7.org/CodeSystem/v3-TribalEntityUS";
            public static Coding Encode(string value, string display) => new Coding(tribalEntityUsSystem, value, display);
        }

    }
}
