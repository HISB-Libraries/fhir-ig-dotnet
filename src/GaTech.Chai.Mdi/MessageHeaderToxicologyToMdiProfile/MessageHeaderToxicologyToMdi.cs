using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Mdi.Common;
using System.Collections.Generic;

namespace GaTech.Chai.Mdi.MessageHeaderToxicologyToMdiProfile
{
    /// <summary>
    /// MessageHeaderToxicologyToMdiProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
    /// </summary>
    public class MessageHeaderToxicologyToMdi
    {
        readonly MessageHeader messageHeader;
        readonly static Dictionary<string, Resource> resources = new();

        internal MessageHeaderToxicologyToMdi(MessageHeader messageHeader)
        {
            this.messageHeader = messageHeader;
        }

        /// <summary>
        /// Factory for MessageHeaderToxicologyToMdiProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
        /// </summary>
        public static MessageHeader Create()
        {
            // clear static resource container.
            resources.Clear();

            var messageHeader = new MessageHeader();
            messageHeader.MessageHeaderToxicologyToMdi().AddProfile();
            messageHeader.Event = MdiCodeSystem.MdiCodes.ToxResultReport;

            return messageHeader;
        }

        /// <summary>
        /// Factory for MessageHeaderToxicologyToMdiProfile with sourceEndPointUrl and DiagnosticReport
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-toxicology-to-mdi
        /// </summary>
        public static MessageHeader Create(string sourceEndpointUrlString, DiagnosticReport diagnosticReport)
        {
            // clear static resource container.
            resources.Clear();

            var messageHeader = new MessageHeader();

            messageHeader.MessageHeaderToxicologyToMdi().AddProfile();
            messageHeader.Event = MdiCodeSystem.MdiCodes.ToxResultReport;
            messageHeader.Source = new MessageHeader.MessageSourceComponent { Endpoint = sourceEndpointUrlString };
            messageHeader.MessageHeaderToxicologyToMdi().ToxicologyReport = diagnosticReport;            

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

        /// <summary>
        /// adding or getting Focus
        /// </summary>
        public DiagnosticReport ToxicologyReport
        {
            get
            {
                ResourceReference reportReference = this.messageHeader.Focus?[0];
                if (reportReference != null)
                {
                    return (DiagnosticReport) resources[reportReference.Reference];
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