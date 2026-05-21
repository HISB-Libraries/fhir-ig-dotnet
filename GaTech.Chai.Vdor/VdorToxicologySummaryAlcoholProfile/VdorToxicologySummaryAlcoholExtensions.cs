using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorToxicologySummaryAlcoholExtensions
{
    public static VdorToxicologySummaryAlcohol VdorToxicologySummaryAlcohol(this Observation observation)
    {
        return new VdorToxicologySummaryAlcohol(observation);
    }
}
