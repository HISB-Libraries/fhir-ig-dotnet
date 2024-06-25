using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    public static class LocationDeathExtensions
    {
        public static LocationDeath LocationDeath(this Location location)
        {
            return new LocationDeath(location);
        }
    }
}

