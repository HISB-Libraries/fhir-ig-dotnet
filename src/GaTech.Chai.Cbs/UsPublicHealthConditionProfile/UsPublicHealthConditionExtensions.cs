﻿using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.UsPublicHealthConditionProfile
{
    /// <summary>
    /// Class with Observation extensions for Case Based Surveillance Condition profile.
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
