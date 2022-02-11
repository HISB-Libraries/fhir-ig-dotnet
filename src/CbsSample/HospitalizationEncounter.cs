using System;
using System.Collections.Generic;
using GaTech.Chai.Cbs.UsCbsHospitalizationEncounterProfile;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class HospitalizationEncounter
    {
        public HospitalizationEncounter()
        {
        }

        public static Encounter Create(Patient patient, Condition conditionOfInterest, List<CodeableConcept> type, Period period)
        {
            var encounter = UsCbsHospitalization.Create();
            encounter.Type = type;
            encounter.Subject = patient.AsReference();
            encounter.Period = period;
            encounter.UsCbsHospitalization().Reason = conditionOfInterest.AsReference();

            return encounter;
        }
    }
}
