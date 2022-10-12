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
            patient.Name = new List<HumanName> { new HumanName() { Family = "FREEMAN", GivenElement = new List<FhirString> { new FhirString("Alice"), new FhirString("J") } } };
            patient.Identifier.Add(new Identifier() { Use = Identifier.IdentifierUse.Usual, Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SS", "Social Security number", "Social Security number"), System = "http://hospital.smarthealthit.org", Value = "987054321" });

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("1010-8", "Apache") };
            patient.UsCorePatient().Race.RaceText = "Apache";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2162-6", "Central American Indian") };
            patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

            // Birth Related
            patient.BirthDateElement = new Date(1965, 5, 2);
            patient.UsCorePatient().BirthSex.Extension = new Code("F");
            patient.Gender = AdministrativeGender.Female;

            // Address
            var address = new Address() { Use = Address.AddressUse.Home, State = "TX", PostalCode = "77018", Country = "USA" };
            address.Use = Address.AddressUse.Home;
            patient.Address.Add(address);

            // Contact
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5309");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310");
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310"); // duplicate entry demo
            patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "mywork@gtri.org");

            // Deceased
            patient.Deceased = new FhirDateTime(2014, 3, 2);
            // ODH Usual Work Observation
            // Removed --
            //Observation usualWorkObservation = OdhUsualWork.Create();
            //usualWorkObservation.Status = ObservationStatus.Final;
            //usualWorkObservation.Subject = patient.AsReference();
            //usualWorkObservation.Effective = new Period(new FhirDateTime("2000-06-01"), new FhirDateTime("2021-05-20"));
            //usualWorkObservation.OdhUsualWork().OccupationCdcCensus2010 = new Coding(OdhUsualWork.OccupationCdcCensus2010Oid, "3600", "Nursing, psychiatric, and home health aides");
            //usualWorkObservation.OdhUsualWork().OccupationCdcOnetSdc2010 = new Coding(OdhUsualWork.OccupationOdhOid, "31-1014.00.007136", "Certified Nursing Assistant (CNA) [Nursing Assistants]");
            //usualWorkObservation.OdhUsualWork().IndustryCdcCensus2010 = new Coding(OdhUsualWork.IndustryCdcCensus2010Oid, "8270", "Nursing care facilities");
            //usualWorkObservation.OdhUsualWork().UsualOccupationDuration = 21;

            // Us Core Practitioner (ME)
            Practitioner practitioner = UsCorePractitioner.Create();
            practitioner.Name = new List<HumanName> { new HumanName() { Use = HumanName.NameUse.Official, Family = "Jones", GivenElement = new List<FhirString> { new FhirString("Sam") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } } };
            practitioner.UsCorePractitioner().NPI = "3333445555";

            // Cause of Death Condition Observation
            Observation causeOfDeath1 = ObservationCauseOfDeathPart1.Create(patient, practitioner, "Fentanyl toxicity", 1, "minutes to hours");
            causeOfDeath1.Status = ObservationStatus.Final;
            Observation causeOfDeath2 = ObservationCauseOfDeathPart1.Create(patient, practitioner, "Fentanyl toxicity", 2, "minutes to hours");
            causeOfDeath2.Status = ObservationStatus.Final;

            // Condition Contributing to Death
            Observation conditionContributingToDeath = ObservationContributingCauseOfDeathPart2.Create();
            conditionContributingToDeath.Status = ObservationStatus.Final;
            conditionContributingToDeath.Subject = patient.AsReference();
            conditionContributingToDeath.Performer.Add(practitioner.AsReference());
            conditionContributingToDeath.ObservationContributingCauseOfDeathPart2().Value = new CodeableConcept(null, null, "Hypertensive heart disease");

            // Location Death
            Location deathLocation = LocationDeath.Create();
            deathLocation.Identifier.Add(new Identifier("http://www.acme.org/location", "29"));
            deathLocation.Status = Location.LocationStatus.Active;
            deathLocation.Name = "Atlanta GA Death Location - Freeman";
            deathLocation.Address = new Address() { Use = Address.AddressUse.Home, Type = Address.AddressType.Physical, Line = new List<string>{
                    "400 Windstream Street" }, City = "Atlanta", District = "Fulton County", State = "GA", Country = "USA" };

            // Observation Death Date
            Observation observationDeathDate = ObservationDeathDate.Create(patient);
            observationDeathDate.Status = ObservationStatus.Final;
            observationDeathDate.Effective = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.Value = new FhirDateTime("2022-01-08T14:04:00-05:00");
            observationDeathDate.ObservationDeathDate().DateTimePronouncedDead = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.ObservationDeathDate().PlaceOfDeath = MdiVsPlaceOfDeath.DeadOnArrivalAtHospital;
            observationDeathDate.Method = MdiCodeSystem.MdiCodes.Exact;

            // Observation Death How Death Injury Occurred
            Observation observationHowDeathInjuryOccurred = ObservationHowDeathInjuryOccurred.Create(patient);
            observationHowDeathInjuryOccurred.Status = ObservationStatus.Final;
            observationHowDeathInjuryOccurred.Performer.Add(practitioner.AsReference());
            observationHowDeathInjuryOccurred.ObservationHowDeathInjuryOccurred().HowInjuredDescription = "Ingested counterfeit medication";
            observationHowDeathInjuryOccurred.ObservationHowDeathInjuryOccurred().PartialDateTime = (
                new UnsignedInt(2022),
                new UnsignedInt(2),
                new UnsignedInt(1),
                new Time("12:30:45"));
            observationHowDeathInjuryOccurred.ObservationHowDeathInjuryOccurred().PlaceOfInjury = new CodeableConcept { Text = "Private House" };

            // Observation Manner of Death
            Observation observationMannerOfDeath = ObservationMannerOfDeath.Create(patient, practitioner);
            observationMannerOfDeath.Value = MdiVsMannerOfDeath.AccidentalDeath;

            // Death Certification
            Procedure procedureDeathCertification = ProcedureDeathCertification.Create(patient);
            procedureDeathCertification.ProcedureDeathCertification().Certifier = (MdiVsCertifierTypes.MedicalExaminerCornerExamination, practitioner);
            procedureDeathCertification.Status = EventStatus.Completed;
            procedureDeathCertification.Performed = new FhirDateTime("2022-01-08T15:30:00-05:00");

            // Observation Decedent Pregnancy
            Observation observationDecedentPregnancy = ObservationDecedentPregnancy.Create(patient);
            observationDecedentPregnancy.Value = MdiCodeSystem.DeathPregnancyStatus.NA;

            // Observation Tobacco Use Contributed To Death
            Observation observationTobaccoUseContributedToDeath = ObservationTobaccoUseContributedToDeath.Create();
            observationTobaccoUseContributedToDeath.Subject = patient.AsReference();
            observationTobaccoUseContributedToDeath.Value = MdiVsContributoryTobaccoUse.No;

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
            composition.CompositionMdiToEdrs().MdiCaseNumber = ("urn:connectathon:test", "Case1234");
            composition.CompositionMdiToEdrs().AdditionalDemographics = new Narrative {
                Div = "<div xmlns=\"http://www.w3.org/1999/xhtml\">\n  <p>No additional demographic information</p>\n  </div>",
                Status = Narrative.NarrativeStatus.Additional };
            composition.CompositionMdiToEdrs().Circumstances = (new List<Resource> { deathLocation }, null, null);
            composition.CompositionMdiToEdrs().Jurisdiction = (new List<Resource> { observationDeathDate, procedureDeathCertification }, null, null);
            composition.CompositionMdiToEdrs().CauseManner = (
                new List<Resource> { causeOfDeath1, causeOfDeath2 },
                new List<Resource> { conditionContributingToDeath },
                null /* manner of death */,
                new List<Resource> { observationHowDeathInjuryOccurred },
                null /* empty reason code */);

            // Medical History is not available. We have to have one of entry, text, or subsection.
            // Since we have no entry and no subsection, must include text.
            composition.CompositionMdiToEdrs().MedicalHistory = (
                null,
                new Narrative { Div="Medical History is not available", Status=Narrative.NarrativeStatus.Generated },
                ListEmptyReason.Unavailable);

            ////
            // Document Bundle
            Bundle MdiDocument = BundleDocumentMdiToEdrs.Create(
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:933dde44f7664b03a20b6324f23986c0"),
                composition
                );
            MdiDocument.TimestampElement = Instant.Now();

            var cod1A = MdiDocument.BundleDocumentMdiToEdrs().CauseOfDeathPart1A;
            string output = serializer.SerializeToString(MdiDocument);
            File.WriteAllText(outputPath + "MDItoEDRS_Document.json", output);
            //Console.WriteLine(output);

            /////////////////////////// Toxicology Lab Report ///////////////////////////////
            // Specimen for Toxicology
            Specimen specimenBlood = SpecimenToxicologyLab.Create("Whole blood sample (specimen)", patient);
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "10mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non - evacuated blood collection tube, potassium oxalate / sodium fluoride(physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Specimen specimenUrine = SpecimenToxicologyLab.Create("Urine specimen (specimen)", patient);
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "10mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            Specimen specimenVitreousHumor = SpecimenToxicologyLab.Create("Vitreous humor sample (specimen)", patient);
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.Type.Coding.Add(new Coding("http://snomed.info/sct", "258438000", "Vitreous humor sample (specimen)"));
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "10mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenBile = SpecimenToxicologyLab.Create("Bile specimen (specimen)", patient);
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL sample of bile specimen", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenLiver = SpecimenToxicologyLab.Create("Tissue specimen from liver (specimen)", patient);
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5mL sample of liver specimen", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            Specimen specimenStomachContents = SpecimenToxicologyLab.Create();
            specimenStomachContents.SpecimenToxicologyLab().SubjectAsResource = patient;
            specimenStomachContents.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "MM352356");
            specimenStomachContents.Status = Specimen.SpecimenStatus.Available;
            specimenStomachContents.Type = new CodeableConcept("http://snomed.info/sct", "258580003", "Specimen from stomach (specimen)", "Specimen from stomach (specimen)");
            specimenStomachContents.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenStomachContents.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenStomachContents.Container.Add(new Specimen.ContainerComponent() { Description = "60mL sample of stomach contents specimen", SpecimenQuantity = new Quantity() { Value = 60, Unit = "ml" } });

            // Toxicology Lab Results to MDI
            Observation toxLabResultEthanolBlood = ObservationToxicologyLabResult.Create();
            toxLabResultEthanolBlood.Status = ObservationStatus.Final;
            toxLabResultEthanolBlood.Code = new CodeableConcept("http://loinc.org", "56478-1", "Ethanol [Mass/volume] in Blood by Gas chromatography", "Ethanol [Mass/volume] in Blood by Gas chromatography");
            toxLabResultEthanolBlood.Subject = patient.AsReference();
            toxLabResultEthanolBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolBlood.Value = new Quantity() { Value = new Decimal(0.145), Unit = "g/dL", System = "http://unitsofmeasure.org" };
            toxLabResultEthanolBlood.Specimen = specimenBlood.AsReference();

            Observation toxLabResult4anppBlood = ObservationToxicologyLabResult.Create();
            toxLabResult4anppBlood.Status = ObservationStatus.Final;
            toxLabResult4anppBlood.Code = new CodeableConcept("http://loinc.org", "11072-6", "Despropionylfentanyl [Mass/volume] in Serum or Plasma", "Despropionylfentanyl [Mass/volume] in Serum or Plasma");
            toxLabResult4anppBlood.Subject = patient.AsReference();
            toxLabResult4anppBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResult4anppBlood.Value = new FhirBoolean(true);
            toxLabResult4anppBlood.Specimen = specimenBlood.AsReference();

            Observation toxLabResultAcetylfentanylBlood = ObservationToxicologyLabResult.Create();
            toxLabResultAcetylfentanylBlood.Status = ObservationStatus.Final;
            toxLabResultAcetylfentanylBlood.Code = new CodeableConcept("http://loinc.org", "86223-5", "Acetyl norfentanyl [Mass/volume] in Serum, Plasma or Blood by Confirmatory method", "Acetyl norfentanyl [Mass/volume] in Serum, Plasma or Blood by Confirmatory method");
            toxLabResultAcetylfentanylBlood.Subject = patient.AsReference();
            toxLabResultAcetylfentanylBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetylfentanylBlood.Value = new Quantity() { Value = 2, Unit = "ng/mL", System = "http://unitsofmeasure.org" };
            toxLabResultAcetylfentanylBlood.Specimen = specimenBlood.AsReference();

            Observation toxLabResultFentanylBlood = ObservationToxicologyLabResult.Create();
            toxLabResultFentanylBlood.Status = ObservationStatus.Final;
            toxLabResultFentanylBlood.Code = new CodeableConcept("http://loinc.org", "73938-3", "fentaNYL [Mass/volume] in Blood by Confirmatory method", "fentaNYL [Mass/volume] in Blood by Confirmatory method");
            toxLabResultFentanylBlood.Subject = patient.AsReference();
            toxLabResultFentanylBlood.Effective = new FhirDateTime("2021-12-03");
            toxLabResultFentanylBlood.Value = new Quantity() { Value = 23, Unit = "ng/mL", System = "http://unitsofmeasure.org" };
            toxLabResultFentanylBlood.Specimen = specimenBlood.AsReference();

            Observation toxLabResultEthanolUrine = ObservationToxicologyLabResult.Create();
            toxLabResultEthanolUrine.Status = ObservationStatus.Final;
            toxLabResultEthanolUrine.Code = new CodeableConcept("http://loinc.org", "46983-3", "Ethanol [Mass/volume] in Urine by Confirmatory method", "Ethanol [Mass/volume] in Urine by Confirmatory method");
            toxLabResultEthanolUrine.Subject = patient.AsReference();
            toxLabResultEthanolUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolUrine.Value = new Quantity() { Value = new Decimal(0.16), Unit = "g/dL", System = "http://unitsofmeasure.org" };
            toxLabResultEthanolUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResult4anppUrine = ObservationToxicologyLabResult.Create();
            toxLabResult4anppUrine.Status = ObservationStatus.Final;
            toxLabResult4anppUrine.Code = new CodeableConcept("http://loinc.org", "11072-6", "Despropionylfentanyl [Mass/volume] in Serum or Plasma", "Despropionylfentanyl [Mass/volume] in Serum or Plasma");
            toxLabResult4anppUrine.Subject = patient.AsReference();
            toxLabResult4anppUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResult4anppUrine.Value = new FhirBoolean(true);
            toxLabResult4anppUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultAcetylfentanylUrine = ObservationToxicologyLabResult.Create(ObservationStatus.Final, "Acetyl fentanyl [Presence] in Urine by Confirmatory method", patient);
            toxLabResultAcetylfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetylfentanylUrine.Value = new FhirBoolean(true);
            toxLabResultAcetylfentanylUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultFentanylUrine = ObservationToxicologyLabResult.Create();
            toxLabResultFentanylUrine.Status = ObservationStatus.Final;
            toxLabResultFentanylUrine.Code = new CodeableConcept("http://loinc.org", "11235-9", "fentaNYL [Presence] in Urine", "fentaNYL [Presence] in Urine");
            toxLabResultFentanylUrine.ObservationToxicologyLabResult().SubjectAsResource = patient;
            toxLabResultFentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultFentanylUrine.Value = new FhirBoolean(true);
            toxLabResultFentanylUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultNorfentanylUrine = ObservationToxicologyLabResult.Create();
            toxLabResultNorfentanylUrine.Status = ObservationStatus.Final;
            toxLabResultNorfentanylUrine.Code = new CodeableConcept("http://loinc.org", "43199-9", "Norfentanyl [Presence] in Urine", "Norfentanyl [Presence] in Urine");
            toxLabResultNorfentanylUrine.ObservationToxicologyLabResult().SubjectAsResource = patient;
            toxLabResultNorfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNorfentanylUrine.Value = new FhirBoolean(true);
            toxLabResultNorfentanylUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultXylazineUrine = ObservationToxicologyLabResult.Create();
            toxLabResultXylazineUrine.Status = ObservationStatus.Final;
            toxLabResultXylazineUrine.Code = new CodeableConcept("http://loinc.org", "12327-3", "Ketamine [Presence] in Urine", "Ketamine [Presence] in Urine");
            toxLabResultXylazineUrine.ObservationToxicologyLabResult().SubjectAsResource = patient;
            toxLabResultXylazineUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultXylazineUrine.Value = new FhirBoolean(true);
            toxLabResultXylazineUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create();
            toxLabResultEthanolVitreousHumor.Status = ObservationStatus.Final;
            toxLabResultEthanolVitreousHumor.Code = new CodeableConcept("http://loinc.org", "12465-1", "Ethanol [Mass/volume] in Vitreous fluid", "Ethanol [Mass/volume] in Vitreous fluid");
            toxLabResultEthanolVitreousHumor.ObservationToxicologyLabResult().SubjectAsResource = patient;
            toxLabResultEthanolVitreousHumor.Effective = new FhirDateTime("2021-12-03");
            toxLabResultEthanolVitreousHumor.Value = new Quantity() { Value = new Decimal(0.133), Unit = "g/dL", System = "http://unitsofmeasure.org" };
            toxLabResultEthanolVitreousHumor.Specimen = specimenVitreousHumor.AsReference();

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

            // Us Core Diagnostic Report for Tox Lab Results
            DiagnosticReport diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create(patient);
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().ToxLabCaseNumber = ("http://uf-path-labs.org/fhir/lab-cases", "R21-01578");
            diagnosticReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            diagnosticReport.Code = new CodeableConcept("http://loinc.org", "81273-5", "fentaNYL and Norfentanyl panel - Specimen", null);
            diagnosticReport.Effective = new FhirDateTime("2021-12-03T11:00:00Z");
            diagnosticReport.IssuedElement = new Instant() { Value = new FhirDateTime("2022-01-05T11:00:00Z").ToDateTimeOffset(new TimeSpan()) };

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
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().AddResult(toxLabResultEthanolVitreousHumor);

            MessageHeader messageHeader = MessageHeaderToxicologyToMdi.Create("http://uf.org/access/endpoint/1", diagnosticReport);
            messageHeader.Source.Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory";
            messageHeader.Source.Software = "MS Access";
            messageHeader.Source.Version = "1.2.3";
            messageHeader.Source.Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567");

            // Tox Report Bundle
            Bundle bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create(new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9"), messageHeader);

            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "ToxToCMS_Message.json", output);
            //Console.WriteLine(output);
        }
    }
}
