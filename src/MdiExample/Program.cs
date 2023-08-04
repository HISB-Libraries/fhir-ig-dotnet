using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GaTech.Chai.Share.Extensions;
using GaTech.Chai.Mdi.BundleDocumentMdiToEdrsProfile;
using GaTech.Chai.Mdi.BundleMessageToxicologyToMdiProfile;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.Mdi.CompositionMditoEdrsProfile;
using GaTech.Chai.Mdi.DiagnosticReportToxicologyLabResultToMdiProfile;
using GaTech.Chai.Mdi.LocationDeathProfile;
using GaTech.Chai.Mdi.MessageHeaderToxicologyToMdiProfile;
using GaTech.Chai.Mdi.ObservationCauseOfDeathPart1Profile;
using GaTech.Chai.Mdi.ObservationConditionContributingToDeathProfile;
using GaTech.Chai.Mdi.ObservationContributingCauseOfDeathPart2Profile;
using GaTech.Chai.Mdi.ObservationDeathDateProfile;
using GaTech.Chai.Mdi.ObservationDecedentPregnancyProfile;
using GaTech.Chai.Mdi.ObservationHowDeathInjuryOccurredProfile;
using GaTech.Chai.Mdi.ObservationMannerOfDeathProfile;
using GaTech.Chai.Mdi.ObservationTobaccoUseContributedToDeathProfile;
using GaTech.Chai.Mdi.ObservationToxicologyLabResultProfile;
using GaTech.Chai.Mdi.SpecimenToxicologyLabProfile;
using GaTech.Chai.Odh.UsualWorkProfile;
using GaTech.Chai.UsCore.LocationProfile;
using GaTech.Chai.UsCore.OrganizationProfile;
using GaTech.Chai.UsCore.PatientProfile;
using GaTech.Chai.UsCore.PractitionerProfile;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using GaTech.Chai.Mdi.ProceDureDeathCertificationProfile;
using GaTech.Chai.Mdi.ProcedureDeathCertificationProfile;
using GaTech.Chai.Share.Common;
using Newtonsoft.Json.Linq;
using GaTech.Chai.Mdi.ObservationAutopsyPerformedIndicatorProfile;
using GaTech.Chai.Mdi.LocationInjuryProfile;

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
            patient.Id = "806c53c0-a993-11ed-afa1-0242ac120002";

            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Freeman", GivenElement = new List<FhirString> { new FhirString("Alice"), new FhirString("J") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", null),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "123456790"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2028-9", "Asian");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2029-7", "Asian Indian") };
            patient.UsCorePatient().Race.RaceText = "Asian Indian";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2162-6", "Central American Indian") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Date(1978, 3, 12);
            patient.UsCorePatient().BirthSex.Extension = new Code("F");
            patient.Gender = AdministrativeGender.Female;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "5100 Peachtree Street", "Bldg4-12" },
                City = "Atlanta",
                State = "GA",
                PostalCode = "09090",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "404-123-0022");
            //patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310");
            //patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310"); // duplicate entry demo
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "raven@mdi.org");

            // Deceased
            patient.Deceased = new FhirDateTime(2014, 3, 2);

            // Us Core Practitioner (ME)
            Practitioner practitioner = UsCorePractitioner.Create();
            practitioner.Id = "ac069540-a993-11ed-afa1-0242ac120002";

            practitioner.Name = new List<HumanName> { new HumanName() { Use = HumanName.NameUse.Official, Family = "Jones", GivenElement = new List<FhirString> { new FhirString("Sam") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } } };
            practitioner.UsCorePractitioner().NPI = "3333445555";
            practitioner.Telecom = new List<ContactPoint> { new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Work, "134-456-7890") };
            practitioner.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Work,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "567 Coda Blvd" },
                City = "Atlanta",
                District = "Fulton County",
                State = "GA",
                PostalCode = "30318",
                Country = "USA" }
            };

            // Cause of Death Condition Observation
            Observation causeOfDeath1 = ObservationCauseOfDeathPart1.Create(patient, practitioner, "Fentanyl toxicity", 1, "minutes to hours");
            causeOfDeath1.Id = "b90b4a24-a993-11ed-afa1-0242ac120002";
            causeOfDeath1.Status = ObservationStatus.Final;

            Observation causeOfDeath2 = ObservationCauseOfDeathPart1.Create(patient, practitioner, "Liver failure", 2, "1 hour");
            causeOfDeath2.Id = "c77a5528-a993-11ed-afa1-0242ac120002";
            causeOfDeath2.Status = ObservationStatus.Final;

            // Condition Contributing to Death
            Observation conditionContributingToDeath = ObservationContributingCauseOfDeathPart2.Create(patient, practitioner);
            conditionContributingToDeath.Id = "d4429ad6-a993-11ed-afa1-0242ac120002";
            conditionContributingToDeath.Status = ObservationStatus.Final;
            conditionContributingToDeath.ObservationContributingCauseOfDeathPart2().Value = new CodeableConcept(null, null, "Hypertensive heart disease");

            // Observation Manner of Death
            Observation observationMannerOfDeath = ObservationMannerOfDeath.Create(patient, practitioner);
            observationMannerOfDeath.Id = "e7f0fd84-a993-11ed-afa1-0242ac120002";
            observationMannerOfDeath.Value = MdiVsMannerOfDeath.AccidentalDeath;

            // Observation Death How Death Injury Occurred
            Observation observationHowDeathInjuryOccurred = ObservationHowDeathInjuryOccurred.Create(patient);
            observationHowDeathInjuryOccurred.Id = "f4185864-a993-11ed-afa1-0242ac120002";
            observationHowDeathInjuryOccurred.Status = ObservationStatus.Final;
            observationHowDeathInjuryOccurred.ObservationHowDeathInjuryOccurred().Certifier = practitioner;
            observationHowDeathInjuryOccurred.ObservationHowDeathInjuryOccurred().HowInjuredDescription = "Ingested counterfeit medication";
            observationHowDeathInjuryOccurred.ObservationHowDeathInjuryOccurred().PartialDateTime = (
                new UnsignedInt(2022),
                new UnsignedInt(2),
                new UnsignedInt(1),
                new Time("15:34:20"));
            observationHowDeathInjuryOccurred.ObservationHowDeathInjuryOccurred().PlaceOfInjury = new CodeableConcept { Text = "Private House" };

            // Location Death
            Location deathLocation = LocationDeath.Create();
            deathLocation.Id = "00c78cce-a994-11ed-afa1-0242ac120002";
            deathLocation.Identifier.Add(new Identifier("http://www.acme.org/location", "29"));
            deathLocation.Status = Location.LocationStatus.Active;
            deathLocation.Name = "Atlanta GA Death Location - Freeman";
            deathLocation.Address = new Address() { Use = Address.AddressUse.Home, Type = Address.AddressType.Physical, Line = new List<string>{
                    "400 Windstream Street" }, City = "Atlanta", District = "Fulton County", State = "GA", Country = "USA" };

            // Location Injury
            Location injuryLocation = LocationInjury.Create();
            injuryLocation.Id = "0affba40-a994-11ed-afa1-0242ac120002";
            injuryLocation.Name = "Atlanta GA Injury Location";
            injuryLocation.Address = new Address() {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "400 Windstream Street" },
                City = "Atlanta",
                District = "Fulton County",
                State = "GA", PostalCode = "30318", Country = "USA" };

            // Observation Death Date
            Observation observationDeathDate = ObservationDeathDate.Create(patient);
            observationDeathDate.Id = "19026d5e-a994-11ed-afa1-0242ac120002";
            observationDeathDate.Status = ObservationStatus.Final;
            observationDeathDate.Effective = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.Value = new FhirDateTime("2022-01-08T14:04:00-05:00");
            observationDeathDate.ObservationDeathDate().DateTimePronouncedDead = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.ObservationDeathDate().PlaceOfDeath = MdiVsPlaceOfDeath.DeadOnArrivalAtHospital;
            observationDeathDate.Method = MdiCodeSystem.MdiCodes.Exact;

            // Death Certification
            Procedure procedureDeathCertification = ProcedureDeathCertification.Create(patient);
            procedureDeathCertification.Id = "23145afa-a994-11ed-afa1-0242ac120002";
            procedureDeathCertification.ProcedureDeathCertification().Certifier = (MdiVsCertifierTypes.MedicalExaminerCornerExamination, practitioner);
            procedureDeathCertification.Status = EventStatus.Completed;
            procedureDeathCertification.Performed = new FhirDateTime("2022-01-08T15:30:00-05:00");

            // Observation Decedent Pregnancy
            Observation observationDecedentPregnancy = ObservationDecedentPregnancy.Create(patient);
            observationDecedentPregnancy.Id = "2ce05796-a994-11ed-afa1-0242ac120002";
            observationDecedentPregnancy.Value = MdiCodeSystem.DeathPregnancyStatus.NA;

            // Observation Tobacco Use Contributed To Death
            Observation observationTobaccoUseContributedToDeath = ObservationTobaccoUseContributedToDeath.Create(patient);
            observationTobaccoUseContributedToDeath.Id = "38bcabfa-a994-11ed-afa1-0242ac120002";
            observationTobaccoUseContributedToDeath.Value = MdiVsContributoryTobaccoUse.No;

            // Observation - Autopsy Performed Indicator
            Observation observationAutopsyPerformedIndicator = ObservationAutopsyPerformedIndicator.Create(patient);
            observationAutopsyPerformedIndicator.Id = "410ff8b6-a994-11ed-afa1-0242ac120002";
            observationAutopsyPerformedIndicator.Status = ObservationStatus.Final;
            observationAutopsyPerformedIndicator.ObservationAutopsyPerformedIndicator().Value = MdiVsYesNoUnknown.Yes;
            observationAutopsyPerformedIndicator.ObservationAutopsyPerformedIndicator().AutopsyResultAvailable
                = MdiVsYesNoUnknownNotApplicable.NA;
            
            ////
            // Composition of MDI to EDRS document
            Composition composition = CompositionMdiToEdrs.Create(
                new Identifier() { Value = "a03eab8c-11e8-4d0c-ad2a-b385395e27de" },
                CompositionStatus.Final,
                patient,
                practitioner,
                practitioner,
                Composition.CompositionAttestationMode.Official
                );
            composition.Id = "d5eb30e7-f656-424c-8902-ba5c95797872";
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Title = "MDI to EDRS Composition";

            // Demo: Tracking numbers - one with library. the other for custom type
            composition.CompositionMdiToEdrs().MdiCaseNumber = ("urn:connectathon_jan22:test", "ME21-113");
            composition.CompositionMdiToEdrs().AdditionalDemographics = new Narrative {
                Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">\n  <p>No additional demographic information</p>\n  </div>",
                Status = Narrative.NarrativeStatus.Additional };
            composition.CompositionMdiToEdrs().Circumstances = (new List<Resource> { deathLocation, observationTobaccoUseContributedToDeath, observationDecedentPregnancy, injuryLocation }, null, null);
            composition.CompositionMdiToEdrs().Jurisdiction = (new List<Resource> { observationDeathDate, procedureDeathCertification }, null, null);
            composition.CompositionMdiToEdrs().CauseManner = (
                new List<Resource> { causeOfDeath1, causeOfDeath2 },
                new List<Resource> { conditionContributingToDeath },
                new List<Resource> { observationMannerOfDeath },
                new List<Resource> { observationHowDeathInjuryOccurred },
                null /* empty reason code */);

            // Medical History is not available. We have to have one of entry, text, or subsection.
            // Since we have no entry and no subsection, must include text.
            composition.CompositionMdiToEdrs().MedicalHistory = (
                null,
                new Narrative { Div="Medical History is not available", Status=Narrative.NarrativeStatus.Generated },
                ListEmptyReason.Unavailable);

            // exam and autopsy information
            composition.CompositionMdiToEdrs().ExamAutopsy = (new List<Resource> { observationAutopsyPerformedIndicator }, null, null);

            ////
            // Document Bundle
            Bundle mdiDocument = BundleDocumentMdiToEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:933dde44f7664b03a20b6324f23986c0"),
                composition
                );
            mdiDocument.Id = "5ac0a4e0-a994-11ed-afa1-0242ac120002";
            mdiDocument.TimestampElement = Instant.Now();

            string output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "MDItoEDRS_Alice_Freeman_Document.json", output);
            //Console.WriteLine(output);

            /////////////////////////// Reference MDI-EDRS document /////////////////////////
            mdiDocument.Id = "6951910e-a994-11ed-afa1-0242ac120002";
            mdiDocument.TypeElement.AddExtension("http://config.raven.app/code", new Code("reference"));
            output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "MDItoEDRS_Alice_Freeman_Reference_Document.json", output);

            /////////////////////////// Toxicology Lab Report ///////////////////////////////
            // Specimen for Toxicology
            // - Fentanyl OD

            // Us Core Practitioner (Tox Lab)
            Practitioner practitionerToxLab = UsCorePractitioner.Create();
            practitionerToxLab.Id = "77b2cf2e-a994-11ed-afa1-0242ac120002";
            practitionerToxLab.Name = new List<HumanName> { new HumanName() { Use = HumanName.NameUse.Official, Family = "Goldberger", GivenElement = new List<FhirString> { new FhirString("Bruce") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } } };
            practitionerToxLab.UsCorePractitioner().NPI = "555667777";

            // Us Core Lab Organization
            Organization organizationLab = UsCoreOrganization.Create();
            organizationLab.Id = "8169de5e-a994-11ed-afa1-0242ac120002";
            organizationLab.Identifier.AddOrUpdateIdentifier(UsCoreOrganization.NPISystem, "111223333");
            organizationLab.Active = true;
            organizationLab.Type.Add(new CodeableConcept("http://terminology.hl7.org/CodeSystem/organization-type", "prov", "Healthcare Provider", null));
            organizationLab.Name = "UF Health Pathology Labs, Forensic Toxicology Laboratory";
            organizationLab.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Work, "(352) 265-9900");
            organizationLab.Address.Add(new Address() { Line = new List<String> { "4800 SW 35th Drive" }, City = "Gainesville", State = "FL", PostalCode = "32608", Country = "USA" });

            Specimen specimenBlood = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood.Id = "8d129084-a994-11ed-afa1-0242ac120002";
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Specimen specimenUrine = SpecimenToxicologyLab.Create("Urine", patient);
            specimenUrine.Id = "9a57db82-a994-11ed-afa1-0242ac120002";
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "5mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            Specimen specimenBile = SpecimenToxicologyLab.Create("Bile", patient);
            specimenBile.Id = "a451c2ce-a994-11ed-afa1-0242ac120002";
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenVitreousHumor = SpecimenToxicologyLab.Create("Vitreous Humor", patient);
            specimenVitreousHumor.Id = "aeaa342c-a994-11ed-afa1-0242ac120002";
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "3mL GT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenStomachContents = SpecimenToxicologyLab.Create("Stomach Contents", patient);
            specimenStomachContents.Id = "b9d7f690-a994-11ed-afa1-0242ac120002";
            specimenStomachContents.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "MM352356");
            specimenStomachContents.Status = Specimen.SpecimenStatus.Available;
            specimenStomachContents.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenStomachContents.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenStomachContents.Container.Add(new Specimen.ContainerComponent() { Description = "60mL Cup", SpecimenQuantity = new Quantity() { Value = 60, Unit = "ml" } });

            Specimen specimenLiver = SpecimenToxicologyLab.Create("Liver", patient);
            specimenLiver.Id = "c1f87dd6-a994-11ed-afa1-0242ac120002";
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5g Cup", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            // Toxicology Lab Results to MDI
            Observation toxLabResultEthanolBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolBlood.Id = "d22ed77c-a994-11ed-afa1-0242ac120002";
            toxLabResultEthanolBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().ValueText = "0.145 g/dL";
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResult4anppBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "4-ANPP", patient);
            toxLabResult4anppBlood.Id = "dd010ab2-a994-11ed-afa1-0242ac120002";
            toxLabResult4anppBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResult4anppBlood.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResult4anppBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultAcetylfentanylBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetylfentanyl", patient);
            toxLabResultAcetylfentanylBlood.Id = "f034d488-a994-11ed-afa1-0242ac120002";
            toxLabResultAcetylfentanylBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetylfentanylBlood.ObservationToxicologyLabResult().ValueText = "<2.5 ng/mL";
            toxLabResultAcetylfentanylBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultFentanylBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Fentanyl", patient);
            toxLabResultFentanylBlood.Id = "f9c5ac48-a994-11ed-afa1-0242ac120002";
            toxLabResultFentanylBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultFentanylBlood.ObservationToxicologyLabResult().ValueText = "23 ng/mL";
            toxLabResultFentanylBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolUrine.Id = "033f1c14-a995-11ed-afa1-0242ac120002";
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().ValueText = "0.160 g/dL";
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResult4anppUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "4-ANPP", patient);
            toxLabResult4anppUrine.Id = "0c4b6eac-a995-11ed-afa1-0242ac120002";
            toxLabResult4anppUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResult4anppUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResult4anppUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultAcetylfentanylUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetylfentanyl", patient);
            toxLabResultAcetylfentanylUrine.Id = "183490e0-a995-11ed-afa1-0242ac120002";
            toxLabResultAcetylfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetylfentanylUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultAcetylfentanylUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultFentanylUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Fentanyl", patient);
            toxLabResultFentanylUrine.Id = "24d39a08-a995-11ed-afa1-0242ac120002";
            toxLabResultFentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultFentanylUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultFentanylUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultNorfentanylUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Norfentanyl", patient);
            toxLabResultNorfentanylUrine.Id = "2e3842ba-a995-11ed-afa1-0242ac120002";
            toxLabResultNorfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNorfentanylUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultNorfentanylUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultXylazineUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Xylazine", patient);
            toxLabResultXylazineUrine.Id = "788e7c02-a996-11ed-afa1-0242ac120002";
            toxLabResultXylazineUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultXylazineUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultXylazineUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultNotTestedBile = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedBile.Id = "81c53a36-a996-11ed-afa1-0242ac120002";
            toxLabResultNotTestedBile.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().Specimen = specimenBile;

            Observation toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolVitreousHumor.Id = "8cf44618-a996-11ed-afa1-0242ac120002";
            toxLabResultEthanolVitreousHumor.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().ValueText = "0.133 g/dL";
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().Specimen = specimenVitreousHumor;

            Observation toxLabResultNotTestedStomachContents = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedStomachContents.Id = "1a8b1a80-a9a4-11ed-afa1-0242ac120002";
            toxLabResultNotTestedStomachContents.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().Specimen = specimenStomachContents;

            Observation toxLabResultNotTestedLiver = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedLiver.Id = "2d20c6a4-a9a4-11ed-afa1-0242ac120002";
            toxLabResultNotTestedLiver.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().Specimen = specimenLiver;

            // Us Core Diagnostic Report for Tox Lab Results
            DiagnosticReport diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);
            diagnosticReport.Id = "3739a714-a9a4-11ed-afa1-0242ac120002";
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().ToxLabCaseNumber = ("http://uf-path-labs.org/fhir/lab-cases", "R21-01580");
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().MdiCaseNumber = ("urn:connectathon_jan22:test", "ME21-113");

            diagnosticReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            diagnosticReport.Code = new CodeableConcept { Text = "Forensic Toxicology Lab Report" };
            diagnosticReport.Effective = new FhirDateTime("2022-01-08T16:00:00Z");
            diagnosticReport.IssuedElement = new Instant() { Value = new FhirDateTime("2022-01-10T00:00:00Z").ToDateTimeOffset(new TimeSpan()) };

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddPerformer(practitionerToxLab);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenVitreousHumor);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBile);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenLiver);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenStomachContents);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResult4anppBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultAcetylfentanylBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultFentanylBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResult4anppUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultAcetylfentanylUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultFentanylUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNorfentanylUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultXylazineUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedBile);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolVitreousHumor);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedStomachContents);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedLiver);

            diagnosticReport.Text = new Narrative {
                Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">\n  <p>It may be appropriate to include interpretive information to help the reader understand the meaning of detected analytes. Interpretive information is not considered a mandatory part of the toxicological report, but is based on jurisdictional or laboratory preference to include such. This information may be included in the body of the report.</p>\n  </div>",
                Status = Narrative.NarrativeStatus.Additional
            };

            MessageHeader messageHeader = MessageHeaderToxicologyToMdi.Create("http://uf.org/access/endpoint/1", diagnosticReport);
            messageHeader.Id = "45f3d4a0-a9a4-11ed-afa1-0242ac120002";
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MDI.net";
            messageHeader.Source.Version = "1.0.0";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            Bundle bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9"), messageHeader);
            bundleMessageToxToMDI.Id = "51a32198-a9a4-11ed-afa1-0242ac120002";
            bundleMessageToxToMDI.AsReference(); // set ID
            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "Tox_Fentanyl_OD.json", output);
            //Console.WriteLine(output);


            /////////////////////////////////
            ///
            // - Oxycodone & Alprazolam OD

            // US Core PatientProfile for Decedent
            patient = UsCorePatient.Create();
            patient.Id = "604702aa-a9a4-11ed-afa1-0242ac120002";

            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Rogers", GivenElement = new List<FhirString> { new FhirString("Jasmine"), new FhirString("M") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", null),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "789012345"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2108-9", "European") };
            patient.UsCorePatient().Race.RaceText = "White European";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2180-8", "Puerto Rican") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Puerto Rican";

            // Birth Related
            patient.BirthDateElement = new Date(1966, 6, 15);
            patient.UsCorePatient().BirthSex.Extension = new Code("F");
            patient.Gender = AdministrativeGender.Female;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "901 Piedmont Street", "Suite 200" },
                City = "Midwell",
                State = "GA",
                PostalCode = "22090",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "678-121-9989");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "bluejay@mdi-case.org");

            specimenBlood = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood.Id = "71427f58-a9a4-11ed-afa1-0242ac120002";
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            specimenUrine = SpecimenToxicologyLab.Create("Urine", patient);
            specimenUrine.Id = "7cbec45e-a9a4-11ed-afa1-0242ac120002";
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "5mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            specimenBile = SpecimenToxicologyLab.Create("Bile", patient);
            specimenBile.Id = "8600ac6c-a9a4-11ed-afa1-0242ac120002";
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenVitreousHumor = SpecimenToxicologyLab.Create("Vitreous Humor", patient);
            specimenVitreousHumor.Id = "8fc58222-a9a4-11ed-afa1-0242ac120002";
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "3mL GT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenStomachContents = SpecimenToxicologyLab.Create("Stomach Contents", patient);
            specimenStomachContents.Id = "b042a250-a9a4-11ed-afa1-0242ac120002";
            specimenStomachContents.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "MM352356");
            specimenStomachContents.Status = Specimen.SpecimenStatus.Available;
            specimenStomachContents.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenStomachContents.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenStomachContents.Container.Add(new Specimen.ContainerComponent() { Description = "60mL Cup", SpecimenQuantity = new Quantity() { Value = 60, Unit = "ml" } });

            specimenLiver = SpecimenToxicologyLab.Create("Liver", patient);
            specimenLiver.Id = "c704d4ea-a9a4-11ed-afa1-0242ac120002";
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5g Cup", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            // Toxicology Lab Results to MDI
            toxLabResultEthanolBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolBlood.Id = "d41c2160-a9a4-11ed-afa1-0242ac120002";
            toxLabResultEthanolBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().ValueText = "0.145 g/dL";
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultAcetaminophenBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetaminophen", patient);
            toxLabResultAcetaminophenBlood.Id = "24780f08-a9ae-11ed-afa1-0242ac120002";
            toxLabResultAcetaminophenBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetaminophenBlood.ObservationToxicologyLabResult().ValueText = "54 mg/L";
            toxLabResultAcetaminophenBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultAlprazolamBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Alprazolam", patient);
            toxLabResultAlprazolamBlood.Id = "58de5e82-a9ae-11ed-afa1-0242ac120002";
            toxLabResultAlprazolamBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAlprazolamBlood.ObservationToxicologyLabResult().ValueText = "95 ng/mL";
            toxLabResultAlprazolamBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultOxycodoneBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Oxycodone", patient);
            toxLabResultOxycodoneBlood.Id = "6540b7f6-a9ae-11ed-afa1-0242ac120002";
            toxLabResultOxycodoneBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultOxycodoneBlood.ObservationToxicologyLabResult().ValueText = "335 ng/mL";
            toxLabResultOxycodoneBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolUrine.Id = "7af2c8aa-a9ae-11ed-afa1-0242ac120002";
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().ValueText = "0.160 g/dL";
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultAcetaminophenUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetaminophen", patient);
            toxLabResultAcetaminophenUrine.Id = "83a6fdd6-a9ae-11ed-afa1-0242ac120002";
            toxLabResultAcetaminophenUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetaminophenUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultAcetaminophenUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabAlphaHydroxyalprazolamUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Alpha-hydroxyalprazolam", patient);
            toxLabAlphaHydroxyalprazolamUrine.Id = "8f49cd94-a9ae-11ed-afa1-0242ac120002";
            toxLabAlphaHydroxyalprazolamUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabAlphaHydroxyalprazolamUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabAlphaHydroxyalprazolamUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultCannabinoidsUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Cannabinoids", patient);
            toxLabResultCannabinoidsUrine.Id = "9c13b4ae-a9ae-11ed-afa1-0242ac120002";
            toxLabResultCannabinoidsUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultCannabinoidsUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultCannabinoidsUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultOxycoconeUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Oxycocone", patient);
            toxLabResultOxycoconeUrine.Id = "ac22b02a-a9ae-11ed-afa1-0242ac120002";
            toxLabResultOxycoconeUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultOxycoconeUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultOxycoconeUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            toxLabResultNotTestedBile = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedBile.Id = "b538b696-a9ae-11ed-afa1-0242ac120002";
            toxLabResultNotTestedBile.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().Specimen = specimenBile;

            toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolVitreousHumor.Id = "bf2ffa2e-a9ae-11ed-afa1-0242ac120002";
            toxLabResultEthanolVitreousHumor.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().ValueText = "0.133 g/dL";
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().Specimen = specimenVitreousHumor;

            toxLabResultNotTestedStomachContents = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedStomachContents.Id = "d25e01cc-a9ae-11ed-afa1-0242ac120002";
            toxLabResultNotTestedStomachContents.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().Specimen = specimenStomachContents;

            toxLabResultNotTestedLiver = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedLiver.Id = "db942b36-a9ae-11ed-afa1-0242ac120002";
            toxLabResultNotTestedLiver.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().Specimen = specimenLiver;

            // Us Core Diagnostic Report for Tox Lab Results
            diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);
            diagnosticReport.Id = "feb7b150-a9ae-11ed-afa1-0242ac120002";

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().ToxLabCaseNumber = ("http://uf-path-labs.org/fhir/lab-cases", "R21-01579");
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().MdiCaseNumber = ("urn:connectathon_jan22:test", "ME21-112");

            diagnosticReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            diagnosticReport.Code = new CodeableConcept { Text = "Forensic Toxicology Lab Report" };
            diagnosticReport.Effective = new FhirDateTime("2022-01-04T16:00:00Z");
            diagnosticReport.IssuedElement = new Instant() { Value = new FhirDateTime("2022-01-05T00:00:00Z").ToDateTimeOffset(new TimeSpan()) };

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddPerformer(practitionerToxLab);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenVitreousHumor);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBile);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenLiver);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenStomachContents);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultAcetaminophenBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultAlprazolamBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultOxycodoneBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultAcetaminophenUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabAlphaHydroxyalprazolamUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultCannabinoidsUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultOxycoconeUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedBile);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolVitreousHumor);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedStomachContents);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedLiver);

            diagnosticReport.Text = new Narrative
            {
                Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">\n  <p><h1 style=\"text-align: center;\">Raven Toxicology Report Example</h1> <p style=\"text-align: center;\"> <strong>75 E Peachtree Rd<br/>Atlanta, GA 30382<br/>Tel: 404-123-4567</strong> </p> <p> <table width=\"100%\"> <tr style=\"vertical-align: top;\"> <th width=\"100%\"><h2>Case Identification</h2></th> </tr> <tr> <td> <table style=\"padding: 1em;\"> <tr><td>Toxicolgy Number:</td><td>R21-01579</td></tr> <tr><td>Name:</td><td>Jasmine M Rogers</td></tr> <tr><td>Report Date:</td><td>2022-01-05T00:00:00Z</td></tr> </table> </td> </tr> <tr style=\"vertical-align: top;\"> <th width=\"100%\"><h2>Specimen(s) Received</h2></th> </tr> <tr> <td> <table style=\"padding: 1em;\"> <tr><td>Id</td><td>Type</td><td>Site</td><td>Date Collected</td></tr> <tr style=\"vertical-align: top;\"><td>X352356</td><td>Blood</td><td>Femoral vein structure (body structure)</td><td>2021-12-03T11:00:00Z</td></tr> <tr style=\"vertical-align: top;\"><td>ZZZ352356</td><td>Urine</td><td/><td>2021-12-03T11:00:00Z</td></tr> <tr style=\"vertical-align: top;\"><td>XXX352356</td><td>Vitreous Humor</td><td/><td>2021-12-03T11:00:00Z</td></tr> <tr style=\"vertical-align: top;\"><td>OO352356</td><td>Bile</td><td/><td>2021-12-03T11:00:00Z</td></tr> <tr style=\"vertical-align: top;\"><td>DD352356</td><td>Liver</td><td/><td>2021-12-03T11:00:00Z</td></tr> <tr style=\"vertical-align: top;\"><td>MM352356</td><td>Stomach Contents</td><td/><td>2021-12-03T11:00:00Z</td></tr> </table> </td> </tr> <tr> <th><h2>Results</h2></th> </tr> <tr> <td> <table style=\"padding: 1em; width: 100%;\"> <tr><th>Sample</th><th>Compound</th><th>Value</th></tr> <tr><td>Blood</td><td>Ethanol</td><td>0.145 g/dL</td></tr> <tr><td>Blood</td><td>Acetaminophen</td><td>54 mg/L</td></tr> <tr><td>Blood</td><td>Alprazolam</td><td>95 ng/mL</td></tr> <tr><td>Blood</td><td>Oxycodone</td><td>335 ng/mL</td></tr> <tr><td>Urine</td><td>Ethanol</td><td>0.160 g/dL</td></tr> <tr><td>Urine</td><td>Acetaminophen</td><td>Detected</td></tr> <tr><td>Urine</td><td>Alpha-hydroxyalprazolam</td><td>Detected</td></tr> <tr><td>Urine</td><td>Cannabinoids</td><td>Detected</td></tr> <tr><td>Urine</td><td>Oxycocone</td><td>Detected</td></tr> <tr><td>Bile</td><td>Not Tested</td><td/></tr> <tr><td>Vitreous Humor</td><td>Ethanol</td><td>0.133 g/dL</td></tr> <tr><td>Stomach Contents</td><td>Not Tested</td><td/></tr> <tr><td>Liver</td><td>Not Tested</td><td/></tr> </table> </td> </tr> <tr> <th><h2>Conclusion</h2></th> </tr> <tr> <td> <h3>Signed By: Dr. Bruce Goldberger</h3> </td> </tr> <tr> <td> Signed By: Dr. Bruce Goldberger </td> </tr> </table> </p></p>\n  </div>",
                Status = Narrative.NarrativeStatus.Additional
            };

            messageHeader = MessageHeaderToxicologyToMdi.Create("http://uf.org/access/endpoint/1", diagnosticReport);
            messageHeader.Id = "20e209e2-a9af-11ed-afa1-0242ac120002";
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MDI.net";
            messageHeader.Source.Version = "1.0.0";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9"), messageHeader);
            bundleMessageToxToMDI.Id = "2b641aea-a9af-11ed-afa1-0242ac120002"; // set ID
            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "Tox_Oxycodone_Alprazolam_OD.json", output);
            //Console.WriteLine(output);


            /////////////////////////////////
            ///
            // - MVA with Alcohol

            // US Core PatientProfile for Decedent
            patient = UsCorePatient.Create();
            patient.Id = "41ea4c26-a9af-11ed-afa1-0242ac120002";

            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Ramirez", GivenElement = new List<FhirString> { new FhirString("Joseph"), new FhirString("S") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", null),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "456789012"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2054-5", "Black or African American");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2058-6", "African American") };
            patient.UsCorePatient().Race.RaceText = "White, Black";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2182-4", "Cuban") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Cuban";

            // Birth Related
            patient.BirthDateElement = new Date(1964, 2, 24);
            patient.UsCorePatient().BirthSex.Extension = new Code("M");
            patient.Gender = AdministrativeGender.Male;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "45 Coda Street" },
                City = "Peachcity",
                State = "GA",
                PostalCode = "12098",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "770-541-9012");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "ravejay@mdi-case.org");

            specimenBlood = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood.Id = "51534cbc-a9af-11ed-afa1-0242ac120002";
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            specimenUrine = SpecimenToxicologyLab.Create("Urine", patient);
            specimenUrine.Id = "5f043ea2-a9af-11ed-afa1-0242ac120002";
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "5mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            specimenBile = SpecimenToxicologyLab.Create("Bile", patient);
            specimenBile.Id = "75c1010c-a9af-11ed-afa1-0242ac120002";
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenVitreousHumor = SpecimenToxicologyLab.Create("Vitreous Humor", patient);
            specimenVitreousHumor.Id = "7e80dc9a-a9af-11ed-afa1-0242ac120002";
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "3mL GT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenStomachContents = SpecimenToxicologyLab.Create("Stomach Contents", patient);
            specimenStomachContents.Id = "933e6b84-a9af-11ed-afa1-0242ac120002";
            specimenStomachContents.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "MM352356");
            specimenStomachContents.Status = Specimen.SpecimenStatus.Available;
            specimenStomachContents.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenStomachContents.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenStomachContents.Container.Add(new Specimen.ContainerComponent() { Description = "60mL Cup", SpecimenQuantity = new Quantity() { Value = 60, Unit = "ml" } });

            specimenLiver = SpecimenToxicologyLab.Create("Liver", patient);
            specimenLiver.Id = "a05dfcbc-a9af-11ed-afa1-0242ac120002";
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5g Cup", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            // Toxicology Lab Results to MDI
            toxLabResultEthanolBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolBlood.Id = "ababe3fe-a9af-11ed-afa1-0242ac120002";
            toxLabResultEthanolBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().ValueText = "0.145 g/dL";
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolUrine.Id = "b453fc9e-a9af-11ed-afa1-0242ac120002";
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().ValueText = "0.160 g/dL";
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            toxLabResultNotTestedBile = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedBile.Id = "bd479a86-a9af-11ed-afa1-0242ac120002";
            toxLabResultNotTestedBile.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().Specimen = specimenBile;

            toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolVitreousHumor.Id = "c6a26836-a9af-11ed-afa1-0242ac120002";
            toxLabResultEthanolVitreousHumor.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().ValueText = "0.133 g/dL";
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().Specimen = specimenVitreousHumor;

            toxLabResultNotTestedStomachContents = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedStomachContents.Id = "1e06e87c-a9b0-11ed-afa1-0242ac120002";
            toxLabResultNotTestedStomachContents.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().Specimen = specimenStomachContents;

            toxLabResultNotTestedLiver = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedLiver.Id = "84281fa2-a9c1-11ed-afa1-0242ac120002";
            toxLabResultNotTestedLiver.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().Specimen = specimenLiver;

            // Us Core Diagnostic Report for Tox Lab Results
            diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);
            diagnosticReport.Id = "902c9940-a9c1-11ed-afa1-0242ac120002";
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().ToxLabCaseNumber = ("http://uf-path-labs.org/fhir/lab-cases", "R21-01578");
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().MdiCaseNumber = ("urn:connectathon_jan22:test", "ME21-111");

            diagnosticReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            diagnosticReport.Code = new CodeableConcept { Text = "Forensic Toxicology Lab Report" };
            diagnosticReport.Effective = new FhirDateTime("2022-01-01T16:00:00Z");
            diagnosticReport.IssuedElement = new Instant() { Value = new FhirDateTime("2022-01-05T00:00:00Z").ToDateTimeOffset(new TimeSpan()) };

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddPerformer(practitionerToxLab);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenVitreousHumor);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBile);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenLiver);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenStomachContents);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedBile);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolVitreousHumor);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedStomachContents);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultNotTestedLiver);

            diagnosticReport.Text = new Narrative
            {
                Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">\n  <p>It may be appropriate to include interpretive information to help the reader understand the meaning of detected analytes. Interpretive information is not considered a mandatory part of the toxicological report, but is based on jurisdictional or laboratory preference to include such. This information may be included in the body of the report.</p>\n  </div>",
                Status = Narrative.NarrativeStatus.Additional
            };

            messageHeader = MessageHeaderToxicologyToMdi.Create("http://uf.org/access/endpoint/1", diagnosticReport);
            messageHeader.Id = "9ed5595a-a9c1-11ed-afa1-0242ac120002";
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MDI.net";
            messageHeader.Source.Version = "1.0.0";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9"), messageHeader);
            bundleMessageToxToMDI.Id = "ab89997c-a9c1-11ed-afa1-0242ac120002"; // set ID
            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "Tox_MVA_with_Alcohol.json", output);
            //Console.WriteLine(output);

            /////////////////////////////////
            ///
            // - UAB Example - accident (2018-1811)

            // US Core PatientProfile for Decedent
            patient = UsCorePatient.Create();
            patient.Id = "d2ab1a9f-9281-4f4b-ac14-2e297209fc33";

            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "Alpha", GivenElement = new List<FhirString> { new FhirString("Abel"), new FhirString("A") } } };
            patient.Identifier.Add(new Identifier()
            {
                Use = Identifier.IdentifierUse.Usual,
                Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", null),
                System = "http://hl7.org/fhir/sid/us-ssn",
                Value = "123456789"
            });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2054-5", "Black or African American");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2058-6", "African American") };
            patient.UsCorePatient().Race.RaceText = "White, Black";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2182-4", "Cuban") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Cuban";

            // Birth Related
            patient.BirthDateElement = new Date(1982, 6, 14);
            patient.UsCorePatient().BirthSex.Extension = new Code("M");
            patient.Gender = AdministrativeGender.Male;

            // Address
            patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "120 Healthy Street" },
                City = "HL7",
                State = "GA",
                PostalCode = "00001",
                Country = "USA"}
            };

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "404-770-1234");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "abelalpha@tox-case.org");

            Specimen specimenBlood1 = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood1.Id = "419f068e-dd40-11ed-b5ea-0242ac120002";
            specimenBlood1.AccessionIdentifier = new Identifier("http://lab.uab.org/specimens/2018", "20180001");
            specimenBlood1.Status = Specimen.SpecimenStatus.Available;
            specimenBlood1.ReceivedTimeElement = new FhirDateTime("2018-09-28T16:00:00Z");
            specimenBlood1.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2018-09-27T11:00:00Z"), BodySite = new CodeableConcept() { Text = "Central" } };
            specimenBlood1.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });
            specimenBlood1.Condition.Add(new CodeableConcept() { Coding = new List<Coding>() { ValueSets.Hl7VsSpecimenCondition.Cool }, Text = ValueSets.Hl7VsSpecimenCondition.Cool.Display });

            specimenUrine = SpecimenToxicologyLab.Create("Urine", patient);
            specimenUrine.Id = "28220188-dd46-11ed-b5ea-0242ac120002";
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.uab.org/specimens/2018", "2018000X");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2018-09-28T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2018-09-27T11:00:00Z") };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "5mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });
            specimenUrine.Condition.Add(new CodeableConcept() { Coding = new List<Coding>() { ValueSets.Hl7VsSpecimenCondition.RoomTemperature }, Text = ValueSets.Hl7VsSpecimenCondition.RoomTemperature.Display });

            Specimen specimenBlood2 = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood2.Id = "54a2e2ee-dd47-11ed-b5ea-0242ac120002";
            specimenBlood2.AccessionIdentifier = new Identifier("http://lab.uab.org/specimens/2018", "20180002");
            specimenBlood2.Status = Specimen.SpecimenStatus.Available;
            specimenBlood2.ReceivedTimeElement = new FhirDateTime("2018-09-28T16:00:00Z");
            specimenBlood2.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2018-09-27T11:00:00Z"), BodySite = new CodeableConcept() { Text = "Peripheral" } };
            specimenBlood2.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Specimen specimenBlood3 = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood3.Id = "13c0909a-dd48-11ed-b5ea-0242ac120002";
            specimenBlood3.AccessionIdentifier = new Identifier("http://lab.uab.org/specimens/2018", "20180003");
            specimenBlood3.Status = Specimen.SpecimenStatus.Available;
            specimenBlood3.ReceivedTimeElement = new FhirDateTime("2018-09-28T16:00:00Z");
            specimenBlood3.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2018-09-27T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood3.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Specimen specimenBlood4 = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood4.Id = "1cfb55a0-dd48-11ed-b5ea-0242ac120002";
            specimenBlood4.AccessionIdentifier = new Identifier("http://lab.uab.org/specimens/2018", "20180004");
            specimenBlood4.Status = Specimen.SpecimenStatus.Available;
            specimenBlood4.ReceivedTimeElement = new FhirDateTime("2018-09-28T16:00:00Z");
            specimenBlood4.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2018-09-27T11:00:00Z"), BodySite = new CodeableConcept() { Text = "Peripheral" } };
            specimenBlood4.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Specimen specimenBlood5 = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood5.Id = "21c942fe-dd48-11ed-b5ea-0242ac120002";
            specimenBlood5.AccessionIdentifier = new Identifier("http://lab.uab.org/specimens/2018", "20180005");
            specimenBlood5.Status = Specimen.SpecimenStatus.Available;
            specimenBlood5.ReceivedTimeElement = new FhirDateTime("2018-09-28T16:00:00Z");
            specimenBlood5.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2018-09-27T11:00:00Z"), BodySite = new CodeableConcept() { Text = "Peripheral" } };
            specimenBlood5.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Observation toxLabResultEthanolBlood1 = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolBlood1.Id = "a6e42852-dd5f-11ed-b5ea-0242ac120002";
            toxLabResultEthanolBlood1.Effective = new FhirDateTime("2018-09-30");
            toxLabResultEthanolBlood1.ObservationToxicologyLabResult().ValueText = "ND";
            toxLabResultEthanolBlood1.Method = new CodeableConcept() { Text = "GC" };
            toxLabResultEthanolBlood1.ObservationToxicologyLabResult().Specimen = specimenBlood1;

            toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "DA", patient);
            toxLabResultEthanolUrine.Id = "acdce014-dd5f-11ed-b5ea-0242ac120002";
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2018-09-30");
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().ValueText = "Cocaine M, P";
            toxLabResultEthanolUrine.Method = new CodeableConcept() { Text = "EMIT" };
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultEthanolBlood2 = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ecgonine Methyl Ester", patient);
            toxLabResultEthanolBlood2.Id = "b24c7bf4-dd5f-11ed-b5ea-0242ac120002";
            toxLabResultEthanolBlood2.Effective = new FhirDateTime("2018-09-30");
            toxLabResultEthanolBlood2.ObservationToxicologyLabResult().ValueText = "P";
            toxLabResultEthanolBlood2.Method = new CodeableConcept() { Text = "GC/MS" };
            toxLabResultEthanolBlood2.ObservationToxicologyLabResult().Specimen = specimenBlood2;

            Observation toxLabResultEthanolBlood3 = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Cocaine", patient);
            toxLabResultEthanolBlood3.Id = "b757dbc0-dd5f-11ed-b5ea-0242ac120002";
            toxLabResultEthanolBlood3.Effective = new FhirDateTime("2018-09-30");
            toxLabResultEthanolBlood3.ObservationToxicologyLabResult().ValueText = "0.068";
            toxLabResultEthanolBlood3.Method = new CodeableConcept() { Text = "GC/MC" };
            toxLabResultEthanolBlood3.ObservationToxicologyLabResult().Specimen = specimenBlood3;

            Observation toxLabResultEthanolBlood4 = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Cocaethylene", patient);
            toxLabResultEthanolBlood4.Id = "c5db7db4-dd5f-11ed-b5ea-0242ac120002";
            toxLabResultEthanolBlood4.Effective = new FhirDateTime("2018-09-30");
            toxLabResultEthanolBlood4.ObservationToxicologyLabResult().ValueText = "0.076";
            toxLabResultEthanolBlood4.Method = new CodeableConcept() { Text = "GC/MC" };
            toxLabResultEthanolBlood4.ObservationToxicologyLabResult().Specimen = specimenBlood4;

            Observation toxLabResultEthanolBlood5 = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Fentanyl", patient);
            toxLabResultEthanolBlood5.Id = "c9e7ff18-dd5f-11ed-b5ea-0242ac120002";
            toxLabResultEthanolBlood5.Effective = new FhirDateTime("2018-09-30");
            toxLabResultEthanolBlood5.ObservationToxicologyLabResult().ValueText = "0.002";
            toxLabResultEthanolBlood5.Method = new CodeableConcept() { Text = "ARUP" };
            toxLabResultEthanolBlood5.ObservationToxicologyLabResult().Specimen = specimenBlood5;


            // Us Core Diagnostic Report for Tox Lab Results
            diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);
            diagnosticReport.Id = "3a4eb094-dd60-11ed-b5ea-0242ac120002";
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().ToxLabCaseNumber = ("http://uab-path-labs.org/fhir/lab-cases", "2018-12345");

            diagnosticReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            diagnosticReport.Code = new CodeableConcept { Text = "Forensic Toxicology Lab Report" };
            diagnosticReport.Effective = new FhirDateTime("2018-10-01T16:00:00Z");
            diagnosticReport.IssuedElement = new Instant() { Value = new FhirDateTime("2018-10-05T00:00:00Z").ToDateTimeOffset(new TimeSpan()) };

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddPerformer(practitionerToxLab);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood1);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood2);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood3);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood4);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddSpecimen(specimenBlood5);

            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood1);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolUrine);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood2);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood3);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood4);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolBlood5);

            diagnosticReport.Text = new Narrative
            {
                Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">\n  <p>It may be appropriate to include interpretive information to help the reader understand the meaning of detected analytes. Interpretive information is not considered a mandatory part of the toxicological report, but is based on jurisdictional or laboratory preference to include such. This information may be included in the body of the report.</p>\n  </div>",
                Status = Narrative.NarrativeStatus.Additional
            };

            diagnosticReport.Conclusion = "The conclusion comes here. This is a test data for Toxicology-to-MDI workflow.";

            messageHeader = MessageHeaderToxicologyToMdi.Create("http://uf.org/access/endpoint/1", diagnosticReport);
            messageHeader.Id = "d73e936a-dd60-11ed-b5ea-0242ac120002";
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MDI.net";
            messageHeader.Source.Version = "1.0.0";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:c3fafc62dd6011edb5ea0242ac120002"), messageHeader);
            bundleMessageToxToMDI.Id = "d1c83922-dd60-11ed-b5ea-0242ac120002"; // set ID
            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "Tox_with_UAB_2018_1811.json", output);
            //Console.WriteLine(output);
        }
    }
}
