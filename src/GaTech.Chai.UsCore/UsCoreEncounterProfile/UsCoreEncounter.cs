using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.EncounterProfile
{
    /// <summary>
    /// US Core Encounter Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-encounter
    /// </summary>
    public class UsCoreEncounter
    {
        readonly Encounter encounter;

        internal UsCoreEncounter(Encounter encounter)
        {
            this.encounter = encounter;
        }

        /// <summary>
        /// Factory for US Core Encounter Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-encounter
        /// </summary>
        public static Encounter Create()
        {
            var encounter = new Encounter();
            encounter.UsCoreEncounter().AddProfile();
            return encounter;
        }

        /// <summary>
        /// The official URL for the US Core Encounter profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-encounter";

        /// <summary>
        /// Set profile for US Core Encounter Profile
        /// </summary>
        public void AddProfile()
        {
            this.encounter.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Core Encounter Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.encounter.RemoveProfile(ProfileUrl);
        }
    }
}
