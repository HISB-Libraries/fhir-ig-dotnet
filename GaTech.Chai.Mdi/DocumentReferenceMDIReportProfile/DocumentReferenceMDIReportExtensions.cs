using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Observation extensions for ObservationDeathDateProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Observation-death-date
    /// </summary>
    public static class DocumentReferenceMDIReportExtensions
    {
        public static DocumentReferenceMDIReport DocumentReferenceMDIReport(this DocumentReference documentReference)
        {
            return new DocumentReferenceMDIReport(documentReference);
        }
    }
}
