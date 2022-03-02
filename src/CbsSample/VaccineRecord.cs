using System;
using GaTech.Chai.Cbs.CbsVaccinationRecordProfile;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class VaccineRecord
    {
        public VaccineRecord()
        {
        }

        public static Immunization RecordFromBirthCertificate(Patient patient, String code, String name, PositiveInt doseNumber, FhirDateTime adminDateTime)
        {
            var vaccinationRecord = CbsVaccinationRecord.Create();
            vaccinationRecord.Status = Immunization.ImmunizationStatusCodes.Completed;
            vaccinationRecord.ReportOrigin = CbsVaccinationRecord.VaccineEventInformationSource.FromBirthCertificate;
            vaccinationRecord.ProtocolApplied.Add(new Immunization.ProtocolAppliedComponent() { DoseNumber = doseNumber });
            vaccinationRecord.Occurrence = adminDateTime;
            vaccinationRecord.VaccineCode = CbsVaccinationRecord.VaccineAdministered.Encode(code, name);
            vaccinationRecord.Patient = patient.AsReference();
            return vaccinationRecord;
        }
    }
}
