using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorHistoryOfSuicideAttemptsExtensions
{
    public static VdorHistoryOfSuicideAttempts VdorHistoryOfSuicideAttempts(this Observation observation)
    {
        return new VdorHistoryOfSuicideAttempts(observation);
    }
}
