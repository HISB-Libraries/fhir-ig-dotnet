using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsPerformingLaboratoryProfile
{
    /// <summary>
    /// Class with Organziation extensions for Case Based Surveillance Performing Laboratory Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-performing-lab
    /// </summary>
    public static class CbsPerformingLaboratoryExtension
    {
        public static CbsPerformingLaboratory CbsPerformingLaboratory(this Organization organization)
        {
            return new CbsPerformingLaboratory(organization);
        }
    }
}
