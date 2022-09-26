using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.BundleDocumentMdiToEdrsProfile;
using GaTech.Chai.Mdi.BundleMessageToxicologyToMdiProfile;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.Mdi.CompositionMditoEdrsProfile;
using GaTech.Chai.Mdi.DiagnosticReportToxicologyLabResultToMdiProfile;
using GaTech.Chai.Mdi.ListCauseOfDeathPathwayProfile;
using GaTech.Chai.Mdi.LocationDeathProfile;
using GaTech.Chai.Mdi.MessageHeaderToxicologyToMdiProfile;
using GaTech.Chai.Mdi.ObservationCauseOfDeathPart1Profile;
using GaTech.Chai.Mdi.ObservationConditionContributingToDeathProfile;
using GaTech.Chai.Mdi.ObservationContributingCauseOfDeathPart2Profile;
using GaTech.Chai.Mdi.ObservationDeathDateProfile;
using GaTech.Chai.Mdi.ObservationDeathInjuryEventOccurredAtWorkProfile;
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
            Observation observationDeathDate = ObservationDeathDate.Create();
            observationDeathDate.Subject = patient.AsReference();
            observationDeathDate.Effective = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.Value = new FhirDateTime("2022-01-08T14:04:00-05:00");
            observationDeathDate.ObservationDeathDate().DateAndTimePronouncedDead = new FhirDateTime("2022-01-08T15:30:00-05:00");
            observationDeathDate.ObservationDeathDate().ObservationLocation = deathLocation.AsReference();
            observationDeathDate.Method = MdiCodeSystem.MdiCodes.Exact;

            // Observation Death Injury/Event Occurred at Work
            Observation observationInjuryEventWork = ObservationDeathInjuryEventOccurredAtWork.Create();
            observationInjuryEventWork.Status = ObservationStatus.Final;
            observationInjuryEventWork.Subject = patient.AsReference();
            observationInjuryEventWork.Value = MdiVsYesNoNotApplicable.No;

            // Observation Death How Death Injury Occurred
            Observation observationHowDeathInjuryOccurred = ObservationHowDeathInjuryOccurred.Create();
            observationHowDeathInjuryOccurred.Status = ObservationStatus.Final;
            observationHowDeathInjuryOccurred.Subject = patient.AsReference();
            observationHowDeathInjuryOccurred.Effective = new FhirDateTime("2018-02-19T16:48:06-05:00");
            observationHowDeathInjuryOccurred.Performer.Add(practitioner.AsReference());
            observationHowDeathInjuryOccurred.Value = new FhirString("Ingested counterfeit medication");

            // Observation Manner of Death
            Observation observationMannerOfDeath = ObservationMannerOfDeath.Create();
            observationMannerOfDeath.Subject = patient.AsReference();
            observationMannerOfDeath.Performer.Add(patient.AsReference());
            observationMannerOfDeath.Value = MdiVsMannerOfDeath.AccidentalDeath;

            // Observation Decedent Pregnancy
            Observation observationDecedentPregnancy = ObservationDecedentPregnancy.Create();
            observationDecedentPregnancy.Subject = patient.AsReference();
            observationDecedentPregnancy.Value = MdiVsDeathPregnancyStatus.NA;

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
                practitioner
                );
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Title = "MDI to EDRS Composition";

            // Demo: Tracking numbers - one with library. the other for custom type
            composition.CompositionMdiToEdrs().MdiCaseNumber = ("urn:connectathon:test", "Case1234");
            composition.CompositionMdiToEdrs().AdditionalDemographics = "Certified Nursing Assistant (CNA) [Nursing Assistants]";
            composition.CompositionMdiToEdrs().Circumstances = (new List<Resource> { deathLocation }, null, null);
            composition.CompositionMdiToEdrs().CauseManner = (new List<Resource> { causeOfDeath1, causeOfDeath2 }, null, null, null, null);

            ////
            // Document Bundle
            Bundle MdiDocument = BundleDocumentMdiToEdrs.Create(
                composition,
                new Identifier("urn:ietf:rfc:3986", "urn:uuid:933dde44f7664b03a20b6324f23986c0")
                );
            MdiDocument.TimestampElement = Instant.Now();

            var cod1A = MdiDocument.BundleDocumentMdiToEdrs().CauseOfDeathPart1A;
            Console.WriteLine("Cause of Death 1A : " + cod1A.Item1);
            Console.WriteLine("Cause of Death 1A Interval : " + cod1A.Item2);

            string output = serializer.SerializeToString(MdiDocument);
            File.WriteAllText(outputPath + "MDItoEDRS_Document.json", output);
            //Console.WriteLine(output);

            /////////////////////////// Toxicology Lab Report ///////////////////////////////
            // Specimen for Toxicology
            Specimen specimenBlood = SpecimenToxicologyLab.Create();
            specimenBlood.Subject = patient.AsReference();
            specimenBlood.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "X352356");
            specimenBlood.Status = Specimen.SpecimenStatus.Available;
            specimenBlood.Type = new CodeableConcept("http://snomed.info/sct", "258580003", "Whole blood sample (specimen)", "Whole blood sample (specimen)");
            specimenBlood.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBlood.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenBlood.Container.Add(new Specimen.ContainerComponent() { Description = "10mL GT tube", Type = new CodeableConcept("http://snomed.info/sct", "702287009", "Non - evacuated blood collection tube, potassium oxalate / sodium fluoride(physical object)", "GT tube"), SpecimenQuantity = new Quantity() { Value = 20, Unit = "ml" } });

            Specimen specimenUrine = SpecimenToxicologyLab.Create();
            specimenUrine.Subject = patient.AsReference();
            specimenUrine.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "ZZZ352356");
            specimenUrine.Status = Specimen.SpecimenStatus.Available;
            specimenUrine.Type = new CodeableConcept("http://snomed.info/sct", "122575003", "Urine specimen (specimen)", "Urine specimen (specimen)");
            specimenUrine.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenUrine.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenUrine.Container.Add(new Specimen.ContainerComponent() { Description = "10mL RT tube", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            Specimen specimenVitreousHumor = SpecimenToxicologyLab.Create();
            specimenVitreousHumor.Subject = patient.AsReference();
            specimenVitreousHumor.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "XXX352356");
            specimenVitreousHumor.Status = Specimen.SpecimenStatus.Available;
            specimenVitreousHumor.Type = new CodeableConcept("http://snomed.info/sct", "258438000", "Vitreous humor sample (specimen)", "Vitreous humor sample (specimen)");
            specimenVitreousHumor.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenVitreousHumor.Collection = new Specimen.CollectionComponent() { Collected = new FhirDateTime("2021-12-03T11:00:00Z"), BodySite = new CodeableConcept("http://snomed.info/sct", "83419000", "Femoral vein structure (body structure)", null) };
            specimenVitreousHumor.Container.Add(new Specimen.ContainerComponent() { Description = "10mL RT tube", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenBile = SpecimenToxicologyLab.Create();
            specimenBile.Subject = patient.AsReference();
            specimenBile.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "OO352356");
            specimenBile.Status = Specimen.SpecimenStatus.Available;
            specimenBile.Type = new CodeableConcept("http://snomed.info/sct", "119341000", "Bile specimen (specimen)", "Bile specimen (specimen)");
            specimenBile.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenBile.Container.Add(new Specimen.ContainerComponent() { Description = "3mL sample of bile specimen", SpecimenQuantity = new Quantity() { Value = 3, Unit = "ml" } });

            Specimen specimenLiver = SpecimenToxicologyLab.Create();
            specimenLiver.Subject = patient.AsReference();
            specimenLiver.AccessionIdentifier = new Identifier("http://lab.acme.org/specimens/2021", "DD352356");
            specimenLiver.Status = Specimen.SpecimenStatus.Available;
            specimenLiver.Type = new CodeableConcept("http://snomed.info/sct", "119379005", "Tissue specimen from liver (specimen)", "Tissue specimen from liver (specimen)");
            specimenLiver.ReceivedTimeElement = new FhirDateTime("2021-12-03T16:00:00Z");
            specimenLiver.Container.Add(new Specimen.ContainerComponent() { Description = "5mL sample of liver specimen", SpecimenQuantity = new Quantity() { Value = 5, Unit = "ml" } });

            Specimen specimenStomachContents = SpecimenToxicologyLab.Create();
            specimenStomachContents.Subject = patient.AsReference();
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

            Observation toxLabResultAcetylfentanylUrine = ObservationToxicologyLabResult.Create();
            toxLabResultAcetylfentanylUrine.Status = ObservationStatus.Final;
            toxLabResultAcetylfentanylUrine.Code = new CodeableConcept("http://loinc.org", "74810-3", "Acetyl fentanyl [Presence] in Urine by Confirmatory method", "Acetyl fentanyl [Presence] in Urine by Confirmatory method");
            toxLabResultAcetylfentanylUrine.Subject = patient.AsReference();
            toxLabResultAcetylfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultAcetylfentanylUrine.Value = new FhirBoolean(true);
            toxLabResultAcetylfentanylUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultFentanylUrine = ObservationToxicologyLabResult.Create();
            toxLabResultFentanylUrine.Status = ObservationStatus.Final;
            toxLabResultFentanylUrine.Code = new CodeableConcept("http://loinc.org", "11235-9", "fentaNYL [Presence] in Urine", "fentaNYL [Presence] in Urine");
            toxLabResultFentanylUrine.Subject = patient.AsReference();
            toxLabResultFentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultFentanylUrine.Value = new FhirBoolean(true);
            toxLabResultFentanylUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultNorfentanylUrine = ObservationToxicologyLabResult.Create();
            toxLabResultNorfentanylUrine.Status = ObservationStatus.Final;
            toxLabResultNorfentanylUrine.Code = new CodeableConcept("http://loinc.org", "43199-9", "Norfentanyl [Presence] in Urine", "Norfentanyl [Presence] in Urine");
            toxLabResultNorfentanylUrine.Subject = patient.AsReference();
            toxLabResultNorfentanylUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultNorfentanylUrine.Value = new FhirBoolean(true);
            toxLabResultNorfentanylUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultXylazineUrine = ObservationToxicologyLabResult.Create();
            toxLabResultXylazineUrine.Status = ObservationStatus.Final;
            toxLabResultXylazineUrine.Code = new CodeableConcept("http://loinc.org", "12327-3", "Ketamine [Presence] in Urine", "Ketamine [Presence] in Urine");
            toxLabResultXylazineUrine.Subject = patient.AsReference();
            toxLabResultXylazineUrine.Effective = new FhirDateTime("2021-12-03");
            toxLabResultXylazineUrine.Value = new FhirBoolean(true);
            toxLabResultXylazineUrine.Specimen = specimenUrine.AsReference();

            Observation toxLabResultEthanolVitreousHumor = ObservationToxicologyLabResult.Create();
            toxLabResultEthanolVitreousHumor.Status = ObservationStatus.Final;
            toxLabResultEthanolVitreousHumor.Code = new CodeableConcept("http://loinc.org", "12465-1", "Ethanol [Mass/volume] in Vitreous fluid", "Ethanol [Mass/volume] in Vitreous fluid");
            toxLabResultEthanolVitreousHumor.Subject = patient.AsReference();
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
            DiagnosticReport diagnosticReport = DiagnosticReportToxicologyLabResultToMdi.Create();
            diagnosticReport.DiagnosticReportToxicologyLabResultToMdi().ToxCaseNumber = ("http://uf-path-labs.org/fhir/lab-cases", "R21-01578");
            diagnosticReport.Identifier.GetIdentifier(MdiCodeSystem.MdiCodes.ToxLabCaseNumber.Coding[0]).Assigner = organizationLab.AsReference();
            diagnosticReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            diagnosticReport.Code = new CodeableConcept("http://loinc.org", "81273-5", "fentaNYL and Norfentanyl panel - Specimen", null);
            diagnosticReport.Subject = patient.AsReference();
            if (patient.Name != null) {
                diagnosticReport.Subject.Display = patient.Name[0].Family + ", " + patient.Name[0].GivenElement[0];
            }
            diagnosticReport.Effective = new FhirDateTime("2021-12-03T11:00:00Z");
            diagnosticReport.IssuedElement = new Instant() { Value = new FhirDateTime("2022-01-05T11:00:00Z").ToDateTimeOffset(new TimeSpan()) };
            diagnosticReport.Performer.Add(practitionerToxLab.AsReference());
            diagnosticReport.Specimen.Add(specimenBlood.AsReference(specimenBlood.Type.Text));
            diagnosticReport.Specimen.Add(specimenUrine.AsReference(specimenUrine.Type.Text));
            diagnosticReport.Specimen.Add(specimenVitreousHumor.AsReference(specimenVitreousHumor.Type.Text));
            diagnosticReport.Specimen.Add(specimenBile.AsReference(specimenBile.Type.Text));
            diagnosticReport.Specimen.Add(specimenLiver.AsReference(specimenLiver.Type.Text));
            diagnosticReport.Specimen.Add(specimenStomachContents.AsReference(specimenStomachContents.Type.Text));

            diagnosticReport.Result.Add(toxLabResultEthanolBlood.AsReference(toxLabResultEthanolBlood.Code.Text));
            diagnosticReport.Result.Add(toxLabResult4anppBlood.AsReference(toxLabResult4anppBlood.Code.Text));
            diagnosticReport.Result.Add(toxLabResultAcetylfentanylBlood.AsReference(toxLabResultAcetylfentanylBlood.Code.Text));
            diagnosticReport.Result.Add(toxLabResultFentanylBlood.AsReference(toxLabResultFentanylBlood.Code.Text));
            diagnosticReport.Result.Add(toxLabResultEthanolUrine.AsReference(toxLabResultEthanolUrine.Code.Text));
            diagnosticReport.Result.Add(toxLabResult4anppUrine.AsReference(toxLabResult4anppUrine.Code.Text));
            diagnosticReport.Result.Add(toxLabResultAcetylfentanylUrine.AsReference(toxLabResultAcetylfentanylUrine.Code.Text));
            diagnosticReport.Result.Add(toxLabResultFentanylUrine.AsReference(toxLabResultFentanylUrine.Code.Text));
            diagnosticReport.Result.Add(toxLabResultNorfentanylUrine.AsReference(toxLabResultNorfentanylUrine.Code.Text));
            diagnosticReport.Result.Add(toxLabResultXylazineUrine.AsReference(toxLabResultXylazineUrine.Code.Text));
            diagnosticReport.Result.Add(toxLabResultEthanolVitreousHumor.AsReference(toxLabResultEthanolVitreousHumor.Code.Text));

            MessageHeader messageHeader = MessageHeaderToxicologyToMdi.Create();
            messageHeader.Source = new MessageHeader.MessageSourceComponent() { Name = "University of Florida Pathology Labs, Forensic Toxicology Laboratory", Software = "MS Access", Version = "1.2.3", Contact = new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "+1 (555) 123 4567"), Endpoint = "http://uf.org/access/endpoint/1" };
            messageHeader.Focus.Add(diagnosticReport.AsReference());

            // Tox Report Bundle
            Bundle bundleMessageToxToMDI = BundleMessageToxicologyToMdi.Create();
            bundleMessageToxToMDI.Identifier = new Identifier("urn:ietf:rfc:3986", "urn:uuid:683dde44f7664b03a20b6324f23986d9");
            bundleMessageToxToMDI.AddResourceEntry(messageHeader, messageHeader.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(diagnosticReport, diagnosticReport.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(patient, patient.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(practitionerToxLab, practitionerToxLab.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(organizationLab, organizationLab.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(specimenBlood, specimenBlood.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(specimenUrine, specimenUrine.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(specimenVitreousHumor, specimenVitreousHumor.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(specimenBile, specimenBile.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(specimenLiver, specimenLiver.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(specimenStomachContents, specimenStomachContents.AsReference().Url.ToString());

            bundleMessageToxToMDI.AddResourceEntry(toxLabResultEthanolBlood, toxLabResultEthanolBlood.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResult4anppBlood, toxLabResult4anppBlood.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultAcetylfentanylBlood, toxLabResultAcetylfentanylBlood.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultFentanylBlood, toxLabResultFentanylBlood.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultEthanolUrine, toxLabResultEthanolUrine.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResult4anppUrine, toxLabResult4anppUrine.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultAcetylfentanylUrine, toxLabResultAcetylfentanylUrine.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultFentanylUrine, toxLabResultFentanylUrine.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultNorfentanylUrine, toxLabResultNorfentanylUrine.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultXylazineUrine, toxLabResultXylazineUrine.AsReference().Url.ToString());
            bundleMessageToxToMDI.AddResourceEntry(toxLabResultEthanolVitreousHumor, toxLabResultEthanolVitreousHumor.AsReference().Url.ToString());

            output = serializer.SerializeToString(bundleMessageToxToMDI);
            File.WriteAllText(outputPath + "ToxToCMS_Message.json", output);
            //Console.WriteLine(output);
        }
    }
}
