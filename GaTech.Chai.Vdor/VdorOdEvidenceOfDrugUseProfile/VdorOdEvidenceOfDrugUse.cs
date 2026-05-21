using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdEvidenceOfDrugUse
{
    readonly Observation observation;

    internal VdorOdEvidenceOfDrugUse(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdEvidenceOfDrugUse().AddProfile();
        observation.Code = VdorCustomCs.EvidenceOfDrugUse;

        return observation;
    }

    public static Observation Create(Patient decedent, Boolean? value)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdEvidenceOfDrugUse().AddProfile();
        observation.Code = VdorCustomCs.EvidenceOfDrugUse;

        observation.VdorOdEvidenceOfDrugUse().SubjectAsResource = decedent;
        observation.VdorOdEvidenceOfDrugUse().ValueOfEvidenceOfDrugUse = value;
        
        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-evidence-of-drug-use";

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

    public Boolean? ValueOfEvidenceOfDrugUse
    {
        get => (this.observation.Value as FhirBoolean)?.Value;
        set => this.observation.Value = new FhirBoolean(value);
    }
}
