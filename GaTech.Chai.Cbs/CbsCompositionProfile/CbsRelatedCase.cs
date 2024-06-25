using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CompositionProfile
{
    /// <summary>
    /// Composition extenstion for CBS Related case 
    /// </summary>
    public class CbsRelatedCase
    {
        readonly Composition composition;

        internal CbsRelatedCase(Composition composition)
        {
            this.composition = composition;
        }

        public const string ExtUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-related-case";

        public string CaseNumber
        {
            set
            {
                var relatedCaseExt = AddOrUpdateRelatedCaseExtension();
                relatedCaseExt.Extension.AddOrUpdateExtension(new Extension("case-number", new FhirString(value)));
            }
            get
            {
                var relatedCaseExt = composition.GetExtension(ExtUrl);
                return (relatedCaseExt?.GetExtension("case-number").Value as FhirString).ToString();
            }
        }

        public CodeableConcept CaseType
        {
            set
            {
                var relatedCaseExt = AddOrUpdateRelatedCaseExtension();
                relatedCaseExt.Extension.AddOrUpdateExtension(new Extension("case-type", value));
            }
            get
            {
                var relatedCaseExt = composition.GetExtension(ExtUrl);
                return relatedCaseExt?.GetExtension("case-type").Value as CodeableConcept;
            }
        }

        private Extension AddOrUpdateRelatedCaseExtension()
        {
            var relatedCaseExt = new Extension() { Url = ExtUrl };
            return composition.Extension.AddOrUpdateExtension(relatedCaseExt);
        }

        /// <summary>
        /// Codes for CBS Related case 
        /// </summary>
        public static class CbsRelatedCaseTypeVS
        {
            public static CodeableConcept PreviouslyReported => new CodeableConcept("http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "previously-reported", "Previously Reported Case", null);
            public static CodeableConcept ConnectedOutbreakCase => new CodeableConcept("http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "connected-outbreak", "Connected Outbreak Case", null);
            public static CodeableConcept ParentInCongenitalSyphilis => new CodeableConcept("http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system", "parent-congential-syphilis", "Parent in Congenital Syphilis", null);
        }
    }
}
