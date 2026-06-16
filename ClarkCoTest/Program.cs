using GaTech.Chai.Mdi;
using GaTech.Chai.Odh;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;
using GaTech.Chai.Vrcl;
using GaTech.Chai.Vrdr;
using GaTech.Chai.Vdor;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using static GaTech.Chai.UsCore.CodeSystemsValueSets;
using GaTech.Chai.Nvdrs;

Console.WriteLine("+--------- Create NVDRS Bundle for Clark County ---------+");

// Create a patient
Patient patient = VrdrDecedent.Create();
patient.UsCorePatient().Race.Category = UsCoreVsOmbRaceCategory.Unknown;
patient.UsCorePatient().Race.ExtendedRaceCodes = [UsCoreVSDetailedRace.Unknown];
patient.UsCorePatient().Race.RaceText = UsCoreVSDetailedRace.Unknown.Display;

patient.UsCorePatient().Ethnicity.Category = UsCoreVsOmbEthnicityCategory.HispanicOrLatino;
patient.UsCorePatient().Ethnicity.ExtendedEthnicityCodes = [UsCoreVSDetailedEthnicity.MexicanAmerican];
patient.UsCorePatient().Ethnicity.EthnicityText = UsCoreVSDetailedEthnicity.MexicanAmerican.Display;

patient.UsCorePatient().GenderIdentity = [UsCoreVsGenderIdentity.FemaleToMaleTranssexual];

patient.Identifier.Add(new Identifier()
{
    Use = Identifier.IdentifierUse.Usual,
    Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", ""),
    System = "http://hl7.org/fhir/sid/us-ssn",
    Value = "55555555"
});

patient.Name =
[
    new() { Use = HumanName.NameUse.Official, Family = "Cane", GivenElement = [new("Jhon"), new("Michael")], SuffixElement = [new("First")] },
    new() { Use = HumanName.NameUse.Nickname, Family = "NameAKA"}
];

patient.BirthDateElement = new Hl7.Fhir.Model.Date(2000, 4, 23);
patient.Gender = AdministrativeGender.Male;

patient.Address = [ new Address {
    Line = ["9127 Katy Freeway"],
    City = "Houston",
    State = "TX",
    PostalCode = "77024",
    Country = "US"}
];

// Practitioner who will be used for assigner/performer
Practitioner practitioner = VrdrCertifier.Create();
practitioner.Id = "ac069540-a993-11ed-afa1-0242ac120002";

practitioner.Name = [new HumanName() { Use = HumanName.NameUse.Official, Family = "Jones", GivenElement = new List<FhirString> { new FhirString("Sam") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } }];
practitioner.UsCorePractitioner().NPI = "3333445555";
practitioner.Telecom = [new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Work, "134-456-7890")];
practitioner.Address = [ new Address {
    Use = Address.AddressUse.Work,
    Type = Address.AddressType.Physical,
    Line = ["567 Coda Blvd"],
    City = "Atlanta",
    District = "Fulton County",
    State = "GA",
    PostalCode = "30318",
    Country = "US" }
];
practitioner.Address[0].SetDistrictCode(04000);
practitioner.Address[0].SetStreetNameExt("Olympic Blvd");

// Get the composition ready. This is like table of contents for the Bundle.
Composition clarkTestComp = VdorComposition.Create(patient, practitioner, null, NvdrsDocTypesVs.CMEReport);
clarkTestComp.Subject = patient.AsReference();

// Set this to true if this data is a new record in NVDRS Web.
clarkTestComp.VdorComposition().ForceNewRecord = true;

/*******************
 * For Injury and Death section
 * - EMS at scene
 * - Number of Bullets
 * - injuryWhenCustody
 * - Injury Incident
 * - Injury Location
 * - Autopsy Performed
 */
// EMS at scene
Observation emsAtSceneObs = VdorEmsAtScene.Create();
emsAtSceneObs.Status = ObservationStatus.Final;
emsAtSceneObs.FhirSubject(patient);
emsAtSceneObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Add Number of Bullets to composition's Injury and death section.
Observation numOfBulletObs = VdorNumberOfBullets.Create();
numOfBulletObs.Status = ObservationStatus.Final;
numOfBulletObs.VdorNumberOfBullets().NumOfBullets = 3;
numOfBulletObs.FhirSubject(patient);

// injuryWhenCustody
Observation injuryWhenCustodyObs = VdorVictimInCustodyWhenInjured.Create();
injuryWhenCustodyObs.Status = ObservationStatus.Final;
injuryWhenCustodyObs.FhirSubject(patient);
injuryWhenCustodyObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Injury Incident
Observation injuryIncident = VrdrInjuryIncident.Create(patient);
injuryIncident.Status = ObservationStatus.Final;
injuryIncident.FhirSubject(patient);
injuryIncident.VrdrInjuryIncident().WorkInjuryIndicator = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;
injuryIncident.VrdrInjuryIncident().PlaceOfInjury = new FhirString("company");
injuryIncident.VrdrInjuryIncident().TransportationRole = (VrdrTransportationIncidentRoleVs.Other, "Rear Right");

// Injury Location
Location injuryLocation = VrdrInjuryLocation.Create();
injuryLocation.Address = new Address()
{
    Line = ["27421 Valley Center Road"],
    City = "Valley Center",
    District = "San Diego",
    State = "California",
    PostalCode = "92082",
    Country = "United States"
};

// Autopsy Performed
Observation autopsyPerformedObs = ObservationAutopsyPerformedIndicatorVr.Create(patient);
autopsyPerformedObs.Status = ObservationStatus.Final;
autopsyPerformedObs.FhirSubject(patient);
autopsyPerformedObs.ObservationAutopsyPerformedIndicatorVr().Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.No;

// Add these resources to Injury and Death section.
clarkTestComp.VdorComposition().AddSectionEntryByCode(VdorCompositionSections.InjuryAndDeath, 
    [
        emsAtSceneObs, 
        numOfBulletObs, 
        injuryWhenCustodyObs, 
        injuryIncident, 
        injuryLocation, 
        autopsyPerformedObs]
);

/*******************
 * For Circumstance section
 * - Depressed Mode 
 * - History of Mental Illness (non-NVDRS)
 * - Self Harm
 * - Random Violence
 * - School Problem
 * - History of suicide attempts
 * - Suicide Note
 * - Alcohol problem
 * - Clark co specific - drug involvement
 * - Death Abuse
 * - Gang related
 * - Drive by shooting
 */
// Depressed Mode
Observation depressedObs = VdorCurrentDepressedMood.Create();
depressedObs.Status = ObservationStatus.Final;
depressedObs.FhirSubject(patient); 
depressedObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Mental Illness
Observation mentalIllnessObs = VdorHistoryOfMentalIllness.Create();
mentalIllnessObs.Status = ObservationStatus.Final;
mentalIllnessObs.FhirSubject(patient); 
mentalIllnessObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Selfharm
Observation selfharmObs = VdorHistoryOfSelfHarm.Create();
selfharmObs.Status = ObservationStatus.Final;
selfharmObs.FhirSubject(patient);
selfharmObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Random Vielence
Observation randomViolenceObs = VdorRandomViolence.Create();
randomViolenceObs.Status = ObservationStatus.Final;
randomViolenceObs.FhirSubject(patient);
randomViolenceObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// School Problem
Observation schoolProblemObs = VdorSchoolProblem.Create();
schoolProblemObs.Status = ObservationStatus.Final;
schoolProblemObs.FhirSubject(patient);
schoolProblemObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// History of suicide attempts
Observation suicideAttempts = VdorHistoryOfSuicideAttempts.Create();
suicideAttempts.Status = ObservationStatus.Final;
suicideAttempts.FhirSubject(patient);
suicideAttempts.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

 // Suicide Note
Observation suicideNoteObs = VdorSuicideNoteContent.Create();
suicideNoteObs.Status = ObservationStatus.Final;
suicideNoteObs.FhirSubject(patient);   
suicideNoteObs.VdorSuicideNoteContent().SuicideNoteContent = "Sorry.. I am ...";

// Alcohol problem
Observation alcoholProblemObs = VdorHistoryAlcoholUse.Create();
alcoholProblemObs.Status = ObservationStatus.Final;
alcoholProblemObs.FhirSubject(patient);
alcoholProblemObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Clark co specific - drug involvement
Observation drugInvolvementObs = VdorCircumstances.Create();
drugInvolvementObs.Status = ObservationStatus.Final;
drugInvolvementObs.FhirSubject(patient);
drugInvolvementObs.Code = new(VdorCustomCs.officialUrl, "drug-involvement", "Drug Involvement", "");
drugInvolvementObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// DeathAbuse
Observation deathAbuseObs = VdorDeathAbuse.Create();
deathAbuseObs.Status = ObservationStatus.Final;
deathAbuseObs.FhirSubject(patient);
deathAbuseObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.No;

// Gang related observation
Observation gangRelatedObs = VdorGangRelated.Create();
gangRelatedObs.Status = ObservationStatus.Final;
gangRelatedObs.FhirSubject(patient);
gangRelatedObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Firearm Drive by shooting
Observation driveByShootingObs = VdorDriveByShooting.Create();
driveByShootingObs.Status = ObservationStatus.Final;
driveByShootingObs.FhirSubject(patient);
driveByShootingObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Firearm Related observation
Observation playWithFirearmObs = VdorPlayingWithFirearm.Create();
playWithFirearmObs.Status = ObservationStatus.Final;
playWithFirearmObs.FhirSubject(patient);
playWithFirearmObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Add these resources to Circumstance section.
clarkTestComp.VdorComposition().AddSectionEntryByCode(VdorCompositionSections.Circumstances, 
    [
        depressedObs, 
        mentalIllnessObs, 
        selfharmObs, 
        randomViolenceObs, 
        schoolProblemObs, 
        suicideAttempts, 
        suicideNoteObs,
        alcoholProblemObs,
        drugInvolvementObs,
        deathAbuseObs,
        gangRelatedObs,
        driveByShootingObs,
        playWithFirearmObs
    ]
);

/*******************
 * For Toxicology section
 * - Lab Results
 * - Specimen
 */
 // Lab Results for Alcohol, Amphetamine, Benzodiazepines, Cocaine, Opiate
Observation alcoholObs = ObservationToxicologyLabResult.Create();
alcoholObs.Status = ObservationStatus.Final;
alcoholObs.FhirSubject(patient);
alcoholObs.ObservationToxicologyLabResult().CodeText = "Alcohol";
alcoholObs.ObservationToxicologyLabResult().ValueText = "4";

Observation amphetamineObs = ObservationToxicologyLabResult.Create();
amphetamineObs.Status = ObservationStatus.Final;
amphetamineObs.FhirSubject(patient);
amphetamineObs.ObservationToxicologyLabResult().CodeText = "Amphetamine";
amphetamineObs.ObservationToxicologyLabResult().ValueText = "8 mg";

Observation benzodiazepinesObs = ObservationToxicologyLabResult.Create();
benzodiazepinesObs.Status = ObservationStatus.Final;
benzodiazepinesObs.FhirSubject(patient);
benzodiazepinesObs.ObservationToxicologyLabResult().CodeText = "Benzodiazepines";
benzodiazepinesObs.ObservationToxicologyLabResult().ValueText = "10 mg";

Observation cocaineObs = ObservationToxicologyLabResult.Create();
cocaineObs.Status = ObservationStatus.Final;
cocaineObs.FhirSubject(patient);
cocaineObs.ObservationToxicologyLabResult().CodeText = "Cocaine";
cocaineObs.ObservationToxicologyLabResult().ValueText = "9 mg";

Observation opiateObs = ObservationToxicologyLabResult.Create();
opiateObs.Status = ObservationStatus.Final;
opiateObs.FhirSubject(patient);
opiateObs.ObservationToxicologyLabResult().CodeText = "Opiate";
opiateObs.ObservationToxicologyLabResult().ValueText = "11 mg";

// Specimen
Specimen specimen = SpecimenToxicologyLab.Create();
specimen.Subject = patient.AsReference();
specimen.SpecimenToxicologyLab().SpecimenTypeText = "Bile specimen (specimen)";

// Add these resources to Toxicology section.
clarkTestComp.VdorComposition().AddSectionEntryByCode(VdorCompositionSections.Toxicology, 
    [
        alcoholObs, 
        amphetamineObs, 
        benzodiazepinesObs, 
        cocaineObs, 
        opiateObs, 
        specimen
    ]
);

/*******************
 * For Demographics section
 * - Homeless status
 * - Age at Death
 * - Occupation of decedent
 * - Height
 * - Weight
 */
// Homeless status
Observation homelessObs = VdorHomelessAtDeath.Create();
homelessObs.Status = ObservationStatus.Final;
homelessObs.FhirSubject(patient);
homelessObs.Value = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;

// Age at Death
Observation ageAtDeathObs = VrdrDecedentAge.Create(patient);
ageAtDeathObs.Status = ObservationStatus.Final;
ageAtDeathObs.FhirSubject(patient);
ageAtDeathObs.Value = new Hl7.Fhir.Model.Quantity() 
{ 
    Value = 24,
    Unit = "a",
    System = UriString.UnitsOfMeasure,
    Code = "a"
};

// Occupation of decedent. We must have occupation if we create this. If occupation is
// unknown, we just do not create this. "Occupation" is not an occupation....
Observation usualWorkObs = OdhUsualWork.Create();
usualWorkObs.Status = ObservationStatus.Final;
usualWorkObs.FhirSubject(patient);
usualWorkObs.Value = new CodeableConcept() 
{
    Text = "Occupation"
};

Observation.ComponentComponent usualWorkComp = usualWorkObs.Component.GetOrAddComponent("http://loinc.org", "21844-6", "History of Usual industry");
usualWorkComp.Value = new CodeableConcept() { Text = "Occupation"};

// Height
Observation heightObs = new()
{
    Status = ObservationStatus.Final
};
heightObs.FhirSubject(patient);
heightObs.AddProfile("http://hl7.org/fhir/us/core/StructureDefinition/us-core-body-height");
heightObs.Category =
[
    new("http://terminology.hl7.org/CodeSystem/observation-category", "vital-signs")
];
heightObs.Code = VitalHeight;
heightObs.Effective = new FhirDateTime(2024, 7, 2);
heightObs.Value = new Hl7.Fhir.Model.Quantity() 
{
    Value = (decimal?)259.8,
    Unit = "cm",
    System = "http://unitsofmeasure.org ",
    Code = "cm"
};

// Weight
Observation weightObs = new()
{
    Status = ObservationStatus.Final
};
weightObs.FhirSubject(patient);
weightObs.AddProfile("http://hl7.org/fhir/us/core/StructureDefinition/us-core-body-weight");
weightObs.Category =
[
    new("http://terminology.hl7.org/CodeSystem/observation-category", "vital-signs")
];
weightObs.Code = VitalWeight;
weightObs.Effective = new FhirDateTime(2024, 7, 2);
weightObs.Value = new Hl7.Fhir.Model.Quantity() 
{
    Value = (decimal?)185,
    Unit = "lb_av",
    System = "http://unitsofmeasure.org ",
    Code = "[lb_av]"
};

Observation sexualOrientationObs = UsCoreObservationSexualOrientation.Create();
sexualOrientationObs.Status = ObservationStatus.Final;
sexualOrientationObs.FhirSubject(patient);
sexualOrientationObs.Value = UsCoreVsSexualOrientation.Bisexual;

// Add these resources to Demographics section
clarkTestComp.VdorComposition().AddSectionEntryByCode(VdorCompositionSections.Demographics, 
    [
        homelessObs, 
        ageAtDeathObs, 
        usualWorkObs,
        heightObs,
        weightObs,
        sexualOrientationObs
    ]);


/*******************
 * For Weapon section
 * - Weapon Type  
 * - Firearm 
 */
 // Person who owns the firearm.
Person firearmOwnerPerson = new()
{
    Name = [new() { Family = "Brown", Given = ["Tiffany"]}]
};

 // Firearm
Observation firearmObs = VdorFirearm.Create();
firearmObs.Status = ObservationStatus.Final;
firearmObs.FhirSubject(patient);
// firearmObs.Category.Add(NvdrsCustomCs.Weapons);
firearmObs.VdorFirearm().FirearmStolen = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;
firearmObs.VdorFirearm().FirearmStoredLoaded = VrclCodeSystemsValueSets.VrclValueSetYesNoUnknownVr.Yes;
firearmObs.VdorFirearm().SerialNumber = "5555555f";
firearmObs.VdorFirearm().FireamrOwner = (VdorGunOwnerCodesVs.Stranger, "Narrative here", firearmOwnerPerson);
firearmObs.VdorFirearm().FirearmType = NvdrsFirearmTypeVs.ShotgunUnknownType;
// firearmObs.ObservationFirearm().FirearmMake = NcicFirearmMakeVs.GlockInc;
firearmObs.VdorFirearm().FirearmMake = new FhirString("64");
firearmObs.VdorFirearm().FirearmModel = "512";
firearmObs.VdorFirearm().FirearmCaliber = NvdrsFirearmCaliberVs.FirearmCaliber556;

// Weapon Type
Observation weaponTypeObs = VdorWeaponType.Create();
weaponTypeObs.Status = ObservationStatus.Final;
weaponTypeObs.FhirSubject(patient);
weaponTypeObs.VdorWeaponType().FocusOnFirearm = firearmObs;
weaponTypeObs.Value = NvdrsWeaponTypeVs.Firearm;

// Add these resources to weapon section.
clarkTestComp.VdorComposition().AddSectionEntryByCode(VdorCompositionSections.Weapons, [weaponTypeObs]);

/*****************************
 * The follows are cause-manner in MDI compose section or death certification in VRDR.
 * Since this is from CME, we will use MDI definition here.
 * - Causes of death 1 - 4
 * - Other contributing condition
 */
// Causes of Death 1 - 4
Observation causeOfDeathPart1 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Airway Occlusion - Chemical", 1, "minutes");
causeOfDeathPart1.Status = ObservationStatus.Final;
causeOfDeathPart1.FhirSubject(patient);

Observation causeOfDeathPart2 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Aspiration of Food - Chemical", 2, "minutes");
causeOfDeathPart2.Status = ObservationStatus.Final;
causeOfDeathPart2.FhirSubject(patient);

Observation causeOfDeathPart3 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Burns - Thermal", 3, "minutes");
causeOfDeathPart3.Status = ObservationStatus.Final;
causeOfDeathPart3.FhirSubject(patient);

Observation causeOfDeathPart4 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Cardiac - Ruptured Aortic Aneurysm", 4, "minutes");
causeOfDeathPart4.Status = ObservationStatus.Final;
causeOfDeathPart4.FhirSubject(patient);

// Other contributing factor
Observation conditionContributingToDeath = VrdrCauseOfDeathPart2.Create(patient, practitioner);
conditionContributingToDeath.Status = ObservationStatus.Final;
conditionContributingToDeath.FhirSubject(patient);
conditionContributingToDeath.VrdrCauseOfDeathPart2().Value = new CodeableConcept("", "", "other cause");

// Add these resources to cause-manner section.
clarkTestComp.VdorComposition().AddSectionEntryByCode(MdiCodeSystem.MdiCodes.CauseManner, 
    [
        causeOfDeathPart1,
        causeOfDeathPart2,
        causeOfDeathPart3,
        causeOfDeathPart4,
        conditionContributingToDeath
    ]
);


/*******************************
 * Death Certification is in the Jurisdication section of MDI composition
 */
Procedure deathCertificationProcedure = VrdrDeathCertification.Create();
deathCertificationProcedure.Performed = new FhirDateTime(2024, 7, 23);;
deathCertificationProcedure.Subject = patient.AsReference();
deathCertificationProcedure.VrdrDeathCertification().SubjectAsResource = patient;
deathCertificationProcedure.VrdrDeathCertification().AddPerformer(practitioner, VrdrCertifierTypesVs.DeathCertByCME);

// Put these to the jurisdiction section. Use MDI FHIR IG code. 
clarkTestComp.VdorComposition().AddSectionEntryByCode(MdiCodeSystem.MdiCodes.Jurisdiction, 
    [
        deathCertificationProcedure
    ]);

/***********************************
 * Vital Information about the decedent
 * This can be grouped in the medical-history of MDI FHIR IG. 
 * - Height
 * - Weight
 */


// Put these to the medical-history section. Use MDI FHIR IG code. 
// clarkTestComp.NvdrsComposition().AddSectionEntryByCode(MdiCompositionSections.MedicalHistory, 
//     [
//         heightObs, 
//         weightObs
//     ]);

/*******************
 * For another data that are related to death but we do not have sections defined for.
 * The best place to reference these data could be still in the composition.section but
 * we may want to use MDI or VDRD FHIR IG so that we can achieve the interoperability without
 * too much of custom parsing. 
 *
 * For anything that we can't find from the existing code, we put them in the appendix.
 *
 * - Number of victims
  */

// Number of victims
// This is auto-generated in NVDRS (see 1.8 in NVDRS Coding Manual)
Observation numOfVictimObs = VdrsNumberOfVictims.Create();
numOfVictimObs.Status = ObservationStatus.Final;
numOfVictimObs.FhirSubject(patient);
numOfVictimObs.VdrsNumberOfVictims().NumOfVictims = 34;

// Add these resources to Appendix section.
clarkTestComp.VdorComposition().AddSectionEntryByCode(VdorCompositionSections.Appendix, 
    [
        numOfVictimObs
    ]);


// Create NVDRS Bundle using the composition created above
Bundle nvdrsTestBundle = VdorDocumentBundle.Create(clarkTestComp);
nvdrsTestBundle.Id = "6d9beb96-3edd-4344-8976-e8e46796c26c";
FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });
string outputPath = "./";
string output = serializer.SerializeToString(nvdrsTestBundle);
File.WriteAllText(outputPath + "ClarkCounty_NVDRS_bundle_test.json", output);

Console.WriteLine("+--------- Export NVDRS Bundle to Web Input file ---------+");
// Set up if you want to export the NVDRS bundle to NVDRS web input file
FlatObjectCMELE flatObject = new();
nvdrsTestBundle.VdorDocumentBundle().ExportToNVDRS(flatObject, "clarkson_data_gtri_flat.txt");

// Read FHIR Bundle
var parser = new FhirJsonParser();

string bundleText = System.IO.File.ReadAllText("FHIRMessage-CaseId-436160-V5.json");
var bundle = parser.Parse<Bundle>(bundleText);

bundle.ImportToLibrary();
bundle.VdorDocumentBundle().ExportToNVDRS(flatObject, "from_clarkco_data_flat.txt");

