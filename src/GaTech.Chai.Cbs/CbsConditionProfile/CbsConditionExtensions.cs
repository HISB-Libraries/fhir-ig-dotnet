using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsConditionProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Condition profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-condition
    /// </summary>
    public static class CbsConditionExtensions
    {
        public static CbsCondition CbsCondition(this Condition condition)
        {
            return new CbsCondition(condition);
        }
    }
}
