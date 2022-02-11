using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.UsCbsConditionProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Condition profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-condition
    /// </summary>
    public static class UsCbsConditionExtensions
    {
        public static UsCbsCondition UsCbsCondition(this Condition condition)
        {
            return new UsCbsCondition(condition);
        }
    }
}
