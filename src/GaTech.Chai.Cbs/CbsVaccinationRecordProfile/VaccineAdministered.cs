using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsVaccinationRecordProfile
{
    /// <summary>
    /// Vaccine Administered (MMR) (2.16.840.1.114222.4.11.7331)
    /// </summary>
    public static class VaccineAdministered
    {
        public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.7331";

        /// <summary>
        /// Encode entry for Vaccine Event Information Source (2.16.840.1.114222.4.11.7450)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
    }
}