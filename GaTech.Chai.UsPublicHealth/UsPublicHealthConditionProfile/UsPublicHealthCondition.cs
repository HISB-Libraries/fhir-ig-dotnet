using System;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.UsPublicHealthConditionProfile
{
    /// <summary>
    /// US Core Public Health Condition Profile Extensions
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-condition
    /// </summary>
    public class UsPublicHealthCondition
    {
        readonly Condition condition;

        internal UsPublicHealthCondition(Condition condition)
        {
            this.condition = condition;
        }

        /// <summary>
        /// Factory for US Core Public Health Condition Profile
        /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-condition
        /// </summary>
        public static Condition Create()
        {
            var condition = new Condition();
            condition.UsPublicHealthCondition().AddProfile();
            return condition;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Lab Condition profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-condition";

        /// <summary>
        /// Set the assertion that an condition object conforms to the US Core Condition profile.
        /// </summary>
        public void AddProfile()
        {
            this.condition.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the US Core Condition profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.condition.RemoveProfile(ProfileUrl);
        }
    }
}
