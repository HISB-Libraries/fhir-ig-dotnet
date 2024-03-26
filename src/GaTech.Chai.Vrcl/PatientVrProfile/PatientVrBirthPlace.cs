using System;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Vrcl.Extensions;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vrcl.PatientVrProfile
{
	public class PatientVrBirthPlace
	{
		readonly Patient patient;

        internal PatientVrBirthPlace(Patient patient)
		{
			this.patient = patient;
		}

        public const string ExtUrl = "http://hl7.org/fhir/StructureDefinition/patient-birthPlace";

        public Address Extension
        {
            set
            {
                var bithPlaceExt = AddOrUpdateBirthPlaceExtension();
                bithPlaceExt.Value = value;
            }
            get
            {
                var bithPlaceExt = patient.GetExtension(ExtUrl);
                return bithPlaceExt?.Value as Address;
            }
        }

        private Extension AddOrUpdateBirthPlaceExtension()
        {
            var bithPlaceExt = new Extension() { Url = ExtUrl };
            return patient.Extension.AddOrUpdateExtension(bithPlaceExt);
        }

        public int? CityCode
        {
            set
            {
                Address address = Extension ?? new();
                address.SetCityCode(value.Value);
                Extension = address;
            }
            get
            {
                Address address = Extension;
                if (address != null)
                {
                    return address.GetCityCode().Value;
                }

                return null;
            }
        }

        public int? DistrictCode
        {
            set
            {
                Address address = Extension ?? new();
                address.SetDistrictCode(value.Value);
                Extension = address;
            }
            get
            {
                Address address = Extension;
                if (address != null)
                {
                    return address.GetDistrictCode().Value;
                }

                return null;
            }
        }

        public const string ExtJurisdictionIdVrUrl = "http://hl7.org/fhir/us/vr-common-library/StructureDefinition/Extension-jurisdiction-id-vr";

        public FhirString ExtJurisdictionIdVrElement
        {
            set
            {
                Address address = Extension ?? new();
                address.StateElement ??= new FhirString();
                address.StateElement.SetExtension(ExtJurisdictionIdVrUrl, value);

                Extension = address;
            }
            get
            {
                Address address = Extension;
                if (address != null)
                {
                    return address.StateElement?.GetExtension(ExtJurisdictionIdVrUrl)?.Value as FhirString;
                }

                return null;
            }
        }

        public string ExtJurisdictionIdVr
        {
            set
            {
                ExtJurisdictionIdVrElement = new FhirString(value);
            }
            get
            {
                return ExtJurisdictionIdVrElement?.Value?.ToString();
            }
        }
    }
}

