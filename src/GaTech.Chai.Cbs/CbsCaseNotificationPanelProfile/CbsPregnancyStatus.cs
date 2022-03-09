using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Pregnancy Status Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-pregnancy-status
    /// </summary>
    public class CbsPregnancyStatus : CbsCaseNotificationPanel
    {
        internal CbsPregnancyStatus(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-pregnancy-status";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Pregnancy Status Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-pregnancy-status
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsPregnancyStatus().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77996-7", "Pregnancy status at time of illness or condition", null);
            return observation;
        }

        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set => this.observation.Value = value;
        }
    }
}
