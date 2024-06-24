using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsNumberOfBulletsExtensions
{
    public static NvdrsNumberOfBullets NvdrsNumberOfBullets(this Observation observation)
    {
        return new NvdrsNumberOfBullets(observation);
    }
}
