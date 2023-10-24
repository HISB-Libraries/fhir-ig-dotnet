using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.ObservationContributingCauseOfDeathPart2Profile
{
    /// <summary>
    /// ObservationContributingCauseOfDeathPart2Profile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-contributing-cause-of-death-part2
    /// </summary>
    public class ObservationContributingCauseOfDeathPart2
    {
        readonly Observation observation;
        readonly static Dictionary<string, Resource> resources = new();

        internal ObservationContributingCauseOfDeathPart2(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69441-4", "Other significant causes or conditions of death", null);
        }

        /// <summary>
        /// Factory for ObservationContributingCauseOfDeathPart2Profile with inital parameters
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-contributing-cause-of-death-part2
        /// </summary>
        public static Observation Create(Patient subjectResource, Practitioner performerResource)
        {
            // clear static resource container.
            resources.Clear();

            var observation = new Observation();

            observation.ObservationContributingCauseOfDeathPart2().AddProfile();

            observation.ObservationContributingCauseOfDeathPart2().SubjectAsResource = subjectResource;
            if (performerResource != null)
            {
                observation.ObservationContributingCauseOfDeathPart2().PerformerAsResource = performerResource;
            }

            return observation;
        }

        /// <summary>
        /// Factory for ObservationContributingCauseOfDeathPart2Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-contributing-cause-of-death-part2
        /// </summary>
        public static Observation Create()
        {
            // clear static resource container.
            resources.Clear();

            var observation = new Observation();
            observation.ObservationContributingCauseOfDeathPart2().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationContributingCauseOfDeathPart2Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-contributing-cause-of-death-part2";

        /// <summary>
        /// Set profile for the ObservationConditionContributingToDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationContributingCauseOfDeathPart2Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// valueCodeableConcept property. Setter checks the length of Text.
        /// </summary>
        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set
            {
                int? totalTextCount = value.Text?.Length;
                if (totalTextCount != null && totalTextCount > 240)
                {
                    throw (new ArgumentException("Total size of valueCodeableConcept.Text (" + totalTextCount + ") exceeded 240"));
                }
                this.observation.Value = value;
            }
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
        /// adding performer (C/ME)
        /// </summary>
        public Practitioner PerformerAsResource
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.observation.Performer?[0].Reference, out value);

                return (Practitioner) value;
            }
            set
            {
                if (this.observation.Performer?.Count > 0)
                {
                    foreach (ResourceReference reference in this.observation.Performer)
                    {
                        resources.Remove(reference.Reference);
                    }
                    this.observation.Performer.Clear();
                }
                this.observation.Performer.Add(value.AsReference());
                resources[value.AsReference().Reference] = value;
            }
        }

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
