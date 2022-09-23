using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using System.Collections.Generic;
using GaTech.Chai.Mdi.Common;
using static GaTech.Chai.Mdi.Common.MdiCodeSystem;

namespace GaTech.Chai.Mdi.ObservationCauseOfDeathPart1Profile
{
    /// <summary>
    /// ObservationCauseOfDeathConditionProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-part1
    /// </summary>
    public class ObservationCauseOfDeathPart1
    {
        readonly Observation observation;
        readonly Dictionary<string, Resource> resources;

        internal ObservationCauseOfDeathPart1(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69453-9", "Cause of death [US Standard Certificate of Death]", null);

            if (resources == null) resources = new();
        }

        /// <summary>
        /// Factory for ObservationCauseOfDeathConditionProfile with initial parameters
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-condition
        /// </summary>
        public static Observation Create(Patient subjectResource, Practitioner performerResource, string conceptText, int lineNumber, string interval)
        {
            var observation = new Observation();

            observation.ObservationCauseOfDeathPart1().AddProfile();

            observation.ObservationCauseOfDeathPart1().SubjectAsResource = subjectResource;
            observation.ObservationCauseOfDeathPart1().PerformerAsResource = performerResource;

            observation.ObservationCauseOfDeathPart1().ValueText = conceptText;
            observation.ObservationCauseOfDeathPart1().LineNumber = new Integer(lineNumber);
            observation.ObservationCauseOfDeathPart1().Interval = interval;

            return observation;
        }

        /// <summary>
        /// Factory for ObservationCauseOfDeathConditionProfile with no parameters.
        /// Required parameters MUST be initiated maunally. 
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-condition
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationCauseOfDeathPart1().AddProfile();

            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationCauseOfDeathConditionProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-part1";

        /// <summary>
        /// Set profile for the ObservationCauseOfDeathConditionProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationCauseOfDeathConditionProfile
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
                if (totalTextCount != null && totalTextCount > 120)
                {
                    throw (new ArgumentException("Total size of valueCodeableConcept.Text (" + totalTextCount + ") exceeded 120"));
                }
                this.observation.Value = value;
            }
        }

        /// <summary>
        /// ValueText gets or sets valueCodeableConcept.text.
        /// </summary>
        public string ValueText
        {
            get
            {
                if (Value != null)
                {
                    return Value.Text;
                } else
                {
                    return null;
                }
            }

            set
            {
                Value = new CodeableConcept() { Text = value };
            }
        }

        /// <summary>
        /// LineNumber gets or sets the line number of cause of death part 1
        /// </summary>
        public Integer LineNumber
        {
            get
            {
                string system = MdiCodeSystem.LocalComponentCodes.LineNumber.Coding[0].System;
                string code = MdiCodeSystem.LocalComponentCodes.LineNumber.Coding[0].Code;
                return this.observation.Component?.GetComponent(system, code).Value as Integer;
            }
            set
            {
                string system = MdiCodeSystem.LocalComponentCodes.LineNumber.Coding[0].System;
                string code = MdiCodeSystem.LocalComponentCodes.LineNumber.Coding[0].Code;
                string display = LocalComponentCodes.LineNumber.Coding[0].Display;
                this.observation.Component.GetOrAddComponent(system, code, display).Value = value;
            }
        }

        /// <summary>
        /// Interval Component for Interval value as a string
        /// </summary>
        public string Interval
        {
            get
            {
                return (this.observation.Component?.GetComponent("http://loinc.org", "69440-6").Value as FhirString).ToString();
            }
            set
            {
                if (value.Length > 20)
                {
                    throw (new ArgumentException("Total string length of interval (" + value.Length + ") exceeded 20"));
                }
                this.observation.Component.GetOrAddComponent("http://loinc.org", "69440-6", "Disease onset to death interval").Value = new FhirString(value);
            }
        }

        /// <summary>
        /// Cause of Death simple read and write.
        /// value: (valueText, interval) 
        /// </summary>
        public (string, string) CauseOfDeathPart1A
        {
            get
            {
                return (ValueText, Interval);
            }
            set
            {
                ValueText = value.Item1;
                Interval = value.Item2;
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
                this.resources.TryGetValue(this.observation.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.observation.Subject = value.AsReference();
                this.resources.Add(value.AsReference().Reference, value);
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
                this.resources.TryGetValue(this.observation.Performer?[0].Reference, out value);

                return (Practitioner)value;
            }
            set
            {
                if (this.observation.Performer?.Count > 0)
                {
                    foreach (ResourceReference reference in this.observation.Performer)
                    {
                        this.resources.Remove(reference.Reference);
                    }
                    this.observation.Performer.Clear();
                }
                this.observation.Performer.Add(value.AsReference());
                this.resources.Add(value.AsReference().Reference, value);
            }
        }

        /// <summary>
        /// InvervalQuantity for Interval value as a quantity.
        /// </summary>
        [Obsolete("Removed from v1.0.0 - CI", true)]
        public Quantity IntervalQuantity
        {
            get
            {
                return this.observation.Component?.GetComponent("http://loinc.org", "69440-6").Value as Quantity;
            }
            set
            {
                this.observation.Component.GetOrAddComponent("http://loinc.org", "69440-6", "Disease onset to death interval").Value = value;
            }
        }
    }
}
