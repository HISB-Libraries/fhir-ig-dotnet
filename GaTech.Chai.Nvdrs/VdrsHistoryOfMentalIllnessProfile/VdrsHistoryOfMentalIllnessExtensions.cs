using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class VdrsHistoryOfMentalIllnessExtensions
{
    public static VdrsHistoryOfMentalIllness VdrsHistoryOfMentalIllness(this Observation observation)
    {
        return new VdrsHistoryOfMentalIllness(observation);
    }
}
