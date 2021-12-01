using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsTravelHistoryProfile
{
    /// <summary>
    /// Case Based Surveillance Travel History Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
    /// </summary>
    public class CbsTravelHistory
    {
        readonly Observation observation;
        readonly ProgramSpecificTimeWindow programSpecificTimeWindow;
        readonly TravelHistoryAddress travelHistoryAddress;

        internal CbsTravelHistory(Observation observation)
        {
            this.observation = observation;
            this.programSpecificTimeWindow = new ProgramSpecificTimeWindow(observation);
            this.travelHistoryAddress = new TravelHistoryAddress(observation);
        }

        /// <summary>
        /// Factory for Case Based Surveillance Travel History Record Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.CbsTravelHistory().AddProfile();
            observation.Code = new CodeableConcept("http://snomed.info/sct", "420008001", "Travel");
            observation.CbsTravelHistory().TravelHistoryAddress.AddComponent();

            return observation;
        }

        /// <summary>
        /// Case Based Surveillance Program Specific Time Window
        /// </summary>
        public ProgramSpecificTimeWindow ProgramSpecificTimeWindow => this.programSpecificTimeWindow;

        public TravelHistoryAddress TravelHistoryAddress => this.travelHistoryAddress;

        /// <summary>
        /// The official URL for the Case Based Surveillance Travel History profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication";

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