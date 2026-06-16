using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorToxicologySummaryCarbonMonoxide
{
    readonly Observation observation;

    internal VdorToxicologySummaryCarbonMonoxide(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorToxicologySummary.Create();
        observation.VdorToxicologySummary().RemoveProfile();
        observation.VdorToxicologySummaryCarbonMonoxide().AddProfile();
        observation.Code = VdorCustomCs.CarbonMonoxideTestResult;

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-toxicology-summary-carbon-monoxide";

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

    public CodeableConcept? SourceOfCarbonMonoxide
    {
        get
        {
            var component = this.observation.Component.GetComponent(VdorCustomCs.SourceOfCarbonMonoxide.Coding.First().System, VdorCustomCs.SourceOfCarbonMonoxide.Coding.First().Code);
            return component?.Value as CodeableConcept;
        }
        set
        {
            if (VdorToxicologySummaryCarbonMonoxideSourceVs.MotorizedVehicle.Matches(value) 
                || VdorToxicologySummaryCarbonMonoxideSourceVs.Other.Matches(value)
                || VdorToxicologySummaryCarbonMonoxideSourceVs.GasToolApplianceHeater.Matches(value)
                || VdorToxicologySummaryCarbonMonoxideSourceVs.GrillOrBarbeque.Matches(value)
                || VdorToxicologySummaryCarbonMonoxideSourceVs.Fire.Matches(value)
                || VdorToxicologySummaryCarbonMonoxideSourceVs.NotApplicable.Matches(value)
                || VdorToxicologySummaryCarbonMonoxideSourceVs.Unknown.Matches(value))
            {
                var component = this.observation.Component.GetOrAddComponent(VdorCustomCs.SourceOfCarbonMonoxide.Coding.First().System, VdorCustomCs.SourceOfCarbonMonoxide.Coding.First().Code, null);
                component.Value = value;
            } else
            {
                throw new ArgumentException($"Value must be one of the codes from {VdorToxicologySummaryCarbonMonoxideSourceVs.officialUrl}");
            }
        }
    }
}
