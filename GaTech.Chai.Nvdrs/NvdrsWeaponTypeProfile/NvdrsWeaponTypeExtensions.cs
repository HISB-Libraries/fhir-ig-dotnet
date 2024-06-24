using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsWeaponTypeExtensions
{
    public static NvdrsWeaponType NvdrsWeaponType(this Observation observation)
    {
        return new NvdrsWeaponType(observation);
    }
}
