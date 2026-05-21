using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Nvdrs;

public class VdrsNumberOfDeaths
{
    readonly Observation observation;

    internal VdrsNumberOfDeaths(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Code = NvdrsCustomCs.NumberOfDeaths
        };

        observation.VdrsNumberOfDeaths().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/vdrs-number-of-deaths";

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

    public int? NumOfDeaths
    {
        get { return (this.observation.Value as Integer)?.Value; }
        set { this.observation.Value = new Integer(value); }
    }
}
