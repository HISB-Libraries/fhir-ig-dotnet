using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsPlayingWithFirearmExtensions
{
    public static NvdrsPlayingWithFirearm NvdrsPlayingWithFirearm(this Observation observation)
    {
        return new NvdrsPlayingWithFirearm(observation);
    }
}
