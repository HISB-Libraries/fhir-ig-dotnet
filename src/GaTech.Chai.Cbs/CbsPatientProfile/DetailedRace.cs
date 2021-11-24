using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    /// <summary>
    /// https://build.fhir.org/ig/HL7/US-Core//ValueSet-detailed-race.html
    /// </summary>
    public static class DetailedRace
    {
        /// <summary>
        /// Create coding for https://build.fhir.org/ig/HL7/US-Core//ValueSet-detailed-race.html
        /// </summary>
        /// <param name="code"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Coding Encode(string code, string text)
        {
            return new Coding("urn:oid:2.16.840.1.113883.6.238", code) { Display = text };
        }
    }
}