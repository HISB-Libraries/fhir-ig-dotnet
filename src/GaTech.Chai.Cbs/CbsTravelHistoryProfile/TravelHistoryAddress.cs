using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Cbs.CbsTravelHistoryProfile
{
    /// <summary>
    /// Travel History Address
    /// </summary>
    public class TravelHistoryAddress
    {
        readonly Observation observation;

        internal TravelHistoryAddress(Observation observation)
        {
            this.observation = observation;
        }

        public const string ExtensionUrl = "http://hl7.org/fhir/us/ecr/StructureDefinition/us-ph-address-extension";
        public const string LocationUri = "http://terminology.hl7.org/CodeSystem/v3-ParticipationType";

        /// <summary>
        /// Travel history address
        /// </summary>
        public Address Address
        {
            get
            {
                var component = GetComponent();
                return component?.GetExtension(ExtensionUrl)?.Value as Address;
            }
            set
            {
                var component = GetOrAddComponent();
                component.Extension.AddOrUpdateExtension(ExtensionUrl, value);
            }
        }

        /// <summary>
        /// Date or period of time spent in the location
        /// Alias for Observation.Effective
        /// </summary>
        public DataType TimeSpent
        {
            get
            {
                return observation.Effective;
            }
            set
            {
                observation.Effective = value;
            }
        }

        /// <summary>
        /// Geographical location (2.16.840.1.114222.4.11.3201)
        /// https://phinvads.cdc.gov/vads/ViewValueSet.action?oid=2.16.840.1.114222.4.11.3201
        /// </summary>
        public CodeableConcept Location
        {
            get
            {
                var component = GetComponent();
                return component?.Value as CodeableConcept;
            }
            set
            {
                var component = GetOrAddComponent();
                component.Value = value;
            }
        }

        internal Observation.ComponentComponent AddComponent()
        {
            var component = new Observation.ComponentComponent()
            {
                Code = new CodeableConcept(LocationUri, "LOC")
            };
            component.Code.Coding.First().Display = "Location";
            observation.Component.Add(component);
            return component;
        }

        private Observation.ComponentComponent GetOrAddComponent()
        {
            var component = GetComponent();
            if (component == null)
                component = AddComponent();
            return component;
        }

        private Observation.ComponentComponent GetComponent()
        {
            var component = observation.Component.Find(
                c => c.Code.Coding.Exists(coding => coding.Code == "LOC" && coding.System == LocationUri));
            return component;
        }
    }
}