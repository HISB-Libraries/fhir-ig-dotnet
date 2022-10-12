using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi.ProcecureDeathCertificationProfile
{
    /// <summary>
    /// Class with Procedure extensions for ProcecureDeathCertificationProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Procedure-death-certification
    /// </summary>
    public static class ProcecureDeathCertificationExtensions
    {
        public static ProcecureDeathCertification ProcecureDeathCertification(this Procedure procedure)
        {
            return new ProcecureDeathCertification(procedure);
        }
    }
}
