using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsCaseOfDeathProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Cause of Death Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cause-of-death
    /// </summary>
    public static class CbsCaseOfDeathExtensions
    {
        public static CbsCaseOfDeath CbsCaseOfDeath(this Observation observation)
        {
            return new CbsCaseOfDeath(observation);
        }
    }
}
