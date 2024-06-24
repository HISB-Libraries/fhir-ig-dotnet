using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Nvdrs.Common;

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
        Observation observation = new()
        {
            Code = NvdrsCustomCs.HistoryOfSuicideAttempts
        };

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
