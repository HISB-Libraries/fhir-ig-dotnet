using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl
{
	public static class PractitionerVrExtensions
	{
		public static PractitionerVr PractitionerVr(this Practitioner practitioner)
		{
			return new PractitionerVr(practitioner);
		}
	}
}

