using GaTech.Chai.Share;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Vdor
{
    /*
     * Vdor Code Systems
     */
    public class VdorNcicGunDataCs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/CodeSystem/vdor-ncic-gun-data";

        public static CodeableConcept GlockInc_Smyrna_Georgia = new(VdorNcicGunDataCs.officialUrl, "GLD", "Glock Inc. (Smyrna, Georgia)", "Subsidiary of original Glock guns manufactured in the USA, NOT Austria");
        public static CodeableConcept GlockInc = new(VdorNcicGunDataCs.officialUrl, "GLC", "Glock Inc.", "Original Glock guns manufactured in Austria. See GLD for Glocks manufactured in the USA");
        public static CodeableConcept _11_11 = new(VdorNcicGunDataCs.officialUrl, "MDX", "11 11, LLC (Christian Soldier/Mason Dixon Arms) Lewisberry, PA", null);
        public static CodeableConcept _144_Tactical = new(VdorNcicGunDataCs.officialUrl, "0FT", "144 Tactical, LLC Brandon, MS", null);
        public static CodeableConcept _17_Design_Manufacturing = new(VdorNcicGunDataCs.officialUrl, "SEV", "17 Design & Manufacturing, LLC, Oklahoma City, Oklahoma", null);
        public static CodeableConcept _2_Vets_Arms_Company = new(VdorNcicGunDataCs.officialUrl, "VSC", "2 Vets Arms Company, LLC Stigler, Oklahoma", null);
        public static CodeableConcept _21_Gun = new(VdorNcicGunDataCs.officialUrl, "TWN", "21 Gun, LLC (Twenty One Gun, LLC) Shelby Township, Michigan", null);
        public static CodeableConcept _252_Armory = new(VdorNcicGunDataCs.officialUrl, "MPH", "252 Armory (Murphy's Coating & Firearms, LLC) Elizabeth City, NC", null);
        public static CodeableConcept _2A_Armament = new(VdorNcicGunDataCs.officialUrl, "TW0", "2A Armament, LLC Boise, Idaho", null);
        public static CodeableConcept _2A_Holdings = new(VdorNcicGunDataCs.officialUrl, "CCT", "2A Holdings, Inc. (Constitution Arms) Maplewood, New Jersey", null);
        public static CodeableConcept _2A_Zone = new(VdorNcicGunDataCs.officialUrl, "AZN", "2A Zone Alta Loma, California", null);
        public static CodeableConcept _3_Lions_Armory = new(VdorNcicGunDataCs.officialUrl, "LNS", "3 Lions Armory, LLC. Monessen, PA", null);
        public static CodeableConcept _3_G_Firearms = new(VdorNcicGunDataCs.officialUrl, "THG", "3-G Firearms (Korenek, Lawrence Daniel) Three Rivers, TX", null);
        public static CodeableConcept _300_Arms = new(VdorNcicGunDataCs.officialUrl, "THB", "300 Arms Inc. Wellington, CO", null);
        public static CodeableConcept Smith_Wesson = new(VdorNcicGunDataCs.officialUrl, "SWT", "Smith & Wesson", null);
        public static CodeableConcept Model_10 = new(VdorNcicGunDataCs.officialUrl, "SWT-10", "Model 10", null);
        public static CodeableConcept Model_19 = new(VdorNcicGunDataCs.officialUrl, "SWT-19", "Model 19", null);
        public static CodeableConcept Model_29 = new(VdorNcicGunDataCs.officialUrl, "SWT-29", "Model 29", null);
        public static CodeableConcept Model_36 = new(VdorNcicGunDataCs.officialUrl, "SWT-36", "Model 36", null);
        public static CodeableConcept Model_59 = new(VdorNcicGunDataCs.officialUrl, "SWT-59", "Model 59", null);
        public static CodeableConcept Model_60 = new(VdorNcicGunDataCs.officialUrl, "SWT-60", "Model 60", null);
        public static CodeableConcept Model_64 = new(VdorNcicGunDataCs.officialUrl, "SWT-64", "Model 64", null);
        public static CodeableConcept Model_66 = new(VdorNcicGunDataCs.officialUrl, "SWT-66", "Model 66", null);
        public static CodeableConcept Model_629 = new(VdorNcicGunDataCs.officialUrl, "SWT-629", "Model 629", null);
        public static CodeableConcept Model_686 = new(VdorNcicGunDataCs.officialUrl, "SWT-686", "Model 686", null);
        public static CodeableConcept M_P9 = new(VdorNcicGunDataCs.officialUrl, "SWT-MP9", "M&P9", null);
        public static CodeableConcept M_P40 = new(VdorNcicGunDataCs.officialUrl, "SWT-MP40", "M&P40", null);
        public static CodeableConcept M_P45 = new(VdorNcicGunDataCs.officialUrl, "SWT-MP45", "M&P45.", null);
        public static CodeableConcept M_P_Shield = new(VdorNcicGunDataCs.officialUrl, "SWT-MPSHLD", "M&P Shield", null);
        public static CodeableConcept M_P_Shield_Plus = new(VdorNcicGunDataCs.officialUrl, "SWT-MPSHLD2", "M&P Shield Plus", null);
        public static CodeableConcept M_P_Compact = new(VdorNcicGunDataCs.officialUrl, "SWT-MPCOMP", "M&P Compact", null);
        public static CodeableConcept SD9_VE = new(VdorNcicGunDataCs.officialUrl, "SWT-SD9", "SD9 VE", null);
        public static CodeableConcept SD40_VE = new(VdorNcicGunDataCs.officialUrl, "SWT-SD40", "SD40 VE", null);
        public static CodeableConcept SW1911 = new(VdorNcicGunDataCs.officialUrl, "SWT-1911", "SW1911", null);
        public static CodeableConcept Model_500 = new(VdorNcicGunDataCs.officialUrl, "SWT-500", "Model 500", null);
        public static CodeableConcept Model_460 = new(VdorNcicGunDataCs.officialUrl, "SWT-460", "Model 460", null);
        public static CodeableConcept Performance_Center = new(VdorNcicGunDataCs.officialUrl, "SWT-PERF", "Performance Center", null);
        public static CodeableConcept Bodyguard_380 = new(VdorNcicGunDataCs.officialUrl, "SWT-BODY", "Bodyguard 380", null);
    }

    public class NvdrsCodingManualCs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/CodeSystem/nvdrs-coding-manual-cs";

        public static CodeableConcept AbsentNotWounded = new(NvdrsCodingManualCs.officialUrl, "WoundLocation0", "Absent (not wounded)", null);
        public static CodeableConcept DrugObtainedFor1 = new(NvdrsCodingManualCs.officialUrl, "DrugObtainedFor1", "Self", null);
        public static CodeableConcept DrugObtainedFor2 = new(NvdrsCodingManualCs.officialUrl, "DrugObtainedFor2", "Intimate Partner", null);
        public static CodeableConcept DrugObtainedFor3 = new(NvdrsCodingManualCs.officialUrl, "DrugObtainedFor3", "Family", "(non-intimate partner)");
        public static CodeableConcept DrugObtainedFor4 = new(NvdrsCodingManualCs.officialUrl, "DrugObtainedFor4", "Other", null);
        public static CodeableConcept DrugObtainedFor8 = new(NvdrsCodingManualCs.officialUrl, "DrugObtainedFor8", "Not applicable", "e.g., not a prescribed drug");
        public static CodeableConcept DrugObtainedFor9 = new(NvdrsCodingManualCs.officialUrl, "DrugObtainedFor9", "Relationship unknown", "Relationship between decedent and the individual the drug was obtained for is not known");
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
        public static CodeableConcept OtherWeaponType = new(NvdrsCodingManualCs.officialUrl, "WeaponType66", "Other (e.g., Taser, electrocution, nail gun, exposure to environment/weather)", null);
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
        public static CodeableConcept FirearmCaliber556 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber556", "5.56 mm", null);
        public static CodeableConcept FirearmCaliber6 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber6", "6 mm", null);
        public static CodeableConcept FirearmCaliber635 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber635", "6.35 mm", null);
        public static CodeableConcept FirearmCaliber65 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber65", "6.5 mm", null);
        public static CodeableConcept FirearmCaliber7 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber7", "7 mm", null);
        public static CodeableConcept FirearmCaliber735 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber735", "7.35 mm", null);
        public static CodeableConcept FirearmCaliber75 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber75", "7.5 mm", null);
        public static CodeableConcept FirearmCaliber762 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber762", "7.62 mm", null);
        public static CodeableConcept FirearmCaliber763 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber763", "7.63 mm", null);
        public static CodeableConcept FirearmCaliber765 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber765", "7.65 mm", null);
        public static CodeableConcept FirearmCaliber8 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber8", "8 mm", null);
        public static CodeableConcept FirearmCaliber9 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber9", "9 mm", null);
        public static CodeableConcept FirearmCaliber10 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber10", "10 mm", null);
        public static CodeableConcept FirearmCaliber11 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber11", "11 mm", null);
        public static CodeableConcept FirearmCaliber17 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber17", ".17 in", null);
        public static CodeableConcept FirearmCaliber22 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber22", ".22 in", null);
        public static CodeableConcept FirearmCaliber221 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber221", ".221 in", null);
        public static CodeableConcept FirearmCaliber222 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber222", ".222 in", null);
        public static CodeableConcept FirearmCaliber223 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber223", ".223 in", null);
        public static CodeableConcept FirearmCaliber243 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber243", ".243 in", null);
        public static CodeableConcept FirearmCaliber25 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber25", ".25 in", null);
        public static CodeableConcept FirearmCaliber250 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber250", ".250 in", null);
        public static CodeableConcept FirearmCaliber256 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber256", ".256 in", null);
        public static CodeableConcept FirearmCaliber257 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber257", ".257 in", null);
        public static CodeableConcept FirearmCaliber264 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber264", ".264 in", null);
        public static CodeableConcept FirearmCaliber270 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber270", ".270 in", null);
        public static CodeableConcept FirearmCaliber280 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber280", ".280 in", null);
        public static CodeableConcept FirearmCaliber284 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber284", ".284 in", null);
        public static CodeableConcept FirearmCaliber30 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber30", ".30 in (including 30-06)", null);
        public static CodeableConcept FirearmCaliber300 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber300", ".300 in", null);
        public static CodeableConcept FirearmCaliber303 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber303", ".303 in", null);
        public static CodeableConcept FirearmCaliber308 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber308", ".308 in", null);
        public static CodeableConcept FirearmCaliber32 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber32", ".32 in", null);
        public static CodeableConcept FirearmCaliber338 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber338", ".338 in", null);
        public static CodeableConcept FirearmCaliber35 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber35", ".35 in", null);
        public static CodeableConcept FirearmCaliber351 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber351", ".351 in", null);
        public static CodeableConcept FirearmCaliber357 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber357", ".357 in", null);
        public static CodeableConcept FirearmCaliber36 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber36", ".36 in", null);
        public static CodeableConcept FirearmCaliber375 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber375", ".375 in", null);
        public static CodeableConcept FirearmCaliber38 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber38", ".38 in", null);
        public static CodeableConcept FirearmCaliber380 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber380", ".380 in", null);
        public static CodeableConcept FirearmCaliber40 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber40", ".40 in", null);
        public static CodeableConcept FirearmCaliber401 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber401", ".401 in", null);
        public static CodeableConcept FirearmCaliber405 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber405", ".405 in", null);
        public static CodeableConcept FirearmCaliber41 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber41", ".41 in", null);
        public static CodeableConcept FirearmCaliber44 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber44", ".44 in", null);
        public static CodeableConcept FirearmCaliber444 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber444", ".444 in", null);
        public static CodeableConcept FirearmCaliber455 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber455", ".455 in", null);
        public static CodeableConcept FirearmCaliber458 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber458", ".458 in", null);
        public static CodeableConcept FirearmCaliber460 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber460", ".460 in", null);
        public static CodeableConcept FirearmCaliber50 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber50", ".50 in", null);
        public static CodeableConcept FirearmCaliber54 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber54", ".54 in", null);
        public static CodeableConcept FirearmCaliber58 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber58", ".58 in", null);
        public static CodeableConcept FirearmCaliber60 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber60", ".60 in", null);
        public static CodeableConcept FirearmCaliber1000 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber1000`", "Undetermined whether .38 or .357", null);
        public static CodeableConcept FirearmCaliber1001 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber1001", "Small, unspecified (<=32)", null);
        public static CodeableConcept FirearmCaliber1002 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber1002", "Medium, unspecified (>32, <10mm/.40)", null);
        public static CodeableConcept FirearmCaliber1003 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber1003", "Large, unspecified (>=10mm/.40)", null);
        public static CodeableConcept FirearmCaliber6666 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber6666", "Other", null);
        public static CodeableConcept FirearmCaliber8888 = new(NvdrsCodingManualCs.officialUrl, "FirearmCaliber8888", "Not applicable (shotgun or unknown gun type)", null);
        public static CodeableConcept FirearmGauge10 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge10", "10 gauge", null);
        public static CodeableConcept FirearmGauge12 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge12", "12 gauge", null);
        public static CodeableConcept FirearmGauge16 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge16", "16 gauge)", null);
        public static CodeableConcept FirearmGauge20 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge20", "20 gauge", null);
        public static CodeableConcept FirearmGauge28 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge28", "28 gauge", null);
        public static CodeableConcept FirearmGauge410 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge410", "0.410 bore", null);
        public static CodeableConcept FirearmGauge666 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge666", "Other", null);
        public static CodeableConcept FirearmGauge888 = new(NvdrsCodingManualCs.officialUrl, "FirearmGauge888", "Not applicable", null);
        public static CodeableConcept Shooter = new(NvdrsCodingManualCs.officialUrl, "GunOwner1", "Shooter", null);
        public static CodeableConcept Parent = new(NvdrsCodingManualCs.officialUrl, "GunOwner2", "Parent of shooter", null);
        public static CodeableConcept OtherFamilyMember = new(NvdrsCodingManualCs.officialUrl, "GunOwner3", "Other family member of shooter", null);
        public static CodeableConcept SpouseIntimatePartner = new(NvdrsCodingManualCs.officialUrl, "GunOwner4", "Spouse/Intimate partner of shooter", null);
        public static CodeableConcept SubstanceResult1 = new(VdorCustomCs.officialUrl, "SubstanceResult1", "Present", null);
        public static CodeableConcept SubstanceResult2 = new(VdorCustomCs.officialUrl, "SubstanceResult2", "Not present", null);
        public static CodeableConcept SubstanceResult8 = new(VdorCustomCs.officialUrl, "SubstanceResult8", "Not applicable", "e.g., Testing was not done");
        public static CodeableConcept FriendAcquaintance = new(NvdrsCodingManualCs.officialUrl, "GunOwner6", "Friend/Acquaintance of shooter", null);
        public static CodeableConcept Stranger = new(NvdrsCodingManualCs.officialUrl, "GunOwner7", "Stranger to shooter", null);
        public static CodeableConcept OtherSpecify = new(NvdrsCodingManualCs.officialUrl, "GunOwner66", "Other (specify in gun access narrative)", null);
        public static CodeableConcept ToxTested1 = new(NvdrsCodingManualCs.officialUrl, "ToxTested1", "Tested", null);
        public static CodeableConcept ToxTested2 = new(NvdrsCodingManualCs.officialUrl, "ToxTested2", "Not tested", null);
    }

    public class VdorCustomCs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/CodeSystem/vdor-custom-code-system";

        public static CodeableConcept DCReport = new(VdorCustomCs.officialUrl, "dc-report", "DC Report", null);
        public static CodeableConcept CMEReport = new(VdorCustomCs.officialUrl, "cme-report", "C/ME Report", null);
        public static CodeableConcept ICD10 = new(VdorCustomCs.officialUrl, "icd-10", "ICD-10", null);
        public static CodeableConcept Demographics = new(VdorCustomCs.officialUrl, "demographics", "Demographics", "Data elements that fall under the demographics category");
        public static CodeableConcept InjuryAndDeath = new(VdorCustomCs.officialUrl, "injury-and-death", "Injury and Death", "Data elements that fall under the injury and death category");
        public static CodeableConcept Toxicology = new(VdorCustomCs.officialUrl, "toxicology", "Toxicology", "Data elements that fall under the toxicology category");
        public static CodeableConcept ToxicologyFindings = new(VdorCustomCs.officialUrl, "toxicology-findings", "Toxicology Findings", null);
        public static CodeableConcept Circumstances = new(VdorCustomCs.officialUrl, "circumstances", "Circumstances", "Data elements that fall under the circumstances category");
        public static CodeableConcept Weapons = new(VdorCustomCs.officialUrl, "weapons", "Weapon(s)", "Data elements that fall under the weapon(s) category");
        public static CodeableConcept Suspects = new(VdorCustomCs.officialUrl, "suspects", "Suspect(s)", null);
        public static CodeableConcept Overdose = new(VdorCustomCs.officialUrl, "overdose", "Overdose", null);
        public static CodeableConcept WeaponType = new(VdorCustomCs.officialUrl, "weapon-type", "Type of Weapon", null);
        public static CodeableConcept Firearm = new(VdorCustomCs.officialUrl, "firearm", "Details on Firearm", null);
        public static CodeableConcept FirearmType = new(VdorCustomCs.officialUrl, "firearm-type", "Firearm - Firearm Type", "The type of the firearm");
        public static CodeableConcept FirearmMake = new(VdorCustomCs.officialUrl, "firearm-make", "Firearm - Gun Make or NCIC Code", "The make of the firearm");
        public static CodeableConcept FirearmModel = new(VdorCustomCs.officialUrl, "firearm-model", "Firearm - Gun Model", "The model of the firearm");
        public static CodeableConcept FirearmCaliber = new(VdorCustomCs.officialUrl, "firearm-caliber", "Firearm - Caliber", "The caliber of the firearm");
        public static CodeableConcept FirearmGauge = new(VdorCustomCs.officialUrl, "firearm-gauge", "Firearm - Gauge", "The gauge of the firearm");
        public static CodeableConcept PlayWithFirearm = new(VdorCustomCs.officialUrl, "playing-with-firearm", "Playing with Firearm", "Playing with Firearm");
        public static CodeableConcept GangRelated = new(VdorCustomCs.officialUrl, "gang-related", "Gang Related", "Death was gang related");
        public static CodeableConcept SelfHarm = new(VdorCustomCs.officialUrl, "self-harm", "Non-suicidal self-Injury/self-harm", "History of non-suicidal self-Injury/self-harm");
        public static CodeableConcept Amphetamines = new(VdorCustomCs.officialUrl, "amphetamines", "Amphetamines Tested", "Decedent was tested for presence of amphetamines");
        public static CodeableConcept CurrentOrPastPrescriptionDrugMisuseOrIllicitDrugUse = new(VdorCustomCs.officialUrl, "od-current-or-past-drug-misuse", "Current or Past Prescription Drug Misuse or Illicit Drug Use", null);
        public static CodeableConcept WoundToHead = new(VdorCustomCs.officialUrl, "wound-to-the-head", "Wound to the head", null);
        public static CodeableConcept WoundToFace = new(VdorCustomCs.officialUrl, "wound-to-the-face", "Wound to the face", null);
        public static CodeableConcept WoundToNeck = new(VdorCustomCs.officialUrl, "wound-to-the-neck", "Wound to the neck", null);
        public static CodeableConcept WoundToUpperExtremity = new(VdorCustomCs.officialUrl, "wound-to-an-upper-extermity", "Wound to an upper extremity", null);
        public static CodeableConcept WoundToSpine = new(VdorCustomCs.officialUrl, "wound-to-the-spine", "Wound to the spine", null);
        public static CodeableConcept WoundToThorax = new(VdorCustomCs.officialUrl, "wound-to-the-thorax", "Wound to the thorax", null);
        public static CodeableConcept WoundToAbdomen = new(VdorCustomCs.officialUrl, "wound-to-the-abdomen", "Wound to the abdomen", null);
        public static CodeableConcept WoundToLowerExtremity = new(VdorCustomCs.officialUrl, "wound-to-a-lower-exterminity", "Wound to a lower extremity", null);
        public static CodeableConcept CurrentDepressedMood = new(VdorCustomCs.officialUrl, "current-depressed-mood", "Current depressed mood", null);
        public static CodeableConcept DriveByShooting = new(VdorCustomCs.officialUrl, "drive-by-shooting", "Drive-by Shooting", null);
        public static CodeableConcept EmsAtScene = new(VdorCustomCs.officialUrl, "ems-at-scene", "EMS at Scene", null);
        public static CodeableConcept HistoryOfSuicideAttempts = new(VdorCustomCs.officialUrl, "history-of-suicide-attempts", "History of Suicide Attempts", null);
        public static CodeableConcept HomelessAtDeath = new(VdorCustomCs.officialUrl, "homeless-at-death", "Homeless (at time of death)", null);
        public static CodeableConcept RandomViolence = new(VdorCustomCs.officialUrl, "random-violence", "Incident is Random Violence", null);
        public static CodeableConcept NumberOfBullets = new(VdorCustomCs.officialUrl, "number-of-bullets", "Number of Bullets", null);
        public static CodeableConcept SchoolProblem = new(VdorCustomCs.officialUrl, "school-problem", "School Problem", null);
        public static CodeableConcept VictimInCustodyWhenInjured = new(VdorCustomCs.officialUrl, "victim-in-custody-when-injured", "Victim in custody when injured", null);
        public static CodeableConcept HistoryOfMentalIllness = new(VdorCustomCs.officialUrl, "history-of-mental-illness", "History of Mental Illness", null);
        public static CodeableConcept NumberOfDeaths = new(VdorCustomCs.officialUrl, "number-of-deaths", "Number of Deaths", null);
        public static CodeableConcept NumberOfVictims = new(VdorCustomCs.officialUrl, "number-of-victims", "Number of Victims (Non Fatal)", null);
        public static CodeableConcept SuicideNoteContent = new(VdorCustomCs.officialUrl, "suicide-note-content", "Suicide Note Content", null);
        public static CodeableConcept DeathAbuse = new(VdorCustomCs.officialUrl, "death-abuse", "Abuse or neglect led to death", null);
        public static CodeableConcept DrugInvolvement = new(VdorCustomCs.officialUrl, "drug-involvement", "Drug Involvement", null);
        public static CodeableConcept PersonLeftASuicideNote = new(VdorCustomCs.officialUrl, "person-left-a-suicide-note", "Person Left a Suicide Note", null);
        public static CodeableConcept AlcoholTestResultBAC = new(VdorCustomCs.officialUrl, "ts-alcohol", "Alcohol Test Result (BAC)", null);
        public static CodeableConcept AmphetaminesTestResult = new(VdorCustomCs.officialUrl, "ts-amphetamines", "Amphetamines Test Result", null);
        public static CodeableConcept AnticonvulsantsTestResult = new(VdorCustomCs.officialUrl, "ts-anticonvulsants", "Anticonvulsants Test Result", null);
        public static CodeableConcept AntidepressantTestResult = new(VdorCustomCs.officialUrl, "ts-antidepressant", "Antidepressant Test Result", null);
        public static CodeableConcept AntipsychoticTestResult = new(VdorCustomCs.officialUrl, "ts-antipsychotic", "Antipsychotic Test Result", null);
        public static CodeableConcept BarbituratesTestResult = new(VdorCustomCs.officialUrl, "ts-barbiturates", "Barbiturates Test Result", null);
        public static CodeableConcept BenzodiazepinesTestResult = new(VdorCustomCs.officialUrl, "ts-benzodiazepines", "Benzodiazepines Test Result", null);
        public static CodeableConcept CarbonMonoxideTestResult = new(VdorCustomCs.officialUrl, "ts-carbonmonoxide", "Carbon Monoxide Test Result and Source", null);
        public static CodeableConcept CocaineTestResult = new(VdorCustomCs.officialUrl, "ts-cocaine", "Cocaine Test Result", null);
        public static CodeableConcept MarijuanaTestResult = new(VdorCustomCs.officialUrl, "ts-marijuana", "Marijuana Test Result", null);
        public static CodeableConcept MuscleRelaxersTestResult = new(VdorCustomCs.officialUrl, "ts-musclerelaxers", "Muscle Relaxers Test Result", null);
        public static CodeableConcept OpiateTestResult = new(VdorCustomCs.officialUrl, "ts-opiate", "Opiate Test Result", null);
        public static CodeableConcept TypeOfOverdosePoisoning = new(VdorCustomCs.officialUrl, "od-type-of-od", "Type of Overdose/poisoning", null);
        public static CodeableConcept TimeDateLastKnownAliveAndWellPreOverdose = new(VdorCustomCs.officialUrl, "od-lnka", "Time/Date Last Known Alive and Well Pre-overdose", null);
        public static CodeableConcept TimeDateFirstFoundUnresponsive = new(VdorCustomCs.officialUrl, "od-ffu", "Time/Date First Found Unresponsive", null);
        public static CodeableConcept PreviousOverdose = new(VdorCustomCs.officialUrl, "od-previous-overdose", "Previous Overdose", null);
        public static CodeableConcept PreviousOverdoseTiming = new(VdorCustomCs.officialUrl, "od-previous-overdose-timing", "Timing of Previous Overdose", null);
        public static CodeableConcept RecentOpioidUseRelapse = new(VdorCustomCs.officialUrl, "od-recent-opioid-use-relapse", "Recent Opioid Use Relapse", null);
        public static CodeableConcept TreatmentForSubstanceUseDisorder = new(VdorCustomCs.officialUrl, "od-treatment-for-substance-use-disorder", "Treatment for Substance Use Disorder", null);
        public static CodeableConcept EvidenceOfDrugUse = new(VdorCustomCs.officialUrl, "od-evidence-of-drug-use", "Evidence of Drug Use", null);
        public static CodeableConcept BystandersPresent = new(VdorCustomCs.officialUrl, "od-bystanders-present", "Bystander(s) Present", null);
        public static CodeableConcept UseOfPrescriptionMorphine = new(VdorCustomCs.officialUrl, "od-use-of-prescription-morphine", "Use of Prescription Morphine", null);
        public static CodeableConcept RecentEmergencyDepartmentVisitOrUrgentCareVisit = new(VdorCustomCs.officialUrl, "od-recent-emergency-department-visit", "Recent Emergency Department Visit or Urgent Care Visit", null);
        public static CodeableConcept OverdoseRelatedToSubstanceUseOrMisuse = new(VdorCustomCs.officialUrl, "od-type-of-od-1", "Overdose related to substance use/misuse", null);
        public static CodeableConcept VictimUnintentionallyTakesADrugOrWrongDosage = new(VdorCustomCs.officialUrl, "od-type-of-od-2", "Victim unintentionally takes a drug or wrong dosage", null);
        public static CodeableConcept Overmedication = new(VdorCustomCs.officialUrl, "od-type-of-od-3", "Overmedication", null);
        public static CodeableConcept TookPrescribedDosage = new(VdorCustomCs.officialUrl, "od-type-of-od-4", "Took prescribed dosage", null);
        public static CodeableConcept OtherPleaseAddInformationToNarrative = new(VdorCustomCs.officialUrl, "od-type-of-od-5", "Other, please add information to narrative", null);
        public static CodeableConcept UnknownTypeOfOD = new(VdorCustomCs.officialUrl, "od-type-of-od-6", "Unknown", null);
        public static CodeableConcept NoPreviousOdReported = new(VdorCustomCs.officialUrl, "od-previous-overdose-1", "No previous overdose reported", null);
        public static CodeableConcept PreviousOdWithinLastMonth = new(VdorCustomCs.officialUrl, "od-previous-overdose-2", "Previous OD within the last month", null);
        public static CodeableConcept PreviousOdOccurredBetweenAMonthAndAYearAgo = new(VdorCustomCs.officialUrl, "od-previous-overdose-3", "Previous OD occurred between a month and a year ago", null);
        public static CodeableConcept PreviousOdOccurredMoreThanAYearAgo = new(VdorCustomCs.officialUrl, "od-previous-overdose-4", "Previous OD occurred more than a year ago", null);
        public static CodeableConcept PreviousOdTimingUnknown = new(VdorCustomCs.officialUrl, "od-previous-overdose-5", "Previous OD, timing unknown", null);
        public static CodeableConcept PreviousOdOccurredBetween0And2DaysEarlier = new(VdorCustomCs.officialUrl, "od-previous-overdose-timing-1", "Previous overdose occurred between 0-2 days earlier", null);
        public static CodeableConcept PreviousOdOccurredBetween3And7DaysEarlier = new(VdorCustomCs.officialUrl, "od-previous-overdose-timing-2", "Previous overdose occurred between 3-7 days earlier", null);
        public static CodeableConcept NoEvidence = new(VdorCustomCs.officialUrl, "od-recent-opioid-use-relapse-0", "No evidence", null);
        public static CodeableConcept RelapseOccurredLessThan2WeeksBeforeFatalOverdose = new(VdorCustomCs.officialUrl, "od-recent-opioid-use-relapse-1", "Relapse occurred < 2 weeks before fatal overdose", null);
        public static CodeableConcept RelapseOccurredBetween2WeeksAndLessThan3MonthsBeforeFatalOverdose = new(VdorCustomCs.officialUrl, "od-recent-opioid-use-relapse-2", "Relapse occurred between 2 weeks and < 3 months before fatal overdose", null);
        public static CodeableConcept RelapseMentionedTimingUnclear = new(VdorCustomCs.officialUrl, "od-recent-opioid-use-relapse-3", "Relapse mentioned, timing unclear", null);
        public static CodeableConcept NoBystandersPresent = new(VdorCustomCs.officialUrl, "od-bystanders-present-1", "No bystanders present", null);
        public static CodeableConcept OneBystanderPresent = new(VdorCustomCs.officialUrl, "od-bystanders-present-2", "1 bystander present", null);
        public static CodeableConcept MultipleBystandersPresent = new(VdorCustomCs.officialUrl, "od-bystanders-present-3", "Multiple bystanders present", null);
        public static CodeableConcept BystandersPresentUnknownNumber = new(VdorCustomCs.officialUrl, "od-bystanders-present-4", "Bystanders present, unknown number", null);
        public static CodeableConcept UnknownIfBystanderPresent = new(VdorCustomCs.officialUrl, "od-bystanders-present-5", "Unknown if bystander present", null);
        public static CodeableConcept None = new(VdorCustomCs.officialUrl, "od-use-of-prescription-morphine-1", "None", null);
        public static CodeableConcept EvidenceOfMorphinePrescriptionDispensedWithinLast30Days = new(VdorCustomCs.officialUrl, "od-use-of-prescription-morphine-2", "Evidence of morphine prescription dispensed within last 30 days", null);
        public static CodeableConcept PrescriptionMorphineFoundAtScene = new(VdorCustomCs.officialUrl, "od-use-of-prescription-morphine-3", "Prescription morphine found at the scene (vials or tablets)", null);
        public static CodeableConcept BothPrescriptionAndSceneEvidence = new(VdorCustomCs.officialUrl, "od-use-of-prescription-morphine-4", "Both prescription and scene evidence of morphine prescription", null);
        public static CodeableConcept OtherEvidence = new(VdorCustomCs.officialUrl, "od-use-of-prescription-morphine-5", "Other evidence (include in narrative)", null);
        public static CodeableConcept NoEvidenceOfTreatment = new(VdorCustomCs.officialUrl, "od-treatment-substance-use-disorder-1", "No evidence of treatment", null);
        public static CodeableConcept CurrentTreatment = new(VdorCustomCs.officialUrl, "od-treatment-substance-use-disorder-2", "Current treatment", null);
        public static CodeableConcept NoCurrentTreatmentButTreatedInPast = new(VdorCustomCs.officialUrl, "od-treatment-substance-use-disorder-3", "No current treatment, but treated in the past", null);
        public static CodeableConcept NoEvidenceOfCurrentOrPastDrugUseMisuse = new(VdorCustomCs.officialUrl, "od-drug-misuse-1", "No evidence of current or past drug use/misuse", null);
        public static CodeableConcept Heroin = new(VdorCustomCs.officialUrl, "od-drug-misuse-2", "Heroin", null);
        public static CodeableConcept PrescriptionOpioids = new(VdorCustomCs.officialUrl, "od-drug-misuse-3", "Prescription opioids", null);
        public static CodeableConcept UnspecifiedOpioids = new(VdorCustomCs.officialUrl, "od-drug-misuse-4", "Unspecified opioids", null);
        public static CodeableConcept Fentanyl = new(VdorCustomCs.officialUrl, "od-drug-misuse-5", "Fentanyl", null);
        public static CodeableConcept Cocaine = new(VdorCustomCs.officialUrl, "od-drug-misuse-6", "Cocaine", null);
        public static CodeableConcept Methamphetamine = new(VdorCustomCs.officialUrl, "od-drug-misuse-7", "Methamphetamine", null);
        public static CodeableConcept Benzodiazepines = new(VdorCustomCs.officialUrl, "od-drug-misuse-8", "Benzodiazepines", null);
        public static CodeableConcept Cannabis = new(VdorCustomCs.officialUrl, "od-drug-misuse-9", "Cannabis (marijuana)", null);
        public static CodeableConcept SubstancesUnspecified = new(VdorCustomCs.officialUrl, "od-drug-misuse-10", "Substance unspecified", null);
        public static CodeableConcept OtherSubstanceSpecify = new(VdorCustomCs.officialUrl, "od-drug-misuse-11", "Other substance - specify", null);
        public static CodeableConcept InpatientOutpatientRehabilitation = new(VdorCustomCs.officialUrl, "od-types-of-substance-use-disorder-treatment-1", "Inpatient/outpatient rehabilitation", null);
        public static CodeableConcept MATWithCognitiveBehavioralTherapy = new(VdorCustomCs.officialUrl, "od-types-of-substance-use-disorder-treatment-2", "Medication-assisted treatment, or MAT (with cognitive/behavioral therapy)", null);
        public static CodeableConcept MATWithoutCognitiveBehavioralTherapy = new(VdorCustomCs.officialUrl, "od-types-of-substance-use-disorder-treatment-3", "Medication-assisted treatment, or MAT (without cognitive/behavioral therapy)", null);
        public static CodeableConcept MATCognitiveBehavioralTherapyUnknown = new(VdorCustomCs.officialUrl, "od-types-of-substance-use-disorder-treatment-4", "Medication-assisted therapy, or MAT (cognitive/behavioral therapy unknown)", null);
        public static CodeableConcept CognitiveBehavioralTherapy = new(VdorCustomCs.officialUrl, "od-types-of-substance-use-disorder-treatment-5", "Cognitive/behavioral therapy", null);
        public static CodeableConcept NarcoticsAnonymous = new(VdorCustomCs.officialUrl, "od-types-of-substance-use-disorder-treatment-6", "Narcotics Anonymous", null);
        public static CodeableConcept OtherSpecify = new(VdorCustomCs.officialUrl, "od-types-of-substance-use-disorder-treatment-7", "Other - specify", null);
        public static CodeableConcept NoEvidenceOfEdOrUrgentCareVisitWithinLastYearBeforeDeath = new(VdorCustomCs.officialUrl, "od-recent-emergency-department-visit-0", "No evidence of ED or urgent care visit within last year before death", null);
        public static CodeableConcept EdOrUrgentCareVisitWithinTheLastMonthBeforeDeath = new(VdorCustomCs.officialUrl, "od-recent-emergency-department-visit-1", "ED or urgent care visit within the last month before death", null);
        public static CodeableConcept EdOrUrgentCareVisitBetweenOneAndThreeMonthsBeforeDeath = new(VdorCustomCs.officialUrl, "od-recent-emergency-department-visit-2", "ED or urgent care visit between one and three months before death", null);
        public static CodeableConcept EdOrUrgentCareVisitBetweenThreeAndSixMonthsBeforeDeath = new(VdorCustomCs.officialUrl, "od-recent-emergency-department-visit-3", "ED or urgent care visit between three and six months before death", null);
        public static CodeableConcept EdOrUrgentCareVisitBetweenSixMonthsAndOneYearBeforeDeath = new(VdorCustomCs.officialUrl, "od-recent-emergency-department-visit-4", "ED or urgent care visit between six months and one year before death", null);
        public static CodeableConcept RecentEdOrUrgentCareVisitNotedTimingUnknown = new(VdorCustomCs.officialUrl, "od-recent-emergency-department-visit-5", "Recent ED or urgent care visit noted, timing unknown", null);
        public static CodeableConcept SubstanceName = new(VdorCustomCs.officialUrl, "substance-name", "Substance Name", null);
        public static CodeableConcept SubstanceTested = new(VdorCustomCs.officialUrl, "substance-tested", "Substance Tested", null);
        public static CodeableConcept SubstanceResult = new(VdorCustomCs.officialUrl, "substance-result", "Substance Result", null);
        public static CodeableConcept SubstanceCausedDeath = new(VdorCustomCs.officialUrl, "substance-caused-death", "Substance Caused Death", null);
        public static CodeableConcept DrugObtainedFor = new(VdorCustomCs.officialUrl, "substance-obtained-for", "Drug Obtained For", null);
        public static CodeableConcept TestPerformed = new(VdorCustomCs.officialUrl, "tox-summary-component-tested", "Test Performed", null);
        public static CodeableConcept TestResults = new(VdorCustomCs.officialUrl, "tox-summary-component-results", "Results", null);
        public static CodeableConcept BloodAlcoholContent = new(VdorCustomCs.officialUrl, "tox-summary-component-bac", "Blood Alcohol Content", null);
        public static CodeableConcept SourceOfCarbonMonoxide = new(VdorCustomCs.officialUrl, "tox-summary-component-co-source", "Source of Carbon Monoxide", null);
        public static CodeableConcept Tested = new(VdorCustomCs.officialUrl, "tox-summary-tested-1", "Tested", null);
        public static CodeableConcept NotTested = new(VdorCustomCs.officialUrl, "tox-summary-tested-2", "Not Tested", null);
        public static CodeableConcept UnknownToxSummaryTested = new(VdorCustomCs.officialUrl, "tox-summary-tested-9", "Unknown", null);
        public static CodeableConcept Present = new(VdorCustomCs.officialUrl, "tox-summary-results-1", "Present", null);
        public static CodeableConcept NotPresent = new(VdorCustomCs.officialUrl, "tox-summary-results-2", "Not Present", null);
        public static CodeableConcept NotApplicableToxSummaryResult = new(VdorCustomCs.officialUrl, "tox-summary-results-8", "Not Applicable", null);
        public static CodeableConcept UnknownToxSummaryResult = new(VdorCustomCs.officialUrl, "tox-summary-results-9", "Unknown", null);
        public static CodeableConcept MotorizedVehicle = new(VdorCustomCs.officialUrl, "tox-summary-carbon-monoxide-1", "Motorized vehicle (e.g., car, truck, bus, motorcycle, boat)", null);
        public static CodeableConcept OtherToxSummaryCarbonMonoxide = new(VdorCustomCs.officialUrl, "tox-summary-carbon-monoxide-2", "Other", null);
        public static CodeableConcept GasToolApplianceHeater = new(VdorCustomCs.officialUrl, "tox-summary-carbon-monoxide-3", "Gas tool/appliance/heater", null);
        public static CodeableConcept GrillOrBarbeque = new(VdorCustomCs.officialUrl, "tox-summary-carbon-monoxide-4", "Grill or barbeque (gas or charcoal, includes hibachi grills)", null);
        public static CodeableConcept Fire = new(VdorCustomCs.officialUrl, "tox-summary-carbon-monoxide-5", "Fire (e.g., house fire)", null);
        public static CodeableConcept NotApplicableToxSummaryCarbonMonoxide = new(VdorCustomCs.officialUrl, "tox-summary-carbon-monoxide-8", "Not applicable", null);
        public static CodeableConcept UnknownToxSummaryCarbonMonoxide = new(VdorCustomCs.officialUrl, "tox-summary-carbon-monoxide-9", "Unknown", null);
    }

    public class VdorNvdrsGunModels
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/CodeSystem/vdor-nvdrs-gun-models";

        // Code systems are not included due to the large number of codes. Please refer to the IG for details: https://build.fhir.org/ig/HL7/fhir-vdor/CodeSystem-vdor-nvdrs-gun-models.html
    }

    /*
     * Vdor Section Codes.
     */
    public class VdorCompositionSections
    {
        public static CodeableConcept Demographics = VdorCustomCs.Demographics;
        public static CodeableConcept InjuryAndDeath = VdorCustomCs.InjuryAndDeath;
        public static CodeableConcept Toxicology = VdorCustomCs.Toxicology;
        public static CodeableConcept Circumstances = VdorCustomCs.Circumstances;
        public static CodeableConcept Weapons = VdorCustomCs.Weapons;
        public static CodeableConcept Suspects = VdorCustomCs.Suspects;
        public static CodeableConcept Overdose = VdorCustomCs.Overdose;
        // Below is not in the IG. Provided as a courtesy if one wants to add references that
        // do not fit in any Vdor, MDI, or VRDR sections to a section for management.
        public static CodeableConcept Appendix = new CodeableConcept("urn:vdrs:document-sections", "appenddix", "Appendix", null);
    }

    /*
     * ValueSets
     */
    public class NcicFirearmMakeVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/ncic-firearm-make";

        public static CodeableConcept GlockInc_Smyrna_Georgia = VdorNcicGunDataCs.GlockInc_Smyrna_Georgia;
        public static CodeableConcept GlockInc = VdorNcicGunDataCs.GlockInc;
        public static CodeableConcept _11_11 = VdorNcicGunDataCs._11_11;
        public static CodeableConcept _144_Tactical = VdorNcicGunDataCs._144_Tactical;
        public static CodeableConcept _17_Design_Manufacturing = VdorNcicGunDataCs._17_Design_Manufacturing;
        public static CodeableConcept _2_Vets_Arms_Company = VdorNcicGunDataCs._2_Vets_Arms_Company;
        public static CodeableConcept _21_Gun = VdorNcicGunDataCs._21_Gun;
        public static CodeableConcept _252_Armory = VdorNcicGunDataCs._252_Armory;
        public static CodeableConcept _2A_Armament = VdorNcicGunDataCs._2A_Armament;
        public static CodeableConcept _2A_Holdings = VdorNcicGunDataCs._2A_Holdings;
        public static CodeableConcept _2A_Zone = VdorNcicGunDataCs._2A_Zone;
        public static CodeableConcept _3_Lions_Armory = VdorNcicGunDataCs._3_Lions_Armory;
        public static CodeableConcept _3_G_Firearms = VdorNcicGunDataCs._3_G_Firearms;
        public static CodeableConcept _300_Arms = VdorNcicGunDataCs._300_Arms;
        public static CodeableConcept Smith_Wesson = VdorNcicGunDataCs.Smith_Wesson;
        public static CodeableConcept Model_10 = VdorNcicGunDataCs.Model_10;
        public static CodeableConcept Model_19 = VdorNcicGunDataCs.Model_19;
        public static CodeableConcept Model_29 = VdorNcicGunDataCs.Model_29;
        public static CodeableConcept Model_36 = VdorNcicGunDataCs.Model_36;
        public static CodeableConcept Model_59 = VdorNcicGunDataCs.Model_59;
        public static CodeableConcept Model_60 = VdorNcicGunDataCs.Model_60;
        public static CodeableConcept Model_64 = VdorNcicGunDataCs.Model_64;
        public static CodeableConcept Model_66 = VdorNcicGunDataCs.Model_66;
        public static CodeableConcept Model_629 = VdorNcicGunDataCs.Model_629;
        public static CodeableConcept Model_686 = VdorNcicGunDataCs.Model_686;
        public static CodeableConcept M_P9 = VdorNcicGunDataCs.M_P9;
        public static CodeableConcept M_P40 = VdorNcicGunDataCs.M_P40;
        public static CodeableConcept M_P45 = VdorNcicGunDataCs.M_P45;
        public static CodeableConcept M_P_Shield = VdorNcicGunDataCs.M_P_Shield;
        public static CodeableConcept M_P_Shield_Plus = VdorNcicGunDataCs.M_P_Shield_Plus;
        public static CodeableConcept M_P_Compact = VdorNcicGunDataCs.M_P_Compact;
        public static CodeableConcept SD9_VE = VdorNcicGunDataCs.SD9_VE;
        public static CodeableConcept SD40_VE = VdorNcicGunDataCs.SD40_VE;
        public static CodeableConcept SW1911 = VdorNcicGunDataCs.SW1911;
        public static CodeableConcept Model_500 = VdorNcicGunDataCs.Model_500;
        public static CodeableConcept Model_460 = VdorNcicGunDataCs.Model_460;
        public static CodeableConcept Performance_Center = VdorNcicGunDataCs.Performance_Center;
        public static CodeableConcept Bodyguard_380 = VdorNcicGunDataCs.Bodyguard_380;
    }

    public class VdorCircumstancesCategoryVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-circumstances-category-vs";

        public static CodeableConcept PlayWithFirearm = VdorCustomCs.PlayWithFirearm;
        public static CodeableConcept GangRelated = VdorCustomCs.GangRelated;
        public static CodeableConcept SelfHarm = VdorCustomCs.SelfHarm;
        public static CodeableConcept DeathAbuse = VdorCustomCs.DeathAbuse;
        public static CodeableConcept CurrentDepressedMood = VdorCustomCs.CurrentDepressedMood;
        public static CodeableConcept RandomViolence = VdorCustomCs.RandomViolence;
        public static CodeableConcept SchoolProblem = VdorCustomCs.SchoolProblem;
        public static CodeableConcept HistoryOfSuicideAttempts = VdorCustomCs.HistoryOfSuicideAttempts;
        public static CodeableConcept DriveByShooting = VdorCustomCs.DriveByShooting;
        public static CodeableConcept DrugInvolvement = VdorCustomCs.DrugInvolvement;
        public static CodeableConcept PersonLeftASuicideNote = VdorCustomCs.PersonLeftASuicideNote;
        public static CodeableConcept HistoryOfAlcoholUse = new(UriString.SCT, "11331-6", "History of Alcohol use", null);
    }

    public class NvdrsGangRelatedVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-gang-related-vs";

        public static CodeableConcept NoNotAvailableUnknown = NvdrsCodingManualCs.NoNotAvailableUnknown;
        public static CodeableConcept YesGangMotivated = NvdrsCodingManualCs.YesGangMotivated;
        public static CodeableConcept YesSusGangMemInv = NvdrsCodingManualCs.YesSusGangMemInv;
        public static CodeableConcept YesGangRelNotOthSpec = NvdrsCodingManualCs.YesGangRelNotOthSpec;
        public static CodeableConcept OrgCrimeIncMotorcycleGangsMafiaDrugCartels = NvdrsCodingManualCs.OrgCrimeIncMotorcycleGangsMafiaDrugCartels;
    }

    public class VdorGunOwnerCodesVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-gun-owner-codes-vs";

        public static CodeableConcept Shooter = NvdrsCodingManualCs.Shooter;
        public static CodeableConcept Parent = NvdrsCodingManualCs.Parent;
        public static CodeableConcept OtherFamilyMember = NvdrsCodingManualCs.OtherFamilyMember;
        public static CodeableConcept SpouseIntimatePartner = NvdrsCodingManualCs.SpouseIntimatePartner;
        public static CodeableConcept FriendAcquaintance = NvdrsCodingManualCs.FriendAcquaintance;
        public static CodeableConcept Stranger = NvdrsCodingManualCs.Stranger;
        public static CodeableConcept OtherSpecify = NvdrsCodingManualCs.OtherSpecify;
        public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
    }

    public class NvdrsFirearmModelVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-firearm-model-vs";

        // actual values are not included because they are database values. See IG for details.
        // https://build.fhir.org/ig/HL7/fhir-vdor/ValueSet-nvdrs-firearm-model-vs.html

    }

    public class NvdrsDocTypesVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-document-types-vs";

        public static CodeableConcept DCReport = VdorCustomCs.DCReport;
        public static CodeableConcept CMEReport = VdorCustomCs.CMEReport;
        public static CodeableConcept ICD10 = VdorCustomCs.ICD10;
    }

    public class NvdrsFirearmTypeVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-firearm-type-vs";

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

    public class NvdrsFirearmCaliberVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-firearm-caliber-vs";

        public static CodeableConcept FirearmCaliber556 = NvdrsCodingManualCs.FirearmCaliber556;
        public static CodeableConcept FirearmCaliber6 = NvdrsCodingManualCs.FirearmCaliber6;
        public static CodeableConcept FirearmCaliber635 = NvdrsCodingManualCs.FirearmCaliber635;
        public static CodeableConcept FirearmCaliber65 = NvdrsCodingManualCs.FirearmCaliber65;
        public static CodeableConcept FirearmCaliber7 = NvdrsCodingManualCs.FirearmCaliber7;
        public static CodeableConcept FirearmCaliber735 = NvdrsCodingManualCs.FirearmCaliber735;
        public static CodeableConcept FirearmCaliber75 = NvdrsCodingManualCs.FirearmCaliber75;
        public static CodeableConcept FirearmCaliber762 = NvdrsCodingManualCs.FirearmCaliber762;
        public static CodeableConcept FirearmCaliber763 = NvdrsCodingManualCs.FirearmCaliber763;
        public static CodeableConcept FirearmCaliber765 = NvdrsCodingManualCs.FirearmCaliber765;
        public static CodeableConcept FirearmCaliber8 = NvdrsCodingManualCs.FirearmCaliber8;
        public static CodeableConcept FirearmCaliber9 = NvdrsCodingManualCs.FirearmCaliber9;
        public static CodeableConcept FirearmCaliber10 = NvdrsCodingManualCs.FirearmCaliber10;
        public static CodeableConcept FirearmCaliber11 = NvdrsCodingManualCs.FirearmCaliber11;
        public static CodeableConcept FirearmCaliber17 = NvdrsCodingManualCs.FirearmCaliber17;
        public static CodeableConcept FirearmCaliber22 = NvdrsCodingManualCs.FirearmCaliber22;
        public static CodeableConcept FirearmCaliber221 = NvdrsCodingManualCs.FirearmCaliber221;
        public static CodeableConcept FirearmCaliber222 = NvdrsCodingManualCs.FirearmCaliber222;
        public static CodeableConcept FirearmCaliber223 = NvdrsCodingManualCs.FirearmCaliber223;
        public static CodeableConcept FirearmCaliber243 = NvdrsCodingManualCs.FirearmCaliber243;
        public static CodeableConcept FirearmCaliber25 = NvdrsCodingManualCs.FirearmCaliber25;
        public static CodeableConcept FirearmCaliber250 = NvdrsCodingManualCs.FirearmCaliber250;
        public static CodeableConcept FirearmCaliber256 = NvdrsCodingManualCs.FirearmCaliber256;
        public static CodeableConcept FirearmCaliber257 = NvdrsCodingManualCs.FirearmCaliber257;
        public static CodeableConcept FirearmCaliber264 = NvdrsCodingManualCs.FirearmCaliber264;
        public static CodeableConcept FirearmCaliber270 = NvdrsCodingManualCs.FirearmCaliber270;
        public static CodeableConcept FirearmCaliber280 = NvdrsCodingManualCs.FirearmCaliber280;
        public static CodeableConcept FirearmCaliber284 = NvdrsCodingManualCs.FirearmCaliber284;
        public static CodeableConcept FirearmCaliber30 = NvdrsCodingManualCs.FirearmCaliber30;
        public static CodeableConcept FirearmCaliber300 = NvdrsCodingManualCs.FirearmCaliber300;
        public static CodeableConcept FirearmCaliber303 = NvdrsCodingManualCs.FirearmCaliber303;
        public static CodeableConcept FirearmCaliber308 = NvdrsCodingManualCs.FirearmCaliber308;
        public static CodeableConcept FirearmCaliber32 = NvdrsCodingManualCs.FirearmCaliber32;
        public static CodeableConcept FirearmCaliber338 = NvdrsCodingManualCs.FirearmCaliber338;
        public static CodeableConcept FirearmCaliber35 = NvdrsCodingManualCs.FirearmCaliber35;
        public static CodeableConcept FirearmCaliber351 = NvdrsCodingManualCs.FirearmCaliber351;
        public static CodeableConcept FirearmCaliber357 = NvdrsCodingManualCs.FirearmCaliber357;
        public static CodeableConcept FirearmCaliber36 = NvdrsCodingManualCs.FirearmCaliber36;
        public static CodeableConcept FirearmCaliber375 = NvdrsCodingManualCs.FirearmCaliber375;
        public static CodeableConcept FirearmCaliber38 = NvdrsCodingManualCs.FirearmCaliber38;
        public static CodeableConcept FirearmCaliber380 = NvdrsCodingManualCs.FirearmCaliber380;
        public static CodeableConcept FirearmCaliber40 = NvdrsCodingManualCs.FirearmCaliber40;
        public static CodeableConcept FirearmCaliber401 = NvdrsCodingManualCs.FirearmCaliber401;
        public static CodeableConcept FirearmCaliber405 = NvdrsCodingManualCs.FirearmCaliber405;
        public static CodeableConcept FirearmCaliber41 = NvdrsCodingManualCs.FirearmCaliber41;
        public static CodeableConcept FirearmCaliber44 = NvdrsCodingManualCs.FirearmCaliber44;
        public static CodeableConcept FirearmCaliber444 = NvdrsCodingManualCs.FirearmCaliber444;
        public static CodeableConcept FirearmCaliber455 = NvdrsCodingManualCs.FirearmCaliber455;
        public static CodeableConcept FirearmCaliber458 = NvdrsCodingManualCs.FirearmCaliber458;
        public static CodeableConcept FirearmCaliber460 = NvdrsCodingManualCs.FirearmCaliber460;
        public static CodeableConcept FirearmCaliber50 = NvdrsCodingManualCs.FirearmCaliber50;
        public static CodeableConcept FirearmCaliber54 = NvdrsCodingManualCs.FirearmCaliber54;
        public static CodeableConcept FirearmCaliber58 = NvdrsCodingManualCs.FirearmCaliber58;
        public static CodeableConcept FirearmCaliber60 = NvdrsCodingManualCs.FirearmCaliber60;
        public static CodeableConcept FirearmCaliber1000 = NvdrsCodingManualCs.FirearmCaliber1000;
        public static CodeableConcept FirearmCaliber1001 = NvdrsCodingManualCs.FirearmCaliber1001;
        public static CodeableConcept FirearmCaliber1002 = NvdrsCodingManualCs.FirearmCaliber1002;
        public static CodeableConcept FirearmCaliber1003 = NvdrsCodingManualCs.FirearmCaliber1003;
        public static CodeableConcept FirearmCaliber6666 = NvdrsCodingManualCs.FirearmCaliber6666;
        public static CodeableConcept FirearmCaliber8888 = NvdrsCodingManualCs.FirearmCaliber8888;
        public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
    }

    public class NvdrsFirearmGaugeVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-firearm-gauge-vs";

        public static CodeableConcept FirearmGauge10 = NvdrsCodingManualCs.FirearmGauge10;
        public static CodeableConcept FirearmGauge12 = NvdrsCodingManualCs.FirearmGauge12;
        public static CodeableConcept FirearmGauge16 = NvdrsCodingManualCs.FirearmGauge16;
        public static CodeableConcept FirearmGauge20 = NvdrsCodingManualCs.FirearmGauge20;
        public static CodeableConcept FirearmGauge28 = NvdrsCodingManualCs.FirearmGauge28;
        public static CodeableConcept FirearmGauge410 = NvdrsCodingManualCs.FirearmGauge410;
        public static CodeableConcept FirearmGauge666 = NvdrsCodingManualCs.FirearmGauge666;
        public static CodeableConcept FirearmGauge888 = NvdrsCodingManualCs.FirearmGauge888;
        public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
    }

    public class NvdrsWeaponTypeVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-weapon-type-vs";

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
        public static CodeableConcept Other = NvdrsCodingManualCs.OtherWeaponType;
        public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
    }

    public class VdorToxSubstanceTestedVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-substance-tested-vs";

        public static CodeableConcept Tested = NvdrsCodingManualCs.ToxTested1;
        public static CodeableConcept NotTested = NvdrsCodingManualCs.ToxTested2;
        public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
    }

    public class VdorToxFindingsSubstanceResultsVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-findings-substance-results-vs";

        public static CodeableConcept Present = NvdrsCodingManualCs.SubstanceResult1;
        public static CodeableConcept NotPresent = NvdrsCodingManualCs.SubstanceResult2;
        public static CodeableConcept NotApplicable = NvdrsCodingManualCs.SubstanceResult8;
        public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
    }

    public class VdorToxFindingsDrugObtainedForVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-findings-drug-obtained-for-vs";

        public static CodeableConcept Self = NvdrsCodingManualCs.DrugObtainedFor1;
        public static CodeableConcept IntimatePartner = NvdrsCodingManualCs.DrugObtainedFor2;
        public static CodeableConcept Family = NvdrsCodingManualCs.DrugObtainedFor3;
        public static CodeableConcept Other = NvdrsCodingManualCs.DrugObtainedFor4;
        public static CodeableConcept NotApplicable = NvdrsCodingManualCs.DrugObtainedFor8;
        public static CodeableConcept RelationshipUnknown = NvdrsCodingManualCs.DrugObtainedFor9;
    }

    public class VdorWeaponsCategoryVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-weapons-category-vs";

        public static CodeableConcept Firearm = VdorCustomCs.Firearm;
        public static CodeableConcept WeaponType = VdorCustomCs.WeaponType;
    }

    public class VdorWoundLocationVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-wound-location-vs";

        public static CodeableConcept WoundToHead = VdorCustomCs.WoundToHead;
        public static CodeableConcept WoundToFace = VdorCustomCs.WoundToFace;
        public static CodeableConcept WoundToNeck = VdorCustomCs.WoundToNeck;
        public static CodeableConcept WoundToUpperExtremity = VdorCustomCs.WoundToUpperExtremity;
        public static CodeableConcept WoundToSpine = VdorCustomCs.WoundToSpine;
        public static CodeableConcept WoundToThorax = VdorCustomCs.WoundToThorax;
        public static CodeableConcept WoundToAbdomen = VdorCustomCs.WoundToAbdomen;
        public static CodeableConcept WoundToLowerExtremity = VdorCustomCs.WoundToLowerExtremity;
    }

    public class VdorBystandersPresentVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-bystanders-present-vs";

        public static CodeableConcept NoBystandersPresent = VdorCustomCs.NoBystandersPresent;
        public static CodeableConcept OneBystanderPresent = VdorCustomCs.OneBystanderPresent;
        public static CodeableConcept MultipleBystandersPresent = VdorCustomCs.MultipleBystandersPresent;
        public static CodeableConcept BystandersPresentUnknownNumber = VdorCustomCs.BystandersPresentUnknownNumber;
        public static CodeableConcept UnknownIfBystanderPresent = VdorCustomCs.UnknownIfBystanderPresent;
    }

    public class VdorDrugMisuseVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-drug-misuse-vs";

        public static CodeableConcept NoEvidenceOfCurrentOrPastDrugUseMisuse = VdorCustomCs.NoEvidenceOfCurrentOrPastDrugUseMisuse;
        public static CodeableConcept Heroin = VdorCustomCs.Heroin;
        public static CodeableConcept PrescriptionOpioids = VdorCustomCs.PrescriptionOpioids;
        public static CodeableConcept UnspecifiedOpioids = VdorCustomCs.UnspecifiedOpioids;
        public static CodeableConcept Fentanyl = VdorCustomCs.Fentanyl;
        public static CodeableConcept Cocaine = VdorCustomCs.Cocaine;
        public static CodeableConcept Methamphetamine = VdorCustomCs.Methamphetamine;
        public static CodeableConcept Benzodiazepines = VdorCustomCs.Benzodiazepines;
        public static CodeableConcept Cannabis = VdorCustomCs.Cannabis;
        public static CodeableConcept SubstancesUnspecified = VdorCustomCs.SubstancesUnspecified;
        public static CodeableConcept OtherSubstanceSpecify = VdorCustomCs.OtherSubstanceSpecify;
    }

    public class VdorPreviousOverdoseVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-previous-overdose-vs";

        public static CodeableConcept NoPreviousOdReported = VdorCustomCs.NoPreviousOdReported;
        public static CodeableConcept PreviousOdWithinLastMonth = VdorCustomCs.PreviousOdWithinLastMonth;
        public static CodeableConcept PreviousOdOccurredBetweenAMonthAndAYearAgo = VdorCustomCs.PreviousOdOccurredBetweenAMonthAndAYearAgo;
        public static CodeableConcept PreviousOdOccurredMoreThanAYearAgo = VdorCustomCs.PreviousOdOccurredMoreThanAYearAgo;
        public static CodeableConcept PreviousOdTimingUnknown = VdorCustomCs.PreviousOdTimingUnknown;
    }

    public class VdorTypeOfOverdoseVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-type-of-overdose-vs";

        public static CodeableConcept OverdoseRelatedToSubstanceUseOrMisuse = VdorCustomCs.OverdoseRelatedToSubstanceUseOrMisuse;
        public static CodeableConcept VictimUnintentionallyTakesADrugOrWrongDosage = VdorCustomCs.VictimUnintentionallyTakesADrugOrWrongDosage;
        public static CodeableConcept Overmedication = VdorCustomCs.Overmedication;
        public static CodeableConcept TookPrescribedDosage = VdorCustomCs.TookPrescribedDosage;
        public static CodeableConcept OtherPleaseAddInformationToNarrative = VdorCustomCs.OtherPleaseAddInformationToNarrative;
        public static CodeableConcept UnknownTypeOfOD = VdorCustomCs.UnknownTypeOfOD;
    }

    public class VdorPreviousOverdoseTimingVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-previous-overdose-timing-vs";

        public static CodeableConcept PreviousOdOccurredBetween0And2DaysEarlier = VdorCustomCs.PreviousOdOccurredBetween0And2DaysEarlier;
        public static CodeableConcept PreviousOdOccurredBetween3And7DaysEarlier = VdorCustomCs.PreviousOdOccurredBetween3And7DaysEarlier;
    }

    public class VdorRecentEmergencyDepartmentVisitVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-recent-emergency-department-visit-vs";

        public static CodeableConcept NoEvidenceOfEdOrUrgentCareVisitWithinLastYearBeforeDeath = VdorCustomCs.NoEvidenceOfEdOrUrgentCareVisitWithinLastYearBeforeDeath;
        public static CodeableConcept EdOrUrgentCareVisitWithinTheLastMonthBeforeDeath = VdorCustomCs.EdOrUrgentCareVisitWithinTheLastMonthBeforeDeath;
        public static CodeableConcept EdOrUrgentCareVisitBetweenOneAndThreeMonthsBeforeDeath = VdorCustomCs.EdOrUrgentCareVisitBetweenOneAndThreeMonthsBeforeDeath;
        public static CodeableConcept EdOrUrgentCareVisitBetweenThreeAndSixMonthsBeforeDeath = VdorCustomCs.EdOrUrgentCareVisitBetweenThreeAndSixMonthsBeforeDeath;
        public static CodeableConcept EdOrUrgentCareVisitBetweenSixMonthsAndOneYearBeforeDeath = VdorCustomCs.EdOrUrgentCareVisitBetweenSixMonthsAndOneYearBeforeDeath;
        public static CodeableConcept RecentEdOrUrgentCareVisitNotedTimingUnknown = VdorCustomCs.RecentEdOrUrgentCareVisitNotedTimingUnknown;
    }

    public class VdorRecentOpioidUseRelapseVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-recent-opiod-use-relapse-vs";

        public static CodeableConcept OverdoseRelatedToSubstanceUseOrMisuse = VdorCustomCs.OverdoseRelatedToSubstanceUseOrMisuse;
        public static CodeableConcept NoEvidence = VdorCustomCs.NoEvidence;
        public static CodeableConcept RelapseOccurredLessThan2WeeksBeforeFatalOverdose = VdorCustomCs.RelapseOccurredLessThan2WeeksBeforeFatalOverdose;
        public static CodeableConcept RelapseOccurredBetween2WeeksAndLessThan3MonthsBeforeFatalOverdose = VdorCustomCs.RelapseOccurredBetween2WeeksAndLessThan3MonthsBeforeFatalOverdose;
        public static CodeableConcept RelapseMentionedTimingUnclear = VdorCustomCs.RelapseMentionedTimingUnclear;
    }

    public class VdorToxicologySummaryCarbonMonoxideSourceVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-summary-carbon-monoxide-source-vs";

        public static CodeableConcept MotorizedVehicle = VdorCustomCs.MotorizedVehicle;
        public static CodeableConcept Other = VdorCustomCs.OtherToxSummaryCarbonMonoxide;
        public static CodeableConcept GasToolApplianceHeater = VdorCustomCs.GasToolApplianceHeater;
        public static CodeableConcept GrillOrBarbeque = VdorCustomCs.GrillOrBarbeque;
        public static CodeableConcept Fire = VdorCustomCs.Fire;
        public static CodeableConcept NotApplicable = VdorCustomCs.NotApplicableToxSummaryCarbonMonoxide;
        public static CodeableConcept Unknown = VdorCustomCs.UnknownToxSummaryCarbonMonoxide;
    }

    public class VdorToxSummaryResultsVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-summary-results-vs";
        public static CodeableConcept Present = VdorCustomCs.Present;
        public static CodeableConcept NotPresent = VdorCustomCs.NotPresent;
        public static CodeableConcept NotApplicableToxSummaryResult = VdorCustomCs.NotApplicableToxSummaryResult;
        public static CodeableConcept Unknown = VdorCustomCs.UnknownToxSummaryResult;
    }

    public class VdorToxSummaryTestedVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-tox-summary-tested-vs";

        public static CodeableConcept Tested = VdorCustomCs.Tested;
        public static CodeableConcept NotTested = VdorCustomCs.NotTested;
        public static CodeableConcept Unknown = VdorCustomCs.UnknownToxSummaryTested;
    }

    public class VdorToxicologySummaryTestsVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-toxicology-summary-tests-vs";

        public static CodeableConcept AlcoholTestResultBAC = VdorCustomCs.AlcoholTestResultBAC;
        public static CodeableConcept AmphetaminesTestResult = VdorCustomCs.AmphetaminesTestResult;
        public static CodeableConcept AnticonvulsantsTestResult = VdorCustomCs.AnticonvulsantsTestResult;
        public static CodeableConcept AntidepressantTestResult = VdorCustomCs.AntidepressantTestResult;
        public static CodeableConcept AntipsychoticTestResult = VdorCustomCs.AntipsychoticTestResult;
        public static CodeableConcept BarbituratesTestResult = VdorCustomCs.BarbituratesTestResult;
        public static CodeableConcept BenzodiazepinesTestResult = VdorCustomCs.BenzodiazepinesTestResult;
        public static CodeableConcept CarbonMonoxideTestResult = VdorCustomCs.CarbonMonoxideTestResult;
        public static CodeableConcept CocaineTestResult = VdorCustomCs.CocaineTestResult;
        public static CodeableConcept MarijuanaTestResult = VdorCustomCs.MarijuanaTestResult;
        public static CodeableConcept MuscleRelaxersTestResult = VdorCustomCs.MuscleRelaxersTestResult;
        public static CodeableConcept OpiateTestResult = VdorCustomCs.OpiateTestResult;
    }

    public class VdorTreatmentForSubstanceUseDisorderVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-treatment-for-substance-use-disorder-vs";

        public static CodeableConcept NoEvidenceOfTreatment = VdorCustomCs.NoEvidenceOfTreatment;
        public static CodeableConcept CurrentTreatment = VdorCustomCs.CurrentTreatment;
        public static CodeableConcept NoCurrentTreatmentButTreatedInPast = VdorCustomCs.NoCurrentTreatmentButTreatedInPast;
    }

    public class VdorTypesOfTreatmentForSubstanceUseDisorderVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-types-of-treatment-for-substance-use-disorder-vs";

        public static CodeableConcept InpatientOutpatientRehabilitation = VdorCustomCs.InpatientOutpatientRehabilitation;
        public static CodeableConcept MATWithCognitiveBehavioralTherapy = VdorCustomCs.MATWithCognitiveBehavioralTherapy;
        public static CodeableConcept MATWithoutCognitiveBehavioralTherapy = VdorCustomCs.MATWithoutCognitiveBehavioralTherapy;
        public static CodeableConcept MATCognitiveBehavioralTherapyUnknown = VdorCustomCs.MATCognitiveBehavioralTherapyUnknown;
        public static CodeableConcept CognitiveBehavioralTherapy = VdorCustomCs.CognitiveBehavioralTherapy;
        public static CodeableConcept NarcoticsAnonymous = VdorCustomCs.NarcoticsAnonymous;
        public static CodeableConcept OtherSpecify = VdorCustomCs.OtherSpecify;
    }

    public class VdorUseOfPrescriptionMorphineVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/vdor-use-of-prescription-morphine-vs";

        public static CodeableConcept None = VdorCustomCs.None;
        public static CodeableConcept EvidenceOfMorphinePrescriptionDispensedWithinLast30Days = VdorCustomCs.EvidenceOfMorphinePrescriptionDispensedWithinLast30Days;
        public static CodeableConcept PrescriptionMorphineFoundAtScene = VdorCustomCs.PrescriptionMorphineFoundAtScene;
        public static CodeableConcept BothPrescriptionAndSceneEvidence = VdorCustomCs.BothPrescriptionAndSceneEvidence;
        public static CodeableConcept OtherEvidence = VdorCustomCs.OtherEvidence;
    }

    public class NvdrsWoundLocationValuesVs
    {
        public const string officialUrl = "http://hl7.org/fhir/us/vdor/ValueSet/nvdrs-wound-location-values-vs";

        public static CodeableConcept AbsentNotWounded = NvdrsCodingManualCs.AbsentNotWounded;
        public static CodeableConcept PresentWounded = NvdrsCodingManualCs.PresentWounded;
        public static CodeableConcept NotApplicable = NvdrsCodingManualCs.NotApplicable;
        public static CodeableConcept Unknown = new(UriString.SCT, "261665006", "Unknown", null);
    }

    public class VdorCustomUris
    {
        public const string incidentnumberIdentifierUrl = "urn:vdrs:incidentnumber";
        public const string victimnumberIdentifierUrl = "urn:vdrs:victimnumber";
    }
    // public class VdorSectionCodes
    // {
    //     public const string officialUrl = "http://mortalityreporting.github.io/Vdor-ig/CodeSystem/Vdor-custom-code-system";

    //     public static CodeableConcept Demographics = new(VdorSectionCodes.officialUrl, "demographics", "Demographics", null);
    //     public static CodeableConcept InjuryAndDeath = new(VdorSectionCodes.officialUrl, "injury-and-death", "Injury and Death", null);
    //     public static CodeableConcept Toxicology = new(VdorSectionCodes.officialUrl, "toxicology", "Toxicology", null);
    //     public static CodeableConcept Circumstances = new(VdorSectionCodes.officialUrl, "circumstances", "Circumstances", null);
    //     public static CodeableConcept Weapons = new(VdorSectionCodes.officialUrl, "weapons", "weapons", null);
    //     public static CodeableConcept Overdose = new(VdorSectionCodes.officialUrl, "overdose", "Overdose(s)", null);
    // }
}