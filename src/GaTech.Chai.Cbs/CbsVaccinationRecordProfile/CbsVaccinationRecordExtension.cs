using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsVaccinationRecordProfile
{
    /// <summary>
    /// Class with Immunization extensions for Case Based Surveillance Vaccinaton Record Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-record
    /// </summary>
    public static class CbsVaccinationRecordExtension
    {
        public static CbsVaccinationRecord CbsVaccinationRecord(this Immunization immunization)
        {
            return new CbsVaccinationRecord(immunization);
        }
    }
}
