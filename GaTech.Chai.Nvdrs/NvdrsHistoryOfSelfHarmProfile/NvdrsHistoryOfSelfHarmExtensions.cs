using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsHistoryOfSelfHarmExtensions
{
    public static NvdrsHistoryOfSelfHarm NvdrsHistoryOfSelfHarm(this Observation observation)
    {
        return new NvdrsHistoryOfSelfHarm(observation);
    }
}
