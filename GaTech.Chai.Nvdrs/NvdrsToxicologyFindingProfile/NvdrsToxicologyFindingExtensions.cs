using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsToxicologyFindingExtensions
{
    public static NvdrsToxicologyFinding NvdrsToxicologyFinding(this Observation observation)
    {
        return new NvdrsToxicologyFinding(observation);
    }
}
