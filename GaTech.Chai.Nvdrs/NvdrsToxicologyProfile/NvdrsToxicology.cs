using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Nvdrs;

public class NvdrsToxicology
{
    readonly Observation observation;

    internal NvdrsToxicology(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Category = new List<CodeableConcept>() { NvdrsCustomCs.Toxicology }
        };

        observation.NvdrsToxicology().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-toxicology";

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
