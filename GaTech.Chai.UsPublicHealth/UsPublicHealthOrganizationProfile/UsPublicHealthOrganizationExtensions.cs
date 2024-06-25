using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth
{
    /// <summary>
    /// Class with Organization extensions for US Public Health Organization Profile
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
