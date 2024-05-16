using System;
using GaTech.Chai.Mdi.LocationInjuryProfile;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.LocationInjuryProfile
{
    public static class LocationInjuryExtensions
    {
        public static LocationInjury LocationInjury(this Location location)
        {
            return new LocationInjury(location);
        }
    }
}

