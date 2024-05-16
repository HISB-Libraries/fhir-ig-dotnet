using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.UsCbs.TravelHistoryProfile
{
    /// <summary>
    /// US CBS Period and Mode of Travel helper for US CBS Travel History profile
    /// </summary>
    public class UsCbsPeriodAndModeOfTravel
    {
        readonly Observation observation;

        internal UsCbsPeriodAndModeOfTravel(Observation observation)
        {
            this.observation = observation;
        }

        public const string ExtUrl = "http://cbsig.chai.gatech.edu/StructureDefinition/us-cbs-period-and-mode-of-travel";

        public DataType DateOrPeriodOfTravel
        {
            set
            {
                var dateOrPeriodExt = AddOrUpdateTravelExtension();
                dateOrPeriodExt.Extension.AddOrUpdateExtension(new Extension("dateOrPeriodOfTravel", value));
            }
            get
            {
                var dateOrPeriodExt = observation.GetExtension(ExtUrl);
                return dateOrPeriodExt?.GetExtension("dateOrPeriodOfTravel").Value;
            }
        }

        public CodeableConcept ModeOfTravel
        {
            set
            {
                var modeOfTravelExt = AddOrUpdateTravelExtension();
                modeOfTravelExt.Extension.AddOrUpdateExtension(new Extension("modeOfTravel", value));
            }
            get
            {
                var modeOfTravelExt = observation.GetExtension(ExtUrl);
                return modeOfTravelExt?.GetExtension("modeOfTravel").Value as CodeableConcept;
            }
        }

        public IEnumerable<DataType> RelevantLocation
        {
            set
            {
                var locationExt = AddOrUpdateTravelExtension();
                locationExt.Extension.RemoveAll(r => r.Url == "relevantLocation");
                locationExt.Extension.AddRange(
                    from extCode in value
                    select new Extension("relevantLocation", extCode));
            }
            get
            {
                var locationExt = observation.GetExtension(ExtUrl);
                if (locationExt == null)
                    return Array.Empty<DataType>();
                return from r in locationExt.Extension
                       where r.Url == "relevantLocation"
                       select r.Value as DataType;
            }
        }

        private Extension AddOrUpdateTravelExtension()
        {
            var travelExt = new Extension() { Url = ExtUrl };
            return observation.Extension.AddOrUpdateExtension(travelExt);
        }

        /// <summary>
        /// https://phinvads.cdc.gov/vads/ViewValueSet.action?oid=2.16.840.1.114222.4.11.3107
        /// </summary>
        public static class TravelMode
        {
            public static CodeableConcept Aircraft => new CodeableConcept("http://snomed.info/sct", "21753002", "Aircraft", null);
            public static CodeableConcept Automobile => new CodeableConcept("http://snomed.info/sct", "71783008", "Automobile", null);
            public static CodeableConcept MotorBus => new CodeableConcept("http://snomed.info/sct", "22674006", "Motor bus", null);
            public static CodeableConcept PassengerVessel => new CodeableConcept("http://snomed.info/sct", "262044003", "Passenger vessel", null);
            public static CodeableConcept RailwayTrain => new CodeableConcept("http://snomed.info/sct", "62193008", "Railway train", null);
        }
    }
}
