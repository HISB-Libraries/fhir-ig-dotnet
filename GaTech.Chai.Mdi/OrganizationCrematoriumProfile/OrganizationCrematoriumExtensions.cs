using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Observation extensions for Observation - Medical Information Data Quality
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-medical-information-data-quality
    /// </summary>
    public static class OrganizationCrematoriumExtensions
    {
        public static OrganizationCrematorium OrganizationCrematorium(this Organization organization)
        {
            return new OrganizationCrematorium(organization);
        }
    }
}
