using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsVaccinationIndicationProfile
{
    /// <summary>
    /// Case Based Surveillance Vaccinaton Indication Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
    /// </summary>
    public class CbsVaccinationIndication
    {
        readonly Observation observation;

        internal CbsVaccinationIndication(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Vaccinaton Indication Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.CbsVaccinationIndication().AddProfile();
            observation.Code = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.232", "vac126",
                "Did the Subject Ever Receive a Vaccine Against This Disease");

            return observation;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Vaccinaton Indication profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Vaccinaton Indication Profile.
        /// </summary>
        public void AddProfile()
        {
            observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Vaccinaton Indication Profile.
        /// </summary>
        public void RemoveProfile()
        {
            observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// Yes No Unknown (YNU) (2.16.840.1.114222.4.11.888)
        /// Value set used to respond to any question that can be answered Yes, No, or Unknown.
        /// </summary>
        public static class YesNoUnknown
        {
            public const string ValueSetOid = "urn:oid:2.16.840.1.114222.4.11.888";

            public static CodeableConcept Yes => Encode("Y", "Yes");
            public static CodeableConcept No => Encode("N", "No");
            public static CodeableConcept Unknown => Encode("U", "Unknown");
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSetOid, value, display, null);
        }
    }
}