using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Mdi.ObservationCauseOfDeathConditionProfile
{
    /// <summary>
    /// MDI ObservationCauseOfDeathCondition Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-condition
    /// </summary>
    public class ObservationCauseOfDeathCondition
    {
        readonly Observation observation;

        internal ObservationCauseOfDeathCondition(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "69453-9", "Cause of death [US Standard Certificate of Death]", null);
        }

        /// <summary>
        /// Factory for MDI ObservationCauseOfDeathCondition Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-condition
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.ObservationCauseOfDeathCondition().AddProfile();
            return observation;
        }

        /// <summary>
        /// The official URL for the MDI ObservationCauseOfDeathCondition profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-cause-of-death-condition";

        /// <summary>
        /// Set the assertion that an DiagnosticReport object conforms to the Case Based Surveillance DiagnosticReport profile.
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an ObservationCauseOfDeathCondition object conforms to the MDI ObservationCauseOfDeathCondition profile.
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
                if (totalTextCount != null && totalTextCount > 120)
                {
                    throw (new ArgumentException("Total size of valueCodeableConcept.Text (" + totalTextCount + ") exceeded 120"));
                }
                this.observation.Value = value;
            }
        }

        /// <summary>
        /// Interval Component
        /// </summary>
        public string IntervalString
        {
            get
            {
                return (this.observation.Component?.GetComponent("http://loinc.org", "69440-6").Value as FhirString).ToString();
            }
            set
            {
                this.observation.Component.GetOrAddComponent("http://loinc.org", "69440-6", "Disease onset to death interval").Value = new FhirString(value);
            }
        }
        public Quantity IntervalQuantity
        {
            get
            {
                return this.observation.Component?.GetComponent("http://loinc.org", "69440-6").Value as Quantity;
            }
            set
            {
                this.observation.Component.GetOrAddComponent("http://loinc.org", "69440-6", "Disease onset to death interval").Value = value;
            }
        }
    }
}
