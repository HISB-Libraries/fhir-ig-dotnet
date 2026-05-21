using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorOdUseOfPrescriptionMorphineExtensions
{
    public static VdorOdUseOfPrescriptionMorphine VdorOdUseOfPrescriptionMorphine(this Observation observation)
    {
        return new VdorOdUseOfPrescriptionMorphine(observation);
    }
}
