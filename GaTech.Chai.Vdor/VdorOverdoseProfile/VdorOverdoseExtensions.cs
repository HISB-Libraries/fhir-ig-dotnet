using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOverdoseExtensions
{
    public static VdorOverdose VdorOverdose(this Observation observation)
    {
        return new VdorOverdose(observation);
    }
}
