using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CauseOfDeathProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Cause of Death Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cause-of-death
    /// </summary>
    public static class CbsCauseOfDeathExtensions
    {
        public static CbsCauseOfDeath CbsCauseOfDeath(this Observation observation)
        {
            return new CbsCauseOfDeath(observation);
        }
    }
}
