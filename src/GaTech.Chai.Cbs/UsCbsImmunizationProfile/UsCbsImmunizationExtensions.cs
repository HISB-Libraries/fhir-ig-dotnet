using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.ImmunizationProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Immunization profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-immunization
    /// </summary>
    public static class UsCbsImmunizationExtensions
    {
        public static UsCbsImmunization UsCbsImmunization(this Immunization immunization)
        {
            return new UsCbsImmunization(immunization);
        }
    }
}
