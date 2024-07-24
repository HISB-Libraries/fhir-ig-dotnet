using System.Collections.Generic;
using GaTech.Chai.Share;
using GaTech.Chai.Vrcl;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public class VrdrCertifier
{
    readonly Practitioner practitioner;

    internal VrdrCertifier(Practitioner practitioner)
    {
        this.practitioner = practitioner;
    }

    public static Practitioner Create()
    {
        Practitioner practitioner = PractitionerVr.Create();
        practitioner.PractitionerVr().RemoveProfile();

        practitioner.AddExtension("http://hl7.org/fhir/us/vrdr/StructureDefinition/practitioner-role", new Code("Certifier"));
        practitioner.VrdrCertifier().AddProfile();

        return practitioner;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-certifier";

    public void AddProfile()
    {
        this.practitioner.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.practitioner.RemoveProfile(ProfileUrl);
    }
}

