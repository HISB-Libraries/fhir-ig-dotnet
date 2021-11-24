using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsConditionProfile
{
    public static class CbsConditionCode
    {
        /// <summary>
        /// Nationally Notifiable Disease Surveillance System (NNDSS) & Other Conditions of Public Health Importance
        /// 2.16.840.1.114222.4.11.1015
        /// </summary>
        /// <param name="code"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        public static CodeableConcept Encode(string code, string display)
        {
           return new CodeableConcept("urn:oid:2.16.840.1.114222.4.11.1015", code, display, null);
        }
    }
}
