using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorToxicologyFinding
{
    readonly Observation observation;

    internal VdorToxicologyFinding(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorToxicology.Create();
        observation.VdorToxicology().RemoveProfile();

        observation.VdorToxicologyFinding().AddProfile();
        observation.Code = VdorCustomCs.ToxicologyFindings;

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-toxicology-findings";

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

    public string? SubstanceName
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.SubstanceName.Coding[0].System, VdorCustomCs.SubstanceName.Coding[0].Code);
            return component?.Value.ToString();
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.SubstanceName.Coding[0].System, VdorCustomCs.SubstanceName.Coding[0].Code, VdorCustomCs.SubstanceName.Coding[0].Display);
            component.Value = new FhirString(value);
        }
    }

    public CodeableConcept? SubstanceTested
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.SubstanceTested.Coding[0].System, VdorCustomCs.SubstanceTested.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }

        set
        {
            if (VdorToxSubstanceTestedVs.Tested.Matches(value)
                || VdorToxSubstanceTestedVs.NotTested.Matches(value)
                || VdorToxSubstanceTestedVs.Unknown.Matches(value))
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.SubstanceTested.Coding[0].System, VdorCustomCs.SubstanceTested.Coding[0].Code, VdorCustomCs.SubstanceTested.Coding[0].Display);
                component.Value = value;
            }
            else
            {
                throw new ArgumentException($"Value must match one of the following: {VdorToxSubstanceTestedVs.Tested.Coding[0].Code}, {VdorToxSubstanceTestedVs.NotTested.Coding[0].Code}, {VdorToxSubstanceTestedVs.Unknown.Coding[0].Code}");
            }
        }
    }

    public CodeableConcept? SubstanceResult
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.SubstanceResult.Coding[0].System, VdorCustomCs.SubstanceResult.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }

        set
        {
            if (VdorToxFindingsSubstanceResultsVs.Present.Matches(value)
                || VdorToxFindingsSubstanceResultsVs.NotPresent.Matches(value)
                || VdorToxFindingsSubstanceResultsVs.NotApplicable.Matches(value)
                || VdorToxFindingsSubstanceResultsVs.Unknown.Matches(value))
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.SubstanceResult.Coding[0].System, VdorCustomCs.SubstanceResult.Coding[0].Code, VdorCustomCs.SubstanceResult.Coding[0].Display);
                component.Value = value;
            }
            else
            {
                throw new ArgumentException($"Value must match one of the following: {VdorToxFindingsSubstanceResultsVs.Present.Coding[0].Code}, {VdorToxFindingsSubstanceResultsVs.NotPresent.Coding[0].Code}, {VdorToxFindingsSubstanceResultsVs.NotApplicable.Coding[0].Code}, {VdorToxFindingsSubstanceResultsVs.Unknown.Coding[0].Code}");
            }
        }
    }

    public bool? SubstanceCausedDeath
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.SubstanceCausedDeath.Coding[0].System, VdorCustomCs.SubstanceCausedDeath.Coding[0].Code);
            return (component?.Value as FhirBoolean)?.Value;
        }

        set
        {
            Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.SubstanceCausedDeath.Coding[0].System, VdorCustomCs.SubstanceCausedDeath.Coding[0].Code, VdorCustomCs.SubstanceCausedDeath.Coding[0].Display);
            component.Value = new FhirBoolean(value);
        }
    }

    public CodeableConcept? DrugObtainedFor
    {
        get
        {
            Observation.ComponentComponent component = this.observation.Component.GetComponent(VdorCustomCs.DrugObtainedFor.Coding[0].System, VdorCustomCs.DrugObtainedFor.Coding[0].Code);
            return component?.Value as CodeableConcept;
        }

        set
        {
            if (VdorToxFindingsDrugObtainedForVs.Self.Matches(value)
                || VdorToxFindingsDrugObtainedForVs.IntimatePartner.Matches(value)
                || VdorToxFindingsDrugObtainedForVs.Family.Matches(value)
                || VdorToxFindingsDrugObtainedForVs.Other.Matches(value)
                || VdorToxFindingsDrugObtainedForVs.NotApplicable.Matches(value)
                || VdorToxFindingsDrugObtainedForVs.RelationshipUnknown.Matches(value))
            {
                Observation.ComponentComponent component = this.observation.Component.GetOrAddComponent(VdorCustomCs.DrugObtainedFor.Coding[0].System, VdorCustomCs.DrugObtainedFor.Coding[0].Code, VdorCustomCs.DrugObtainedFor.Coding[0].Display);
                component.Value = value;
            }
            else
            {
                throw new ArgumentException($"Value must match one of the following: {VdorToxFindingsDrugObtainedForVs.Self.Coding[0].Code}, {VdorToxFindingsDrugObtainedForVs.IntimatePartner.Coding[0].Code}, {VdorToxFindingsDrugObtainedForVs.Family.Coding[0].Code}, {VdorToxFindingsDrugObtainedForVs.Other.Coding[0].Code}, {VdorToxFindingsDrugObtainedForVs.NotApplicable.Coding[0].Code}, {VdorToxFindingsDrugObtainedForVs.RelationshipUnknown.Coding[0].Code}");
            }
        }
    }
}
