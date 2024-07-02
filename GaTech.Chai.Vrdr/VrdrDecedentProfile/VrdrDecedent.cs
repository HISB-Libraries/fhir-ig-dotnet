using GaTech.Chai.Share;
using GaTech.Chai.Vrcl;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public class VrdrDecedent
{
    readonly Patient patient;

    internal VrdrDecedent(Patient patient)
    {
        this.patient = patient;
    }

    public static Patient Create()
    {
        Patient patient = PatientVr.Create();
        patient.PatientVr().RemoveProfile();

        patient.VrdrDecedent().AddProfile();

        return patient;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-cause-of-death-part2";

    public void AddProfile()
    {
        this.patient.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.patient.RemoveProfile(ProfileUrl);
    }

    public CodeableConcept NVSSSexAtDeath
    {
        get
        {
            Extension ext = this.patient.GetExtension("http://hl7.org/fhir/us/vrdr/StructureDefinition/NVSS-SexAtDeath");
            if (ext != null)
            {
                return ext.Value as CodeableConcept;
            }

            return null;
        }

        set
        {
            Extension ext = this.patient.GetExtension(VrdrUrls.NVSSSexAtDeathUrl);
            if (ext != null)
            {
                ext.Value = value;
            }
            else 
            {
                this.patient.AddExtension(VrdrUrls.NVSSSexAtDeathUrl, value);
            }
        }
    }
}

