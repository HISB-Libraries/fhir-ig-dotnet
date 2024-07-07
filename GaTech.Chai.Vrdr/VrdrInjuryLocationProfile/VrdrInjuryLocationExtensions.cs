using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public static class VrdrInjuryLocationExtensions
{
    public static VrdrInjuryLocation VrdrInjuryLocation(this Location location)
    {
        return new VrdrInjuryLocation(location);
    }

}
