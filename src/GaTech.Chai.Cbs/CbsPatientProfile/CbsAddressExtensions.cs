using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    /// <summary>
    /// Class with Address extensions for Case Based Surveillance Patient Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-patient
    /// </summary>
    public static class CbsAddressExtensions
    {
        public static CbsAddress CbsAddress(this Address address)
        {
            return new CbsAddress(address);
        }
    }
}
