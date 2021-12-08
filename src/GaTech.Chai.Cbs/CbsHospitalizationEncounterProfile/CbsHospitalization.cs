using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsHospitalizationEncounterProfile
{
    /// <summary>
    /// Case Based Surveillance Hospitalization Encounter Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-hospitalization
    /// </summary>
    public class CbsHospitalization
    {
        readonly Encounter encounter;

        internal CbsHospitalization(Encounter encounter)
        {
            this.encounter = encounter;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Hospitalization Encounter Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-hospitalization
        /// </summary>
        public static Encounter Create()
        {
            var encounter = new Encounter();
            encounter.CbsHospitalization().AddProfile();
            encounter.Class = new Coding("http://terminology.hl7.org/CodeSystem/v3-ActCode", "IMP");
            encounter.Status = Encounter.EncounterStatus.Unknown;
            return encounter;
        }

        /// <summary>
        /// The diagnosis or procedure relevant to the encounter.
        /// Reference to Case Based Surveillance Condition of Interest Profile
        /// </summary>
        public ResourceReference Condition
        {
            get
            {
                return encounter.Diagnosis.Find(d => d.Condition?.Reference.StartsWith("Condition") == true)?.Condition;
            }
            set
            {
                encounter.Diagnosis.RemoveAll(d => d.Condition?.Reference.StartsWith("Condition") == true);
                encounter.Diagnosis.Add(new Encounter.DiagnosisComponent() { Condition = value });

            }
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Hospitalization Encounter profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-hospitalization";

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
