using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsVaccinationIndicationProfile
{
    /// <summary>
    /// Class with Immunization extensions for Case Based Surveillance Vaccinaton Indication Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
    /// </summary>
    public static class CbsVaccinationIndicationExtension
    {
        public static CbsVaccinationIndication CbsVaccinationIndication(this Observation observation)
        {
            return new CbsVaccinationIndication(observation);
        }
    }
}
