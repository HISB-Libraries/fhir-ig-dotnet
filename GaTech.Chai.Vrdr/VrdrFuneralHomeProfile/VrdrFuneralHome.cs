﻿using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Share;
using System.Collections.Generic;
using GaTech.Chai.UsCore;

namespace GaTech.Chai.Vrdr
{
    /// <summary>
    /// OrganizationCrematoriumProfile
    /// http://hl7.org/fhir/us/mdi/StructureDefinition/Organization-crematorium
    /// </summary>
    public class VrdrFuneralHome
    {
        readonly Organization organization;

        internal VrdrFuneralHome(Organization organization)
        {
            this.organization = organization;
        }

        /// <summary>
        /// Factory for OrganizationCrematoriumProfile
        /// http://hl7.org/fhir/us/mdi/StructureDefinition/Organization-crematorium
        /// </summary>
        public static Organization Create()
        {
            var organization = UsCoreOrganization.Create();

            // it's OK to keep both profiles. But, for simplicity, remove UsCore one. Validation 
            // will be able to back tract the paraent profile.
            organization.UsCoreOrganization().RemoveProfile();
            organization.VrdrFuneralHome().AddProfile();
            organization.Type = [VrdrOrganizationTypeCs.FuneralHome];
            organization.Active = true;

            return organization;
        }

        /// <summary>
        /// Factory for OrganizationCrematoriumProfile with Subject patient
        /// http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-funeral-home
        /// </summary>
        public static Organization Create(string name)
        {
            var organization = UsCoreOrganization.Create(name);
            
            // it's OK to keep both profiles. But, for simplicity, remove UsCore one. Validation 
            // will be able to back tract the paraent profile.
            organization.UsCoreOrganization().RemoveProfile();
            organization.VrdrFuneralHome().AddProfile();
            organization.Type = [VrdrOrganizationTypeCs.FuneralHome];
            organization.Active = true;
            organization.Name = name;

            return organization;
        }

        /// <summary>
        /// The official URL for ObservationMedicalInformationDataQualityProfile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/vrdr/StructureDefinition/vrdr-funeral-home";

        /// <summary>
        /// Set profile for the ObservationMedicalInformationDataQualityProfile
        /// </summary>
        public void AddProfile()
        {
            this.organization.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear profile for the ObservationMedicalInformationDataQualityProfile
        /// </summary>
        public void RemoveProfile()
        {
            this.organization.RemoveProfile(ProfileUrl);
        }

    }
}
