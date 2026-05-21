using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorToxicologySummaryExtensions
{
    public static VdorToxicologySummary VdorToxicologySummary(this Observation observation)
    {
        return new VdorToxicologySummary(observation);
    }
}
