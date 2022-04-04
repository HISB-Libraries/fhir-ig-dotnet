using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationDecedentPregnancyProfile
{
    /// <summary>
    /// ObservationDecedentPregnancyProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy
    /// </summary>
    public class ObservationDecedentPregnancy
    {
        readonly Observation observation;

        internal ObservationDecedentPregnancy(Observation observation)
        {
            this.observation = observation;
            this.observation.Status = ObservationStatus.Final;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69442-2", "Timing of recent pregnancy in relation to death", null);
        }

        /// <summary>
        /// Factory for ObservationDecedentPregnancyProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationDecedentPregnancy().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationDecedentPregnancyProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-decedent-pregnancy";

        /// <summary>
        /// Set profile for ObservationDecedentPregnancyProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationDecedentPregnancyProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
