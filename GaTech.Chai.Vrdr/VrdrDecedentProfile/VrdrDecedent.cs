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
}

