using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using GaTech.Chai.Cbs.Common;
using GaTech.Chai.Cbs.Extensions;
using GaTech.Chai.Cbs.CbsCauseOfDeathProfile;
using GaTech.Chai.Cbs.CbsLabObservationProfile;
using GaTech.Chai.Cbs.CbsPatientProfile;
using GaTech.Chai.Cbs.CbsConditionProfile;
using GaTech.Chai.Cbs.CbsTravelHistoryProfile;
using GaTech.Chai.Cbs.CbsVaccinationIndicationProfile;
using GaTech.Chai.Cbs.CbsVaccinationRecordProfile;
using GaTech.Chai.Cbs.CbsLabTestReportProfile;
using GaTech.Chai.Cbs.CbsPerformingLaboratoryProfile;
using GaTech.Chai.Cbs.CbsPersonReportingToCDCProfile;
using GaTech.Chai.Cbs.CbsReportingSourceOrganizationProfile;
using GaTech.Chai.Cbs.CbsSocialDeterminantsOfHealthProfile;
using GaTech.Chai.Cbs.CbsCaseNotificationPanelProfile;
using GaTech.Chai.Cbs.CbsHospitalizationEncounterProfile;
using GaTech.Chai.Cbs.CbsSpecimenProfile;
using GaTech.Chai.Cbs.CbsDocumentBundleProfile;
using GaTech.Chai.Cbs.CbsQuestionnaireProfile;

namespace CbsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // CbsPatientProfile
            Patient patient = CbsPatient.Create();
            patient.CbsPatient().Race.Category = CbsPatientRace.RaceCategory.Encode("2106-3", "White");
            patient.CbsPatient().Race.Description = "Mixed";
            patient.CbsPatient().Race.ExtendedRaceCodes = new Coding[] { CbsPatientRace.DetailedRace.Encode("1010-8", "Apache") };
            patient.CbsPatient().Race.Other = "Apache";
            patient.CbsPatient().BirthSex = CbsPatient.Sex.Female;
            patient.CbsPatient().BirthPlace = new Address() { City = "Austin", State = "TX" };
            var address = new Address() { City = "Dallas", State = "TX" };
            address.CbsAddress().CdcAddressUse = CbsAddress.AddressUse.UsualResidence;
            address.CbsAddress().CensusTract = "030500";
            patient.Address.Add(address);
            patient.Telecom.Add(new ContactPoint(ContactPoint.ContactPointSystem.Phone, 
                ContactPoint.ContactPointUse.Home, "867-5309"));

            // CbsLabObservationProfile
            Observation labObs = CbsLabObservation.Create();
            labObs.Subject = patient.AsReference();
            labObs.Code = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.232", "LAB723", "DNA Sequencing", null);
            labObs.Value = new CodeableConcept("http://snomed.info/sct", "10828004", "Positive", null);
            labObs.Method = new CodeableConcept(null, "D1D2", "D1/D2", null);

            // CbsConditionProfile
            Condition condition = CbsCondition.Create();
            condition.Subject = patient.AsReference();
            condition.CbsCondition().ClassificationStatus = CbsCondition.CaseClassificationStatus.ConfirmedPresent;
            condition.CbsCondition().DiagnosisDate = new FhirDateTime("2021-03-01");
            condition.CbsCondition().IllnesDuration = new Quantity(6, "d");
            condition.Code = CbsCondition.ConditionCode.Encode("11550", "Hemolytic Uremic Syndrome");
            condition.Onset = new FhirDateTime("2021-02-28");
            condition.ClinicalStatus = new CodeableConcept("http://terminology.hl7.org/CodeSystem/condition-clinical", "inactive");

            // CbsCaseOfDeathProfile
            Observation caseOfDeathObs = CbsCauseOfDeath.Create();
            caseOfDeathObs.Subject = patient.AsReference();
            caseOfDeathObs.Focus.Add(condition.AsReference());

            // CbsTravelHistoryProfile
            var travelHistory = CbsTravelHistory.Create();
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeTo =
                TimeWindowRelativeToValue.ConditionOnsetDatePeriodStart;
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.TimeWindow = new Quantity(1, "day");
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeReference = patient.AsReference();
            travelHistory.CbsTravelHistory().TravelHistoryAddress.Address = new Address() { City = "Dallas", State = "TX" };
            travelHistory.CbsTravelHistory().TravelHistoryAddress.Location = CbsTravelHistory.GeographicalLocation.Encode("48", "Texas");
            travelHistory.CbsTravelHistory().TravelHistoryAddress.TimeSpent = FhirDateTime.Now();

            // CbsVaccinationRecordProfile
            var vaccinationRecord = CbsVaccinationRecord.Create();
            vaccinationRecord.ReportOrigin = CbsVaccinationRecord.VaccineEventInformationSource.FromBirthCertificate;
            vaccinationRecord.ProtocolApplied.Add(new Immunization.ProtocolAppliedComponent() { DoseNumber = new Integer(1) });
            vaccinationRecord.Occurrence = FhirDateTime.Now();
            vaccinationRecord.VaccineCode = CbsVaccinationRecord.VaccineAdministered.Encode("05", "measles");
            vaccinationRecord.Patient = patient.AsReference();

            // CbsVaccinationIndicationProfile
            var vaccinationIndication = CbsVaccinationIndication.Create();
            vaccinationIndication.Subject = patient.AsReference();
            vaccinationIndication.Value = YesNoUnknown.Yes;

            // CbsLabTestReportProfile
            var labTestReport = CbsLabTestReport.Create();
            labTestReport.Code = new CodeableConcept("http://loinc.org", "85069-3");
            labTestReport.Subject = patient.AsReference();

            // CbsPerformingLaboratoryProfile
            var performingLab = CbsPerformingLaboratory.Create();
            performingLab.Name = "Jab Lab, Dallas";

            // CbsPersonReportingToCDCProfile
            var reporter = CbsPersonReportingToCDC.Create();
            reporter.Name.Add(new HumanName() { Family = "Smith", Given = new[] { "Sandra" } });
            reporter.Telecom.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Email, Value = "ssmith@gmail.com" });

            // CbsReportingSourceOrganizationProfile
            var org = CbsReportingSourceOrganization.Create("PHC247", "Laboratory");
            org.Name = "Jab Labs, Inc.";

            // CbsSocialDeterminantsOfHealthProfile
            var socialDeterminant = CbsSocialDeterminantsOfHealth.Create();
            socialDeterminant.Status = ObservationStatus.Final;
            socialDeterminant.Category.Add(CbsSocialDeterminantsOfHealth.Categories.HousingOrResidence);
            socialDeterminant.Code = CbsSocialDeterminantsOfHealth.Codes.CharacteristicsOfResidence;
            socialDeterminant.CbsSocialDeterminantsOfHealth().ProgramSpecificTimeWindow.RelativeTo =
                    TimeWindowRelativeToValue.ConditionOnsetDateTime;
            socialDeterminant.CbsSocialDeterminantsOfHealth().ProgramSpecificTimeWindow.TimeWindow = new Quantity(1, "year");
            socialDeterminant.CbsSocialDeterminantsOfHealth().ProgramSpecificTimeWindow.RelativeReference = patient.AsReference();

            // CbsCaseNotificationPanel
            var notificationPanel = CbsCaseNotificationPanel.Create();
            notificationPanel.Code = CbsCaseNotificationPanel.CaseNotificationPanelValues.Hospitalized;
            notificationPanel.Subject = patient.AsReference();
            notificationPanel.Value = YesNoUnknown.Yes;

            // CbsExposureObservationProfile
            var exposure = CbsExposureObservation.Create();
            exposure.CbsExposureObservation().CountryOfExposure = new CodeableConcept("urn:iso:std:iso:3166", "USA", "United States of America");
            exposure.CbsExposureObservation().StateOrProvinceOfExposure = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas");
            exposure.CbsExposureObservation().CityOfExposure = "Houston";
            exposure.CbsExposureObservation().CountyOfExposure = "Harris";
            exposure.Subject = patient.AsReference();
            exposure.Focus.Add(condition.AsReference());

            // CbsMmwrProfile
            var mmwr = CbsMmwr.Create();
            mmwr.Subject = patient.AsReference();
            mmwr.CbsMmwr().MMWRWeek = 12;
            mmwr.CbsMmwr().MMWRYear = 2021;

            // CbsHospitalizationEncounterProfile
            var hospitalization = CbsHospitalization.Create();
            hospitalization.Subject = patient.AsReference();
            hospitalization.CbsHospitalization().Condition = condition.AsReference();

            // CbsSpecimenProfile
            var specimen = CbsSpecimen.Create();
            specimen.CbsSpecimen().SpecimenRole = CbsSpecimen.Roles.BlindSample;
            specimen.CbsSpecimen().FillerAssignedId = new Identifier() { Value = "IDR908765140" };
            specimen.CbsSpecimen().PlacerAssignedId = new Identifier() { Value = "198374-9" };
            specimen.Type = CbsSpecimen.Types.Encode("258497007", "Abscess swab (specimen)");
            specimen.Subject = patient.AsReference();
            specimen.Collection = new Specimen.CollectionComponent()
            {
                Collected = FhirDateTime.Now(),
                Quantity = new Quantity(1, "ml"),
                BodySite = CbsSpecimen.BodySites.Encode("64700008", "7 nm filaments(cell structure)")
            };

            // CbsDocumentBundle
            var documents = CbsDocumentBundle.Create();
            var doc = new Bundle.EntryComponent()
            {
                FullUrl = "http://fhir.healthintersections.com.au/open/Composition/180f219f-97a8-486d-99d9-ed631fe4fc57"
            };
            documents.Entry.Add(doc);

            // CbsQuestionnaireProfile
            var questionnaire = CbsQuestionnaire.Create();
            var item = new Questionnaire.ItemComponent()
            {
                LinkId = "1",
                Text = "Do you have allergies?",
                Type = Questionnaire.QuestionnaireItemType.Boolean
            };
            questionnaire.Item.Add(item);

            // Serialize each object to display results
            FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });
            Console.WriteLine("CbsPatient:");
            Console.WriteLine(serializer.SerializeToString(patient));
            Console.WriteLine("CbsLabObservation:");
            Console.WriteLine(serializer.SerializeToString(labObs));
            Console.WriteLine("CbsCaseOfDeath:");
            Console.WriteLine(serializer.SerializeToString(caseOfDeathObs));
            Console.WriteLine("CbsCondition:");
            Console.WriteLine(serializer.SerializeToString(condition));
            Console.WriteLine("CbsTravelHistory:");
            Console.WriteLine(serializer.SerializeToString(travelHistory));
            Console.WriteLine("CbsVaccinationRecord:");
            Console.WriteLine(serializer.SerializeToString(vaccinationRecord));
            Console.WriteLine("CbsVaccinationIndication:");
            Console.WriteLine(serializer.SerializeToString(vaccinationIndication));
            Console.WriteLine("CbsLabTestReport:");
            Console.WriteLine(serializer.SerializeToString(labTestReport));
            Console.WriteLine("CbsPerformingLaboratory:");
            Console.WriteLine(serializer.SerializeToString(performingLab));
            Console.WriteLine("CbsPersonReportingToCDC:");
            Console.WriteLine(serializer.SerializeToString(reporter));
            Console.WriteLine("CbsReportingSourceOrganization:");
            Console.WriteLine(serializer.SerializeToString(org));
            Console.WriteLine("CbsSocialDeterminantsOfHealth:");
            Console.WriteLine(serializer.SerializeToString(socialDeterminant));

            Console.WriteLine("CbsCaseNotificationPanel:");
            Console.WriteLine(serializer.SerializeToString(notificationPanel));
            Console.WriteLine("CbsExposureObservation:");
            Console.WriteLine(serializer.SerializeToString(exposure));
            Console.WriteLine("CbsMmwr:");
            Console.WriteLine(serializer.SerializeToString(mmwr));
            Console.WriteLine("CbsHospitalization:");
            Console.WriteLine(serializer.SerializeToString(hospitalization));
            Console.WriteLine("CbsSpecimen:");
            Console.WriteLine(serializer.SerializeToString(specimen));

            Console.WriteLine("CbsDocumentBundle:");
            Console.WriteLine(serializer.SerializeToString(documents));
            Console.WriteLine("CbsQuestionnaireProfile:");
            Console.WriteLine(serializer.SerializeToString(questionnaire));

        }
    }
}
