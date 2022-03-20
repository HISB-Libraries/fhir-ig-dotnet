using System;
using System.Collections.Generic;
using System.IO;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.BundleDocumentMdiToEdrsProfile;
using GaTech.Chai.Mdi.Common;
using GaTech.Chai.Mdi.CompositionMditoEdrsProfile;
using GaTech.Chai.Mdi.DiagnosticReportToxicologyLabResultToMdiProfile;
using GaTech.Chai.Mdi.ListCauseOfDeathPathwayProfile;
using GaTech.Chai.Mdi.ObservationCauseOfDeathConditionProfile;
using GaTech.Chai.Mdi.ObservationConditionContributingToDeathProfile;
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

            // US Core PatientProfile
            Patient patient = UsCorePatient.Create();
            // Name
            patient.Name = new List<HumanName> { new HumanName() { Family = "FREEMAN", GivenElement = new List<FhirString> { new FhirString("Alice"), new FhirString("J") } } };

            // Race
            patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
            patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("1010-8", "Apache") };
            patient.UsCorePatient().Race.RaceText = "Apache";

            // Ethnicity
            patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
            patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino") };
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
            Observation usualWorkObservation = OdhUsualWork.Create();
            usualWorkObservation.Status = ObservationStatus.Final;
            usualWorkObservation.Subject = patient.AsReference();
            usualWorkObservation.Effective = new Period(new FhirDateTime("2000-06-01"), new FhirDateTime("2021-05-20"));
            usualWorkObservation.OdhUsualWork().OccupationCdcCensus2010 = new Coding(OdhUsualWork.OccupationCdcCensus2010Oid, "3600", "Nursing, psychiatric, and home health aides");
            usualWorkObservation.OdhUsualWork().OccupationCdcOnetSdc2010 = new Coding(OdhUsualWork.OccupationOdhOid, "31-1014.00.007136", "Certified Nursing Assistant (CNA) [Nursing Assistants]");
            usualWorkObservation.OdhUsualWork().IndustryCdcCensus2010 = new Coding(OdhUsualWork.IndustryCdcCensus2010Oid, "8270", "Nursing care facilities");
            usualWorkObservation.OdhUsualWork().UsualOccupationDuration = 21;

            // Cause of Death Condition Observation
            Observation causeOfDeath1 = ObservationCauseOfDeathCondition.Create();
            causeOfDeath1.Status = ObservationStatus.Final;
            causeOfDeath1.Subject = patient.AsReference();
            causeOfDeath1.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            causeOfDeath1.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            Observation causeOfDeath2 = ObservationCauseOfDeathCondition.Create();
            causeOfDeath2.Status = ObservationStatus.Final;
            causeOfDeath2.Subject = patient.AsReference();
            causeOfDeath2.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            causeOfDeath2.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            Observation causeOfDeath3 = ObservationCauseOfDeathCondition.Create();
            causeOfDeath3.Status = ObservationStatus.Final;
            causeOfDeath3.Subject = patient.AsReference();
            causeOfDeath3.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            causeOfDeath3.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            Observation causeOfDeath4 = ObservationCauseOfDeathCondition.Create();
            causeOfDeath4.Status = ObservationStatus.Final;
            causeOfDeath4.Subject = patient.AsReference();
            causeOfDeath4.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            causeOfDeath4.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            Observation causeOfDeath5 = ObservationCauseOfDeathCondition.Create();
            causeOfDeath5.Status = ObservationStatus.Final;
            causeOfDeath5.Subject = patient.AsReference();
            causeOfDeath5.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            causeOfDeath5.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            Observation causeOfDeath6 = ObservationCauseOfDeathCondition.Create();
            causeOfDeath6.Status = ObservationStatus.Final;
            causeOfDeath6.Subject = patient.AsReference();
            causeOfDeath6.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            causeOfDeath6.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            // Us Core Practitioner (ME)
            Practitioner practitioner = UsCorePractitioner.Create();
            practitioner.Name = new List<HumanName> { new HumanName() { Use = HumanName.NameUse.Official, Family = "Jones", GivenElement = new List<FhirString> { new FhirString("Sam") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } } };
            practitioner.UsCorePractitioner().NPI = "3333445555";

            // Cause of Death Pathway
            List pathWayList = ListCauseOfDeathPathway.Create();
            pathWayList.ListCauseOfDeathPathway().AddCauseOfDeathCondition(causeOfDeath1.AsReference());
            pathWayList.ListCauseOfDeathPathway().AddCauseOfDeathCondition(causeOfDeath2.AsReference());
            pathWayList.ListCauseOfDeathPathway().AddCauseOfDeathCondition(causeOfDeath3.AsReference());
            pathWayList.ListCauseOfDeathPathway().AddCauseOfDeathCondition(causeOfDeath4.AsReference());
            pathWayList.ListCauseOfDeathPathway().AddCauseOfDeathCondition(causeOfDeath5.AsReference());
            ////
            // Demo: Total number of causes of death check
            //pathWayList.ListCauseOfDeathPathway().AddCauseOfDeathCondition(causeOfDeath6.AsReference());
            pathWayList.Subject = patient.AsReference();
            pathWayList.Source = practitioner.AsReference();

            // Condition Contributing to Death
            Observation conditionContributingToDeath = ObservationConditionContributingToDeath.Create();
            conditionContributingToDeath.Status = ObservationStatus.Final;
            conditionContributingToDeath.Subject = patient.AsReference();
            conditionContributingToDeath.Performer.Add(practitioner.AsReference());
            conditionContributingToDeath.ObservationConditionContributingToDeath().Value = new CodeableConcept(null, null, "Hypertensive heart disease");

            // Location Death
            Location deathLocation = UsCoreLocation.Create();
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
            observationDeathDate.Method = MdiCodeSystem.Exact;

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
            Composition composition = CompositionMdiToEdrs.Create();
            // Demo: Tracking numbers - one with library. the other for custom type
            composition.CompositionMdiToEdrs().MdiCaseNumber = "Case1234";
            ////
            // demo: custom tracking number
            //Extension ext = new Extension() { Url = "http://hl7.org/fhir/us/mdi/StructureDefinition/Extension-tracking-number" };
            //ext.Value = new Identifier() { Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "BCT"), Value = "ME21-113" };
            //composition.Extension.AddOrUpdateExtension(ext);
            composition.Identifier = new Identifier() { Value = "a03eab8c-11e8-4d0c-ad2a-b385395e27de" };
            composition.Status = CompositionStatus.Final;
            composition.Subject = patient.AsReference();
            composition.DateElement = new FhirDateTime("2022-02-20");
            composition.Author = new List<ResourceReference> { practitioner.AsReference() };
            composition.Title = "MDI to EDRS Composition";
            composition.CompositionMdiToEdrs().Demographics = new Composition.SectionComponent() { Entry = new List<ResourceReference> { usualWorkObservation.AsReference() } };
            composition.CompositionMdiToEdrs().Circumstances = new Composition.SectionComponent() { Entry = new List<ResourceReference> { deathLocation.AsReference(), observationInjuryEventWork.AsReference(), observationTobaccoUseContributedToDeath.AsReference(), observationDecedentPregnancy.AsReference() } };
            composition.CompositionMdiToEdrs().Jurisdiction = new Composition.SectionComponent() { Entry = new List<ResourceReference> { observationDeathDate.AsReference() } };
            composition.CompositionMdiToEdrs().CauseManner = new Composition.SectionComponent() { Entry = new List<ResourceReference> { pathWayList.AsReference(), conditionContributingToDeath.AsReference(), observationMannerOfDeath.AsReference(), observationHowDeathInjuryOccurred.AsReference() } };
            composition.CompositionMdiToEdrs().MedicalHistory = new Composition.SectionComponent() { EmptyReason = new CodeableConcept("http://terminology.hl7.org/CodeSystem/list-empty-reason", "unavailable", "Unavailable", "Decedent's medical history not available") };

            ////
            // Document Bundle
            Bundle MdiDocument = BundleDocumentMdiToEdrs.Create();
            MdiDocument.Identifier = new Identifier("urn:ietf:rfc:3986", "urn:uuid:933dde44f7664b03a20b6324f23986c0");
            MdiDocument.TimestampElement = Instant.Now();
            MdiDocument.AddResourceEntry(composition, composition.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(usualWorkObservation, usualWorkObservation.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(deathLocation, deathLocation.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(observationInjuryEventWork, observationInjuryEventWork.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(observationTobaccoUseContributedToDeath, observationTobaccoUseContributedToDeath.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(observationDecedentPregnancy, observationDecedentPregnancy.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(observationDeathDate, observationDeathDate.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(pathWayList, pathWayList.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(conditionContributingToDeath, conditionContributingToDeath.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(observationMannerOfDeath, observationMannerOfDeath.AsReference().Url.ToString());
            MdiDocument.AddResourceEntry(observationHowDeathInjuryOccurred, observationHowDeathInjuryOccurred.AsReference().Url.ToString());

            string output = serializer.SerializeToString(MdiDocument);
            File.WriteAllText("MDItoEDRS_Document.json", output);
            Console.WriteLine(output);

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
            Observation toxLabResultChromatography = ObservationToxicologyLabResult.Create();
            toxLabResultChromatography.Status = ObservationStatus.Final;
            toxLabResultChromatography.Code = new CodeableConcept("http://loinc.org", "56478-1", "Ethanol [Mass/volume] in Blood by Gas chromatography", "Ethanol [Mass/volume] in Blood by Gas chromatography");
            toxLabResultChromatography.Subject = patient.AsReference();
            toxLabResultChromatography.Effective = new FhirDateTime("2021-12-03");
            toxLabResultChromatography.Value = new Quantity() { Value = new Decimal(0.145), Unit = "g/dL", System = "http://unitsofmeasure.org" };
            toxLabResultChromatography.Specimen = specimenBlood.AsReference();

            Observation toxLabResult = ObservationToxicologyLabResult.Create();
            toxLabResult.Status = ObservationStatus.Final;
            toxLabResult.Code = new CodeableConcept("http://loinc.org", "73938-3", "fentaNYL [Mass/volume] in Blood by Confirmatory method", null);
            toxLabResult.Subject = patient.AsReference();
            toxLabResult.Effective = new FhirDateTime("2021-12-03");
            toxLabResult.Value = new Quantity() { Value = 23, Unit = "ng/mL", System = "http://unitsofmeasure.org" };
            toxLabResult.Specimen = specimenBlood.AsReference();

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
            diagnosticReport.Identifier.GetIdentifier(MdiCodeSystem.ToxLabCaseNumber.Coding[0]).Assigner = organizationLab.AsReference();
            diagnosticReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            diagnosticReport.Code = new CodeableConcept("http://loinc.org", "81273-5", "fentaNYL and Norfentanyl panel - Specimen", null);
            diagnosticReport.Subject = patient.AsReference();
            if (patient.Name != null) {
                diagnosticReport.Subject.Display = patient.Name[0].Family + ", " + patient.Name[0].GivenElement[0];
            }
            diagnosticReport.Effective = new FhirDateTime("2021-12-03T11:00:00Z");
            diagnosticReport.IssuedElement = new Instant() { Value = new FhirDateTime("2022-01-05T11:00:00Z").ToDateTimeOffset(new TimeSpan()) };
            diagnosticReport.Performer.Add(practitionerToxLab.AsReference());
            diagnosticReport.Specimen.Add(specimenBlood.AsReference());
            diagnosticReport.Specimen.Add(specimenUrine.AsReference());
            diagnosticReport.Specimen.Add(specimenVitreousHumor.AsReference());
            diagnosticReport.Specimen.Add(specimenBile.AsReference());
            diagnosticReport.Specimen.Add(specimenLiver.AsReference());
            diagnosticReport.Specimen.Add(specimenStomachContents.AsReference());

            diagnosticReport.Result.Add(toxLabResultChromatography.AsReference(toxLabResultChromatography.Code.Text));

            output = serializer.SerializeToString(diagnosticReport);
            File.WriteAllText("ToxToCMS_Message.json", output);
            Console.WriteLine(output);

        }
    }
}
