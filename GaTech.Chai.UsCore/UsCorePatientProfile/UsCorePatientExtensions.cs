﻿using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.UsCorePatientProfile
{
    /// <summary>
    /// Class with Patient extensions for US Core Patient Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-patient
    /// </summary>
    public static class CbsPatientExtensions
    {
        public static UsCorePatient UsCorePatient(this Patient patient)
        {
            return new UsCorePatient(patient);
        }
    }
}
