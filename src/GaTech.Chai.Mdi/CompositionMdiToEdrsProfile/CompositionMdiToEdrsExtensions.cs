using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.CompositionMditoEdrsProfile
{
    /// <summary>
    /// Class with Composition extensions for Case Based Surveillance Composition Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-questionnaire
    /// </summary>
    public static class MdiToEdrsCompositionExtensions
    {
        public static CompositionMdiToEdrs CompositionMdiToEdrs(this Composition composition)
        {
            return new CompositionMdiToEdrs(composition);
        }
    }
}
