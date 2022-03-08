using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsPublicHealth.TravelHistoryProfile;
using GaTech.Chai.UsCbs.Common;

namespace GaTech.Chai.UsCbs.TravelHistoryProfile
{
    /// <summary>
    /// Case Based Surveillance Travel History Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-travel-history
    /// </summary>
    public class UsCbsTravelHistory
    {
        readonly Observation observation;
        readonly UsCbsPeriodAndModeOfTravel usCbsPeriodandModeofTravel;
        readonly UsCbsProgramSpecificTimeWindow usCbsProgramSpecificTimeWindow;

        internal UsCbsTravelHistory(Observation observation)
        {
            this.observation = observation;
            this.usCbsPeriodandModeofTravel = new UsCbsPeriodAndModeOfTravel(observation);
            this.usCbsProgramSpecificTimeWindow = new UsCbsProgramSpecificTimeWindow(observation);
        }

        /// <summary>
        /// Factory for Case Based Surveillance Travel History Record Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-travel-history
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.UsCbsTravelHistory().AddProfile();
            observation.UsPublicHealthTravelHistory().AddProfile();

            return observation;
        }

        /// <summary>
        /// Case Based Surveillance Priod and Mode of Travel
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-period-and-mode-of-travel
        /// </summary>
        public UsCbsPeriodAndModeOfTravel PeriodAndModeOfTravel => usCbsPeriodandModeofTravel;

        /// <summary>
        /// Case Based Surveillance Program Specific Time Window
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-program-specific-time-window
        /// </summary>
        public UsCbsProgramSpecificTimeWindow ProgramSpecificTimeWindow => this.usCbsProgramSpecificTimeWindow;

        /// <summary>
        /// The official URL for the Case Based Surveillance Travel History profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-travel-history";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Travel History Profile.
        /// </summary>
        public void AddProfile()
        {
            observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Travel History Profile.
        /// </summary>
        public void RemoveProfile()
        {
            observation.RemoveProfile(ProfileUrl);
        }
    }
}