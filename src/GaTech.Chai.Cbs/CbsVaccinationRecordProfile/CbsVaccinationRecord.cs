using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Extensions;

namespace GaTech.Chai.Cbs.CbsVaccinationRecordProfile
{
    /// <summary>
    /// Case Based Surveillance Vaccinaton Record Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-record
    /// </summary>
    public class CbsVaccinationRecord
    {
        readonly Immunization immunization;

        internal CbsVaccinationRecord(Immunization immunization)
        {
            this.immunization = immunization;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Vaccinaton Record Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-record
        /// </summary>
        public static Immunization Create()
        {
            var immunization = new Immunization();
            immunization.CbsVaccinationRecord().AddProfile();
            return immunization;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Vaccinaton Record profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-record";

        /// <summary>
        /// Set the assertion that a immunization object conforms to the Case Based Surveillance Vaccinaton Record Profile.
        /// </summary>
        public void AddProfile()
        {
            immunization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a immunization object conforms to the Case Based Surveillance Vaccinaton Record Profile.
        /// </summary>
        public void RemoveProfile()
        {
            immunization.RemoveProfile(ProfileUrl);
        }
    }
}