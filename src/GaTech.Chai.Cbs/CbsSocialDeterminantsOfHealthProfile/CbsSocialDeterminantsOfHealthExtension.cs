using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.SocialDeterminantsOfHealthProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Social Determinants of Health Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-social-determinants-of-health
    /// </summary>
    public static class CbsVaccinationIndicationExtension
    {
        public static CbsSocialDeterminantsOfHealth CbsSocialDeterminantsOfHealth(this Observation observation)
        {
            return new CbsSocialDeterminantsOfHealth(observation);
        }
    }
}
