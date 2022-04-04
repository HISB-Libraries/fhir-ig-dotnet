using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.HospitalizationEncounterProfile
{
    /// <summary>
    /// Class with Encounter extensions for US Case Based Surveillance Hospitalization Profile
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
