using GaTech.Chai.Mdi;
using GaTech.Chai.Nvdrs;
using GaTech.Chai.Odh.UsualWorkProfile;
using GaTech.Chai.Share;
using GaTech.Chai.UsCore;
using GaTech.Chai.Vrcl;
using GaTech.Chai.Vrdr;
using Hl7.Fhir.ElementModel.Types;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using static GaTech.Chai.UsCore.CodeSystemsValueSets;
using static GaTech.Chai.Vrcl.VrclCodeSystemsValueSets;

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
    Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "SB", "Social Beneficiary Identifier", null),
    System = "http://hl7.org/fhir/sid/us-ssn",
    Value = "55555555"
});

patient.Name = new List<HumanName>
{
    new() { Use = HumanName.NameUse.Official, Family = "Cane", GivenElement = [new("Jhon"), new("Michael")], SuffixElement = [new("First")] },
    new() { Use = HumanName.NameUse.Nickname, Family = "NameAKA"}
};

patient.BirthDateElement = new Hl7.Fhir.Model.Date(2000, 4, 23);
patient.Gender = AdministrativeGender.Male;

patient.Address = [ new Address {
    Line = ["9127 Katy Freeway"],
    City = "Houston",
    State = "Texas",
    PostalCode = "77024",
    Country = "United States"}
];

// Practitioner who will be used for assigner/performer
Practitioner practitioner = UsCorePractitioner.Create();
practitioner.Id = "ac069540-a993-11ed-afa1-0242ac120002";

practitioner.Name = [new HumanName() { Use = HumanName.NameUse.Official, Family = "Jones", GivenElement = new List<FhirString> { new FhirString("Sam") }, PrefixElement = new List<FhirString> { new FhirString("Dr") } }];
practitioner.UsCorePractitioner().NPI = "3333445555";
practitioner.Telecom = [new ContactPoint(ContactPoint.ContactPointSystem.Phone, ContactPoint.ContactPointUse.Work, "134-456-7890")];
practitioner.Address = [ new Address {
    Use = Address.AddressUse.Work,
    Type = Address.AddressType.Physical,
    Line = new List<string> { "567 Coda Blvd" },
    City = "Atlanta",
    District = "Fulton County",
    State = "GA",
    PostalCode = "30318",
    Country = "USA" }
];
practitioner.Address[0].SetDistrictCode(04000);
practitioner.Address[0].SetStreetNameExt("Olympic Blvd");

// Get the composition ready. This is like table of contents for the Bundle.
Composition clarkTestComp = NvdrsComposition.Create(patient, practitioner, null, NvdrsDocTypesVs.CMEReport);

// Set this to true if this data is a new record in NVDRS Web.
clarkTestComp.NvdrsComposition().ForceNewRecord = true;

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
Observation emsAtSceneObs = NvdrsEmsAtScene.Create();
emsAtSceneObs.FhirSubject(patient);
emsAtSceneObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Add Number of Bullets to composition's Injury and death section.
Observation numOfBulletObs = NvdrsNumberOfBullets.Create();
numOfBulletObs.NvdrsNumberOfBullets().NumOfBullets = 3;
numOfBulletObs.FhirSubject(patient);

// injuryWhenCustody
Observation injuryWhenCustodyObs = NvdrsVictimInCustodyWhenInjured.Create();
injuryWhenCustodyObs.FhirSubject(patient);
injuryWhenCustodyObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Injury Incident
Observation injuryIncident = VrdrInjuryIncident.Create(patient);
injuryIncident.VrdrInjuryIncident().WorkInjuryIndicator = VrclValueSetYesNoUnknownVr.Yes;
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
autopsyPerformedObs.ObservationAutopsyPerformedIndicatorVr().Value = VrclValueSetYesNoUnknownVr.No;

// Add these resources to Injury and Death section.
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(NvdrsCompositionSections.InjuryAndDeath, 
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
 * - Alcohol problem
 * - Clark co specific - drug involvement
 * - Death Abuse
 * - Gang related
 * - Drive by shooting
 */
// Depressed Mode
Observation depressedObs = NvdrsCurrentDepressedMood.Create();
depressedObs.FhirSubject(patient); 
depressedObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Mental Illness
Observation mentalIllnessObs = VdrsHistoryOfMentalIllness.Create();
mentalIllnessObs.FhirSubject(patient); 
mentalIllnessObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Selfharm
Observation selfharmObs = NvdrsHistoryOfSelfHarm.Create();
selfharmObs.FhirSubject(patient);
selfharmObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Random Vielence
Observation randomViolenceObs = NvdrsRandomViolence.Create();
randomViolenceObs.FhirSubject(patient);
randomViolenceObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// School Problem
Observation schoolProblemObs = NvdrsSchoolProblem.Create();
schoolProblemObs.FhirSubject(patient);
schoolProblemObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// History of suicide attempts
Observation suicideAttempts = NvdrsHistoryOfSuicideAttempts.Create();
suicideAttempts.FhirSubject(patient);
suicideAttempts.Value = VrclValueSetYesNoUnknownVr.Yes;

// Alcohol problem
Observation alcoholProblemObs = NvdrsHistoryAlcoholUse.Create();
alcoholProblemObs.FhirSubject(patient);
alcoholProblemObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Clark co specific - drug involvement
Observation drugInvolvementObs = NvdrsCircumstances.Create();
drugInvolvementObs.FhirSubject(patient);
drugInvolvementObs.Code = new(NvdrsCustomCs.officialUrl, "drug-involvement", "Drug Involvement", null);
drugInvolvementObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// DeathAbuse
Observation deathAbuseObs = NvdrsDeathAbuse.Create();
deathAbuseObs.Value = VrclValueSetYesNoUnknownVr.No;

// Gang related observation
Observation gangRelatedObs = NvdrsGangRelated.Create();
gangRelatedObs.FhirSubject(patient);
gangRelatedObs.Value = NvdrsGangRelatedVs.YesGangMotivated;

// Firearm Drive by shooting
Observation driveByShootingObs = NvdrsDriveByShooting.Create();
driveByShootingObs.FhirSubject(patient);
driveByShootingObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Firearm Related observation
Observation playWithFirearmObs = NvdrsPlayingWithFirearm.Create();
playWithFirearmObs.FhirSubject(patient);
playWithFirearmObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Add these resources to Circumstance section.
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(NvdrsCompositionSections.Circumstances, 
    [
        depressedObs, 
        mentalIllnessObs, 
        selfharmObs, 
        randomViolenceObs, 
        schoolProblemObs, 
        suicideAttempts, 
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
 * - Specimen
 */
 // Lab Results for Alcohol, Amphetamine, Benzodiazepines, Cocaine, Opiate
Observation alcoholObs = ObservationToxicologyLabResult.Create();
alcoholObs.FhirSubject(patient);
alcoholObs.ObservationToxicologyLabResult().CodeText = "Alcohol";
alcoholObs.ObservationToxicologyLabResult().ValueText = "4";

Observation amphetamineObs = ObservationToxicologyLabResult.Create();
amphetamineObs.FhirSubject(patient);
amphetamineObs.ObservationToxicologyLabResult().CodeText = "Amphetamine";
amphetamineObs.ObservationToxicologyLabResult().ValueText = "8 mg";

Observation benzodiazepinesObs = ObservationToxicologyLabResult.Create();
benzodiazepinesObs.FhirSubject(patient);
benzodiazepinesObs.ObservationToxicologyLabResult().CodeText = "Benzodiazepines";
benzodiazepinesObs.ObservationToxicologyLabResult().ValueText = "10 mg";

Observation cocaineObs = ObservationToxicologyLabResult.Create();
cocaineObs.FhirSubject(patient);
cocaineObs.ObservationToxicologyLabResult().CodeText = "Cocaine";
cocaineObs.ObservationToxicologyLabResult().ValueText = "9 mg";

Observation opiateObs = ObservationToxicologyLabResult.Create();
opiateObs.FhirSubject(patient);
opiateObs.ObservationToxicologyLabResult().CodeText = "Opiate";
opiateObs.ObservationToxicologyLabResult().ValueText = "11 mg";

// Specimen
Specimen specimen = SpecimenToxicologyLab.Create();
specimen.SpecimenToxicologyLab().SpecimenTypeText = "Bile specimen (specimen)";

// Add these resources to Toxicology section.
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(NvdrsCompositionSections.Toxicology, 
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
 */
// Homeless status
Observation homelessObs = NvdrsHomelessAtDeath.Create();
homelessObs.FhirSubject(patient);
homelessObs.Value = VrclValueSetYesNoUnknownVr.Yes;

// Age at Death
Observation ageAtDeathObs = VrdrDecedentAge.Create(patient);
ageAtDeathObs.Value = new Hl7.Fhir.Model.Quantity() 
{ 
    Value = 24,
    Unit = "a"
};

// Occupation of decedent. We must have occumation if we create this. If occupation is
// unknown, we just do not create this. "Occupation" is not an occupation....
Observation usualWorkObs = OdhUsualWork.Create();
usualWorkObs.FhirSubject(patient);
usualWorkObs.Value = new CodeableConcept() 
{
    Text = "Occupation"
};

Observation.ComponentComponent usualWorkComp = usualWorkObs.Component.GetOrAddComponent("http://loinc.org", "21844-6", "History of Usual industry");
usualWorkComp.Value = new CodeableConcept() { Text = "Occupation"};

// Add these resources to Demographics section
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(NvdrsCompositionSections.Demographics, [homelessObs, ageAtDeathObs, usualWorkObs]);


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
Observation firearmObs = NvdrsFirearm.Create();
// firearmObs.Category.Add(NvdrsCustomCs.Weapons);
firearmObs.NvdrsFirearm().FirearmStolen = VrclValueSetYesNoUnknownVr.Yes;
firearmObs.NvdrsFirearm().FirearmStoredLoaded = VrclValueSetYesNoUnknownVr.Yes;
firearmObs.NvdrsFirearm().SerialNumber = "5555555f";
firearmObs.NvdrsFirearm().FireamrOwner = (null, "Narrative here", firearmOwnerPerson);
firearmObs.NvdrsFirearm().FirearmType = NvdrsFirearmTypeVs.ShotgunUnknownType;
// firearmObs.ObservationFirearm().FirearmMake = NcicFirearmMakeVs.GlockInc;
firearmObs.NvdrsFirearm().FirearmMake = new FhirString("64");
firearmObs.NvdrsFirearm().FirearmModel = "512";
firearmObs.NvdrsFirearm().FirearmCaliber = "556";
firearmObs.FhirSubject(patient);

// Weapon Type
Observation weaponTypeObs = NvdrsWeaponType.Create();
weaponTypeObs.NvdrsWeaponType().FocusOnFirearm = firearmObs;
weaponTypeObs.Value = NvdrsWeaponTypeVs.Firearm;
weaponTypeObs.FhirSubject(patient);

// Add these resources to weapon section.
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(NvdrsCompositionSections.Weapons, [weaponTypeObs]);

/*****************************
 * The follows are cause-manner in MDI compose section or death certification in VRDR.
 * Since this is from CME, we will use MDI definition here.
 * - Causes of death 1 - 4
 * - Other contributing condition
 */
// Causes of Death 1 - 4
Observation causeOfDeathPart1 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Airway Occlusion - Chemical", 1, "minutes");
causeOfDeathPart1.Status = ObservationStatus.Final;
Observation causeOfDeathPart2 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Aspiration of Food - Chemical", 2, "minutes");
causeOfDeathPart2.Status = ObservationStatus.Final;
Observation causeOfDeathPart3 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Burns - Thermal", 3, "minutes");
causeOfDeathPart3.Status = ObservationStatus.Final;
Observation causeOfDeathPart4 = ObservationMdiCauseOfDeathPart1.Create(patient, practitioner, "Cardiac - Ruptured Aortic Aneurysm", 4, "minutes");
causeOfDeathPart4.Status = ObservationStatus.Final;

// Other contributing factor
Observation conditionContributingToDeath = VrdrCauseOfDeathPart2.Create(patient, practitioner);
conditionContributingToDeath.Status = ObservationStatus.Final;
conditionContributingToDeath.VrdrCauseOfDeathPart2().Value = new CodeableConcept(null, null, "other cause");

// Add these resources to cause-manner section.
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(MdiCompositionSections.CauseManner, 
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
deathCertificationProcedure.VrdrDeathCertification().SubjectAsResource = patient;
deathCertificationProcedure.VrdrDeathCertification().AddPerformer(practitioner, VrdrCertifierTypesVs.DeathCertByCME);

// Put these to the jurisdiction section. Use MDI FHIR IG code. 
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(MdiCompositionSections.Jurisdiction, 
    [
        deathCertificationProcedure
    ]);

/***********************************
 * Vital Information about the decedent
 * This can be grouped in the medical-history of MDI FHIR IG. 
 * - Height
 * - Weight
 */
Observation heightObs = new();
heightObs.AddProfile("http://hl7.org/fhir/us/core/StructureDefinition/us-core-body-height");
heightObs.Category =
[
    new("http://terminology.hl7.org/CodeSystem/observation-category", "vital-signs")
];
heightObs.Code = new(UriString.LOINC, "8302-2");
heightObs.Effective = new Hl7.Fhir.Model.Date(2024, 7, 2);
heightObs.Value = new Hl7.Fhir.Model.Quantity() 
{
    Value = (decimal?)2590.8,
    Unit = "cm",
    System = "http://unitsofmeasure.org ",
    Code = "cm"
};

Observation weightObs = new();
weightObs.AddProfile("http://hl7.org/fhir/us/core/StructureDefinition/us-core-body-weight");
weightObs.Category =
[
    new("http://terminology.hl7.org/CodeSystem/observation-category", "vital-signs")
];
weightObs.Code = new(UriString.LOINC, "29463-7");
weightObs.Effective = new Hl7.Fhir.Model.Date(2024, 7, 2);
weightObs.Value = new Hl7.Fhir.Model.Quantity() 
{
    Value = (decimal?)185,
    Unit = "lb_av",
    System = "http://unitsofmeasure.org ",
    Code = "[lb_av]"
};

// Put these to the medical-history section. Use MDI FHIR IG code. 
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(MdiCompositionSections.MedicalHistory, 
    [
        heightObs, 
        weightObs
    ]);

/*******************
 * For another data that are related to death but we do not have sections defined for.
 * The best place to reference these data could be still in the composition.section but
 * we may want to use MDI or VDRD FHIR IG so that we can achieve the interoperability without
 * too much of custom parsing. 
 *
 * For anything that we can't find from the existing code, we put them in the appendix.
 *
 * - Suicide Note  
 * - Number of victims
  */
 // Suicide Note
Observation suicideNoteObs = VdrsSuicideNote.Create();
suicideNoteObs.FhirSubject(patient);   
suicideNoteObs.VdrsSuicideNote().SuicideNote = "Sorry.. I am ...";

// Number of victims
// This is auto-generated in NVDRS (see 1.8 in NVDRS Coding Manual)
Observation numOfVictimObs = VdrsNumberOfVictims.Create();
numOfVictimObs.FhirSubject(patient);
numOfVictimObs.VdrsNumberOfVictims().NumOfVictims = 34;

// Add these resources to Appendix section.
clarkTestComp.NvdrsComposition().AddSectionEntryByCode(NvdrsCompositionSections.Appendix, 
    [
        suicideNoteObs, 
        numOfVictimObs
    ]);


// Create NVDRS Bundle using the composition created above
Bundle nvdrsTestBundle = NvdrsDocumentBundle.Create(clarkTestComp);

FhirJsonSerializer serializer = new(new SerializerSettings() { Pretty = true });
string outputPath = "./";
string output = serializer.SerializeToString(nvdrsTestBundle);
File.WriteAllText(outputPath + "ClarkCounty_NVDRS_bundle_test.json", output);

Console.WriteLine("+--------- Export NVDRS Bundle to Web Input file ---------+");
// Set up if you want to export the NVDRS bundle to NVDRS web input file
FlatObjectCMELE flatObject = new();
nvdrsTestBundle.NvdrsDocumentBundle().ExportToNVDRS(flatObject);

