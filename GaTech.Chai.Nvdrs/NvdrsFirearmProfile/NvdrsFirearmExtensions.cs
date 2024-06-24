using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsFirearmExtensions
{
    public static NvdrsFirearm NvdrsFirearm(this Observation observation)
    {
        return new NvdrsFirearm(observation);
    }
}
