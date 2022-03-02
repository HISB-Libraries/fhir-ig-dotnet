using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.FhirIg.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth.ConditionProfile
{
    public class UsPublicHealthConditionAssertedDate
    {
        readonly Condition condition;

        internal UsPublicHealthConditionAssertedDate(Condition condition)
        {
            this.condition = condition;
        }

        public const string ExtUrl = "http://hl7.org/fhir/StructureDefinition/condition-assertedDate";

        public FhirDateTime Extension
        {
            set
            {
                var assertedDateExt = AddOrUpdateAssertedDateExtension();
                assertedDateExt.Value = value as FhirDateTime;
            }
            get
            {
                var assertedDateExt = condition.GetExtension(ExtUrl);
                return assertedDateExt?.Value as FhirDateTime;
            }
        }

        private Extension AddOrUpdateAssertedDateExtension()
        {
            var assertedDateExt = new Extension() { Url = ExtUrl };
            return condition.Extension.AddOrUpdateExtension(assertedDateExt);
        }
    }
}
