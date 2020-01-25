using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Base {
		public static readonly string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\LocalLow\Interactive Fate\Shortest Trip To Earth\";
		private static readonly string[] shipEntries = { "shipTigerfish", "shipNukeRunner", "shipWeirdship", "shipRogueRat", "shipGardenship", "shipAtlas", "shipBluestar", "shipRoundship", "shipEndurance", "shipBattleTiger" };
		private static int GetShipType(string shipType) {
			switch (shipType) {
				case "shipTigerfish": return 0;
				case "shipNukeRunner": return 1;
				case "shipWeirdship": return 2;
				case "shipRogueRat": return 3;
				case "shipGardenship": return 4;
				case "shipAtlas": return 5;
				case "shipBluestar": return 6;
				case "shipRoundship": return 7;
				case "shipEndurance": return 8;
				case "shipBattleTiger": return 9;
				default: return 0;
			}
		}
		private static string GetShipName(string shipType) {
			switch (shipType) {
				case "shipTigerfish": return "Tigerfish";
				case "shipNukeRunner": return "Nuke Runner";
				case "shipWeirdship": return "Fierce Sincerity";
				case "shipRogueRat": return "Rogue Rat";
				case "shipGardenship": return "Pumpkin Hammer";
				case "shipAtlas": return "Atlas";
				case "shipBluestar": return "Bluestar";
				case "shipRoundship": return "Warpshell";
				case "shipEndurance": return "Endurance";
				case "shipBattleTiger": return "Battle Tiger";
				default: return "?";
			}
		}
		public static void LoadModConfiguration() {
			if (!string.IsNullOrEmpty(appDataPath)) {
				string modConfDir = @"ModsConf\";
				string modConfFile = @"FFU_Bleeding_Edge.ini";
				if (!Directory.Exists(appDataPath + modConfDir)) Directory.CreateDirectory(appDataPath + modConfDir);
				if (File.Exists(appDataPath + modConfDir + modConfFile)) {
					IniFile modConfig = new IniFile();
					modConfig.Load(appDataPath + modConfDir + modConfFile);
					string modConfigLog = "Loading mod configuration from " + appDataPath + modConfDir + modConfFile;
					if (modConfig["Settings"]["enableModdedContent"].TryConvertBool(out FFU_BE_Defs.enableModdedContent)) modConfigLog += "\n > " + ("Property \"enableModdedContent\" loaded with value: " + FFU_BE_Defs.enableModdedContent.ToString());
					else { FFU_BE_Defs.enableModdedContent = true; modConfigLog += "\n > " + ("Property \"enableModdedContent\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.enableModdedContent.ToString()); }
					if (modConfig["Settings"]["advancedWelcomePopup"].TryConvertBool(out FFU_BE_Defs.advancedWelcomePopup)) modConfigLog += "\n > " + ("Property \"advancedWelcomePopup\" loaded with value: " + FFU_BE_Defs.advancedWelcomePopup.ToString());
					else { FFU_BE_Defs.advancedWelcomePopup = false; modConfigLog += "\n > " + ("Property \"advancedWelcomePopup\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.advancedWelcomePopup.ToString()); }
					if (modConfig["Settings"]["restartUnlocksEverything"].TryConvertBool(out FFU_BE_Defs.restartUnlocksEverything)) modConfigLog += "\n > " + ("Property \"restartUnlocksEverything\" loaded with value: " + FFU_BE_Defs.restartUnlocksEverything.ToString());
					else { FFU_BE_Defs.restartUnlocksEverything = false; modConfigLog += "\n > " + ("Property \"restartUnlocksEverything\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.restartUnlocksEverything.ToString()); }
					if (modConfig["Settings"]["allModulesCraftable"].TryConvertBool(out FFU_BE_Defs.allModulesCraftable)) modConfigLog += "\n > " + ("Property \"allModulesCraftable\" loaded with value: " + FFU_BE_Defs.allModulesCraftable.ToString());
					else { FFU_BE_Defs.allModulesCraftable = false; modConfigLog += "\n > " + ("Property \"allModulesCraftable\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.allModulesCraftable.ToString()); }
					if (modConfig["Settings"]["allTypesCraftable"].TryConvertBool(out FFU_BE_Defs.allTypesCraftable)) modConfigLog += "\n > " + ("Property \"allTypesCraftable\" loaded with value: " + FFU_BE_Defs.allTypesCraftable.ToString());
					else { FFU_BE_Defs.allTypesCraftable = false; modConfigLog += "\n > " + ("Property \"allTypesCraftable\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.allTypesCraftable.ToString()); }
					if (modConfig["Settings"]["moduleCraftingForFree"].TryConvertBool(out FFU_BE_Defs.moduleCraftingForFree)) modConfigLog += "\n > " + ("Property \"moduleCraftingForFree\" loaded with value: " + FFU_BE_Defs.moduleCraftingForFree.ToString());
					else { FFU_BE_Defs.moduleCraftingForFree = false; modConfigLog += "\n > " + ("Property \"moduleCraftingForFree\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.moduleCraftingForFree.ToString()); }
					if (modConfig["Settings"]["fuelIsCraftingEnergy"].TryConvertBool(out FFU_BE_Defs.fuelIsCraftingEnergy)) modConfigLog += "\n > " + ("Property \"fuelIsCraftingEnergy\" loaded with value: " + FFU_BE_Defs.fuelIsCraftingEnergy.ToString());
					else { FFU_BE_Defs.fuelIsCraftingEnergy = true; modConfigLog += "\n > " + ("Property \"fuelIsCraftingEnergy\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.fuelIsCraftingEnergy.ToString()); }
					if (modConfig["Settings"]["fuelIsScrapRefunded"].TryConvertBool(out FFU_BE_Defs.fuelIsScrapRefunded)) modConfigLog += "\n > " + ("Property \"fuelIsScrapRefunded\" loaded with value: " + FFU_BE_Defs.fuelIsScrapRefunded.ToString());
					else { FFU_BE_Defs.fuelIsScrapRefunded = false; modConfigLog += "\n > " + ("Property \"fuelIsScrapRefunded\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.fuelIsScrapRefunded.ToString()); }
					if (modConfig["Settings"]["relativeEnemyCrewSkills"].TryConvertBool(out FFU_BE_Defs.relativeEnemyCrewSkills)) modConfigLog += "\n > " + ("Property \"relativeEnemyCrewSkills\" loaded with value: " + FFU_BE_Defs.relativeEnemyCrewSkills.ToString());
					else { FFU_BE_Defs.relativeEnemyCrewSkills = true; modConfigLog += "\n > " + ("Property \"relativeEnemyCrewSkills\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.relativeEnemyCrewSkills.ToString()); }
					if (modConfig["Multipliers"]["containerSizeMultiplier"].TryConvertFloat(out FFU_BE_Defs.containerSizeMultiplier)) modConfigLog += "\n > " + ("Property \"containerSizeMultiplier\" loaded with value: " + FFU_BE_Defs.containerSizeMultiplier.ToString());
					else { FFU_BE_Defs.containerSizeMultiplier = 1.0f; modConfigLog += "\n > " + ("Property \"containerSizeMultiplier\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.containerSizeMultiplier.ToString()); }
					if (modConfig["Multipliers"]["resourcesScrapFraction"].TryConvertFloat(out FFU_BE_Defs.resourcesScrapFraction)) modConfigLog += "\n > " + ("Property \"resourcesScrapFraction\" loaded with value: " + FFU_BE_Defs.resourcesScrapFraction.ToString());
					else { FFU_BE_Defs.resourcesScrapFraction = 0.2f; modConfigLog += "\n > " + ("Property \"resourcesScrapFraction\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.resourcesScrapFraction.ToString()); }
					if (modConfig["Multipliers"]["newStartingFateBonus"].TryConvertInt(out FFU_BE_Defs.newStartingFateBonus)) modConfigLog += "\n > " + ("Property \"newStartingFateBonus\" loaded with value: " + FFU_BE_Defs.newStartingFateBonus.ToString());
					else { FFU_BE_Defs.newStartingFateBonus = 0; modConfigLog += "\n > " + ("Property \"newStartingFateBonus\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.newStartingFateBonus.ToString()); }
					if (modConfig["Multipliers"]["addFreeCrewSkillPoints"].TryConvertInt(out FFU_BE_Defs.addFreeCrewSkillPoints)) modConfigLog += "\n > " + ("Property \"addFreeCrewSkillPoints\" loaded with value: " + FFU_BE_Defs.addFreeCrewSkillPoints.ToString());
					else { FFU_BE_Defs.addFreeCrewSkillPoints = 0; modConfigLog += "\n > " + ("Property \"addFreeCrewSkillPoints\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.addFreeCrewSkillPoints.ToString()); }
					if (modConfig["Multipliers"]["minPlayerCrewSkillsLimit"].TryConvertInt(out FFU_BE_Defs.minPlayerCrewSkillsLimit)) modConfigLog += "\n > " + ("Property \"minPlayerCrewSkillsLimit\" loaded with value: " + FFU_BE_Defs.minPlayerCrewSkillsLimit.ToString());
					else { FFU_BE_Defs.minPlayerCrewSkillsLimit = 1; modConfigLog += "\n > " + ("Property \"minPlayerCrewSkillsLimit\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.minPlayerCrewSkillsLimit.ToString()); }
					if (modConfig["Multipliers"]["minEnemyCrewSkillsLimit"].TryConvertInt(out FFU_BE_Defs.minEnemyCrewSkillsLimit)) modConfigLog += "\n > " + ("Property \"minEnemyCrewSkillsLimit\" loaded with value: " + FFU_BE_Defs.minEnemyCrewSkillsLimit.ToString());
					else { FFU_BE_Defs.minEnemyCrewSkillsLimit = 1; modConfigLog += "\n > " + ("Property \"minEnemyCrewSkillsLimit\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.minEnemyCrewSkillsLimit.ToString()); }
					if (modConfig["Multipliers"]["enemyShipCrewSizeMult"].TryConvertInt(out FFU_BE_Defs.enemyShipCrewSizeMult)) modConfigLog += "\n > " + ("Property \"enemyShipCrewSizeMult\" loaded with value: " + FFU_BE_Defs.enemyShipCrewSizeMult.ToString());
					else { FFU_BE_Defs.enemyShipCrewSizeMult = 1; modConfigLog += "\n > " + ("Property \"enemyShipCrewSizeMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.enemyShipCrewSizeMult.ToString()); }
					if (modConfig["Multipliers"]["shipMaxEvasionLimit"].TryConvertInt(out FFU_BE_Defs.shipMaxEvasionLimit)) modConfigLog += "\n > " + ("Property \"shipMaxEvasionLimit\" loaded with value: " + FFU_BE_Defs.shipMaxEvasionLimit.ToString());
					else { FFU_BE_Defs.shipMaxEvasionLimit = 95; modConfigLog += "\n > " + ("Property \"shipMaxEvasionLimit\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.shipMaxEvasionLimit.ToString()); }
					if (modConfig["Multipliers"]["shipModuleHealthMult"].TryConvertFloat(out FFU_BE_Defs.shipModuleHealthMult)) modConfigLog += "\n > " + ("Property \"shipModuleHealthMult\" loaded with value: " + FFU_BE_Defs.shipModuleHealthMult.ToString());
					else { FFU_BE_Defs.shipModuleHealthMult = 3f; modConfigLog += "\n > " + ("Property \"shipModuleHealthMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.shipModuleHealthMult.ToString()); }
					if (modConfig["Multipliers"]["shipModuleUnpackTime"].TryConvertFloat(out FFU_BE_Defs.shipModuleUnpackTime)) modConfigLog += "\n > " + ("Property \"shipModuleUnpackTime\" loaded with value: " + FFU_BE_Defs.shipModuleUnpackTime.ToString());
					else { FFU_BE_Defs.shipModuleUnpackTime = 60f; modConfigLog += "\n > " + ("Property \"shipModuleUnpackTime\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.shipModuleUnpackTime.ToString()); }
					if (modConfig["Multipliers"]["shipModuleCraftTime"].TryConvertFloat(out FFU_BE_Defs.shipModuleCraftTime)) modConfigLog += "\n > " + ("Property \"shipModuleCraftTime\" loaded with value: " + FFU_BE_Defs.shipModuleCraftTime.ToString());
					else { FFU_BE_Defs.shipModuleCraftTime = 120f; modConfigLog += "\n > " + ("Property \"shipModuleCraftTime\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.shipModuleCraftTime.ToString()); }
					if (modConfig["Multipliers"]["coreSlotsHealthMult"].TryConvertFloat(out FFU_BE_Defs.coreSlotsHealthMult)) modConfigLog += "\n > " + ("Property \"coreSlotsHealthMult\" loaded with value: " + FFU_BE_Defs.coreSlotsHealthMult.ToString());
					else { FFU_BE_Defs.coreSlotsHealthMult = 1f; modConfigLog += "\n > " + ("Property \"coreSlotsHealthMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.coreSlotsHealthMult.ToString()); }
					if (modConfig["Multipliers"]["enemyResourcesLootMinMult"].TryConvertFloat(out FFU_BE_Defs.enemyResourcesLootMinMult)) modConfigLog += "\n > " + ("Property \"enemyResourcesLootMinMult\" loaded with value: " + FFU_BE_Defs.enemyResourcesLootMinMult.ToString());
					else { FFU_BE_Defs.enemyResourcesLootMinMult = 2; modConfigLog += "\n > " + ("Property \"enemyResourcesLootMinMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.enemyResourcesLootMinMult.ToString()); }
					if (modConfig["Multipliers"]["enemyResourcesLootMaxMult"].TryConvertFloat(out FFU_BE_Defs.enemyResourcesLootMaxMult)) modConfigLog += "\n > " + ("Property \"enemyResourcesLootMaxMult\" loaded with value: " + FFU_BE_Defs.enemyResourcesLootMaxMult.ToString());
					else { FFU_BE_Defs.enemyResourcesLootMaxMult = 5f; modConfigLog += "\n > " + ("Property \"enemyResourcesLootMaxMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.enemyResourcesLootMaxMult.ToString()); }
					if (modConfig["Multipliers"]["enemyShipHullHealthMult"].TryConvertFloat(out FFU_BE_Defs.enemyShipHullHealthMult)) modConfigLog += "\n > " + ("Property \"enemyShipHullHealthMult\" loaded with value: " + FFU_BE_Defs.enemyShipHullHealthMult.ToString());
					else { FFU_BE_Defs.enemyShipHullHealthMult = 10f; modConfigLog += "\n > " + ("Property \"enemyShipHullHealthMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.enemyShipHullHealthMult.ToString()); }
					if (modConfig["Multipliers"]["tierResearchSpeedMult"].TryConvertFloat(out FFU_BE_Defs.tierResearchSpeedMult)) modConfigLog += "\n > " + ("Property \"tierResearchSpeedMult\" loaded with value: " + FFU_BE_Defs.tierResearchSpeedMult.ToString());
					else { FFU_BE_Defs.tierResearchSpeedMult = 1f; modConfigLog += "\n > " + ("Property \"tierResearchSpeedMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.tierResearchSpeedMult.ToString()); }
					if (modConfig["Multipliers"]["moduleResearchSpeedMult"].TryConvertFloat(out FFU_BE_Defs.moduleResearchSpeedMult)) modConfigLog += "\n > " + ("Property \"moduleResearchSpeedMult\" loaded with value: " + FFU_BE_Defs.moduleResearchSpeedMult.ToString());
					else { FFU_BE_Defs.moduleResearchSpeedMult = 1f; modConfigLog += "\n > " + ("Property \"moduleResearchSpeedMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.moduleResearchSpeedMult.ToString()); }
					if (modConfig["Multipliers"]["intactModuleDropChance"].TryConvertFloat(out FFU_BE_Defs.intactModuleDropChance)) modConfigLog += "\n > " + ("Property \"intactModuleDropChance\" loaded with value: " + FFU_BE_Defs.intactModuleDropChance.ToString());
					else { FFU_BE_Defs.intactModuleDropChance = 0.85f; modConfigLog += "\n > " + ("Property \"intactModuleDropChance\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.intactModuleDropChance.ToString()); }
					if (modConfig["Multipliers"]["warpProducedResearchMult"].TryConvertFloat(out FFU_BE_Defs.warpProducedResearchMult)) modConfigLog += "\n > " + ("Property \"warpProducedResearchMult\" loaded with value: " + FFU_BE_Defs.warpProducedResearchMult.ToString());
					else { FFU_BE_Defs.warpProducedResearchMult = 0.8f; modConfigLog += "\n > " + ("Property \"warpProducedResearchMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.warpProducedResearchMult.ToString()); }
					if (modConfig["Multipliers"]["warpProducedResourcesMult"].TryConvertFloat(out FFU_BE_Defs.warpProducedResourcesMult)) modConfigLog += "\n > " + ("Property \"warpProducedResourcesMult\" loaded with value: " + FFU_BE_Defs.warpProducedResourcesMult.ToString());
					else { FFU_BE_Defs.warpProducedResourcesMult = 0.8f; modConfigLog += "\n > " + ("Property \"warpProducedResourcesMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.warpProducedResourcesMult.ToString()); }
					if (modConfig["Multipliers"]["enemyCrewHealthSectorMult"].TryConvertFloat(out FFU_BE_Defs.enemyCrewHealthSectorMult)) modConfigLog += "\n > " + ("Property \"enemyCrewHealthSectorMult\" loaded with value: " + FFU_BE_Defs.enemyCrewHealthSectorMult.ToString());
					else { FFU_BE_Defs.enemyCrewHealthSectorMult = 0.1f; modConfigLog += "\n > " + ("Property \"enemyCrewHealthSectorMult\" is not found or couldn't be parsed, using default value: " + FFU_BE_Defs.enemyCrewHealthSectorMult.ToString()); }
					foreach (string shipEntry in shipEntries) {
						if (!string.IsNullOrEmpty(modConfig["CrewSpawn"][shipEntry + "Types"].GetString()) && !string.IsNullOrEmpty(modConfig["CrewSpawn"][shipEntry + "Numbers"].GetString())) {
							string endResult = "";
							string[] tmpStrArrT = new string[] { };
							string[] tmpStrArrN = new string[] { };
							tmpStrArrT = modConfig["CrewSpawn"][shipEntry + "Types"].GetString().Split('|');
							tmpStrArrN = modConfig["CrewSpawn"][shipEntry + "Numbers"].GetString().Split('|');
							if (tmpStrArrT.Length > 0) for (int t = 0; t < tmpStrArrT.Length; t++) FFU_BE_Defs.crewTypesOnStart[GetShipType(shipEntry)][t] = tmpStrArrT[t];
							else FFU_BE_Defs.crewTypesOnStart[GetShipType(shipEntry)][0] = modConfig["CrewSpawn"][shipEntry + "Types"].GetString();
							if (tmpStrArrN.Length > 0) for (int t = 0; t < tmpStrArrN.Length; t++) FFU_BE_Defs.crewNumsOnStart[GetShipType(shipEntry)][t] = tmpStrArrN[t];
							else FFU_BE_Defs.crewNumsOnStart[GetShipType(shipEntry)][0] = modConfig["CrewSpawn"][shipEntry + "Numbers"].GetString();
							if (tmpStrArrT.Length > 0) for (int x = 0; x < tmpStrArrT.Length; x++) endResult += tmpStrArrN[x] + "x " + tmpStrArrT[x] + (x < tmpStrArrT.Length - 1 ? ", " : "");
							modConfigLog += "\n > " + ("Additional \"" + GetShipName(shipEntry) + "\" Crew: " + endResult);
						}
					}
					Debug.LogWarning(modConfigLog);
				} else {
					Debug.LogWarning("Mod configuration file doesn't exists!");
					Debug.LogWarning("Creating template mod configuration file at " + appDataPath + modConfDir + modConfFile);
					IniFile modConfig = new IniFile();
					modConfig["Settings"]["enableModdedContent"] = true;
					modConfig["Settings"]["advancedWelcomePopup"] = false;
					modConfig["Settings"]["restartUnlocksEverything"] = false;
					modConfig["Settings"]["allModulesCraftable"] = false;
					modConfig["Settings"]["allTypesCraftable"] = false;
					modConfig["Settings"]["moduleCraftingForFree"] = false;
					modConfig["Settings"]["fuelIsCraftingEnergy"] = true;
					modConfig["Settings"]["fuelIsScrapRefunded"] = false;
					modConfig["Settings"]["relativeEnemyCrewSkills"] = true;
					modConfig["Multipliers"]["containerSizeMultiplier"] = 1.0f;
					modConfig["Multipliers"]["resourcesScrapFraction"] = 0.2f;
					modConfig["Multipliers"]["newStartingFateBonus"] = 0;
					modConfig["Multipliers"]["addFreeCrewSkillPoints"] = 0;
					modConfig["Multipliers"]["minPlayerCrewSkillsLimit"] = 1;
					modConfig["Multipliers"]["minEnemyCrewSkillsLimit"] = 1;
					modConfig["Multipliers"]["enemyShipCrewSizeMult"] = 1;
					modConfig["Multipliers"]["shipMaxEvasionLimit"] = 95;
					modConfig["Multipliers"]["shipModuleHealthMult"] = 3.0f;
					modConfig["Multipliers"]["shipModuleUnpackTime"] = 60.0f;
					modConfig["Multipliers"]["shipModuleCraftTime"] = 120.0f;
					modConfig["Multipliers"]["coreSlotsHealthMult"] = 1.0f;
					modConfig["Multipliers"]["enemyResourcesLootMinMult"] = 2.0f;
					modConfig["Multipliers"]["enemyResourcesLootMaxMult"] = 5.0f;
					modConfig["Multipliers"]["tierResearchSpeedMult"] = 1.0f;
					modConfig["Multipliers"]["moduleResearchSpeedMult"] = 1.0f;
					modConfig["Multipliers"]["intactModuleDropChance"] = 0.85f;
					modConfig["Multipliers"]["warpProducedResearchMult"] = 0.8f;
					modConfig["Multipliers"]["warpProducedResourcesMult"] = 0.8f;
					modConfig["Multipliers"]["enemyCrewHealthSectorMult"] = 0.1f;
					modConfig["CrewSpawn"]["shipTigerfishTypes"] = "Combat Drone Humanoid|Drone tigerspider";
					modConfig["CrewSpawn"]["shipTigerfishNumbers"] = "3|2";
					modConfig["CrewSpawn"]["shipNukeRunnerTypes"] = "Heavy security drone|Drone CT2 gunnery";
					modConfig["CrewSpawn"]["shipNukeRunnerNumbers"] = "3|2";
					modConfig["CrewSpawn"]["shipWeirdshipTypes"] = "Redripper crew|Beedroid crew";
					modConfig["CrewSpawn"]["shipWeirdshipNumbers"] = "2|1";
					modConfig["CrewSpawn"]["shipRogueRatTypes"] = "Drone DIY gunjunker|Drone DIY gunnery pirates cannon";
					modConfig["CrewSpawn"]["shipRogueRatNumbers"] = "2|2";
					modConfig["CrewSpawn"]["shipGardenshipTypes"] = "Combat Drone Humanoid|Drone tigerspider";
					modConfig["CrewSpawn"]["shipGardenshipNumbers"] = "2|2";
					modConfig["CrewSpawn"]["shipAtlasTypes"] = "Combat Drone Humanoid|Heavy security drone";
					modConfig["CrewSpawn"]["shipAtlasNumbers"] = "2|2";
					modConfig["CrewSpawn"]["shipBluestarTypes"] = "Drone DIY science|Drone tigerspider";
					modConfig["CrewSpawn"]["shipBluestarNumbers"] = "4|2";
					modConfig["CrewSpawn"]["shipRoundshipTypes"] = "Combat Drone Humanoid|Redripper crew";
					modConfig["CrewSpawn"]["shipRoundshipNumbers"] = "2|4";
					modConfig["CrewSpawn"]["shipEnduranceTypes"] = "Combat Drone Humanoid|Heavy security drone|Drone tigerspider pirates";
					modConfig["CrewSpawn"]["shipEnduranceNumbers"] = "4|3|3";
					modConfig["CrewSpawn"]["shipBattleTigerTypes"] = "Combat Drone Humanoid|Heavy security drone|Drone tigerspider assaulter|Drone tigerdog";
					modConfig["CrewSpawn"]["shipBattleTigerNumbers"] = "4|2|2|2";
					modConfig.Save(appDataPath + modConfDir + modConfFile);
				}
			}
		}
		public static List<int> allPerksList = new List<int>(new int[] {
			487234563,
			1809014558,
			578937222,
			1106792042,
			2103659466,
			1772361532,
			1251918188,
			1939804939,
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
			153460441,
			161683945,
			174917737,
			184540469,
			187729117,
			203859815,
			209451390,
			225180168,
			237545307,
			272967497,
			283158951,
			285860403,
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
			484808345,
			522883132,
			547639251,
			548302033,
			566836399,
			584291632,
			600376461,
			611909834,
			633108626,
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
			858785858,
			872216984,
			873280599,
			873320189,
			883360183,
			889458515,
			907765912,
			907839204,
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
			1138940531,
			1163778916,
			1246169320,
			1252646026,
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
			1504797922,
			1506790699,
			1511793584,
			1512141944,
			1512794172,
			1524517897,
			1555035434,
			1559119211,
			1559698830,
			1569517835,
			1570827982,
			1577853994,
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
			2075504578,
			2098263678,
			2114506397,
			2140969742
		});
		public static List<int> allShipsList = new List<int>(new int[] {
			487234563,
			1809014558,
			578937222,
			1106792042,
			2103659466,
			1772361532,
			1251918188,
			1939804939
		});
	}
}