using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorPlayingWithFirearmExtensions
{
    public static VdorPlayingWithFirearm VdorPlayingWithFirearm(this Observation observation)
    {
        return new VdorPlayingWithFirearm(observation);
    }
}
