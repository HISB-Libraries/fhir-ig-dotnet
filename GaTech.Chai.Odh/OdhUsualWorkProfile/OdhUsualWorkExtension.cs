using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Odh.UsualWorkProfile
{
    /// <summary>
    /// Class with Observation extensions for UsualWorkProfile
    /// http://hl7.org/fhir/us/odh/StructureDefinition/odh-UsualWork
    /// </summary>
    public static class OdhUsualWorkExtension
    {
        public static OdhUsualWork OdhUsualWork(this Observation observation)
        {
            return new OdhUsualWork(observation);
        }
    }
}
