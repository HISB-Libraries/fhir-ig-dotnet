using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.ImmunizationProfile
{
    /// <summary>
    /// Class with Encounter extensions for Case Based Surveillance Encounter profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-immunization
    /// </summary>
    public static class UsCoreImmunizationExtensions
    {
        public static UsCoreImmunization UsCoreImmunization(this Immunization immunization)
        {
            return new UsCoreImmunization(immunization);
        }
    }
}
