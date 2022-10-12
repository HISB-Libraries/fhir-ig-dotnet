using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.ObservationAutopsyPerformedIndicatorProfile
{
    /// <summary>
    /// ObservationAutopsyPerformedIndicatorProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-autopsy-performed-indicator
    /// </summary>
    public class ObservationAutopsyPerformedIndicator
    {
        readonly Observation observation;
        readonly static Dictionary<string, Resource> resources = new();

        internal ObservationAutopsyPerformedIndicator(Observation observation)
        {
            this.observation = observation;
            this.observation.Code = new CodeableConcept("http://loinc.org", "85699-7", "Autopsy was performed", null);
        }

        /// <summary>
        /// Factory for ObservationAutopsyPerformedIndicatorProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-autopsy-performed-indicator
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();

            observation.ObservationAutopsyPerformedIndicator().AddProfile();
            return observation;
        }

        /// <summary>
        /// Factory for ObservationAutopsyPerformedIndicatorProfile with Subject
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-autopsy-performed-indicator
        /// </summary>
        public static Observation Create(Patient subject)
        {
            var observation = new Observation();

            observation.ObservationAutopsyPerformedIndicator().AddProfile();
            observation.ObservationAutopsyPerformedIndicator().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationAutopsyPerformedIndicatorProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-autopsy-performed-indicator";

        /// <summary>
        /// Set profile for ObservationAutopsyPerformedIndicatorProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationAutopsyPerformedIndicatorProfile
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
                resources.TryGetValue(this.observation.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.observation.Subject = value.AsReference();
                resources[value.AsReference().Reference] = value;
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

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
