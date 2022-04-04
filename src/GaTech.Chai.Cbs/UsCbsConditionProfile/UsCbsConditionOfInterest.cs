using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.UsPublicHealth.ConditionProfile;

namespace GaTech.Chai.UsCbs.ConditionOfInterestProfile
{
    /// <summary>
    /// US Case Based Surveillance Condition Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-condition
    /// </summary>
    public class UsCbsConditionOfInterest
    {
        readonly Condition condition;

        internal UsCbsConditionOfInterest(Condition condition)
        {
            this.condition = condition;
            condition.UsPublicHealthCondition().AddProfile();
        }

        /// <summary>
        /// Factory for US Case Based Surveillance Condition Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-condition
        /// </summary>
        public static Condition Create()
        {
            var condition = new Condition();
            condition.UsCbsConditionOfInterest().AddProfile();
            return condition;
        }

        /// <summary>
        /// The official URL for the US Case Based Surveillance Condition profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-condition";

        /// <summary>
        /// Set profile for US Case Based Surveillance Condition Profile
        /// </summary>
        public void AddProfile()
        {
            this.condition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Case Based Surveillance Condition Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.condition.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Set Classification Status
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-case-class-status
        /// </summary>
        public CodeableConcept CaseClassStatus
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
        public Quantity CaseIllnesDuration
        {
            get => this.condition.GetExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-illness-duration")?.Value as Quantity;
            set => this.condition.Extension.AddOrUpdateExtension(
                    "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-illness-duration", value);
        }

        /// <summary>
        /// Nationally Notifiable Disease Surveillance System (NNDSS) & Other Conditions of Public Health Importance
        /// 2.16.840.1.114222.4.5.277
        /// </summary>
        public static class ConditionCode
        {
            /// <summary>
            /// Nationally Notifiable Disease Surveillance System (NNDSS) & Other Conditions of Public Health Importance
            /// 2.16.840.1.114222.4.5.277
            /// </summary>
            /// <param name="code"></param>
            /// <param name="display"></param>
            /// <returns></returns>
            public static CodeableConcept Encode(string code, string display)
            {
                return new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.277", code, display, null);
            }
        }

        /// <summary>
        /// Valueset for Case Classification Status (2.16.840.1.114222.4.11.968)
        /// Indicates how the Nationally Notifiable Disease case was classified at its close
        /// There are three systems involved, SNOMED-CT, PHINVS, and NullFlavor
        /// </summary>
        public static class CaseClassStatusValues
        {
            public static CodeableConcept ConfirmedPresent => new CodeableConcept("http://snomed.info/sct", "410605003", "Confirmed present", null);
            public static CodeableConcept NotACase => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC178", "Not a Case", null);
            public static CodeableConcept ProbableDiagnosis => new CodeableConcept("http://snomed.info/sct", "2931005", "Probable diagnosis", null);
            public static CodeableConcept Suspected => new CodeableConcept("http://snomed.info/sct", "415684004", "Suspected", null);
            public static CodeableConcept Unknown => new CodeableConcept ("http://hl7.org/fhir/v3/NullFlavor", "UNK", "Unknown", null);
        }
    }
}
