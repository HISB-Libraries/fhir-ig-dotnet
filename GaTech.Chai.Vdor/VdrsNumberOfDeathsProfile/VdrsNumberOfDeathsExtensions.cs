using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class VdrsNumberOfDeathsExtensions
{
    public static VdrsNumberOfDeaths VdrsNumberOfDeaths(this Observation observation)
    {
        return new VdrsNumberOfDeaths(observation);
    }
}
