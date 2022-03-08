using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.CbsVaccinationIndicationProfile;
using GaTech.Chai.Cbs.CbsLabTestReportProfile;
using GaTech.Chai.Cbs.CbsPersonReportingToCDCProfile;
using GaTech.Chai.Cbs.CbsSocialDeterminantsOfHealthProfile;
using GaTech.Chai.UsCbs.HospitalizationEncounterProfile;
using GaTech.Chai.Cbs.CbsDocumentBundleProfile;
using GaTech.Chai.Cbs.CbsQuestionnaireProfile;
using GaTech.Chai.Cbs.CbsCompositionProfile;
using Hl7.Fhir.Serialization;
using CbsProfileInitialization;
using System.Collections.Generic;
using System.IO;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.FhirIg.Common;
using GaTech.Chai.UsCbs.PerformingLaboratoryProfile;
using GaTech.Chai.UsCbs.ReportingSourceOrganizationProfile;
using GaTech.Chai.UsCbs.TravelHistoryProfile;
using GaTech.Chai.UsPublicHealth.TravelHistoryProfile;
using GaTech.Chai.UsCbs.Common;
using GaTech.Chai.Cbs.CaseNotificationPanelProfile;

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

            var ageAtInvestigation = CbsAgeAtCaseInvestigation.Create();
            ageAtInvestigation.CbsAgeAtCaseInvestigation().Value = new Quantity(35, "year") { Code = "a" };
            caseNotificationPanel.HasMember.Add(ageAtInvestigation.AsReference());

            var binationalReportingCriteria = CbsBinationalReportingCriteria.Create();
            binationalReportingCriteria.CbsBinationalReportingCriteria().Value = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC1140", "Exposure to suspected product from Canada or Mexico", null);
            caseNotificationPanel.HasMember.Add(binationalReportingCriteria.AsReference());

            var investigationStartDate = CbsCaseInvestigationStartDate.Create();
            investigationStartDate.CbsCaseInvestigationStartDate().Value = new FhirDateTime("2022-01-30");
            caseNotificationPanel.HasMember.Add(investigationStartDate.AsReference());

            var caseOutbreak = CbsCaseOutbreak.Create();
            caseOutbreak.CbsCaseOutbreak().AddOutbreakName = "HANSENOUTB1";
            caseOutbreak.CbsCaseOutbreak().AddOutbreakIndicator = YesNoUnknown.Yes;
            caseNotificationPanel.HasMember.Add(caseOutbreak.AsReference());

            string output = serializer.SerializeToString(caseNotificationPanel);
            //File.WriteAllText("GenV2.json", output);
            Console.WriteLine(output);

            output = serializer.SerializeToString(caseOutbreak);
            Console.WriteLine(output);

            /////////////////////////////////////////////////////////////////////////////
            // CbsVaccinationRecordProfile
            var measlesVaccine = VaccineRecord.RecordFromBirthCertificate(patient, "05", "measles", new PositiveInt(1), new FhirDateTime("1965-07-02"));

            // Cause of Death Observation
            var causeOfDeathObservation = CauseOfDeathObservation.Create(patient, HemolyticUremicSyndromeCondition);

            // Person reporting to CDC
            var personReporting = PersonReporting.Create("Smith", "Sandra");
            personReporting.Telecom.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Email, Value = "ssmith@gmail.com" });
            personReporting.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, null, "444-321-1234"));


            // Case Notification Panel Members
            List<ResourceReference> listCPNMembers = new List<ResourceReference>();

            var mmwrHUS = MMWR.Create(patient, HemolyticUremicSyndromeCondition, 9, 2014);
            listCPNMembers.Add(mmwrHUS.AsReference());

            var exposureObservation = ExposureObservation.Create(patient, HemolyticUremicSyndromeCondition, new CodeableConcept("urn:iso:std:iso:3166", "USA", "United States of America"), new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas"), "Houston", "Harris");
            listCPNMembers.Add(exposureObservation.AsReference());

            //var immediateNationalNotifiableCondition = CbsCaseNotificationPanel.CreateMember();
            //immediateNationalNotifiableCondition.Subject = patient.AsReference();
            //immediateNationalNotifiableCondition.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.ImmediateNationalNotifiableCondition;
            //immediateNationalNotifiableCondition.Value = YesNoUnknown.No;
            //listCPNMembers.Add(immediateNationalNotifiableCondition.AsReference());

            //var reportingState = CbsCaseNotificationPanel.CreateMember();
            //reportingState.Subject = patient.AsReference();
            //reportingState.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.ReportingState;
            //reportingState.Value = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas");
            //listCPNMembers.Add(reportingState.AsReference());

            //var reportingCounty = CbsCaseNotificationPanel.CreateMember();
            //reportingCounty.Subject = patient.AsReference();
            //reportingCounty.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.ReportingCounty;
            //reportingCounty.Value = new CodeableConcept("urn:oid:2.16.840.1.113883.6.93", "48201", "Harris");
            //listCPNMembers.Add(reportingCounty.AsReference());

            //var nationalReportingJurisdiction = CbsCaseNotificationPanel.CreateMember();
            //nationalReportingJurisdiction.Subject = patient.AsReference();
            //nationalReportingJurisdiction.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.NationalReportingJurisdiction;
            //nationalReportingJurisdiction.Value = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas");
            //listCPNMembers.Add(nationalReportingJurisdiction.AsReference());

            //var jurisdictionCode = CbsCaseNotificationPanel.CreateMember();
            //jurisdictionCode.Subject = patient.AsReference();
            //jurisdictionCode.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.JurisdictionCode;
            //jurisdictionCode.Value = new FhirString("S01");
            //listCPNMembers.Add(jurisdictionCode.AsReference());

            //var dateOfInitialReport = CbsCaseNotificationPanel.CreateMember();
            //dateOfInitialReport.Subject = patient.AsReference();
            //dateOfInitialReport.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.DateOfInitialReport;
            //dateOfInitialReport.Value = new FhirDateTime("2014-02-25");
            //listCPNMembers.Add(dateOfInitialReport.AsReference());

            //var earliestDateReportedToCounty = CbsCaseNotificationPanel.CreateMember();
            //earliestDateReportedToCounty.Subject = patient.AsReference();
            //earliestDateReportedToCounty.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.EarliestDateReportedtoCounty;
            //earliestDateReportedToCounty.Value = new FhirDateTime("2014-02-25");
            //listCPNMembers.Add(earliestDateReportedToCounty.AsReference());

            //var earliestDateReportedToState = CbsCaseNotificationPanel.CreateMember();
            //earliestDateReportedToState.Subject = patient.AsReference();
            //earliestDateReportedToState.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.EarliestDateReportedtoState;
            //earliestDateReportedToState.Value = new FhirDateTime("2014-02-25");
            //listCPNMembers.Add(earliestDateReportedToState.AsReference());

            //var caseInvestigationStartDate = CbsCaseNotificationPanel.CreateMember();
            //caseInvestigationStartDate.Subject = patient.AsReference();
            //caseInvestigationStartDate.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.CaseInvestigationStartDate;
            //caseInvestigationStartDate.Value = new FhirDateTime("2014-02-25");
            //listCPNMembers.Add(caseInvestigationStartDate.AsReference());

            //var caseOutbreakNameAndIndicator = CbsCaseNotificationPanel.CreateMember();
            //caseOutbreakNameAndIndicator.Subject = patient.AsReference();
            //caseOutbreakNameAndIndicator.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.CaseOutbreakIndicator;
            //caseOutbreakNameAndIndicator.Component.Add(new Observation.ComponentComponent() { Code=CbsCaseNotificationPanel.CaseNotificationPanelValues.CaseAssociatedWithKnownOutbreak, Value=YesNoUnknown.Yes });
            //caseOutbreakNameAndIndicator.Component.Add(new Observation.ComponentComponent() { Code=CbsCaseNotificationPanel.CaseNotificationPanelValues.CaseOutbreakName, Value=new FhirString("HANSENOUTB1") });
            //listCPNMembers.Add(caseOutbreakNameAndIndicator.AsReference());

            //var binationalReportingCriteria = CbsCaseNotificationPanel.CreateMember();
            //binationalReportingCriteria.Subject = patient.AsReference();
            //binationalReportingCriteria.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.BinationalReportingCriteria;
            //binationalReportingCriteria.Value = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.274", "PHC1140", "Exposure to suspected product from Canada or Mexico", null);
            //listCPNMembers.Add(binationalReportingCriteria.AsReference());

            //var diseaseTransmissionMode = CbsCaseNotificationPanel.CreateMember();
            //diseaseTransmissionMode.Subject = patient.AsReference();
            //diseaseTransmissionMode.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.DiseaseTransmissionMode;
            //diseaseTransmissionMode.Value = new CodeableConcept("http://snomed.info/sct", "416086007", "Food-borne transmission", null);
            //listCPNMembers.Add(diseaseTransmissionMode.AsReference());

            //var dateOfFirstReportToPublicHealthDepartment = CbsCaseNotificationPanel.CreateMember();
            //dateOfFirstReportToPublicHealthDepartment.Subject = patient.AsReference();
            //dateOfFirstReportToPublicHealthDepartment.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.DateReported;
            //dateOfFirstReportToPublicHealthDepartment.Value = new FhirDateTime("2014-02-25");
            //listCPNMembers.Add(dateOfFirstReportToPublicHealthDepartment.AsReference());

            //var pregnancyStatusAtTimeOfIllnessOrCondition = CbsCaseNotificationPanel.CreateMember();
            //pregnancyStatusAtTimeOfIllnessOrCondition.Subject = patient.AsReference();
            //pregnancyStatusAtTimeOfIllnessOrCondition.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.PregnancyStatus;
            //pregnancyStatusAtTimeOfIllnessOrCondition.Value = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0532", "N", "No", null);
            //listCPNMembers.Add(pregnancyStatusAtTimeOfIllnessOrCondition.AsReference());

            //var ageAtTimeOfCaseInvestigation = CbsCaseNotificationPanel.CreateMember();
            //ageAtTimeOfCaseInvestigation.Subject = patient.AsReference();
            //ageAtTimeOfCaseInvestigation.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.AgeatCaseInvestigation;
            //ageAtTimeOfCaseInvestigation.Value = new Integer(49);
            //listCPNMembers.Add(ageAtTimeOfCaseInvestigation.AsReference());

            //caseNotificationPanel.HasMember.Add(mmwrHUS.AsReference());
            //caseNotificationPanel.HasMember.Add(exposureObservation.AsReference());
            //caseNotificationPanel.HasMember.Add(immediateNationalNotifiableCondition.AsReference());
            //caseNotificationPanel.HasMember.Add(reportingState.AsReference());
            //caseNotificationPanel.HasMember.Add(reportingCounty.AsReference());
            //caseNotificationPanel.HasMember.Add(nationalReportingJurisdiction.AsReference());
            //caseNotificationPanel.HasMember.Add(jurisdictionCode.AsReference());
            //caseNotificationPanel.HasMember.Add(dateOfInitialReport.AsReference());
            //caseNotificationPanel.HasMember.Add(earliestDateReportedToCounty.AsReference());
            //caseNotificationPanel.HasMember.Add(earliestDateReportedToState.AsReference());
            //caseNotificationPanel.HasMember.Add(caseInvestigationStartDate.AsReference());
            //caseNotificationPanel.HasMember.Add(caseOutbreakNameAndIndicator.AsReference());
            //caseNotificationPanel.HasMember.Add(binationalReportingCriteria.AsReference());
            //caseNotificationPanel.HasMember.Add(diseaseTransmissionMode.AsReference());
            //caseNotificationPanel.HasMember.Add(dateOfFirstReportToPublicHealthDepartment.AsReference());
            //caseNotificationPanel.HasMember.Add(pregnancyStatusAtTimeOfIllnessOrCondition.AsReference());
            //caseNotificationPanel.HasMember.Add(ageAtTimeOfCaseInvestigation.AsReference());

            // Create composition for the resources created above.
            Composition composition = CbsComposition.Create();
            composition.Subject = patient.AsReference();
            composition.Date = "2014-03-02";
            composition.Author.Add(reportingSource.AsReference());
            composition.Title = "Case Based Surveillance Composition";
            composition.CbsComposition().ConditionOfInterest.Entry.Add(HemolyticUremicSyndromeCondition.AsReference());
            composition.CbsComposition().Encounters.Entry.Add(hospitalizationEncounter.AsReference());
            composition.CbsComposition().CaseNotification.Entry.Add(caseNotificationPanel.AsReference());

            // GenV2 Document
            Bundle document = CbsDocumentBundle.Create();
            document.Entry.Add(new Bundle.EntryComponent() { Resource = composition });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = patient });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = HemolyticUremicSyndromeCondition });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = measlesVaccine });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = hospitalizationEncounter });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = causeOfDeathObservation });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = personReporting });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = reportingSource });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = caseNotificationPanel });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = mmwrHUS });
            document.Entry.Add(new Bundle.EntryComponent() { Resource = exposureObservation });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = immediateNationalNotifiableCondition });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = reportingState });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = reportingCounty });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = nationalReportingJurisdiction });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = jurisdictionCode });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = dateOfInitialReport });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = earliestDateReportedToCounty });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = earliestDateReportedToState });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = caseInvestigationStartDate });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = caseOutbreakNameAndIndicator });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = binationalReportingCriteria });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = diseaseTransmissionMode });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = dateOfFirstReportToPublicHealthDepartment });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = pregnancyStatusAtTimeOfIllnessOrCondition });
            //document.Entry.Add(new Bundle.EntryComponent() { Resource = ageAtTimeOfCaseInvestigation });

            // Print out the result
            //string output = serializer.SerializeToString(document);
            //File.WriteAllText("GenV2.json", output);
            //Console.WriteLine(output);

            /*
             * HAI-CA Test Case 2: Candida auris, Clinical
             * 
             */
            Condition candidaAurisCondition = ConditionOfInterest.Create(patient, "50263", "Candida auris, clinical", null, new FhirDateTime("2018-11-22"));
            var hAICaHospitalizationEncounter = HospitalizationEncounter.Create(patient, candidaAurisCondition, new List<CodeableConcept> { new CodeableConcept("http://www.ama-assn.org/go/cpt", "42628595", "Inpatient Hospital", null) }, new Period(new FhirDateTime(2018, 11, 24), null));

            // CbsSpecimenProfile
            Specimen specimen = MySpecimen.Create(patient);

            // CbsVaccinationIndicationProfile
            var vaccinationIndication = CbsVaccinationIndication.Create();
            vaccinationIndication.Status = ObservationStatus.Final;
            vaccinationIndication.Subject = patient.AsReference();
            vaccinationIndication.Value = YesNoUnknown.Yes;

            // CbsLabTestReportProfile
            var labTestReport = CbsLabTestReport.Create();
            labTestReport.Status = DiagnosticReport.DiagnosticReportStatus.Final;
            labTestReport.Code = new CodeableConcept("http://loinc.org", "85069-3");
            labTestReport.Subject = patient.AsReference();

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
