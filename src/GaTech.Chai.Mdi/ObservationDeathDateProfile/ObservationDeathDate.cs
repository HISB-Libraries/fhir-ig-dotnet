using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using System.Collections.Generic;
using GaTech.Chai.Mdi.Common;

namespace GaTech.Chai.Mdi.ObservationDeathDateProfile
{
    /// <summary>
    /// ObservationDeathDateProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
    /// </summary>
    public class ObservationDeathDate
    {
        readonly Observation observation;
        readonly static Dictionary<string, Resource> resources = new();

        internal ObservationDeathDate(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "81956-5", "Date and time of death [TimeStamp]", null);
        }

        /// <summary>
        /// Factory for ObservationDeathDateProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationDeathDate().AddProfile();

            return observation;
        }

        /// <summary>
        /// Factory for ObservationDeathDateProfile with Subject patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationDeathDate().AddProfile();
            observation.ObservationDeathDate().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for ObservationDeathDateProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date";

        /// <summary>
        /// Set profile for the ObservationDeathDateProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationDeathDateProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Date and time pronounced dead.
        /// </summary>
        public FhirDateTime DateTimePronouncedDead
        {
            get => this.observation.Component?.GetComponent("http://loinc.org", "80616-6").Value as FhirDateTime;
            set
            {
                this.observation.Component.GetOrAddComponent("http://loinc.org", "80616-6", "Date and time pronounced dead [US Standard Certificate of Death]").Value = value;
            }
        }

        /// <summary>
        /// Observation Location Extension
        /// </summary>
        public CodeableConcept PlaceOfDeath
        {
            get => (CodeableConcept)this.observation.Component?.GetComponent("http://loinc.org", "58332-8").Value;
            set
            {
                this.observation.Component.GetOrAddComponent("http://loinc.org", "58332-8", "Location of death").Value = value;
            }
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

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
