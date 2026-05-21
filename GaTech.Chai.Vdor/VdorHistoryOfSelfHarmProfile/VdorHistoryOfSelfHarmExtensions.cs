using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorHistoryOfSelfHarmExtensions
{
    public static VdorHistoryOfSelfHarm VdorHistoryOfSelfHarm(this Observation observation)
    {
        return new VdorHistoryOfSelfHarm(observation);
    }
}
