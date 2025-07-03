using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public static class VrdrDecedentUsualWorkExtensions
{
    public static VrdrDecedentUsualWork VrdrDecedentUsualWork(this Observation observation)
    {
        return new VrdrDecedentUsualWork(observation);
    }

}
