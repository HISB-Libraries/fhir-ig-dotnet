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
		public class VrclValueSetYesNoUnknownVr
		{
			public const string officialUrl = "http://hl7.org/fhir/us/vr-common-library/ValueSet/ValueSet-yes-no-unknown-vr";

			public static CodeableConcept NO = new("http://terminology.hl7.org/CodeSystem/v2-0136", "N", "No", null);
			public static CodeableConcept YES = new("http://terminology.hl7.org/CodeSystem/v2-0136", "Y", "Yes", null);
			public static CodeableConcept UNKNOWN = new("http://terminology.hl7.org/CodeSystem/v3-NullFlavor", "UNK", "unknown", null);
		}
	}
}

