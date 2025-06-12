using System.Collections.Generic;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;
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
        Location location = UsCoreLocation.Create();
        location.UsCoreLocation().RemoveProfile();

        location.Type = new List<CodeableConcept>() { VrdrLocationTypeCs.InjuryLocation };
        location.VrdrInjuryLocation().AddProfile();

        return location;
    }

    public static Location Create(string name)
    {
        Location location = UsCoreLocation.Create();
        location.UsCoreLocation().RemoveProfile();

        location.Type = new List<CodeableConcept>() { VrdrLocationTypeCs.InjuryLocation };
        location.VrdrInjuryLocation().AddProfile();

        location.Name = name;

        return location;
    }

    public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-injury-location";

    public void AddProfile()
    {
        this.location.AddProfile(ProfileUrl);
    }

    public void RemoveProfile()
    {
        this.location.RemoveProfile(ProfileUrl);
    }
    
    /// <summary>
    /// (float Latitude, float Longitutde)
    /// </summary>
    public (float, float) Position
    {
        get
        {
            return (((float)this.location.Position?.Latitude), ((float)this.location.Position?.Latitude));
        }
        set
        {
            this.location.Position = new Location.PositionComponent { Latitude = new decimal(value.Item1), Longitude = new decimal(value.Item2)};
        }
    }

}

