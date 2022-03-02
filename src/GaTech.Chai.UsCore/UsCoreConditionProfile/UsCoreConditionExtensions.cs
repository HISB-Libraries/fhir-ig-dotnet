using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.UsCoreConditionProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Condition profile.
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
