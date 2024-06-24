using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsDriveByShootingExtensions
{
    public static NvdrsDriveByShooting NvdrsDriveByShooting(this Observation observation)
    {
        return new NvdrsDriveByShooting(observation);
    }
}
