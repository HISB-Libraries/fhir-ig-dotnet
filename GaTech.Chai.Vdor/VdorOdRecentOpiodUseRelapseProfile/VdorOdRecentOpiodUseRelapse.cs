using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdRecentOpiodUseRelapse
{
    readonly Observation observation;

    internal VdorOdRecentOpiodUseRelapse(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdRecentOpiodUseRelapse().AddProfile();
        observation.Code = VdorCustomCs.PreviousOverdose;

        return observation;
    }

    public static Observation Create(Patient decedent, CodeableConcept? value)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdRecentOpiodUseRelapse().AddProfile();
        observation.Code = VdorCustomCs.PreviousOverdose;

            observation.VdorOdRecentOpiodUseRelapse().SubjectAsResource = decedent;
            observation.VdorOdRecentOpiodUseRelapse().ValueOfRecentOpiodUseRelapse = value;
        
        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-recent-opiod-use-relapse";

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

    public CodeableConcept? ValueOfRecentOpiodUseRelapse
    {
        get => this.observation.Value as CodeableConcept;
        set
        {
            if (VdorRecentOpioidUseRelapseVs.OverdoseRelatedToSubstanceUseOrMisuse.Matches(value)
            || VdorRecentOpioidUseRelapseVs.NoEvidence.Matches(value)
            || VdorRecentOpioidUseRelapseVs.RelapseOccurredLessThan2WeeksBeforeFatalOverdose.Matches(value)
            || VdorRecentOpioidUseRelapseVs.RelapseOccurredBetween2WeeksAndLessThan3MonthsBeforeFatalOverdose.Matches(value)
            || VdorRecentOpioidUseRelapseVs.RelapseMentionedTimingUnclear.Matches(value))
            {
                this.observation.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-recent-opiod-use-relapse-vs");
            }
        }
    }
}
