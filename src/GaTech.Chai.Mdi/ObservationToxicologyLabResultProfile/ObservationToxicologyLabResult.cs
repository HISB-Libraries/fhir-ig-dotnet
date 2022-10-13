using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.UsCore.LabResultObservationProfile;
using System.Collections.Generic;
using GaTech.Chai.Share.Common;

namespace GaTech.Chai.Mdi.ObservationToxicologyLabResultProfile
{
    /// <summary>
    /// ObservationToxicologyLabResultProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result
    /// </summary>
    public class ObservationToxicologyLabResult
    {
        readonly Observation observation;
        readonly static Dictionary<string, Resource> resources = new();

        internal ObservationToxicologyLabResult(Observation observation)
        {
            this.observation = observation;
            this.observation.Category.SetCategory(CodeSystems.ObservationCategory.Laboratory);
        }

        /// <summary>
        /// Factory for ObservationToxicologyLabResultProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationToxicologyLabResult().AddProfile();
            return observation;
        }

        /// <summary>
        /// Factory for ObservationToxicologyLabResultProfile with Code Text and valueText
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result
        /// </summary>
        public static Observation Create(ObservationStatus status, string codeText, Patient subject)
        {
            var observation = new Observation();

            observation.ObservationToxicologyLabResult().AddProfile();
            observation.Status = status;
            if (codeText != null) observation.ObservationToxicologyLabResult().CodeText = codeText;
            observation.ObservationToxicologyLabResult().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationToxicologyLabResultProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-toxicology-lab-result";

        /// <summary>
        /// Set profile for ObservationToxicologyLabResultProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationToxicologyLabResultProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }

        public string CodeText
        {
            get
            {
                return this.observation.Code?.Text;
            }
            set
            {
                this.observation.Code = new CodeableConcept { Text = value };
            }
        }

        /// <summary>
        /// Get and Set subject as Patient
        /// </summary>
        public Patient SubjectAsResource
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.observation.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.observation.Subject = value.AsReference();
                resources[value.AsReference().Reference] = value;
            }
        }

        public string ValueText
        {
            get
            {
                FhirString valueString = this.observation.Value as FhirString;
                if (valueString != null)
                {
                    return valueString.Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.observation.Value = new FhirString(value);
            }
        }

        public Specimen Specimen
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.observation.Specimen?.Reference, out value);

                return (Specimen)value;
            }
            set
            {
                this.observation.Specimen = value.AsReference();
                resources[value.AsReference().Reference] = value;
            }

        }
        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
