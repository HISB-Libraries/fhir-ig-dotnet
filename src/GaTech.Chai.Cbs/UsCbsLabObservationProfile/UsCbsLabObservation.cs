using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsCore.LabResultObservationProfile;

namespace GaTech.Chai.UsCbs.LabObservationProfile
{
    /// <summary>
    /// US Case Based Surveillance Lab Observation Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-observation
    /// </summary>
    public class UsCbsLabObservation
    {
        readonly Observation observation;

        internal UsCbsLabObservation(Observation o)
        {
            this.observation = o;
            o.UsCoreLabResultObservation().AddProfile();
        }

        /// <summary>
        /// Factory for US Case Based Surveillance Lab Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-observation
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.UsCbsLabObservation().AddProfile();
            observation.Status = ObservationStatus.Final;
            return observation;
        }

        /// <summary>
        /// The official URL for the US Case Based Surveillance Lab Observation Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-lab-observation";

        /// <summary>
        /// Set profile for US Case Based Surveillance Lab Observation Profile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Case Based Surveillance Lab Observation Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
