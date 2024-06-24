using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsCompositionExtensions
{  
    public static NvdrsComposition NvdrsComposition(this Composition composition)
        {
            return new NvdrsComposition(composition);
        }
}
