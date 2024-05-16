using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.OrganizationProfile
{
    /// <summary>
    /// Class with Organization extensions for US Core Organization profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-organization
    /// </summary>
    public static class UsCoreOrganizationExtensions
    {
        public static UsCoreOrganization UsCoreOrganization(this Organization organization)
        {
            return new UsCoreOrganization(organization);
        }
    }
}
