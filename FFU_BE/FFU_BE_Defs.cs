using RST;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;
using RST.UI;
using System;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Defs {
		//Internal Variables
		public static bool firstRun = true;
		public static bool firstInst = true;
		public static bool goFullASMD = false;
		public static bool debugMode = false;
		public static bool visualDebug = true;
		public static bool canSpawnCrew = true;
		public static bool dumpObjectLists = false;
		public static bool dumpInstructions = false;
		public static bool allStatProps = false;
		public static bool allModuleProps = false;
		public static bool showSortedList = false;
		public static bool showPrefabIDs = false;
		public static bool showDescription = false;
		public static bool createModulesCSV = false;
		public static int wordWrapLimit = 50;
		public static int moduleRepairCost = 2;
		public static int blackMarketMult = 1111;
		public static float timePassedCycle = 4f;
		public static float shieldBonusMult = 4f;
		public static float researchProgress = 0f;
		public static float equipmentChangeDist = 2f;
		public static float moduleRepairTime = 2f;
		public static float shipHullRepairTime = 5f;
		public static float moduleRepairAcceleration = 25f;
		public static float shipHullRepairAcceleration = 15f;
		public static List<int> updatedShips = new List<int>();
		public static List<Ship> prefabShipsList = new List<Ship>();
		public static List<Beam> prefabBeamRaysList = new List<Beam>();
		public static List<Projectile> prefabProjectilesList = new List<Projectile>();
		public static List<PointDefDamageDealer> prefabDefDealersList = new List<PointDefDamageDealer>();
		public static List<Crewmember> prefabModdedCrewList = new List<Crewmember>();
		public static List<ModuleSlot> prefabModdedSlotsList = new List<ModuleSlot>();
		public static List<ShipModule> prefabModdedModulesList = new List<ShipModule>();
		public static List<SpacePod> prefabModdedSpacePodsList = new List<SpacePod>();
		public static List<HandWeapon> prefabModdedFirearmsList = new List<HandWeapon>();
		public static IDictionary<int, int> equippedCrewFirearms = new Dictionary<int, int>();
		public static IDictionary<int, int> craftingProficiency = new Dictionary<int, int>();
		public static int[] techLevel = new int[] { 0, 1500, 3500, 6000, 10000, 16000, 24000, 34000, 46000, 60000 };
		public static List<int> discoveredModuleIDs = new List<int>(new int[] { 760167696, 453797399, 1581569285,
			345284781, 813048445, 124199597, 92356131, 430038657, 2146165248, 533676501, 858424257, 821254137,
			1780996798, 1521997681, 1751631045, 842299308, 55650103, 144623758, 981179656, 1386212334, 2075523594,
			893617597, 983196801, 1284816050, 2136288774, 482395317, 1700526886, 482395319, 825891570, 1404265275,
			1158881065, 1449641283, 1477762477, 340918825, 165493307, 271236703, 168523420, 429768775, 126798266,
			741193982, 930742757, 1769741276, 236853983, 241738085, 1219429018, 1290558229, 1398713621, 665713195,
			1902866107, 1819161633 });
		public static List<int> essentialTopModuleIDs = new List<int>(new int[] {
			1196638242, /* Nanometric Integrity Armor */
			1148319565, /* Dreadnought Command Bridge */
			41460892,   /* Exploration Cryodream Bay */
			1276182160, /* Phased Stealth Generator */
			171954197,  /* Multi-Phased Sensor Array */
			738383846,  /* Quantum ECM Array */
			383658151,  /* Industrial Drone Bay */
			1304112764, /* Genesis Medical Bay */
			1699316752, /* Antimatter Reactor */
			426751082,  /* Capital XSM Multicontainer */
			1165288718, /* Capital FEO Multicontainer */
			1427874574, /* Zero Point Shield Generator */
			1424188745, /* Zero Point Shield Capacitor */
			728608876,  /* Accelerated Greenhouse */
			737359377,  /* Exogenetic Greenhouse */
			1448350571, /* Quantum Laboratory */
			1559705412, /* Quantum Warp Drive */
			1119228548, /* Particle-Folding Quantum Engine */
			373200662,  /* Industrial Synthetics Printer */
			194638103,  /* Industrial Fuel Refinery */
			1615170861, /* Industrial Ordnance Factory */
			1482294420, /* Industrial Blast Furnace */
			685017033,  /* Mechanical Upgrades Cache */
			957508477,  /* Biological Implants Cache */
			760711671,  /* Laser Type Weapons Cache */
			938711464,  /* Iron Dome Tactical CIWS */
			1571322820  /* Annihilator Rocket Launcher */ });
		public static List<int> unresearchedModuleIDs = new List<int>();
		public static float unusedReverseProgress = 0f;
		public static float moduleResearchProgress = 0f;
		public static float moduleResearchGoal = 0f;
		public static List<string> builtInWeaponTypes = new List<string>(new string[] { "Hand melee insectbite", "Hand melee red claw", "Hand weapon acid gland spray",
			"Hand weapon acid gland spray red", "Hand weapon warp moleculoray", "Hand weapon warp spider", "Hand melee basic fists", "Hand melee blue crystals",
			"Hand melee enhanced fists", "Hand melee teeth", "Hand weapon electric", "Hand weapon flames", "Hand weapon pink ray", "Hand melee mincer"
			/* "Hand weapon drone liquid nitrogen spray", "Hand weapon drone flamer", "Hand weapon welder light", "Hand weapon welder heavy" */ });
		public static List<string> positiveMods = new List<string>(new string[] { "(Sustained)", "(Reinforced)", "(Efficient)", "(Precise)", "(Rapid)", "(Enhanced)", "(Durable)", "(Persistent)" });
		public static List<string> negativeMods = new List<string>(new string[] { "(Unstable)", "(Fragile)", "(Inefficient)", "(Inhibited)", "(Disrupted)", "(Deficient)", "(Brittle)", "(Volatile)" });
		public static List<string> choiceAnchorWords = new List<string>(new string[] { "organic", "fuel", "starfuel", "metal", "synthetic", "explosive", "exotic", "xenodata", "credit" });
		public static List<int> updatedChoices = new List<int>();
		public static bool summonAttempted = true;
		public static bool summonEnforcerFleet = false;
		public static int discoveryScanLevel = 0;
		public static int discoveryFleetsLevel = 0;
		public static float scanFrequency = 1600f;
		public static float energyEmission = 300f;
		public static float distanceTraveledInPeace = 0f;
		public static float[] scanResolution = new float[] { 5000f, 3000f, 1500f, 1000f, 500f };
		public static int[] killedFleetsTrigger = new int[] { 3, 6, 10, 15, 21, 27, 34, 42, 50 };
		public static int[] timesInterceptedByEnforcers = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		//Configuration Variables
		public static bool advancedWelcomePopup = false;
		public static bool restartUnlocksEverything = false;
		public static bool allModulesCraftable = false;
		public static bool allTypesCraftable = false;
		public static bool moduleCraftingForFree = false;
		public static bool fuelIsCraftingEnergy = true;
		public static bool fuelIsScrapRefunded = false;
		public static bool relativeEnemyCrewSkills = true;
		public static float containerSizeMultiplier = 1.0f;
		public static float resourcesScrapFraction = 0.2f;
		public static int newStartingFateBonus = 0;
		public static int addFreeCrewSkillPoints = 0;
		public static int minPlayerCrewSkillsLimit = 1;
		public static int minEnemyCrewSkillsLimit = 1;
		public static int enemyShipCrewSizeMult = 1;
		public static int shipMaxEvasionLimit = 95;
		public static int stationCapacityMult = 20;
		public static int resultNumbersMult = 10;
		public static float shipModuleHealthMult = 3f;
		public static float shipModuleUnpackTime = 60f;
		public static float shipModuleCraftTime = 120f;
		public static float coreSlotsHealthMult = 1f;
		public static float enemyResourcesLootMinMult = 2f;
		public static float enemyResourcesLootMaxMult = 5f;
		public static float enemyShipHullHealthMult = 10f;
		public static float tierResearchSpeedMult = 1f;
		public static float moduleResearchSpeedMult = 1f;
		public static float intactModuleDropChance = 0.85f;
		public static float warpProducedResearchMult = 0.8f;
		public static float warpProducedResourcesMult = 0.8f;
		public static float enemyCrewHealthSectorMult = 0.1f;
		public static string[][] crewTypesOnStart = new string[10][] {
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""}
		};
		public static string[][] crewNumsOnStart = new string[10][] {
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""},
			new string[10] {"","","","","","","","","",""}
		};
		public static void LoadModPropsAndFeatures() {
			if (!firstRun) {
				Debug.LogWarning("Updating and saving custom variables...");
				ES2.Save(discoveredModuleIDs, "permanent.es2?tag=discoveredModuleIDs");
				ES2.Save(unresearchedModuleIDs, "start.es2?tag=unresearchedModuleIDs");
				ES2.Save(researchProgress, "start.es2?tag=researchProgress");
				ES2.Save(moduleResearchGoal, "start.es2?tag=moduleResearchGoal");
				ES2.Save(unusedReverseProgress, "start.es2?tag=unusedReverseProgress");
				ES2.Save(moduleResearchProgress, "start.es2?tag=moduleResearchProgress");
				ES2.Save(distanceTraveledInPeace, "start.es2?tag=distanceTraveledInPeace");
				ES2.Save(timesInterceptedByEnforcers, "start.es2?tag=timesIntercepted");
				ES2.Save(discoveryScanLevel, "start.es2?tag=discoveryScanLevel");
				ES2.Save(discoveryFleetsLevel, "start.es2?tag=discoveryFleetsLevel");
				ES2.Save((Dictionary<int, int>)equippedCrewFirearms, "start.es2?tag=equippedCrewFirearms");
				ES2.Save((Dictionary<int, int>)craftingProficiency, "start.es2?tag=craftingProficiency");
				ES2.Save(summonEnforcerFleet, "start.es2?tag=summonEnforcerFleet");
				ES2.Save(summonAttempted, "start.es2?tag=summonAttempted");
				RecalculateEnergyEmission();
			}
			if (firstRun) {
				Debug.LogWarning("Loading modded data and custom variables for the first time...");
				InitGameTextUpdate();
				InitShipDoorsUpdate();
				InitDamageDealersPrefabList();
				FFU_BE_Mod_Crewmembers.InitFirearmsList();
				FFU_BE_Mod_Crewmembers.InitCrewTypesList();
				FFU_BE_Mod_Crewmembers.InitSpacePodsList();
				FFU_BE_Mod_Modules.InitShipSlotsList();
				FFU_BE_Mod_Modules.InitShipModulesList();
				FFU_BE_Mod_Spaceships.InitSpaceShipsPrefabList();
				if (ES2.Exists("start.es2?tag=researchProgress")) researchProgress = ES2.Load<float>("start.es2?tag=researchProgress");
				if (ES2.Exists("start.es2?tag=moduleResearchGoal")) moduleResearchGoal = ES2.Load<float>("start.es2?tag=moduleResearchGoal");
				if (ES2.Exists("start.es2?tag=unusedReverseProgress")) unusedReverseProgress = ES2.Load<float>("start.es2?tag=unusedReverseProgress");
				if (ES2.Exists("start.es2?tag=moduleResearchProgress")) moduleResearchProgress = ES2.Load<float>("start.es2?tag=moduleResearchProgress");
				if (ES2.Exists("start.es2?tag=unresearchedModuleIDs")) unresearchedModuleIDs = ES2.LoadList<int>("start.es2?tag=unresearchedModuleIDs");
				if (ES2.Exists("start.es2?tag=equippedCrewFirearms")) equippedCrewFirearms = ES2.LoadDictionary<int, int>("start.es2?tag=equippedCrewFirearms");
				if (ES2.Exists("start.es2?tag=craftingProficiency")) craftingProficiency = ES2.LoadDictionary<int, int>("start.es2?tag=craftingProficiency");
				if (ES2.Exists("start.es2?tag=distanceTraveledInPeace")) distanceTraveledInPeace = ES2.Load<float>("start.es2?tag=distanceTraveledInPeace");
				if (ES2.Exists("start.es2?tag=timesIntercepted")) timesInterceptedByEnforcers = ES2.LoadArray<int>("start.es2?tag=timesIntercepted");
				if (ES2.Exists("start.es2?tag=discoveryScanLevel")) discoveryScanLevel = ES2.Load<int>("start.es2?tag=discoveryScanLevel");
				if (ES2.Exists("start.es2?tag=discoveryFleetsLevel")) discoveryFleetsLevel = ES2.Load<int>("start.es2?tag=discoveryFleetsLevel");
				if (ES2.Exists("start.es2?tag=summonEnforcerFleet")) summonEnforcerFleet = ES2.Load<bool>("start.es2?tag=summonEnforcerFleet");
				if (ES2.Exists("start.es2?tag=summonAttempted")) summonAttempted = ES2.Load<bool>("start.es2?tag=summonAttempted");
				if (ES2.Exists("permanent.es2?tag=discoveredModuleIDs")) discoveredModuleIDs = ES2.LoadList<int>("permanent.es2?tag=discoveredModuleIDs");
				else ES2.Save<int>(discoveredModuleIDs, "permanent.es2?tag=discoveredModuleIDs");
				if (goFullASMD) {
					foreach (int moduleID in essentialTopModuleIDs)
						if (!discoveredModuleIDs.Contains(moduleID) &&
							!unresearchedModuleIDs.Contains(moduleID))
							discoveredModuleIDs.Add(moduleID);
					goFullASMD = false;
				}
				firstRun = false;
				RecalculateEnergyEmission();
			}
		}
		public static void InitDamageDealersPrefabList() {
			foreach (ShootAtDamageDealer damageDealer in Resources.FindObjectsOfTypeAll<ShootAtDamageDealer>()) {
				if (damageDealer as Projectile != null) prefabProjectilesList.Add(damageDealer as Projectile);
				else if (damageDealer as Beam != null) prefabBeamRaysList.Add(damageDealer as Beam);
			}
			foreach (PointDefDamageDealer pointDefDamageDealer in Resources.FindObjectsOfTypeAll<PointDefDamageDealer>()) {
				prefabDefDealersList.Add(pointDefDamageDealer);
			}
			if (dumpObjectLists) {
				foreach (PointDefDamageDealer defender in prefabDefDealersList) Debug.Log("Defender: " + defender.name);
				foreach (Projectile projectile in prefabProjectilesList) Debug.Log("Projectile: " + projectile.name);
				foreach (Beam beam in prefabBeamRaysList) Debug.Log("Beam: " + beam.name);
			}
		}
		public static void InitShipDoorsUpdate() {
			foreach (Door door in Resources.FindObjectsOfTypeAll<Door>()) {
				AccessTools.FieldRefAccess<Door, int>(door, "maxHealth") = 275;
				AccessTools.FieldRefAccess<Door, int>(door, "health") = 275;
			}
		}
		public static void InitGameTextUpdate() {
			foreach (Text txt in Resources.FindObjectsOfTypeAll<Text>()) {
				if (txt.name.Contains("WeaponIgnoresShieldValue")) txt.text = "Shield Bypass";
				if (txt.name.Contains("WeaponNeverDeflectsValue")) txt.text = "Deflect Ignore";
			}
		}
		public static void LoadBleedingEdgeWelcome() {
			foreach (Text txt in Resources.FindObjectsOfTypeAll<Text>()) {
				if (txt.text.ToLower().Contains("cancel")) txt.text = "NOPE";
				if (txt.text.ToLower().Contains("start game")) txt.text = "NIGHTMARE MODE ON";
				if (txt.text.ToLower().Contains("discard this offer permanently")) txt.text = "I HAVE ASMD SHOCK RIFLE";
				if (txt.text.ToLower().Contains("reset progress & unlock all ships")) txt.text = "HARD RESET + IDKFA";
				if (txt.text.ToLower().Contains("yes, reset progress and unlock all ships")) txt.text = "TAKE THE " + (restartUnlocksEverything ? "RED" : "BLUE") + " PILL";
				if (txt.text.ToLower().Contains("visit the steam forums if you have questions"))
					txt.text = "If you see this message, it means that you've installed <color=orange>Fight For Universe: Bleeding Edge</color> " +
					"mod for <color=#4fd376>Shortest Trip to Earth</color>, because original amount of <color=#cc0000>death and desperation</color> was not enough and you decided to go full IDDQD." + "\n\n" +
					"Bleeding Edge Main Features:" + "\n" +
					" - Completely New In-Game Mechanics" + "\n" +
					" - Modules, Crew & Firearms Rebalance" + "\n" +
					" - Module Reversing, Research & Tiers" + "\n" +
					" - Local Forces Awareness & Response" + "\n" +
					" - Reworked Boarding & Module Looting" + "\n" +
					" - Tactical Pacing & Many Other Changes" + "\n" +
					"\n" + "Special thanks goes to <color=#4fd376>Interactive Fate</color> for creating this art piece and helping me with modding it, thus allowing me to make this unforgiving mod for it.";
				if (txt.text.ToLower().Contains("we offer you an opportunity to unlock"))
					txt.text = "<size=14>\nCongratulations! You found a secret cow level. Nah, I'm kidding, there is no cow level. If you found this page, it means you probably already know about mod's configuration file existence." + "\n\n" +
					"Anyway, you can <color=#3366ff>reset all data and just unlock all ships</color> or <color=#ff3333>reset all data and unlock all ships with all perks</color> depending on mod's configuration. To do it just follow (no, not a white rabbit) IDKFA and take the pill.\n</size>";
			}
		}
		public static int SortAllModules(ShipModule shipModule) {
			switch (shipModule.type) {
				case ShipModule.Type.ResourcePack:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 1000 + FFU_BE_Prefab_ResPacks.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Weapon_Nuke:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 2000 + FFU_BE_Prefab_Nukes.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Weapon:
				if (!shipModule.name.ToLower().Contains("bossweapon"))
					return 3000 + FFU_BE_Prefab_Weapons.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.PointDefence:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 4000 + FFU_BE_Prefab_PointDefences.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Bridge:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 5000 + FFU_BE_Prefab_Bridges.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Engine:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 6000 + FFU_BE_Prefab_Engines.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Warp:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 7000 + FFU_BE_Prefab_Drives.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Reactor:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 8000 + FFU_BE_Prefab_Reactors.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Container:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 9000 + FFU_BE_Prefab_Storages.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Integrity:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 10000 + FFU_BE_Prefab_Armors.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.ShieldGen:
				if (!shipModule.name.ToLower().Contains("artifact") && !shipModule.name.ToLower().Contains("decoy"))
					return 11000 + FFU_BE_Prefab_Shields.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Sensor:
				if (!shipModule.name.ToLower().Contains("tutorial"))
					return 12000 + FFU_BE_Prefab_Sensors.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.StealthDecryptor:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 13000 + FFU_BE_Prefab_Decryptors.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.PassiveECM:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 14000 + FFU_BE_Prefab_PassiveECMs.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Dronebay:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 15000 + FFU_BE_Prefab_HealthBays.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Medbay:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 16000 + FFU_BE_Prefab_HealthBays.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Cryosleep:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 17000 + FFU_BE_Prefab_CryoBays.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.ResearchLab:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 18000 + FFU_BE_Prefab_Laboratories.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Garden:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 19000 + FFU_BE_Prefab_Greenhouses.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.MaterialsConverter:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 20000 + FFU_BE_Prefab_Converters.SortModules(shipModule.name);
				else goto default;
				case ShipModule.Type.Decoy:
				if (!shipModule.name.ToLower().Contains("artifact"))
					return 21000 + FFU_BE_Prefab_Decoys.SortModules(shipModule.name);
				else goto default;
				default:
				if (shipModule.name.ToLower().Contains("decoy"))
					return 21000 + FFU_BE_Prefab_Decoys.SortModules(shipModule.name);
				if (shipModule.name.ToLower().Contains("artifact"))
					return 22000 + FFU_BE_Prefab_Miscellaneous.SortModules(shipModule.name);
				if (shipModule.name.ToLower().Contains("tutorial"))
					return 23000 + FFU_BE_Prefab_Miscellaneous.SortModules(shipModule.name);
				if (shipModule.name.ToLower().Contains("bossweapon"))
					return 24000 + FFU_BE_Prefab_Miscellaneous.SortModules(shipModule.name);
				return 25000;
			}
		}
		public static bool IsAllowedModuleCategory(ShipModule shipModule) {
			if (shipModule.displayName.Contains("Cache")) return true;
			if (shipModule.name.Contains("bossweapon")) return false;
			if (shipModule.name.Contains("tutorial")) return false;
			if (shipModule.name.Contains("artifact")) return false;
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				case ShipModule.Type.Weapon_Nuke:
				case ShipModule.Type.PointDefence:
				case ShipModule.Type.Bridge:
				case ShipModule.Type.Engine:
				case ShipModule.Type.Warp:
				case ShipModule.Type.Reactor:
				case ShipModule.Type.Container:
				case ShipModule.Type.Integrity:
				case ShipModule.Type.ShieldGen:
				case ShipModule.Type.Sensor:
				case ShipModule.Type.StealthDecryptor:
				case ShipModule.Type.PassiveECM:
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				case ShipModule.Type.Cryosleep:
				case ShipModule.Type.ResearchLab:
				case ShipModule.Type.Garden:
				case ShipModule.Type.MaterialsConverter:
				case ShipModule.Type.Decoy: return true;
				default: return false;
			}
		}
		public static bool IsAllowedModuleToList(ShipModule shipModule) {
			if (shipModule.displayName.Contains("Cache")) return true;
			if (shipModule.name.Contains("bossweapon")) return false;
			if (shipModule.name.Contains("tutorial")) return false;
			if (shipModule.name.Contains("artifact")) return false;
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				case ShipModule.Type.Weapon_Nuke:
				case ShipModule.Type.PointDefence:
				case ShipModule.Type.Bridge:
				case ShipModule.Type.Engine:
				case ShipModule.Type.Warp:
				case ShipModule.Type.Reactor:
				case ShipModule.Type.Container:
				case ShipModule.Type.Integrity:
				case ShipModule.Type.ShieldGen:
				case ShipModule.Type.Sensor:
				case ShipModule.Type.StealthDecryptor:
				case ShipModule.Type.PassiveECM:
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				case ShipModule.Type.Cryosleep:
				case ShipModule.Type.ResearchLab:
				case ShipModule.Type.Garden:
				case ShipModule.Type.MaterialsConverter:
				case ShipModule.Type.Storage:
				case ShipModule.Type.ResourcePack:
				case ShipModule.Type.Fighter:
				case ShipModule.Type.Decoy: return true;
				default: return false;
			}
		}
		public static bool IsStaticModuleType(ShipModule shipModule) {
			if (shipModule.displayName.Contains("Cache")) return true;
			return false;
		}
		public static bool IsProhibitedModule(ShipModule shipModule) {
			if (shipModule.PrefabId == 1801315413) return true;
			if (shipModule.PrefabId == 1088715096) return true;
			return false;
		}
		public static bool IsCraftedToStorage(ShipModule shipModule) {
			if (shipModule.type == ShipModule.Type.ResourcePack) return true;
			else if (shipModule.displayName.Contains("Cache")) return true;
			else return false;
		}
		public static Crewmember GetRandomIntruderFromName(ShootAtDamageDealer damageDealer) {
			float rollValue = UnityEngine.Random.Range(0f, 100f);
			Core.PayloadPool spawnPoolType = Core.PayloadPool.None;
			if (damageDealer.name.Contains("DIY bio nuke") || damageDealer.name.Contains("Mini Bio nuke") || damageDealer.name.Contains("insectoid spawner nuke")) spawnPoolType = Core.PayloadPool.Squid;
			else if (damageDealer.name.Contains("pirate spawner nuke")) spawnPoolType = Core.PayloadPool.Pirate;
			else if (damageDealer.name.Contains("Tiger intruderbot nuke")) spawnPoolType = Core.PayloadPool.Terran;
			switch (spawnPoolType) {
				case Core.PayloadPool.Squid:
				if (rollValue >= 80f) return prefabModdedCrewList.Find(x => x.name.Contains("Moleculaati"));
				else if (rollValue >= 50f) return prefabModdedCrewList.Find(x => x.name.Contains("Larva big"));
				else return prefabModdedCrewList.Find(x => x.name.Contains("Larva small"));
				case Core.PayloadPool.Pirate:
				if (rollValue >= 80f) return prefabModdedCrewList.Find(x => x.name.Contains("Drone DIY gunnery pirates cannon"));
				else if (rollValue >= 50f) return prefabModdedCrewList.Find(x => x.name.Contains("Drone DIY mincer pirates"));
				else return prefabModdedCrewList.Find(x => x.name.Contains("Drone DIY fire safety clawed"));
				case Core.PayloadPool.Terran:
				return prefabModdedCrewList.Find(x => x.name.Contains("Drone tigerspider assaulter"));
				default: return null;
			}
		}
		public static int GetModuleMaxCraftingProficiency(ShipModule shipModule) {
			return Mathf.RoundToInt(5 + ModuleAvailableSector(shipModule) + shipModule.costCreditsInShop / 2000f);
		}
		public static float GetModuleCraftingProficiency(ShipModule shipModule) {
			if (craftingProficiency.ContainsKey(shipModule.PrefabId)) return Mathf.Clamp(craftingProficiency[shipModule.PrefabId] / (float)GetModuleMaxCraftingProficiency(shipModule), 0f, 1f);
			else return 0f;
		}
		public static void AddModuleCraftingProficiency(ShipModule shipModule) {
			if (craftingProficiency.ContainsKey(shipModule.PrefabId)) craftingProficiency[shipModule.PrefabId]++;
			else craftingProficiency.Add(new KeyValuePair<int, int>(shipModule.PrefabId, 1));
		}
		public static float GetModuleEnergyEmissionMult(ShipModule shipModule) {
			switch (shipModule.type) {
				case ShipModule.Type.Weapon: return 1.8f;
				case ShipModule.Type.Weapon_Nuke: return 0.05f;
				case ShipModule.Type.PointDefence: return 1.8f;
				case ShipModule.Type.Bridge: return 1.4f;
				case ShipModule.Type.Engine: return 1.6f;
				case ShipModule.Type.Warp: return 2.4f;
				case ShipModule.Type.Reactor: return 1.8f;
				case ShipModule.Type.ShieldGen: return 1.6f;
				case ShipModule.Type.Sensor: return 1.3f;
				case ShipModule.Type.StealthDecryptor: return -24.6f;
				case ShipModule.Type.PassiveECM: return -8.2f;
				case ShipModule.Type.Dronebay: return 1.6f;
				case ShipModule.Type.Medbay: return 1.6f;
				case ShipModule.Type.Cryosleep: return 1.7f;
				case ShipModule.Type.ResearchLab: return 2.2f;
				case ShipModule.Type.Garden: return 2.6f;
				case ShipModule.Type.MaterialsConverter: return 1.1f;
				default: return 1.0f;
			}
		}
		public static float GetModuleEnergyEmission(ShipModule shipModule) {
			Core.BonusMod moduleMofidier = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			switch (shipModule.type) {
				case ShipModule.Type.Bridge:
				if (shipModule.Bridge != null && shipModule.turnedOn) return (shipModule.PowerConsumed + shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.PointDefence:
				if (shipModule.PointDefence != null && shipModule.turnedOn) return (shipModule.PowerConsumed + shipModule.PointDefence.coverRadius) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.ShieldGen:
				if (shipModule.ShieldGen != null && shipModule.turnedOn) return (shipModule.PowerConsumed + shipModule.ShieldGen.MaxShieldAdd / 5f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				if (shipModule.Medbay != null && shipModule.turnedOn) return (shipModule.PowerConsumed + (shipModule.Medbay.resourcesPerHp.organics +
						shipModule.Medbay.resourcesPerHp.fuel + shipModule.Medbay.resourcesPerHp.metals + shipModule.Medbay.resourcesPerHp.synthetics +
						shipModule.Medbay.resourcesPerHp.explosives + shipModule.Medbay.resourcesPerHp.exotics * 10f + shipModule.Medbay.resourcesPerHp.credits / 10f) *
						shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Cryosleep:
				if (shipModule.Cryosleep != null && shipModule.turnedOn)
					return (shipModule.PowerConsumed + shipModule.PowerConsumed / 2f * shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.ResearchLab:
				if (shipModule.Research != null && shipModule.turnedOn)
					return (shipModule.PowerConsumed + (shipModule.Research.producedPerSkillPoint.organics + shipModule.Research.producedPerSkillPoint.fuel +
						shipModule.Research.producedPerSkillPoint.metals + shipModule.Research.producedPerSkillPoint.synthetics +
						shipModule.Research.producedPerSkillPoint.explosives + shipModule.Research.producedPerSkillPoint.exotics * 10 +
						shipModule.Research.producedPerSkillPoint.credits) * shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Garden:
				if (shipModule.GardenModule != null && shipModule.turnedOn)
					return (shipModule.PowerConsumed + (shipModule.GardenModule.producedPerSkillPoint.organics + shipModule.GardenModule.producedPerSkillPoint.fuel +
						shipModule.GardenModule.producedPerSkillPoint.metals + shipModule.GardenModule.producedPerSkillPoint.synthetics +
						shipModule.GardenModule.producedPerSkillPoint.explosives + shipModule.GardenModule.producedPerSkillPoint.exotics * 10 +
						shipModule.GardenModule.producedPerSkillPoint.credits) * shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Sensor:
				if (shipModule.Sensor != null && shipModule.turnedOn)
					return (shipModule.PowerConsumed + shipModule.Sensor.sectorRadarRange / 10f + shipModule.Sensor.starmapRadarRange) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.MaterialsConverter:
				if (shipModule.MaterialsConverter != null && shipModule.turnedOn) return (shipModule.PowerConsumed + shipModule.MaterialsConverter.consume.organics +
						shipModule.MaterialsConverter.consume.fuel + shipModule.MaterialsConverter.consume.metals + shipModule.MaterialsConverter.consume.synthetics +
						shipModule.MaterialsConverter.consume.explosives + shipModule.MaterialsConverter.consume.exotics * 10f + shipModule.MaterialsConverter.consume.credits / 10f +
						shipModule.MaterialsConverter.produce.organics + shipModule.MaterialsConverter.produce.fuel + shipModule.MaterialsConverter.produce.metals +
						shipModule.MaterialsConverter.produce.synthetics + shipModule.MaterialsConverter.produce.explosives + shipModule.MaterialsConverter.produce.exotics * 10f +
						shipModule.MaterialsConverter.produce.credits / 10f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Reactor:
				if (shipModule.Reactor != null && shipModule.IsOvercharged && shipModule.turnedOn)
					return (shipModule.Reactor.powerCapacity + shipModule.Reactor.overchargePowerCapacityAdd) * GetModuleEnergyEmissionMult(shipModule);
				else if (shipModule.Reactor != null && shipModule.turnedOn)
					return shipModule.Reactor.powerCapacity * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.PassiveECM:
				if (shipModule.ECM != null && shipModule.turnedOn) return shipModule.PowerConsumed / (moduleMofidier == Core.BonusMod.Sustained ? 0.5f :
					moduleMofidier == Core.BonusMod.Unstable ? 2f : 1f) * GetModuleEnergyEmissionMult(shipModule) *
					FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shipModule), Core.BonusType.Default) *
					(moduleMofidier == Core.BonusMod.Enhanced ? 1.2f : moduleMofidier == Core.BonusMod.Deficient ? 0.5f : 1f);
				else return 0f;
				case ShipModule.Type.StealthDecryptor:
				if (shipModule.StealthDecryptor != null && shipModule.turnedOn) return shipModule.PowerConsumed / (moduleMofidier == Core.BonusMod.Sustained ? 0.5f :
					moduleMofidier == Core.BonusMod.Unstable ? 2f : 1f) * GetModuleEnergyEmissionMult(shipModule) *
					FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shipModule), Core.BonusType.Default) *
					(moduleMofidier == Core.BonusMod.Enhanced ? 2f : moduleMofidier == Core.BonusMod.Deficient ? 0.5f : 1f);
				else return 0f;
				case ShipModule.Type.Weapon:
				if (shipModule.Weapon != null && shipModule.turnedOn)
					return (shipModule.PowerConsumed + shipModule.Weapon.resourcesPerShot.fuel + shipModule.Weapon.resourcesPerShot.explosives * 2f +
						shipModule.Weapon.resourcesPerShot.exotics * 10f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Weapon_Nuke:
				if (shipModule.Weapon != null) return (shipModule.craftCost.fuel + shipModule.craftCost.explosives * 2f + shipModule.craftCost.exotics * 10f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Engine:
				if (shipModule.Engine != null && shipModule.turnedOn) return (shipModule.PowerConsumed + shipModule.Engine.ConsumedPerDistance.fuel * 100f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Warp:
				if (shipModule.Warp != null) return (shipModule.PowerConsumed + shipModule.Warp.activationFuel) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				default: return 0f;
			}
		}
		public static string GetModuleEnergyEmissionText(ShipModule shipModule) {
			float emissionMin = 0f;
			float emissionMax = 0f;
			bool isStaticShipModule = !shipModule.name.ToLower().Contains("(clone)");
			Core.BonusMod moduleMofidier = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			switch (shipModule.type) {
				case ShipModule.Type.Bridge:
				if (shipModule.Bridge != null && isStaticShipModule) {
					emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
					emissionMax = (shipModule.PowerConsumed + shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				} else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.PointDefence:
				if (shipModule.PointDefence != null && isStaticShipModule) emissionMin = (shipModule.PowerConsumed + shipModule.PointDefence.coverRadius) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.ShieldGen:
				if (shipModule.ShieldGen != null && isStaticShipModule) emissionMin = (shipModule.PowerConsumed + shipModule.ShieldGen.MaxShieldAdd / 5f) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				if (shipModule.Medbay != null && isStaticShipModule) {
					emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
					emissionMax = (shipModule.PowerConsumed + (shipModule.Medbay.resourcesPerHp.organics +
						 shipModule.Medbay.resourcesPerHp.fuel + shipModule.Medbay.resourcesPerHp.metals + shipModule.Medbay.resourcesPerHp.synthetics +
						 shipModule.Medbay.resourcesPerHp.explosives + shipModule.Medbay.resourcesPerHp.exotics * 10f + shipModule.Medbay.resourcesPerHp.credits / 10f) *
						 shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				} else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Cryosleep:
				if (shipModule.Cryosleep != null && isStaticShipModule) {
					emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
					emissionMax = (shipModule.PowerConsumed + shipModule.PowerConsumed / 2f * shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				} else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.ResearchLab:
				if (shipModule.Research != null && isStaticShipModule) {
					emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
					emissionMax = (shipModule.PowerConsumed + (shipModule.Research.producedPerSkillPoint.organics + shipModule.Research.producedPerSkillPoint.fuel +
						shipModule.Research.producedPerSkillPoint.metals + shipModule.Research.producedPerSkillPoint.synthetics +
						shipModule.Research.producedPerSkillPoint.explosives + shipModule.Research.producedPerSkillPoint.exotics * 10 +
						shipModule.Research.producedPerSkillPoint.credits) * shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				} else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Garden:
				if (shipModule.GardenModule != null && isStaticShipModule) {
					emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
					emissionMax = (shipModule.PowerConsumed + (shipModule.GardenModule.producedPerSkillPoint.organics + shipModule.GardenModule.producedPerSkillPoint.fuel +
						shipModule.GardenModule.producedPerSkillPoint.metals + shipModule.GardenModule.producedPerSkillPoint.synthetics +
						shipModule.GardenModule.producedPerSkillPoint.explosives + shipModule.GardenModule.producedPerSkillPoint.exotics * 10 +
						shipModule.GardenModule.producedPerSkillPoint.credits) * shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				} else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Sensor:
				if (shipModule.Sensor != null && isStaticShipModule)
					emissionMin = (shipModule.PowerConsumed + shipModule.Sensor.sectorRadarRange / 10f + shipModule.Sensor.starmapRadarRange) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.MaterialsConverter:
				if (shipModule.MaterialsConverter != null && isStaticShipModule) emissionMin = (shipModule.PowerConsumed + shipModule.MaterialsConverter.consume.organics +
						shipModule.MaterialsConverter.consume.fuel + shipModule.MaterialsConverter.consume.metals + shipModule.MaterialsConverter.consume.synthetics +
						shipModule.MaterialsConverter.consume.explosives + shipModule.MaterialsConverter.consume.exotics * 10f + shipModule.MaterialsConverter.consume.credits / 10f +
						shipModule.MaterialsConverter.produce.organics + shipModule.MaterialsConverter.produce.fuel + shipModule.MaterialsConverter.produce.metals +
						shipModule.MaterialsConverter.produce.synthetics + shipModule.MaterialsConverter.produce.explosives + shipModule.MaterialsConverter.produce.exotics * 10f +
						shipModule.MaterialsConverter.produce.credits / 10f) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Reactor:
				if (shipModule.Reactor != null && isStaticShipModule) {
					emissionMin = shipModule.Reactor.powerCapacity * GetModuleEnergyEmissionMult(shipModule);
					emissionMax = (shipModule.Reactor.powerCapacity + shipModule.Reactor.overchargePowerCapacityAdd) * GetModuleEnergyEmissionMult(shipModule);
				} else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.PassiveECM:
				if (shipModule.ECM != null && isStaticShipModule) emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule) *
					FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shipModule), Core.BonusType.Default) * (moduleMofidier == Core.BonusMod.Enhanced ? 1.2f :
					moduleMofidier == Core.BonusMod.Deficient ? (1f / 1.2f) : 1f);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.StealthDecryptor:
				if (shipModule.StealthDecryptor != null && isStaticShipModule) emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule) *
					FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shipModule), Core.BonusType.Default) * (moduleMofidier == Core.BonusMod.Enhanced ? 2f :
					moduleMofidier == Core.BonusMod.Deficient ? (1f / 2f) : 1f);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Weapon:
				if (shipModule.Weapon != null && isStaticShipModule) emissionMin = (shipModule.PowerConsumed + shipModule.Weapon.resourcesPerShot.fuel +
						shipModule.Weapon.resourcesPerShot.explosives * 2f + shipModule.Weapon.resourcesPerShot.exotics * 10f) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Weapon_Nuke:
				if (shipModule.Weapon != null && isStaticShipModule) emissionMin = (shipModule.craftCost.fuel + shipModule.craftCost.explosives * 2f + shipModule.craftCost.exotics * 10f) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Engine:
				if (shipModule.Engine != null && isStaticShipModule) emissionMin = (shipModule.PowerConsumed + shipModule.Engine.ConsumedPerDistance.fuel * 100f) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				case ShipModule.Type.Warp:
				if (shipModule.Warp != null && isStaticShipModule) emissionMin = (shipModule.PowerConsumed + shipModule.Warp.activationFuel) * GetModuleEnergyEmissionMult(shipModule);
				else { emissionMin = 0f; emissionMax = 0f; }
				break;
				default: emissionMin = 0f; emissionMax = 0f; break;
			}
			if (emissionMin != 0f && emissionMax != 0f) return string.Format("{0:0.#}", emissionMin) + "m³ ~ " + string.Format("{0:0.#}", emissionMax) + "m³";
			else if (emissionMin != 0f && emissionMax == 0f) return string.Format("{0:0.#}", emissionMin) + "m³";
			else return null;
		}
		public static void RecalculateEnergyEmission() {
			if (PlayerDatas.Me != null && PlayerDatas.Me.Flagship != null) {
				energyEmission = 0;
				foreach (ModuleSlotRoot slotRoot in PlayerDatas.Me.Flagship.ModuleSlotRoots) {
					if (slotRoot.Module != null && !slotRoot.Module.IsPacked && !slotRoot.Module.IsUnpacking)
						energyEmission += GetModuleEnergyEmission(slotRoot.Module);
					if (debugMode) Debug.LogWarning(slotRoot.Module.name + ": " + GetModuleEnergyEmission(slotRoot.Module));
				}
				energyEmission *= GetFlagshipEmissionModifier();
				if (energyEmission < 100f) energyEmission = RstRandom.Range(80f, 120f);
			}
		}
		public static float GetFlagshipEmissionModifier() {
			if (PlayerDatas.Me != null && PlayerDatas.Me.Flagship != null) return 1f + PlayerDatas.Me.Flagship.ModuleSlotRoots.Count / 100f;
			else return 1f;
		}
		public static float GetIntruderCountFromName(ShootAtDamageDealer damageDealer) {
			float intruderCountMult = 1f;
			if (damageDealer.name.Contains("DIY bio nuke")) intruderCountMult = 10f;
			else if (damageDealer.name.Contains("Mini Bio nuke")) intruderCountMult = 10f;
			else if (damageDealer.name.Contains("insectoid spawner nuke")) intruderCountMult = 10f;
			else if (damageDealer.name.Contains("pirate spawner nuke")) intruderCountMult = 5f;
			else if (damageDealer.name.Contains("Tiger intruderbot nuke")) intruderCountMult = 4f;
			return damageDealer.MaxHealth * intruderCountMult / 40f * 3f;
		}
		public static float GetIntruderCountFromName(ShipModule shipModule) {
			float intruderCountMult = 1f;
			if (shipModule.name.Contains("07 DIY bionuke launcher")) intruderCountMult = 10f;
			else if (shipModule.name.Contains("07 Weirdship Minibio nuke launcher")) intruderCountMult = 10f;
			else if (shipModule.name.Contains("99 maggot spawner launcher")) intruderCountMult = 10f;
			else if (shipModule.name.Contains("99 pirate spawner launcher 1")) intruderCountMult = 5f;
			else if (shipModule.name.Contains("Tiger intruderbot nuke launcher")) intruderCountMult = 4f;
			return shipModule.Weapon.overrideProjectileHealth * intruderCountMult / 40f;
		}
		public static bool ModuleViableForSector(ShipModule shipModule, int sectorNum) {
			ShipModule refModule = prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId);
			if (refModule != null) {
				if (shipModule.name.Contains("bossweapon")) return true;
				if (shipModule.name.Contains("tutorial")) return true;
				if (shipModule.name.Contains("artifact")) return true;
				switch (shipModule.type) {
					case ShipModule.Type.Weapon: return FFU_BE_Prefab_Weapons.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Weapon_Nuke: return FFU_BE_Prefab_Nukes.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.PointDefence: return FFU_BE_Prefab_PointDefences.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Bridge: return FFU_BE_Prefab_Bridges.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Engine: return FFU_BE_Prefab_Engines.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Warp: return FFU_BE_Prefab_Drives.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Reactor: return FFU_BE_Prefab_Reactors.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Integrity: return FFU_BE_Prefab_Armors.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.ShieldGen: return FFU_BE_Prefab_Shields.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Sensor: return FFU_BE_Prefab_Sensors.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.StealthDecryptor: return FFU_BE_Prefab_Decryptors.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.PassiveECM: return FFU_BE_Prefab_PassiveECMs.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Dronebay: return FFU_BE_Prefab_HealthBays.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Medbay: return FFU_BE_Prefab_HealthBays.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Cryosleep: return FFU_BE_Prefab_CryoBays.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.ResearchLab: return FFU_BE_Prefab_Laboratories.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.Garden: return FFU_BE_Prefab_Greenhouses.ViableForSector(sectorNum).Contains(refModule.name);
					case ShipModule.Type.MaterialsConverter: return FFU_BE_Prefab_Converters.ViableForSector(sectorNum).Contains(refModule.name);
					default: return true;
				}
			} else return false;
		}
		public static int ModuleAvailableSector(ShipModule shipModule) {
			if (ModuleViableForSector(shipModule, 1)) return 1;
			else if (ModuleViableForSector(shipModule, 2)) return 2;
			else if (ModuleViableForSector(shipModule, 3)) return 3;
			else if (ModuleViableForSector(shipModule, 4)) return 4;
			else if (ModuleViableForSector(shipModule, 5)) return 5;
			else if (ModuleViableForSector(shipModule, 6)) return 6;
			else if (ModuleViableForSector(shipModule, 7)) return 7;
			else if (ModuleViableForSector(shipModule, 8)) return 8;
			else if (ModuleViableForSector(shipModule, 9)) return 9;
			else if (ModuleViableForSector(shipModule, 10)) return 10;
			else return 0;
		}
		public static ShipModule GetReplacementModule(ShipModule shipModule, int sectorNum) {
			ShipModule refModule = prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId);
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					string lookupType = "";
					string lookupSubType = "";
					if (refModule.displayName.Contains("Launcher")) lookupType = "Launcher";
					else if (refModule.displayName.Contains("Autocannon")) lookupType = "Autocannon";
					else if (refModule.displayName.Contains("Howitzer")) lookupType = "Howitzer";
					else if (refModule.displayName.Contains("Railgun")) lookupType = "Railgun";
					else if (refModule.displayName.Contains("Railcannon")) lookupType = "Railcannon";
					else if (refModule.displayName.Contains("Laser")) lookupType = "Laser";
					else if (refModule.displayName.Contains("Beam")) lookupType = "Beam";
					else if (refModule.displayName.Contains("Heat Ray")) lookupType = "Heat Ray";
					else if (refModule.displayName.Contains("Disruptor")) lookupType = "Disruptor";
					else if (refModule.displayName.Contains("Exotic Ray")) lookupType = "Exotic Ray";
					if (refModule.displayName.Contains("Explosive")) lookupSubType = "Explosive";
					else if (refModule.displayName.Contains("Kinetic")) lookupSubType = "Kinetic";
					else if (refModule.displayName.Contains("Plasma")) lookupSubType = "Plasma";
					else if (refModule.displayName.Contains("Chemical")) lookupSubType = "Chemical";
					else if (refModule.displayName.Contains("Incendiary")) lookupSubType = "Incendiary";
					else if (refModule.displayName.Contains("Exotic")) lookupSubType = "Exotic";
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(lookupType) && x.displayName.Contains(lookupSubType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(lookupType)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(sectorNum).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else {
								refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(0).Contains(x.name)).ToList();
								if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
								else return null;
							}
						}
					}
				} else return null;
				case ShipModule.Type.Weapon_Nuke:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					string lookupType = "";
					if (refModule.displayName.Contains("Kinetic")) lookupType = "Kinetic";
					else if (refModule.displayName.Contains("Energy")) lookupType = "Energy";
					else if (refModule.displayName.Contains("Thermal")) lookupType = "Thermal";
					else if (refModule.displayName.Contains("Tactical")) lookupType = "Tactical";
					else if (refModule.displayName.Contains("Chemical")) lookupType = "Chemical";
					else if (refModule.displayName.Contains("Boarding")) lookupType = "Boarding";
					else if (refModule.displayName.Contains("Strategic")) lookupType = "Strategic";
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Nukes.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(lookupType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Nukes.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Nukes.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.PointDefence:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PointDefences.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PointDefences.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Bridge:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Bridges.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Bridges.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Engine:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Engines.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Engines.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Warp:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Drives.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Drives.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Reactor:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Reactors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Reactors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Integrity:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Armors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Armors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.ShieldGen:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					string lookupType = "";
					if (refModule.displayName.Contains("Capacitor")) lookupType = "Capacitor";
					else if (refModule.displayName.Contains("Generator")) lookupType = "Generator";
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Shields.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(lookupType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Shields.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Shields.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.Sensor:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Sensors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Sensors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.StealthDecryptor:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Decryptors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Decryptors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.PassiveECM:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PassiveECMs.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PassiveECMs.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					string lookupType = "";
					if (refModule.displayName.Contains("Drone")) lookupType = "Drone";
					else if (refModule.displayName.Contains("Medical")) lookupType = "Medical";
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_HealthBays.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(lookupType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_HealthBays.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_HealthBays.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.Cryosleep:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					string lookupType = "";
					if (refModule.displayName.Contains("Cryodream")) lookupType = "Cryodream";
					else if (refModule.displayName.Contains("Cryosleep")) lookupType = "Cryosleep";
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_CryoBays.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(lookupType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_CryoBays.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_CryoBays.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.ResearchLab:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Laboratories.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Laboratories.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Garden:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Greenhouses.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Greenhouses.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.MaterialsConverter:
				if (refModule != null && prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Converters.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Converters.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				default: return null;
			}
		}
		public static ShipModule GetRandomModuleType(ShipModule.Type moduleType, int sectorNum, string mType = "", string mSubType = "") {
			switch (moduleType) {
				case ShipModule.Type.Weapon:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(mType) && x.displayName.Contains(mSubType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(mType)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(sectorNum).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else {
								refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Weapons.ViableForSector(0).Contains(x.name)).ToList();
								if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
								else return null;
							}
						}
					}
				} else return null;
				case ShipModule.Type.Weapon_Nuke:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Nukes.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(mType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Nukes.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Nukes.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.PointDefence:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PointDefences.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PointDefences.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Bridge:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Bridges.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Bridges.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Engine:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Engines.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Engines.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Warp:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Drives.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Drives.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Reactor:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Reactors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Reactors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Integrity:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Armors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Armors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.ShieldGen:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Shields.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(mType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Shields.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Shields.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.Sensor:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Sensors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Sensors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.StealthDecryptor:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Decryptors.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Decryptors.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.PassiveECM:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PassiveECMs.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_PassiveECMs.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_HealthBays.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(mType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_HealthBays.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_HealthBays.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.Cryosleep:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_CryoBays.ViableForSector(sectorNum).Contains(x.name) && x.displayName.Contains(mType)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_CryoBays.ViableForSector(sectorNum).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else {
							refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_CryoBays.ViableForSector(0).Contains(x.name)).ToList();
							if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
							else return null;
						}
					}
				} else return null;
				case ShipModule.Type.ResearchLab:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Laboratories.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Laboratories.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.Garden:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Greenhouses.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Greenhouses.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				case ShipModule.Type.MaterialsConverter:
				if (prefabModdedModulesList.Count > 0) {
					var refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Converters.ViableForSector(sectorNum).Contains(x.name)).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else {
						refList = prefabModdedModulesList.Where(x => FFU_BE_Prefab_Converters.ViableForSector(0).Contains(x.name)).ToList();
						if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
						else return null;
					}
				} else return null;
				default:
				if (prefabModdedModulesList.Count > 0) {
					List<ShipModule> refList = new List<ShipModule>();
					if (RstRandom.Range(0f, 1f) < 0.75f) refList = prefabModdedModulesList.Where(x => x.displayName.Contains("Cache")).ToList();
					else refList = prefabModdedModulesList.Where(x => x.name.Contains("artifactmodule") && !x.displayName.Contains("Cache")).ToList();
					if (refList.Count > 0) return Core.RandomItemFromList(refList, null);
					else return null;
				} else return null;
			}
		}
	}
}