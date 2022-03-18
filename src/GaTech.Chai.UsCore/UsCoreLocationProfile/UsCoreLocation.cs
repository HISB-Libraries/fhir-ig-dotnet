using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.LocationProfile
{
    /// <summary>
    /// Us Core Location Profile Extensions
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
        /// Factory for US Core Practitioner Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-location
        /// </summary>
        public static Location Create()
        {
            var location = new Location();
            location.UsCoreLocation().AddProfile();
            return location;
        }

        /// <summary>
        /// The official URL for the US Core Practitioner profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-location";

        /// <summary>
        /// Set the assertion that an practitioner object conforms to the US Core Practitioner profile.
        /// </summary>
        public void AddProfile()
        {
            this.location.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the US Core Practitioner profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.location.RemoveProfile(ProfileUrl);
        }
    }
}
