using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsWeaponsExtensions
{
    public static NvdrsWeapons NvdrsWeapons(this Observation observation)
    {
        return new NvdrsWeapons(observation);
    }
}
