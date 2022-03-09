using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.FhirIg.Common;
using GaTech.Chai.UsCbs.Common;

namespace GaTech.Chai.Cbs.SocialDeterminantsOfHealthProfile
{
    /// <summary>
    /// Case Based Surveillance Social Determinants of Health Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-social-determinants-of-health
    /// </summary>
    public class CbsSocialDeterminantsOfHealth
    {
        readonly Observation observation;
        readonly UsCbsProgramSpecificTimeWindow programSpecificTimeWindow;

        internal CbsSocialDeterminantsOfHealth(Observation observation)
        {
            this.observation = observation;
            this.programSpecificTimeWindow = new UsCbsProgramSpecificTimeWindow(observation);

        }

        /// <summary>
        /// Factory for Case Based Surveillance Social Determinants of Health Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-social-determinants-of-health
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.CbsSocialDeterminantsOfHealth().AddProfile();

            return observation;
        }

        /// <summary>
        /// Case Based Surveillance Program Specific Time Window
        /// </summary>
        public UsCbsProgramSpecificTimeWindow ProgramSpecificTimeWindow => this.programSpecificTimeWindow;

        /// <summary>
        /// The official URL for the Case Based Surveillance Social Determinants of Health profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-social-determinants-of-health";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Social Determinants of Health Profile.
        /// </summary>
        public void AddProfile()
        {
            observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Social Determinants of Health Profile.
        /// </summary>
        public void RemoveProfile()
        {
            observation.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// CBS Case Social Determinants of Health Category
        /// Categories for social determinants of health and related elements of social history which may be captured in the SDOH profile.
        /// </summary>
        public static class Categories
        {
            public const string ValueSet = "http://cbsig.chai.gatech.edu/CodeSystem/cbs-temp-code-system";

            public static CodeableConcept Sogi => Encode("sogi", "Sexual Orientation and Gender Identity");
            public static CodeableConcept HousingOrResidence => Encode("housing-or-residence", "Housing Insecurity or Residence Characteristics");
            public static CodeableConcept Education => Encode("education", "Education Level");
            public static CodeableConcept FoodInsecurity => Encode("food-insecurity", "Food Insecurity");
            public static CodeableConcept Encode(string value, string display) => new CodeableConcept(ValueSet, value, display, null);
        }

        /// <summary>
        /// Case Social Determinants of Health Codes
        /// Codes for social determinants of health and related elements of social history which may be captured in the SDOH profile.
        /// </summary>
        public static class Codes
        {
            public const string loinc = "http://loinc.org";
            public const string somed = "http://snomed.info/sct";

            public static CodeableConcept SexualOrientation => Somed("76690-7", "Sexual orientation");
            public static CodeableConcept GenderIdentity => Somed("76691-5", "Gender identity");
            public static CodeableConcept CharacteristicsOfResidence => Somed("75274-1", "Characteristics of residence");
            public static CodeableConcept Incarceration => Loinc("4536100", "Incarceration");
            public static CodeableConcept Loinc(string value, string display) => new CodeableConcept(loinc, value, display, null);
            public static CodeableConcept Somed(string value, string display) => new CodeableConcept(somed, value, display, null);
        }
    }
}