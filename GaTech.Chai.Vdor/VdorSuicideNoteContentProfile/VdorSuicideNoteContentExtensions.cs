using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorSuicideNoteContentExtensions
{
    public static VdorSuicideNoteContent VdorSuicideNoteContent(this Observation observation)
    {
        return new VdorSuicideNoteContent(observation);
    }
}
