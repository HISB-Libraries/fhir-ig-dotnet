using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorNumberOfBulletsExtensions
{
    public static VdorNumberOfBullets VdorNumberOfBullets(this Observation observation)
    {
        return new VdorNumberOfBullets(observation);
    }
}
