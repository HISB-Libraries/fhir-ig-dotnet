using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdPreviousOverdose
{
    readonly Observation observation;

    internal VdorOdPreviousOverdose(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdPreviousOverdose().AddProfile();
        observation.Code = VdorCustomCs.PreviousOverdose;

        return observation;
    }

    public static Observation Create(Patient decedent, CodeableConcept? value)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdPreviousOverdose().AddProfile();
        observation.Code = VdorCustomCs.PreviousOverdose;

        observation.VdorOdPreviousOverdose().SubjectAsResource = decedent;
        observation.VdorOdPreviousOverdose().ValueOfPreviousOverdose = value;
        
        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-previous-overdose";

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

    public CodeableConcept? ValueOfPreviousOverdose
    {
        get => this.observation.Value as CodeableConcept;
        set
        {
            if (VdorPreviousOverdoseVs.NoPreviousOdReported.Matches(value)
            || VdorPreviousOverdoseVs.PreviousOdWithinLastMonth.Matches(value)
            || VdorPreviousOverdoseVs.PreviousOdOccurredBetweenAMonthAndAYearAgo.Matches(value)
            || VdorPreviousOverdoseVs.PreviousOdOccurredMoreThanAYearAgo.Matches(value)
            || VdorPreviousOverdoseVs.PreviousOdTimingUnknown.Matches(value))
            {
                this.observation.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-previous-overdose-vs");
            }
        }
    }

    public CodeableConcept? PreviousOverdoseTiming
    {
        get
        {
            var component = this.observation.Component.GetComponent(VdorCustomCs.PreviousOverdoseTiming.Coding.First().System, VdorCustomCs.PreviousOverdoseTiming.Coding.First().Code);
            return component?.Value as CodeableConcept;
        }
        set
        {
            if (VdorPreviousOverdoseTimingVs.PreviousOdOccurredBetween0And2DaysEarlier.Matches(value)
            || VdorPreviousOverdoseTimingVs.PreviousOdOccurredBetween3And7DaysEarlier.Matches(value))
            {
                var component = this.observation.Component.GetOrAddComponent(VdorCustomCs.PreviousOverdoseTiming.Coding.First().System, VdorCustomCs.PreviousOverdoseTiming.Coding.First().Code, null);
                component.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-previous-overdose-timing-vs");
            }
        }
    }
}
