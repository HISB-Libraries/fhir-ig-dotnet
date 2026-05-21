using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdRecentOpiodUseRelapseExtensions
{
    public static VdorOdRecentOpiodUseRelapse VdorOdRecentOpiodUseRelapse(this Observation observation)
    {
        return new VdorOdRecentOpiodUseRelapse(observation);
    }
}
