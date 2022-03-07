using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.LabResultObservationProfile
{
    /// <summary>
    /// US Core DiagnosticReport Profile Extensions
    /// hhttp://hl7.org/fhir/us/core/StructureDefinition/us-core-diagnosticreport-lab
    /// </summary>
    public class UsCoreLabResultObservation
    {
        readonly Observation observation;

        internal UsCoreLabResultObservation(Observation observation)
        {
            this.observation = observation;
            this.observation.Category.SetCategory(new Coding("http://terminology.hl7.org/CodeSystem/observation-category", "laboratory"));
        }

        /// <summary>
        /// Factory for US Core DiagnosticReport Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-diagnosticreport-lab
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.UsCoreLabResultObservation().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the US Core DiagnosticReport profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-observation-lab";

        /// <summary>
        /// Set the assertion that an DiagnosticReport object conforms to the Case Based Surveillance DiagnosticReport profile.
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an DiagnosticReport object conforms to the Case Based Surveillance DiagnosticReport profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
