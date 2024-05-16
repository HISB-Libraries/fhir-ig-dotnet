using System;
using System.Collections.Generic;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.EncounterProfile
{
    /// <summary>
    /// US Public Health Encounter Profile
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-encounter
    /// </summary>
    public class UsPublicHealthEncounter
    {
        readonly Encounter encounter;

        internal UsPublicHealthEncounter(Encounter encounter)
        {
            this.encounter = encounter; 
        }

        /// <summary>
        /// Factory for US Public Health Encounter Profile
        /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-encounter
        /// </summary>
        public static Encounter Create()
        {
            var encounter = new Encounter();
            encounter.UsPublicHealthEncounter().AddProfile();
            return encounter;
        }

        /// <summary>
        /// The official URL for US Public Health Encounter Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-encounter";

        /// <summary>
        /// Set profile for US Public Health Encounter Profile
        /// </summary>
        public void AddProfile()
        {
            this.encounter.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Public Health Encounter Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.encounter.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Responsible Provider for Participant
        /// </summary>
        public void SetResponsibleProvider(Period period = null, ResourceReference individual = null)
        {
            Encounter.ParticipantComponent participantComponent = new Encounter.ParticipantComponent()
            {
                Type = new List<CodeableConcept> { new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-ParticipationType", "ATND", null, null) }
            };

            if (this.encounter.Participant == null)
            {
                this.encounter.Participant.Add(participantComponent);
            }

            if (this.encounter.Participant != null)
            {
                foreach (Encounter.ParticipantComponent p in this.encounter.Participant)
                {
                    foreach (CodeableConcept c in p.Type)
                    {
                        var result = c.Coding.Find(e => e.System == "http://terminology.hl7.org/CodeSystem/v3-ParticipationType" && e.Code == "ATND");
                        if (result != null)
                        {
                            this.encounter.Participant.Remove(p);
                            this.encounter.Participant.Add(participantComponent);
                            return;
                        }
                    }
                }
            }


            this.encounter.Participant.Add(participantComponent);
        }
    }
}
