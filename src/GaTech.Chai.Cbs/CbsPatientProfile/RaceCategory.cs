using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPatientProfile
{
    /// <summary>
    /// http://terminology.hl7.org/CodeSystem/v2-0005
    /// </summary>
    public static class RaceCategory
    {
        /// <summary>
        /// Create coding for http://terminology.hl7.org/CodeSystem/v2-0005
        /// </summary>
        /// <param name="code"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Coding Encode(string code, string text)
        {
            return new Coding("http://terminology.hl7.org/CodeSystem/v2-0005", code)
            { Display = text };
        }
    }
}
