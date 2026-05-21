using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorCurrentDepressedMoodExtensions
{
    public static VdorCurrentDepressedMood VdorCurrentDepressedMood(this Observation observation)
    {
        return new VdorCurrentDepressedMood(observation);
    }
}
