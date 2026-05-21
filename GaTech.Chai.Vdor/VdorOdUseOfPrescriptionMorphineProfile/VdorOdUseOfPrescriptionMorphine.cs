using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdUseOfPrescriptionMorphine
{
    readonly Observation observation;

    internal VdorOdUseOfPrescriptionMorphine(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdUseOfPrescriptionMorphine().AddProfile();
        observation.Code = VdorCustomCs.UseOfPrescriptionMorphine;

        return observation;
    }

    public static Observation Create(Patient decedent, CodeableConcept? value, CodeableConcept? typeOfTreatment = null, string? noteText = null)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdUseOfPrescriptionMorphine().AddProfile();
        observation.Code = VdorCustomCs.UseOfPrescriptionMorphine;

        observation.VdorOdUseOfPrescriptionMorphine().SubjectAsResource = decedent;
        observation.VdorOdUseOfPrescriptionMorphine().ValueOfUseOfPrescriptionMorphine = value;
        if (!string.IsNullOrEmpty(noteText))
        {
            observation.VdorOdUseOfPrescriptionMorphine().Note = new Annotation
            {
                Text = noteText
            };
        }

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-use-of-prescription-morphine";

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

    public CodeableConcept? ValueOfUseOfPrescriptionMorphine
    {
        get => this.observation.Value as CodeableConcept;
        set
        {
            if (VdorUseOfPrescriptionMorphineVs.None.Matches(value)
            || VdorUseOfPrescriptionMorphineVs.EvidenceOfMorphinePrescriptionDispensedWithinLast30Days.Matches(value)
            || VdorUseOfPrescriptionMorphineVs.PrescriptionMorphineFoundAtScene.Matches(value)
            || VdorUseOfPrescriptionMorphineVs.BothPrescriptionAndSceneEvidence.Matches(value)
            || VdorUseOfPrescriptionMorphineVs.OtherEvidence.Matches(value))
            {
                this.observation.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-use-of-prescription-morphine-vs");
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
