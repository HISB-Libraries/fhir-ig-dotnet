using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorToxicologyExtensions
{
    public static VdorToxicology VdorToxicology(this Observation observation)
    {
        return new VdorToxicology(observation);
    }
}
