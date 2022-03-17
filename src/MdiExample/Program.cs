using System;
using System.Collections.Generic;
using GaTech.Chai.FhirIg.Extensions;
using GaTech.Chai.Mdi.ListCauseOfDeathPathwayProfile;
using GaTech.Chai.Mdi.MditoEdrsCompositionProfile;
using GaTech.Chai.Mdi.ObservationCauseOfDeathConditionProfile;
using GaTech.Chai.Odh.UsualWorkProfile;
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

            //Observation causeOfDeath2 = ObservationCauseOfDeathCondition.Create();
            //causeOfDeath1.Status = ObservationStatus.Final;
            //causeOfDeath1.Subject = patient.AsReference();
            //causeOfDeath1.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            //causeOfDeath1.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            //Observation causeOfDeath3 = ObservationCauseOfDeathCondition.Create();
            //causeOfDeath1.Status = ObservationStatus.Final;
            //causeOfDeath1.Subject = patient.AsReference();
            //causeOfDeath1.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            //causeOfDeath1.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            //Observation causeOfDeath4 = ObservationCauseOfDeathCondition.Create();
            //causeOfDeath1.Status = ObservationStatus.Final;
            //causeOfDeath1.Subject = patient.AsReference();
            //causeOfDeath1.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            //causeOfDeath1.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            //Observation causeOfDeath5 = ObservationCauseOfDeathCondition.Create();
            //causeOfDeath1.Status = ObservationStatus.Final;
            //causeOfDeath1.Subject = patient.AsReference();
            //causeOfDeath1.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            //causeOfDeath1.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            //Observation causeOfDeath6 = ObservationCauseOfDeathCondition.Create();
            //causeOfDeath1.Status = ObservationStatus.Final;
            //causeOfDeath1.Subject = patient.AsReference();
            //causeOfDeath1.ObservationCauseOfDeathCondition().Value = new CodeableConcept(null, null, "Fentanyl toxicity");
            //causeOfDeath1.ObservationCauseOfDeathCondition().IntervalString = "minutes to hours";

            // Us Core Practitioner
            Practitioner practitioner = UsCorePractitioner.Create();
            practitioner.Name = new List<HumanName> { new HumanName() { Use = HumanName.NameUse.Official, Family = "Jones", GivenElement = new List<FhirString> { new FhirString("Sam") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } } };
            practitioner.UsCorePractitioner().NPI = "3333445555";

            // Cause of Death Pathway
            List pathWayList = ListCauseOfDeathPathway.Create();
            pathWayList.ListCauseOfDeathPathway().AddCauseOfDeathCondition(causeOfDeath1.AsReference());
            pathWayList.Subject = patient.AsReference();
            pathWayList.Source = practitioner.AsReference();
   
            string output = serializer.SerializeToString(pathWayList);
            Console.WriteLine(output);

            //Composition composition = MdiToEdrsComposition.Create();

        }
    }
}
