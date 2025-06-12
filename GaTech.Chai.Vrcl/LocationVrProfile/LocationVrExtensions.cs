using System;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl
{
	public static class LocationVrExtensions
	{
		public static LocationVr LocationVr(this Location location)
		{
			return new LocationVr(location);
		}
	}
}

