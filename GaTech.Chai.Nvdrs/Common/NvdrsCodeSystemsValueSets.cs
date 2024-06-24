using GaTech.Chai.Share.Common;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs.Common;

/*
 * NVDRS Code Systems
 */
public class NvdrsNcicGunDataCs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-ncic-gun-data";

    public static CodeableConcept GlockInc_Smyrna_Georgia = new(NvdrsNcicGunDataCs.officialUrl, "GLD", "Glock Inc. (Smyrna, Georgia)", "Subsidiary of original Glock guns manufactured in the USA, NOT Austria");
    public static CodeableConcept GlockInc = new(NvdrsNcicGunDataCs.officialUrl, "GLC", "Glock Inc.", "Original Glock guns manufactured in Austria. See GLD for Glocks manufactured in the USA");
}

public class NvdrsCodingManualCs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-coding-manual-cs";

    public static CodeableConcept AbsentNotWounded = new(NvdrsCodingManualCs.officialUrl, "WoundLocation0", "Absent (not wounded)", null);
    public static CodeableConcept PresentWounded = new(NvdrsCodingManualCs.officialUrl, "WoundLocation1", "Present (wounded)", null);
    public static CodeableConcept NotApplicable = new(NvdrsCodingManualCs.officialUrl, "WoundLocation8", "Not applicable", null);
    public static CodeableConcept NoNotAvailableUnknown = new(NvdrsCodingManualCs.officialUrl, "GangRelated0", "No, Not available, Unknown", null);
    public static CodeableConcept YesGangMotivated = new(NvdrsCodingManualCs.officialUrl, "GangRelated1", "Yes, gang motivated", null);
    public static CodeableConcept YesSusGangMemInv = new(NvdrsCodingManualCs.officialUrl, "GangRelated2", "Yes, suspected gang member involvement", null);
    public static CodeableConcept YesGangRelNotOthSpec = new(NvdrsCodingManualCs.officialUrl, "GangRelated3", "Yes, gang-related not otherwise specified", null);
    public static CodeableConcept OrgCrimeIncMotorcycleGangsMafiaDrugCartels = new(NvdrsCodingManualCs.officialUrl, "GangRelated4", "Organized crime including motorcycle gangs, mafia, and drug cartels", null);
    public static CodeableConcept Firearm = new(NvdrsCodingManualCs.officialUrl, "WeaponType1", "Firearm", null);
    public static CodeableConcept NonPowderGun = new(NvdrsCodingManualCs.officialUrl, "WeaponType5", "Non-powder gun", null);
    public static CodeableConcept SharpInstrument = new(NvdrsCodingManualCs.officialUrl, "WeaponType6", "Sharp instrument", null);
    public static CodeableConcept BluntInstrument = new(NvdrsCodingManualCs.officialUrl, "WeaponType7", "Blunt instrument", null);
    public static CodeableConcept Poisoning = new(NvdrsCodingManualCs.officialUrl, "WeaponType8", "Poisoning", null);
    public static CodeableConcept HangingStrangulationSuffocation = new(NvdrsCodingManualCs.officialUrl, "WeaponType9", "Hanging, strangulation, suffocation", null);
    public static CodeableConcept PersonalWeapons = new(NvdrsCodingManualCs.officialUrl, "WeaponType10", "Personal weapons", null);
    public static CodeableConcept Fall = new(NvdrsCodingManualCs.officialUrl, "WeaponType11", "Fall", null);
    public static CodeableConcept Explosive = new(NvdrsCodingManualCs.officialUrl, "WeaponType12", "Explosive", null);
    public static CodeableConcept Drowning = new(NvdrsCodingManualCs.officialUrl, "WeaponType13", "Drowning", null);
    public static CodeableConcept FireOrBurns = new(NvdrsCodingManualCs.officialUrl, "WeaponType14", "Fire or burns", null);
    public static CodeableConcept Shaking = new(NvdrsCodingManualCs.officialUrl, "WeaponType15", "Shaking (e.g., shaken baby syndrome)", null);
    public static CodeableConcept MotorVehicle = new(NvdrsCodingManualCs.officialUrl, "WeaponType16", "Motor Vehicle, including buses, motorcycles", null);
    public static CodeableConcept OtherTransport = new(NvdrsCodingManualCs.officialUrl, "WeaponType17", "Other transport vehicle, (e.g., trains, planes, boats)", null);
    public static CodeableConcept IntentionalNeglect = new(NvdrsCodingManualCs.officialUrl, "WeaponType18", "Intentional neglect, (e.g., starving a baby or oneself)", null);
    public static CodeableConcept BiologicalWeapons = new(NvdrsCodingManualCs.officialUrl, "WeaponType19", "Biological weapons", null);
    public static CodeableConcept WeaponTypeOther = new(NvdrsCodingManualCs.officialUrl, "WeaponType66", "Other (e.g., Taser, electrocution, nail gun, exposure to environment/weather)", null);
    public static CodeableConcept SubmachineGun = new(NvdrsCodingManualCs.officialUrl, "FirearmType1", "Submachine Gun", null);
    public static CodeableConcept HandgunUnknownType = new(NvdrsCodingManualCs.officialUrl, "FirearmType2", "Handgun, Unknown Type", null);
    public static CodeableConcept HandgunPistolBoltAction = new(NvdrsCodingManualCs.officialUrl, "FirearmType3", "Handgun, Pistol- Bolt Action", null);
    public static CodeableConcept HandgunPistolDerringer = new(NvdrsCodingManualCs.officialUrl, "FirearmType4", "Handgun, Pistol- Derringer", null);
    public static CodeableConcept HandgunPistolSingleShot = new(NvdrsCodingManualCs.officialUrl, "FirearmType5", "Handgun, Pistol- Single Shot", null);
    public static CodeableConcept HandgunPistolSemiAutomatic = new(NvdrsCodingManualCs.officialUrl, "FirearmType6", "Handgun, Pistol- Semi-automatic", null);
    public static CodeableConcept HandgunPistolRevolver = new(NvdrsCodingManualCs.officialUrl, "FirearmType7", "Handgun, Revolver", null);
    public static CodeableConcept RifleUnknownType = new(NvdrsCodingManualCs.officialUrl, "FirearmType8", "Rifle, Unknown Type", null);
    public static CodeableConcept RifleAutomatic = new(NvdrsCodingManualCs.officialUrl, "FirearmType9", "Rifle, Automatic", null);
    public static CodeableConcept RifleBoltAction = new(NvdrsCodingManualCs.officialUrl, "FirearmType10", "Rifle, Bolt Action", null);
    public static CodeableConcept RifleLeverAction = new(NvdrsCodingManualCs.officialUrl, "FirearmType11", "Rifle, Lever Action", null);
    public static CodeableConcept RiflePumpAction = new(NvdrsCodingManualCs.officialUrl, "FirearmType12", "Rifle, Pump Action", null);
    public static CodeableConcept RifleSemiAutomatic = new(NvdrsCodingManualCs.officialUrl, "FirearmType13", "Rifle, Semi-automatic", null);
    public static CodeableConcept RifleSingleShot = new(NvdrsCodingManualCs.officialUrl, "FirearmType14", "Rifle, Single Shot", null);
    public static CodeableConcept RifleShotgunCombination = new(NvdrsCodingManualCs.officialUrl, "FirearmType15", "Rifle-Shotgun Combination", null);
    public static CodeableConcept ShotgunUnknownType = new(NvdrsCodingManualCs.officialUrl, "FirearmType16", "Shotgun, Unknown Type", null);
    public static CodeableConcept ShotgunAutomatic = new(NvdrsCodingManualCs.officialUrl, "FirearmType17", "Shotgun, Automatic", null);
    public static CodeableConcept ShotgunBoltAction = new(NvdrsCodingManualCs.officialUrl, "FirearmType18", "Shotgun, Bolt Action", null);
    public static CodeableConcept ShotgunDoubleBarrel = new(NvdrsCodingManualCs.officialUrl, "FirearmType19", "Shotgun, Double Barrel (Over/Under, Side by Side)", null);
    public static CodeableConcept ShotgunPumpAction = new(NvdrsCodingManualCs.officialUrl, "FirearmType20", "Shotgun, Pump Action", null);
    public static CodeableConcept ShotgunSemiAutomatic = new(NvdrsCodingManualCs.officialUrl, "FirearmType21", "Shotgun, Semi-automatic", null);
    public static CodeableConcept ShotgunSingleShot = new(NvdrsCodingManualCs.officialUrl, "FirearmType22", "Shotgun, Single Shot", null);
    public static CodeableConcept LongGunUnknownType = new(NvdrsCodingManualCs.officialUrl, "FirearmType23", "Long gun, Unknown type", null);
    public static CodeableConcept FirearmTypeOther = new(NvdrsCodingManualCs.officialUrl, "FirearmType66", "Other (e.g., handmade gun)", null);
    public static CodeableConcept Shooter = new(NvdrsCodingManualCs.officialUrl, "GunOwner1", "Shooter", null);
    public static CodeableConcept Parent = new(NvdrsCodingManualCs.officialUrl, "GunOwner2", "Parent of shooter", null);
    public static CodeableConcept OtherFamilyMember = new(NvdrsCodingManualCs.officialUrl, "GunOwner3", "Other family member of shooter", null);
    public static CodeableConcept SpouseIntimatePartner = new(NvdrsCodingManualCs.officialUrl, "GunOwner4", "Spouse/Intimate partner of shooter", null);
    public static CodeableConcept FriendAcquaintance = new(NvdrsCodingManualCs.officialUrl, "GunOwner6", "Friend/Acquaintance of shooter", null);
    public static CodeableConcept Stranger = new(NvdrsCodingManualCs.officialUrl, "GunOwner7", "Stranger to shooter", null);
    public static CodeableConcept OtherSpecify = new(NvdrsCodingManualCs.officialUrl, "GunOwner66", "Other (specify in gun access narrative)", null);
}

public class NvdrsCustomCs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";

    public static CodeableConcept DCReport = new(NvdrsCustomCs.officialUrl, "dc-report", "DC Report", null);
    public static CodeableConcept CMEReport = new(NvdrsCustomCs.officialUrl, "cme-report", "C/ME Report", null);
    public static CodeableConcept ICD10 = new(NvdrsCustomCs.officialUrl, "icd-10", "ICD-10", null);
    public static CodeableConcept Demographics = new(NvdrsCustomCs.officialUrl, "demographics", "Demographics", "Data elements that fall under the demographics category");
    public static CodeableConcept InjuryAndDeath = new(NvdrsCustomCs.officialUrl, "injury-and-death", "Injury and Death", "Data elements that fall under the injury and death category");
    public static CodeableConcept Toxicology = new(NvdrsCustomCs.officialUrl, "toxicology", "Toxicology", "Data elements that fall under the toxicology category");
    public static CodeableConcept Circumstances = new(NvdrsCustomCs.officialUrl, "circumstances", "Circumstances", "Data elements that fall under the circumstances category");
    public static CodeableConcept Weapons = new(NvdrsCustomCs.officialUrl, "weapons", "Weapon(s)", "Data elements that fall under the weapon(s) category");
    public static CodeableConcept Suspects = new(NvdrsCustomCs.officialUrl, "suspects", "Suspect(s)", null);
    public static CodeableConcept Overdose = new(NvdrsCustomCs.officialUrl, "overdose", "Overdose", null);
    public static CodeableConcept WeaponType = new(NvdrsCustomCs.officialUrl, "weapon-type", "Type of Weapon", null);
    public static CodeableConcept Firearm = new(NvdrsCustomCs.officialUrl, "firearm", "Details on Firearm", null);
    public static CodeableConcept FirearmType = new(NvdrsCustomCs.officialUrl, "firearm-type", "Firearm - Type", "The type of the firearm");
    public static CodeableConcept FirearmMake = new(NvdrsCustomCs.officialUrl, "firearm-make", "Firearm - Gun Make or NCIC Code", "The make of the firearm");
    public static CodeableConcept FirearmModel = new(NvdrsCustomCs.officialUrl, "firearm-model", "Firearm - Gun Model", "The model of the firearm");
    public static CodeableConcept FirearmCaliber = new(NvdrsCustomCs.officialUrl, "firearm-caliber", "Firearm - Caliber", "The caliber of the firearm");
    public static CodeableConcept FirearmGauge = new(NvdrsCustomCs.officialUrl, "firearm-gauge", "Firearm - Gauge", "The gauge of the firearm");
    public static CodeableConcept PlayWithFirearm = new(NvdrsCustomCs.officialUrl, "playing-with-firearm", "Playing with Firearm", "Playing with Firearm");
    public static CodeableConcept GangRelated = new(NvdrsCustomCs.officialUrl, "gang-related", "Gang Related", "Death was gang related");
    public static CodeableConcept SelfHarm = new(NvdrsCustomCs.officialUrl, "self-harm", "Non-suicidal self-Injury/self-harm", "History of non-suicidal self-Injury/self-harm");
    public static CodeableConcept Amphetimines = new(NvdrsCustomCs.officialUrl, "amphetimines", "Amphetimines Tested", "Decedent was tested for presence of amphetimines");
    public static CodeableConcept WoundToHead = new(NvdrsCustomCs.officialUrl, "wound-to-the-head", "Wound to the head", null);
    public static CodeableConcept WoundToFace = new(NvdrsCustomCs.officialUrl, "wound-to-the-face", "Wound to the face", null);
    public static CodeableConcept WoundToNeck = new(NvdrsCustomCs.officialUrl, "wound-to-the-neck", "Wound to the neck", null);
    public static CodeableConcept WoundToUpperExtremity = new(NvdrsCustomCs.officialUrl, "wound-to-an-upper-extermity", "Wound to an upper extremity", null);
    public static CodeableConcept WoundToSpine = new(NvdrsCustomCs.officialUrl, "wound-to-the-spine", "Wound to the spine", null);
    public static CodeableConcept WoundToThorax = new(NvdrsCustomCs.officialUrl, "wound-to-the-thorax", "Wound to the thorax", null);
    public static CodeableConcept WoundToAbdomen = new(NvdrsCustomCs.officialUrl, "wound-to-the-abdomen", "Wound to the abdomen", null);
    public static CodeableConcept WoundToLowerExtremity = new(NvdrsCustomCs.officialUrl, "wound-to-a-lower-exterminity", "Wound to a lower extremity", null);
    public static CodeableConcept CurrentDepressedMood = new(NvdrsCustomCs.officialUrl, "current-depressed-mood", "Current depressed mood", null);
    public static CodeableConcept DriveByShooting = new(NvdrsCustomCs.officialUrl, "drive-by-shooting", "Drive-by Shooting", null);
    public static CodeableConcept EmsAtScene = new(NvdrsCustomCs.officialUrl, "ems-at-scene", "EMS at Scene", null);
    public static CodeableConcept HistoryOfSuicideAttempts = new(NvdrsCustomCs.officialUrl, "history-of-suicide-attempts", "History of Suicide Attempts", null);
    public static CodeableConcept HomelessAtDeath = new(NvdrsCustomCs.officialUrl, "homeless-at-death", "Homeless (at time of death)", null);
    public static CodeableConcept RandomViolence = new(NvdrsCustomCs.officialUrl, "random-violence", "Incident is Random Violence", null);
    public static CodeableConcept NumberOfBullets = new(NvdrsCustomCs.officialUrl, "number-of-bullets", "Number of Bullets", null);
    public static CodeableConcept SchoolProblem = new(NvdrsCustomCs.officialUrl, "school-problem", "School Problem", null);
    public static CodeableConcept VictimInCustodyWhenInjured = new(NvdrsCustomCs.officialUrl, "victim-in-custody-when-injured", "Victim in custody when injured", null);
    public static CodeableConcept HistoryOfMentalIllness = new(NvdrsCustomCs.officialUrl, "history-of-mental-illness", "History of Mental Illness", null);
    public static CodeableConcept NumberOfDeaths = new(NvdrsCustomCs.officialUrl, "number-of-deaths", "Number of Deaths", null);
    public static CodeableConcept NumberOfVictims = new(NvdrsCustomCs.officialUrl, "number-of-victims", "Number of Victims (Non Fatal)", null);
    public static CodeableConcept SuicideNote = new(NvdrsCustomCs.officialUrl, "suicide-note", "Suicide Note", null);
}

/*
 * ValueSets
 */
public class NcicFirearmMakeVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/ncic-firearm-make";

    public static CodeableConcept GlockInc_Smyrna_Georgia = NvdrsNcicGunDataCs.GlockInc_Smyrna_Georgia;
    public static CodeableConcept GlockInc = NvdrsNcicGunDataCs.GlockInc;
}

public class NvdrsCircumstancesCategoryVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-circumstances-category-vs";

    public static CodeableConcept PlayWithFirearm = NvdrsCustomCs.PlayWithFirearm;
    public static CodeableConcept GangRelated = NvdrsCustomCs.GangRelated;
    public static CodeableConcept SelfHarm = NvdrsCustomCs.SelfHarm;
}

public class NvdrsGangRelatedVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-gang-related-vs";

    public static CodeableConcept NoNotAvailableUnknown = NvdrsCodingManualCs.NoNotAvailableUnknown;
    public static CodeableConcept YesGangMotivated = NvdrsCodingManualCs.YesGangMotivated;
    public static CodeableConcept YesSusGangMemInv = NvdrsCodingManualCs.YesSusGangMemInv;
    public static CodeableConcept YesGangRelNotOthSpec = NvdrsCodingManualCs.YesGangRelNotOthSpec;
    public static CodeableConcept OrgCrimeIncMotorcycleGangsMafiaDrugCartels = NvdrsCodingManualCs.OrgCrimeIncMotorcycleGangsMafiaDrugCartels;
}

public class NvdrsGunOwnerCodesVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-gun-owner-codes-vs";

    public static CodeableConcept Shooter = NvdrsCodingManualCs.Shooter;
    public static CodeableConcept Parent = NvdrsCodingManualCs.Parent;
    public static CodeableConcept OtherFamilyMember = NvdrsCodingManualCs.OtherFamilyMember;
    public static CodeableConcept SpouseIntimatePartner = NvdrsCodingManualCs.SpouseIntimatePartner;
    public static CodeableConcept FriendAcquaintance = NvdrsCodingManualCs.FriendAcquaintance;
    public static CodeableConcept Stranger = NvdrsCodingManualCs.Stranger;
    public static CodeableConcept OtherSpecify = NvdrsCodingManualCs.OtherSpecify;
    public static CodeableConcept Unknown = new("http://snomed.info/sct", "261665006", "Unknown", null);
}

public class NvdrsDocTypesVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-document-types-vs";

    public static CodeableConcept DCReport = NvdrsCustomCs.DCReport;
    public static CodeableConcept CMEReport = NvdrsCustomCs.CMEReport;
    public static CodeableConcept ICD10 = NvdrsCustomCs.ICD10;
}

public class NvdrsFirearmTypeVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-firearm-type-vs";

    public static CodeableConcept SubmachineGun = NvdrsCodingManualCs.SubmachineGun;
    public static CodeableConcept HandgunUnknownType = NvdrsCodingManualCs.HandgunUnknownType;
    public static CodeableConcept HandgunPistolBoltAction = NvdrsCodingManualCs.HandgunPistolBoltAction;
    public static CodeableConcept HandgunPistolDerringer = NvdrsCodingManualCs.HandgunPistolDerringer;
    public static CodeableConcept HandgunPistolSingleShot = NvdrsCodingManualCs.HandgunPistolSingleShot;
    public static CodeableConcept HandgunPistolSemiAutomatic = NvdrsCodingManualCs.HandgunPistolSemiAutomatic;
    public static CodeableConcept HandgunPistolRevolver = NvdrsCodingManualCs.HandgunPistolRevolver;
    public static CodeableConcept RifleUnknownType = NvdrsCodingManualCs.RifleUnknownType;
    public static CodeableConcept RifleAutomatic = NvdrsCodingManualCs.RifleAutomatic;
    public static CodeableConcept RifleBoltAction = NvdrsCodingManualCs.RifleBoltAction;
    public static CodeableConcept RifleLeverAction = NvdrsCodingManualCs.RifleLeverAction;
    public static CodeableConcept RiflePumpAction = NvdrsCodingManualCs.RiflePumpAction;
    public static CodeableConcept RifleSemiAutomatic = NvdrsCodingManualCs.RifleSemiAutomatic;
    public static CodeableConcept RifleSingleShot = NvdrsCodingManualCs.RifleSingleShot;
    public static CodeableConcept RifleShotgunCombination = NvdrsCodingManualCs.RifleShotgunCombination;
    public static CodeableConcept ShotgunUnknownType = NvdrsCodingManualCs.ShotgunUnknownType;
    public static CodeableConcept ShotgunAutomatic = NvdrsCodingManualCs.ShotgunAutomatic;
    public static CodeableConcept ShotgunBoltAction = NvdrsCodingManualCs.ShotgunBoltAction;
    public static CodeableConcept ShotgunDoubleBarrel = NvdrsCodingManualCs.ShotgunDoubleBarrel;
    public static CodeableConcept ShotgunPumpAction = NvdrsCodingManualCs.ShotgunPumpAction;
    public static CodeableConcept ShotgunSemiAutomatic = NvdrsCodingManualCs.ShotgunSemiAutomatic;
    public static CodeableConcept ShotgunSingleShot = NvdrsCodingManualCs.ShotgunSingleShot;
    public static CodeableConcept LongGunUnknownType = NvdrsCodingManualCs.LongGunUnknownType;
    public static CodeableConcept Other = NvdrsCodingManualCs.FirearmTypeOther;
    public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
}

public class NvdrsWeaponTypeVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-weapon-type-vs";

    public static CodeableConcept Firearm = NvdrsCodingManualCs.Firearm;
    public static CodeableConcept NonPowderGun = NvdrsCodingManualCs.NonPowderGun;
    public static CodeableConcept SharpInstrument = NvdrsCodingManualCs.SharpInstrument;
    public static CodeableConcept BluntInstrument = NvdrsCodingManualCs.BluntInstrument;
    public static CodeableConcept Poisoning = NvdrsCodingManualCs.Poisoning;
    public static CodeableConcept HangingStrangulationSuffocation = NvdrsCodingManualCs.HangingStrangulationSuffocation;
    public static CodeableConcept PersonalWeapons = NvdrsCodingManualCs.PersonalWeapons;
    public static CodeableConcept Fall = NvdrsCodingManualCs.Fall;
    public static CodeableConcept Explosive = NvdrsCodingManualCs.Explosive;
    public static CodeableConcept Drowning = NvdrsCodingManualCs.Drowning;
    public static CodeableConcept FireOrBurns = NvdrsCodingManualCs.FireOrBurns;
    public static CodeableConcept Shaking = NvdrsCodingManualCs.Shaking;
    public static CodeableConcept MotorVehicle = NvdrsCodingManualCs.MotorVehicle;
    public static CodeableConcept OtherTransport = NvdrsCodingManualCs.OtherTransport;
    public static CodeableConcept IntentionalNeglect = NvdrsCodingManualCs.IntentionalNeglect;
    public static CodeableConcept BiologicalWeapons = NvdrsCodingManualCs.BiologicalWeapons;
    public static CodeableConcept Other = NvdrsCodingManualCs.WeaponTypeOther;
    public static CodeableConcept Unknown = new("http://snomed.info/sct", "261665006", "Unknown", null);
}

public class NvdrsWeaponsCategoryVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-weapons-category-vs";

    public static CodeableConcept Firearm = NvdrsCustomCs.Firearm;
    public static CodeableConcept WeaponType = NvdrsCustomCs.WeaponType;
}

public class NvdrsWoundLocationVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-wound-location-vs";

    public static CodeableConcept WoundToHead = NvdrsCustomCs.WoundToHead;
    public static CodeableConcept WoundToFace = NvdrsCustomCs.WoundToFace;
    public static CodeableConcept WoundToNeck = NvdrsCustomCs.WoundToNeck;
    public static CodeableConcept WoundToUpperExtremity = NvdrsCustomCs.WoundToUpperExtremity;
    public static CodeableConcept WoundToSpine = NvdrsCustomCs.WoundToSpine;
    public static CodeableConcept WoundToThorax = NvdrsCustomCs.WoundToThorax;
    public static CodeableConcept WoundToAbdomen = NvdrsCustomCs.WoundToAbdomen;
    public static CodeableConcept WoundToLowerExtremity = NvdrsCustomCs.WoundToLowerExtremity;
}

public class NvdrsWoundLocationValuesVs
{
    public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-wound-location-values-vs";

    public static CodeableConcept AbsentNotWounded = NvdrsCodingManualCs.AbsentNotWounded;
    public static CodeableConcept PresentWounded = NvdrsCodingManualCs.PresentWounded;
    public static CodeableConcept NotApplicable = NvdrsCodingManualCs.NotApplicable;
    public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
}

// public class NvdrsSectionCodes
// {
//     public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";

//     public static CodeableConcept Demographics = new(NvdrsSectionCodes.officialUrl, "demographics", "Demographics", null);
//     public static CodeableConcept InjuryAndDeath = new(NvdrsSectionCodes.officialUrl, "injury-and-death", "Injury and Death", null);
//     public static CodeableConcept Toxicology = new(NvdrsSectionCodes.officialUrl, "toxicology", "Toxicology", null);
//     public static CodeableConcept Circumstances = new(NvdrsSectionCodes.officialUrl, "circumstances", "Circumstances", null);
//     public static CodeableConcept Weapons = new(NvdrsSectionCodes.officialUrl, "weapons", "weapons", null);
//     public static CodeableConcept Overdose = new(NvdrsSectionCodes.officialUrl, "overdose", "Overdose(s)", null);
// }