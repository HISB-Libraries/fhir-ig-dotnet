using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class ObservationWeaponTypeExtensions
{
    public static ObservationWeaponType ObservationWeaponType(this Observation observation)
    {
        return new ObservationWeaponType(observation);
    }
}
