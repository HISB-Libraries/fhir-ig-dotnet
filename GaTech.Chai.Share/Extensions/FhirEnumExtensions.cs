using System;
using System.Linq;
using System.Reflection;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;

namespace GaTech.Chai.Share
{
    /// <summary>
    /// Enum extension for FHIR enum data
    /// </summary>
    public static class FhirEnumExtensions
    {
        public static string GetEnumSystem(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            EnumLiteralAttribute[] attributes = (EnumLiteralAttribute[])fi.GetCustomAttributes(typeof(EnumLiteralAttribute), false);

            if (attributes != null && attributes.Length > 1)
                return attributes[1].Literal;
            else
                return value.ToString();
        }

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

        public static T GetEnumValueFromCode<T>(this string code)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(EnumLiteralAttribute), false), (f, a) => new { Field = f, Att = a })
                            .Where(a => ((EnumLiteralAttribute[])a.Att)[0].Literal == code).SingleOrDefault();
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }
    }
}
