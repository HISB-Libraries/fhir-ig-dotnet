using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorDriveByShootingExtensions
{
    public static VdorDriveByShooting VdorDriveByShooting(this Observation observation)
    {
        return new VdorDriveByShooting(observation);
    }
}
