using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsDeathAbuseExtensions
{
    public static NvdrsDeathAbuse NvdrsDeathAbuse(this Observation observation)
    {
        return new NvdrsDeathAbuse(observation);
    }
}
