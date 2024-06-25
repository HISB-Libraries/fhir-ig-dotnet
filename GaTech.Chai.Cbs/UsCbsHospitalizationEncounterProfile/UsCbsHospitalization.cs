using Hl7.Fhir.Model;
using GaTech.Chai.Share;

namespace GaTech.Chai.UsCbs.HospitalizationEncounterProfile
{
    /// <summary>
    /// US Case Based Surveillance Hospitalization Profile
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
        /// Factory for US Case Based Surveillance Hospitalization Profile
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
        /// Set profile for US Case Based Surveillance Hospitalization Profile
        /// </summary>
        public void AddProfile()
        {
            this.encounter.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for US Case Based Surveillance Hospitalization Profile
        /// </summary>
        public void RemoveProfile()
        {
            this.encounter.RemoveProfile(ProfileUrl);
        }

        /// <summary>
        /// reasonReference for the encounter.
        /// Reference to US Case Based Surveillance Hospitalization Profile
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
        /// The official URL for the US Case Based Surveillance Hospitalization Profile, used to assert conformance.
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
    }
}
