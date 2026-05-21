using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdFirstFoundUnresponsiveExtensions
{
    public static VdorOdFirstFoundUnresponsive VdorOdFirstFoundUnresponsive(this Observation observation)
    {
        return new VdorOdFirstFoundUnresponsive(observation);
    }
}
