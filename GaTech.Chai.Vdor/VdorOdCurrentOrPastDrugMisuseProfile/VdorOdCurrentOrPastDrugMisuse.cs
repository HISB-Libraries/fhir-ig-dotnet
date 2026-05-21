using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.Vdor;

public class VdorOdCurrentOrPastDrugMisuse
{
    readonly Observation observation;

    internal VdorOdCurrentOrPastDrugMisuse(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();
        observation.VdorOdCurrentOrPastDrugMisuse().AddProfile();
        observation.Code = VdorCustomCs.CurrentOrPastPrescriptionDrugMisuseOrIllicitDrugUse;

        return observation;
    }

    public static Observation Create(Patient decedent, string? text)
    {
        Observation observation = VdorOverdose.Create();
        observation.VdorOverdose().RemoveProfile();
        observation.VdorOdBystandersPresent().AddProfile();
        observation.Code = VdorCustomCs.CurrentOrPastPrescriptionDrugMisuseOrIllicitDrugUse;
        observation.VdorOdBystandersPresent().SubjectAsResource = decedent;
        observation.Note = [new Annotation() { Text = text }];

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-od-current-or-past-drug-misuse";

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

    public CodeableConcept? DrugMisuse
    {
        get
        {
            Extension ext = this.observation.GetExtension("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-drug-misuse");
            if (ext == null || ext.Value is not CodeableConcept)
            {
                return null;
            }

            return ext.Value as CodeableConcept;
        }
        set
        {
            if (value != null 
                && (
                    VdorDrugMisuseVs.NoEvidenceOfCurrentOrPastDrugUseMisuse.Matches(value)
                    || VdorDrugMisuseVs.Heroin.Matches(value)
                    || VdorDrugMisuseVs.PrescriptionOpioids.Matches(value)
                    || VdorDrugMisuseVs.UnspecifiedOpioids.Matches(value)
                    || VdorDrugMisuseVs.Fentanyl.Matches(value)
                    || VdorDrugMisuseVs.Cocaine.Matches(value)
                    || VdorDrugMisuseVs.Methamphetamine.Matches(value)
                    || VdorDrugMisuseVs.Benzodiazepines.Matches(value)
                    || VdorDrugMisuseVs.Cannabis.Matches(value)
                    || VdorDrugMisuseVs.SubstancesUnspecified.Matches(value)
                    || VdorDrugMisuseVs.OtherSubstanceSpecify.Matches(value)
                ))
            {
                Extension ext = new("http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-drug-misuse", value);
                this.observation.Extension.AddOrUpdateExtension(ext);
            }
            else
            {
                throw new ArgumentException("Value must be one of the allowed codes from the VdorDrugMisuse value set in http://hl7.org/fhir/us/vdor/ValueSet/vdor-drug-misuse-vs.");
            }
        }
    }
}
