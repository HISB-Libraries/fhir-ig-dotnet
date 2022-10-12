using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace GaTech.Chai.Cbs.VaccinationACIPRecommendationProfile
{
    /// <summary>
    /// Case Based Surveillance Subject Vaccinated per ACIP Recommendations Profile
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-ACIP-Recommendation
    /// </summary>
    public class CbsVaccinationACIPRecommendation
    {
        readonly Observation observation;

        internal CbsVaccinationACIPRecommendation(Observation observation)
        {
            this.observation = observation;
            observation.Code = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.232", "vac148");
            observation.Code.Coding.First().Display = "Vaccinated per ACIP Recommendations";
        }

        /// <summary>
        /// Factory for Case Based Surveillance Subject Vaccinated per ACIP Recommendations Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-ACIP-Recommendation
        /// </summary>
        public static Observation Create()
        {
            var observation = new Observation();
            observation.CbsVaccinationACIPRecommendation().AddProfile();

            return observation;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Subject Vaccinated per ACIP Recommendations profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-ACIP-Recommendation";

        /// <summary>
        /// Set profile for Case Based Surveillance Subject Vaccinated per ACIP Recommendations Profile
        /// </summary>
        public void AddProfile()
        {
            observation.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for Case Based Surveillance Subject Vaccinated per ACIP Recommendations Profile
        /// </summary>
        public void RemoveProfile()
        {
            observation.RemoveProfile(ProfileUrl);
        }

        public CodeableConcept ReasonNotGiven
        {
            get
            {
                Coding coding = this.observation.Component?[0].Code?.Coding?.Find(e => e.System == "urn:oid:2.16.840.1.114222.4.5.232" && e.Code == "vac149");
                if (coding != null)
                {
                    return this.observation.Component?[0].Code;
                } else
                {
                    return null;
                }
            }
            set
            {
                Coding coding = this.observation.Component?[0].Code?.Coding?.Find(e => e.System == "urn:oid:2.16.840.1.114222.4.5.232" && e.Code == "vac149");
                if (coding == null)
                {
                    this.observation.Component = new List<Observation.ComponentComponent> { new Observation.ComponentComponent() { Code = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.232", "vac149", "Reason Not Vaccinated per ACIP Recommendations", null), Value = value } };
                }
                else
                {
                    this.observation.Component[0].Value = value;
                }
            }
        }
    }
}