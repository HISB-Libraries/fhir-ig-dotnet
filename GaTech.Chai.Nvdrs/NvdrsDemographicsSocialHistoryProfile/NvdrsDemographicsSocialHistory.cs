using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;
using GaTech.Chai.Nvdrs.Common;
using GaTech.Chai.UsCore.UsCoreObservationSocialHistory;

namespace GaTech.Chai.Nvdrs;

public class NvdrsDemographicsSocialHistory
{
    readonly Observation observation;

    internal NvdrsDemographicsSocialHistory(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        // This profile based on the US Core Observation Social History
        Observation observation = UsCoreObservationSocialHistory.Create();

        // It's OK to have multiple profiles. But, Let's remove USCore as IG has hierachical 
        // reference already. But, we add NVDRS Demographics Social History Profile.
        observation.UsCoreObservationSocialHistory().RemoveProfile();
        observation.NvdrsDemographicsSocialHistory().AddProfile();

        // We need to set the Category for NVDRS Demographics Social History Profile.
        observation.Category.Add(NvdrsCustomCs.Demographics);

        return observation;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-demographics-social-history";

    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }
}
