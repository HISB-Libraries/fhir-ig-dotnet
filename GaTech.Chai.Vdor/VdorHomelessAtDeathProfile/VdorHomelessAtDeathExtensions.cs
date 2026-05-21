using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorHomelessAtDeathExtensions
{
    public static VdorHomelessAtDeath VdorHomelessAtDeath(this Observation observation)
    {
        return new VdorHomelessAtDeath(observation);
    }
}
