# fhir-ig-vdor-dotnet

A .NET Library for VDOR FHIR IG, https://build.fhir.org/ig/HL7/fhir-mdi-ig/

This library provides

*   supporting functions,
*   extensions
*   value sets
*   NVDRS flatfile and cvs files

Sources are available in https://github.com/HISB-Libraries/fhir-ig-dotnet/tree/main/GaTech.Chai.Vdor

Example:

```
Patient patient = VdorDecedent.Create();
patient.Id = "3c8be50e-cb06-402b-b9c0-211495d176b9";

// Name
patient.Name = new List<HumanName> { new HumanName() { Family = "Skywalker", GivenElement = new List<FhirString> { new FhirString("Leia") } } };
patient.Identifier.Add(new Identifier()
{
    Use = Identifier.IdentifierUse.Usual,
    Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
    System = "http://hl7.org/fhir/sid/us-ssn",
    Value = "987654321"
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
patient.Gender = AdministrativeGender.Male;
patient.VrdrDecedent().NVSSSexAtDeath = ValueSetAdministrativeGenderMaxVs.M;

// Address
patient.Address = new List<Address> { new Address {
        Use = Address.AddressUse.Home,
        Type = Address.AddressType.Physical,
        Line = new List<string> { "5150 Olympus Street", "Bldg5-12" },
        City = "Atlanta",
        State = "GA",
        PostalCode = "09090",
        Country = "USA"}
    };

// Contact
patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Home, "404-770-0022");
patient.Telecom.AddTelecom(ContactPoint.ContactPointSystem.Email, ContactPoint.ContactPointUse.Work, "raven@fhir.org");

// Deceased
patient.Deceased = new FhirDateTime(2025, 3, 2);

// BirthPlace
patient.PatientVr().BirthPlace.CityCode = 42425;

// Meta information.
Composition nvdrsTestComp = VdorComposition.Create(patient, null, ValueSets.Hl7VsDataAbsentReason.NotAsked, NvdrsDocTypesVs.CMEReport);
nvdrsTestComp.VdorComposition().ForceNewRecord = false;
nvdrsTestComp.VdorComposition().OverwriteConflicts = true;
nvdrsTestComp.VdorComposition().IncidentNumber = "12";
nvdrsTestComp.VdorComposition().IncidentYear = new Date(2025);
nvdrsTestComp.VdorComposition().VictimNumber = "1";

// Add VRDR Manner of Death. Follow the MDI FHIR IG Composition section pattern.
// Us Core Practitioner (ME)
Practitioner practitioner = UsCorePractitioner.Create();
practitioner.Id = "86a031e9-ff66-48a4-894c-936880a3dd6b";

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

nvdrsTestComp.CompositionMdiAndEdrs().SetMannerOfDeath(VrdrMannerOfDeathVs.AccidentalDeath);
nvdrsTestComp.CompositionMdiAndEdrs().SetCOD1(1, "Fentanyl toxicity", new FhirString("minutes to hours"));

// Add Toxicology Findings
Observation toxFinding1 = VdorToxicologyFinding.Create();
toxFinding1.Id = "toxfinding1";
toxFinding1.VdorToxicologyFinding().SubstanceName = "FENTANYL";
toxFinding1.VdorToxicologyFinding().SubstanceTested = VdorToxSubstanceTestedVs.Tested;
toxFinding1.VdorToxicologyFinding().SubstanceResult = VdorToxFindingsSubstanceResultsVs.Present;
toxFinding1.VdorToxicologyFinding().SubstanceCausedDeath = true;
toxFinding1.VdorToxicologyFinding().DrugObtainedFor = VdorToxFindingsDrugObtainedForVs.Family;

Observation toxFinding2 = VdorToxicologyFinding.Create();
toxFinding2.Id = "toxfinding2";
toxFinding2.VdorToxicologyFinding().SubstanceName = "CAFFEINE";
toxFinding2.VdorToxicologyFinding().SubstanceTested = VdorToxSubstanceTestedVs.Tested;
toxFinding2.VdorToxicologyFinding().SubstanceResult = VdorToxFindingsSubstanceResultsVs.NotPresent;
toxFinding2.VdorToxicologyFinding().SubstanceCausedDeath = false;
toxFinding2.VdorToxicologyFinding().DrugObtainedFor = VdorToxFindingsDrugObtainedForVs.IntimatePartner;

nvdrsTestComp.VdorComposition().Toxicology = [toxFinding1, toxFinding2];

// Create NVDRS Bundle using the composition created above
Bundle nvdrsTestBundle = VdorDocumentBundle.Create(nvdrsTestComp);
```


Generating NVDRS Import CSV file from Bundle. The VDOR FHIR IG .net library has import specifications for CME and Toxicology Findings
embedded. However, if you want to provide your own, you can include them when the flatfile object is created as shown below for the toxicology findings.

```
FlatObjectCMELE flatCMEObject = new("csv");
FlatObjectTox flatToxFindingsObject = new("csv", "TOX_2026.json", "/your_path_to_toxicology_findings_spec/");

nvdrsTestBundle.VdorDocumentBundle().ExportToNVDRS(flatCMEObject);
nvdrsTestBundle.VdorDocumentBundle().ExportToNVDRS(flatToxFindingsObject);
```

The ExportToNVDRS() will write the flatfile or csv file with a file name of file type (CME or TOX) with timestamp. 
As an option, you can provide a filename like ExportToNVDRS(flatTypeObject, filename) to save the output file to different
location and name.