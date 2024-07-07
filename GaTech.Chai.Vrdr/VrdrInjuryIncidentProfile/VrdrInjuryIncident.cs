using GaTech.Chai.Share;
using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// VrdrInjuryIncidentProfile
    /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-injury-incident
    /// </summary>
    public class VrdrInjuryIncident
    {
        readonly Observation observation;

        internal VrdrInjuryIncident(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for VrdrInjuryIncidentProfile
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-injury-incident
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.VrdrInjuryIncident().AddProfile();
            observation.VrdrInjuryIncident().AddFixedValues();

            return observation;
        }

        /// <summary>
        /// Factory for VrdrInjuryIncidentProfile
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-injury-incident
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.VrdrInjuryIncident().AddProfile();
            observation.VrdrInjuryIncident().AddFixedValues();
            observation.VrdrInjuryIncident().SubjectAsResource = subject;

            return observation;
        }

        public void AddFixedValues() {
            observation.Code = VrdrCs.InjuryIncident;
        }

        /// <summary>
        /// The official URL for the VrdrInjuryIncidentProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-injury-incident";

        /// <summary>
        /// Set profile for VrdrInjuryIncidentProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for VrdrInjuryIncidentProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
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
                Observation.ComponentComponent placeOfInjuryComponent 
                    = this.observation.Component.GetComponent(VrdrInjuryIncidentComponentsCs.PlaceOfInjury.Coding[0].System, VrdrInjuryIncidentComponentsCs.PlaceOfInjury.Coding[0].Code);
                return placeOfInjuryComponent?.Value;
            }

            set
            {
                Observation.ComponentComponent placeOfInjuryComponent 
                    = this.observation.Component.GetOrAddComponent(VrdrInjuryIncidentComponentsCs.PlaceOfInjury.Coding[0].System, VrdrInjuryIncidentComponentsCs.PlaceOfInjury.Coding[0].Code, null);
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
                Observation.ComponentComponent workInjuryIndicator = 
                    this.observation.Component.GetComponent(VrdrInjuryIncidentComponentsCs.WorkInjuryIndicator.Coding[0].System, VrdrInjuryIncidentComponentsCs.WorkInjuryIndicator.Coding[0].Code);
                return workInjuryIndicator?.Value as CodeableConcept;
            }

            set
            {
                Observation.ComponentComponent workInjuryIndicator = 
                    this.observation.Component.GetOrAddComponent(VrdrInjuryIncidentComponentsCs.WorkInjuryIndicator.Coding[0].System, VrdrInjuryIncidentComponentsCs.WorkInjuryIndicator.Coding[0].Code, null);
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
                Observation.ComponentComponent transportationRole = this.observation.Component.GetComponent(VrdrInjuryIncidentComponentsCs.TransportationRole.Coding[0].System, VrdrInjuryIncidentComponentsCs.TransportationRole.Coding[0].Code);
                CodeableConcept retValue = transportationRole?.Value as CodeableConcept;
                return (retValue, retValue?.Text);
            }

            set
            {
                Observation.ComponentComponent transportationRole = this.observation.Component.GetOrAddComponent(VrdrInjuryIncidentComponentsCs.TransportationRole.Coding[0].System, VrdrInjuryIncidentComponentsCs.TransportationRole.Coding[0].Code, null);
                transportationRole.Value = value.Item1;
                if (VrdrTransportationIncidentRoleVs.Other.Matches(value.Item1))
                {
                    (transportationRole.Value as CodeableConcept).Text = value.Item2;
                }
            }
        }

        public Practitioner Certifier
        {
            get
            {
                Record.GetResources().TryGetValue(this.observation.Performer?[0].Reference, out Resource value);
                return (Practitioner)value;
            }
            set
            {
                this.observation.Performer = new List<ResourceReference> { value.AsReference() };
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }
    }
}
