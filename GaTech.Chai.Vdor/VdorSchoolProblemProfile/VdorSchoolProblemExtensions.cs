using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorSchoolProblemExtensions
{
    public static VdorSchoolProblem VdorSchoolProblem(this Observation observation)
    {
        return new VdorSchoolProblem(observation);
    }
}
