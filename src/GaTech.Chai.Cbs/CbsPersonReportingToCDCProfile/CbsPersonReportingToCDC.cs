using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.Cbs.CbsPersonReportingToCDCProfile
{
    /// <summary>
    /// Case Based Surveillance Person Reporting To CDC Profile Extensions
    /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
    /// </summary>
    public class CbsPersonReportingToCDC
    {
        readonly Practitioner practitioner;

        internal CbsPersonReportingToCDC(Practitioner practitioner)
        {
            this.practitioner = practitioner;
        }

        /// <summary>
        /// Factory for Case Based Surveillance Person Reporting To CDC Profile
        /// http://cbsig.chai.gatech.edu/StructureDefinition/cbs-vaccination-indication
        /// </summary>
        public static Practitioner Create()
        {
            var practitioner = new Practitioner();
            practitioner.CbsPersonReportingToCDC().AddProfile();

            return practitioner;
        }

        /// <summary>
        /// The official URL for the Case Based Surveillance Person Reporting To CDC profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/cbs-person-reporting-to-cdc";

        /// <summary>
        /// Set the assertion that a observation object conforms to the Case Based Surveillance Person Reporting To CDC Profile.
        /// </summary>
        public void AddProfile()
        {
            practitioner.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that a observation object conforms to the Case Based Surveillance Person Reporting To CDC Profile.
        /// </summary>
        public void RemoveProfile()
        {
            practitioner.RemoveProfile(ProfileUrl);
        }
    }
}