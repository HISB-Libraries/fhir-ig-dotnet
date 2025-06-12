using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    public static class VrdrDeathLocationExtensions
    {
        public static VrdrDeathLocation VrdrDeathLocation(this Location location)
        {
            return new VrdrDeathLocation(location);
        }
    }
}

