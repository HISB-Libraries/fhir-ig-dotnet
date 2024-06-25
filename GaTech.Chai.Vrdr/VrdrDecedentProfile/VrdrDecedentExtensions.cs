using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public static class VrdrDecedentExtensions
{
    public static VrdrDecedent VrdrDecedent(this Patient patient)
    {
        return new VrdrDecedent(patient);
    }

}
