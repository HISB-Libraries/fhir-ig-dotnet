using System;
using Hl7.Fhir.Model;
using static GaTech.Chai.Share.CodeSystems;

namespace GaTech.Chai.Vrcl
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

			public static CodeableConcept No = new("http://terminology.hl7.org/CodeSystem/v2-0136", "N", "No", null);
			public static CodeableConcept Yes = new("http://terminology.hl7.org/CodeSystem/v2-0136", "Y", "Yes", null);
			public static CodeableConcept Unknown = V3NullFlavor.Unknown;
		}
	}
}

