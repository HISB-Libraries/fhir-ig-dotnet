using System;
using System.Collections.Generic;
using System.Linq;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;
using Newtonsoft.Json.Linq;

namespace GaTech.Chai.Vrcl
{
	public static class VrclAddressExtensions
	{
        public static void SetPredirectionalExt(this Address address, string value)
        {
            address.Extension.AddOrUpdateExtension(new Extension(ExtenstionUrls.PredirExtUrl, new FhirString(value)));
        }

        public static string GetPredirectionalExt(this Address address)
        {
            return address.GetExtensionValue<FhirString>(ExtenstionUrls.PredirExtUrl)?.Value;
        }

        public static void SetStreetNumberExt(this Address address, string value)
        {
            address.Extension.AddOrUpdateExtension(new Extension(ExtenstionUrls.StnumExtUrl, new FhirString(value)));
        }

        public static string GetStreetNumberExt(this Address address)
        {
            return address.GetExtensionValue<FhirString>(ExtenstionUrls.StnumExtUrl)?.Value;
        }

        public static void SetStreetNameExt(this Address address, string value)
        {
            address.Extension.AddOrUpdateExtension(new Extension(ExtenstionUrls.StnameExtUrl, new FhirString(value)));
        }

        public static string GetStreetNameExt(this Address address)
        {
            return address.GetExtensionValue<FhirString>(ExtenstionUrls.StnameExtUrl)?.Value;
        }

        public static void SetStreetDesignatorExt(this Address address, string value)
        {
            address.Extension.AddOrUpdateExtension(new Extension(ExtenstionUrls.StdesigExtUrl, new FhirString(value)));
        }

        public static string GetStreetDesignatorExt(this Address address)
        {
            return address.GetExtensionValue<FhirString>(ExtenstionUrls.StdesigExtUrl)?.Value;
        }

        public static void SetPostDirectionalExt(this Address address, string value)
        {
            address.Extension.AddOrUpdateExtension(new Extension(ExtenstionUrls.PostdirExtUrl, new FhirString(value)));
        }

        public static string GetPostDirectionalExt(this Address address)
        {
            return address.GetExtensionValue<FhirString>(ExtenstionUrls.PostdirExtUrl)?.Value;
        }

        public static void SetUnitOrAptNumberExt(this Address address, string value)
        {
            address.Extension.AddOrUpdateExtension(new Extension(ExtenstionUrls.UnitnumberExtUrl, new FhirString(value)));
        }

        public static string GetUnitOrAptNumberExt(this Address address)
        {
            return address.GetExtensionValue<FhirString>(ExtenstionUrls.UnitnumberExtUrl)?.Value;
        }

        public static void SetCityCode(this Address address, int cityCode)
		{
            FhirString city = address.CityElement ?? new();
			city.SetExtension(ExtenstionUrls.CityCodeExtUrl, new PositiveInt(cityCode));

            address.CityElement = city;
        }

		public static int? GetCityCode(this Address address)
		{
            PositiveInt _cityCode = address.CityElement?.GetExtension(ExtenstionUrls.CityCodeExtUrl)?.Value as PositiveInt;
            return _cityCode.Value;
        }

        public static void SetDistrictCode(this Address address, int districtCode)
        {
            FhirString district = address.DistrictElement ?? new();
            district.SetExtension(ExtenstionUrls.DistrictCodeExtUrl, new PositiveInt(districtCode));

            address.DistrictElement = district;
        }

        public static int? GetDistrictCode(this Address address)
        {
            PositiveInt _districtCode = address.CityElement?.GetExtension(ExtenstionUrls.DistrictCodeExtUrl)?.Value as PositiveInt;
            return _districtCode.Value;
        }
    }
}

