using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.ImmunizationProfile
{
    /// <summary>
    /// Class with Immunization extensions for US Core Immunization Profile
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
