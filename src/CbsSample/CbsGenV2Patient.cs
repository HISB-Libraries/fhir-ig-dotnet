using System;
using GaTech.Chai.UsCbs.PatientProfile;
using GaTech.Chai.UsCore.PatientProfile;
using GaTech.Chai.UsPublicHealth.PatientProfile;
using GaTech.Chai.FhirIg.Extensions;
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
            var patient = UsCbsPatient.Create();
            patient.UsPublicHealthPatient().AddProfile();
            patient.UsCorePatient().AddProfile();

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("1010-8", "Apache") };
            patient.UsCorePatient().Race.RaceText = "Apache";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            // patient.BirthDateElement = new Date(1965, 5, 2);
            patient.UsPublicHealthPatient().SetBrithDateDataAbsentReason();
            patient.UsCorePatient().BirthSex.Extension = new Code("F");
            patient.UsPublicHealthPatient().BirthPlace = new Address() { Country = "USA" };
            patient.Gender = AdministrativeGender.Female;

            // Address
            var address = new Address() { Use = Address.AddressUse.Home, State = "TX", PostalCode = "77018", Country = "USA" };
            address.Use = Address.AddressUse.Home;
            address.UsCbsAddress().CensusTract = "030500";
            patient.Address.Add(address);

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5309");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310"); // duplicate entry demo
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "mywork@gtri.org");

            // Deceased
            patient.Deceased = new FhirDateTime(2014, 3, 2);

            return patient;
        }
    }
}
