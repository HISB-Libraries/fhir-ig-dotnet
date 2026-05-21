using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorCircumstancesExtensions
{
    public static VdorCircumstances VdorCircumstances(this Observation observation)
    {
        return new VdorCircumstances(observation);
    }
}
