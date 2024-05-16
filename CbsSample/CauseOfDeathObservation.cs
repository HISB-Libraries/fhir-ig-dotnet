using System;
using GaTech.Chai.Cbs.CauseOfDeathProfile;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class CauseOfDeathObservation
    {
        public CauseOfDeathObservation()
        {
        }

        public static Observation Create(Patient patient, Condition conditionOfInterest)
        {
            Observation observation = CbsCauseOfDeath.Create();

            observation.Subject = patient.AsReference();
            observation.Focus.Add(conditionOfInterest.AsReference());

            return observation;
        }
    }
}
