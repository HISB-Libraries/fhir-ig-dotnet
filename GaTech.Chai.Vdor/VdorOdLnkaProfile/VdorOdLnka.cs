using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdLnka
{
    readonly Observation observation;

    internal VdorOdLnka(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdLnka().AddProfile();
        observation.Code = VdorCustomCs.TimeDateLastKnownAliveAndWellPreOverdose;

        return observation;
    }

    public static Observation Create(Patient decedent, FhirDateTime? value)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdLnka().AddProfile();
        observation.Code = VdorCustomCs.TimeDateLastKnownAliveAndWellPreOverdose;

            observation.VdorOdLnka().SubjectAsResource = decedent;
            observation.VdorOdLnka().ValueOfOdLnka = value;
        
        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-lnka";

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

    public FhirDateTime? ValueOfOdLnka
    {
        get => this.observation.Value as FhirDateTime;
        set => this.observation.Value = value;
    }
}
