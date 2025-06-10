using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with MessageHeader extensions for MessageHeaderDeathCertificateReviewProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/MessageHeader-death-certificate-review
    /// </summary>
    public static class MessageHeaderDeathCertificateReviewExtensions
    {
        public static MessageHeaderDeathCertificateReview MessageHeaderDeathCertificateReview(this MessageHeader messageHeader)
        {
            return new MessageHeaderDeathCertificateReview(messageHeader);
        }
    }
}
