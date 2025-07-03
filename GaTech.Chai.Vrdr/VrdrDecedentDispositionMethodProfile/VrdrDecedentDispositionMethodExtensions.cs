using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public static class VrdrDecedentDispositionMethodExtensions
{
    public static VrdrDecedentDispositionMethod VrdrDecedentDispositionMethod(this Observation observation)
    {
        return new VrdrDecedentDispositionMethod(observation);
    }

}
