using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsHomelessAtDeathExtensions
{
    public static NvdrsHomelessAtDeath NvdrsHomelessAtDeath(this Observation observation)
    {
        return new NvdrsHomelessAtDeath(observation);
    }
}
