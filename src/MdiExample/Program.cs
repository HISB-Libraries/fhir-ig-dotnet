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
            causeOfDeath1.Status = ObservationStatus.Final;
            Observation causeOfDeath2 = ObservationCauseOfDeathPart1.Create(patient, practitioner, "Liver failure", 2, "1 hour");
            causeOfDeath2.Status = ObservationStatus.Final;

            // Condition Contributing to Death
            Observation conditionContributingToDeath = ObservationContributingCauseOfDeathPart2.Create(patient, practitioner);
            conditionContributingToDeath.Status = ObservationStatus.Final;
            conditionContributingToDeath.ObservationContributingCauseOfDeathPart2().Value = new CodeableConcept(null, null, "Hypertensive heart disease");

            // Observation Manner of Death
            Observation observationMannerOfDeath = ObservationMannerOfDeath.Create(patient, practitioner);
            observationMannerOfDeath.Value = MdiVsMannerOfDeath.AccidentalDeath;

            // Observation Death How Death Injury Occurred
            Observation observationHowDeathInjuryOccurred = ObservationHowDeathInjuryOccurred.Create(patient);
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
            deathLocation.Identifier.Add(new Identifier("http://www.acme.org/location", "29"));
            deathLocation.Status = Location.LocationStatus.Active;
            deathLocation.Name = "Atlanta GA Death Location - Freeman";
            deathLocation.Address = new Address() { Use = Address.AddressUse.Home, Type = Address.AddressType.Physical, Line = new List<string>{
                    "400 Windstream Street" }, City = "Atlanta", District = "Fulton County", State = "GA", Country = "USA" };

            // Location Injury
            Location injuryLocation = LocationInjury.Create();
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
            observationDeathDate.Status = ObservationStatus.Final;
            observationDeathDate.Effective = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.Value = new FhirDateTime("2022-01-08T14:04:00-05:00");
            observationDeathDate.ObservationDeathDate().DateTimePronouncedDead = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.ObservationDeathDate().PlaceOfDeath = MdiVsPlaceOfDeath.DeadOnArrivalAtHospital;
            observationDeathDate.Method = MdiCodeSystem.MdiCodes.Exact;

            // Death Certification
            Procedure procedureDeathCertification = ProcedureDeathCertification.Create(patient);
            procedureDeathCertification.ProcedureDeathCertification().Certifier = (MdiVsCertifierTypes.MedicalExaminerCornerExamination, practitioner);
            procedureDeathCertification.Status = EventStatus.Completed;
            procedureDeathCertification.Performed = new FhirDateTime("2022-01-08T15:30:00-05:00");

            // Observation Decedent Pregnancy
            Observation observationDecedentPregnancy = ObservationDecedentPregnancy.Create(patient);
            observationDecedentPregnancy.Value = MdiCodeSystem.DeathPregnancyStatus.NA;

            // Observation Tobacco Use Contributed To Death
            Observation observationTobaccoUseContributedToDeath = ObservationTobaccoUseContributedToDeath.Create(patient);
            observationTobaccoUseContributedToDeath.Value = MdiVsContributoryTobaccoUse.No;

            // Observation - Autopsy Performed Indicator
            Observation observationAutopsyPerformedIndicator = ObservationAutopsyPerformedIndicator.Create(patient);
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
            mdiDocument.AsReference();
            mdiDocument.TimestampElement = Instant.Now();

            string output = serializer.SerializeToString(mdiDocument);
            File.WriteAllText(outputPath + "MDItoEDRS_Fentanyl_toxicity_Document.json", output);
            //Console.WriteLine(output);


            /////////////////////////// Toxicology Lab Report ///////////////////////////////
            // Specimen for Toxicology
            // - Fentanyl OD

            // Us Core Practitioner (Tox Lab)
            Practitioner practitionerToxLab = UsCorePractitioner.Create();
            practitionerToxLab.Name = new List<HumanName> { new HumanName() { Use = HumanName.NameUse.Official, Family = "Goldberger", GivenElement = new List<FhirString> { new FhirString("Bruce") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } } };
            practitionerToxLab.UsCorePractitioner().NPI = "555667777";

            // Us Core Lab Organization
            Organization organizationLab = UsCoreOrganization.Create();
            organizationLab.Identifier.AddOrUpdateIdentifier(UsCoreOrganization.NPISystem, "111223333");
            organizationLab.Active = true;
            organizationLab.Type.Add(new CodeableConcept("http://terminology.hl7.org/CodeSystem/organization-type", "prov", "Healthcare Provider", null));
            organizationLab.Name = "UF Health Pathology Labs, Forensic Toxicology Laboratory";
            organizationLab.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Work, "(352) 265-9900");
            organizationLab.Address.Add(new Address() { Line = new List<String> { "4800 SW 35th Drive" }, City = "Gainesville", State = "FL", PostalCode = "32608", Country = "USA" });

            Specimen specimenBlood = SpecimenToxicologyLab.Create("Blood", patient);
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Specimen specimenUrine = SpecimenToxicologyLab.Create("Urine", patient);
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "5mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            Specimen specimenBile = SpecimenToxicologyLab.Create("Bile", patient);
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenVitreousHumor = SpecimenToxicologyLab.Create("Vitreous Humor", patient);
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "3mL GT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenStomachContents = SpecimenToxicologyLab.Create("Stomach Contents", patient);
            specimenStomachContents.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "MM352356");
            specimenStomachContents.Status = Specimen.SpecimenStatus.Available;
            specimenStomachContents.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenStomachContents.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenStomachContents.Container.Add(new Specimen.ContainerComponent() { Description = "60mL Cup", SpecimenQuantity = new Quantity() { Value = 60, Unit = "ml" } });

            Specimen specimenLiver = SpecimenToxicologyLab.Create("Liver", patient);
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5g Cup", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            // Toxicology Lab Results to MDI
            Observation toxLabResultEthanolBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().ValueText = "0.145 g/dL";
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResult4anppBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "4-ANPP", patient);
            toxLabResult4anppBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResult4anppBlood.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResult4anppBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultAcetylfentanylBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetylfentanyl", patient);
            toxLabResultAcetylfentanylBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetylfentanylBlood.ObservationToxicologyLabResult().ValueText = "<2.5 ng/mL";
            toxLabResultAcetylfentanylBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultFentanylBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Fentanyl", patient);
            toxLabResultFentanylBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultFentanylBlood.ObservationToxicologyLabResult().ValueText = "23 ng/mL";
            toxLabResultFentanylBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().ValueText = "0.160 g/dL";
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResult4anppUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "4-ANPP", patient);
            toxLabResult4anppUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResult4anppUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResult4anppUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultAcetylfentanylUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetylfentanyl", patient);
            toxLabResultAcetylfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetylfentanylUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultAcetylfentanylUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultFentanylUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Fentanyl", patient);
            toxLabResultFentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultFentanylUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultFentanylUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultNorfentanylUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Norfentanyl", patient);
            toxLabResultNorfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNorfentanylUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultNorfentanylUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultXylazineUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Xylazine", patient);
            toxLabResultXylazineUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultXylazineUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultXylazineUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultNotTestedBile = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedBile.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().Specimen = specimenBile;

            Observation toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolVitreousHumor.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().ValueText = "0.133 g/dL";
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().Specimen = specimenVitreousHumor;

            Observation toxLabResultNotTestedStomachContents = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedStomachContents.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().Specimen = specimenStomachContents;

            Observation toxLabResultNotTestedLiver = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedLiver.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().Specimen = specimenLiver;

            // Us Core Diagnostic Report for Tox Lab Results
            DiagnosticReport diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);

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
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MDI.net";
            messageHeader.Source.Version = "1.0.0";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            Bundle bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9"), messageHeader);
            bundleMessageToxToMDI.AsReference(); // set ID
            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "Tox_Fentanyl_OD.json", output);
            //Console.WriteLine(output);


            /////////////////////////////////
            ///
            // - Oxycodone & Alprazolam OD

            // US Core PatientProfile for Decedent
            patient = UsCorePatient.Create();
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
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            specimenUrine = SpecimenToxicologyLab.Create("Urine", patient);
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "5mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            specimenBile = SpecimenToxicologyLab.Create("Bile", patient);
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenVitreousHumor = SpecimenToxicologyLab.Create("Vitreous Humor", patient);
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "3mL GT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenStomachContents = SpecimenToxicologyLab.Create("Stomach Contents", patient);
            specimenStomachContents.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "MM352356");
            specimenStomachContents.Status = Specimen.SpecimenStatus.Available;
            specimenStomachContents.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenStomachContents.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenStomachContents.Container.Add(new Specimen.ContainerComponent() { Description = "60mL Cup", SpecimenQuantity = new Quantity() { Value = 60, Unit = "ml" } });

            specimenLiver = SpecimenToxicologyLab.Create("Liver", patient);
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5g Cup", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            // Toxicology Lab Results to MDI
            toxLabResultEthanolBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().ValueText = "0.145 g/dL";
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultAcetaminophenBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetaminophen", patient);
            toxLabResultAcetaminophenBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetaminophenBlood.ObservationToxicologyLabResult().ValueText = "54 mg/L";
            toxLabResultAcetaminophenBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultAlprazolamBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Alprazolam", patient);
            toxLabResultAlprazolamBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAlprazolamBlood.ObservationToxicologyLabResult().ValueText = "95 ng/mL";
            toxLabResultAlprazolamBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            Observation toxLabResultOxycodoneBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Oxycodone", patient);
            toxLabResultOxycodoneBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultOxycodoneBlood.ObservationToxicologyLabResult().ValueText = "335 ng/mL";
            toxLabResultOxycodoneBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().ValueText = "0.160 g/dL";
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultAcetaminophenUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetaminophen", patient);
            toxLabResultAcetaminophenUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetaminophenUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultAcetaminophenUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabAlphaHydroxyalprazolamUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Alpha-hydroxyalprazolam", patient);
            toxLabAlphaHydroxyalprazolamUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabAlphaHydroxyalprazolamUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabAlphaHydroxyalprazolamUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultCannabinoidsUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Cannabinoids", patient);
            toxLabResultCannabinoidsUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultCannabinoidsUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultCannabinoidsUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            Observation toxLabResultOxycoconeUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Oxycocone", patient);
            toxLabResultOxycoconeUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultOxycoconeUrine.ObservationToxicologyLabResult().ValueText = "Detected";
            toxLabResultOxycoconeUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            toxLabResultNotTestedBile = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedBile.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().Specimen = specimenBile;

            toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolVitreousHumor.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().ValueText = "0.133 g/dL";
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().Specimen = specimenVitreousHumor;

            toxLabResultNotTestedStomachContents = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedStomachContents.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().Specimen = specimenStomachContents;

            toxLabResultNotTestedLiver = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedLiver.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().Specimen = specimenLiver;

            // Us Core Diagnostic Report for Tox Lab Results
            diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);

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
                Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">\n  <p>It may be appropriate to include interpretive information to help the reader understand the meaning of detected analytes. Interpretive information is not considered a mandatory part of the toxicological report, but is based on jurisdictional or laboratory preference to include such. This information may be included in the body of the report.</p>\n  </div>",
                Status = Narrative.NarrativeStatus.Additional
            };

            messageHeader = MessageHeaderToxicologyToMdi.Create("http://uf.org/access/endpoint/1", diagnosticReport);
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MDI.net";
            messageHeader.Source.Version = "1.0.0";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9"), messageHeader);
            bundleMessageToxToMDI.AsReference(); // set ID
            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "Tox_Oxycodone_Alprazolam_OD.json", output);
            //Console.WriteLine(output);


            /////////////////////////////////
            ///
            // - MVA with Alcohol

            // US Core PatientProfile for Decedent
            patient = UsCorePatient.Create();
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
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "20mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non-evacuated blood collection tube, potassium oxalate/sodium fluoride (physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            specimenUrine = SpecimenToxicologyLab.Create("Urine", patient);
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "5mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            specimenBile = SpecimenToxicologyLab.Create("Bile", patient);
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenVitreousHumor = SpecimenToxicologyLab.Create("Vitreous Humor", patient);
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "3mL GT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            specimenStomachContents = SpecimenToxicologyLab.Create("Stomach Contents", patient);
            specimenStomachContents.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "MM352356");
            specimenStomachContents.Status = Specimen.SpecimenStatus.Available;
            specimenStomachContents.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenStomachContents.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenStomachContents.Container.Add(new Specimen.ContainerComponent() { Description = "60mL Cup", SpecimenQuantity = new Quantity() { Value = 60, Unit = "ml" } });

            specimenLiver = SpecimenToxicologyLab.Create("Liver", patient);
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z") };
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5g Cup", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            // Toxicology Lab Results to MDI
            toxLabResultEthanolBlood = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().ValueText = "0.145 g/dL";
            toxLabResultEthanolBlood.ObservationToxicologyLabResult().Specimen = specimenBlood;

            toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().ValueText = "0.160 g/dL";
            toxLabResultEthanolUrine.ObservationToxicologyLabResult().Specimen = specimenUrine;

            toxLabResultNotTestedBile = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedBile.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedBile.ObservationToxicologyLabResult().Specimen = specimenBile;

            toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Ethanol", patient);
            toxLabResultEthanolVitreousHumor.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().ValueText = "0.133 g/dL";
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().Specimen = specimenVitreousHumor;

            toxLabResultNotTestedStomachContents = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedStomachContents.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedStomachContents.ObservationToxicologyLabResult().Specimen = specimenStomachContents;

            toxLabResultNotTestedLiver = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Not Tested", patient);
            toxLabResultNotTestedLiver.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().ValueText = "";
            toxLabResultNotTestedLiver.ObservationToxicologyLabResult().Specimen = specimenLiver;

            // Us Core Diagnostic Report for Tox Lab Results
            diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);

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
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MDI.net";
            messageHeader.Source.Version = "1.0.0";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9"), messageHeader);
            bundleMessageToxToMDI.AsReference(); // set ID
            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "Tox_MVA_with_Alcohol.json", output);
            //Console.WriteLine(output);

        }
    }
}
