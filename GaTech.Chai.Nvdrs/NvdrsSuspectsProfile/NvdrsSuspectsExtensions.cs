using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsSuspectsExtensions
{
    public static NvdrsSuspects NvdrsSuspects(this Observation observation)
    {
        return new NvdrsSuspects(observation);
    }
}
