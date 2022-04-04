using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationConditionContributingToDeathProfile
{
    /// <summary>
    /// ObservationConditionContributingToDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-condition-contributing-to-death
    /// </summary>
    public class ObservationConditionContributingToDeath
    {
        readonly Observation observation;

        internal ObservationConditionContributingToDeath(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69441-4", "Other significant causes or conditions of death", null);
        }

        /// <summary>
        /// Factory for ObservationConditionContributingToDeathProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-condition-contributing-to-death
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationConditionContributingToDeath().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationConditionContributingToDeathProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-condition-contributing-to-death";

        /// <summary>
        /// Set profile for the ObservationConditionContributingToDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationConditionContributingToDeathProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// valueCodeableConcept property. Setter checks the length of Text.
        /// </summary>
        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set
            {
                int? totalTextCount = value.Text?.Length;
                if (totalTextCount != null && totalTextCount > 240)
                {
                    throw (new ArgumentException("Total size of valueCodeableConcept.Text (" + totalTextCount + ") exceeded 240"));
                }
                this.observation.Value = value;
            }
        }
    }
}
