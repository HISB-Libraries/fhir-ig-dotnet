using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Share.Extensions
{
    /// <summary>
    /// Resource extension to add Profile URL to FHIR Resource
    /// </summary>
    public static class FhirResourceExtensions
    {
        /// <summary>
        /// Set the assertion that a resource object conforms to the given profile.
        /// </summary>
        public static void AddProfile(this Resource resource, string profileUrl)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (resource.Meta == null)
            {
                resource.Meta = new Meta();
            }

            if ((resource.Meta.Profile == null) || (!resource.Meta.Profile.Any()))
            {
                resource.Meta.Profile = new List<string>()
                    {
                      profileUrl,
                    };
                return;
            }

            if (resource.Meta.Profile.Contains(profileUrl))
            {
                return;
            }

            resource.Meta.Profile = resource.Meta.Profile.Append(profileUrl);
        }

        /// <summary>
        /// Check if the profile exists in this resource
        /// </summary>
        public static bool hasProfile(this Resource resource, string profileUrl)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (resource.Meta == null)
            {
                return false;
            }

            if ((resource.Meta.Profile == null) || (!resource.Meta.Profile.Any()))
            {
                return false;
            }

            if (resource.Meta.Profile.Contains(profileUrl))
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Clear the assertion that a patient object conforms to the US Core Patient Profile.
        /// </summary>
        public static void RemoveProfile(this Resource resource, string profileUrl)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            if (resource.Meta == null)
            {
                return;
            }

            // set last updated so that meta is never empty
            resource.Meta.LastUpdated = DateTimeOffset.Now;

            if ((resource.Meta.Profile == null) || (!resource.Meta.Profile.Any()))
            {
                return;
            }

            if (resource.Meta.Profile.Contains(profileUrl))
            {
                int index = 0;
                foreach (var profile in resource.Meta.Profile)
                {
                    if (profile.Equals(profileUrl, StringComparison.Ordinal))
                    {
                        break;
                    }

                    index++;
                }

                resource.Meta.ProfileElement.RemoveAt(index);
            }
        }

        /// <summary>
        /// Get Reference to Resource
        /// </summary>
        /// <returns></returns>
        public static ResourceReference AsReference(this Resource resource, string display=null)
        {
            if (string.IsNullOrEmpty(resource.Id))
                resource.Id = Guid.NewGuid().ToString();
            return new ResourceReference($"{resource.TypeName}/{resource.Id}", display);
        }
    }
}