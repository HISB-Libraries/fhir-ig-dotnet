using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr;

public static class VrdrCertifierExtensions
{
    public static VrdrCertifier VrdrCertifier(this Practitioner practitioner)
    {
        return new VrdrCertifier(practitioner);
    }

}
