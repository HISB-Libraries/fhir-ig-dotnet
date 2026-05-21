using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdBystandersPresent
{
    readonly Observation observation;

    internal VdorOdBystandersPresent(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();
        observation.VdorOdBystandersPresent().AddProfile();
        observation.Code = VdorCustomCs.BystandersPresent;

        return observation;
    }

    public static Observation Create(Patient decedent, CodeableConcept? value)
    {
        Observation observation = VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();
        observation.VdorOdBystandersPresent().AddProfile();
        observation.Code = VdorCustomCs.BystandersPresent;
        observation.VdorOdBystandersPresent().SubjectAsResource = decedent;
        observation.Value = value;

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-bystanders-present";

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

    public CodeableConcept? ValueOfOdBystandersPresent
    {
        get { return this.observation.Value as CodeableConcept; }
        set 
        { 
            if (VdorBystandersPresentVs.NoBystandersPresent.Matches(value) 
                || VdorBystandersPresentVs.OneBystanderPresent.Matches(value) 
                || VdorBystandersPresentVs.MultipleBystandersPresent.Matches(value) 
                || VdorBystandersPresentVs.BystandersPresentUnknownNumber.Matches(value)
                || VdorBystandersPresentVs.UnknownIfBystanderPresent.Matches(value))
            {
                this.observation.Value = value; 
            }
            else
            {
                throw new ArgumentException($"Value must be one of the valueset in http://hl7.org/fhir/us/vdor/ValueSet/vdor-bystanders-present-vs");
            }
        }
    }
}
