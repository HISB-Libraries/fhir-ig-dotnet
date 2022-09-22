using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;

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

        /// <summary>
        /// State in Two Letters
        /// </summary>
        public string TwoLetterStateFor(string longStateName)
        {
            if (longStateName.Equals("Alabama", StringComparison.OrdinalIgnoreCase))
            {
                return "AL";
            }
            else if (longStateName.Equals("Alaska", StringComparison.OrdinalIgnoreCase))
            {
                return "AK";
            }
            else if (longStateName.Equals("American Samoa", StringComparison.OrdinalIgnoreCase))
            {
                return "AS";
            }
            else if (longStateName.Equals("Arizona", StringComparison.OrdinalIgnoreCase))
            {
                return "AZ";
            }
            else if (longStateName.Equals("Arkansas", StringComparison.OrdinalIgnoreCase))
            {
                return "AR";
            }
            else if (longStateName.Equals("California", StringComparison.OrdinalIgnoreCase))
            {
                return "CA";
            }
            else if (longStateName.Equals("Colorado", StringComparison.OrdinalIgnoreCase))
            {
                return "CO";
            }
            else if (longStateName.Equals("Connecticut", StringComparison.OrdinalIgnoreCase))
            {
                return "CT";
            }
            else if (longStateName.Equals("Delaware", StringComparison.OrdinalIgnoreCase))
            {
                return "DE";
            }
            else if (longStateName.Equals("District of Columbia", StringComparison.OrdinalIgnoreCase))
            {
                return "DC";
            }
            else if (longStateName.Equals("Federated States of Micronesia", StringComparison.OrdinalIgnoreCase))
            {
                return "FM";
            }
            else if (longStateName.Equals("Florida", StringComparison.OrdinalIgnoreCase))
            {
                return "FL";
            }
            else if (longStateName.Equals("Georgia", StringComparison.OrdinalIgnoreCase))
            {
                return "GA";
            }
            else if (longStateName.Equals("Guam", StringComparison.OrdinalIgnoreCase))
            {
                return "GU";
            }
            else if (longStateName.Equals("Hawaii", StringComparison.OrdinalIgnoreCase))
            {
                return "HI";
            }
            else if (longStateName.Equals("Idaho", StringComparison.OrdinalIgnoreCase))
            {
                return "ID";
            }
            else if (longStateName.Equals("Illinois", StringComparison.OrdinalIgnoreCase))
            {
                return "IL";
            }
            else if (longStateName.Equals("Indiana", StringComparison.OrdinalIgnoreCase))
            {
                return "IN";
            }
            else if (longStateName.Equals("Iowa", StringComparison.OrdinalIgnoreCase))
            {
                return "IA";
            }
            else if (longStateName.Equals("Kansas", StringComparison.OrdinalIgnoreCase))
            {
                return "KS";
            }
            else if (longStateName.Equals("Kentucky", StringComparison.OrdinalIgnoreCase))
            {
                return "KY";
            }
            else if (longStateName.Equals("Louisiana", StringComparison.OrdinalIgnoreCase))
            {
                return "LA";
            }
            else if (longStateName.Equals("Maine", StringComparison.OrdinalIgnoreCase))
            {
                return "ME";
            }
            else if (longStateName.Equals("Marshall Islands", StringComparison.OrdinalIgnoreCase))
            {
                return "MH";
            }
            else if (longStateName.Equals("Maryland", StringComparison.OrdinalIgnoreCase))
            {
                return "MD";
            }
            else if (longStateName.Equals("Massachusetts", StringComparison.OrdinalIgnoreCase))
            {
                return "MA";
            }
            else if (longStateName.Equals("Michigan", StringComparison.OrdinalIgnoreCase))
            {
                return "MI";
            }
            else if (longStateName.Equals("Minnesota", StringComparison.OrdinalIgnoreCase))
            {
                return "MN";
            }
            else if (longStateName.Equals("Mississippi", StringComparison.OrdinalIgnoreCase))
            {
                return "MS";
            }
            else if (longStateName.Equals("Missouri", StringComparison.OrdinalIgnoreCase))
            {
                return "MO";
            }
            else if (longStateName.Equals("Montana", StringComparison.OrdinalIgnoreCase))
            {
                return "MT";
            }
            else if (longStateName.Equals("Nebraska", StringComparison.OrdinalIgnoreCase))
            {
                return "NE";
            }
            else if (longStateName.Equals("Nevada", StringComparison.OrdinalIgnoreCase))
            {
                return "NV";
            }
            else if (longStateName.Equals("New Hampshire", StringComparison.OrdinalIgnoreCase))
            {
                return "NH";
            }
            else if (longStateName.Equals("New Jersey", StringComparison.OrdinalIgnoreCase))
            {
                return "NJ";
            }
            else if (longStateName.Equals("New Mexico", StringComparison.OrdinalIgnoreCase))
            {
                return "NM";
            }
            else if (longStateName.Equals("New York", StringComparison.OrdinalIgnoreCase))
            {
                return "NY";
            }
            else if (longStateName.Equals("North Carolina", StringComparison.OrdinalIgnoreCase))
            {
                return "NC";
            }
            else if (longStateName.Equals("North Dakota", StringComparison.OrdinalIgnoreCase))
            {
                return "ND";
            }
            else if (longStateName.Equals("Northern Mariana Islands", StringComparison.OrdinalIgnoreCase))
            {
                return "MP";
            }
            else if (longStateName.Equals("Ohio", StringComparison.OrdinalIgnoreCase))
            {
                return "OH";
            }
            else if (longStateName.Equals("Oklahoma", StringComparison.OrdinalIgnoreCase))
            {
                return "OK";
            }
            else if (longStateName.Equals("Oregon", StringComparison.OrdinalIgnoreCase))
            {
                return "OR";
            }
            else if (longStateName.Equals("Palau", StringComparison.OrdinalIgnoreCase))
            {
                return "PW";
            }
            else if (longStateName.Equals("Pennsylvania", StringComparison.OrdinalIgnoreCase))
            {
                return "PA";
            }
            else if (longStateName.Equals("Puerto Rico", StringComparison.OrdinalIgnoreCase))
            {
                return "PR";
            }
            else if (longStateName.Equals("Rhode Island", StringComparison.OrdinalIgnoreCase))
            {
                return "RI";
            }
            else if (longStateName.Equals("South Carolina", StringComparison.OrdinalIgnoreCase))
            {
                return "SC";
            }
            else if (longStateName.Equals("South Dakota", StringComparison.OrdinalIgnoreCase))
            {
                return "SD";
            }
            else if (longStateName.Equals("Tennessee", StringComparison.OrdinalIgnoreCase))
            {
                return "TN";
            }
            else if (longStateName.Equals("Texas", StringComparison.OrdinalIgnoreCase))
            {
                return "TX";
            }
            else if (longStateName.Equals("Utah", StringComparison.OrdinalIgnoreCase))
            {
                return "UT";
            }
            else if (longStateName.Equals("Vermont", StringComparison.OrdinalIgnoreCase))
            {
                return "VT";
            }
            else if (longStateName.Equals("Virgin Islands", StringComparison.OrdinalIgnoreCase))
            {
                return "VI";
            }
            else if (longStateName.Equals("Virginia", StringComparison.OrdinalIgnoreCase))
            {
                return "VA";
            }
            else if (longStateName.Equals("Washington", StringComparison.OrdinalIgnoreCase))
            {
                return "WA";
            }
            else if (longStateName.Equals("West Virginia", StringComparison.OrdinalIgnoreCase))
            {
                return "WV";
            }
            else if (longStateName.Equals("Wisconsin", StringComparison.OrdinalIgnoreCase))
            {
                return "WI";
            }
            else if (longStateName.Equals("Wyoming", StringComparison.OrdinalIgnoreCase))
            {
                return "WY";
            }
            else if (longStateName.Equals("Armed Forces Europe, the Middle East, and Canada", StringComparison.OrdinalIgnoreCase))
            {
                return "AE";
            }
            else if (longStateName.Equals("Armed Forces Pacific", StringComparison.OrdinalIgnoreCase))
            {
                return "AP";
            }
            else if (longStateName.Equals("Armed Forces Americas(except Canada)", StringComparison.OrdinalIgnoreCase))
            {
                return "AA";
            } else
            {
                return "";
            }
        }
    }
}
