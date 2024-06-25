using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsPublicHealth
{
    /// <summary>
    /// Travel History Purpose Helper
    /// </summary>
    public class TravelPurpose
    {
        readonly Observation observation;

        internal TravelPurpose(Observation observation)
        {
            this.observation = observation;
        }

        /// <summary>
        /// Travel Purpose in 
        /// https://phinvads.cdc.gov/vads/ViewValueSet.action?oid=2.16.840.1.114222.4.11.3108
        /// </summary>
        public CodeableConcept Purpose
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
                Code = new CodeableConcept("http://snomed.info/sct", "280147009", "Type of activity", null)
            };
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
                c => c.Code.Coding.Exists(coding => coding.Code == "280147009" && coding.System == "http://snomed.info/sct"));
            return component;
        }

        public static class PurposeValueSet
        {
            public static CodeableConcept ActiveDutyMilitary => new CodeableConcept("http://snomed.info/sct", "702348006", "Active duty military", null);
            public static CodeableConcept Business => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC386", "business", null);
            public static CodeableConcept Migration => new CodeableConcept("http://www.nlm.nih.gov/research/umls", "C0013976", "migration", null);
            public static CodeableConcept Other => new CodeableConcept("urn:oid:2.16.840.1.113883.5.1008", "OTH", "other (specify)", null);
            public static CodeableConcept DisasterRelief => new CodeableConcept("http://snomed.info/sct", "440593000", "Disaster Relief", null);
            public static CodeableConcept Tourism => new CodeableConcept("http://www.nlm.nih.gov/research/umls", "C0683587", "tourism", null);
            public static CodeableConcept Unknown => new CodeableConcept("urn:oid:2.16.840.1.113883.5.1008", "UNK", "unknown", null);
            public static CodeableConcept VisitingRelativesFriends => new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC387", "Visiting relatives/friends", null);
        }
    }
}