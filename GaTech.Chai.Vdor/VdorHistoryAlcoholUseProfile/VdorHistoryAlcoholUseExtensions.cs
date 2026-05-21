using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorHistoryAlcoholUseExtensions
{
    public static VdorHistoryAlcoholUse VdorHistoryAlcoholUse(this Observation observation)
    {
        return new VdorHistoryAlcoholUse(observation);
    }
}
