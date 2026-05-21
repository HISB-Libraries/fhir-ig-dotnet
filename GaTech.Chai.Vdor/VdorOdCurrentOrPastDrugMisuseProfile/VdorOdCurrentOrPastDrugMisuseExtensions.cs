using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdCurrentOrPastDrugMisuseExtensions
{
    public static VdorOdCurrentOrPastDrugMisuse VdorOdCurrentOrPastDrugMisuse(this Observation observation)
    {
        return new VdorOdCurrentOrPastDrugMisuse(observation);
    }
}
