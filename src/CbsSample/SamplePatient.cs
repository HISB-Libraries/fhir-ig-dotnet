using System;
using GaTech.Chai.Cbs.CbsCaseNotificationPanelProfile;
using GaTech.Chai.Cbs.CbsConditionProfile;
using GaTech.Chai.Cbs.CbsPatientProfile;
using GaTech.Chai.Cbs.CbsSpecimenProfile;
using GaTech.Chai.Cbs.CbsVaccinationRecordProfile;
using GaTech.Chai.Cbs.Extensions;
using Hl7.Fhir.Model;

namespace CbsSample
{
    public static class SamplePatient
    {
        public static Patient Create()
        {
            Patient patient = CbsPatient.Create();
            patient.Identifier.Add(new Identifier("urn:temp:national-reporting-jurisdiction:48", "340227"));
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
            return patient;
        }

        public static Specimen SampleSpecimen(Patient patient)
        {
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
            return specimen;
        }

        public static (Condition, Observation) HemolyticUremicSyndrome(Patient patient)
        {
            Condition condition = CbsCondition.Create();
            condition.Subject = patient.AsReference();
            condition.CbsCondition().ClassificationStatus = CbsCondition.CaseClassificationStatus.ConfirmedPresent;
            condition.CbsCondition().DiagnosisDate = new FhirDateTime("2021-03-01");
            condition.CbsCondition().IllnesDuration = new Quantity(6, "d");
            condition.Code = CbsCondition.ConditionCode.Encode("11550", "Hemolytic Uremic Syndrome");
            condition.Onset = new FhirDateTime("2021-02-28");
            condition.ClinicalStatus = new CodeableConcept("http://terminology.hl7.org/CodeSystem/condition-clinical", "inactive");

            var exposure = CbsExposureObservation.Create();
            exposure.CbsExposureObservation().CountryOfExposure = new CodeableConcept("urn:iso:std:iso:3166", "USA", "United States of America");
            exposure.CbsExposureObservation().StateOrProvinceOfExposure = new CodeableConcept("urn:oid:2.16.840.1.113883.6.92", "48", "Texas");
            exposure.CbsExposureObservation().CityOfExposure = "Houston";
            exposure.CbsExposureObservation().CountyOfExposure = "Harris";
            exposure.Subject = patient.AsReference();
            exposure.Focus.Add(condition.AsReference());

            return (condition, exposure);
        }

        public static Immunization MeaslesVaccine(Patient patient)
        {
            var vaccinationRecord = CbsVaccinationRecord.Create();
            vaccinationRecord.Status = Immunization.ImmunizationStatusCodes.Completed;
            vaccinationRecord.ReportOrigin = CbsVaccinationRecord.VaccineEventInformationSource.FromBirthCertificate;
            vaccinationRecord.ProtocolApplied.Add(new Immunization.ProtocolAppliedComponent() { DoseNumber = new PositiveInt(1) });
            vaccinationRecord.Occurrence = FhirDateTime.Now();
            vaccinationRecord.VaccineCode = CbsVaccinationRecord.VaccineAdministered.Encode("05", "measles");
            vaccinationRecord.Patient = patient.AsReference();
            return vaccinationRecord;
        }
    }
}
