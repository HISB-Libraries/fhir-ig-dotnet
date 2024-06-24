using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsVictimInCustodyWhenInjuredEtensions
{
    public static NvdrsVictimInCustodyWhenInjured NvdrsVictimInCustodyWhenInjured(this Observation observation)
    {
        return new NvdrsVictimInCustodyWhenInjured(observation);
    }
}
