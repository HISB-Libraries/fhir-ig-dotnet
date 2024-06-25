using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// MannerOfDeathProfile
    /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-manner-of-death
    /// </summary>
    public class VrdrMannerOfDeath
    {
        readonly Observation observation;

        internal VrdrMannerOfDeath(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for MannerOfDeathProfile
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-manner-of-death
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.VrdrMannerOfDeath().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.VrdrMannerOfDeath().AddFixedValue();

            return observation;
        }

        /// <summary>
        /// Factory for MannerOfDeathProfile with a patient
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-manner-of-death
        /// </summary>
        public static Observation Create(Patient subject, Practitioner certifier)
        {
            var observation = new Observation();

            observation.VrdrMannerOfDeath().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.VrdrMannerOfDeath().AddFixedValue();
            observation.VrdrMannerOfDeath().SubjectAsResource = subject;
            observation.VrdrMannerOfDeath().Certifier = certifier;

            return observation;
        }

        /// <summary>
        /// The official URL for MannerOfDeathProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-manner-of-death";

        public void AddFixedValue()
        {
            this.observation.Code = new CodeableConcept("http://loinc.org", "69449-7", "Manner of death", null);
        }

        /// <summary>
        /// Set profile for MannerOfDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for MannerOfDeathProfile
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
        /// setting subject reference and store the resource for future use
        /// </summary>
        public Practitioner Certifier
        {
            get
            {
                Resource value;
                Record.GetResources().TryGetValue(this.observation.Performer?[0].Reference, out value);

                return (Practitioner) value;
            }
            set
            {
                this.observation.Performer = new List<ResourceReference> { value.AsReference() };
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }
    }
}
