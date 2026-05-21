using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorVictimInCustodyWhenInjuredExtensions
{
    public static VdorVictimInCustodyWhenInjured VdorVictimInCustodyWhenInjured(this Observation observation)
    {
        return new VdorVictimInCustodyWhenInjured(observation);
    }
}
