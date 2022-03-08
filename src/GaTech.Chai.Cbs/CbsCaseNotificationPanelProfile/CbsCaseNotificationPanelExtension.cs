using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Case Notification Panel Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-notification-panel
    /// </summary>
    public static class CbsCaseNotificationPanelExtension
    {
        public static CbsCaseNotificationPanel CbsCaseNotificationPanel(this Observation observation)
        {
            return new CbsCaseNotificationPanel(observation);
        }

        public static CbsExposureObservation CbsAgeAtCaseInvestigation(this Observation observation)
        {
            return new CbsExposureObservation(observation); 
        }

        public static CbsMmwr CbsMmwr(this Observation observation)
        {
            return new CbsMmwr(observation);
        }
    }
}
