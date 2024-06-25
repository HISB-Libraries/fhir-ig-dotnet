using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public class NvdrsDeathAbuse
{
    readonly Observation observation;

    internal NvdrsDeathAbuse(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = NvdrsCircumstances.Create();
        observation.NvdrsCircumstances().RemoveProfile();
        observation.Code = NvdrsCustomCs.DeathAbuse;

        observation.NvdrsDeathAbuse().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-death-abuse";

    /// <summary>
    /// Set profile for the Nvdrs Death Abuse
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the Nvdrs Death Abuse
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

}
