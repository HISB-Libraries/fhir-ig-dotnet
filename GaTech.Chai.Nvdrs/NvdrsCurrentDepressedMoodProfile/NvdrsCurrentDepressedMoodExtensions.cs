using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsCurrentDepressedMoodExtensions
{
    public static NvdrsCurrentDepressedMood NvdrsCurrentDepressedMood(this Observation observation)
    {
        return new NvdrsCurrentDepressedMood(observation);
    }
}
