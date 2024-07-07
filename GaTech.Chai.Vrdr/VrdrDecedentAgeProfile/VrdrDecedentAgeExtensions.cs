using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public static class VrdrDecedentAgeExtensions
{
    public static VrdrDecedentAge VrdrDecedentAge(this Observation observation)
    {
        return new VrdrDecedentAge(observation);
    }

}
