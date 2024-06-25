using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Nvdrs;

public class NvdrsEmsAtScene
{
    readonly Observation observation;

    internal NvdrsEmsAtScene(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = NvdrsInjuryAndDeath.Create();
        observation.NvdrsInjuryAndDeath().RemoveProfile();
        observation.Code = NvdrsCustomCs.EmsAtScene;

        observation.NvdrsEmsAtScene().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-ems-at-scene";

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
