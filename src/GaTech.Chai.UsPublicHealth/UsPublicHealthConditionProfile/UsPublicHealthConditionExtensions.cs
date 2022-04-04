using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.ConditionProfile
{
    /// <summary>
    /// Class with Condition extensions for US Public Health Condition Profile
    /// http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-condition
    /// </summary>
    public static class UsPublicHealthConditionExtensions
    {
        public static UsPublicHealthCondition UsPublicHealthCondition(this Condition condition)
        {
            return new UsPublicHealthCondition(condition);
        }
    }
}
