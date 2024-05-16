using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.CompositionMdiAndEdrsProfile
{
    /// <summary>
    /// Class with Composition extensions for CompositionMdiAndEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-and-edrs
    /// </summary>
    public static class CompositionMdiAndEdrsExtensions
    {
        public static CompositionMdiAndEdrs CompositionMdiAndEdrs(this Composition composition)
        {
            return new CompositionMdiAndEdrs(composition);
        }
    }
}
