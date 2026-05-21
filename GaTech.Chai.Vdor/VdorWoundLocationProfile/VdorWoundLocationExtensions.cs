using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorWoundLocationExtensions
{
    public static VdorWoundLocation VdorWoundLocation(this Observation observation)
    {
        return new VdorWoundLocation(observation);
    }
}
