using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.PatientProfile
{
    /// <summary>
    /// Class with Address extensions for Case Based Surveillance Patient Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient
    /// </summary>
    public static class CbsAddressExtensions
    {
        public static UsCbsAddress UsCbsAddress(this Address address)
        {
            return new UsCbsAddress(address);
        }
    }
}
