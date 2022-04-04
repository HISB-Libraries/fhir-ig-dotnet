using System;
using System.Linq;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CaseNotificationPanelProfile
{
    /// <summary>
    /// CBS Case Investigation Start Date Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-investigation-start-date
    /// </summary>
    public class CbsCaseInvestigationStartDate : CbsCaseNotificationPanel
    {
        internal CbsCaseInvestigationStartDate(Observation observation) : base(observation)
        {
            this.ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-investigation-start-date";
        }

        /// <summary>
        /// Factory for CBS Case Investigation Start Date Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-investigation-start-date
        /// </summary>
        public static new Observation Create()
        {
            var observation = new Observation();
            observation.CbsCaseNotificationPanel().AddProfile();
            observation.CbsCaseInvestigationStartDate().AddProfile();
            observation.Code = new CodeableConcept("http://loinc.org", "77979-3", "Case Investigation Start Date", null);
            return observation;
        }

        public FhirDateTime Value
        {
            get => this.observation.Value as FhirDateTime;
            set => this.observation.Value = value;
        }
    }
}
