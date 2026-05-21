using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorDemographicsSocialHistoryExtensions
{
    public static VdorDemographicsSocialHistory VdorDemographicsSocialHistory(this Observation observation)
    {
        return new VdorDemographicsSocialHistory(observation);
    }
}
