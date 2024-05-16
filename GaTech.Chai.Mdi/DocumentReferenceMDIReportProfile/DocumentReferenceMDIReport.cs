using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Collections.Generic;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.Mdi.ObservationDeathDateProfile;

namespace GaTech.Chai.Mdi.DocumentReferenceMDIReportProfile
{
    /// <summary>
    /// DocumentReferenceMDIReportProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/DocumentReference-mdi-report
    /// </summary>
    public class DocumentReferenceMDIReport
    {
        readonly DocumentReference documentReference;
        readonly static Dictionary<string, Resource> resources = new();

        internal DocumentReferenceMDIReport(DocumentReference documentReference)
        {
            this.documentReference = documentReference;
        }

        /// <summary>
        /// Factory for DocumentReferenceMDIReportProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/DocumentReference-mdi-report
        /// </summary>
        public static DocumentReference Create()
        {
            // clear static resource container.
            resources.Clear();

            var documentReference = new DocumentReference();
            documentReference.DocumentReferenceMDIReport().AddProfile();

            return documentReference;
        }

        /// <summary>
        /// Factory for DocumentReferenceMDIReportProfile with Subject patient
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/DocumentReference-mdi-report
        /// </summary>
        public static DocumentReference Create(Patient subject, DocumentReferenceStatus status, CodeableConcept type, List<CodeableConcept> categories, string contentUrl, byte[] contentData)
        {
            // clear static resource container.
            resources.Clear();

            var documentReference = new DocumentReference();

            documentReference.DocumentReferenceMDIReport().AddProfile();
            documentReference.DocumentReferenceMDIReport().SubjectAsResource = subject;
            documentReference.Status = status;
            documentReference.Type = type;
            documentReference.Category = categories;

            Attachment attachment = new();
            if (contentUrl != null)
            {
                attachment.Url = contentUrl;
            }

            if (contentUrl != null)
            {
                attachment.Data = contentData;
            }

            documentReference.Content = new List<DocumentReference.ContentComponent> { new DocumentReference.ContentComponent() { Attachment = attachment } };

            return documentReference;
        }

        /// <summary>
        /// The official URL for DocumentReferenceMDIReportProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/DocumentReference-mdi-report";

        /// <summary>
        /// Set profile for the DocumentReferenceMDIReportProfile
        /// </summary>
        public void AddProfile()
        {
            this.documentReference.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the DocumentReferenceMDIReportProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.documentReference.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// setting subject reference and store the resource for future use
        /// </summary>
        public Patient SubjectAsResource
        {
            get
            {
                Resource value;
                resources.TryGetValue(this.documentReference.Subject.Reference, out value);

                return (Patient)value;
            }
            set
            {
                this.documentReference.Subject = value.AsReference();
                resources[value.AsReference().Reference] = value;
            }
        }

        public Dictionary<String, Resource> GetReferencedResources()
        {
            return resources;
        }
    }
}
