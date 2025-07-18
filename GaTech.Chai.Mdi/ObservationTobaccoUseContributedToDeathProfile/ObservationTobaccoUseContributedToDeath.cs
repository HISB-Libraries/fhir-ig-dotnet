﻿using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// ObservationTobaccoUseContributedToDeathProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death
    /// </summary>
    public class ObservationTobaccoUseContributedToDeath
    {
        readonly Observation observation;
        // readonly static Dictionary<string, Resource> resources = new();

        internal ObservationTobaccoUseContributedToDeath(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for ObservationTobaccoUseContributedToDeathProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death
        /// </summary>
        public static Observation Create()
        {
            // clear static resource container.
            // resources.Clear();

            var observation = new Observation();
            observation.ObservationTobaccoUseContributedToDeath().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.Code = new CodeableConcept("http://loinc.org", "69443-0", "Did tobacco use contribute to death", null);

            return observation;
        }

        /// <summary>
        /// Factory for ObservationTobaccoUseContributedToDeathProfile with Patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death
        /// </summary>
        public static Observation Create(Patient subject)
        {
            // clear static resource container.
            // resources.Clear();

            var observation = new Observation();

            observation.ObservationTobaccoUseContributedToDeath().AddProfile();
            observation.Status = ObservationStatus.Final;
            observation.Code = new CodeableConcept("http://loinc.org", "69443-0", "Did tobacco use contribute to death", null);
            observation.ObservationTobaccoUseContributedToDeath().SubjectAsResource = subject;

            return observation;
        }

        /// <summary>
        /// The official URL for the ObservationTobaccoUseContributedToDeathProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-tobacco-use-contributed-to-death";

        /// <summary>
        /// Set profile for ObservationTobaccoUseContributedToDeathProfile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for ObservationTobaccoUseContributedToDeathProfile
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

        // public Dictionary<String, Resource> GetReferencedResources()
        // {
        //     return resources;
        // }
    }
}
