using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdLnkaExtensions
{
    public static VdorOdLnka VdorOdLnka(this Observation observation)
    {
        return new VdorOdLnka(observation);
    }
}
