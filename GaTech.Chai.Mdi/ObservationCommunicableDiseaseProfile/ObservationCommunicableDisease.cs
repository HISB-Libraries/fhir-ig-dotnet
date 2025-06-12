using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// ObservationCommunicableDiseaseProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-communicable-disease
    /// </summary>
    public class ObservationCommunicableDisease
    {
        readonly Observation observation;

        internal ObservationCommunicableDisease(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ObservationCommunicableDiseaseProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-communicable-disease
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationCommunicableDisease().AddProfile();
            observation.Code = MdiCodeSystem.MdiCodes.CommunicableDiseaseObs;

            return observation;
        }

        /// <summary>
        /// Factory for ObservationCommunicableDiseaseProfile with Subject patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationCommunicableDisease().AddProfile();
            observation.Code = MdiCodeSystem.MdiCodes.CommunicableDiseaseObs;
            observation.ObservationCommunicableDisease().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for ObservationCommunicableDiseaseProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-communicable-disease";

        /// <summary>
        /// Set profile for the ObservationCommunicableDiseaseProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationCommunicableDiseaseProfile
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
