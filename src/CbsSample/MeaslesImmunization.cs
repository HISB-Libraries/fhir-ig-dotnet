using System;
using System.Collections.Generic;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;
using GaTech.Chai.UsCbs.ImmunizationProfile;

namespace CbsProfileInitialization
{
    public class MeaslesImmunization
    {
        public MeaslesImmunization()
        {
        }

        public static Immunization Create(Patient patient, FhirDateTime occurrenceDate)
        {
            var immunization = UsCbsImmunization.Create();
            immunization.Patient = patient.AsReference();
            immunization.Status = Immunization.ImmunizationStatusCodes.Completed;
            immunization.VaccineCode = UsCbsImmunization.VaccineAdministerd_MMR.Measles;
            immunization.Occurrence = occurrenceDate;
            immunization.ReportOrigin = UsCbsImmunization.VaccineEventInformationSource_NND.HistInfoFromSchoolRecord;

            return immunization;
        }
    }
}
