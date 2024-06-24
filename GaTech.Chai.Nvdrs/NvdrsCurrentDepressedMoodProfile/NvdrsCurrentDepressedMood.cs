using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Nvdrs.Common;
using System.ComponentModel;

namespace GaTech.Chai.Nvdrs;

public class NvdrsCurrentDepressedMood
{
    readonly Observation observation;

    internal NvdrsCurrentDepressedMood(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Code = NvdrsCustomCs.CurrentDepressedMood
        };

        observation.NvdrsCurrentDepressedMood().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-current-depressed-mood";

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
