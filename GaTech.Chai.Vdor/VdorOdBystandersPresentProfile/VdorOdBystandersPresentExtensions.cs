using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdBystandersPresentExtensions
{
    public static VdorOdBystandersPresent VdorOdBystandersPresent(this Observation observation)
    {
        return new VdorOdBystandersPresent(observation);
    }
}
