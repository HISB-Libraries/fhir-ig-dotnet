using GaTech.Chai.Share;
using GaTech.Chai.Vrcl;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public class VrdrDecedentDispositionMethod
{
    readonly Observation observation;

    internal VrdrDecedentDispositionMethod(Observation observation)
    {
        this.observation = observation;
    }

    public static Observation Create()
    {
        Observation observation = new();
        observation.VrdrDecedentDispositionMethod().AddProfile();
        observation.Status = ObservationStatus.Final;
        observation.Code = new CodeableConcept(UriString.LOINC, "80905-3", "Body disposition method", null);

        return observation;
    }

    public static Observation Create(Patient patient)
    {
        Observation observation = new();
        observation.VrdrDecedentDispositionMethod().AddProfile();
        observation.Status = ObservationStatus.Final;
        observation.Code = new CodeableConcept(UriString.LOINC, "80905-3", "Body disposition method", null);
        observation.VrdrDecedentDispositionMethod().SubjectAsResource = patient;

        return observation;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-decedent-disposition-method";

    public void AddProfile()
    {
        this.observation.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.observation.RemoveProfile(ProfileUrl);
    }

    public Patient SubjectAsResource
    {
        get
        {
        Record.GetResources().TryGetValue(this.observation.Subject.Reference, out Resource value);

        return (Patient)value;
        }
        set
        {
            this.observation.Subject = value.AsReference();
            Record.GetResources()[value.AsReference().Reference] = value;
        }
    }
}

