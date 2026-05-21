using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorDemographicsExtensions
{
    public static VdorDemographics VdorDemographics(this Observation observation)
    {
        return new VdorDemographics(observation);
    }
}
