using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCbs.HospitalizationEncounterProfile
{
    /// <summary>
    /// Case Based Surveillance Hospitalization Encounter Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-hospitalization
    /// </summary>
    public class UsCbsHospitalization
    {
        readonly Encounter encounter;

        internal UsCbsHospitalization(Encounter encounter)
        {
            this.encounter = encounter;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Hospitalization Encounter Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-hospitalization
        /// </summary>
        public static Encounter Create()
        {
            var encounter = new Encounter();
            encounter.UsCbsHospitalization().AddProfile();
            encounter.Class = new Coding("http://terminology.hl7.org/CodeSystem/v3-ActCode", "IMP", "inpatient encounter");
            encounter.Type.Add(new CodeableConcept("http://www.ama-assn.org/go/cpt", "42628595", "Inpatient Hospital", null)); 
            return encounter;
        }

        /// <summary>
        /// reasonReference for the encounter.
        /// Reference to Case Based Surveillance Condition of Interest Profile
        /// </summary>
        public ResourceReference Reason
        {
            get
            {
                return encounter.ReasonReference?[0];
            }
            set
            {
                encounter.ReasonReference.Clear();
                encounter.ReasonReference.Add(value);

            }
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Hospitalization Encounter profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-hospitalization";

        /// <summary>
        /// Set data-absent-reason extension to Participant
        /// </summary>
        public Code ParticipantDataAbsentReason
        {
            get => encounter.Participant?[0].GetExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
            set
            {
                if (encounter.Participant.Count == 0)
                    encounter.Participant.Add(new Encounter.ParticipantComponent());
                encounter.Participant[0].Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", new FhirString("masked"));
            }
        }

        /// <summary>
        /// Set data-absent-reason extension to Location
        /// </summary>
        public Code LocationDataAbsentReason
        {
            get => encounter.Location?[0].GetExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason")?.Value as Code;
            set
            {
                if (encounter.Location == null || encounter.Location.Count == 0)
                    encounter.Location.Add(new Encounter.LocationComponent());
                encounter.Location[0].Extension.AddOrUpdateExtension(
                    "http://hl7.org/fhir/StructureDefinition/data-absent-reason", new FhirString("masked"));
            }
        }

        /// <summary>
        /// Set the assertion that an condition object conforms to the Case Based Surveillance Hospitalization Encounter profile.
        /// </summary>
        public void AddProfile()
        {
            this.encounter.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the Case Based Surveillance Hospitalization Encounter profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.encounter.RemoveProfile(ProfileUrl);
        }

    }
}
