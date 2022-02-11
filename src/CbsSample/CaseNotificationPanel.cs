using System;
using System.Collections.Generic;
using GaTech.Chai.Cbs.CbsCaseNotificationPanelProfile;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    public class CaseNotificationPanel
    {
        public CaseNotificationPanel()
        {
        }

        public static Observation Create(Patient patient)
        {
            Observation observation = CbsCaseNotificationPanel.Create();
            observation.Subject = patient.AsReference();
            observation.Code = new CodeableConcept("http://loinc.org", "78000-7", "Case notification panel [CDC.PHIN]", null);

            return observation;
        }
    }
}
