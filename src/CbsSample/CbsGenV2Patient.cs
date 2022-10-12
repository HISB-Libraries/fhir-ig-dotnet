using System;
using GaTech.Chai.UsCbs.PatientProfile;
using GaTech.Chai.UsCore.PatientProfile;
using GaTech.Chai.UsPublicHealth.PatientProfile;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;
using System.Collections.Generic;

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

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.RaceText = "White";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            // patient.BirthDateElement = new Date(1965, 5, 2);
            patient.UsCorePatient().BirthSex.Extension = new Code("F");

            patient.UsPublicHealthPatient().SetBrithDateDataAbsentReason();
            patient.UsPublicHealthPatient().BirthPlace = new Address() { Country = "USA" };
            patient.UsPublicHealthPatient().GenderIdentity = UsPublicHealthPatient.GenderFemale;
            patient.UsPublicHealthPatient().TribalAffiliation.TribeName = UsPublicHealthTribalAffiliation.TribalEntityUS.Encode("91", "Fort Mojave Indian Tribe of Arizona, California");
            patient.UsPublicHealthPatient().TribalAffiliation.EnrolledTribeMember = new FhirBoolean(true);
            patient.BirthDate = "1974-11-24";

            patient.Gender = AdministrativeGender.Female;


            patient.Identifier.Add(new Identifier() { Use = Identifier.IdentifierUse.Usual, Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "MR", "Medical Record Number", "Medical Record Number"), System = "http://hospital.smarthealthit.org", Value = "1032702" });
            patient.Active = true;
            patient.Name.Add(new HumanName() { Family = "Everywoman", Given = new List<string> { "Eve", "L" } });

            // Address
            var address = new Address() { Use = Address.AddressUse.Home, Line = new List<string> { "5101 Peachtree St NE" }, City = "Atlanta", State = "GA", PostalCode = "30302", Country = "US" };
            address.UsCbsAddress().CensusTract = "030500";
            patient.Address.Add(address);

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "1-(404)555-1212");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "1-(404)555-1212");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "1-(404)555-1212"); // duplicate entry demo
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "mywork@gtri.org");

            return patient;
        }
    }
}
