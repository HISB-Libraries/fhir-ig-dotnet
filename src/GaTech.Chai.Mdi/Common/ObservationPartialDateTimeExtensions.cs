using System;
using Hl7.Fhir.Model;
using Newtonsoft.Json.Linq;

namespace GaTech.Chai.Mdi.Common
{
    public static class ObservationPartialDateTimeExtensions
    {
        /// <summary>
        /// Partial DateTime Extension on Observation.valueDateTime
        /// </summary>
        public static  Extension GetPartialDateTime(this Observation observation)
        {
            FhirDateTime deathDateTiem = (FhirDateTime)observation.Value;

            return deathDateTiem.GetExtension(MdiUrls.partialDateTimeUrl);
        }

        public static Extension SetPartialDateTime(this Observation observation, DataType year, DataType month, DataType day, DataType time)
        {
            Extension partialDateTimeExt = new Extension { Url = MdiUrls.partialDateTimeUrl };

            if (year is UnsignedInt)
            {
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeYearUrl, (UnsignedInt)year);
            }
            else if (year is Code)
            {
                // This is data-absent-reason
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeYearUrl, null)
                    .AddExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason", year);
            }

            if (month is UnsignedInt)
            {
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeMonthUrl, (UnsignedInt)month);
            }
            else if (month is Code)
            {
                // This is data-absent-reason
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeMonthUrl, null)
                    .AddExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason", month);
            }

            if (day is UnsignedInt)
            {
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeDayUrl, (UnsignedInt)day);
            }
            else if (day is Code)
            {
                // This is data-absent-reason
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeDayUrl, null)
                    .AddExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason", day);
            }

            if (time is Time)
            {
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeTimeUrl, time);
            }
            else if (time is Code)
            {
                // This is data-absent-reason
                partialDateTimeExt.AddExtension(MdiUrls.partialDateTimeTimeUrl, null)
                    .AddExtension("http://hl7.org/fhir/StructureDefinition/data-absent-reason", time);
            }

            FhirDateTime valueDateTime = (FhirDateTime)observation.Value;
            valueDateTime.Extension.Add(partialDateTimeExt);

            return partialDateTimeExt;
        }
    }
}

