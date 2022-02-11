using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.UsCbsHospitalizationEncounterProfile
{
    /// <summary>
    /// Class with Encounter extensions for Case Based Surveillance Hospitalization Encounter profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-hospitalization
    /// </summary>
    public static class CbsHospitalizationExtensions
    {
        public static UsCbsHospitalization UsCbsHospitalization(this Encounter encounter)
        {
            return new UsCbsHospitalization(encounter);
        }
    }
}
