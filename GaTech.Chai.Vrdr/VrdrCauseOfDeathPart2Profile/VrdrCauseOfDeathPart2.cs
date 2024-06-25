using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// VrdrCauseOfDeathPart2Profile
    /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-cause-of-death-part2
    /// </summary>
    public class VrdrCauseOfDeathPart2
    {
        readonly Observation observation;

        internal VrdrCauseOfDeathPart2(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for VrdrCauseOfDeathPart2Profile with inital parameters
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-cause-of-death-part2
        /// </summary>
        public static Observation Create(Patient subjectResource, Practitioner performerResource)
        {
            var observation = new Observation();

            observation.VrdrCauseOfDeathPart2().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "69441-4", "Other significant causes or conditions of death", null);

            observation.VrdrCauseOfDeathPart2().SubjectAsResource = subjectResource;
            if (performerResource != null)
            {
                observation.VrdrCauseOfDeathPart2().PerformerAsResource = performerResource;
            }

            return observation;
        }

        /// <summary>
        /// Factory for VrdrCauseOfDeathPart2Profile
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-cause-of-death-part2
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.VrdrCauseOfDeathPart2().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "69441-4", "Other significant causes or conditions of death", null);

            return observation;
        }

        /// <summary>
        /// The official URL for the VrdrCauseOfDeathPart2Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-cause-of-death-part2";

        /// <summary>
        /// Set profile for the ObservationConditionContributingToDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the VrdrCauseOfDeathPart2Profile
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

        public string ValueText
        {
            get => (this.observation.Value as CodeableConcept).Text;
            set
            {
                if (value.Length > 240)
                {
                    throw (new ArgumentException("Total size of valueString (" + value.Length + ") exceeded 240"));
                }
                this.observation.Value = new CodeableConcept() {Text = value};
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
                Record.GetResources().TryGetValue(this.observation.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.observation.Subject = value.AsReference();
                Record.GetResources()[value.AsReference().Reference] = value;
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
                Record.GetResources().TryGetValue(this.observation.Performer?[0].Reference, out value);

                return (Practitioner) value;
            }
            set
            {
                if (this.observation.Performer?.Count > 0)
                {
                    foreach (ResourceReference reference in this.observation.Performer)
                    {
                        Record.GetResources().Remove(reference.Reference);
                    }
                    this.observation.Performer.Clear();
                }
                this.observation.Performer.Add(value.AsReference());
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }
    }
}
