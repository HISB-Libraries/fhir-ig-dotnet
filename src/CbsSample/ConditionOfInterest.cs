using System;
using GaTech.Chai.UsCbs.ConditionOfInterestProfile;
using GaTech.Chai.UsCore.ConditionProfile;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsPublicHealth.ConditionProfile;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class ConditionOfInterest
    {
        public ConditionOfInterest()
        {
        }

        public static Condition Create(Patient patient, String code, String name, Quantity duration, FhirDateTime onSetDate)
        {
            var condition = UsCbsConditionOfInterest.Create();
            condition.UsPublicHealthCondition().AddProfile();
            condition.UsCoreCondition().AddProfile();

            condition.Subject = patient.AsReference();
            condition.UsCbsConditionOfInterest().CaseClassStatus = UsCbsConditionOfInterest.CaseClassStatusValues.ConfirmedPresent;
            condition.UsCbsConditionOfInterest().CaseIllnesDuration = duration;
            condition.Code = UsCbsConditionOfInterest.ConditionCode.Encode(code, name);
            condition.Onset = onSetDate;
            condition.UsPublicHealthCondition().ConditionAssertedDate = onSetDate;
            condition.ClinicalStatus = new CodeableConcept("http://terminology.hl7.org/CodeSystem/condition-clinical", "inactive");
            condition.UsCoreCondition().SetVerificationStatus(Condition.ConditionVerificationStatus.Confirmed);

            return condition;
        }
    }
}
