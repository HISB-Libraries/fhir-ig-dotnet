using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Linq;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// ObservationMedicalInformationDataQualityProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-communicable-disease
    /// </summary>
    public class ObservationMedicalInformationDataQuality
    {
        readonly Observation observation;

        internal ObservationMedicalInformationDataQuality(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ObservationMedicalInformationDataQualityProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-medical-information-data-quality
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationMedicalInformationDataQuality().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.Code = MdiCodeSystem.MdiCodes.MedInfoDataQualityObs;

            return observation;
        }

        /// <summary>
        /// Factory for ObservationEmbalmedProfile with Subject patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-embalmed
        /// </summary>
        public static Observation Create(Patient subject, Composition deathCertificate)
        {
            var observation = new Observation();

            observation.ObservationMedicalInformationDataQuality().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.Code = MdiCodeSystem.MdiCodes.MedInfoDataQualityObs;
            observation.ObservationMedicalInformationDataQuality().SubjectAsResource = subject;
            observation.ObservationMedicalInformationDataQuality().DeathCertificate = deathCertificate;

            return observation;
        }

        /// <summary>
        /// The official URL for ObservationMedicalInformationDataQualityProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-medical-information-data-quality";

        /// <summary>
        /// Set profile for the ObservationMedicalInformationDataQualityProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationMedicalInformationDataQualityProfile
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

        /// <summary>
        /// setting DeathCertificate reference and store the resource for future use
        /// </summary>
        public Composition DeathCertificate
        {
            get
            {
                if (this.observation.Focus.Count > 0)
                {
                    Record.GetResources().TryGetValue(this.observation.Focus[0].Reference, out Resource value);
                    return (Composition)value;
                }

                return null;
            }
            set
            {
                this.observation.Focus = [value.AsReference()];
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }

    }
}
