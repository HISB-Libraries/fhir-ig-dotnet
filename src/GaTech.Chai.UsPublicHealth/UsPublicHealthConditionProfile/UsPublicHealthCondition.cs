using System;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.UsCore.ConditionProfile;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.ConditionProfile
{
    /// <summary>
    /// US Public Health Condition Profile
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-condition
    /// </summary>
    public class UsPublicHealthCondition
    {
        readonly Condition condition;

        internal UsPublicHealthCondition(Condition condition)
        {
            this.condition = condition;
            condition.UsCoreCondition().AddProfile();
        }

        /// <summary>
        /// Factory for US Public Health Condition Profile
        /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-condition
        /// </summary>
        public static Condition Create()
        {
            var condition = new Condition();
            condition.UsPublicHealthCondition().AddProfile();
            return condition;
        }

        /// <summary>
        /// The official URL for the US Public Health Condition Profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-condition";

        /// <summary>
        /// Set profile for US Public Health Condition Profile
        /// </summary>
        public void AddProfile()
        {
            this.condition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Public Health Condition Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.condition.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// condition-assertedDateTime extension
        /// http://hl7.org/fhir/StructureDefinition/condition-assertedDate
        /// </summary>
        public FhirDateTime ConditionAssertedDate
        {
            get => this.condition.GetExtension("http://hl7.org/fhir/StructureDefinition/condition-assertedDate")?.Value as FhirDateTime;
            set => this.condition.Extension.AddOrUpdateExtension("http://hl7.org/fhir/StructureDefinition/condition-assertedDate", value);

        }
    }
}
