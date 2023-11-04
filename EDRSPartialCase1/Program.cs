using System;
using System.Collections.Generic;
using System.IO;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Mdi.BundleDocumentMdiAndEdrsProfile;
using GaTech.Chai.Mdi.CompositionMdiAndEdrsProfile;
using GaTech.Chai.UsCore.PatientProfile;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Reflection.Metadata;
using System.Text;

namespace MdiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });
            string outputPath = "/Users/mc142/Documents/workspace/MMG/cbs-ig-dotnet/MDIout/";

            // US Core PatientProfile
            Patient patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Adams", GivenElement = new List<FhirString> { new FhirString("Patch"), new FhirString("J") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "890123456"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2108-9", "European") };
            patient.UsCorePatient().Race.RaceText = "European";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("UNK", "unknown") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Hl7.Fhir.Model.Date(1960, 5, 10);
            patient.UsCorePatient().BirthSex.Extension = new Code("M");
            patient.Gender = AdministrativeGender.Male;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "123 Coda Street" },
                City = "Decatur",
                State = "GA",
                PostalCode = "08190",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310");


            ////
            // Composition of MDI to EDRS document
            Composition composition = CompositionMdiAndEdrs.Create(
                new Identifier() { Value = "115759f4-8d18-11ed-a1eb-0242ac120002" },
                CompositionStatus.Final,
                patient,
                null,
                null,
                null,
                null,
                Composition.CompositionAttestationMode.Official
                );
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Title = "MDI to EDRS Composition";

            composition.CompositionMdiAndEdrs().EdrsFileNumber = ("urn:raven:test", "EDRS-01");

            ////
            // Document Bundle
            Bundle mdiDocument = BundleDocumentMdiAndEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:9ba0a959-bce5-42ee-9710-2f1c54b37d09"),
                composition
                );
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            string output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "partialCase1.json", output);
            //Console.WriteLine(output);


            /// case 2
            // US Core PatientProfile
            patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Vader", GivenElement = new List<FhirString> { new FhirString("Darth"), new FhirString("J") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "567890123"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2054-5", "Black or African American");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2058-6", "African American") };
            patient.UsCorePatient().Race.RaceText = "African American";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2155-0", "Central American") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Hl7.Fhir.Model.Date(1977, 1, 20);
            patient.UsCorePatient().BirthSex.Extension = new Code("M");
            patient.Gender = AdministrativeGender.Male;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "567 Wall Street" },
                City = "Dallas",
                State = "TX",
                PostalCode = "12340",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "215-123-3456");


            ////
            // Composition of MDI to EDRS document
            composition = CompositionMdiAndEdrs.Create(
                new Identifier() { Value = "f84b848a-8d17-11ed-a1eb-0242ac120002" },
                CompositionStatus.Final,
                patient,
                null,
                null,
                null,
                null,
                Composition.CompositionAttestationMode.Official
                );
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Title = "MDI to EDRS Composition";

            composition.CompositionMdiAndEdrs().EdrsFileNumber = ("urn:raven:test", "EDRS-02");

            ////
            // Document Bundle
            mdiDocument = BundleDocumentMdiAndEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:1d804ed4-8d18-11ed-a1eb-0242ac120002"),
                composition
                );
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "partialCase2.json", output);
            //Console.WriteLine(output);


            // Case 3
            patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Kenobi", GivenElement = new List<FhirString> { new FhirString("Obiwan") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "304958907"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("1002-5", "American Indian or Alaska Native");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("1004-1", "American Indian") };
            patient.UsCorePatient().Race.RaceText = "American Indian";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("OTH", "other") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Hl7.Fhir.Model.Date(1957, 10, 15);
            patient.UsCorePatient().BirthSex.Extension = new Code("M");
            patient.Gender = AdministrativeGender.Male;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "1234 StarWars Street" },
                City = "Los Angeles",
                State = "CA",
                PostalCode = "09090",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "908-234-1212");


            ////
            // Composition of MDI to EDRS document
            composition = CompositionMdiAndEdrs.Create(
                new Identifier() { Value = "4146e91c-8d19-11ed-a1eb-0242ac120002" },
                CompositionStatus.Final,
                patient,
                null,
                null,
                null,
                null,
                Composition.CompositionAttestationMode.Official
                );
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Title = "MDI to EDRS Composition";

            composition.CompositionMdiAndEdrs().EdrsFileNumber = ("urn:raven:test", "EDRS-03");

            ////
            // Document Bundle
            mdiDocument = BundleDocumentMdiAndEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:464878f4-8d19-11ed-a1eb-0242ac120002"),
                composition
                );
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "partialCase3.json", output);

            // Case 4
            patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Organa", GivenElement = new List<FhirString> { new FhirString("Leia") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "102987654"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2108-9", "European") };
            patient.UsCorePatient().Race.RaceText = "European";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2178-2", "Latin American") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Hl7.Fhir.Model.Date(1977, 1, 20);
            patient.UsCorePatient().BirthSex.Extension = new Code("F");
            patient.Gender = AdministrativeGender.Female;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "3432 Earth Street" },
                City = "Alpharetta",
                State = "GA",
                PostalCode = "12321",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "223-123-9809");


            ////
            // Composition of MDI to EDRS document
            composition = CompositionMdiAndEdrs.Create(
                new Identifier() { Value = "fa54f5de-8d19-11ed-a1eb-0242ac120002" },
                CompositionStatus.Final,
                patient,
                null,
                null,
                null,
                null,
                Composition.CompositionAttestationMode.Official
                );
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Title = "MDI to EDRS Composition";

            composition.CompositionMdiAndEdrs().EdrsFileNumber = ("urn:raven:test", "EDRS-04");

            ////
            // Document Bundle
            mdiDocument = BundleDocumentMdiAndEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:fe8ddfa8-8d19-11ed-a1eb-0242ac120002"),
                composition
                );
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "partialCase4.json", output);

            ///
            // Case 5
            patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Master", GivenElement = new List<FhirString> { new FhirString("Yoda") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "890564732"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2131-1", "Other Race");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("UNK", "unknown") };
            patient.UsCorePatient().Race.RaceText = "Other Race";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("UNK", "unknown") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Hl7.Fhir.Model.Date(1940, 12, 20);
            patient.UsCorePatient().BirthSex.Extension = new Code("M");
            patient.Gender = AdministrativeGender.Male;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "4544 Training Street" },
                City = "Duluth",
                State = "GA",
                PostalCode = "90987",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "201-109-8905");


            ////
            // Composition of MDI to EDRS document
            composition = CompositionMdiAndEdrs.Create(
                new Identifier() { Value = "1acab910-8d1b-11ed-a1eb-0242ac120002" },
                CompositionStatus.Final,
                patient,
                null,
                null,
                null,
                null,
                Composition.CompositionAttestationMode.Official
                );
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Title = "MDI to EDRS Composition";

            composition.CompositionMdiAndEdrs().EdrsFileNumber = ("urn:raven:test", "EDRS-05");

            ////
            // Document Bundle
            mdiDocument = BundleDocumentMdiAndEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:2549d844-8d1b-11ed-a1eb-0242ac120002"),
                composition
                );
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "partialCase5.json", output);


            ///
            // Case Zapp
            patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Zapp", GivenElement = new List<FhirString> { new FhirString("Lasers"), new FhirString("J") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "102459876"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2108-9", "European") };
            patient.UsCorePatient().Race.RaceText = "European";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("UNK", "unknown") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Hl7.Fhir.Model.Date(1982, 1, 2);
            patient.UsCorePatient().BirthSex.Extension = new Code("M");
            patient.Gender = AdministrativeGender.Male;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "8005 Miller Street" },
                City = "Phoenixville",
                State = "PA",
                PostalCode = "19460",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "215-456-8900");


            ////
            // Composition of MDI to EDRS document
            composition = CompositionMdiAndEdrs.Create(
                new Identifier() { Value = "5d814bdc-9777-11ed-a8fc-0242ac120002" },
                CompositionStatus.Final,
                patient,
                null,
                null,
                null,
                null,
                Composition.CompositionAttestationMode.Official
                );
            composition.DateElement = new FhirDateTime("2021-01-15");
            composition.Title = "MDI to EDRS Composition";

            composition.CompositionMdiAndEdrs().EdrsFileNumber = ("urn:raven:test", "EDRS-06");

            ////
            // Document Bundle
            mdiDocument = BundleDocumentMdiAndEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:912549ac-9777-11ed-a8fc-0242ac120002"),
                composition
                );
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "partialCase-Zapp.json", output);


            ///
            // Case Winslow
            patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Winslow", GivenElement = new List<FhirString> { new FhirString("Annie") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "543980765"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2028-9", "Asian Indian");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2029-7", "Asian Indian") };
            patient.UsCorePatient().Race.RaceText = "Asian Indian";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("UNK", "unknown") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Hl7.Fhir.Model.Date(1978, 3, 12);
            patient.UsCorePatient().BirthSex.Extension = new Code("F");
            patient.Gender = AdministrativeGender.Female;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "112 Miramar Ct" },
                City = "Danville",
                State = "NC",
                PostalCode = "23454",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "687-123-0987");


            ////
            // Composition of MDI to EDRS document
            composition = CompositionMdiAndEdrs.Create(
                new Identifier() { Value = "855cff7e-9778-11ed-a8fc-0242ac120002" },
                CompositionStatus.Final,
                patient,
                null,
                null,
                null,
                null,
                Composition.CompositionAttestationMode.Official
                );
            composition.DateElement = new FhirDateTime("2021-06-15");
            composition.Title = "MDI to EDRS Composition";

            composition.CompositionMdiAndEdrs().EdrsFileNumber = ("urn:raven:test", "EDRS-07");

            ////
            // Document Bundle
            mdiDocument = BundleDocumentMdiAndEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:ad07a0e2-9778-11ed-a8fc-0242ac120002"),
                composition
                );
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "partialCase-Winslow.json", output);
        }
    }
}
