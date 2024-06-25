using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth
{
    /// <summary>
    /// Class with Encounter extensions for US Public Health Encounter Profile.
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-encounter
    /// </summary>
    public static class UsPublicHealthEncounterExtensions
    {
        public static UsPublicHealthEncounter UsPublicHealthEncounter(this Encounter encounter)
        {
            return new UsPublicHealthEncounter(encounter);
        }
    }
}
