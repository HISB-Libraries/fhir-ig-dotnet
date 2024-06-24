using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsDemographicsSocialHistoryExtensions
{
    public static NvdrsDemographicsSocialHistory NvdrsDemographicsSocialHistory(this Observation observation) {
        return new NvdrsDemographicsSocialHistory(observation);
    }
}