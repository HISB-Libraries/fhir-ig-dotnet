using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public class NvdrsHistoryOfSuicideAttempts
{
    readonly Observation observation;

    internal NvdrsHistoryOfSuicideAttempts(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = NvdrsCircumstances.Create();
        observation.NvdrsCircumstances().RemoveProfile();
        observation.Code = NvdrsCustomCs.HistoryOfSuicideAttempts;

        observation.NvdrsHistoryOfSuicideAttempts().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-history-of-suicide-attempts";

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
