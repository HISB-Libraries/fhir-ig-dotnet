using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    /// <summary>
    /// Class with Patient extensions for Case Based Surveillance Patient Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient
    /// </summary>
    public static class CbsPatientExtensions
    {
        public static CbsPatient CbsPatient(this Patient patient)
        {
            return new CbsPatient(patient);
        }
    }
}
