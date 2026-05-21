using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;

namespace GaTech.Chai.Vdor;

public class VdorDemographicsSocialHistory
{
    readonly Observation observation;

    internal VdorDemographicsSocialHistory(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = UsCoreObservationSocialHistory.Create();

        // It's OK to have multiple profiles. But, Let's remove USCore as IG has hierachical 
        // reference already. But, we add NVDRS Demographics Social History Profile.
        observation.UsCoreObservationSocialHistory().RemoveProfile();
        observation.VdorDemographicsSocialHistory().AddProfile();

        // We need to set the Category for NVDRS Demographics Social History Profile.
        observation.Category.Insert(0, VdorCustomCs.Demographics);

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-demographics-social-history";

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
