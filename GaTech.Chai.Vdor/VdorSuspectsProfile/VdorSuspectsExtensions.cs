using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorSuspectsExtensions
{
    public static VdorSuspects VdorSuspects(this Observation observation)
    {
        return new VdorSuspects(observation);
    }
}
