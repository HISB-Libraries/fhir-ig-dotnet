using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vrcl
{
    /// <summary>
    /// ObservationAutopsyPerformedIndicatorVrProfile
    /// http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Observation-autopsy-performed-indicator-vr
    /// </summary>
    public class ObservationAutopsyPerformedIndicatorVr
    {
        readonly Observation observation;

        internal ObservationAutopsyPerformedIndicatorVr(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ObservationAutopsyPerformedIndicatorVrProfile
        /// http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Observation-autopsy-performed-indicator-vr
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();

            observation.ObservationAutopsyPerformedIndicatorVr().AddProfile();
            observation.ObservationAutopsyPerformedIndicatorVr().AddFixedValues();

            return observation;
        }

        /// <summary>
        /// Factory for ObservationAutopsyPerformedIndicatorVrProfile with Subject
        /// http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Observation-autopsy-performed-indicator-vr
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationAutopsyPerformedIndicatorVr().AddProfile();
            observation.ObservationAutopsyPerformedIndicatorVr().AddFixedValues();
            observation.ObservationAutopsyPerformedIndicatorVr().SubjectAsResource = subject;

            return observation;
        }

        public void AddFixedValues()
        {
            observation.Code = new CodeableConcept("http://loinc.org", "85699-7", "Autopsy was performed", null);
        }

        /// <summary>
        /// The official URL for the ObservationAutopsyPerformedIndicatorVrProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Observation-autopsy-performed-indicator-vr";

        /// <summary>
        /// Set profile for ObservationAutopsyPerformedIndicatorVrProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationAutopsyPerformedIndicatorVrProfile
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
                Resource value;
                Record.GetResources().TryGetValue(this.observation.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.observation.Subject = value.AsReference();
                Record.GetResources()[value.AsReference().Reference] = value;
            }
        }

        /// <summary>
        /// setting or getting valueCodeableConcept
        /// </summary>
        public CodeableConcept Value
        {
            get
            {
                return this.observation.Value as CodeableConcept;
            }
            set
            {
                this.observation.Value = value;
            }
        }

        /// <summary>
        /// setting or getting component value for Autopsy Result Available
        /// </summary>
        /// <returns></returns>
        public CodeableConcept AutopsyResultAvailable
        {
            get
            {
                Observation.ComponentComponent component = this.observation.Component.GetComponent("http://loinc.org", "69436-4");
                return component?.Value as CodeableConcept;
            }
            set
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent("http://loinc.org", "69436-4", null);
                component.Value = value;
            }
        }
    }
}
