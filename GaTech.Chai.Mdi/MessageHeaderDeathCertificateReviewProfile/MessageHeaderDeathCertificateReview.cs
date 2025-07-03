using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// MessageHeaderDeathCertificateReviewProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-death-certificate-review
    /// </summary>
    public class MessageHeaderDeathCertificateReview
    {
        readonly MessageHeader messageHeader;
        readonly static Dictionary<string, Resource> resources = new();

        internal MessageHeaderDeathCertificateReview(MessageHeader messageHeader)
        {
            this.messageHeader = messageHeader;
        }

        /// <summary>
        /// Factory for MessageHeaderDeathCertificateReviewProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-death-certificate-review
        /// </summary>
        public static MessageHeader Create()
        {
            // clear static resource container.
            resources.Clear();

            var messageHeader = new MessageHeader();
            messageHeader.MessageHeaderDeathCertificateReview().AddProfile();
            messageHeader.Event = MdiCodeSystem.MdiCodes.DeathCertificateReviewEvent;

            return messageHeader;
        }

        /// <summary>
        /// Factory for MessageHeaderDeathCertificateReviewProfile with sourceEndPointUrl and DiagnosticReport
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
        /// </summary>
        public static MessageHeader Create(string sourceEndpointUrlString, CodeableConcept reason, Bundle BundleDCRDocument)
        {
            // clear static resource container.
            resources.Clear();

            var messageHeader = new MessageHeader();

            messageHeader.MessageHeaderDeathCertificateReview().AddProfile();
            messageHeader.Event = MdiCodeSystem.MdiCodes.DeathCertificateReviewEvent;
            messageHeader.Source = new MessageHeader.MessageSourceComponent { Endpoint = sourceEndpointUrlString };
            messageHeader.Reason = reason;
            messageHeader.MessageHeaderDeathCertificateReview().BundleDocumentDeathCertificateReview = BundleDCRDocument; 

            return messageHeader;
        }

        /// <summary>
        /// The official URL for the MessageHeaderDeathCertificateReviewProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-death-certificate-review";

        /// <summary>
        /// Set profile for the MessageHeaderDeathCertificateReviewProfile
        /// </summary>
        public void AddProfile()
        {
            messageHeader.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the MessageHeaderDeathCertificateReviewProfile
        /// </summary>
        public void RemoveProfile()
        {
            messageHeader.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// adding or getting Focus
        /// </summary>
        public Bundle BundleDocumentDeathCertificateReview
        {
            get
            {
                ResourceReference reportReference = this.messageHeader.Focus?[0];
                if (reportReference != null)
                {
                    return (Bundle) resources[reportReference.Reference];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.messageHeader.Focus = new List<ResourceReference>() { value.AsReference() };
                resources[value.AsReference().Reference] = value;
            }
        }
        
        public Dictionary<String, Resource> GetResourcesInFocus()
        {
            return resources;
        }
    }
}