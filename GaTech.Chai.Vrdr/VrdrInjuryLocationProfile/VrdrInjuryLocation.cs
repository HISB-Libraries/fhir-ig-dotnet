using System.Collections.Generic;
using GaTech.Chai.Share;
using GaTech.Chai.Vrcl;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public class VrdrInjuryLocation
{
    readonly Location location;

    internal VrdrInjuryLocation(Location location)
    {
        this.location = location;
    }

    public static Location Create()
    {
        Location location = new Location
        {
            Type = new List<CodeableConcept>() {VrdrLocationTypeCs.InjuryLocation}
        };
        location.VrdrInjuryLocation().AddProfile();

        return location;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Location-vr";

    public void AddProfile()
    {
        this.location.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.location.RemoveProfile(ProfileUrl);
    }
}

