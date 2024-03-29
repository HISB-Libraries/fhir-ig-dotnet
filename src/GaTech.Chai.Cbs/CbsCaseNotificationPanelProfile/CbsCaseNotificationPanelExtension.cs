﻿using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Case Notification and Component Panel Profiles
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-notification-panel
    /// </summary>
    public static class CbsCaseNotificationPanelExtension
    {
        public static CbsCaseNotificationPanel CbsCaseNotificationPanel(this Observation observation)
        {
            return new CbsCaseNotificationPanel(observation);
        }

        public static CbsAgeAtCaseInvestigation CbsAgeAtCaseInvestigation(this Observation observation)
        {
            return new CbsAgeAtCaseInvestigation(observation);
        }

        public static CbsBinationalReportingCriteria CbsBinationalReportingCriteria(this Observation observation)
        {
            return new CbsBinationalReportingCriteria(observation);
        }

        public static CbsCaseInvestigationStartDate CbsCaseInvestigationStartDate(this Observation observation)
        {
            return new CbsCaseInvestigationStartDate(observation);
        }

        public static CbsCaseOutbreak CbsCaseOutbreak(this Observation observation)
        {
            return new CbsCaseOutbreak(observation);
        }

        public static CbsDateOfFirstReportToPublicHealthDept CbsDateOfFirstReportToPublicHealthDept(this Observation observation)
        {
            return new CbsDateOfFirstReportToPublicHealthDept(observation);
        }

        public static CbsDateOfInitialReport CbsDateOfInitialReport(this Observation observation)
        {
            return new CbsDateOfInitialReport(observation);
        }

        public static CbsEarliestDateReportedToCounty CbsEarliestDateReportedToCounty(this Observation observation)
        {
            return new CbsEarliestDateReportedToCounty(observation);
        }

        public static CbsEarliestDateReportedToState CbsEarliestDateReportedToState(this Observation observation)
        {
            return new CbsEarliestDateReportedToState(observation);
        }

        public static CbsExposureObservation CbsExposureObservation(this Observation observation)
        {
            return new CbsExposureObservation(observation);
        }

        public static CbsImmediateNationalNotifiableCondition CbsImmediateNationalNotifiableCondition(this Observation observation)
        {
            return new CbsImmediateNationalNotifiableCondition(observation);
        }

        public static CbsJurisdictionCode CbsJurisdictionCode(this Observation observation)
        {
            return new CbsJurisdictionCode(observation);
        }

        public static CbsMmwr CbsMmwr(this Observation observation)
        {
            return new CbsMmwr(observation);
        }

        public static CbsNationalReportingJurisdiction CbsNationalReportingJurisdiction(this Observation observation)
        {
            return new CbsNationalReportingJurisdiction(observation);
        }

        public static CbsPregnancyStatus CbsPregnancyStatus(this Observation observation)
        {
            return new CbsPregnancyStatus(observation);
        }

        public static CbsReportingCounty CbsReportingCounty(this Observation observation)
        {
            return new CbsReportingCounty(observation);
        }

        public static CbsReportingState CbsReportingState(this Observation observation)
        {
            return new CbsReportingState(observation);
        }

        public static CbsTransmissionMode CbsTransmissionMode(this Observation observation)
        {
            return new CbsTransmissionMode(observation);
        }
    }
}
