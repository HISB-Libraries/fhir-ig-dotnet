using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;
using System.Linq;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// This Bundle profile represents a Document Bundle Message Death Certificate Review.
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-death-certificate-review
    /// </summary>
    public class BundleMessageDeathCertificateReview
    {
        readonly Bundle bundle;

        internal BundleMessageDeathCertificateReview(Bundle bundle)
        {
            this.bundle = bundle;
        }

        /// <summary>
        /// Factory for BundleMessageDeathCertificateReviewProfile with composition and identifier
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-death-certificate-review
        /// </summary>
        public static Bundle Create(MessageHeader messageheader)
        {
            Bundle bundle = new();
            bundle.BundleMessageDeathCertificateReview().DCRMessage = messageheader ?? throw new Exception("MessageHeader cannot be null for Message DCR Bundle entry[0].");
            // bundle.BundleMessageDeathCertificateReview().DCRDocument = bundleDocumentMDIDCR ?? throw new Exception("DocumentBundle cannot be null for Message DCR Bundle entry[1].");
            bundle.BundleMessageDeathCertificateReview().AddProfile();
            bundle.BundleMessageDeathCertificateReview().AddFixedValues();

            return bundle;
        }

        public static Bundle Create()
        {
            Bundle bundle = new();
            bundle.BundleDocumentMdiAndEdrs().AddFixedValues();
            bundle.BundleDocumentMdiAndEdrs().AddProfile();

            return bundle;
        }

        public void AddFixedValues()
        {
            bundle.Type = Bundle.BundleType.Message;
        }

        public void ImportResourcesInEntry()
        {
            foreach (Bundle.EntryComponent entry in this.bundle.Entry)
            {
                if (entry.Resource != null)
                {
                    Record.GetResources()[entry.Resource.AsReference().Reference] = entry.Resource;
                }
            }
        }

        /// <summary>
        /// The official URL for the BundleMessageDeathCertificateReviewProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-death-certificate-review";

        /// <summary>
        /// Set the profile URL for the BundleMessageDeathCertificateReviewProfile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the profile URL for the BundleMessageDeathCertificateReviewProfile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

        public MessageHeader DCRMessage
        {
            get
            {
                return this.bundle.Entry?[0].Resource as MessageHeader;
            }
            set
            {
                if (!value.hasProfile(MessageHeaderDeathCertificateReview.ProfileUrl))
                {
                    throw (new ArgumentException("Bundle-message-death-certificate-review requires the MessageHeader to be http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-death-certificate-review profile"));
                }

                // First entry MUST be MessageHeader. Clear the entry
                bundle.Entry.Clear();
                bundle.AddResourceEntry(value, value.AsReference().Reference);
                //bundle.Entry.Add(new Bundle.EntryComponent() { FullUrl = value.AsReference().Reference, Resource = value });

                // We have focus in messageheader. Add resource(s) in the focus to entries if we have them.
                Dictionary<string, Resource> entryResources = value.MessageHeaderDeathCertificateReview().GetResourcesInFocus();
                foreach (var urlAndResource in entryResources)
                {
                    // We should have only one Document Bundle. Add this Bundle to entry.
                    Bundle dcrBundleDoc = urlAndResource.Value as Bundle;
                    bundle.AddResourceEntry(dcrBundleDoc, dcrBundleDoc.AsReference().Reference);

                    // This dcrBundle document has references.
                    Dictionary<string, Resource> dcrReferencedResources = dcrBundleDoc.BundleDocumentMdiDcr().GetReferencedResources();
                    foreach (var referecedResource in dcrReferencedResources)
                    {
                        bundle.AddResourceEntry(referecedResource.Value, referecedResource.Value.AsReference().Reference);
                    }
                }
            }
        }

        public Bundle DCRDocument
        {
            get
            {
                if (this.bundle.Entry?.Count >= 1)
                {
                    MessageHeader mh = this.bundle.Entry[0].Resource as MessageHeader;
                    return mh.MessageHeaderDeathCertificateReview().BundleDocumentDeathCertificateReview;
                }

                return null;
            }
            // set
            // {
            //     if (!value.hasProfile(BundleDocumentMdiDcr.ProfileUrl))
            //     {
            //         throw (new ArgumentException("Bundle-message-death-certificate-review requires the Document to be http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-document-mdi-dcr profile"));
            //     }

            //     // First entry MUST be MessageHeader. Clear the entry
            //     if (this.bundle.Entry?.Count < 1)
            //     {
            //         throw (new ArgumentException("Bundle-message-death-certificate-review requires the first entry to be MessageHeader. But, the entry is empty"));
            //     }

            //     IEnumerable<Bundle.EntryComponent> foundResourceRefs = bundle.FindEntry(value.AsReference().Reference);
            //     if (!foundResourceRefs.Any())
            //     {
            //         bundle.AddResourceEntry(value, value.AsReference().Reference);
            //     }

            //     // Get the messageHeader so that we can put this bundle document in the focus.
            //     MessageHeader mh = this.bundle.Entry[0].Resource as MessageHeader;
            //     mh.MessageHeaderDeathCertificateReview().BundleDocumentDeathCertificateReview = value;
            // }
        }
    }
}