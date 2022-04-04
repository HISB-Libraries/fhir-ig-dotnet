using System;
using System.Reflection;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Share.Extensions
{
    /// <summary>
    /// Enum extension for FHIR enum data
    /// </summary>
    public static class FhirEnumExtensions
    {
        public static string GetEnumCode(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            EnumLiteralAttribute[] attributes = (EnumLiteralAttribute[])fi.GetCustomAttributes(typeof(EnumLiteralAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Literal;
            else
                return value.ToString();
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
