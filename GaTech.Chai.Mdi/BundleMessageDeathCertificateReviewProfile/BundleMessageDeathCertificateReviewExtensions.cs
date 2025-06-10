using Hl7.Fhir.Model;

namespace GaTech.Chai.Mdi
{
    /// <summary>
    /// Class with Bundle extensions for the BundleMessageDeathCertificateReviewProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Bundle-message-death-certificate-review
    /// </summary>
    public static class BundleMessageDeathCertificateReviewExtensions
    {
        public static BundleMessageDeathCertificateReview BundleMessageDeathCertificateReview(this Bundle bundle)
        {
            return new BundleMessageDeathCertificateReview(bundle);
        }
    }
}
