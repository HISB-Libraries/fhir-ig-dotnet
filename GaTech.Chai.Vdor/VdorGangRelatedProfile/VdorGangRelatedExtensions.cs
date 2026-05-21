using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorGangRelatedExtensions
{
    public static VdorGangRelated VdorGangRelated(this Observation observation)
    {
        return new VdorGangRelated(observation);
    }
}
