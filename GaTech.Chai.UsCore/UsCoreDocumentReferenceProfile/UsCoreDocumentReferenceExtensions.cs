using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore.UsCoreDocumentReferenceProfile
{
    /// <summary>
    /// Class with Encounter extensions for US Core Encounter Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-encounter
    /// </summary>
    public static class UsCoreDocumentReferenceExtensions
    {
        public static UsCoreDocumentReference UsCoreDocumentReference(this DocumentReference documentReference)
        {
            return new UsCoreDocumentReference(documentReference);
        }
    }
}
