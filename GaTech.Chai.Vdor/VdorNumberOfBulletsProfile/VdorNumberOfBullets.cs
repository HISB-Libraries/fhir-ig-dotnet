using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public class VdorNumberOfBullets
{
    readonly Observation observation;

    internal VdorNumberOfBullets(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorInjuryAndDeath.Create();
        observation.VdorInjuryAndDeath().RemoveProfile();
        observation.Code = VdorCustomCs.NumberOfBullets;

        observation.VdorNumberOfBullets().AddProfile();

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-number-of-bullets";

    /// <summary>
    /// Set profile for the Vdor Current Depressed Mood
    /// </summary>
    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the Vdor Current Depressed Mood
    /// </summary>
    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

    public int? NumOfBullets
    {
        get { return (this.observation.Value as Integer)?.Value; }
        set { this.observation.Value = new Integer(value); }
    }
}
