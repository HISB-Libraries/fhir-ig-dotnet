using GaTech.Chai.Share.Extensions;
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
        var patient = new Patient();
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
