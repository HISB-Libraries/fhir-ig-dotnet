using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;
using GaTech.Chai.Vrdr;

namespace GaTech.Chai.Mdi
{
    public class VrdrCauseOfDeathPart1
    {
        readonly Observation observation;

        internal VrdrCauseOfDeathPart1(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ObservationMdiCauseOfDeathPart1 with initial parameters
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-mdi-cause-of-death-part1
        /// </summary>
        public static Observation Create(Patient subjectResource, Practitioner performerResource, string conceptText, int lineNumber, string interval)
        {
            var observation = new Observation();

            observation.VrdrCauseOfDeathPart1().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.Code = VrdrCs.CauseOfDeath;

            observation.VrdrCauseOfDeathPart1().SubjectAsResource = subjectResource;
            observation.VrdrCauseOfDeathPart1().PerformerAsResource = performerResource;

            observation.VrdrCauseOfDeathPart1().ValueText = conceptText;
            observation.VrdrCauseOfDeathPart1().LineNumber = new Integer(lineNumber);
            observation.VrdrCauseOfDeathPart1().Interval = interval;

            return observation;
        }

        /// <summary>
        /// Factory for ObservationCauseOfDeathConditionProfile with a subject.
        /// Required parameters MUST be initiated maunally. 
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-condition
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.VrdrCauseOfDeathPart1().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.Code = VrdrCs.CauseOfDeath;
            observation.VrdrCauseOfDeathPart1().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// Factory for ObservationCauseOfDeathConditionProfile with no parameters.
        /// Required parameters MUST be initiated maunally. 
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-mdi-cause-of-death-part1
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.VrdrCauseOfDeathPart1().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.Code = VrdrCs.CauseOfDeath;

            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationMdiCauseOfDeathPart1Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-cause-of-death-part1";

        /// <summary>
        /// Set profile for the ObservationMdiCauseOfDeathPart1Profile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationMdiCauseOfDeathPart1Profile
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
                int? totalTextCount = value?.Length;
                if (totalTextCount != null && totalTextCount > 120)
                {
                    throw (new ArgumentException("Total size of valueCodeableConcept.Text (" + totalTextCount + ") exceeded 120"));
                }
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
                string system = VrdrComponentCs.LineNumber.Coding[0].System;
                string code = VrdrComponentCs.LineNumber.Coding[0].Code;
                return this.observation.Component?.GetComponent(system, code).Value as Integer;
            }
            set
            {
                string system = VrdrComponentCs.LineNumber.Coding[0].System;
                string code = VrdrComponentCs.LineNumber.Coding[0].Code;
                string display = VrdrComponentCs.LineNumber.Coding[0].Display;
                this.observation.Component.GetOrAddComponent(system, code, display).Value = value;
            }
        }

        /// <summary>
        /// Interval Component for Interval value as its orignal type, string, quanity, or codeableconcept.
        /// </summary>
        public Object Interval
        {
            get
            {
                DataType intervalValue = this.observation.Component?.GetComponent(UriString.LOINC, "69440-6").Value;
                if (intervalValue is FhirString intervalValueString)
                {
                    return intervalValueString.ToString();
                }
                else if (intervalValue is Quantity intervalQty)
                {
                    return intervalQty;
                }
                return (CodeableConcept) intervalValue;
            }
            set
            {
                if (value is FhirString valueFhirString)
                {
                    if (valueFhirString.ToString().Length > 20)
                    {
                        throw (new ArgumentException("Total string length of interval (" + valueFhirString.ToString().Length + ") exceeded 20"));
                    }

                    this.observation.Component.GetOrAddComponent(UriString.LOINC, "69440-6", "Disease onset to death interval").Value = valueFhirString;
                }
                else if (value is string valueString)
                {
                    if (valueString.Length > 20)
                    {
                        throw (new ArgumentException("Total string length of interval (" + valueString.Length + ") exceeded 20"));
                    }
                    this.observation.Component.GetOrAddComponent(UriString.LOINC, "69440-6", "Disease onset to death interval").Value = new FhirString(valueString);
                }
                else if (value is Quantity valueQty)
                {
                    this.observation.Component.GetOrAddComponent(UriString.LOINC, "69440-6", "Disease onset to death interval").Value = valueQty;
                }
                else
                {
                    this.observation.Component.GetOrAddComponent(UriString.LOINC, "69440-6", "Disease onset to death interval").Value = (CodeableConcept) value;
                }
            }
        }

        /// <summary>
        /// Interval Component for Interval value as string. Qty or CodeableConcept will be converted to string.
        /// </summary>
        public string IntervalAsString
        {
            get
            {
                DataType intervalValue = this.observation.Component?.GetComponent(UriString.LOINC, "69440-6").Value;
                if (intervalValue is FhirString intervalValueString)
                {
                    return intervalValueString.ToString();
                }
                else if (intervalValue is Quantity intervalQty)
                {
                    return intervalQty.Value + intervalQty.Code;
                }
                return ((CodeableConcept) intervalValue).Coding[0].Code;
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

                return (Practitioner)value;
            }
            set
            {
                if (this.observation.Performer?.Count > 0)
                {
                    this.observation.Performer.Clear();
                }
                this.observation.Performer.Add(value.AsReference());
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }
    }
}
