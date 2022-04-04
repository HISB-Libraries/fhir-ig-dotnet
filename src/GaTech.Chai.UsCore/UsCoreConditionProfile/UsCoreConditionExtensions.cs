using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.ConditionProfile
{
    /// <summary>
    /// Class with Condition extensions for US Core Condition profile.
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-condition
    /// </summary>
    public static class UsCoreConditionExtensions
    {
        public static UsCoreCondition UsCoreCondition(this Condition condition)
        {
            return new UsCoreCondition(condition);
        }
    }
}
