using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.VaccinationACIPRecommendationProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Vaccinaton Indication Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
    /// </summary>
    public static class CbsVaccinationIndicationExtension
    {
        public static CbsVaccinationACIPRecommendation CbsVaccinationACIPRecommendation(this Observation observation)
        {
            return new CbsVaccinationACIPRecommendation(observation);
        }
    }
}
