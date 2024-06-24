using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsInjuryAndDeathExtensions
{
    public static NvdrsInjuryAndDeath NvdrsInjuryAndDeath(this Observation observation)
    {
        return new NvdrsInjuryAndDeath(observation);
    }
}
