using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    public static class VrdrDeathCertificationExtensions
    {
        public static VrdrDeathCertification VrdrDeathCertification(this Procedure procedure)
        {
            return new VrdrDeathCertification(procedure);
        }
    }
}
