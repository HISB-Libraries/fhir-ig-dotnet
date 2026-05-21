using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorSuspects
{
    readonly Observation observation;

    internal VdorSuspects(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Category = [VdorCustomCs.Suspects]
        };

        observation.VdorSuspects().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-suspects";

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

}
