using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsHistoryAlcoholUseExtensions
{
    public static NvdrsHistoryAlcoholUse NvdrsHistoryAlcoholUse(this Observation observation)
    {
        return new NvdrsHistoryAlcoholUse(observation);
    }
}
