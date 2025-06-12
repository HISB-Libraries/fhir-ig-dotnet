using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// ObservationPersonalInformationDataQualityProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-communicable-disease
    /// </summary>
    public class ObservationPersonalInformationDataQuality
    {
        readonly Observation observation;

        internal ObservationPersonalInformationDataQuality(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ObservationPersonalInformationDataQuality
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-personal-information-data-quality
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationPersonalInformationDataQuality().AddProfile();
            observation.Code = MdiCodeSystem.MdiCodes.PersonalInfoDataQualityObs;

            return observation;
        }

        /// <summary>
        /// Factory for ObservationPersonalInformationDataQualityProfile with Subject patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-personal-information-data-quality
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationPersonalInformationDataQuality().AddProfile();
            observation.Code = MdiCodeSystem.MdiCodes.PersonalInfoDataQualityObs;
            observation.ObservationPersonalInformationDataQuality().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for ObservationPersonalInformationDataQuality, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-personal-information-data-quality";

        /// <summary>
        /// Set profile for the ObservationPersonalInformationDataQuality
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationPersonalInformationDataQuality
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
