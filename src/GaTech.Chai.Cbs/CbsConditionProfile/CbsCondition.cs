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

        /// <summary>
        /// Nationally Notifiable Disease Surveillance System (NNDSS) & Other Conditions of Public Health Importance
        /// 2.16.840.1.114222.4.11.1015
        /// </summary>
        public static class ConditionCode
        {
            /// <summary>
            /// Nationally Notifiable Disease Surveillance System (NNDSS) & Other Conditions of Public Health Importance
            /// 2.16.840.1.114222.4.11.1015
            /// </summary>
            /// <param name="code"></param>
            /// <param name="display"></param>
            /// <returns></returns>
            public static CodeableConcept Encode(string code, string display)
            {
                return new CodeableConcept("urn:oid:2.16.840.1.114222.4.11.1015", code, display, null);
            }
        }

        /// <summary>
        /// Case Classification Status (2.16.840.1.114222.4.11.968)
        /// Indicates how the Nationally Notifiable Disease case was classified at its close
        /// </summary>
        public static class CaseClassificationStatus
        {
            public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.968";

            public static CodeableConcept ConfirmedPresent => Encode("410605003", "Confirmed present");
            public static CodeableConcept NotACase => Encode("PHC178", "Not a Case");
            public static CodeableConcept ProbableDiagnosis => Encode("2931005", "Probable diagnosis");
            public static CodeableConcept Suspected => Encode("415684004", "Suspected");
            public static CodeableConcept Unknown => Encode("UNK", "Unknown");
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
        }
    }
}
