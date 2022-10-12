using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.ObservationMannerOfDeathProfile
{
    /// <summary>
    /// ObservationMannerOfDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death
    /// </summary>
    public class ObservationMannerOfDeath
    {
        readonly Observation observation;
        readonly static Dictionary<string, Resource> resources = new();

        internal ObservationMannerOfDeath(Observation observation)
        {
            this.observation = observation;
            this.observation.Status = ObservationStatus.Final;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69449-7", "Manner of death", null);
        }

        /// <summary>
        /// Factory for ObservationMannerOfDeathProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationMannerOfDeath().AddProfile();
            return observation;
        }

        /// <summary>
        /// Factory for ObservationMannerOfDeathProfile with a patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death
        /// </summary>
        public static Observation Create(Patient subject, Practitioner certifier)
        {
            var observation = new Observation();

            observation.ObservationMannerOfDeath().AddProfile();
            observation.ObservationMannerOfDeath().SubjectAsResource = subject;
            observation.ObservationMannerOfDeath().Certifier = certifier;

            return observation;
        }

        /// <summary>
        /// The official URL for ObservationMannerOfDeathProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-manner-of-death";

        /// <summary>
        /// Set profile for ObservationMannerOfDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationMannerOfDeathProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// setting subject reference and store the resource for future use
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

        /// <summary>
        /// setting subject reference and store the resource for future use
        /// </summary>
        public Practitioner Certifier
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.observation.Performer?[0].Reference, out value);

                return (Practitioner) value;
            }
            set
            {
                this.observation.Performer = new List<ResourceReference> { value.AsReference() };
            }
        }

        /// <summary>
        /// setting or getting valueCodeableConcept
        /// </summary>
        public CodeableConcept Value
        {
            get
            {
                return this.observation.Value as CodeableConcept;
            }
            set
            {
                this.observation.Value = value;
            }
        }

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
