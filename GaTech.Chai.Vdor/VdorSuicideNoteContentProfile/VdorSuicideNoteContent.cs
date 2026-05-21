using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorSuicideNoteContent
{
    readonly Observation observation;

    internal VdorSuicideNoteContent(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Code = VdorCustomCs.SuicideNoteContent
        };

        observation.VdorSuicideNoteContent().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-suicide-note-content";

    /// <summary>
    /// Set profile for the Nvdrs Current Depressed Mood
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the Nvdrs Current Depressed Mood
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

    public string? SuicideNoteContent
    {
        get { return (this.observation.Value as FhirString)?.Value; }
        set { this.observation.Value = new FhirString(value); }
    }
}
