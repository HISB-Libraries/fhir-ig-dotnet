using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsCircumstancesExtensions
{
    public static NvdrsCircumstances NvdrsCircumstances(this Observation observation)
    {
        return new NvdrsCircumstances(observation);
    }
}
