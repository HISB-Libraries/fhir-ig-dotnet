using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorRandomViolenceExtensions
{
    public static VdorRandomViolence VdorRandomViolence(this Observation observation)
    {
        return new VdorRandomViolence(observation);
    }
}
