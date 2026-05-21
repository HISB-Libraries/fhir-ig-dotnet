using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorWeaponsExtensions
{
    public static VdorWeapons VdorWeapons(this Observation observation)
    {
        return new VdorWeapons(observation);
    }
}
