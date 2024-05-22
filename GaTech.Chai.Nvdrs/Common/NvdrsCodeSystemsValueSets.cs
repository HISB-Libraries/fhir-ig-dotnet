using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs.Common;

public class NvdrsCodeSystem
{
    public class NvdrsDocTypeValueSet
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-document-types-vs";
        public const string systemUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";

        public static CodeableConcept DCReport = new(NvdrsDocTypeValueSet.systemUrl, "dc-report", "DC Report", null);
        public static CodeableConcept CNEReport = new(NvdrsDocTypeValueSet.systemUrl, "cme-report", "C/ME Report", null);
        public static CodeableConcept ICD10 = new(NvdrsDocTypeValueSet.systemUrl, "icd-10", "ICD-10", null);
    }

    public class NvdrsSectionCodes
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";

        public static CodeableConcept Demographics = new(NvdrsCodeSystem.NvdrsSectionCodes.officialUrl, "demographics", "Demographics", null);
        public static CodeableConcept InjuryAndDeath = new(NvdrsCodeSystem.NvdrsSectionCodes.officialUrl, "injury-and-death", "Injury and Death", null);
        public static CodeableConcept Toxicology = new(NvdrsCodeSystem.NvdrsSectionCodes.officialUrl, "toxicology", "Toxicology", null);
        public static CodeableConcept Circumstances = new(NvdrsCodeSystem.NvdrsSectionCodes.officialUrl, "circumstances", "Circumstances", null);
        public static CodeableConcept Weapons = new(NvdrsCodeSystem.NvdrsSectionCodes.officialUrl, "weapons", "weapons", null);
        public static CodeableConcept Overdose = new(NvdrsCodeSystem.NvdrsSectionCodes.officialUrl, "overdose", "Overdose(s)", null);
    }

    public class NvdrsWeaponTypeValueSet
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-weapon-type-vs";
        public const string systemUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-weapon-type-code-system";

        public static CodeableConcept Firearm = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "1", "Firearm", null);
        public static CodeableConcept NonPowderGun = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "5", "Non-powder gun", null);
        public static CodeableConcept SharpInstrument = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "6", "Sharp instrument", null);
        public static CodeableConcept BluntInstrument = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "7", "Blunt instrument", null);
        public static CodeableConcept Poisoning = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "8", "Poisoning", null);
        public static CodeableConcept HangingStrangulationSuffocation = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "9", "Hanging, strangulation, suffocation", null);
        public static CodeableConcept PersonalWeapons = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "10", "Personal weapons", null);
        public static CodeableConcept Fall = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "11", "Fall", null);
        public static CodeableConcept Explosive = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "12", "Explosive", null);
        public static CodeableConcept Drowning = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "13", "Drowning", null);
        public static CodeableConcept FireOrBurns = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "14", "Fire or burns", null);
        public static CodeableConcept Shaking = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "15", "Shaking (e.g., shaken baby syndrome)", null);
        public static CodeableConcept MotorVehicle = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "16", "Motor Vehicle, including buses, motorcycles", null);
        public static CodeableConcept OtherTransport = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "17", "Other transport vehicle, (e.g., trains, planes, boats)", null);
        public static CodeableConcept IntentionalNeglect = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "18", "Intentional neglect, (e.g., starving a baby or oneself)", null);
        public static CodeableConcept BiologicalWeapons = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "19", "Biological weapons", null);
        public static CodeableConcept Other = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "66", "Other (e.g., Taser, electrocution, nail gun, exposure to environment/weather)", null);
        public static CodeableConcept Unknown = new(NvdrsCodeSystem.NvdrsWeaponTypeValueSet.systemUrl, "99", "Unknown", null);
    }

    public class NvdrsFirearmTypeValueSet
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-firearm-type-vs";
        public const string systemUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-firearm-type-code-system";

        public static CodeableConcept SubmachineGun = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "1", "Submachine Gun", null);
        public static CodeableConcept HandgunUnknownType = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "2", "Handgun, Unknown Type", null);
        public static CodeableConcept HandgunPistolBoltAction = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "3", "Handgun, Pistol- Bolt Action", null);
        public static CodeableConcept HandgunPistolDerringer = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "4", "Handgun, Pistol- Derringer", null);
        public static CodeableConcept HandgunPistolSingleShot = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "5", "Handgun, Pistol- Single Shot", null);
        public static CodeableConcept HandgunPistolSemiAutomatic = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "6", "Handgun, Pistol- Semi-automatic", null);
        public static CodeableConcept HandgunPistolRevolver = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "7", "Handgun, Revolver", null);
        public static CodeableConcept RifleUnknownType = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "8", "Rifle, Unknown Type", null);
        public static CodeableConcept RifleAutomatic = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "9", "Rifle, Automatic", null);
        public static CodeableConcept RifleBoltAction = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "10", "Rifle, Bolt Action", null);
        public static CodeableConcept RifleLevelAction = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "11", "Rifle, Lever Action", null);
        public static CodeableConcept RiflePumpAction = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "12", "Rifle, Pump Action", null);
        public static CodeableConcept RifleSemiAutomatic = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "13", "Rifle, Semi-automatic", null);
        public static CodeableConcept RifleSingleShot = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "14", "Rifle, Single Shot", null);
        public static CodeableConcept RifleShotgunCombination = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "15", "Rifle-Shotgun Combination", null);
        public static CodeableConcept ShotgunUnknownType = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "16", "Shotgun, Unknown Type", null);
        public static CodeableConcept ShotgunAutomatic = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "17", "Shotgun, Automatic", null);
        public static CodeableConcept ShotgunBolAction = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "18", "Shotgun, Bolt Action", null);
        public static CodeableConcept ShotgunDoubleBarrel = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "19", "Shotgun, Double Barrel (Over/Under, Side by Side)", null);
        public static CodeableConcept ShotgunPumpAction = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "20", "Shotgun, Pump Action", null);
        public static CodeableConcept ShotgunSemiAutomatic = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "21", "Shotgun, Semi-automatic", null);
        public static CodeableConcept ShotgunSingleShot = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "22", "Shotgun, Single Shot", null);
        public static CodeableConcept LongGunUnknownType = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "23", "Long gun, Unknown type", null);
        public static CodeableConcept Other = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "66", "Other (e.g., handmade gun)", null);
        public static CodeableConcept Unknown = new(NvdrsCodeSystem.NvdrsFirearmTypeValueSet.systemUrl, "99", "Unknown", null);
    }

    public class NvdrsResourceCodes
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";
        public static CodeableConcept Firearm = new(NvdrsCodeSystem.NvdrsResourceCodes.officialUrl, "firearm", "Details on Firearm", null);
        public static CodeableConcept WeaponType = new(NvdrsCodeSystem.NvdrsResourceCodes.officialUrl, "weapon-type", "Type of Weapon", null);
    }

    public class NvdrsGunOwnerCodesValueSet
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/ValueSet/nvdrs-gun-owner-codes-vs";
        public const string systemUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";

        public static CodeableConcept Shooter = new(NvdrsGunOwnerCodesValueSet.systemUrl, "shooter", "Shooter", null);
        public static CodeableConcept Parent = new(NvdrsGunOwnerCodesValueSet.systemUrl, "parent", "Parent of shooter", null);
        public static CodeableConcept OtherFamilyMember = new(NvdrsGunOwnerCodesValueSet.systemUrl, "other-family-member", "Other family member of shooter", null);
        public static CodeableConcept IntimatePartner = new(NvdrsGunOwnerCodesValueSet.systemUrl, "intimate-partner", "Spouse/Intimate partner of shooter", null);
        public static CodeableConcept FriendAcquaintance = new(NvdrsGunOwnerCodesValueSet.systemUrl, "friend-acquaintance", "Friend/Acquaintance of shooter", null);
        public static CodeableConcept Stranger = new(NvdrsGunOwnerCodesValueSet.systemUrl, "friend-acquaintance", "Friend/Acquaintance of shooter", null);
        public static CodeableConcept OtherSpecify = new(NvdrsGunOwnerCodesValueSet.systemUrl, "other-specify", "Other (specify in gun access narrative)", null);
        public static CodeableConcept Unknown = new("http://snomed.info/sct", "261665006", "Unknown", null);
    }

    public class NvdrsFirearmComponentCodes
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";

        public static CodeableConcept FirearmType = new(NvdrsCodeSystem.NvdrsFirearmComponentCodes.officialUrl, "firearm-type", "Firearm - Type", null);
        public static CodeableConcept FirearmMake = new(NvdrsCodeSystem.NvdrsFirearmComponentCodes.officialUrl, "firearm-make", "Firearm - Gun Make or NCIC Code", null);
        public static CodeableConcept FirearmModel = new(NvdrsCodeSystem.NvdrsFirearmComponentCodes.officialUrl, "firearm-model", "Firearm - Gun Model", null);
        public static CodeableConcept FirearmCaliber = new(NvdrsCodeSystem.NvdrsFirearmComponentCodes.officialUrl, "firearm-caliber", "Firearm - Caliber", null);
        public static CodeableConcept FirearmGauge = new(NvdrsCodeSystem.NvdrsFirearmComponentCodes.officialUrl, "firearm-gauge", "Firearm - Gauge", null);
    }

    public class NvdrsCategoryCodes
    {
        public const string officialUrl = "http://mortalityreporting.github.io/nvdrs-ig/CodeSystem/nvdrs-custom-code-system";

        public static CodeableConcept Weapons = new(NvdrsCodeSystem.NvdrsCategoryCodes.officialUrl, "weapons", "Weapon(s)", null);
    }
}
