using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsGangRelatedExtensions
{
    public static NvdrsGangRelated NvdrsGangRelated(this Observation observation)
    {
        return new NvdrsGangRelated(observation);
    }
}
