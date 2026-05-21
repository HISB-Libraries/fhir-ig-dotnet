using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorDeathAbuseExtensions
{
    public static VdorDeathAbuse VdorDeathAbuse(this Observation observation)
    {
        return new VdorDeathAbuse(observation);
    }
}
