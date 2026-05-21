using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorWeaponTypeExtensions
{
    public static VdorWeaponType VdorWeaponType(this Observation observation)
    {
        return new VdorWeaponType(observation);
    }
}
