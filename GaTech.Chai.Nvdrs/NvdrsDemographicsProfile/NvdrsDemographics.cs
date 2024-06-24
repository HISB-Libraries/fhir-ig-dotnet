using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;
using GaTech.Chai.Nvdrs.Common;

namespace GaTech.Chai.Nvdrs;

public class NvdrsDemographics
{
    readonly Observation observation;

    internal NvdrsDemographics(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Category = new List<CodeableConcept>() { NvdrsCustomCs.Demographics }
        };

        observation.NvdrsDemographics().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-demographics";

    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }
}
