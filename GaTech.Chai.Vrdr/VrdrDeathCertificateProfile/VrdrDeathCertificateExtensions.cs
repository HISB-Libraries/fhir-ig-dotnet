using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Composition extensions for VrdrDeathCertificateProfile
    /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-death-certificate
    /// </summary>
    public static class VrdrDeathCertificateExtensions
    {
        public static VrdrDeathCertificate VrdrDeathCertificate(this Composition composition)
        {
            return new VrdrDeathCertificate(composition);
        }
    }
}
