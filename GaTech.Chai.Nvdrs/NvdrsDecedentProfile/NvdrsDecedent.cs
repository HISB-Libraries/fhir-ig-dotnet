using GaTech.Chai.Share;
using GaTech.Chai.Vrdr;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public class NvdrsDecedent
{
    readonly Patient patient;

    internal NvdrsDecedent(Patient patient)
    {
        this.patient = patient;
    }

    public static Patient Create()
    {
        Patient patient = VrdrDecedent.Create();
        patient.VrdrDecedent().RemoveProfile();
        patient.NvdrsDecedent().AddProfile();

        return patient;
    }

    public const string ProfileUrl = "http://mortalityreporting.github.io/nvdrs-ig/StructureDefinition/nvdrs-decedent";

    public void AddProfile()
    {
        this.patient.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.patient.RemoveProfile(ProfileUrl);
    }

}
