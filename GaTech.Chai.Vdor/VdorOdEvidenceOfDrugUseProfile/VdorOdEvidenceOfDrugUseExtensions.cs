using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdEvidenceOfDrugUseExtensions
{
    public static VdorOdEvidenceOfDrugUse VdorOdEvidenceOfDrugUse(this Observation observation)
    {
        return new VdorOdEvidenceOfDrugUse(observation);
    }
}
