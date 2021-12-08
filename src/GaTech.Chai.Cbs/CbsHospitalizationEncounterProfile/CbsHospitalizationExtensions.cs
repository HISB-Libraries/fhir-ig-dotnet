using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsHospitalizationEncounterProfile
{
    /// <summary>
    /// Class with Encounter extensions for Case Based Surveillance Hospitalization Encounter profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-condition
    /// </summary>
    public static class CbsHospitalizationExtensions
    {
        public static CbsHospitalization CbsHospitalization(this Encounter encounter)
        {
            return new CbsHospitalization(encounter);
        }
    }
}
