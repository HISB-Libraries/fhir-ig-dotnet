using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorToxicology
{
    readonly Observation observation;

    internal VdorToxicology(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Category = [VdorCustomCs.Toxicology]
        };
        observation.VdorToxicology().AddProfile();

        return observation;
    }

    public static Observation Create(Patient subject)
    {
        Observation observation = new()
        {
            Category = [VdorCustomCs.Toxicology]
        };
        observation.VdorToxicology().AddProfile();
        observation.VdorToxicology().SubjectAsResource = subject;

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-toxicology";

    /// <summary>
    /// Set profile for the Vdor Current Depressed Mood
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

    public Patient? SubjectAsResource
    {
        get
        {
            Record.GetResources().TryGetValue(this.observation.Subject.Reference, out Resource? value);
            return value as Patient;
        }
        set
        {
            this.observation.Subject = value.AsReference();
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }
}
