using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Cbs.CauseOfDeathProfile
{
    /// <summary>
    /// Case Based Surveillance Cause of Death Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cause-of-death
    /// </summary>
    public class CbsCauseOfDeath
    {
        readonly Observation observation;

        internal CbsCauseOfDeath(Observation o)
        {
            this.observation = o;
            observation.Code = new CodeableConcept("http://loinc.org", "79378-6");
            observation.Status = ObservationStatus.Final;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Cause of Death Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cause-of-death
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.CbsCauseOfDeath().AddProfile();
            return observation;
        }
        /// <summary>
        /// The official URL for the Case Based Surveillance Cause of Death profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-cause-of-death";

        /// <summary>
        /// Set profile for Case Based Surveillance Cause of Death Profile
        /// </summary>
        public void AddProfile()
        {
            this.observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Case Based Surveillance Cause of Death Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.observation.RemoveProfile(ProfileUrl);
        }
    }
}
