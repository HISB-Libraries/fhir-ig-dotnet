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

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("+--------- Create NVDRS Bundle ---------+");
        // Decedent. the Vitim
        Patient patient = PatientVr.Create();
        patient.Id = "806c53c0-a993-11ed-afa1-0242ac120002";

        // Name
        patient.Name = new List<HumanName> { new HumanName() { Family = "Solo", GivenElement = new List<FhirString> { new FhirString("Han"), new FhirString("J") } } };
        patient.Identifier.Add(new Identifier()
        {
            Use = Identifier.IdentifierUse.Usual,
            Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", null),
            System = "http://hl7.org/fhir/sid/us-ssn",
            Value = "123456790"
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
        patient.UsCorePatient().BirthSex.Extension = new Code("M");
        patient.Gender = AdministrativeGender.Female;

        // Address
        patient.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Home,
                Type = Address.AddressType.Physical,
                Line = new List<string> { "5100 Peachtree Street", "Bldg4-12" },
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
        patient.Deceased = new FhirDateTime(2014, 3, 2);

        // BirthPlace
        patient.PatientVr().BirthPlace.CityCode = 42425;

        // Firearm 
        Observation firearmObs = ObservationFirearm.Create();
        firearmObs.Category.Add(NvdrsCodeSystem.NvdrsCategoryCodes.Weapons);
        firearmObs.ObservationFirearm().FirearmStolen = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.YES;
        firearmObs.ObservationFirearm().FirearmType = NvdrsCodeSystem.NvdrsFirearmTypeValueSet.HandgunPistolBoltAction;
        firearmObs.ObservationFirearm().SerialNumber = new Identifier { System = "urn:vdrs:ncic:serialnumber", Value = "12345-0987" };
        firearmObs.ObservationFirearm().FirearmMake = NvdrsCodeSystem.NvdrsNcicFirearmMakeValueSet.GlockInc_Smyrna_Georgia;
        firearmObs.ObservationFirearm().FirearmModel = "XYZ";
        firearmObs.ObservationFirearm().FirearmCaliber = "556";

        // Weapon Type
        Observation weaponTypeObs = ObservationWeaponType.Create();
        weaponTypeObs.ObservationWeaponType().FocusOnFirearm = firearmObs;
        weaponTypeObs.Value = NvdrsCodeSystem.NvdrsWeaponTypeValueSet.Firearm;

        // Meta information.
        Composition nvdrsTestComp = CompositionNVDRS.Create(patient, null, ValueSets.Hl7VsDataAbsentReason.NotAsked, NvdrsCodeSystem.NvdrsDocTypeValueSet.CNEReport);
        nvdrsTestComp.CompositionNVDRS().ForceNewRecord = true;
        nvdrsTestComp.CompositionNVDRS().OverwriteConflicts = false;
        nvdrsTestComp.CompositionNVDRS().IncidentYear = new Date(2014);

        // Add firearm object to composition's weapon section.
        nvdrsTestComp.CompositionNVDRS().AddSectionEntryByCode(NvdrsCodeSystem.NvdrsSectionCodes.Weapons, [weaponTypeObs]);

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