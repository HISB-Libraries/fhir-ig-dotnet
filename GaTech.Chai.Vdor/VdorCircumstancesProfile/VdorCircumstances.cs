using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorCircumstances
{
    readonly Observation observation;

    internal VdorCircumstances(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new()
        {
            Category = [VdorCustomCs.Circumstances]
        };

        observation.VdorCircumstances().AddProfile();
        
        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-circumstances";

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
