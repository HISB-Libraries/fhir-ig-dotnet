using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.ConditionOfInterestProfile
{
    /// <summary>
    /// Class with Observation extensions for US Case Based Surveillance Condition profile.
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-condition
    /// </summary>
    public static class UsCbsConditionOfInterestExtensions
    {
        public static UsCbsConditionOfInterest UsCbsConditionOfInterest(this Condition condition)
        {
            return new UsCbsConditionOfInterest(condition);
        }
    }
}
