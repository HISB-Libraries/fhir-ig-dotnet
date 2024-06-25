using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public class NvdrsWoundLocation
{
    readonly Observation observation;

    internal NvdrsWoundLocation(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = NvdrsInjuryAndDeath.Create();
        observation.NvdrsInjuryAndDeath().RemoveProfile();
        observation.NvdrsWoundLocation().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-wound-location";

    /// <summary>
    /// Set profile for the ObservationDeathDateProfile
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the ObservationDeathDateProfile
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }
}
