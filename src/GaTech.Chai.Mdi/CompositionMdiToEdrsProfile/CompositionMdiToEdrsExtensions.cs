using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.CompositionMditoEdrsProfile
{
    /// <summary>
    /// Class with Composition extensions for CompositionMditoEdrsProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Composition-mdi-to-edrs
    /// </summary>
    public static class CompositionMdiToEdrsExtensions
    {
        public static CompositionMdiToEdrs CompositionMdiToEdrs(this Composition composition)
        {
            return new CompositionMdiToEdrs(composition);
        }
    }
}
