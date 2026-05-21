using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorHistoryOfMentalIllnessExtensions
{
    public static VdorHistoryOfMentalIllness VdorHistoryOfMentalIllness(this Observation observation)
    {
        return new VdorHistoryOfMentalIllness(observation);
    }
}
