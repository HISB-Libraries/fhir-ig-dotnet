using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.PerformingLaboratoryProfile
{
    /// <summary>
    /// Class with Organziation extensions for Case Based Surveillance Performing Laboratory Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-performing-lab
    /// </summary>
    public static class CbsPerformingLaboratoryExtension
    {
        public static UsCbsPerformingLaboratory UsCbsPerformingLaboratory(this Organization organization)
        {
            return new UsCbsPerformingLaboratory(organization);
        }
    }
}
