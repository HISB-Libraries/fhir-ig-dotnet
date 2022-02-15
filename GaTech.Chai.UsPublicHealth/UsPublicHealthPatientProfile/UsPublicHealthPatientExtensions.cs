using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.UsPublicHealthPatientProfile
{
    /// <summary>
    /// Class with Patient extensions for US Puablic Health Patient Profile
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-patient
    /// </summary>
    public static class UsPublicHealthPatientExtensions
    {
        public static UsPublicHealthPatient UsPublicHealthPatient(this Patient patient)
        {
            return new UsPublicHealthPatient(patient);
        }
    }
}
