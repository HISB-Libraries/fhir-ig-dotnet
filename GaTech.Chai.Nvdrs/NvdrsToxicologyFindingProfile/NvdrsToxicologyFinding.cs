using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Nvdrs.Common;

namespace GaTech.Chai.Nvdrs;

public class NvdrsToxicologyFinding
{
    readonly Observation observation;

    internal NvdrsToxicologyFinding(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = NvdrsToxicology.Create();
        observation.NvdrsToxicology().RemoveProfile();

        observation.NvdrsToxicologyFinding().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-toxicology-finding";

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
