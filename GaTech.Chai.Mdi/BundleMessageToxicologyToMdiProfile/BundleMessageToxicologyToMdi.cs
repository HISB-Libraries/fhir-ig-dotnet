using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// BundleMessageToxicologyToMdiProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi
    /// </summary>
    public class BundleMessageToxicologyToMdi
    {
        readonly Bundle bundle;

        internal BundleMessageToxicologyToMdi(Bundle bundle)
        {
            this.bundle = bundle;
        }

        /// <summary>
        /// Factory for BundleMessageToxicologyToMdi Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi
        /// </summary>
        public static Bundle Create()
        {
            var bundle = new Bundle();
            bundle.BundleMessageToxicologyToMdi().AddProfile();
            bundle.Type = Bundle.BundleType.Message;

            return bundle;
        }

        /// <summary>
        /// Factory for BundleMessageToxicologyToMdi Profile with Identifier, MessageHeader
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi
        /// </summary>
        public static Bundle Create(Identifier identifier, MessageHeader messageHeader)
        {
            var bundle = new Bundle();

            bundle.BundleMessageToxicologyToMdi().AddProfile();
            bundle.Type = Bundle.BundleType.Message;

            if (identifier != null) bundle.Identifier = identifier;
            if (messageHeader != null)
            {
                bundle.BundleMessageToxicologyToMdi().ToxToMdiMessage = messageHeader;
            }


            return bundle;
        }

        /// <summary>
        /// The official URL for the BundleMessageToxicologyToMdi profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi";

        /// <summary>
        /// Set profile BundleMessageToxicologyToMdiProfile.
        /// </summary>
        public void AddProfile()
        {
            bundle.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for BundleMessageToxicologyToMdiProfile.
        /// </summary>
        public void RemoveProfile()
        {
            bundle.RemoveProfile(ProfileUrl);
        }

        public MessageHeader ToxToMdiMessage
        {
            get
            {
                return (MessageHeader)bundle.Entry?[0].Resource;
            }
            set
            {
                // First check if the composition is
                // a http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi profile.
                if (!value.hasProfile(MessageHeaderToxicologyToMdi.ProfileUrl))
                {
                    Console.WriteLine("Bundle-message-tox-to-mdi requires the MessageHeader to be http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi profile");
                    throw (new ArgumentException("BundleMessageToxicologyToMdi bundle must have MessageHeader-toxicology-to-mdi."));
                }

                // First entry MUST be MessageHeader. Clear the entry
                bundle.Entry.Clear();
                bundle.AddResourceEntry(value, value.AsReference().Reference);
                //bundle.Entry.Add(new Bundle.EntryComponent() { FullUrl = value.AsReference().Reference, Resource = value });

                // We have focus in messageheader. Add resource(s) in the focus to entries if we have them.
                Dictionary<string, Resource> entryResources = value.MessageHeaderToxicologyToMdi().GetResourcesInFocus();
                foreach (var urlAndResource in entryResources)
                {
                    // We should have only one DiagnosticReport. Add this diagnositicReport to entry.
                    DiagnosticReport toxReport = urlAndResource.Value as DiagnosticReport;
                    bundle.AddResourceEntry(toxReport, toxReport.AsReference().Reference);

                    // This diagnostic report has references.
                    Dictionary<string, Resource> toxReferencedResources = toxReport.DiagnosticReportToxicologyLabResultToMdi().GetReferencedResources();
                    foreach(var referecedResource in toxReferencedResources)
                    {
                        bundle.AddResourceEntry(referecedResource.Value, referecedResource.Value.AsReference().Reference);
                    }
                }
            }
        }

    }
}