using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public class NvdrsVictimInCustodyWhenInjured
{
    readonly Observation observation;

    internal NvdrsVictimInCustodyWhenInjured(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = NvdrsInjuryAndDeath.Create();
        observation.NvdrsInjuryAndDeath().RemoveProfile();
        observation.Code = NvdrsCustomCs.VictimInCustodyWhenInjured;

        observation.NvdrsVictimInCustodyWhenInjured().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-victim-in-custody-when-injured";

    /// <summary>
    /// Set profile for the Nvdrs Victim In Custody When Injured
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the Nvdrs Victim In Custody When Injured
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

}
