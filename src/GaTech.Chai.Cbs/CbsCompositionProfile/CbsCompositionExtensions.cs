using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CompositionProfile
{
    /// <summary>
    /// Class with Composition extensions for Case Based Surveillance Composition Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-composition
    /// </summary>
    public static class CbsCompositionExtensions
    {
        public static CbsComposition CbsComposition(this Composition composition)
        {
            return new CbsComposition(composition);
        }
    }
}
