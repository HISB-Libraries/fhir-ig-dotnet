using System;
using System.Collections.Generic;
using GaTech.Chai.Cbs.CaseNotificationPanelProfile;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class MMWR
    {
        public MMWR()
        {
        }

        public static Observation Create(Patient patient, Condition conditionOfInterest, int week, int year)
        {
            // MMWR Observation
            Observation mmwrObservation = CbsMmwr.Create();
            mmwrObservation.Subject = patient.AsReference();
            mmwrObservation.CbsMmwr().MMWRWeek = week;
            mmwrObservation.CbsMmwr().MMWRYear = year;

            return mmwrObservation;
        }
    }
}
