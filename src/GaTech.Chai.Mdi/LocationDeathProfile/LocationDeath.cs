using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.UsCore.LocationProfile;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.LocationDeathProfile
{
    public class LocationDeath
    {
        readonly Location location;
        readonly static Dictionary<string, Resource> resources = new();

        internal LocationDeath(Location location)
        {
            this.location = location;
            if (location.Type?.Count > 1)
            {
                location.Type.Clear();
                location.Type.Add(MdiCodeSystem.MdiCodes.Death);
            }
            else if (location.Type?.Count > 0)
            {
                location.Type[0] = MdiCodeSystem.MdiCodes.Death;
            }
            else
            {
                location.Type.Add(MdiCodeSystem.MdiCodes.Death);
            }
        }

        /// <summary>
        /// Factory for LocationDeathProfile
        /// </summary>
        public static Location Create()
        {
            var location = new Location();
            location.LocationDeath().AddProfile();

            return location;
        }

        /// <summary>
        /// The official URL for the LocationDeathProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Location-death";

        /// <summary>
        /// Set profile for the LocationDeathProfile
        /// </summary>
        public void AddProfile()
        {
            location.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the LocationDeathProfile
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

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}

