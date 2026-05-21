using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorInjuryAndDeathExtensions
{
    public static VdorInjuryAndDeath VdorInjuryAndDeath(this Observation observation)
    {
        return new VdorInjuryAndDeath(observation);
    }
}
