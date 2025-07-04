using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// Class with Procedure extensions for US Core Procedure profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-procedure
    /// </summary>
    public static class UsCoreProcedureExtensions
    {
        public static UsCoreProcedure UsCoreProcedure(this Procedure procedure)
        {
            return new UsCoreProcedure(procedure);
        }
    }
}
