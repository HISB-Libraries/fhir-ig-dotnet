using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Procedure extensions for ProcecureDeathCertificationProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Procedure-death-certification
    /// </summary>
    public static class ProcedureDeathCertificationExtensions
    {
        public static ProcedureDeathCertification ProcedureDeathCertification(this Procedure procedure)
        {
            return new ProcedureDeathCertification(procedure);
        }
    }
}
