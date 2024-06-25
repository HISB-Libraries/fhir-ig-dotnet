using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with MessageHeader extensions for MessageHeaderToxicologyToMdiProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-tox-to-mdi
    /// </summary>
    public static class MessageHeaderToxicologyToMdiExtensions
    {
        public static MessageHeaderToxicologyToMdi MessageHeaderToxicologyToMdi(this MessageHeader messageHeader)
        {
            return new MessageHeaderToxicologyToMdi(messageHeader);
        }
    }
}
