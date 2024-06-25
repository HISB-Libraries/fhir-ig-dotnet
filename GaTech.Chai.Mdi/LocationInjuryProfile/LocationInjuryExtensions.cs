using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    public static class LocationInjuryExtensions
    {
        public static LocationInjury LocationInjury(this Location location)
        {
            return new LocationInjury(location);
        }
    }
}

