using System;
using GaTech.Chai.Cbs.UsCbsConditionProfile;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class ConditionOfInterest
    {
        public ConditionOfInterest()
        {
        }

        public static Condition Create(Patient patient, String code, String name, Quantity duration, FhirDateTime diagnosisDate, FhirDateTime onSetDate)
        {
            var condition = UsCbsCondition.Create();

            condition.Subject = patient.AsReference();
            condition.UsCbsCondition().ClassificationStatus = UsCbsCondition.CaseClassificationStatus.ConfirmedPresent;
            condition.UsCbsCondition().DiagnosisDate = diagnosisDate;
            condition.UsCbsCondition().IllnesDuration = duration;
            condition.Code = UsCbsCondition.ConditionCode.Encode(code, name);
            condition.Onset = onSetDate;
            condition.ClinicalStatus = new CodeableConcept("http://terminology.hl7.org/CodeSystem/condition-clinical", "inactive");

            return condition;
        }
    }
}
