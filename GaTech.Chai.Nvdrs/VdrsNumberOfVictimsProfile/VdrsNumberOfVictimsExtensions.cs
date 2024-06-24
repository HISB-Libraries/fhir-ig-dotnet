using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class VdrsNumberOfVictimsExtensions
{
    public static VdrsNumberOfVictims VdrsNumberOfVictims(this Observation observation)
    {
        return new VdrsNumberOfVictims(observation);
    }
}
