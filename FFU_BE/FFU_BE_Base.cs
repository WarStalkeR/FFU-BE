#pragma warning disable IDE0051
#pragma warning disable IDE0059

using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Base {
		public static readonly string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\LocalLow\Interactive Fate\Shortest Trip To Earth\";
		public static readonly string modConfDir = @"ModsConf\";
		public static readonly string modConfFile = @"FFU_Bleeding_Edge.ini";
		private static readonly string[] shipEntries = { "Tigerfish", "NukeRunner", "RogueRat", "Exception", "Weirdship", "EasyTiger", "Atlas", "Roundship", "Engiship", "Bluestar", "Gardenship", "BattleTiger", "Shybettle", "Endurance" };
		private static int GetShipPrefabID(string shipType) {
			switch (shipType) {
				case "Tigerfish": return 516057105;
				case "NukeRunner": return 487234563;
				case "RogueRat": return 578937222;
				case "Exception": return 66885230;
				case "Weirdship": return 1809014558;
				case "EasyTiger": return 1920692188;
				case "Gardenship": return 1106792042;
				case "Atlas": return 2103659466;
				case "Bluestar": return 1772361532;
				case "Roundship": return 1251918188;
				case "Engiship": return 853503871;
				case "BattleTiger": return 1452660923;
				case "Shybettle": return 42388666;
				case "Endurance": return 1939804939;
				default: return -1;
			}
		}
		private static string GetShipNameByID(int shipPrefabID) {
			switch (shipPrefabID) {
				case 516057105: return "Tigerfish";
				case 487234563: return "Nuke Runner";
				case 578937222: return "Rogue Rat";
				case 66885230: return "The Exception";
				case 1809014558: return "Fierce Sincerity";
				case 1920692188: return "Easy Tiger";
				case 1106792042: return "Pumpkin Hammer";
				case 2103659466: return "Atlas";
				case 1772361532: return "Bluestar";
				case 1251918188: return "Warpshell";
				case 853503871: return "Riggy";
				case 1452660923: return "Battle Tiger";
				case 42388666: return "Shybettle";
				case 1939804939: return "Endurance";
				default: return "???";
			}
		}
		public static void LoadModConfiguration() {
			if (!string.IsNullOrEmpty(appDataPath)) {
				Debug.LogWarning("Initializing mod configuration for Fight For Universe: Bleeding Edge v" + FFU_BE_Defs.modVersion);
				if (!Directory.Exists(appDataPath + modConfDir)) Directory.CreateDirectory(appDataPath + modConfDir);
				if (File.Exists(appDataPath + modConfDir + modConfFile)) {
					IniFile modConfig = new IniFile();
					modConfig.Load(appDataPath + modConfDir + modConfFile);
					string modConfigLog = $"Loading mod configuration from {appDataPath + modConfDir + modConfFile}";
					if (string.IsNullOrEmpty(modConfig["InitConfig"]["modVersion"].Value) || modConfig["InitConfig"]["modVersion"].ToString() != FFU_BE_Defs.modVersion) {
						CreateModConfiguration(modConfDir, modConfFile); 
						return;
					}
					FFU_BE_Defs.allModulesCraftable = modConfig["Settings"]["allModulesCraftable"].ToBool(FFU_BE_Defs.allModulesCraftable);
					FFU_BE_Defs.allTypesCraftable = modConfig["Settings"]["allTypesCraftable"].ToBool(FFU_BE_Defs.allTypesCraftable);
					FFU_BE_Defs.moduleCraftingForFree = modConfig["Settings"]["moduleCraftingForFree"].ToBool(FFU_BE_Defs.moduleCraftingForFree);
					FFU_BE_Defs.fuelIsCraftingEnergy = modConfig["Settings"]["fuelIsCraftingEnergy"].ToBool(FFU_BE_Defs.fuelIsCraftingEnergy);
					FFU_BE_Defs.fuelIsScrapRefunded = modConfig["Settings"]["fuelIsScrapRefunded"].ToBool(FFU_BE_Defs.fuelIsScrapRefunded);
					FFU_BE_Defs.relativeEnemyCrewSkills = modConfig["Settings"]["relativeEnemyCrewSkills"].ToBool(FFU_BE_Defs.relativeEnemyCrewSkills);
					FFU_BE_Defs.listAllCrewmemberTypes = modConfig["Settings"]["listAllCrewmemberTypes"].ToBool(FFU_BE_Defs.listAllCrewmemberTypes);
					FFU_BE_Defs.containerSizeMultiplier = modConfig["Multipliers"]["containerSizeMultiplier"].ToFloat(FFU_BE_Defs.containerSizeMultiplier);
					FFU_BE_Defs.resourcesScrapFraction = modConfig["Multipliers"]["resourcesScrapFraction"].ToFloat(FFU_BE_Defs.resourcesScrapFraction);
					FFU_BE_Defs.newStartingFateBonus = modConfig["Multipliers"]["newStartingFateBonus"].ToInt(FFU_BE_Defs.newStartingFateBonus);
					FFU_BE_Defs.addFreeCrewSkillPoints = modConfig["Multipliers"]["addFreeCrewSkillPoints"].ToInt(FFU_BE_Defs.addFreeCrewSkillPoints);
					FFU_BE_Defs.minPlayerCrewSkillsLimit = modConfig["Multipliers"]["minPlayerCrewSkillsLimit"].ToInt(FFU_BE_Defs.minPlayerCrewSkillsLimit);
					FFU_BE_Defs.minEnemyCrewSkillsLimit = modConfig["Multipliers"]["minEnemyCrewSkillsLimit"].ToInt(FFU_BE_Defs.minEnemyCrewSkillsLimit);
					FFU_BE_Defs.shipMaxEvasionLimit = modConfig["Multipliers"]["shipMaxEvasionLimit"].ToInt(FFU_BE_Defs.shipMaxEvasionLimit);
					FFU_BE_Defs.shipModuleHealthMult = modConfig["Multipliers"]["shipModuleHealthMult"].ToFloat(FFU_BE_Defs.shipModuleHealthMult);
					FFU_BE_Defs.shipModuleUnpackTime = modConfig["Multipliers"]["shipModuleUnpackTime"].ToFloat(FFU_BE_Defs.shipModuleUnpackTime);
					FFU_BE_Defs.shipModuleCraftTime = modConfig["Multipliers"]["shipModuleCraftTime"].ToFloat(FFU_BE_Defs.shipModuleCraftTime);
					FFU_BE_Defs.moduleFireStartChance = modConfig["Multipliers"]["moduleFireStartChance"].ToFloat(FFU_BE_Defs.moduleFireStartChance);
					FFU_BE_Defs.coreSlotsHealthMult = modConfig["Multipliers"]["coreSlotsHealthMult"].ToFloat(FFU_BE_Defs.coreSlotsHealthMult);
					FFU_BE_Defs.enemyResourcesLootMinMult = modConfig["Multipliers"]["enemyResourcesLootMinMult"].ToFloat(FFU_BE_Defs.enemyResourcesLootMinMult);
					FFU_BE_Defs.enemyResourcesLootMaxMult = modConfig["Multipliers"]["enemyResourcesLootMaxMult"].ToFloat(FFU_BE_Defs.enemyResourcesLootMaxMult);
					FFU_BE_Defs.enemyShipHullHealthMult = modConfig["Multipliers"]["enemyShipHullHealthMult"].ToFloat(FFU_BE_Defs.enemyShipHullHealthMult);
					FFU_BE_Defs.tierResearchSpeedMult = modConfig["Multipliers"]["tierResearchSpeedMult"].ToFloat(FFU_BE_Defs.tierResearchSpeedMult);
					FFU_BE_Defs.moduleResearchSpeedMult = modConfig["Multipliers"]["moduleResearchSpeedMult"].ToFloat(FFU_BE_Defs.moduleResearchSpeedMult);
					FFU_BE_Defs.intactModuleDropChance = modConfig["Multipliers"]["intactModuleDropChance"].ToFloat(FFU_BE_Defs.intactModuleDropChance);
					FFU_BE_Defs.warpProducedResearchMult = modConfig["Multipliers"]["warpProducedResearchMult"].ToFloat(FFU_BE_Defs.warpProducedResearchMult);
					FFU_BE_Defs.warpProducedResourcesMult = modConfig["Multipliers"]["warpProducedResourcesMult"].ToFloat(FFU_BE_Defs.warpProducedResourcesMult);
					FFU_BE_Defs.enemyCrewHealthSectorMult = modConfig["Multipliers"]["enemyCrewHealthSectorMult"].ToFloat(FFU_BE_Defs.enemyCrewHealthSectorMult);
					modConfigLog += $"\n > Property [allModulesCraftable] loaded with value: {FFU_BE_Defs.allModulesCraftable}";
					modConfigLog += $"\n > Property [allTypesCraftable] loaded with value: {FFU_BE_Defs.allTypesCraftable}";
					modConfigLog += $"\n > Property [moduleCraftingForFree] loaded with value: {FFU_BE_Defs.moduleCraftingForFree}";
					modConfigLog += $"\n > Property [fuelIsCraftingEnergy] loaded with value: {FFU_BE_Defs.fuelIsCraftingEnergy}";
					modConfigLog += $"\n > Property [fuelIsScrapRefunded] loaded with value: {FFU_BE_Defs.fuelIsScrapRefunded}";
					modConfigLog += $"\n > Property [relativeEnemyCrewSkills] loaded with value: {FFU_BE_Defs.relativeEnemyCrewSkills}";
					modConfigLog += $"\n > Property [listAllCrewmemberTypes] loaded with value: {FFU_BE_Defs.listAllCrewmemberTypes}";
					modConfigLog += $"\n > Property [containerSizeMultiplier] loaded with value: {FFU_BE_Defs.containerSizeMultiplier}";
					modConfigLog += $"\n > Property [resourcesScrapFraction] loaded with value: {FFU_BE_Defs.resourcesScrapFraction}";
					modConfigLog += $"\n > Property [newStartingFateBonus] loaded with value: {FFU_BE_Defs.newStartingFateBonus}";
					modConfigLog += $"\n > Property [addFreeCrewSkillPoints] loaded with value: {FFU_BE_Defs.addFreeCrewSkillPoints}";
					modConfigLog += $"\n > Property [minPlayerCrewSkillsLimit] loaded with value: {FFU_BE_Defs.minPlayerCrewSkillsLimit}";
					modConfigLog += $"\n > Property [minEnemyCrewSkillsLimit] loaded with value: {FFU_BE_Defs.minEnemyCrewSkillsLimit}";
					modConfigLog += $"\n > Property [shipMaxEvasionLimit] loaded with value: {FFU_BE_Defs.shipMaxEvasionLimit}";
					modConfigLog += $"\n > Property [shipModuleHealthMult] loaded with value: {FFU_BE_Defs.shipModuleHealthMult}";
					modConfigLog += $"\n > Property [shipModuleUnpackTime] loaded with value: {FFU_BE_Defs.shipModuleUnpackTime}";
					modConfigLog += $"\n > Property [shipModuleCraftTime] loaded with value: {FFU_BE_Defs.shipModuleCraftTime}";
					modConfigLog += $"\n > Property [moduleFireStartChance] loaded with value: {FFU_BE_Defs.moduleFireStartChance}";
					modConfigLog += $"\n > Property [coreSlotsHealthMult] loaded with value: {FFU_BE_Defs.coreSlotsHealthMult}";
					modConfigLog += $"\n > Property [enemyResourcesLootMinMult] loaded with value: {FFU_BE_Defs.enemyResourcesLootMinMult}";
					modConfigLog += $"\n > Property [enemyResourcesLootMaxMult] loaded with value: {FFU_BE_Defs.enemyResourcesLootMaxMult}";
					modConfigLog += $"\n > Property [enemyShipHullHealthMult] loaded with value: {FFU_BE_Defs.enemyShipHullHealthMult}";
					modConfigLog += $"\n > Property [tierResearchSpeedMult] loaded with value: {FFU_BE_Defs.tierResearchSpeedMult}";
					modConfigLog += $"\n > Property [moduleResearchSpeedMult] loaded with value: {FFU_BE_Defs.moduleResearchSpeedMult}";
					modConfigLog += $"\n > Property [intactModuleDropChance] loaded with value: {FFU_BE_Defs.intactModuleDropChance}";
					modConfigLog += $"\n > Property [warpProducedResearchMult] loaded with value: {FFU_BE_Defs.warpProducedResearchMult}";
					modConfigLog += $"\n > Property [warpProducedResourcesMult] loaded with value: {FFU_BE_Defs.warpProducedResourcesMult}";
					modConfigLog += $"\n > Property [enemyCrewHealthSectorMult] loaded with value: {FFU_BE_Defs.enemyCrewHealthSectorMult}";
					foreach (string shipEntry in shipEntries) {
						if (!string.IsNullOrEmpty(modConfig["CrewSpawn"]["ship" + shipEntry].GetString())) {
							string[] crewSets = modConfig["CrewSpawn"]["ship" + shipEntry].GetString().Split('|');
							int[] crewTypes = new int[crewSets.Length];
							int[] crewNumbers = new int[crewSets.Length];
							if (crewSets.Length > 0) {
								for (int i = 0; i < crewSets.Length; i++) {
									string[] tmpStrArr = crewSets[i].Split('*');
									if (tmpStrArr.Length == 2) { 
										bool typeParse = int.TryParse(tmpStrArr[0], out crewTypes[i]);
										bool numParse = int.TryParse(tmpStrArr[1], out crewNumbers[i]);
										if (!typeParse || !numParse) Debug.LogWarning($"Syntax error in \"ship{shipEntry}\" #{i}! Please follow \"PrefabID*Number|PrefabID*Number\" syntax!");
									} else Debug.LogWarning($"Syntax error in \"ship{shipEntry}\" #{i}! Please follow \"PrefabID*Number|PrefabID*Number\" syntax!");
								}
								if (!FFU_BE_Defs.startingCrew.ContainsKey(GetShipPrefabID(shipEntry)))
									FFU_BE_Defs.startingCrew.Add(new KeyValuePair<int, List<KeyValuePair<int, int>>>(GetShipPrefabID(shipEntry), new List<KeyValuePair<int, int>>()));
								if (FFU_BE_Defs.startingCrew.ContainsKey(GetShipPrefabID(shipEntry))) {
									for (int i = 0; i < crewTypes.Length && i < crewNumbers.Length; i++) {
										if (crewTypes[i] > 0 && crewNumbers[i] > 0) {
											KeyValuePair<int, int> crewEntry = FFU_BE_Defs.startingCrew[GetShipPrefabID(shipEntry)].Find(x => x.Key == crewTypes[i]);
											if (FFU_BE_Defs.startingCrew[GetShipPrefabID(shipEntry)].Where(x => x.Key == crewTypes[i]).Count() > 0) FFU_BE_Defs.startingCrew[GetShipPrefabID(shipEntry)].RemoveAt(FFU_BE_Defs.startingCrew[GetShipPrefabID(shipEntry)].IndexOf(crewEntry));
											FFU_BE_Defs.startingCrew[GetShipPrefabID(shipEntry)].Add(new KeyValuePair<int, int>(crewTypes[i], crewNumbers[i]));
										}
									}
								}
							}
						}
					}
					foreach (var coreCrewEntry in FFU_BE_Defs.startingCrew) {
						modConfigLog += $"\n > Additional [{GetShipNameByID(coreCrewEntry.Key)}] Crew: ";
						foreach (var subCrewEntry in coreCrewEntry.Value) modConfigLog += $"{subCrewEntry.Value}x {FFU_BE_Mod_Crewmembers.GetCrewNameFromID(subCrewEntry.Key)}{(coreCrewEntry.Value.Last().Key != subCrewEntry.Key ? ", " : "")}";
					}
					Debug.LogWarning(modConfigLog);
				} else CreateModConfiguration(modConfDir, modConfFile);
			}
		}
		public static void CreateModConfiguration(string modConfDir, string modConfFile) {
			Debug.LogWarning("Mod configuration file doesn't exists or obsolete!");
			Debug.LogWarning("Creating template mod configuration file at " + appDataPath + modConfDir + modConfFile);
			IniFile modConfig = new IniFile();
			modConfig["InitConfig"]["modVersion"] = FFU_BE_Defs.modVersion;
			modConfig["InitConfig"]["unlockShips"] = false;
			modConfig["InitConfig"]["unlockPerks"] = false;
			modConfig["InitConfig"]["grantTopTech"] = false;
			modConfig["InitConfig"]["fullGameReset"] = false;
			modConfig["Settings"]["allModulesCraftable"] = false;
			modConfig["Settings"]["allTypesCraftable"] = false;
			modConfig["Settings"]["moduleCraftingForFree"] = false;
			modConfig["Settings"]["fuelIsCraftingEnergy"] = true;
			modConfig["Settings"]["fuelIsScrapRefunded"] = false;
			modConfig["Settings"]["relativeEnemyCrewSkills"] = true;
			modConfig["Settings"]["listAllCrewmemberTypes"] = false;
			modConfig["Multipliers"]["containerSizeMultiplier"] = 1.0f;
			modConfig["Multipliers"]["resourcesScrapFraction"] = 0.2f;
			modConfig["Multipliers"]["newStartingFateBonus"] = 0;
			modConfig["Multipliers"]["addFreeCrewSkillPoints"] = 0;
			modConfig["Multipliers"]["minPlayerCrewSkillsLimit"] = 1;
			modConfig["Multipliers"]["minEnemyCrewSkillsLimit"] = 1;
			modConfig["Multipliers"]["shipMaxEvasionLimit"] = 95;
			modConfig["Multipliers"]["shipModuleHealthMult"] = 3.0f;
			modConfig["Multipliers"]["shipModuleUnpackTime"] = 60.0f;
			modConfig["Multipliers"]["shipModuleCraftTime"] = 120.0f;
			modConfig["Multipliers"]["moduleFireStartChance"] = 1.0f;
			modConfig["Multipliers"]["coreSlotsHealthMult"] = 1.0f;
			modConfig["Multipliers"]["enemyResourcesLootMinMult"] = 2.0f;
			modConfig["Multipliers"]["enemyResourcesLootMaxMult"] = 5.0f;
			modConfig["Multipliers"]["enemyShipHullHealthMult"] = 10.0f;
			modConfig["Multipliers"]["tierResearchSpeedMult"] = 1.0f;
			modConfig["Multipliers"]["moduleResearchSpeedMult"] = 1.0f;
			modConfig["Multipliers"]["intactModuleDropChance"] = 0.85f;
			modConfig["Multipliers"]["warpProducedResearchMult"] = 0.8f;
			modConfig["Multipliers"]["warpProducedResourcesMult"] = 0.8f;
			modConfig["Multipliers"]["enemyCrewHealthSectorMult"] = 0.1f;
			modConfig["CrewSpawn"]["shipTigerfish"] = "826379097*2|1481089982*2";
			modConfig["CrewSpawn"]["shipNukeRunner"] = "190195895*2|1589791427*2";
			modConfig["CrewSpawn"]["shipRogueRat"] = "745155399*2|1349353450*2";
			modConfig["CrewSpawn"]["shipException"] = "768455465*4";
			modConfig["CrewSpawn"]["shipAtlas"] = "826379097*2|190195895*4";
			modConfig["CrewSpawn"]["shipEasyTiger"] = "826379097*4|1727276051*2";
			modConfig["CrewSpawn"]["shipRoundship"] = "826379097*2|488555786*6";
			modConfig["CrewSpawn"]["shipWeirdship"] = "488555786*2|768455465*2";
			modConfig["CrewSpawn"]["shipEngiship"] = "826379097*2|190195895*2|1351800556*4";
			modConfig["CrewSpawn"]["shipBluestar"] = "421109168*4|1481089982*4";
			modConfig["CrewSpawn"]["shipGardenship"] = "826379097*4|1481089982*2";
			modConfig["CrewSpawn"]["shipBattleTiger"] = "826379097*4|190195895*2|1481089982*2|1727276051*2";
			modConfig["CrewSpawn"]["shipShybettle"] = "768455465*4|928833842*4|488555786*4";
			modConfig["CrewSpawn"]["shipEndurance"] = "826379097*4|190195895*4|1351800556*4";
			modConfig.Save(appDataPath + modConfDir + modConfFile);
		}
		public static List<int> allPerksList = new List<int>(new int[] {
			42388666,
			66885230,
			487234563,
			516057105,
			578937222,
			853503871,
			1106792042,
			1251918188,
			1772361532,
			1809014558,
			1920692188,
			1939804939,
			2103659466,
			3870557,
			6974583,
			16054811,
			22277590,
			28078182,
			28205014,
			28396574,
			69059130,
			75978646,
			81789966,
			82318717,
			83526129,
			117807373,
			124153277,
			131783302,
			136575048,
			136621601,
			141752450,
			142590729,
			152890152,
			153460441,
			161683945,
			174917737,
			184540469,
			187729117,
			203859815,
			209451390,
			225180168,
			237545307,
			260900693,
			272967497,
			283158951,
			285860403,
			305450922,
			326598807,
			335666066,
			344652167,
			361125977,
			367285597,
			388240334,
			406945286,
			411849296,
			430920595,
			450353830,
			450636944,
			462414045,
			463511730,
			484808345,
			507217483,
			522883132,
			547639251,
			548302033,
			566836399,
			584291632,
			600376461,
			610158979,
			611909834,
			633108626,
			655868932,
			656830655,
			746099772,
			754443567,
			755906886,
			768469910,
			780498261,
			786995751,
			798752091,
			798912976,
			817992879,
			850100445,
			858785858,
			872216984,
			873280599,
			873320189,
			883360183,
			889458515,
			905925927,
			907765912,
			907839204,
			910502010,
			917843686,
			918962338,
			936025880,
			945087461,
			986856836,
			989922131,
			996292804,
			1002977681,
			1019109695,
			1042155144,
			1048034788,
			1071540180,
			1092748221,
			1101108011,
			1105381290,
			1105713209,
			1108785668,
			1109573451,
			1114131722,
			1137508603,
			1138940531,
			1163778916,
			1246169320,
			1248482139,
			1252646026,
			1260454991,
			1273038811,
			1289207917,
			1304884710,
			1311577453,
			1312794238,
			1332005888,
			1339234810,
			1362449879,
			1406333136,
			1420718850,
			1425666963,
			1447363940,
			1461582440,
			1491789515,
			1491901717,
			1494259635,
			1504797922,
			1506790699,
			1511793584,
			1512141944,
			1512794172,
			1524517897,
			1555035434,
			1559119211,
			1559698830,
			1565459393,
			1569517835,
			1570827982,
			1577853994,
			1581121396,
			1581853207,
			1585922370,
			1590596161,
			1599767297,
			1607974324,
			1610304684,
			1633476255,
			1636676425,
			1636676426,
			1666507194,
			1672628015,
			1672628016,
			1687140155,
			1688834803,
			1711522921,
			1722324010,
			1734489161,
			1744683542,
			1763651597,
			1765157179,
			1783804007,
			1794605234,
			1809779126,
			1819699687,
			1821549491,
			1828524155,
			1840253454,
			1852263270,
			1857941328,
			1860396564,
			1860627745,
			1872158117,
			1886509521,
			1890494450,
			1904910966,
			1908150008,
			1913754090,
			1920833206,
			1960274027,
			1975921437,
			1983487017,
			1984849323,
			1993735695,
			1995216412,
			2032285499,
			2033479731,
			2036238841,
			2037439773,
			2043215293,
			2060998335,
			2073301424,
			2073380488,
			2075504578,
			2098263678,
			2106414951,
			2114506397,
			2140969742
		});
		public static List<int> allShipsList = new List<int>(new int[] {
			42388666,
			66885230,
			487234563,
			516057105,
			578937222,
			853503871,
			1106792042,
			1251918188,
			1772361532,
			1809014558,
			1920692188,
			1939804939,
			2103659466
		});
	}
}