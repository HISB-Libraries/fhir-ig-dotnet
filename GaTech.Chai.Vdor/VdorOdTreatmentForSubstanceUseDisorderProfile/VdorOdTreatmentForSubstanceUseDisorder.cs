using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdTreatmentForSubstanceUseDisorder
{
    readonly Observation observation;

    internal VdorOdTreatmentForSubstanceUseDisorder(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdTreatmentForSubstanceUseDisorder().AddProfile();
        observation.Code = VdorCustomCs.TreatmentForSubstanceUseDisorder;

        return observation;
    }

    public static Observation Create(Patient decedent, CodeableConcept? value, CodeableConcept? typeOfTreatment = null, string? noteText = null)
    {
        Observation observation =  VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();

        observation.VdorOdTreatmentForSubstanceUseDisorder().AddProfile();
        observation.Code = VdorCustomCs.TreatmentForSubstanceUseDisorder;

        observation.VdorOdTreatmentForSubstanceUseDisorder().SubjectAsResource = decedent;
        observation.VdorOdTreatmentForSubstanceUseDisorder().ValueOfTreatmentForSubstanceUseDisorder = value;
        observation.VdorOdTreatmentForSubstanceUseDisorder().TypeOfTreatment = typeOfTreatment;
        if (!string.IsNullOrEmpty(noteText))
        {
            observation.VdorOdTreatmentForSubstanceUseDisorder().Note = new Annotation
            {
                Text = noteText
            };
        }

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-treatment-for-substance-use-disorder";

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

    public CodeableConcept? ValueOfTreatmentForSubstanceUseDisorder
    {
        get => this.observation.Value as CodeableConcept;
        set
        {
            if (VdorTreatmentForSubstanceUseDisorderVs.NoEvidenceOfTreatment.Matches(value)
            || VdorTreatmentForSubstanceUseDisorderVs.CurrentTreatment.Matches(value)
            || VdorTreatmentForSubstanceUseDisorderVs.NoCurrentTreatmentButTreatedInPast.Matches(value))
            {
                this.observation.Value = value;
            }
            else
            {
                throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-treatment-for-substance-use-disorder-vs");
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

    public CodeableConcept? TypeOfTreatment
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-types-of-substance-use-disorder-treatments");
            return ext != null ? ext.Value as CodeableConcept : null;
        }
        set
        {
            if (value != null)
            {
                if (VdorCustomCs.InpatientOutpatientRehabilitation.Matches(value)
                || VdorCustomCs.MATWithCognitiveBehavioralTherapy.Matches(value)
                || VdorCustomCs.MATWithoutCognitiveBehavioralTherapy.Matches(value)
                || VdorCustomCs.MATCognitiveBehavioralTherapyUnknown.Matches(value)
                || VdorCustomCs.CognitiveBehavioralTherapy.Matches(value)
                || VdorCustomCs.NarcoticsAnonymous.Matches(value)
                || VdorCustomCs.OtherSpecify.Matches(value))
                {
                    this.observation.Value = value;
                }
                else
                {
                    throw new ArgumentException("Value must be one of the value in the value set, http://hl7.org/fhir/us/vdor/ValueSet/vdor-types-of-treatment-for-substance-use-disorder-vs");
                }

                Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-types-of-substance-use-disorder-treatments");
                if (ext == null)
                {
                    ext = new Extension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-types-of-substance-use-disorder-treatments", value);
                    this.observation.Extension.Add(ext);
                }
                else
                {
                    ext.Value = value;
                }
            }
            else
            {
                this.observation.Extension.RemoveAll(e => e.Url == "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-types-of-substance-use-disorder-treatments");
            }
        }
    }
}
