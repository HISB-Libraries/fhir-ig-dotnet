using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class NvdrsSchoolProblemeExtensions
{
    public static NvdrsSchoolProblem NvdrsSchoolProblem(this Observation observation)
    {
        return new NvdrsSchoolProblem(observation);
    }
}
