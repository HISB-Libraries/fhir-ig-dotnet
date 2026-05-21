using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorCompositionExtensions
{  
    public static VdorComposition VdorComposition(this Composition composition)
        {
            return new VdorComposition(composition);
        }
}
