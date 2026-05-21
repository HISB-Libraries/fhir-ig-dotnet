using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdPreviousOverdoseExtensions
{
    public static VdorOdPreviousOverdose VdorOdPreviousOverdose(this Observation observation)
    {
        return new VdorOdPreviousOverdose(observation);
    }
}
