using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsConditionProfile
{
    /// <summary>
    /// Case Based Surveillance Lab Condition Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-condition
    /// </summary>
    public class CbsCondition
    {
        readonly Condition condition;

        internal CbsCondition(Condition condition)
        {
            this.condition = condition;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Lab Condition Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-condition
        /// </summary>
        public static Condition Create()
        {
            var condition = new Condition();
            condition.CbsCondition().AddProfile();
            return condition;
        }

        /// <summary>
        /// Get Reference to Resource
        /// </summary>
        /// <returns></returns>
        public ResourceReference AsReference()
        {
            if (string.IsNullOrEmpty(condition.Id))
                condition.Id = Guid.NewGuid().ToString();
            return new ResourceReference("Condition/" + condition.Id);
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Lab Condition profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-condition";

        /// <summary>
        /// Set the assertion that an condition object conforms to the Case Based Surveillance Lab Condition profile.
        /// </summary>
        public void AddProfile()
        {
            this.condition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the Case Based Surveillance Lab Condition profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.condition.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Diagnosis Date
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-diagnosis-date
        /// </summary>
        public FhirDateTime DiagnosisDate
        {
            get => this.condition.GetExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-diagnosis-date")?.Value as FhirDateTime;
            set => this.condition.Extension.AddOrUpdateExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-diagnosis-date", value);
        }

        /// <summary>
        /// Set Classification Status
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-class-status
        /// </summary>
        public CodeableConcept ClassificationStatus
        {
            get => this.condition.GetExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-class-status")?.Value as CodeableConcept;
            set => this.condition.Extension.AddOrUpdateExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-class-status", value);
        }
        /// <summary>
        /// Illness Duration
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-illness-duration
        /// </summary>
        public Quantity IllnesDuration
        {
            get => this.condition.GetExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-illness-duration")?.Value as Quantity;
            set => this.condition.Extension.AddOrUpdateExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-illness-duration", value);
        }
    }
}
