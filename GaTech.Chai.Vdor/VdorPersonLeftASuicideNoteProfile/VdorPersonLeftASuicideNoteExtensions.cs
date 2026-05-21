using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public static class VdorPersonLeftASuicideNoteExtensions
{
    public static VdorPersonLeftASuicideNote VdorPersonLeftASuicideNote(this Observation observation)
    {
        return new VdorPersonLeftASuicideNote(observation);
    }
}
