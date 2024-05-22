using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs.CompositionNVDRSProfile;

public static class CompositionNVDRSExtensions
{  
    public static CompositionNVDRS CompositionNVDRS(this Composition composition)
        {
            return new CompositionNVDRS(composition);
        }
}
