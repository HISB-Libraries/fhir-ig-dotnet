using System.Text.Json;
using System.Text.Json.Nodes;
using GaTech.Chai.Mdi.BundleDocumentMdiAndEdrsProfile;
using GaTech.Chai.Nvdrs;
using GaTech.Chai.Nvdrs.CompositionNVDRSProfile;
using GaTech.Chai.UsCore.PatientProfile;
using GaTech.Chai.Vrcl.PatientVrProfile;
using GaTech.Chai.Share.Extensions;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using GaTech.Chai.Nvdrs.Common;
using GaTech.Chai.Vrdr.VrdrInjuryIncidentProfile;
using GaTech.Chai.Share.Common;
using GaTech.Chai.Nvdrs.ObservationFirearm;
using GaTech.Chai.Vrcl.Common;
using GaTech.Chai.Nvdrs.NvdrsDecedent;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("+--------- Create NVDRS Bundle ---------+");
        // Decedent. the Vitim
        Patient patient = NvdrsDecedent.Create();
        patient.Id = "956c53c0-a993-11ed-afa1-0242ac120002";

        // Name
        patient.Name = new List<HumanName> { new HumanName() { Family = "Organa", GivenElement = new List<FhirString> { new FhirString("Leia"), new FhirString("S") } } };
        patient.Identifier.Add(new Identifier()
        {
            Use = Identifier.IdentifierUse.Usual,
            Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", null),
            System = "http://hl7.org/fhir/sid/us-ssn",
            Value = "213456790"
        });

        // Race
        patient.UsCorePatient().Race.Category = UsCorePatientRace.RaceCoding.Encode("2106-3", "White");
        patient.UsCorePatient().Race.ExtendedRaceCodes = new Coding[] { UsCorePatientRace.RaceCoding.Encode("2029-7", "Asian Indian") };
        patient.UsCorePatient().Race.RaceText = "Asian Indian";

        // Ethnicity
        patient.UsCorePatient().Ethnicity.Category = UsCorePatientEthnicity.EthnicityCoding.Encode("2186-5", "Not Hispanic or Latino");
        patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = new Coding[] { UsCorePatientEthnicity.EthnicityCoding.Encode("2162-6", "Central American Indian") };
        patient.UsCorePatient().Ethnicity.EthnicityText = "Not Hispanic or Latino";

        // Birth Related
        patient.BirthDateElement = new Date(1978, 3, 12);
        patient.UsCorePatient().BirthSex.Extension = new Code("F");
        patient.Gender = AdministrativeGender.Female;

        // Address
        patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "5100 Olympus Street", "Bldg5-12" },
                City = "Atlanta",
                State = "GA",
                PostalCode = "09090",
                Country = "USA"}
            };

        // Contact
        patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "404-123-0022");
        //patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310");
        //patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "212-867-5310"); // duplicate entry demo
        patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "raven@mdi.org");

        // Deceased
        patient.Deceased = new FhirDateTime(2024, 3, 2);

        // BirthPlace
        patient.PatientVr().BirthPlace.CityCode = 42425;

        // Firearm 
        Observation firearmObs = ObservationFirearm.Create();
        firearmObs.Category.Add(NvdrsCustomCs.Weapons);
        firearmObs.ObservationFirearm().FirearmStolen = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.YES;
        firearmObs.ObservationFirearm().FirearmType = NvdrsFirearmTypeVs.HandgunPistolBoltAction;
        firearmObs.ObservationFirearm().SerialNumber = "12345-0987";
        // firearmObs.ObservationFirearm().FirearmMake = NcicFirearmMakeVs.GlockInc;
        firearmObs.ObservationFirearm().FirearmMake = new FhirString("64");
        firearmObs.ObservationFirearm().FirearmModel = "512";
        firearmObs.ObservationFirearm().FirearmCaliber = "556";

        // Weapon Type
        Observation weaponTypeObs = ObservationWeaponType.Create();
        weaponTypeObs.ObservationWeaponType().FocusOnFirearm = firearmObs;
        weaponTypeObs.Value = NvdrsWeaponTypeVs.Firearm;

        // Meta information.
        Composition nvdrsTestComp = CompositionNVDRS.Create(patient, null, ValueSets.Hl7VsDataAbsentReason.NotAsked, NvdrsDocTypesVs.CMEReport);
        nvdrsTestComp.CompositionNVDRS().ForceNewRecord = true;
        nvdrsTestComp.CompositionNVDRS().OverwriteConflicts = false;
        // nvdrsTestComp.CompositionNVDRS().IncidentYear = new Date(2024);

        // Add firearm object to composition's weapon section.
        nvdrsTestComp.CompositionNVDRS().AddSectionEntryByCode(NvdrsCustomCs.Weapons, [weaponTypeObs]);

        // Create NVDRS Bundle using the composition created above
        Bundle nvdrsTestBundle = BundleDocumentNvdrs.Create(nvdrsTestComp);

        FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });
        string outputPath = "./";
        string output = serializer.SerializeToString(nvdrsTestBundle);
        File.WriteAllText(outputPath + "NVDRS_bundle_test.json", output);

        Console.WriteLine("+--------- Export NVDRS Bundle to Web Input file ---------+");
        // Set up if you want to export the NVDRS bundle to NVDRS web input file
        FlatObjectCMELE flatObject = new("./ExportConfigCMELE.json");
        nvdrsTestBundle.BundleDocumentNvdrs().ExportToNVDRS(flatObject);
    }

}