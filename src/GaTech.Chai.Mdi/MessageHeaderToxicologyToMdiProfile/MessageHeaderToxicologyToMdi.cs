using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.Common;

namespace GaTech.Chai.Mdi.MessageHeaderToxicologyToMdiProfile
{
    /// <summary>
    /// MessageHeaderToxicologyToMdiProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
    /// </summary>
    public class MessageHeaderToxicologyToMdi
    {
        readonly MessageHeader messageHeader;

        internal MessageHeaderToxicologyToMdi(MessageHeader messageHeader)
        {
            this.messageHeader = messageHeader;
            messageHeader.Event = MdiCodeSystem.MdiCodes.ToxResultReport.Coding[0];
        }

        /// <summary>
        /// Factory for MessageHeaderToxicologyToMdiProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
        /// </summary>
        public static MessageHeader Create()
        {
            var messageHeader = new MessageHeader();
            messageHeader.MessageHeaderToxicologyToMdi().AddProfile();
            return messageHeader;
        }

        /// <summary>
        /// The official URL for the MessageHeaderToxicologyToMdiProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi";

        /// <summary>
        /// Set profile for the MessageHeaderToxicologyToMdiProfile
        /// </summary>
        public void AddProfile()
        {
            messageHeader.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the MessageHeaderToxicologyToMdiProfile
        /// </summary>
        public void RemoveProfile()
        {
            messageHeader.RemoveProfile(ProfileUrl);
        }

    }
}