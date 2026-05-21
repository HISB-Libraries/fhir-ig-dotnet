using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdFirstFoundUnresponsive
{
    readonly Observation observation;

    internal VdorOdFirstFoundUnresponsive(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdFirstFoundUnresponsive().AddProfile();
        observation.Code = VdorCustomCs.TimeDateFirstFoundUnresponsive;

        return observation;
    }

    public static Observation Create(Patient decedent, FhirDateTime? value)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdFirstFoundUnresponsive().AddProfile();
        observation.Code = VdorCustomCs.TimeDateFirstFoundUnresponsive;

            observation.VdorOdFirstFoundUnresponsive().SubjectAsResource = decedent;
            observation.VdorOdFirstFoundUnresponsive().ValueOfOdFirstFoundUnresponsive = value;
        
        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-first-found-unresponsive";

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

    public FhirDateTime? ValueOfOdFirstFoundUnresponsive
    {
        get => this.observation.Value as FhirDateTime;
        set => this.observation.Value = value;
    }
}
