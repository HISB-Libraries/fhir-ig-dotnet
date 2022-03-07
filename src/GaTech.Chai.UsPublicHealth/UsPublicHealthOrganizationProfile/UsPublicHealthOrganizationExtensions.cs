using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.OrganizationProfile
{
    /// <summary>
    /// Class with Organization extensions for US Core Organization profile.
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-organization
    /// </summary>
    public static class UsPublicHealthOrganizationExtensions
    {
        public static UsPublicHealthOrganization UsPublicHealthOrganization(this Organization organization)
        {
            return new UsPublicHealthOrganization(organization);
        }
    }
}
