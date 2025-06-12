using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// ObservationEmbalmedProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-communicable-disease
    /// </summary>
    public class ObservationEmbalmed
    {
        readonly Observation observation;

        internal ObservationEmbalmed(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ObservationEmbalmedProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-embalmed
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationEmbalmed().AddProfile();
            observation.Code = MdiCodeSystem.MdiCodes.EmbalmedObs;

            return observation;
        }

        /// <summary>
        /// Factory for ObservationEmbalmedProfile with Subject patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-embalmed
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationEmbalmed().AddProfile();
            observation.Code = MdiCodeSystem.MdiCodes.EmbalmedObs;
            observation.ObservationEmbalmed().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for ObservationEmbalmedProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-embalmed";

        /// <summary>
        /// Set profile for the ObservationEmbalmedProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationEmbalmedProfile
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
