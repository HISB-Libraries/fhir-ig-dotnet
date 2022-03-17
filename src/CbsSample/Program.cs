using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.SocialDeterminantsOfHealthProfile;
using GaTech.Chai.Cbs.DocumentBundleProfile;
using GaTech.Chai.Cbs.QuestionnaireProfile;
using GaTech.Chai.Cbs.CompositionProfile;
using Hl7.Fhir.Serialization;
using CbsProfileInitialization;
using System.Collections.Generic;
using System.IO;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.FhirIg.Common;
using GaTech.Chai.UsCbs.PerformingLaboratoryProfile;
using GaTech.Chai.UsCbs.TravelHistoryProfile;
using GaTech.Chai.UsPublicHealth.TravelHistoryProfile;
using GaTech.Chai.UsCbs.Common;
using GaTech.Chai.Cbs.CaseNotificationPanelProfile;
using GaTech.Chai.Cbs.VaccinationACIPRecommendationProfile;

namespace CbsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * GenV2 Example - Hemolytic Uremic Syndrome (HUS) case
             * https://cbsig.chai.gatech.edu/examples.html#genv2-test-case-1-hemolytic-uremic-syndrome-hus
             */

            FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });

            // CbsPatientProfile
            Patient patient = CbsGenV2Patient.Create();

            // CbsConditionProfile
            var HemolyticUremicSyndromeCondition = ConditionOfInterest.Create(patient, "11550", "Hemolytic Uremic Syndrome", new Quantity(6, "d"), new FhirDateTime("2021-02-28"));

            // Hospitalization Encounter
            var hospitalizationEncounter = HospitalizationEncounter.Create(patient, HemolyticUremicSyndromeCondition, new List<CodeableConcept> { new CodeableConcept("http://www.ama-assn.org/go/cpt", "42628595", "Inpatient Hospital", null) }, new Period(new FhirDateTime(2014, 2, 26), new FhirDateTime(2014, 3, 2)));

            var measlesImmunization = MeaslesImmunization.Create(patient, new FhirDateTime("2014-02-25"));

            var haicaLobResultObservation = HaicalLabObservation.Create(patient);

            var haicaLabDiagnosticReport = HAICALabDiagnosticReport.Create(patient, haicaLobResultObservation);

            // CbsPerformingLaboratoryProfile
            var performingLab = UsCbsPerformingLaboratory.Create();
            performingLab.UsCbsPerformingLaboratory().SetNameDataAbsentReason(DataAbsentReason.AskedUnknown);

            // Reporting Source
            var reportingSource = ReportingSource.Create(new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0406", "H", "Hospital", null), new Address() { PostalCode = "77018" });

            // CbsTravelHistoryProfile
            var travelHistory = UsCbsTravelHistory.Create();
            travelHistory.Status = ObservationStatus.Final;
            travelHistory.UsCbsTravelHistory().PeriodAndModeOfTravel.DateOrPeriodOfTravel = new Period(new FhirDateTime("2018-11-02"), new FhirDateTime("2018-11-12"));
            travelHistory.UsCbsTravelHistory().PeriodAndModeOfTravel.ModeOfTravel = UsCbsPeriodAndModeOfTravel.TravelMode.Aircraft;
            travelHistory.UsCbsTravelHistory().PeriodAndModeOfTravel.RelevantLocation = new Address[] { new Address { Country = "Mumbai" } };

            travelHistory.UsCbsTravelHistory().ProgramSpecificTimeWindow.RelativeTo = TimeWindowRelativeToValueSet.ConditionOnsetDatePeriodStart;
            travelHistory.UsCbsTravelHistory().ProgramSpecificTimeWindow.TimeWindow = new Quantity(1, "day");
            travelHistory.UsCbsTravelHistory().ProgramSpecificTimeWindow.RelativeReference = patient.AsReference();
            travelHistory.UsPublicHealthTravelHistory().TravelLocation.Address = new Address() { City = "Dallas", State = "TX", Country = "USA" };
            travelHistory.UsPublicHealthTravelHistory().TravelLocation.Location = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas", null);
            travelHistory.UsPublicHealthTravelHistory().TravelLocation.TimeSpent = FhirDateTime.Now();

            travelHistory.UsPublicHealthTravelHistory().TravelPurpose.Purpose = TravelPurpose.PurposeValueSet.Business;

            // Case Notification Panel
            var caseNotificationPanel = CbsCaseNotificationPanel.Create();
            caseNotificationPanel.Subject = patient.AsReference();
            caseNotificationPanel.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.Hospitalized;

            var ageAtInvestigation = CbsAgeAtCaseInvestigation.Create();
            ageAtInvestigation.CbsAgeAtCaseInvestigation().Value = new Quantity(49, "year") { Code = "a" };
            ageAtInvestigation.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(ageAtInvestigation.AsReference());

            var binationalReportingCriteria = CbsBinationalReportingCriteria.Create();
            binationalReportingCriteria.CbsBinationalReportingCriteria().Value = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC1140", "Exposure to suspected product from Canada or Mexico", null);
            binationalReportingCriteria.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(binationalReportingCriteria.AsReference());

            var investigationStartDate = CbsCaseInvestigationStartDate.Create();
            investigationStartDate.CbsCaseInvestigationStartDate().Value = new FhirDateTime("2014-02-25");
            investigationStartDate.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(investigationStartDate.AsReference());

            var caseOutbreak = CbsCaseOutbreak.Create();
            caseOutbreak.CbsCaseOutbreak().OutbreakName = "HANSENOUTB1";
            caseOutbreak.CbsCaseOutbreak().OutbreakIndicator = YesNoUnknown.Yes;
            caseOutbreak.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(caseOutbreak.AsReference());

            var dateOfFirstReportToPublicHealthDept = CbsDateOfFirstReportToPublicHealthDept.Create();
            dateOfFirstReportToPublicHealthDept.CbsDateOfFirstReportToPublicHealthDept().Value = new FhirDateTime("2014-02-25");
            dateOfFirstReportToPublicHealthDept.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(dateOfFirstReportToPublicHealthDept.AsReference());

            var dateOfInitialReport = CbsDateOfInitialReport.Create();
            dateOfInitialReport.CbsDateOfInitialReport().Value = new FhirDateTime("2022-01-30");
            dateOfInitialReport.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(dateOfInitialReport.AsReference());

            var earliestDateReportedToCounty = CbsEarliestDateReportedToCounty.Create();
            earliestDateReportedToCounty.CbsEarliestDateReportedToCounty().Value = new FhirDateTime("2022-01-30");
            earliestDateReportedToCounty.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(earliestDateReportedToCounty.AsReference());

            var earliestDateReportedToState = CbsEarliestDateReportedToState.Create();
            earliestDateReportedToState.CbsEarliestDateReportedToState().Value = new FhirDateTime("2021-01-30");
            earliestDateReportedToState.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(earliestDateReportedToState.AsReference());

            var exposureObservation = CbsExposureObservation.Create();
            exposureObservation.CbsExposureObservation().CountryOfExposure = new CodeableConcept("urn:iso:std:iso:3166", "USA", "United States of America", null);
            exposureObservation.CbsExposureObservation().StateOrProvinceOfExposure = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas", null);
            exposureObservation.CbsExposureObservation().CityOfExposure = "Houston";
            exposureObservation.CbsExposureObservation().CountyOfExposure = "Harris";
            exposureObservation.Subject = patient.AsReference();
            exposureObservation.Focus.Add(HemolyticUremicSyndromeCondition.AsReference());
            caseNotificationPanel.HasMember.Add(exposureObservation.AsReference());

            var immediateNationalNotifiableCondition = CbsImmediateNationalNotifiableCondition.Create();
            immediateNationalNotifiableCondition.CbsImmediateNationalNotifiableCondition().Value = YesNoUnknown.No;
            immediateNationalNotifiableCondition.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(immediateNationalNotifiableCondition.AsReference());

            var jurisdictionCode = CbsJurisdictionCode.Create();
            jurisdictionCode.CbsJurisdictionCode().Value = "S01";
            jurisdictionCode.Subject = patient.AsReference();
            caseNotificationPanel.HasMember.Add(jurisdictionCode.AsReference());

            var mmwrHUS = CbsMmwr.Create();
            mmwrHUS.Subject = patient.AsReference();
            mmwrHUS.CbsMmwr().MMWRWeek = 9;
            mmwrHUS.CbsMmwr().MMWRYear = 2014;
            caseNotificationPanel.HasMember.Add(mmwrHUS.AsReference());

            var nationalReportingJurisdiction = CbsNationalReportingJurisdiction.Create();
            nationalReportingJurisdiction.Subject = patient.AsReference();
            nationalReportingJurisdiction.CbsNationalReportingJurisdiction().Value = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas", null);
            caseNotificationPanel.HasMember.Add(nationalReportingJurisdiction.AsReference());

            var pregnancyStatusAtTimeOfIllnessOrCondition = CbsPregnancyStatus.Create();
            pregnancyStatusAtTimeOfIllnessOrCondition.Subject = patient.AsReference();
            pregnancyStatusAtTimeOfIllnessOrCondition.CbsPregnancyStatus().Value = YesNoUnknown.No;
            caseNotificationPanel.HasMember.Add(pregnancyStatusAtTimeOfIllnessOrCondition.AsReference());

            var reportingCounty = CbsReportingCounty.Create();
            reportingCounty.Subject = patient.AsReference();
            reportingCounty.CbsReportingCounty().Value = new CodeableConcept("urn:oid:2.16.840.1.113883.6.93", "48201", "Harris", null);
            caseNotificationPanel.HasMember.Add(reportingCounty.AsReference());

            var reportingState = CbsReportingState.Create();
            reportingState.Subject = patient.AsReference();
            reportingState.CbsReportingState().Value = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas", null);
            caseNotificationPanel.HasMember.Add(reportingState.AsReference());

            var diseaseTransmissionMode = CbsTransmissionMode.Create();
            diseaseTransmissionMode.Subject = patient.AsReference();
            diseaseTransmissionMode.CbsTransmissionMode().Value = new CodeableConcept("http://snomed.info/sct", "416086007", "Food-borne transmission", null);
            caseNotificationPanel.HasMember.Add(diseaseTransmissionMode.AsReference());


            // Cause of Death Observation
            var causeOfDeath = CauseOfDeathObservation.Create(patient, HemolyticUremicSyndromeCondition);

            // Cause of Death Observation
            var causeOfDeathObservation = CauseOfDeathObservation.Create(patient, HemolyticUremicSyndromeCondition);

            // Person reporting to CDC
            var personReporting = PersonReporting.Create("Smith", "Sandra");
            personReporting.Telecom.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Email, Value = "ssmith@gmail.com" });
            personReporting.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "444-321-1234"));

            // Create composition for the resources created above.
            Composition composition = CbsComposition.Create();
            composition.Subject = patient.AsReference();
            composition.Date = "2014-03-02";
            composition.Author.Add(reportingSource.AsReference());
            composition.Title = "Case Based Surveillance Composition";
            composition.CbsComposition().ConditionOfInterest = new Composition.SectionComponent() { Entry = new List<ResourceReference> { HemolyticUremicSyndromeCondition.AsReference() } };
            composition.CbsComposition().Encounters = new Composition.SectionComponent() { Entry = new List<ResourceReference> { hospitalizationEncounter.AsReference() } };
            composition.CbsComposition().CaseNotification = new Composition.SectionComponent() { Entry = new List<ResourceReference> { caseNotificationPanel.AsReference() } };
            composition.CbsComposition().ReportingEntities = new Composition.SectionComponent() { Entry = new List<ResourceReference> { reportingSource.AsReference() } };

            // GenV2 Document
            Bundle document = CbsDocumentBundle.Create();
            document.Entry.Add(new Bundle.EntryComponent() { Resource = composition });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = patient });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = HemolyticUremicSyndromeCondition });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = hospitalizationEncounter });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = causeOfDeathObservation });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = personReporting });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = reportingSource });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = caseNotificationPanel });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = mmwrHUS });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = exposureObservation });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = immediateNationalNotifiableCondition });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = reportingState });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = reportingCounty });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = nationalReportingJurisdiction });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = jurisdictionCode });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = dateOfInitialReport });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = earliestDateReportedToCounty });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = earliestDateReportedToState });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = investigationStartDate });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = caseOutbreak });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = binationalReportingCriteria });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = diseaseTransmissionMode });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = dateOfFirstReportToPublicHealthDept });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = pregnancyStatusAtTimeOfIllnessOrCondition });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = ageAtInvestigation });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = measlesImmunization });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = haicaLabDiagnosticReport });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = haicaLobResultObservation });
            
            // Print out the result
            string output = serializer.SerializeToString(document);
            File.WriteAllText("GenV2.json", output);
            Console.WriteLine(output);

            /*
             * HAI-CA Test Case 2: Candida auris, Clinical
             * 
             */
            Condition candidaAurisCondition = ConditionOfInterest.Create(patient, "50263", "Candida auris, clinical", null, new FhirDateTime("2018-11-22"));
            var hAICaHospitalizationEncounter = HospitalizationEncounter.Create(patient, candidaAurisCondition, new List<CodeableConcept> { new CodeableConcept("http://www.ama-assn.org/go/cpt", "42628595", "Inpatient Hospital", null) }, new Period(new FhirDateTime(2018, 11, 24), null));

            // CbsSpecimenProfile
            Specimen specimen = MySpecimen.Create(patient);

            // CbsVaccinationACIPRecommendation
            var vaccinationACIrecom = CbsVaccinationACIPRecommendation.Create();
            vaccinationACIrecom.Subject = patient.AsReference();
            vaccinationACIrecom.Value = YesNoUnknown.Yes;

            // CbsCaseNotificationPanel
            var notificationPanel = CbsCaseNotificationPanel.Create();
            notificationPanel.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.Hospitalized;
            notificationPanel.Subject = patient.AsReference();
            notificationPanel.Value = YesNoUnknown.Yes;


            ///////////////////////////////////////////

            // CbsSocialDeterminantsOfHealthProfile
            var socialDeterminant = CbsSocialDeterminantsOfHealth.Create();
            socialDeterminant.Status = ObservationStatus.Final;
            socialDeterminant.Subject = patient.AsReference();
            socialDeterminant.Category.Add(CbsSocialDeterminantsOfHealth.Categories.HousingOrResidence);
            socialDeterminant.Code = CbsSocialDeterminantsOfHealth.Codes.CharacteristicsOfResidence;
            socialDeterminant.CbsSocialDeterminantsOfHealth().ProgramSpecificTimeWindow.RelativeTo =
                    TimeWindowRelativeToValueSet.ConditionOnsetDateTime;
            socialDeterminant.CbsSocialDeterminantsOfHealth().ProgramSpecificTimeWindow.TimeWindow = new Quantity(1, "year");
            socialDeterminant.CbsSocialDeterminantsOfHealth().ProgramSpecificTimeWindow.RelativeReference = patient.AsReference();

            // CbsQuestionnaireProfile
            var questionnaire = CbsQuestionnaire.Create();
            questionnaire.Name = "Onboarding";
            questionnaire.Status = PublicationStatus.Active;
            questionnaire.Publisher = "Acme, Inc.";
            questionnaire.Version = "1.0";
            var item = new Questionnaire.ItemComponent()
            {
                LinkId = "1",
                Text = "Do you have allergies?",
                Type = Questionnaire.QuestionnaireItemType.Boolean
            };
            questionnaire.Item.Add(item);

            ///////////////////////////////////////////

            // CbsCompositionProfile
            //var composition = CbsComposition.Create();
            //composition.Subject = patient.AsReference();
            //composition.Date = DateTime.Now.ToString("yyyy-MM-dd");
            //composition.Author.Add(org.AsReference());
            //composition.CbsComposition().LabRelated.Entry.Add(labObs.AsReference());
            //composition.CbsComposition().LabRelated.Entry.Add(specimen.AsReference());
            //composition.CbsComposition().LabRelated.Entry.Add(labTestReport.AsReference());
            //composition.CbsComposition().LabRelated.Entry.Add(performingLab.AsReference());
            //composition.CbsComposition().Vaccination.Entry.Add(vaccinationRecord.AsReference());
            //composition.CbsComposition().TravelHistory.Entry.Add(travelHistory.AsReference());
            //composition.CbsComposition().ReportingEntities.Entry.Add(reporter.AsReference());
            //composition.CbsComposition().Sdoh.Entry.Add(socialDeterminant.AsReference());
            //composition.CbsComposition().VitalRecords.Entry.Add(caseOfDeathObs.AsReference());
            //composition.CbsComposition().RelatedPerson.Entry.Add(reporter.AsReference());
            //composition.CbsComposition().ConditionOfInterest.Entry.Add(condition.AsReference());
            //composition.CbsComposition().CaseNotification.Entry.Add(notificationPanel.AsReference());

            //Console.WriteLine(serializer.SerializeToString(composition));

            // CbsDocumentBundleProfile
            var documents = CbsDocumentBundle.Create();
            var doc = new Bundle.EntryComponent();
            documents.Timestamp = DateTimeOffset.Now;
            documents.Identifier = new Identifier() { System = "my-fhir-document-id", Value = "123" };
            documents.Entry.Add(doc);
            doc.Resource = composition;
         

            ///////////////////////////////////////////

            //ValidatorHelper.ValidateResources(new Resource[] { patient, labObs,
            //    caseOfDeathObs, condition, travelHistory, vaccinationRecord,
            //    vaccinationIndication, labTestReport, performingLab,
            //    reporter, org, socialDeterminant, notificationPanel,
            //    exposure, mmwr, hospitalization, specimen, documents,
            //    questionnaire, composition });
        }
    }
}
