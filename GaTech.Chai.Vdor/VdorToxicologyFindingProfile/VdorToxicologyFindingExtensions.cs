using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorToxicologyFindingExtensions
{
    public static VdorToxicologyFinding VdorToxicologyFinding(this Observation observation)
    {
        return new VdorToxicologyFinding(observation);
    }
}
