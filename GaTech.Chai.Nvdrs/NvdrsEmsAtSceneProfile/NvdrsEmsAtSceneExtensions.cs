using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsEmsAtSceneExtensions
{
    public static NvdrsEmsAtScene NvdrsEmsAtScene(this Observation observation)
    {
        return new NvdrsEmsAtScene(observation);
    }
}
