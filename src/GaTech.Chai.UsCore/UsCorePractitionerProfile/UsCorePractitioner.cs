﻿using System;
using Hl7.Fhir.Model;
using GaTech.Chai.FhirIg.Extensions;

namespace GaTech.Chai.UsCore.PractitionerProfile
{
    /// <summary>
    /// US Core Practitioner Profile Extensions
    /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner
    /// </summary>
    public class UsCorePractitioner
    {
        readonly Practitioner practitioner;

        internal UsCorePractitioner(Practitioner practitioner)
        {
            this.practitioner = practitioner;
        }

        /// <summary>
        /// Factory for US Core Practitioner Profile
        /// http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner
        /// </summary>
        public static Practitioner Create()
        {
            var practitioner = new Practitioner();
            practitioner.UsCorePractitioner().AddProfile();
            return practitioner;
        }

        /// <summary>
        /// The official URL for the US Core Practitioner profile, used to assert conformance.
        /// </summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-practitioner";

        /// <summary>
        /// Set the assertion that an practitioner object conforms to the US Core Practitioner profile.
        /// </summary>
        public void AddProfile()
        {
            this.practitioner.AddProfile(ProfileUrl);
        }

        /// <summary>
        /// Clear the assertion that an condition object conforms to the US Core Practitioner profile.
        /// </summary>
        public void RemoveProfile()
        {
            this.practitioner.RemoveProfile(ProfileUrl);
        }

        public string NPI
        {
            get => this.practitioner.Identifier?.Find(c => c.System == "http://hl7.org/fhir/sid/us-npi")?.Value.ToString();
            set
            {
                this.practitioner.Identifier.AddOrUpdateIdentifier("http://hl7.org/fhir/sid/us-npi", value);
            }
        }
    }
}