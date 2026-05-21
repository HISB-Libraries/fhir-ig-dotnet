using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorToxicologySummaryCarbonMonoxideExtensions
{
    public static VdorToxicologySummaryCarbonMonoxide VdorToxicologySummaryCarbonMonoxide(this Observation observation)
    {
        return new VdorToxicologySummaryCarbonMonoxide(observation);
    }
}
