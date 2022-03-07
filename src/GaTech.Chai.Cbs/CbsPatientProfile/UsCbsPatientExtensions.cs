using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.PatientProfile
{
    /// <summary>
    /// Class with Patient extensions for Case Based Surveillance Patient Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient
    /// </summary>
    public static class CbsPatientExtensions
    {
        public static UsCbsPatient UsCbsPatient(this Patient patient)
        {
            return new UsCbsPatient(patient);
        }
    }
}
