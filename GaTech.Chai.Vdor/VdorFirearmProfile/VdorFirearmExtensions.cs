using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorFirearmExtensions
{
    public static VdorFirearm VdorFirearm(this Observation observation)
    {
        return new VdorFirearm(observation);
    }
}
