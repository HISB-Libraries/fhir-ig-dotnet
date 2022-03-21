using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.Common;

namespace GaTech.Chai.Mdi.MessageHeaderToxicologyToMdiProfile
{
    /// <summary>
    /// MessageHeaderToxicologyToMdi Profile Extensions
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
    /// </summary>
    public class MessageHeaderToxicologyToMdi
    {
        readonly MessageHeader messageHeader;

        internal MessageHeaderToxicologyToMdi(MessageHeader messageHeader)
        {
            this.messageHeader = messageHeader;
            messageHeader.Event = MdiCodeSystem.ToxResultReport.Coding[0];
        }

        /// <summary>
        /// Factory for BundleMessageToxicologyToMdi Profile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
        /// </summary>
        public static MessageHeader Create()
        {
            var messageHeader = new MessageHeader();
            messageHeader.MessageHeaderToxicologyToMdi().AddProfile();
            return messageHeader;
        }

        /// <summary>
        /// The official URL for the BundleMessageToxicologyToMdi profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi";

        /// <summary>
        /// Set the assertion that a questionnaire object conforms to the BundleMessageToxicologyToMdi Profile.
        /// </summary>
        public void AddProfile()
        {
            messageHeader.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a questionnaire object conforms to the BundleMessageToxicologyToMdi Profile.
        /// </summary>
        public void RemoveProfile()
        {
            messageHeader.RemoveProfile(ProfileUrl);
        }

    }
}