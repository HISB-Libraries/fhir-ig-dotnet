using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorToxicologySummaryAlcohol
{
    readonly Observation observation;

    internal VdorToxicologySummaryAlcohol(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorToxicologySummary.Create();
        observation.VdorToxicologySummary().RemoveProfile();
        observation.VdorToxicologySummaryAlcohol().AddProfile();
        observation.Code = VdorCustomCs.AlcoholTestResultBAC;

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-toxicology-summary-alcohol";

    /// <summary>
    /// Set profile for the Vdor Current Depressed Mood
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

    public Quantity? BloodAlcoholContent
    {
        get
        {
            var component = this.observation.Component.GetComponent(VdorCustomCs.AlcoholTestResultBAC.Coding.First().System, VdorCustomCs.AlcoholTestResultBAC.Coding.First().Code);
            return component?.Value as Quantity;
        }
        set
        {
            var component = this.observation.Component.GetOrAddComponent(VdorCustomCs.AlcoholTestResultBAC.Coding.First().System, VdorCustomCs.AlcoholTestResultBAC.Coding.First().Code, null);
            component.Value = value;
        }
    }
}
