using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Resources;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.SpecimenToxicologyLabProfile
{
    /// <summary>
    /// SpecimenToxicologyLabProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Specimen-toxicology-lab
    /// </summary>
    public class SpecimenToxicologyLab
    {
        readonly Specimen specimen;
        readonly static Dictionary<string, Resource> resources = new();

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
            // clear static resource container.
            resources.Clear();

            var specimen = new Specimen();
            specimen.SpecimenToxicologyLab().AddProfile();
            return specimen;
        }

        /// <summary>
        /// Factory for SpecimenToxicologyLabProfile with type and subject
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Specimen-toxicology-lab
        /// </summary>
        public static Specimen Create(string typeText, Patient subject)
        {
            // clear static resource container.
            resources.Clear();

            var specimen = new Specimen();

            specimen.SpecimenToxicologyLab().AddProfile();
            specimen.SpecimenToxicologyLab().SubjectAsResource = subject;
            specimen.SpecimenToxicologyLab().SpecimenTypeText = typeText;

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

        /// <summary>
        /// Get and Set subject as Patient
        /// </summary>
        public Patient SubjectAsResource
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.specimen.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.specimen.Subject = value.AsReference();
                resources[value.AsReference().Reference] = value;
            }
        }

        /// <summary>
        /// setting or getting of SpecimenTypeText
        /// </summary>
        public string SpecimenTypeText
        {
            get
            {
                return this.specimen.Type?.Text;
            }
            set
            {
                this.specimen.Type = new CodeableConcept { Text = value };
            }
        }

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}