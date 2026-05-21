using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdTypeOfOverdose
{
    readonly Observation observation;

    internal VdorOdTypeOfOverdose(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdTypeOfOverdose().AddProfile();
        observation.Code = VdorCustomCs.TypeOfOverdosePoisoning;

        return observation;
    }

    public static Observation Create(Patient decedent, CodeableConcept? value, CodeableConcept? typeOfTreatment = null, string? noteText = null)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdTypeOfOverdose().AddProfile();
        observation.Code = VdorCustomCs.TypeOfOverdosePoisoning;

        observation.VdorOdTypeOfOverdose().SubjectAsResource = decedent;
        observation.VdorOdTypeOfOverdose().ValueOfTypeOfOverdose = value;
        if (!string.IsNullOrEmpty(noteText))
        {
            observation.VdorOdTypeOfOverdose().Note = new Annotation
            {
                Text = noteText
            };
        }

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-type-of-overdose";

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

    public CodeableConcept? ValueOfTypeOfOverdose
    {
        get => this.observation.Value as CodeableConcept;
        set
        {
            if (VdorTypeOfOverdoseVs.OverdoseRelatedToSubstanceUseOrMisuse.Matches(value)
            || VdorTypeOfOverdoseVs.VictimUnintentionallyTakesADrugOrWrongDosage.Matches(value)
            || VdorTypeOfOverdoseVs.Overmedication.Matches(value)
            || VdorTypeOfOverdoseVs.TookPrescribedDosage.Matches(value)
            || VdorTypeOfOverdoseVs.OtherPleaseAddInformationToNarrative.Matches(value)
            || VdorTypeOfOverdoseVs.UnknownTypeOfOD.Matches(value))
            {
                this.observation.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-type-of-overdose-vs");
            }
        }
    }

    public Annotation? Note
    {
        get => this.observation.Note.FirstOrDefault();
        set
        {
            if (value != null)
            {
                if (this.observation.Note.Count == 0)
                {
                    this.observation.Note.Add(value);
                }
                else
                {
                    this.observation.Note[0] = value;
                }
            }
            else
            {
                this.observation.Note.Clear();
            }
        }
    }
}
