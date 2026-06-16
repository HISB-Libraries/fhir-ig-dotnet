using GaTech.Chai.Mdi;
using GaTech.Chai.Vdor;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;
using GaTech.Chai.Vrcl;
using GaTech.Chai.Vrdr;
using GaTech.Chai.Nvdrs;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("+--------- Create VDOR Bundle ---------+");
        // Decedent. the Vitim
        Patient patient = VdorDecedent.Create();
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
        patient.VrdrDecedent().NVSSSexAtDeath = ValueSetAdministrativeGenderMaxVs.F;

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
        patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "raven@mdi.org");

        // Deceased
        patient.Deceased = new FhirDateTime(2024, 3, 2);

        // BirthPlace
        patient.PatientVr().BirthPlace.CityCode = 42425;

        // Firearm 
        Observation firearmObs = VdorFirearm.Create();
        firearmObs.VdorFirearm().FirearmStolen = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownNotApplicableVr.Yes;
        firearmObs.VdorFirearm().FirearmType = NvdrsFirearmTypeVs.HandgunPistolBoltAction;
        firearmObs.VdorFirearm().FireamrOwner = (VdorGunOwnerCodesVs.Stranger, null, null);
        firearmObs.VdorFirearm().SerialNumber = "12345-0987";
        // firearmObs.ObservationFirearm().FirearmMake = NcicFirearmMakeVs.GlockInc;
        firearmObs.VdorFirearm().FirearmMake = new FhirString("64");
        firearmObs.VdorFirearm().FirearmModel = "512";
        firearmObs.VdorFirearm().FirearmCaliber = NvdrsFirearmCaliberVs.FirearmCaliber556;;
        firearmObs.FhirSubject(patient);

        // Weapon Type
        Observation weaponTypeObs = VdorWeaponType.Create();
        weaponTypeObs.VdorWeaponType().FocusOnFirearm = firearmObs;
        weaponTypeObs.Value = NvdrsWeaponTypeVs.Firearm;
        weaponTypeObs.FhirSubject(patient);

        // Meta information.
        Composition nvdrsTestComp = VdorComposition.Create(patient, null, ValueSets.Hl7VsDataAbsentReason.NotAsked, NvdrsDocTypesVs.CMEReport);
        nvdrsTestComp.VdorComposition().ForceNewRecord = false;
        nvdrsTestComp.VdorComposition().OverwriteConflicts = true;
        nvdrsTestComp.VdorComposition().IncidentNumber = "107";
        nvdrsTestComp.VdorComposition().IncidentYear = new Date(2024);
        nvdrsTestComp.VdorComposition().AddAdditionalIdentifier(new Identifier(VdorCustomUris.victimnumberIdentifierUrl, "1"));

        // Add firearm object to composition's weapon section.
        nvdrsTestComp.VdorComposition().AddSectionEntryByCode(VdorCustomCs.Weapons, [weaponTypeObs]);

        // Add Number of Bullets to composition's Injury and death section.
        Observation numOfBulletObs = VdorNumberOfBullets.Create();
        numOfBulletObs.VdorNumberOfBullets().NumOfBullets = 3;
        numOfBulletObs.FhirSubject(patient);

        // Add Wound location to composition's Injury and death section.
        Observation woundLocation = VdorWoundLocation.Create();
        woundLocation.Code = VdorWoundLocationVs.WoundToSpine;
        woundLocation.Value = NvdrsWoundLocationValuesVs.PresentWounded;
        woundLocation.FhirSubject(patient);

        nvdrsTestComp.VdorComposition().AddSectionEntryByCode(VdorCustomCs.InjuryAndDeath, [numOfBulletObs, woundLocation]);

        // Add Wound location to composition's Circumstances.
        Observation randomViolenceIncident = VdorRandomViolence.Create();
        randomViolenceIncident.FhirSubject(patient);
        randomViolenceIncident.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownNotApplicableVr.Yes;

        Observation playingWithGun = VdorPlayingWithFirearm.Create();
        playingWithGun.FhirSubject(patient);
        playingWithGun.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownNotApplicableVr.Yes;

        nvdrsTestComp.VdorComposition().AddSectionEntryByCode(VdorCustomCs.Circumstances, [randomViolenceIncident, playingWithGun]);

        // Add VRDR Manner of Death. Follow the MDI FHIR IG Composition section pattern.
        // Us Core Practitioner (ME)
        Practitioner practitioner = UsCorePractitioner.Create();
        practitioner.Id = "ac069540-a993-11ed-afa1-0242ac120002";

        practitioner.Name = new List<HumanName> { new HumanName() { Use = HumanName.NameUse.Official, Family = "Jones", GivenElement = new List<FhirString> { new FhirString("Sam") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } } };
        practitioner.UsCorePractitioner().NPI = "3333445555";
        practitioner.Telecom = new List<ContactPoint> { new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Work, "134-456-7890") };
        practitioner.Address = new List<Address> { new Address {
                Use = Address.AddressUse.Work,
                Type = Address.AddressType.Physical,
                Line = ["567 Coda Blvd"],
                City = "Atlanta",
                District = "Fulton County",
                State = "GA",
                PostalCode = "30318",
                Country = "USA" }
            };
        practitioner.Address[0].SetDistrictCode(04000);
        practitioner.Address[0].SetStreetNameExt("Olympic Blvd");
        Observation vrdrMannerOfDeath = VrdrMannerOfDeath.Create(patient, practitioner);
        vrdrMannerOfDeath.Value = VrdrMannerOfDeathVs.AccidentalDeath;

        nvdrsTestComp.VdorComposition().AddSectionEntryByCode(MdiCodeSystem.MdiCodes.CauseManner, [vrdrMannerOfDeath]);

        // Create NVDRS Bundle using the composition created above
        Bundle nvdrsTestBundle = VdorDocumentBundle.Create(nvdrsTestComp);

        FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });
        string outputPath = "./";
        string output = serializer.SerializeToString(nvdrsTestBundle);
        File.WriteAllText(outputPath + "NVDRS_bundle_test.json", output);
 
        Console.WriteLine("+--------- Export NVDRS Bundle to Web Input file ---------+");
        // Set up if you want to export the NVDRS bundle to NVDRS web input file
        FlatObjectCMELE flatObject = new();
        nvdrsTestBundle.VdorDocumentBundle().ExportToNVDRS(flatObject);
    }

}