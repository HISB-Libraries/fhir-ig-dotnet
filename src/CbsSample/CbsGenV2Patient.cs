using System;
using GaTech.Chai.Cbs.CbsPatientProfile;
using Hl7.Fhir.Model;

namespace CbsProfileInitialization
{
    // https://cbsig.chai.gatech.edu/Patient-GenV2-TC-Patient.html
    public class CbsGenV2Patient
    {
        public CbsGenV2Patient()
        {
        }

        public static Patient Create()
        {
            // Patient Profile
            var patient = CbsPatient.Create();

            // Race
            patient.CbsPatient().Race.Category = CbsPatientRace.RaceCategory.Encode("2106-3", "White");
            patient.CbsPatient().Race.Description = "Mixed";
            patient.CbsPatient().Race.ExtendedRaceCodes = new Coding[] { CbsPatientRace.DetailedRace.Encode("1010-8", "Apache") };
            patient.CbsPatient().Race.Other = "Apache";

            // Ethnicity
            patient.CbsPatient().Ethnicity.Category = CbsPatientEthnicity.EthnicityCategory.Encode("2186-5", "Not Hispanic or Latino");
            patient.CbsPatient().Ethnicity.Description = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Date(1965, 5, 2);
            patient.CbsPatient().BirthSex = CbsPatient.Sex.Female;
            patient.CbsPatient().BirthPlace = new Address() { Country = "USA" };
            patient.Gender = AdministrativeGender.Female;

            // Address
            var address = new Address() { Use = Address.AddressUse.Home, State = "TX", PostalCode = "77018", Country = "USA" };
            address.CbsAddress().CdcAddressUse = CbsAddress.AddressUse.UsualResidence;
            address.CbsAddress().CensusTract = "030500";
            patient.Address.Add(address);

            // Contact
            patient.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "867-5309"));

            // Deceased
            patient.Deceased = new FhirDateTime(2014, 3, 2);

            return patient;
        }
    }
}
