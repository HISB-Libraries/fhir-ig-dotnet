using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.LocationProfile
{
    /// <summary>
    /// Us Core Location Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-location
    /// </summary>
    public class UsCoreLocation
    {
        readonly Location location;

        internal UsCoreLocation(Location location)
        {
            this.location = location;
        }

        /// <summary>
        /// Factory for Us Core Location Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-location
        /// </summary>
        public static Location Create()
        {
            var location = new Location();
            location.UsCoreLocation().AddProfile();
            return location;
        }

        /// <summary>
        /// The official URL for the Us Core Location Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-location";

        /// <summary>
        /// Set profile for Us Core Location Profile
        /// </summary>
        public void AddProfile()
        {
            this.location.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Us Core Location Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.location.RemoveProfile(ProfileUrl);
        }
    }
}
