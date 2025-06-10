using System;
using System.Text;
using GaTech.Chai.Share;
using Hl7.Fhir.Model;
using static GaTech.Chai.Share.CodeSystems;

namespace GaTech.Chai.UsCore
{
    public class CodeSystemsValueSets
    {
        public class UsCoreDocumentReferenceType
        {
            public static string officialUrl = "http://terminology.hl7.org/CodeSystem/v3-NullFlavor";
            public static Coding UNK = new(officialUrl, "UNK", "unknown");
        }

        public class UsCoreDocumentReferenceCategory
        {
            public static string officialUrl = "http://hl7.org/fhir/us/core/CodeSystem/us-core-documentreference-category";
            public static Coding ClinicalNote = new(officialUrl, "clinical-note", "Clinical Note");
        }

        public static CodeableConcept UsCoreSocialHistoryCategory = new("http://terminology.hl7.org/CodeSystem/observation-category", "social-history");
        public static CodeableConcept SDoHCategory = new("http://hl7.org/fhir/us/core/CodeSystem/us-core-tags", "sdoh");

        public static CodeableConcept VitalHeight = new(UriString.LOINC, "8302-2");
        public static CodeableConcept VitalWeight = new(UriString.LOINC, "29463-7");

        public static CodeableConcept SexualOrientation = new(UriString.LOINC, "76690-7");

        public static string UsCoreGenderIdentityUri = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-genderIdentity";

        public class UsCoreVsOmbRaceCategory
        {
            public static string officialUrl = "urn:oid:2.16.840.1.113883.6.238";
            public static Coding AmericanIndianOrAlaskaNative = new(officialUrl, "1002-5", "American Indian or Alaska Native");
            public static Coding Asian = new(officialUrl, "2028-9", "Asian");
            public static Coding BlackOrAfricanAmerican = new(officialUrl, "2054-5", "Black or African American");
            public static Coding NativeHawaiianOrOtherPacificIslander = new(officialUrl, "2076-8", "Native Hawaiian or Other Pacific Islander");
            public static Coding White = new(officialUrl, "2106-3", "White");
            public static Coding OtherRace = new(officialUrl, "2131-1", "Other Race");
            public static Coding AskedButUnknown = V3NullFlavor.AskedButUnknown.Coding[0];
            public static Coding Unknown = V3NullFlavor.Unknown.Coding[0];
        }

        public class UsCoreVsOmbEthnicityCategory
        {
            public static string officialUrl = "urn:oid:2.16.840.1.113883.6.238";
            public static Coding HispanicOrLatino = new(officialUrl, "2135-2", "Hispanic or Latino");
            public static Coding NotHispanicOrLatino = new(officialUrl, "2186-5", "Not Hispanic or Latino");
            public static Coding AskedButUnknown = V3NullFlavor.AskedButUnknown.Coding[0];
            public static Coding Unknown = V3NullFlavor.Unknown.Coding[0];
        }

        public class UsCoreVSDetailedRace
        {
            public static string officialUrl = "urn:oid:2.16.840.1.113883.6.238";
            public static Coding AmericanIndian = new(officialUrl, "1004-1", "American Indian");
            public static Coding Abenaki = new(officialUrl, "1006-6", "Abenaki");
            public static Coding Algonquian = new(officialUrl, "1008-2", "Algonquian");
            public static Coding Apache = new(officialUrl, "1010-8", "Apache");
            public static Coding Chiricahua = new(officialUrl, "1011-6", "Chiricahua");
            public static Coding FortSillApache = new(officialUrl, "1012-4", "Fort Sill Apache");
            public static Coding JicarillaApache = new(officialUrl, "1013-2", "Jicarilla Apache");
            public static Coding LipanApache = new(officialUrl, "1014-0", "Lipan Apache");
            public static Coding MescaleroApache = new(officialUrl, "1015-7", "Mescalero Apache");
            public static Coding OklahomaApache = new(officialUrl, "1016-5", "Oklahoma Apache");
            public static Coding PaysonApache = new(officialUrl, "1006-6", "Payson Apache");
            public static Coding SanCarlosApache = new(officialUrl, "1018-1", "San Carlos Apache");
            public static Coding WhiteMountainApache = new(officialUrl, "1019-9", "White Mountain Apache");
            public static Coding Arapaho = new(officialUrl, "1021-5", "Arapaho");
            public static Coding NorthernArapaho = new(officialUrl, "1022-3", "Northern Arapaho");
            public static Coding SouthernArapaho = new(officialUrl, "1023-1", "Southern Arapaho");
            public static Coding WindRiverArapaho = new(officialUrl, "1024-9", "Wind River Arapaho");
            public static Coding Arikara = new(officialUrl, "1026-4", "Arikara");
            public static Coding Assiniboine = new(officialUrl, "1028-0", "Assiniboine");
            public static Coding AssiniboineSioux = new(officialUrl, "1030-6", "Assiniboine Sioux");
            public static Coding FortPeckAssiniboineSioux = new(officialUrl, "1031-4", "Fort Peck Assiniboine Sioux");
            public static Coding Bannock = new(officialUrl, "1033-0", "Bannock");
            public static Coding Blackfeet = new(officialUrl, "1035-5", "Blackfeet");
            public static Coding Brotherton = new(officialUrl, "1037-1", "Brotherton");
            public static Coding BurtLakeBand = new(officialUrl, "1039-7", "Burt Lake Band");
            public static Coding Caddo = new(officialUrl, "1041-3", "Caddo");
            public static Coding OklahomaCado = new(officialUrl, "1042-1", "Oklahoma Cado");
            public static Coding Cahuilla = new(officialUrl, "1044-7", "Cahuilla");
            public static Coding AguaCalienteCahuilla = new(officialUrl, "1045-4", "Agua Caliente Cahuilla");
            public static Coding Augustine = new(officialUrl, "1046-2", "Augustine");
            public static Coding Cabazon = new(officialUrl, "1047-0", "Cabazon");
            public static Coding LosCoyotes = new(officialUrl, "1048-8", "Los Coyotes");
            public static Coding Morongo = new(officialUrl, "1049-6", "Morongo");
            public static Coding SantaRosaCahuilla = new(officialUrl, "1050-4", "Santa Rosa Cahuilla");
            public static Coding TorresMartinez = new(officialUrl, "1051-2", "Torres-Martinez");
            public static Coding CaliforniaTribes = new(officialUrl, "1053-8", "California Tribes");
            public static Coding Cahto = new(officialUrl, "1054-6", "Cahto");
            public static Coding Chimariko = new(officialUrl, "1055-3", "Chimariko");
            public static Coding CoastMiwok = new(officialUrl, "1056-1", "Coast Miwok");
            public static Coding Digger = new(officialUrl, "1057-9", "Digger");
            public static Coding Kawaiisu = new(officialUrl, "1058-7", "Kawaiisu");
            public static Coding KernRiver = new(officialUrl, "1059-5", "Kern River");
            public static Coding Mattole = new(officialUrl, "1060-3", "Mattole");
            public static Coding RedWood = new(officialUrl, "1061-1", "Red Wood");
            public static Coding SantaRosa = new(officialUrl, "1062-9", "Santa Rosa");
            public static Coding Takelma = new(officialUrl, "1063-7", "Takelma");
            public static Coding Wappo = new(officialUrl, "1064-5", "Wappo");
            public static Coding Yana = new(officialUrl, "1065-2", "Yana");
            public static Coding Yuki = new(officialUrl, "1066-0", "Yuki");
            public static Coding CanadianAndLatinAmericanIndian = new(officialUrl, "1068-6", "Canadian and Latin American Indian");
            public static Coding CanadianIndian = new(officialUrl, "1069-4", "Canadian Indian");
            public static Coding CentralAmericanIndian = new(officialUrl, "1070-2", "Central American Indian");
            public static Coding FrenchAmericanIndian = new(officialUrl, "1071-0", "French American Indian");
            public static Coding MexicanAmericanIndian = new(officialUrl, "1072-8", "Mexican American Indian");
            public static Coding SouthAmericanIndian = new(officialUrl, "1073-6", "South American Indian");
            public static Coding SpanishAmericanIndian = new(officialUrl, "1074-4", "Spanish American Indian");
            public static Coding Catawba = new(officialUrl, "1076-9", "Catawba");
            public static Coding Cayuse = new(officialUrl, "1078-5", "Cayuse");
            public static Coding Chehalis = new(officialUrl, "1080-1", "Chehalis");
            public static Coding Chemakuan = new(officialUrl, "1082-7", "Chemakuan");
            public static Coding Hoh = new(officialUrl, "1083-5", "Hoh");
            public static Coding Quileute = new(officialUrl, "1084-3", "Quileute");
            public static Coding Chemehuevi = new(officialUrl, "1086-8", "Chemehuevi");
            public static Coding Cherokee = new(officialUrl, "1088-4", "Cherokee");
            public static Coding CherokeeAlabama = new(officialUrl, "1089-2", "Cherokee Alabama");
            public static Coding CherokeesOfNortheastAlabama = new(officialUrl, "1090-0", "Cherokees of Northeast Alabama");
            public static Coding CherokeesOfSoutheastAlabama = new(officialUrl, "1091-8", "Cherokees of Southeast Alabama");
            public static Coding EasternCherokee = new(officialUrl, "1092-6", "Eastern Cherokee");
            public static Coding EchotaCherokee = new(officialUrl, "1093-4", "Echota Cherokee");
            public static Coding EtowahCherokee = new(officialUrl, "1094-2", "Etowah Cherokee");
            public static Coding NorthernCherokee = new(officialUrl, "1095-9", "Northern Cherokee");
            public static Coding Tuscola = new(officialUrl, "1096-7", "Tuscola");
            public static Coding UnitedKeetowahBandOfCherokee = new(officialUrl, "1097-5", "United Keetowah Band of Cherokee");
            public static Coding WesternCherokee = new(officialUrl, "1098-3", "Western Cherokee");
            public static Coding CherokeeShawnee = new(officialUrl, "1100-7", "Cherokee Shawnee");
            public static Coding Cheyenne = new(officialUrl, "1102-3", "Cheyenne");
            public static Coding NorthernCheyenne = new(officialUrl, "1103-1", "Northern Cheyenne");
            public static Coding SouthernCheyenne = new(officialUrl, "1104-9", "Southern Cheyenne");
            public static Coding CheyenneArapaho = new(officialUrl, "1106-4", "Cheyenne-Arapaho");
            public static Coding Chickahominy = new(officialUrl, "1108-0", "Chickahominy");
            public static Coding EasternChickahominy = new(officialUrl, "1109-8", "Eastern Chickahominy");
            public static Coding WesternChickahominy = new(officialUrl, "1110-6", "Western Chickahominy");
            public static Coding Chickasaw = new(officialUrl, "1112-2", "Chickasaw");
            public static Coding Chinook = new(officialUrl, "1114-8", "Chinook");
            public static Coding Clatsop = new(officialUrl, "1115-5", "Clatsop");
            public static Coding ColumbiaRiverChinook = new(officialUrl, "1116-3", "Columbia River Chinook");
            public static Coding Kathlamet = new(officialUrl, "1117-1", "Kathlamet");
            public static Coding UpperChinook = new(officialUrl, "1118-9", "Upper Chinook");
            public static Coding WakiakumChinook = new(officialUrl, "1119-7", "Wakiakum Chinook");
            public static Coding WillapaChinook = new(officialUrl, "1120-5", "Willapa Chinook");
            public static Coding Wishram = new(officialUrl, "1121-3", "Wishram");
            public static Coding Chippewa = new(officialUrl, "1123-9", "Chippewa");
            public static Coding BadRiver = new(officialUrl, "1124-7", "Bad River");
            public static Coding BayMillsChippewa = new(officialUrl, "1125-4", "Bay Mills Chippewa");
            public static Coding BoisForte = new(officialUrl, "1126-2", "Bois Forte");
            public static Coding BurtLakeChippewa = new(officialUrl, "1127-0", "Burt Lake Chippewa");
            public static Coding FondduLac = new(officialUrl, "1128-8", "Fond du Lac");
            public static Coding GrandPortage = new(officialUrl, "1129-6", "Grand Portage");
            public static Coding GrandTraverseBandOfOttawaChippewa = new(officialUrl, "1130-4", "Grand Traverse Band of Ottawa/Chippewa");
            public static Coding Keweenaw = new(officialUrl, "1131-2", "Keweenaw");
            public static Coding LacCourteOreilles = new(officialUrl, "1132-0", "Lac Courte Oreilles");
            public static Coding LacduFlambeau = new(officialUrl, "1133-8", "Lac du Flambeau");
            public static Coding LacVieuxDesertChippewa = new(officialUrl, "1134-6", "Lac Vieux Desert Chippewa");
            public static Coding LakeSuperior = new(officialUrl, "1135-3", "Lake Superior");
            public static Coding LeechLake = new(officialUrl, "1136-1", "Leech Lake");
            public static Coding LittleShellChippewa = new(officialUrl, "1137-9", "Little Shell Chippewa");
            public static Coding MilleLacs = new(officialUrl, "1138-7", "Mille Lacs");
            public static Coding MinnesotaChippewa = new(officialUrl, "1139-5", "Minnesota Chippewa");
            public static Coding Ontonagon = new(officialUrl, "1140-3", "Ontonagon");
            public static Coding RedCliffChippewa = new(officialUrl, "1141-1", "Red Cliff Chippewa");
            public static Coding RedLakeChippewa = new(officialUrl, "1142-9", "Red Lake Chippewa");
            public static Coding SaginawChippewa = new(officialUrl, "1143-7", "Saginaw Chippewa");
            public static Coding StCroixChippewa = new(officialUrl, "1144-5", "St. Croix Chippewa");
            public static Coding SaultSteMarieChippewa = new(officialUrl, "1145-2", "Sault Ste. Marie Chippewa");
            public static Coding SokoagonChippewa = new(officialUrl, "1146-0", "Sokoagon Chippewa");
            public static Coding TurtleMountain = new(officialUrl, "1147-8", "Turtle Mountain");
            public static Coding WhiteEarth = new(officialUrl, "1148-6", "White Earth");
            public static Coding ChippewaCree = new(officialUrl, "1150-2", "Chippewa Cree");
            public static Coding RockyBoysChippewaCree = new(officialUrl, "1151-0", "Rocky Boy's Chippewa Cree");
            public static Coding Chitimacha = new(officialUrl, "1153-6", "Chitimacha");
            public static Coding Choctaw = new(officialUrl, "1155-1", "Choctaw");
            public static Coding CliftonChoctaw = new(officialUrl, "1156-9", "Clifton Choctaw");
            public static Coding JenaChoctaw = new(officialUrl, "1157-7", "Jena Choctaw");
            public static Coding MississippiChoctaw = new(officialUrl, "1158-5", "Mississippi Choctaw");
            public static Coding MowaBandOfChoctaw = new(officialUrl, "1159-3", "Mowa Band of Choctaw");
            public static Coding OklahomaChoctaw = new(officialUrl, "1160-1", "Oklahoma Choctaw");
            public static Coding Chumash = new(officialUrl, "1162-7", "Chumash");
            public static Coding SantaYnez = new(officialUrl, "1163-5", "Santa Ynez");
            public static Coding ClearLake = new(officialUrl, "1165-0", "Clear Lake");
            public static Coding CoeurDAlene = new(officialUrl, "1167-6", "Coeur D'Alene");
            public static Coding Coharie = new(officialUrl, "1169-2", "Coharie");
            public static Coding ColoradoRiver = new(officialUrl, "1171-8", "Colorado River");
            public static Coding Colville = new(officialUrl, "1173-4", "Colville");
            public static Coding Comanche = new(officialUrl, "1175-9", "Comanche");
            public static Coding OklahomaComanche = new(officialUrl, "1176-7", "Oklahoma Comanche");
            public static Coding CoosLowerUmpquaSiuslaw = new(officialUrl, "1178-3", "Coos, Lower Umpqua, Siuslaw");
            public static Coding Coos = new(officialUrl, "1180-9", "Coos");
            public static Coding Coquilles = new(officialUrl, "1182-5", "Coquilles");
            public static Coding Costanoan = new(officialUrl, "1184-1", "Costanoan");
            public static Coding Coushatta = new(officialUrl, "1186-6", "Coushatta");
            public static Coding AlabamaCoushatta = new(officialUrl, "1187-4", "Alabama Coushatta");
            public static Coding Cowlitz = new(officialUrl, "1189-0", "Cowlitz");
            public static Coding Cree = new(officialUrl, "1191-6", "Cree");
            public static Coding Creek = new(officialUrl, "1193-2", "Creek");
            public static Coding AlabamaCreek = new(officialUrl, "1194-0", "Alabama Creek");
            public static Coding AlabamaQuassarte = new(officialUrl, "1195-7", "Alabama Quassarte");
            public static Coding EasternCreek = new(officialUrl, "1196-5", "Eastern Creek");
            public static Coding EasternMuscogee = new(officialUrl, "1197-3", "Eastern Muscogee");
            public static Coding Kialegee = new(officialUrl, "1198-1", "Kialegee");
            public static Coding LowerMuscogee = new(officialUrl, "1199-9", "Lower Muscogee");
            public static Coding MachisLowerCreekIndian = new(officialUrl, "1200-5", "Machis Lower Creek Indian");
            public static Coding PoarchBand = new(officialUrl, "1201-3", "Poarch Band");
            public static Coding PrincipalCreekIndianNation = new(officialUrl, "1202-1", "Principal Creek Indian Nation");
            public static Coding StarClanOfMuscogeeCreeks = new(officialUrl, "1203-9", "Star Clan of Muscogee Creeks");
            public static Coding Thlopthlocco = new(officialUrl, "1204-7", "Thlopthlocco");
            public static Coding Tuckabachee = new(officialUrl, "1205-4", "Tuckabachee");
            public static Coding Croatan = new(officialUrl, "1207-0", "Croatan");
            public static Coding Crow = new(officialUrl, "1209-6", "Crow");
            public static Coding Cupeno = new(officialUrl, "1211-2", "Cupeno");
            public static Coding AguaCaliente = new(officialUrl, "1212-0", "Agua Caliente");
            public static Coding Delaware = new(officialUrl, "1214-6", "Delaware");
            public static Coding EasternDelaware = new(officialUrl, "1215-3", "Eastern Delaware");
            public static Coding LenniLenape = new(officialUrl, "1216-1", "Lenni-Lenape");
            public static Coding Munsee = new(officialUrl, "1217-9", "Munsee");
            public static Coding OklahomaDelaware = new(officialUrl, "1218-7", "Oklahoma Delaware");
            public static Coding RampoughMountain = new(officialUrl, "1219-5", "Rampough Mountain");
            public static Coding SandHill = new(officialUrl, "1220-3", "Sand Hill");
            public static Coding Diegueno = new(officialUrl, "1222-9", "Diegueno");
            public static Coding Campo = new(officialUrl, "1223-7", "Campo");
            public static Coding CapitanGrande = new(officialUrl, "1224-5", "Capitan Grande");
            public static Coding Cuyapaipe = new(officialUrl, "1225-2", "Cuyapaipe");
            public static Coding LaPosta = new(officialUrl, "1226-0", "La Posta");
            public static Coding Manzanita = new(officialUrl, "1227-8", "Manzanita");
            public static Coding MesaGrande = new(officialUrl, "1228-6", "Mesa Grande");
            public static Coding SanPasqual = new(officialUrl, "1229-4", "San Pasqual");
            public static Coding SantaYsabel = new(officialUrl, "1230-2", "Santa Ysabel");
            public static Coding Sycuan = new(officialUrl, "1231-0", "Sycuan");
            public static Coding EasternTribes = new(officialUrl, "1233-6", "Eastern Tribes");
            public static Coding Attacapa = new(officialUrl, "1234-4", "Attacapa");
            public static Coding Biloxi = new(officialUrl, "1235-1", "Biloxi");
            public static Coding GeorgetownEasternTribes = new(officialUrl, "1236-9", "Georgetown (Eastern Tribes)");
            public static Coding Moor = new(officialUrl, "1237-7", "Moor");
            public static Coding Nansemond = new(officialUrl, "1238-5", "Nansemond");
            public static Coding Natchez = new(officialUrl, "1239-3", "Natchez");
            public static Coding NausuWaiwash = new(officialUrl, "1240-1", "Nausu Waiwash");
            public static Coding Nipmuc = new(officialUrl, "1241-9", "Nipmuc");
            public static Coding Paugussett = new(officialUrl, "1242-7", "Paugussett");
            public static Coding PocomokeAcohonock = new(officialUrl, "1243-5", "Pocomoke Acohonock");
            public static Coding SoutheasternIndians = new(officialUrl, "1244-3", "Southeastern Indians");
            public static Coding Susquehanock = new(officialUrl, "1245-0", "Susquehanock");
            public static Coding TunicaBiloxi = new(officialUrl, "1246-8", "Tunica Biloxi");
            public static Coding WaccamawSiousan = new(officialUrl, "1247-6", "Waccamaw-Siousan");
            public static Coding Wicomico = new(officialUrl, "1248-4", "Wicomico");
            public static Coding Esselen = new(officialUrl, "1250-0", "Esselen");
            public static Coding FortBelknap = new(officialUrl, "1252-6", "Fort Belknap");
            public static Coding FortBerthold = new(officialUrl, "1254-2", "Fort Berthold");
            public static Coding FortMcdowell = new(officialUrl, "1256-7", "Fort Mcdowell");
            public static Coding FortHall = new(officialUrl, "1258-3", "Fort Hall");
            public static Coding Gabrieleno = new(officialUrl, "1260-9", "Gabrieleno");
            public static Coding GrandRonde = new(officialUrl, "1262-5", "Grand Ronde");
            public static Coding GrosVentres = new(officialUrl, "1264-1", "Gros Ventres");
            public static Coding Atsina = new(officialUrl, "1265-8", "Atsina");
            public static Coding Haliwa = new(officialUrl, "1267-4", "Haliwa");
            public static Coding Hidatsa = new(officialUrl, "1269-0", "Hidatsa");
            public static Coding Hoopa = new(officialUrl, "1271-6", "Hoopa");
            public static Coding Trinity = new(officialUrl, "1272-4", "Trinity");
            public static Coding Whilkut = new(officialUrl, "1273-2", "Whilkut");
            public static Coding HoopaExtension = new(officialUrl, "1275-7", "Hoopa Extension");
            public static Coding Houma = new(officialUrl, "1277-3", "Houma");
            public static Coding InajaCosmit = new(officialUrl, "1279-9", "Inaja-Cosmit");
            public static Coding Iowa = new(officialUrl, "1281-5", "Iowa");
            public static Coding IowaOfKansasNebraska = new(officialUrl, "1282-3", "Iowa of Kansas-Nebraska");
            public static Coding IowaOfOklahoma = new(officialUrl, "1283-1", "Iowa of Oklahoma");
            public static Coding Iroquois = new(officialUrl, "1285-6", "Iroquois");
            public static Coding Cayuga = new(officialUrl, "1286-4", "Cayuga");
            public static Coding Mohawk = new(officialUrl, "1287-2", "Mohawk");
            public static Coding Oneida = new(officialUrl, "1288-0", "Oneida");
            public static Coding Onondaga = new(officialUrl, "1289-8", "Onondaga");
            public static Coding Seneca = new(officialUrl, "1290-6", "Seneca");
            public static Coding SenecaNation = new(officialUrl, "1291-4", "Seneca Nation");
            public static Coding SenecaCayuga = new(officialUrl, "1292-2", "Seneca-Cayuga");
            public static Coding TonawandaSeneca = new(officialUrl, "1293-0", "Tonawanda Seneca");
            public static Coding Tuscarora = new(officialUrl, "1294-8", "Tuscarora");
            public static Coding Wyandotte = new(officialUrl, "1295-5", "Wyandotte");
            public static Coding Juaneno = new(officialUrl, "1297-1", "Juaneno");
            public static Coding Kalispel = new(officialUrl, "1299-7", "Kalispel");
            public static Coding Karuk = new(officialUrl, "1301-1", "Karuk");
            public static Coding Kaw = new(officialUrl, "1303-7", "Kaw");
            public static Coding Kickapoo = new(officialUrl, "1305-2", "Kickapoo");
            public static Coding OklahomaKickapoo = new(officialUrl, "1306-0", "Oklahoma Kickapoo");
            public static Coding TexasKickapoo = new(officialUrl, "1307-8", "Texas Kickapoo");
            public static Coding Kiowa = new(officialUrl, "1309-4", "Kiowa");
            public static Coding OklahomaKiowa = new(officialUrl, "1310-2", "Oklahoma Kiowa");
            public static Coding Klallam = new(officialUrl, "1312-8", "Klallam");
            public static Coding Jamestown = new(officialUrl, "1313-6", "Jamestown");
            public static Coding LowerElwha = new(officialUrl, "1314-4", "Lower Elwha");
            public static Coding PortGambleKlallam = new(officialUrl, "1315-1", "Port Gamble Klallam");
            public static Coding Klamath = new(officialUrl, "1317-7", "Klamath");
            public static Coding Konkow = new(officialUrl, "1319-3", "Konkow");
            public static Coding Kootenai = new(officialUrl, "1321-9", "Kootenai");
            public static Coding Lassik = new(officialUrl, "1323-5", "Lassik");
            public static Coding LongIsland = new(officialUrl, "1325-0", "Long Island");
            public static Coding Matinecock = new(officialUrl, "1326-8", "Matinecock");
            public static Coding Montauk = new(officialUrl, "1327-6", "Montauk");
            public static Coding Poospatuck = new(officialUrl, "1328-4", "Poospatuck");
            public static Coding Setauket = new(officialUrl, "1329-2", "Setauket");
            public static Coding Luiseno = new(officialUrl, "1331-8", "Luiseno");
            public static Coding LaJolla = new(officialUrl, "1332-6", "La Jolla");
            public static Coding Pala = new(officialUrl, "1333-4", "Pala");
            public static Coding Pauma = new(officialUrl, "1334-2", "Pauma");
            public static Coding Pechanga = new(officialUrl, "1335-9", "Pechanga");
            public static Coding Soboba = new(officialUrl, "1336-7", "Soboba");
            public static Coding TwentyNinePalms = new(officialUrl, "1337-5", "Twenty-Nine Palms");
            public static Coding Temecula = new(officialUrl, "1338-3", "Temecula");
            public static Coding Lumbee = new(officialUrl, "1340-9", "Lumbee");
            public static Coding Lummi = new(officialUrl, "1342-5", "Lummi");
            public static Coding Maidu = new(officialUrl, "1344-1", "Maidu");
            public static Coding MountainMaidu = new(officialUrl, "1345-8", "Mountain Maidu");
            public static Coding Nishinam = new(officialUrl, "1346-6", "Nishinam");
            public static Coding Makah = new(officialUrl, "1348-2", "Makah");
            public static Coding Maliseet = new(officialUrl, "1350-8", "Maliseet");
            public static Coding Mandan = new(officialUrl, "1352-4", "Mandan");
            public static Coding Mattaponi = new(officialUrl, "1354-0", "Mattaponi");
            public static Coding Menominee = new(officialUrl, "1356-5", "Menominee");
            public static Coding Miami = new(officialUrl, "1358-1", "Miami");
            public static Coding IllinoisMiami = new(officialUrl, "1359-9", "Illinois Miami");
            public static Coding IndianaMiami = new(officialUrl, "1360-7", "Indiana Miami");
            public static Coding OklahomaMiami = new(officialUrl, "1361-5", "Oklahoma Miami");
            public static Coding Miccosukee = new(officialUrl, "1363-1", "Miccosukee");
            public static Coding Micmac = new(officialUrl, "1365-6", "Micmac");
            public static Coding Aroostook = new(officialUrl, "1366-4", "Aroostook");
            public static Coding MissionIndians = new(officialUrl, "1368-0", "Mission Indians");
            public static Coding Miwok = new(officialUrl, "1370-6", "Miwok");
            public static Coding Modoc = new(officialUrl, "1372-2", "Modoc");
            public static Coding Mohegan = new(officialUrl, "1374-8", "Mohegan");
            public static Coding Mono = new(officialUrl, "1376-3", "Mono");
            public static Coding Nanticoke = new(officialUrl, "1378-9", "Nanticoke");
            public static Coding Narragansett = new(officialUrl, "1380-5", "Narragansett");
            public static Coding Navajo = new(officialUrl, "1382-1", "Navajo");
            public static Coding AlamoNavajo = new(officialUrl, "1383-9", "Alamo Navajo");
            public static Coding CanoncitoNavajo = new(officialUrl, "1384-7", "Canoncito Navajo");
            public static Coding RamahNavajo = new(officialUrl, "1385-4", "Ramah Navajo");
            public static Coding NezPerce = new(officialUrl, "1387-0", "Nez Perce");
            public static Coding Nomalaki = new(officialUrl, "1389-6", "Nomalaki");
            public static Coding NorthwestTribes = new(officialUrl, "1391-2", "Northwest Tribes");
            public static Coding Alsea = new(officialUrl, "1392-0", "Alsea");
            public static Coding Celilo = new(officialUrl, "1393-8", "Celilo");
            public static Coding Columbia = new(officialUrl, "1394-6", "Columbia");
            public static Coding Kalapuya = new(officialUrl, "1395-3", "Kalapuya");
            public static Coding Molala = new(officialUrl, "1396-1", "Molala");
            public static Coding Talakamish = new(officialUrl, "1397-9", "Talakamish");
            public static Coding Tenino = new(officialUrl, "1398-7", "Tenino");
            public static Coding Tillamook = new(officialUrl, "1399-5", "Tillamook");
            public static Coding Wenatchee = new(officialUrl, "1400-1", "Wenatchee");
            public static Coding Yahooskin = new(officialUrl, "1401-9", "Yahooskin");
            public static Coding Omaha = new(officialUrl, "1403-5", "Omaha");
            public static Coding OregonAthabaskan = new(officialUrl, "1405-0", "Oregon Athabaskan");

            public static Coding AskedButUnknown = V3NullFlavor.AskedButUnknown.Coding[0];
            public static Coding Other = V3NullFlavor.Other.Coding[0];
            public static Coding Unknown = V3NullFlavor.Unknown.Coding[0];
        }

        public class UsCoreVSDetailedEthnicity
        {
            public static string officialUrl = "urn:oid:2.16.840.1.113883.6.238";
            public static Coding Spaniard = new(officialUrl, "2137-8", "Spaniard");
            public static Coding Andalusian = new(officialUrl, "2138-6", "Andalusian");
            public static Coding Asturian = new(officialUrl, "2139-4", "Asturian");
            public static Coding Castillian = new(officialUrl, "2140-2", "Castillian");
            public static Coding Catalonian = new(officialUrl, "2141-0", "Catalonian");
            public static Coding BelearicIslander = new(officialUrl, "2142-8", "Belearic Islander");
            public static Coding Gallego = new(officialUrl, "2143-6", "Gallego");
            public static Coding Valencian = new(officialUrl, "2144-4", "Valencian");
            public static Coding Canarian = new(officialUrl, "2145-1", "Canarian");
            public static Coding SpanishBasque = new(officialUrl, "2146-9", "Spanish Basque");
            public static Coding Mexican = new(officialUrl, "2148-5", "Mexican");
            public static Coding MexicanAmerican = new(officialUrl, "2149-3", "Mexican American");
            public static Coding Mexicano = new(officialUrl, "2150-1", "Mexicano");
            public static Coding Chicano = new(officialUrl, "2151-9", "Chicano");
            public static Coding LaRaza = new(officialUrl, "2152-7", "La Raza");
            public static Coding MexicanAmericanIndian = new(officialUrl, "2153-5", "Mexican American Indian");
            public static Coding CentralAmerican = new(officialUrl, "2155-0", "Central American");
            public static Coding CostaRican = new(officialUrl, "2156-8", "Costa Rican");
            public static Coding Guatemalan = new(officialUrl, "2157-6", "Guatemalan");
            public static Coding Honduran = new(officialUrl, "2158-4", "Honduran");
            public static Coding Nicaraguan = new(officialUrl, "2159-2", "Nicaraguan");
            public static Coding Panamanian = new(officialUrl, "2160-0", "Panamanian");
            public static Coding Salvadoran = new(officialUrl, "2161-8", "Salvadoran");
            public static Coding CentralAmericanIndian = new(officialUrl, "2162-6", "Central American Indian");
            public static Coding CanalZone = new(officialUrl, "2163-4", "Canal Zone");
            public static Coding SouthAmerican = new(officialUrl, "2165-9", "South American");
            public static Coding Argentinean = new(officialUrl, "2166-7", "Argentinean");
            public static Coding Bolivian = new(officialUrl, "2167-5", "Bolivian");
            public static Coding Chilean = new(officialUrl, "2168-3", "Chilean");
            public static Coding Colombian = new(officialUrl, "2169-1", "Colombian");
            public static Coding Ecuadorian = new(officialUrl, "2170-9", "Ecuadorian");
            public static Coding Paraguayan = new(officialUrl, "2171-7", "Paraguayan");
            public static Coding Peruvian = new(officialUrl, "2172-5", "Peruvian");
            public static Coding Uruguayan = new(officialUrl, "2173-3", "Uruguayan");
            public static Coding Venezuelan = new(officialUrl, "2174-1", "Venezuelan");
            public static Coding SouthAmericanIndian = new(officialUrl, "2175-8", "South American Indian");
            public static Coding Criollo = new(officialUrl, "2176-6", "Criollo");
            public static Coding LatinAmerican = new(officialUrl, "2178-2", "Latin American");
            public static Coding PuertoRican = new(officialUrl, "2180-8", "Puerto Rican");
            public static Coding Cuban = new(officialUrl, "2182-4", "Cuban");
            public static Coding Dominican = new(officialUrl, "2184-0", "Dominican");
            public static Coding AskedButUnknown = V3NullFlavor.AskedButUnknown.Coding[0];
            public static Coding Other = V3NullFlavor.Other.Coding[0];
            public static Coding Unknown = V3NullFlavor.Unknown.Coding[0];
        }

        public class UsCoreVsGenderIdentity
        {
            public static string officialUrl = "urn:oid:2.16.840.1.113762.1.4.1021.32";
            public static CodeableConcept IdentifiesAsNonbinaryGender = new(UriString.SCT, "33791000087105", "Identifies as nonbinary gender (finding)", null);
            public static CodeableConcept MaleToFemaleTranssexual = new(UriString.SCT, "407376001", "Male-to-female transsexual (finding) (finding)", null);
            public static CodeableConcept FemaleToMaleTranssexual = new(UriString.SCT, "407377005", "Female-to-male transsexual (finding)", null);
            public static CodeableConcept IdentifiesAsNonConformingGender = new(UriString.SCT, "446131000124102", "Identifies as non-conforming gender (finding)", null);
            public static CodeableConcept IdentifiesAsFemaleGender = new(UriString.SCT, "446141000124107", "Identifies as female gender (finding)", null);
            public static CodeableConcept IdentifiesAsMaleGender = new(UriString.SCT, "446151000124109", "Identifies as male gender (finding)", null);
            public static CodeableConcept Other = V3NullFlavor.Other;
            public static CodeableConcept Unknown = V3NullFlavor.Unknown;
            public static CodeableConcept AskedButDeclined = new("http://terminology.hl7.org/CodeSystem/data-absent-reason", "asked-declined", "Asked But Declined", null);
        }

        public class UsCoreVsSexualOrientation
        {
            public static string officialUrl = "urn:oid:2.16.840.1.113762.1.4.1240.11";
            public static CodeableConcept Heterosexual = new(UriString.SCT, "20430005", "Heterosexual (finding)", null);
            public static CodeableConcept Homosexual = new(UriString.SCT, "38628009", "Homosexual (finding)", null);
            public static CodeableConcept Bisexual = new(UriString.SCT, "42035005", "Bisexual (finding)", null);
            public static CodeableConcept SexuallyAttractedToNeitherMaleNorFemaleSex = new(UriString.SCT, "765288000", "Sexually attracted to neither male nor female sex (finding)", null);
            public static CodeableConcept Other = V3NullFlavor.Other;
            public static CodeableConcept Unknown = V3NullFlavor.Unknown;
            public static CodeableConcept AskedButDeclined = new("http://terminology.hl7.org/CodeSystem/data-absent-reason", "asked-declined", "Asked But Declined", null);
        }
    }
}

