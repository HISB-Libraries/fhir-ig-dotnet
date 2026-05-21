using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdTreatmentForSubstanceUseDisorderExtensions
{
    public static VdorOdTreatmentForSubstanceUseDisorder VdorOdTreatmentForSubstanceUseDisorder(this Observation observation)
    {
        return new VdorOdTreatmentForSubstanceUseDisorder(observation);
    }
}
