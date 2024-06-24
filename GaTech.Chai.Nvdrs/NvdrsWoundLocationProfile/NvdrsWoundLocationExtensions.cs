using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsWoundLocationExtensions
{
    public static NvdrsWoundLocation NvdrsWoundLocation(this Observation observation)
    {
        return new NvdrsWoundLocation(observation);
    }
}
