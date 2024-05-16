using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl.Common
{
	public class VrclCodeSystemsValueSets
	{
		public class VrclValueSetRoleVr
		{
			public const string officialUrl = "http://hl7.org/fhir/us/vr-common-library/ValueSet/ValueSet-role-vr";

			public static CodeableConcept FATHER = new(officialUrl, "FTH", "father", null);
            public static CodeableConcept MOTHER = new(officialUrl, "MTH", "mother", null);
        }
    }
}

