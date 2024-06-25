using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// Class with Encounter extensions for US Core Encounter Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-encounter
    /// </summary>
    public static class UsCoreEncounterExtensions
    {
        public static UsCoreEncounter UsCoreEncounter(this Encounter encounter)
        {
            return new UsCoreEncounter(encounter);
        }
    }
}
