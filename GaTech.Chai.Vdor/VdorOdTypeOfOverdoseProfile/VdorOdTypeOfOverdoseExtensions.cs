using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdTypeOfOverdoseExtensions
{
    public static VdorOdTypeOfOverdose VdorOdTypeOfOverdose(this Observation observation)
    {
        return new VdorOdTypeOfOverdose(observation);
    }
}
