using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsDemographicsExtensions
{
    public static NvdrsDemographics NvdrsDemographics(this Observation observation) {
        return new NvdrsDemographics(observation);
    }
}