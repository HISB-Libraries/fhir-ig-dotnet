using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using GaTech.Chai.Vrdr;
using System.ComponentModel;

namespace GaTech.Chai.Vdor;

public class VdorToxicologySummary
{
    readonly Observation observation;

    internal VdorToxicologySummary(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new();
        observation.VdorToxicologySummary().AddFixedValues();
        observation.VdorToxicologySummary().AddProfile();

        return observation;
    }

    public static Observation Create(Patient decedent)
    {
        Observation observation = new();
        observation.VdorToxicologySummary().AddFixedValues();
        observation.VdorToxicologySummary().AddProfile();
        observation.VdorToxicologySummary().SubjectAsResource = decedent;

        return observation;
    }   

    private void AddFixedValues()
    {
        this.observation.Category = [VdorCustomCs.Toxicology];
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-toxicology-summary";

    public Patient? SubjectAsResource
    {
        get
        {
            Record.GetResources().TryGetValue(this.observation.Subject.Reference, out Resource? value);
            return value as Patient;
        }
        set
        {
            this.observation.Subject = value.AsReference();
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }

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

    public CodeableConcept? ToxicologySummaryTested
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.TestPerformed.Coding[0].System, VdorCustomCs.TestPerformed.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }
        set
        {
            if (value != null &&
                (VdorToxSummaryTestedVs.Tested.Matches(value) 
                || VdorToxSummaryTestedVs.NotTested.Matches(value)
                || VdorToxSummaryTestedVs.UnknownToxSummaryTested.Matches(value)))
            {
                this.observation.Component.Add(new Observation.ComponentComponent()
                {
                    Code = VdorCustomCs.TestPerformed,
                    Value = value
                });
            } 
            else
            {
                throw new ArgumentException("Value must be from http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-summary-tested-vs.");
            }
        }
    }

    public CodeableConcept? ToxicologySummaryTestResults
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.TestResults.Coding[0].System, VdorCustomCs.TestResults.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }
        set
        {
            if (value != null &&
                (VdorToxSummaryResultsVs.Present.Matches(value) 
                || VdorToxSummaryResultsVs.NotPresent.Matches(value)
                || VdorToxSummaryResultsVs.NotApplicableToxSummaryResult.Matches(value)
                || VdorToxSummaryResultsVs.UnknownToxSummaryResult.Matches(value)))
            {
                this.observation.Component.Add(new Observation.ComponentComponent()
                {
                    Code = VdorCustomCs.TestResults,
                    Value = value
                });
            }
            else
            {
                throw new ArgumentException("Value must be from http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-summary-results-vs.");
            }
        }
    }
}
