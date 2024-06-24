using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsToxicologyExtensions
{
    public static NvdrsToxicology NvdrsToxicology(this Observation observation)
    {
        return new NvdrsToxicology(observation);
    }
}
