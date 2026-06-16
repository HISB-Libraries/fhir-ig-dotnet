using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using GaTech.Chai.Mdi;

namespace GaTech.Chai.Vdor;

public class VdorToxicologySpecimen
{
    readonly Specimen specimen;

    internal VdorToxicologySpecimen(Specimen specimen)
    {
        this.specimen = specimen;
    }

    public static Specimen Create()
    {
        Specimen specimen = SpecimenToxicologyLab.Create();
        specimen.SpecimenToxicologyLab().RemoveProfile();

        specimen.VdorToxicologySpecimen().AddProfile();

        return specimen;
    }

    public static Specimen Create(Patient subject)
    {
        Specimen specimen = SpecimenToxicologyLab.Create();
        specimen.SpecimenToxicologyLab().RemoveProfile();
        specimen.VdorToxicologySpecimen().AddProfile();
        specimen.VdorToxicologySpecimen().SubjectAsResource = subject;

        return specimen;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vdor/StructureDefinition/vdor-toxicology-specimen";

    /// <summary>
    /// Set profile for the Vdor Current Depressed Mood
    /// </summary>
    public void AddProfile()
    {
        this.specimen.AddProfile(ProfileUrl);
    }

    /// <summary>
    /// Clear profile for the Nvdrs Current Depressed Mood
    /// </summary>
    public void RemoveProfile()
    {
        this.specimen.RemoveProfile(ProfileUrl);
    }

    public Patient? SubjectAsResource
    {
        get
        {
            Record.GetResources().TryGetValue(this.specimen.Subject.Reference, out Resource? value);
            return value as Patient;
        }
        set
        {
            this.specimen.Subject = value.AsReference();
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }
}
