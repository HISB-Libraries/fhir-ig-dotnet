using System;
using Hl7.Fhir.Model;
using GaTech.Chai.Cbs.Common;
using GaTech.Chai.Cbs.Extensions;
using GaTech.Chai.Cbs.CbsCauseOfDeathProfile;
using GaTech.Chai.Cbs.CbsLabObservationProfile;
using GaTech.Chai.Cbs.CbsTravelHistoryProfile;
using GaTech.Chai.Cbs.CbsVaccinationIndicationProfile;
using GaTech.Chai.Cbs.CbsLabTestReportProfile;
using GaTech.Chai.Cbs.CbsPerformingLaboratoryProfile;
using GaTech.Chai.Cbs.CbsPersonReportingToCDCProfile;
using GaTech.Chai.Cbs.CbsReportingSourceOrganizationProfile;
using GaTech.Chai.Cbs.CbsSocialDeterminantsOfHealthProfile;
using GaTech.Chai.Cbs.CbsCaseNotificationPanelProfile;
using GaTech.Chai.Cbs.CbsHospitalizationEncounterProfile;
using GaTech.Chai.Cbs.CbsDocumentBundleProfile;
using GaTech.Chai.Cbs.CbsQuestionnaireProfile;
using GaTech.Chai.Cbs.CbsCompositionProfile;

namespace CbsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // CbsPatientProfile
            Patient patient = SamplePatient.Create();
            // CbsConditionProfile
            // CbsExposureObservationProfile
            (Condition condition, Observation exposure) = SamplePatient.HemolyticUremicSyndrome(patient);
            // CbsSpecimenProfile
            Specimen specimen = SamplePatient.SampleSpecimen(patient);
            // CbsVaccinationRecordProfile
            var vaccinationRecord = SamplePatient.MeaslesVaccine(patient);


            // CbsLabObservationProfile
            Observation labObs = CbsLabObservation.Create();
            labObs.Subject = patient.AsReference();
            labObs.Code = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.232", "LAB723", "DNA Sequencing", null);
            labObs.Value = new CodeableConcept("http://snomed.info/sct", "10828004", "Positive", null);
            labObs.Method = new CodeableConcept(null, "D1D2", "D1/D2", null);

            // CbsCauseOfDeathProfile
            Observation caseOfDeathObs = CbsCauseOfDeath.Create();
            caseOfDeathObs.Subject = patient.AsReference();
            caseOfDeathObs.Focus.Add(condition.AsReference());

            // CbsTravelHistoryProfile
            var travelHistory = CbsTravelHistory.Create();
            travelHistory.Status = ObservationStatus.Final;
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeTo =
                TimeWindowRelativeToValue.ConditionOnsetDatePeriodStart;
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.TimeWindow = new Quantity(1, "day");
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeReference = patient.AsReference();
            travelHistory.CbsTravelHistory().TravelHistoryAddress.Address = new Address() { City = "Dallas", State = "TX", Country = "USA" };
            travelHistory.CbsTravelHistory().TravelHistoryAddress.Location = CbsTravelHistory.GeographicalLocation.Encode("48", "Texas");
            travelHistory.CbsTravelHistory().TravelHistoryAddress.TimeSpent = FhirDateTime.Now();

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

            // CbsMmwrProfile
            var mmwr = CbsMmwr.Create();
            mmwr.Subject = patient.AsReference();
            mmwr.CbsMmwr().MMWRWeek = 12;
            mmwr.CbsMmwr().MMWRYear = 2021;

            // CbsHospitalizationEncounterProfile
            var hospitalization = CbsHospitalization.Create();
            hospitalization.Subject = patient.AsReference();
            hospitalization.CbsHospitalization().Condition = condition.AsReference();

            ///////////////////////////////////////////

            // CbsPerformingLaboratoryProfile
            var performingLab = CbsPerformingLaboratory.Create();
            performingLab.Name = "Jab Lab, Dallas";

            // CbsPersonReportingToCDCProfile
            var reporter = CbsPersonReportingToCDC.Create();
            reporter.Name.Add(new HumanName() { Family = "Smith", Given = new[] { "Sandra" } });
            reporter.Telecom.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Email, Value = "ssmith@gmail.com" });

            // CbsReportingSourceOrganizationProfile
            var org = CbsReportingSourceOrganization.Create("PHC247", "Laboratory");

            // CbsSocialDeterminantsOfHealthProfile
            var socialDeterminant = CbsSocialDeterminantsOfHealth.Create();
            socialDeterminant.Status = ObservationStatus.Final;
            socialDeterminant.Subject = patient.AsReference();
            socialDeterminant.Category.Add(CbsSocialDeterminantsOfHealth.Categories.HousingOrResidence);
            socialDeterminant.Code = CbsSocialDeterminantsOfHealth.Codes.CharacteristicsOfResidence;
            socialDeterminant.CbsSocialDeterminantsOfHealth().ProgramSpecificTimeWindow.RelativeTo =
                    TimeWindowRelativeToValue.ConditionOnsetDateTime;
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
            var composition = CbsComposition.Create();
            composition.Subject = patient.AsReference();
            composition.Date = DateTime.Now.ToString("yyyy-MM-dd");
            composition.Author.Add(org.AsReference());
            composition.CbsComposition().LabRelated.Entry.Add(labObs.AsReference());
            composition.CbsComposition().LabRelated.Entry.Add(specimen.AsReference());
            composition.CbsComposition().LabRelated.Entry.Add(labTestReport.AsReference());
            composition.CbsComposition().LabRelated.Entry.Add(performingLab.AsReference());
            composition.CbsComposition().Vaccination.Entry.Add(vaccinationRecord.AsReference());
            composition.CbsComposition().TravelHistory.Entry.Add(travelHistory.AsReference());
            composition.CbsComposition().ReportingEntities.Entry.Add(reporter.AsReference());
            composition.CbsComposition().Sdoh.Entry.Add(socialDeterminant.AsReference());
            composition.CbsComposition().VitalRecords.Entry.Add(caseOfDeathObs.AsReference());
            composition.CbsComposition().RelatedPerson.Entry.Add(reporter.AsReference());
            composition.CbsComposition().ConditionOfInterest.Entry.Add(condition.AsReference());
            composition.CbsComposition().CaseNotification.Entry.Add(notificationPanel.AsReference());

            // CbsDocumentBundleProfile
            var documents = CbsDocumentBundle.Create();
            var doc = new Bundle.EntryComponent();
            documents.Timestamp = DateTimeOffset.Now;
            documents.Identifier = new Identifier() { System = "my-fhir-document-id", Value = "123" };
            documents.Entry.Add(doc);
            doc.Resource = composition;
         

            ///////////////////////////////////////////

            ValidatorHelper.ValidateResources(new Resource[] { patient, labObs,
                caseOfDeathObs, condition, travelHistory, vaccinationRecord,
                vaccinationIndication, labTestReport, performingLab,
                reporter, org, socialDeterminant, notificationPanel,
                exposure, mmwr, hospitalization, specimen, documents,
                questionnaire, composition });
        }

    }
}
