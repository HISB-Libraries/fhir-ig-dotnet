using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// VrdrDeathDateProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
    /// </summary>
    public class VrdrDeathDate
    {
        readonly Observation observation;

        internal VrdrDeathDate(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for VrdrDeathDateProfile
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-date
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.VrdrDeathDate().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "81956-5", "Date and time of death [TimeStamp]", null);

            return observation;
        }

        /// <summary>
        /// Factory for VrdrDeathDateProfile with Subject patient
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-date
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.VrdrDeathDate().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "81956-5", "Date and time of death [TimeStamp]", null);
            observation.VrdrDeathDate().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for VrdrDeathDateProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-date";

        /// <summary>
        /// Set profile for the VrdrDeathDateProfile
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
        public DataType DateTimePronouncedDead
        {
            get => this.observation.Component?.GetComponent("http://loinc.org", "80616-6").Value;
            set
            {
                if (value is Time || value is FhirDateTime)
                {
                    this.observation.Component.GetOrAddComponent("http://loinc.org", "80616-6", "Date and time pronounced dead [US Standard Certificate of Death]").Value = value;
                } else
                {
                    throw new ArgumentException("DateTimePronouncedDead must be either Time or FhirDateTime");
                }
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
        public (DataType /* year */, DataType /* month */, DataType /* day */, DataType /* time */) PartialDateTime
        {
            get
            {
                Extension partialDateTimeExt = this.observation.GetPartialDateTime();
                UnsignedInt year = (UnsignedInt)partialDateTimeExt.GetExtension(VrdrUrls.partialDateTimeYearUrl).Value;
                UnsignedInt month = (UnsignedInt)partialDateTimeExt.GetExtension(VrdrUrls.partialDateTimeMonthUrl).Value;
                UnsignedInt day = (UnsignedInt)partialDateTimeExt.GetExtension(VrdrUrls.partialDateTimeDayUrl).Value;
                Time time = (Time)partialDateTimeExt.GetExtension(VrdrUrls.partialDateTimeTimeUrl).Value;

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
                Record.GetResources().TryGetValue(this.observation.Subject.Reference, out Resource value);

                return (Patient)value;
            }
            set
            {
                this.observation.Subject = value.AsReference();
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }
    }
}
