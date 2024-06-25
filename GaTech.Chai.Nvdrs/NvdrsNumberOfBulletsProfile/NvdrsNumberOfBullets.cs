using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public class NvdrsNumberOfBullets
{
    readonly Observation observation;

    internal NvdrsNumberOfBullets(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = NvdrsInjuryAndDeath.Create();
        observation.NvdrsInjuryAndDeath().RemoveProfile();
        observation.Code = NvdrsCustomCs.NumberOfBullets;

        observation.NvdrsNumberOfBullets().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-number-of-bullets";

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

    public int? NumOfBullets
    {
        get { return (this.observation.Value as Integer)?.Value; }
        set { this.observation.Value = new Integer(value); }
    }
}
