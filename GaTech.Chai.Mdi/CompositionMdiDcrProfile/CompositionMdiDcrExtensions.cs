using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Composition extensions for CompositionMdiDcrProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-dcr
    /// </summary>
    public static class CompositionMdiDcrExtensions
    {
        public static CompositionMdiDcr CompositionMdiDcr(this Composition composition)
        {
            return new CompositionMdiDcr(composition);
        }
    }
}
