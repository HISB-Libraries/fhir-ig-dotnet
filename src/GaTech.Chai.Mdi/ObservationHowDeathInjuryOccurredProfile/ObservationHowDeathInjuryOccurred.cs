using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.Common;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.ObservationHowDeathInjuryOccurredProfile
{
    /// <summary>
    /// ObservationHowDeathInjuryOccurredProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred
    /// </summary>
    public class ObservationHowDeathInjuryOccurred
    {
        readonly Observation observation;
        readonly static Dictionary<string, Resource> resources = new();

        internal ObservationHowDeathInjuryOccurred(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "11374-6", "Injury incident description Narrative", null);
        }

        /// <summary>
        /// Factory for ObservationHowDeathInjuryOccurredProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationHowDeathInjuryOccurred().AddProfile();

            return observation;
        }

        /// <summary>
        /// Factory for ObservationHowDeathInjuryOccurredProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationHowDeathInjuryOccurred().AddProfile();
            observation.ObservationHowDeathInjuryOccurred().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationHowDeathInjuryOccurredProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-how-death-injury-occurred";

        /// <summary>
        /// Set profile for ObservationHowDeathInjuryOccurredProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationHowDeathInjuryOccurredProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Partial DateTime Extension
        /// value should be (year, month, day, time)
        /// </summary>
        public (DataType /* year */, DataType /* month */, DataType /* day */, DataType) PartialDateTime
        {
            get
            {
                Extension partialDateTimeExt = this.observation.GetPartialDateTime();
                UnsignedInt year = (UnsignedInt)partialDateTimeExt.GetExtension(MdiUrls.partialDateTimeYearUrl).Value;
                UnsignedInt month = (UnsignedInt)partialDateTimeExt.GetExtension(MdiUrls.partialDateTimeMonthUrl).Value;
                UnsignedInt day = (UnsignedInt)partialDateTimeExt.GetExtension(MdiUrls.partialDateTimeDayUrl).Value;
                Time time = (Time)partialDateTimeExt.GetExtension(MdiUrls.partialDateTimeTimeUrl).Value;

                return (year, month, day, time);
            }
            set
            {
                this.observation.SetPartialDateTime(value.Item1, value.Item2, value.Item3, value.Item4);
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
        /// setting or getting text value of how death injury occurred
        /// </summary>
        public string HowInjuredDescription
        {
            get
            {
                CodeableConcept valueCodeableConcept = (CodeableConcept) this.observation.Value;
                return valueCodeableConcept.Text;
            }

            set
            {
                this.observation.Value = new CodeableConcept() { Text = value };
            }
        }

        /// <summary>
        /// setting or getting placeOfInjury component value
        /// </summary>
        public DataType PlaceOfInjury
        {
            get
            {
                Observation.ComponentComponent placeOfInjuryComponent = this.observation.Component.GetComponent("http://loinc.org", "69450-5");
                return placeOfInjuryComponent?.Value;
            }

            set
            {
                Observation.ComponentComponent placeOfInjuryComponent = this.observation.Component.GetOrAddComponent("http://loinc.org", "69450-5", "");
                placeOfInjuryComponent.Value = value;
            }
        }

        /// <summary>
        /// setting or getting workInjuryIndicator component value
        /// </summary>
        public CodeableConcept WorkInjuryIndicator
        {
            get
            {
                Observation.ComponentComponent workInjuryIndicator = this.observation.Component.GetComponent("http://loinc.org", "69444-8");
                return workInjuryIndicator?.Value as CodeableConcept;
            }

            set
            {
                Observation.ComponentComponent workInjuryIndicator = this.observation.Component.GetOrAddComponent("http://loinc.org", "69444-8", "");
                workInjuryIndicator.Value = value;
            }
        }

        /// <summary>
        /// setting or getting transportationRole component value
        /// </summary>
        public (CodeableConcept, string) TransportationRole
        {
            get
            {
                Observation.ComponentComponent transportationRole = this.observation.Component.GetComponent("http://loinc.org", "69451-3");
                CodeableConcept retValue = transportationRole?.Value as CodeableConcept;
                return (retValue, retValue?.Text);
            }

            set
            {
                Observation.ComponentComponent transportationRole = this.observation.Component.GetOrAddComponent("http://loinc.org", "69451-3", "");
                transportationRole.Value = value.Item1;
                if (MdiVsTransportationIncidentRole.OTH.Matches(value.Item1))
                {
                    (transportationRole.Value as CodeableConcept).Text = value.Item2;
                }
            }
        }

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
