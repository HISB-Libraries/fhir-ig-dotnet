using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;
using GaTech.Chai.UsCore;

namespace GaTech.Chai.Vrdr
{
    public class VrdrDeathLocation
    {
        readonly Location location;

        internal VrdrDeathLocation(Location location)
        {
            this.location = location;
        }

        /// <summary>
        /// Factory for VrdrDeathLocationProfile
        /// </summary>
        public static Location Create()
        {
            var location = UsCoreLocation.Create();
            location.UsCoreLocation().RemoveProfile();

            location.Type = new List<CodeableConcept> { VrdrLocationTypeCs.DeathLocation };
            location.VrdrDeathLocation().AddProfile();

            return location;
        }

        public static Location Create(string name)
        {
            var location = UsCoreLocation.Create();
            location.UsCoreLocation().RemoveProfile();

            location.Type = new List<CodeableConcept> { VrdrLocationTypeCs.DeathLocation };
            location.VrdrDeathLocation().AddProfile();

            location.Name = name;

            return location;
        }

        /// <summary>
        /// The official URL for the VrdrDeathLocationProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-location";

        /// <summary>
        /// Set profile for the VrdrDeathLocationProfile
        /// </summary>
        public void AddProfile()
        {
            location.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the VrdrDeathLocationProfile
        /// </summary>
        public void RemoveProfile()
        {
            location.RemoveProfile(ProfileUrl);
        }

        public string AddressText
        {
            get
            {
                return this.location.Address?.Text;
            }
            set
            {
                this.location.Address.Text = value;
            }
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
}

