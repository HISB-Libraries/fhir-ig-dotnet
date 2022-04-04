using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.SpecimenToxicologyLabProfile
{
    /// <summary>
    /// SpecimenToxicologyLabProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Specimen-toxicology-lab
    /// </summary>
    public class SpecimenToxicologyLab
    {
        readonly Specimen specimen;

        internal SpecimenToxicologyLab(Specimen specimen)
        {
            this.specimen = specimen;
        }

        /// <summary>
        /// Factory for SpecimenToxicologyLabProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Specimen-toxicology-lab
        /// </summary>
        public static Specimen Create()
        {
            var specimen = new Specimen();
            specimen.SpecimenToxicologyLab().AddProfile();
            return specimen;
        }

        /// <summary>
        /// The official URL for the SpecimenToxicologyLabProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Specimen-toxicology-lab";

        /// <summary>
        /// Set profile for SpecimenToxicologyLabProfile
        /// </summary>
        public void AddProfile()
        {
            specimen.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for SpecimenToxicologyLabProfile
        /// </summary>
        public void RemoveProfile()
        {
            specimen.RemoveProfile(ProfileUrl);
        }
    }
}