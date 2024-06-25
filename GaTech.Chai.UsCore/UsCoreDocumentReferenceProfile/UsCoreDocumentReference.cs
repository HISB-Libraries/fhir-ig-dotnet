using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCore
{
    /// <summary>
    /// US Core DocumentReference Profile
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-documentreference
    /// </summary>
    public class UsCoreDocumentReference
    {
        readonly DocumentReference documentReference;

        internal UsCoreDocumentReference(DocumentReference documentReference)
        {
            this.documentReference = documentReference;
        }

        /// <summary>
        /// Factory for US Core DocumentReference Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-documentreference
        /// </summary>
        public static DocumentReference Create()
        {
            var documentReference = new DocumentReference();
            documentReference.UsCoreDocumentReference().AddProfile();
            return documentReference;
        }

        /// <summary>
        /// The official URL for the US Core Encounter profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-documentreference";

        /// <summary>
        /// Set profile for US Core Encounter Profile
        /// </summary>
        public void AddProfile()
        {
            this.documentReference.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Core Encounter Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.documentReference.RemoveProfile(ProfileUrl);
        }
    }
}
