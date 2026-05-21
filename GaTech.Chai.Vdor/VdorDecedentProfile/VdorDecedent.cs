using GaTech.Chai.Share;
using GaTech.Chai.Vrdr;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor;

public class VdorDecedent
{
    readonly Patient patient;

    internal VdorDecedent(Patient patient)
    {
        this.patient = patient;
    }

    public static Patient Create()
    {
        Patient patient = VrdrDecedent.Create();
        patient.VrdrDecedent().RemoveProfile();
        patient.VdorDecedent().AddProfile();

        return patient;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-decedent";

    public void AddProfile()
    {
        this.patient.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.patient.RemoveProfile(ProfileUrl);
    }

}
