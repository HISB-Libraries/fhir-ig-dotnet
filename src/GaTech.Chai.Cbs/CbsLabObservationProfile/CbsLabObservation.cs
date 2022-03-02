using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Cbs.CbsLabObservationProfile
{
    /// <summary>
    /// Case Based Surveillance Lab Observation Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-observation
    /// </summary>
    public class CbsLabObservation
    {
        readonly Observation observation;

        internal CbsLabObservation(Observation o)
        {
            this.observation = o;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Lab Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-observation
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.CbsLabObservation().AddProfile();
            observation.Category.Add(new CodeableConcept("http://terminology.hl7.org/CodeSystem/observation-category", "laboratory"));
            observation.Status = ObservationStatus.Final;
            return observation;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Lab Observation profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-lab-observation";

        /// <summary>
        /// Set the assertion that an observation object conforms to the Case Based Surveillance Lab Observation profile.
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an observation object conforms to the Case Based Surveillance Lab Observation profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
