using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.EncounterProfile
{
    /// <summary>
    /// Class with Encounter extensions for Case Based Surveillance Encounter profile.
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
