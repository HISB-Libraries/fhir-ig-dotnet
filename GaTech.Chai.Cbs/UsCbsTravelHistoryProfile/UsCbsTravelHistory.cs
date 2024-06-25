using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using GaTech.Chai.UsPublicHealth;
using GaTech.Chai.UsCbs.Common;

namespace GaTech.Chai.UsCbs.TravelHistoryProfile
{
    /// <summary>
    /// US Case Based Surveillance Travel History Profile
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
        /// Factory for US Case Based Surveillance Travel History Profile
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
        /// The official URL for the US Case Based Surveillance Travel History profile, used to assert conformance.
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

        /// <summary>
        /// US Case Based Surveillance Priod and Mode of Travel
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-period-and-mode-of-travel
        /// </summary>
        public UsCbsPeriodAndModeOfTravel PeriodAndModeOfTravel => usCbsPeriodandModeofTravel;

        /// <summary>
        /// US Case Based Surveillance Program Specific Time Window
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-program-specific-time-window
        /// </summary>
        public UsCbsProgramSpecificTimeWindow ProgramSpecificTimeWindow => this.usCbsProgramSpecificTimeWindow;
    }
}