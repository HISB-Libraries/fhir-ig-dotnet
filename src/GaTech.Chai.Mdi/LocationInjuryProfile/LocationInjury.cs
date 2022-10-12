using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.UsCore.LocationProfile;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.LocationInjuryProfile
{
    public class LocationInjury
    {
        readonly Location location;
        readonly static Dictionary<string, Resource> resources = new();

        internal LocationInjury(Location location)
        {
            this.location = location;
            if (location.Type?.Count > 1)
            {
                location.Type.Clear();
                location.Type.Add(MdiCodeSystem.MdiCodes.Injury);
            }
            else if (location.Type?.Count > 0)
            {
                location.Type[0] = MdiCodeSystem.MdiCodes.Injury;
            }
            else
            {
                location.Type.Add(MdiCodeSystem.MdiCodes.Injury);
            }

            location.UsCoreLocation().AddProfile();
        }

        /// <summary>
        /// Factory for LocationDeathProfile
        /// </summary>
        public static Location Create()
        {
            var location = new Location();
            location.LocationInjury().AddProfile();

            return location;
        }

        /// <summary>
        /// The official URL for the LocationInjuryProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Location-injury";

        /// <summary>
        /// Set profile for the LocationInjuryProfile
        /// </summary>
        public void AddProfile()
        {
            location.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the LocationInjuryProfile
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

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}

