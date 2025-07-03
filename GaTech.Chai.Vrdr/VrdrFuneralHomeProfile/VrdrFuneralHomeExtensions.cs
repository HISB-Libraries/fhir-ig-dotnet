using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// Class with Observation extensions for Observation - Medical Information Data Quality
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-medical-information-data-quality
    /// </summary>
    public static class VrdrFuneralHomeExtensions
    {
        public static VrdrFuneralHome VrdrFuneralHome(this Organization organization)
        {
            return new VrdrFuneralHome(organization);
        }
    }
}
