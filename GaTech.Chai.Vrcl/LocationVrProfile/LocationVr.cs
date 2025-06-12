using System;
using System.Collections.Generic;
using GaTech.Chai.UsCore;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl
{
	public class LocationVr
	{
		readonly Location location;

        internal LocationVr(Location location)
		{
			this.location = location;
		}

		public static Location Create()
		{
			Location location = UsCoreLocation.Create();
            location.UsCoreLocation().RemoveProfile();
            location.LocationVr().AddProfile();

            return location;
		}

		public static Location Create(string name)
		{
			Location location = UsCoreLocation.Create();
            location.UsCoreLocation().RemoveProfile();
            location.LocationVr().AddProfile();

            location.Name = name;
            
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
}

