using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// Case Based Surveillance Date of Initial Report Observation
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-immediate-nnc
    /// </summary>
    public class CbsImmediateNationalNotifiableCondition : CbsCaseNotificationPanel
    {
        internal CbsImmediateNationalNotifiableCondition(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-immediate-nnc";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Date of Initial Report Observation Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-immediate-nnc
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsImmediateNationalNotifiableCondition().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77965-2", "Immediate National Notifiable Condition", null);
            return observation;
        }

        public CodeableConcept Value
        {
            get => this.observation.Value as CodeableConcept;
            set => this.observation.Value = value;
        }
    }
}
