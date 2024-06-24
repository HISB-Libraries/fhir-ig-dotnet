using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsHistoryOfSuicideAttemptsExtensions
{
    public static NvdrsHistoryOfSuicideAttempts NvdrsHistoryOfSuicideAttempts(this Observation observation)
    {
        return new NvdrsHistoryOfSuicideAttempts(observation);
    }
}
