using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsOverdoseExtensions
{
    public static NvdrsOverdose NvdrsOverdose(this Observation observation)
    {
        return new NvdrsOverdose(observation);
    }
}
