using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.SpecimenToxicologyLabProfile
{
    /// <summary>
    /// Class with Specimen extensions for SpecimenToxicologyLabProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Specimen-toxicology-lab
    /// </summary>
    public static class SpecimenToxicologyLabExtensions
    {
        public static SpecimenToxicologyLab SpecimenToxicologyLab(this Specimen specimen)
        {
            return new SpecimenToxicologyLab(specimen);
        }
    }
}
