using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorEmsAtSceneExtensions
{
    public static VdorEmsAtScene VdorEmsAtScene(this Observation observation)
    {
        return new VdorEmsAtScene(observation);
    }
}
