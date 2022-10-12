using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.ObservationDecedentPregnancyProfile
{
    /// <summary>
    /// ObservationDecedentPregnancyProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy
    /// </summary>
    public class ObservationDecedentPregnancy
    {
        readonly Observation observation;
        readonly static Dictionary<string, Resource> resources = new();

        internal ObservationDecedentPregnancy(Observation observation)
        {
            this.observation = observation;
            this.observation.Status = ObservationStatus.Final;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69442-2", "Timing of recent pregnancy in relation to death", null);
        }

        /// <summary>
        /// Factory for ObservationDecedentPregnancyProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();

            observation.ObservationDecedentPregnancy().AddProfile();
            return observation;
        }

        /// <summary>
        /// Factory for ObservationDecedentPregnancyProfile with Subject
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationDecedentPregnancy().AddProfile();
            observation.ObservationDecedentPregnancy().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationDecedentPregnancyProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy";

        /// <summary>
        /// Set profile for ObservationDecedentPregnancyProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationDecedentPregnancyProfile
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
