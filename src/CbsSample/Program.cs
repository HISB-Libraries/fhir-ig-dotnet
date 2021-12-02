using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
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
            labObs.Subject = patient.CbsPatient().AsReference();
            labObs.Code = new CodeableConcept("urn:oid:2.16.840.1.114222.4.5.232", "LAB723", "DNA Sequencing", null);
            labObs.Value = new CodeableConcept("http://snomed.info/sct", "10828004", "Positive", null);
            labObs.Method = new CodeableConcept(null, "D1D2", "D1/D2", null);

            // CbsConditionProfile
            Condition condition = CbsCondition.Create();
            condition.Subject = patient.CbsPatient().AsReference();
            condition.CbsCondition().ClassificationStatus = CbsCondition.CaseClassificationStatus.ConfirmedPresent;
            condition.CbsCondition().DiagnosisDate = new FhirDateTime("2021-03-01");
            condition.CbsCondition().IllnesDuration = new Quantity(6, "d");
            condition.Code = CbsCondition.ConditionCode.Encode("11550", "Hemolytic Uremic Syndrome");
            condition.Onset = new FhirDateTime("2021-02-28");
            condition.ClinicalStatus = new CodeableConcept("http://terminology.hl7.org/CodeSystem/condition-clinical", "inactive");

            // CbsCaseOfDeathProfile
            Observation caseOfDeathObs = CbsCauseOfDeath.Create();
            caseOfDeathObs.Subject = patient.CbsPatient().AsReference();
            caseOfDeathObs.Focus.Add(condition.CbsCondition().AsReference());

            // CbsTravelHistoryProfile
            var travelHistory = CbsTravelHistory.Create();
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeTo =
                CbsTravelHistory.TimeWindowRelativeToValue.ConditionOnsetDatePeriodStart;
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.TimeWindow = new Quantity(1, "day");
            travelHistory.CbsTravelHistory().ProgramSpecificTimeWindow.RelativeReference = patient.CbsPatient().AsReference();
            travelHistory.CbsTravelHistory().TravelHistoryAddress.Address = new Address() { City = "Dallas", State = "TX" };
            travelHistory.CbsTravelHistory().TravelHistoryAddress.Location = CbsTravelHistory.GeographicalLocation.Encode("48", "Texas");
            travelHistory.CbsTravelHistory().TravelHistoryAddress.TimeSpent = FhirDateTime.Now();

            // CbsVaccinationRecordProfile
            var vaccinationRecord = CbsVaccinationRecord.Create();
            vaccinationRecord.ReportOrigin = CbsVaccinationRecord.VaccineEventInformationSource.FromBirthCertificate;
            vaccinationRecord.ProtocolApplied.Add(new Immunization.ProtocolAppliedComponent() { DoseNumber = new Integer(1) });
            vaccinationRecord.Occurrence = FhirDateTime.Now();
            vaccinationRecord.VaccineCode = CbsVaccinationRecord.VaccineAdministered.Encode("05", "measles");
            vaccinationRecord.Patient = patient.CbsPatient().AsReference();

            // CbsVaccinationIndicationProfile
            var vaccinationIndication = CbsVaccinationIndication.Create();
            vaccinationIndication.Subject = patient.CbsPatient().AsReference();
            vaccinationIndication.Value = YesNoUnknown.Yes;

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

        }
    }
}
