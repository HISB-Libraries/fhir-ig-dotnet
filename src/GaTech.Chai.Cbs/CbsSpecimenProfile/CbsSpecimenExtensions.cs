using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsSpecimenProfile
{
    /// <summary>
    /// Class with Specimen extensions for Case Based Surveillance Specimen Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-specimen
    /// </summary>
    public static class CbsSpecimenExtensions
    {
        public static CbsSpecimen CbsSpecimen(this Specimen specimen)
        {
            return new CbsSpecimen(specimen);
        }
    }
}
