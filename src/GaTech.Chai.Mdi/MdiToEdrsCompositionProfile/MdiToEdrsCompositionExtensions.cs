using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.MditoEdrsCompositionProfile
{
    /// <summary>
    /// Class with Composition extensions for Case Based Surveillance Composition Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-questionnaire
    /// </summary>
    public static class MdiToEdrsCompositionExtensions
    {
        public static MdiToEdrsComposition CbsComposition(this Composition composition)
        {
            return new MdiToEdrsComposition(composition);
        }
    }
}
