using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public static class VdrsSuicideNoteExtensions
{
    public static VdrsSuicideNote VdrsSuicideNote(this Observation observation)
    {
        return new VdrsSuicideNote(observation);
    }
}
