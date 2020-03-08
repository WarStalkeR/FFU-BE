#pragma warning disable CS0436

using RST;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Text;
using RST.UI;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Defs {
		public static string modVersion = "0.9.7.2";
		//Internal Variables
		public static bool firstRun = true;
		public static bool firstInst = true;
		public static bool goFullASMD = false;
		public static bool debugMode = false;
		public static bool visualDebug = false;
		public static bool canSpawnCrew = false;
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
		public static int blackMarketMult = 111;
		public static int pointsPerBarItem = 30;
		public static float timePassedCycle = 4f;
		public static float shieldBonusMult = 4f;
		public static float researchProgress = 0f;
		public static float equipmentChangeDist = 2f;
		public static float moduleRepairTime = 2f;
		public static float shipHullRepairTime = 5f;
		public static float moduleDamageThreshold = 0.25f;
		public static float moduleRepairAcceleration = 25f;
		public static float shipHullRepairAcceleration = 15f;
		public static float permanentModuleDamageChance = 0.20f;
		public static float permanentModuleDamagePercent = 0.15f;
		public static List<int> updatedShips = new List<int>();
		public static List<int> updatedCrews = new List<int>();
		public static List<int> updatedSalvage = new List<int>();
		public static List<Perk> prefabPerkList = new List<Perk>();
		public static List<Ship> prefabShipsList = new List<Ship>();
		public static List<Beam> prefabBeamRaysList = new List<Beam>();
		public static List<AddCrewToShip> prefabCrewSets = new List<AddCrewToShip>();
		public static List<Projectile> prefabProjectilesList = new List<Projectile>();
		public static List<AddResourcesToShip> prefabResourceSets = new List<AddResourcesToShip>();
		public static List<PointDefDamageDealer> prefabDefDealersList = new List<PointDefDamageDealer>();
		public static List<ShootAtDamageDealer> prefabDamageDealersList = new List<ShootAtDamageDealer>();
		public static List<Crewmember> prefabModdedCrewList = new List<Crewmember>();
		public static List<ModuleSlot> prefabModdedSlotsList = new List<ModuleSlot>();
		public static List<ShipModule> prefabModdedModulesList = new List<ShipModule>();
		public static List<SpacePod> prefabModdedSpacePodsList = new List<SpacePod>();
		public static List<HandWeapon> prefabModdedFirearmsList = new List<HandWeapon>();
		public static List<DamageToken> prefabDamageTokensList = new List<DamageToken>();
		public static IDictionary<int, int> equippedCrewFirearms = new Dictionary<int, int>();
		public static IDictionary<int, int> craftingProficiency = new Dictionary<int, int>();
		public static IDictionary<int, int> shipPrefabsDoorHealth = new Dictionary<int, int>();
		public static IDictionary<int, int> shipPrefabsStorageSize = new Dictionary<int, int>();
		public static IDictionary<int, string> shipPrefabsDoorName = new Dictionary<int, string>();
		public static IDictionary<int, float> moduleEmissionPrefabs = new Dictionary<int, float>();
		public static IDictionary<string, List<int>> weaponTypeIDs = new Dictionary<string, List<int>>() {
			{"Launchers", new List<int>()},
			{"Autocannons", new List<int>()},
			{"Howitzers", new List<int>()},
			{"Railguns", new List<int>()},
			{"Railcannons", new List<int>()},
			{"Lasers", new List<int>()},
			{"Beams", new List<int>()},
			{"Heat Rays", new List<int>()},
			{"Disruptors", new List<int>()},
			{"Exotic Rays", new List<int>()}};
		public static IDictionary<string, List<int>> cacheTypeIDs = new Dictionary<string, List<int>>() {
			{"Weapons", new List<int>()},
			{"Implants", new List<int>()},
			{"Upgrades", new List<int>()}};
		public static IDictionary<int, List<int>> sectorViableModuleIDs = new Dictionary<int, List<int>>() {
			{0, new List<int>()},
			{1, new List<int>()},
			{2, new List<int>()},
			{3, new List<int>()},
			{4, new List<int>()},
			{5, new List<int>()},
			{6, new List<int>()},
			{7, new List<int>()},
			{8, new List<int>()},
			{9, new List<int>()},
			{10, new List<int>()}};
		public static int[] techLevel = new int[] { 0, 1500, 3500, 6000, 10000, 16000, 24000, 34000, 46000, 60000 };
		public static List<int> initialModuleIDs = new List<int>(new int[] {
			760167696,  /* Organics Pack */
			453797399,  /* Starfuel Pack */
			1581569285, /* Metals Pack */
			345284781,  /* Synthetics Pack */
			813048445,  /* Explosives Pack */
			124199597,  /* Exotics Pack */
			1012765355, /* Iron Harvest Kinetic Nuke */
			92356131,   /* Powerpack Energy Nuke */
			2146165248, /* Firepack Thermal Nuke */
			533676501,  /* Explopack Tactical Nuke */
			1771248833, /* Synthpack Chemical Nuke */
			858424257,  /* Exopack Strategic Nuke */
			821254137,  /* Rust Jigsaw Rocket Launcher */
			1780996798, /* Dead Weight Explosive Autocannon */
			1521997681, /* F1-Bushwacker Explosive Howitzer */
			1751631045, /* Dead Eye Kinetic Railgun */
			842299308,  /* Ancient 1-Core Laser Emitter */
			55650103,   /* Scrap Cutter Beam Emitter */
			144623758,  /* Impulse Wave Beam Emitter */
			981179656,  /* Thermal Wave Heat Ray Projector */
			1386212334, /* Charged Wave Energy Disruptor */
			2075523594, /* Chromatic Flare Exotic Ray Projector */
			893617597,  /* Makeshift Standard CIWS */
			983196801,  /* Makeshift Command Bridge */
			1284816050, /* Makeshift Chemical Engine */
			2136288774, /* Makeshift Warp Drive */
			482395317,  /* Light Scrap Reactor */
			1700526886, /* Medium Scrap Reactor */
			482395319,  /* Heavy Scrap Reactor */
			825891570,  /* Makeshift XE Multicontainer */
			1404265275, /* Makeshift FO Multicontainer */
			1158881065, /* Makeshift FE Multicontainer */
			1449641283, /* Makeshift Organics Container */
			1477762477, /* Makeshift Starfuel Container */
			340918825,  /* Makeshift Metals Container */
			165493307,  /* Makeshift Synthetics Container */
			271236703,  /* Makeshift Explosives Container */
			168523420,  /* Makeshift Exotics Container */
			429768775,  /* Makeshift Integrity Armor */
			126798266,  /* Makeshift Shield Generator */
			741193982,  /* Makeshift Shield Capacitor */
			930742757,  /* Makeshift Sensor Array */
			1769741276, /* Makeshift Stealth Generator */
			236853983,  /* Makeshift ECM Array */
			241738085,  /* Makeshift Drone Bay */
			1219429018, /* Makeshift Medical Bay */
			1290558229, /* Makeshift Cryodream Bay */
			1398713621, /* Makeshift Cryosleep Bay */
			665713195,  /* Makeshift Laboratory */
			1902866107, /* Makeshift Greenery */ });
		public static List<int> essentialTopModuleIDs = new List<int>(new int[] {
			1196638242, /* Nanometric Integrity Armor */
			1148319565, /* Dreadnought Command Bridge */
			41460892,   /* Exploration Cryodream Bay */
			1276182160, /* Phased Stealth Generator */
			171954197,  /* Multi-Phased Sensor Array */
			738383846,  /* Quantum ECM Array */
			1304112764, /* Genesis Restoration Bay */
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
			1571322820, /* Annihilator Rocket Launcher */
			876704941,  /* Shockwave Plasma Howitzer */
			412909021,  /* Liberator Kinetic Railcannon */ });
		public static List<int> discoveredModuleIDs = initialModuleIDs;
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
		public static int shipCurrentStorageCap = 0;
		public static float scanFrequency = 1600f;
		public static float energyEmission = 300f;
		public static float distanceTraveledInPeace = 0f;
		public static float[] scanResolution = new float[] { 5000f, 3000f, 1500f, 1000f, 500f };
		public static int[] killedFleetsTrigger = new int[] { 3, 6, 10, 15, 21, 27, 34, 42, 50 };
		public static int[] timesInterceptedByEnforcers = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		public static float empowerLocalForcesChance = 0.45f;
		public static float researchRareDivisor = 20f;
		public static float researchCommonDivisor = 1000f;
		public static float reverseResearchDivisor = 3f;
		public static ResourceValueGroup doorRepairCost = new ResourceValueGroup { metals = 2f, synthetics = 4f };
		public static ResourceValueGroup initialResources = new ResourceValueGroup { };
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
		public static int stationCapacityMult = 80;
		public static int resultNumbersMult = 10;
		public static int maxStorageCapacity = 120;
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
		public static string[][] crewTypesOnStart = new string[11][] {
			new string[10] {"","","","","","","","","",""},
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
		public static string[][] crewNumsOnStart = new string[11][] {
			new string[10] {"","","","","","","","","",""},
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
				if (shipCurrentStorageCap > 0) ES2.Save(shipCurrentStorageCap, "start.es2?tag=shipCurrentStorageCap");
				RecalculateEnergyEmission();
			}
			if (firstRun) {
				Debug.LogWarning("Loading modded data and custom variables for the first time...");
				InitGameTextUpdate();
				InitGameInterfaceUpdate();
				InitDamageTokensPrefabList();
				InitDamageDealersPrefabList();
				FFU_BE_Mod_Crewmembers.InitFirearmsList();
				FFU_BE_Mod_Crewmembers.InitCrewTypesList();
				FFU_BE_Mod_Crewmembers.InitSpacePodsList();
				FFU_BE_Mod_Modules.InitShipSlotsList();
				FFU_BE_Mod_Modules.InitShipModulesList();
				FFU_BE_Mod_Spaceships.InitSelectablePerks();
				FFU_BE_Mod_Spaceships.InitShipResourcePrefabs();
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
				if (ES2.Exists("start.es2?tag=shipCurrentStorageCap")) shipCurrentStorageCap = ES2.Load<int>("start.es2?tag=shipCurrentStorageCap");
				if (ES2.Exists("permanent.es2?tag=discoveredModuleIDs")) discoveredModuleIDs = ES2.LoadList<int>("permanent.es2?tag=discoveredModuleIDs");
				else ES2.Save(discoveredModuleIDs, "permanent.es2?tag=discoveredModuleIDs");
				foreach (int initialID in initialModuleIDs) if (!discoveredModuleIDs.Contains(initialID)) discoveredModuleIDs.Add(initialID);
				if (goFullASMD) {
					if (restartUnlocksEverything) ES2.Save(FFU_BE_Base.allPerksList, "permanent.es2?tag=unlockedItemIds");
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
		public static void InitGameInterfaceUpdate() {
			foreach (HoverableUI hoverableUI in Resources.FindObjectsOfTypeAll<HoverableUI>()) {
				if (dumpObjectLists) Debug.LogWarning("[HoverableUI] " + hoverableUI.name + ": " + hoverableUI.hoverText);
			}
			foreach (GridLayoutGroup gridLayoutGroup in Resources.FindObjectsOfTypeAll<GridLayoutGroup>()) {
				if (gridLayoutGroup.name == "Grid" && gridLayoutGroup.constraintCount == 6) gridLayoutGroup.constraintCount = 12;
				if (dumpObjectLists) Debug.LogWarning("[GridLayoutGroup] " + gridLayoutGroup.name + ": " + 
				gridLayoutGroup.constraintCount + ", " + gridLayoutGroup.constraint + ", " +
				gridLayoutGroup.cellSize.x + ", " + gridLayoutGroup.cellSize.y);
			}
		}
		public static void InitDamageTokensPrefabList() {
			foreach (DamageToken damageToken in Resources.FindObjectsOfTypeAll<DamageToken>()) {
				if (damageToken.repairCostPerPoint.metals > 10) damageToken.repairCostPerPoint.metals = 10;
				prefabDamageTokensList.Add(damageToken);
			}
		}
		public static void InitDamageDealersPrefabList() {
			foreach (ShootAtDamageDealer damageDealer in Resources.FindObjectsOfTypeAll<ShootAtDamageDealer>()) {
				if (damageDealer as Projectile != null) prefabProjectilesList.Add(damageDealer as Projectile);
				else if (damageDealer as Beam != null) prefabBeamRaysList.Add(damageDealer as Beam);
				prefabDamageDealersList.Add(damageDealer);
			}
			foreach (PointDefDamageDealer pointDefDamageDealer in Resources.FindObjectsOfTypeAll<PointDefDamageDealer>()) {
				prefabDefDealersList.Add(pointDefDamageDealer);
			}
			if (dumpObjectLists) {
				foreach (ShootAtDamageDealer damageDealer in prefabDamageDealersList) Debug.Log("Damage Dealer: " + damageDealer.name);
				foreach (PointDefDamageDealer defender in prefabDefDealersList) Debug.Log("Defender: " + defender.name);
				foreach (Projectile projectile in prefabProjectilesList) Debug.Log("Projectile: " + projectile.name);
				foreach (Beam beam in prefabBeamRaysList) Debug.Log("Beam: " + beam.name);
			}
		}
		public static void InitShipDoorsUpdate() {
			foreach (Door door in Resources.FindObjectsOfTypeAll<Door>()) {
				AccessTools.FieldRefAccess<Door, int>(door, "maxHealth") = 150;
				AccessTools.FieldRefAccess<Door, int>(door, "health") = 150;
			}
		}
		public static void InitGameTextUpdate() {
			string colorLaserEmt = "ffff60";
			string colorBeamEmt = "ff9060";
			string colorHeatRay = "ff6060";
			string colorEnergyRay = "0090ff";
			string colorExoticRay = "9060ff";
			string colorNukeKin = "add8e6";
			string colorNukeEnr = "0080ff";
			string colorNukeThr = "ff8040";
			string colorNukeTac = "ffff00";
			string colorNukeChm = "008000";
			string colorNukeBrd = "8060ff";
			string colorNukeStr = "ff0000";
			foreach (Text txt in Resources.FindObjectsOfTypeAll<Text>()) {
				if (txt.name.Contains("WeaponIgnoresShieldValue")) txt.text = "Shield Bypass";
				if (txt.name.Contains("WeaponNeverDeflectsValue")) txt.text = "Deflect Ignore";
				if (txt.name.Contains("WeaponTracksTargetValue")) txt.text = "<color=lime>Tracks Target</color>";
				if (txt.name.Contains("BridgeRemoteOpsValue")) txt.text = "<color=lime>Remote Control</color>";
				if (txt.name.Contains("RemovesCrewResConsValue")) txt.text = "<color=lime>No Consumption</color>";
				if (txt.name.Contains("CryosleepGeneratesCreditsValue")) txt.text = "<color=lime>Generates Credits</color>";
				if (txt.name == "Text" && txt.text == "Quick start") txt.text = "Basic Controls";
				if (txt.name == "quick start" && txt.text == "Quick Start") txt.text = "Basic Controls";
				if (txt.name == "quick start 2" && txt.text == "Quick Start 2") txt.text = "Basic Information";
				if (txt.name == "assignments" && txt.text == "Crew roles") txt.text = "Crew Roles (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Crew roles panel") txt.text = "Crew Roles Panel (FFU:BE)";
				if (txt.name == "DescriptionText" && txt.text.Contains("Crew roles panel allows you to give orders to crew very quickly"))
					txt.text = "Crew roles panel allows you to give orders to crew very quickly" + "\n\n" +
					"Clicking on the \" + \" sign next to a specific role (such as \"repairs\" or \"weapons\") sends the unoccupied crew with best skill to take care of it (to repair damage or operate weapons)." + "\n\n" +
					"Only unoccupied crew can be assigned. You will have to unassign crew first to make them available to new roles." + "\n\n" +
					"Drones & pets can be assigned to limited activities only. If a drone and living entity have the same skill level, a drone will be assigned first." + "\n\n" +
					"<color=lime>" + "Drones and living entities spawned by <color=orange>Boarding Nukes</color> are temporary and will disappear once they try to leave the ship." + "</color>";
				if (txt.name == "all controls" && txt.text == "All keyboard shortcuts") txt.text = "Keyboard Shortcuts";
				if (txt.name == "Text" && txt.text == "All keyboard shortcuts") txt.text = "Keyboard Shortcuts";
				if (txt.name == "accelerated time" && txt.text == "Accelerated time") txt.text = "Accelerated Time (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Accelerated time") txt.text = "Accelerated Time (FFU:BE)";
				if (txt.name == "DescriptionText" && txt.text.Contains("The speed of crew walking, repairing, healing or do"))
					txt.text = "The speed of crew walking, repairing, healing or doing other things will accelerate when there are no threats." + "\n\n" +
					"In case of hostiles, fires or leaks, time will revert back to normal speed automatically." + "\n\n" +
					"<color=lime>" + "It should be noted that accelerated time (or lack of it) will not affect productivity of Laboratories, Greenhouses and Resource Converters." + "</color>";
				if (txt.name == "warp" && txt.text == "Sector view basics (warp)") txt.text = "Sector Navigation Basics";
				if (txt.name == "Text" && txt.text == "Sector view basics") txt.text = "Sector Navigation Basics";
				if (txt.name == "warp 2" && txt.text == "Sector view detials (warp)") txt.text = "Sector Navigation Details";
				if (txt.name == "Text" && txt.text == "Sector view details") txt.text = "Sector Navigation Details";
				if (txt.name == "permanent damage" && txt.text == "Permanent damage") txt.text = "Permanent Damage";
				if (txt.name == "Text" && txt.text == "Permanent damage") txt.text = "Permanent Damage";
				if (txt.name == "stealthdetection" && txt.text == "Stealth detection") txt.text = "Stealth Detection";
				if (txt.name == "Text" && txt.text == "Stealth detection") txt.text = "Stealth Detection";
				if (txt.name == "asteroids" && txt.text == "Asteroids") txt.text = "Asteroid Fields";
				if (txt.name == "Text" && txt.text == "Asteroids") txt.text = "Asteroid Fields";
				if (txt.name == "DescriptionText" && txt.text.Contains("Concentrated asteroid clusters have increased risk") && !txt.text.Contains("While moving, your ship could get"))
					txt.text = "Concentrated asteroid clusters have increased risk of impacts. Asteroid clusters with perceived " +
					"value have a special asteroid icon and can be mined. Weapons, point-defences and integrity modules improve " +
					"asteroid defence only if turned on.";
				if (txt.name == "modules" && txt.text == "Weapons & Other Modules") txt.text = "Module Slots/Interfaces";
				if (txt.name == "Text" && txt.text == "Weapons & other modules") txt.text = "Module Slots/Interfaces";
				if (txt.name == "upgrades" && txt.text == "Slot upgrades") txt.text = "Module Slot Upgrades";
				if (txt.name == "Text" && txt.text == "Module slot upgrades") txt.text = "Module Slot Upgrades";
				if (txt.name == "crafting" && txt.text == "Crafting modules") txt.text = "Module Crafting (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Crafting modules") txt.text = "Module Crafting (FFU:BE)";
				if (txt.name == "GeneralText" && txt.text.Contains("DIY modules can be crafted inside empty weapon slots"))
					txt.text = "<color=lime>" + "As long as you have reverse engineered module and have required " +
					"resources you can craft any module you want into any free compatible slot/interface on your ship. " +
					"<color=orange>Reverse engineering</color> process will start once module is scrapped. It will progress as long " +
					"as you have up and running <color=orange>Research Laboratory</color>. Scrapping other modules will also boost " +
					"reverse engineering process slightly. Depending on your <color=orange>research progress</color> and " +
					"<color=orange>module crafting proficiency</color>, crafted module might have different tiers and modifiers." + "</color>";
				if (txt.name == "CraftreacText" && txt.text.Contains("You can use crafting to save yourself after losing an important"))
					txt.text = "<color=lime>" + "Possible Module Tiers (MK): I, II, III, IV, V, VI, VII, VIII, IX, X." +
					"\n" + "<color=orange>Sustained</color>/<color=red>Unstable</color> Mod: affects power consumption." +
					"\n" + "<color=orange>Reinforced</color>/<color=red>Fragile</color> Mod: affects module's durability." +
					"\n" + "<color=orange>Efficient</color>/<color=red>Inefficient</color> Mod: affects resources consumption." +
					"\n" + "<color=orange>Precise</color>/<color=red>Inhibited</color> Mod: affects weapon's accuracy." +
					"\n" + "<color=orange>Rapid</color>/<color=red>Disrupted</color> Mod: affects weapon's rate of fire." +
					"\n" + "<color=orange>Enhanced</color>/<color=red>Deficient</color> Mod: affects core functionality." +
					"\n" + "<color=orange>Durable</color>/<color=red>Brittle</color> Mod: affects armor or container capacity." +
					"\n" + "<color=orange>Persistent</color>/<color=red>Volatile</color> Mod: affects shielding properties." + "</color>";
				if (txt.name == "CraftpackText" && txt.text.Contains("For a small extra cost, you can craft resource packages"))
					txt.text = "<color=lime>" + "In addition, excess resources can be packed into <color=orange>Resources Packs</color> that will be automatically sent to your storage." + "</color>";
				if (txt.name == "turning off modules" && txt.text == "Turning off modules") txt.text = "Energy Emission (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Turning off modules") txt.text = "Energy Emission (FFU:BE)";
				if (txt.name == "DescriptionText" && txt.text.Contains("Modules can be turned off from the power switch"))
					txt.text = "<color=lime>" + "Every once in a while, during your peaceful (and potentially productive) flight local forces will try to scan for your ship's location. " +
					"Will local forces manage to triangulate your location and send <color=orange>Interdiction Fleet</color> mainly depends on <color=orange>Energy Emission</color> levels of your flagship. " +
					"Current Energy Emission value can checked by hovering your mouse over <color=orange>Research Icon</color> at the <color=orange>Economy</color> Panel." + "\n\n" +
					"Every active/powered module at your ship (except <color=orange>ECM Arrays</color> and <color=orange>Stealth Generators</color>) will only increase your Energy Emission levels. " +
					"Bigger ships will produce greater Energy Emission for same amount of active/powered modules. Only <color=orange>ECM Arrays</color> and <color=orange>Stealth Generators</color> can reduce " +
					"Energy Emission levels of your flagship. Flagship always will generate at least <color=orange>100m³</color> Energy Emission. In addition, modules that were powered down manually will not emit any energy." + "\n\n" +
					"Local forces have 5 scan precision levels. Every time local forces will fail to triangulate your location, scan <color=orange>precision</color> will increase, until it will reach <color=orange>maximum</color> level. " +
					"These scan precision levels are 5000nm, 3000nm, 1500nm, 1000nm and 500nm. Triangulation <color=orange>success chance</color> equals to your current <color=orange>energy emission</color> levels " +
					"divided by the <color=orange>scan precision</color>." + "</color>";
				if (txt.name == "module damage" && txt.text == "Module Damage") txt.text = "Module Damage & Repair";
				if (txt.name == "Text" && txt.text == "Module damage") txt.text = "Module Damage & Repair";
				if (txt.name == "DescriptionText" && txt.text.Contains("Damaged modules are covered with red highlight"))
					txt.text = "Damaged modules are covered with red highlight and cannot be used until they are repaired." + "\n\n" +
					"Repair modules by selecting a crewmember and then R-clicking on a damaged module." + "\n\n" +
					"Damaged modules can be repaired for <color=lime>2 synthetics</color> per module hitpoint." + "\n\n" +
					"Crewmembers have varying repair skills, affecting the time needed for repair.";
				if (txt.name == "permanent module damage" && txt.text == "Permanent module damage") txt.text = "Critical Hit Effects (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Permanent module damage") txt.text = "Critical Hit Effects (FFU:BE)";
				if (txt.name == "GeneralText" && txt.text.Contains("There is a chance that if module gets damaged"))
					txt.text = "There is a chance for module to get critically damaged on hit. If module gets critically damaged, its " +
					"maximum durability will be permanently reduced. Permanent reduction percentage depends on chosen difficulty.";
				if (txt.name == "XtText" && txt.text.Contains("You can see how many times module max hitpoints have been"))
					txt.text = "You can see how many times module received critical damage by the number of X-es on it." + "\n\n" +
					"<color=lime>" + "Module Critical Damage Chance on Hit:" + "\n" +
					"<color=orange>Beginner</color> Difficulty: 0%" + "\n" +
					"<color=orange>Challenging</color> Difficulty: 20%" + "\n" +
					"<color=orange>Hardcore</color> Difficulty: 40%" + "\n\n" +
					"Durability Reduction per Critical Damage:" + "\n" +
					"<color=orange>Beginner</color> Difficulty: 0%" + "\n" +
					"<color=orange>Challenging</color> Difficulty: 15%" + "\n" +
					"<color=orange>Hardcore</color> Difficulty: 30%" + "</color>";
				if (txt.name == "weapontypes" && txt.text == "Weapon types") txt.text = "Weapon Types (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Ship Combat & Weapon Types") txt.text = "Weapon Types & Classes (FFU:BE)";
				if (txt.name == "Headline" && txt.text == "Energy weapons") txt.text = "Energy Emission Weapons";
				if (txt.name == "Text" && txt.text.Contains("Best accuracy of all weapon types"))
					txt.text = "- <color=#" + colorLaserEmt + "ff>Lasers</color>: low power and fast reload." + "\n" +
					"- <color=#" + colorBeamEmt + "ff>Beams</color>: moderate power and medium reload." + "\n" +
					"- <color=#" + colorHeatRay + "ff>Heat Rays</color>: good for setting things on fire." + "\n" +
					"- <color=#" + colorEnergyRay + "ff>Disruptors</color>: low damage, but great EMP effect." + "\n" +
					"- <color=#" + colorExoticRay + "ff>Exotic Rays</color>: most ultimate & expensive damage." + "\n" +
					"- Lack AoE and proper anti-personnel damage.";
				if (txt.name == "Headline" && txt.text == "Missiles") txt.text = "Rocket Launcher Weapons";
				if (txt.name == "Text" && txt.text.Contains("Fragile projectiles, vulnerable to point-defences"))
					txt.text = "- Ignore shields and negate deflection." + "\n" +
					"- Varied accuracy, long reload and great AoE." + "\n" +
					"- Slow projectile speed and vulnerable to CIWS." + "\n" +
					"- Requires a lot of resources to print rockets." + "\n" +
					"- Varied (fragile to armored) rocket durability." + "\n" +
					"- Expensive to maintain, but universal in use.";
				if (txt.name == "Headline" && txt.text == "Cannons") txt.text = "High-Caliber Kinetic Weapons";
				if (txt.name == "Text" && txt.text.Contains("Usually have more hitpoints than other modules"))
					txt.text = "- Ignore shields, but can be deflected." + "\n" +
					"- Greater durability than other weapons." + "\n" +
					"- Moderate reload, salvo, damage, AoE & speed." + "\n" +
					"- Various payloads grant tactical advantage." + "\n" +
					"- Require multiple resources to operate." + "\n" +
					"- Low energy consumption & vulnerable to CIWS.";
				if (txt.name == "Headline" && txt.text == "Gatling guns") txt.text = "Low-Caliber Kinetic Weapons";
				if (txt.name == "Text" && txt.text.Contains("Lowest accuracy of all weapons"))
					txt.text = "- Ignore shields, but can be deflected." + "\n" +
					"- Good reload, speed and large salvos." + "\n" +
					"- Lacking per projectile damage and AoE." + "\n" +
					"- Various payloads grant tactical advantage." + "\n" +
					"- Low energy and resource consumption." + "\n" +
					"- Very low accuracy & vulnerable to CIWS.";
				if (txt.name == "Headline" && txt.text == "Projectile weapons, sniper cannons") txt.text = "Electromagnetic Acceleration Weapons";
				if (txt.name == "Text" && txt.text.Contains("Medium or high accuracy"))
					txt.text = "- Ignore shields and negate deflection." + "\n" +
					"- High energy & low resources consumption." + "\n" +
					"- Very accurate and great module damage." + "\n" +
					"- Slow reload, high speed & moderate reload." + "\n" +
					"- Various payloads grant tactical advantage." + "\n" +
					"- Durable projectiles allow to bypass CIWS.";
				if (txt.name == "Headline" && txt.text == "EMP weapons") txt.text = "Energy/Kinetic Hybrid Weapons";
				if (txt.name == "Text" && txt.text.Contains("Overload modules of unshielded ships"))
					txt.text = "- Negate deflection, but stopped by shields." + "\n" +
					"- High energy & low resources consumption." + "\n" +
					"- Moderate reload, salvo, damage, AoE & speed." + "\n" +
					"- Can't be targeted and intercepted by CIWS." + "\n" +
					"- Cause EMP damage in area of effect on impact." + "\n" +
					"- Rapid-fire variants have very low accuracy.";
				if (txt.name == "Headline" && txt.text == "Capital Missiles (nukes)") txt.text = "Anti-Ship/Ship-to-Ship Capital Ordnance";
				if (txt.name == "Text" && txt.text.Contains("Missile itself travels slowly and takes more"))
					txt.text = "- <color=#" + colorNukeEnr + "ff>Energy</color>: anti-shield nuke that EMPs everything." + "\n" +
					"- <color=#" + colorNukeThr + "ff>Thermal</color>: possibly can set entire ship on fire." + "\n" +
					"- <color=#" + colorNukeTac + "ff>Tactical</color>: cheap & low-yield source of damage." + "\n" +
					"- <color=#" + colorNukeChm + "ff>Chemical</color>: perfect for sanitizing entire ship." + "\n" +
					"- <color=#" + colorNukeBrd + "ff>Boarding</color>: delivers guests without tea & cookies." + "\n" +
					"- <color=#" + colorNukeStr + "ff>Strategic</color>: ultimate, but blocked by shields.";
				if (txt.name == "Headline" && txt.text == "Special weapons") txt.text = "Additional Weapon Systems Information";
				if (txt.name == "Text" && txt.text.Contains("Various rare weapons with a variety of special"))
					txt.text = "- <color=#" + colorNukeKin + "ff>Kinetic</color> nukes are more like an oversized kinetic projectiles, than nukes. But they are cheap." + "\n" +
					"- All capital missiles are single use items. Some of them are very expensive. Use them wisely." + "\n" +
					"- Some weapons can't be properly categorized, because they are too unique to fit anywhere.";
				if (txt.name == "battle" && txt.text == "Battle 1") txt.text = "Battle Tactics Basics";
				if (txt.name == "Text" && txt.text == "Battle 1") txt.text = "Battle Tactics Basics";
				if (txt.name == "battle 2" && txt.text == "Battle 2") txt.text = "Battle Tactics Details";
				if (txt.name == "Text" && txt.text == "Battle 2") txt.text = "Battle Tactics Details";
				if (txt.name == "survivebattles" && txt.text == "Surviving battles") txt.text = "Surviving Battles";
				if (txt.name == "Text" && txt.text == "How to survive battles") txt.text = "Surviving Battles";
				if (txt.name == "battle escape" && txt.text == "Escaping From Battles") txt.text = "Escape & Retreat (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Escaping from battles") txt.text = "Escape & Retreat (FFU:BE)";
				if (txt.name == "DescriptionText" && txt.text.Contains("Remember that it is better to escape a battle"))
					txt.text = "Remember that it is better to escape a battle rather than die fighting. Because you always can return and fight it out later." + "\n\n" +
					"Warp drive recharge time is not accelerated, when you are in battle or within active detection range of hostile fleets." + "\n\n" +
					"You can retreat from battles only by spinning up and activating the warp drive. Warp drives need fuel, power and operating crew to work." + "\n\n" +
					"<color=lime>" + "However, some hostile fleets has ability to completely <color=orange>scramble</color> your warp drive, thus leaving you no " +
					"choice, but to fight to the bitter end. This is especially true for <color=orange>Interdiction Fleets</color> sent by <color=orange>Local Forces" +
					"</color> that aware of your presence in the sector." + "</color>";
				if (txt.name == "doors" && txt.text == "Doors") txt.text = "Doors & Airlocks (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Doors") txt.text = "Doors & Airlocks (FFU:BE)";
				if (txt.name == "DescriptionText" && txt.text.Contains("Many ships have doors which can be locked"))
					txt.text = "Many ships are divided into multiple sections & segments. Doors & hatches between these sections & segments " +
					"allow crewmembers access them. All doors can be locked/unlocked by clicking RMB (Right Mouse Button) on it, if you're owner. " +
					"Locking door/hatch prevents enemies from entering into the section/segment. Also, locked door/hatch prevents fire from spreading." + "\n\n" +
					"<color=lime>" + "If your flagship is not in battle and not pursued by enemy fleet, you can repair doors. Repair doors by clicking " +
					"<color=orange>Left Mouse Button</color> on them. Each click can repair up to 10 hit points. Repairing each " +
					"door hit point costs <color=orange>2 metals</color> and <color=orange>4 synthetics</color> by default." + "</color>";
				if (txt.name == "log" && txt.text == "Log Messages") txt.text = "Ship Messages Log";
				if (txt.name == "Text" && txt.text == "Log messages") txt.text = "Ship Messages Log";
				if (txt.name == "DescriptionText" && txt.text.Contains("The log console shows what's going on in"))
					txt.text = "This console keeps logs of all events that happened in the ship or in its vicinity. Whether somebody died, " +
					"container started leaking starfuel, planetary defenses launched nukes, what was eaten on dinner or if reactor is about " +
					"to reach meltdown point and tear ship apart, all these things will be logged." + "\n\n" +
					"If the message is logged in <color=red>red</color>, it means event is a negative one, while " +
					"if it is logged in <color=lime>green</color>, it means that was positive even.";
				if (txt.name == "crew" && txt.text == "Crew") txt.text = "Detailed Crew Information";
				if (txt.name == "Text" && txt.text == "Crew") txt.text = "Detailed Crew Information";
				if (txt.name == "crewhealth" && txt.text == "Crew health") txt.text = "Healing & Repair (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Crew health") txt.text = "Healing & Repair (FFU:BE)";
				if (txt.name == "DescriptionText" && txt.text.Contains("Send crew into medbay to heal damage"))
					txt.text = "Wounded crew can be healed in Medical Bays. Damaged drones can be repaired in Drone Bays. " +
					"Healing crewmembers and pets requires organics, while repairing drones requires synthetics. As alternative, " +
					"wounder crewmembers and pets can be sent to heal in Cryodream and Cryosleep bays, but it might take a long time.";
				if (txt.name == "Text" && txt.text.Contains("Send crew into medbay to heal damage"))
					txt.text = "Healing Bays, Drone Bays and Restoration Bays provide fast way to bring all crewmembers to optimal state, but for a price.";
				if (txt.name == "Text" && txt.text.Contains("Crew in cryosleep do not consume organics"))
					txt.text = "Cryodream Bays and Cryosleep Bays also can heal crewmembers and pets, albeit at much slower pace. Sadly, this doesn't apply to drones.";
				if (txt.name == "intruders" && txt.text == "Intruders") txt.text = "Crew & Intruders (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Intruders") txt.text = "Crew & Intruders (FFU:BE)";
				if (txt.name == "DescriptionText" && txt.text.Contains("To increase crew survivability against"))
					txt.text = "Sometimes, at any point during your peaceful adventure you might get uninvited visitors at your ship. " +
					"It can be Pirates, Slavers, Bounty Hunters, Mad Scientists, Loan Sharks and bona fide hungry Xenomorphs. " +
					"Anyway, whoever they are, you don't want them on your ship and it is unlikely that they will leave on their own, " +
					"even if you will share your last pack of cookies with them. Thus, you need to convince them to leave though the most " +
					"classic method of all: hail of bullets and napalm." + "\n\n" +
					"<color=lime>" + "You can strengthen your crew though various means. Beside maxing out their <color=orange>Hand Weapons Skill</color>, " +
					"you also can increases their maximum health by applying <color=orange>Biological Implants Cache</color> (for biological crew) or " +
					"<color=orange>Mechanical Upgrades Cache</color> (for mechanical crew). You also can change crew personal weapons by opening various " +
					"<color=orange>Weapon Caches</color> that suit your requirements. In short, you can buff your crewmembers to such levels that even " +
					"Duke Nukem will nod at them with deep respect." + "</color>" + "\n\n" +
					"To increase crew survivability against enemy combatants, it is highly advised to position them to shoot from behind corners. " +
					"Also, please do remember that Hand Weapons can damage ship modules as well, thus beware of any skirmishes near reactors.";
				if (txt.name == "multiplecrew" && txt.text == "Managing multiple crew") txt.text = "Managing Ship Personnel";
				if (txt.name == "Text" && txt.text == "Managing multiple crew") txt.text = "Managing Ship Personnel";
				if (txt.name == "resources" && txt.text == "Resources") txt.text = "Supplies & Resources";
				if (txt.name == "Text" && txt.text == "Resources") txt.text = "Supplies & Resources";
				if (txt.name == "DescriptionText" && txt.text.Contains("Basic resources are organics, fuel"))
					txt.text = "Basic resources, such as Organics, Starfuel, Metals, Synthetics, Explosives and Exotics that required to " +
					"sustain day-to-day ship's operations. Lacking any of them may result in very unexpected consequences and very expected " +
					"end of your voyage. Be sure to alway keep your eye on their levels or at very least keep in store backup Resource Pack " +
					"of each resource in your Storage." + "\n\n" +
					"<color=lime>" + "When playing Fight For <color=orange>Universe: Bleeding Edge</color> modification for " +
					"<color=orange>Shortest Trip to Earth</color>, you will need a lot of them, because you will use them often, " +
					"especially when switching to next tier of ship modules or using resource hungry weapons." + "</color>";
				if (txt.name == "organics" && txt.text == "Organics") txt.text = "Organic Substances";
				if (txt.name == "Text" && txt.text == "Organics") txt.text = "Organic Substances";
				if (txt.name == "DescriptionText" && txt.text.Contains("Most crewmembers consume organics as food"))
					txt.text = "Organic substances are base material that can be easily converted into food, water, air and other recreational " +
					"substances through ship's built-in systems. Running out of organic substances will reduce crewmembers skill efficiency by 50%. " +
					"While traveling with empty organics storage, your crewmembers will lose health due to the hunger and lack of necessary supplies." + "\n\n" +
					"<color=lime>" + "There are a couple of ways to ensure that you have a stable supply of organics substances. The most effective " +
					"one is constantly active <color=orange>Greenhouse Module</color>. Others include harvesting organics from planets with ecosystems, buying it from " +
					"trade stations or organics traders and looting it from hostile ships." + "</color>";
				if (txt.name == "fuel" && txt.text == "Fuel") txt.text = "High Energy Starfuel";
				if (txt.name == "Text" && txt.text == "Fuel") txt.text = "High Energy Starfuel";
				if (txt.name == "DescriptionText" && txt.text.Contains("Fuel is mostly consumed by warping between"))
					txt.text = "High Energy Starfuel, also known as Starfuel or just Fuel allows hungry Reactor Modules and Engine Modules " +
					"to generate enough output and thrust power to move your ships in direction of your choice. Warp Drives also require fuel " +
					"to initiate HyperJump to the location of your choice. Sometimes fuel also consumed for exploration and other EVA activities." + "\n\n" +
					"<color=lime>" + "Most basic way to acquire steady supply of fuel is to convert organics and synthetics into fuel via <color=orange>Fuel " +
					"Refinery</color> module. As for how to produce organics and synthetics, please read relevant entries in Help Section (F1). In " +
					"addition, fuel can be acquired through harvesting it from Gas Giants, buying it from trade stations or fuel traders and looting " +
					"it from hostile ships." + "</color>";
				if (txt.name == "refuel" && txt.text == "Refueling") { txt.transform.SetSiblingIndex(14); txt.text = "Module Integrity (FFU:BE)"; }
				if (txt.name == "Text" && txt.text == "Refueling") txt.text = "Module Integrity & Efficiency (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Options for gaining fuel") txt.text = "<color=lime>Module can be operated and used as long as it has more than <color=orange>25%</color> of HP!</color>";
				if (txt.name == "Text" && txt.text.Contains("Use converter modules (if you have them) to convert"))
					txt.text = "<color=lime>Even after receiving damage, modules still can be activated, operated and used by the crew. However, their " +
						"<color=orange>performance</color> and <color=orange>efficiency</color> will be <color=orange>reduced</color> based on the damage they received.</color>";
				if (txt.name == "Text" && txt.text.Contains("Harvest fuel from gas giants or explore"))
					txt.text = "<color=lime>Consequences of using damaged modules depends on their types. Whilst reactors will only have reduced performance " +
						"if damaged, <color=orange>weapons</color> can <color=orange>misfire</color> and cause damage to the ship and itself, if damaged.</color>";
				if (txt.name == "Text" && txt.text.Contains("Use xenodata credits to buy fuel from"))
					txt.text = "<color=lime>Using damaged modules in <color=orange>short-term</color> is fine, as during intense <color=orange>combat</color> " +
						"you won't have luxury of time to repair them all. However, in the <color=orange>long run</color> they should be <color=orange>repaired</color> to avoid any economic issues.</color>";
				if (txt.name == "Text" && txt.text.Contains("Scrap modules or nukes that give fuel"))
					txt.text = "<color=lime>Some modules are volatile by the nature and damaging them has consequences. On destruction nuke will <color=orange>explode</color>, " +
						"and on hit damaged container modules will start <color=orange>fires</color> and secondary <color=orange>explosions</color>.</color>";
				if (txt.name == "Text" && txt.text.Contains("Fight hostile fleets to gain fuel"))
					txt.text = "<color=lime>Nukes are the most volatile modules in the game. When <color=orange>HP</color> of the non-deployed nuke will reach " +
						"<color=orange>zero</color> from external damage, it will <color=orange>detonate</color> along with all magnificent atomic, biological & chemical consequences.</color>";
				if (txt.name == "Text" && txt.text.Contains("Activate the SOS signal and hope"))
					txt.text = "<color=lime>In addition, <color=orange>integrity</color> of a module affects chance to <color=orange>salvage</color> it from enemy " +
						"ship, when it is destroyed. The more <color=orange>damage</color> module received during the battle, the lesser your <color=orange>chances</color> to salvage it.</color>";
				if (txt.name == "metals" && txt.text == "Metals") txt.text = "Metals & Composites";
				if (txt.name == "Text" && txt.text == "Metals") txt.text = "Metals & Composites";
				if (txt.name == "DescriptionText" && txt.text.Contains("Metals are the most common resource"))
					txt.text = "Metals, Metal Composites and Noble Metals are one of the basic resources. Although they aren't critically important as " +
					"organics and starfuel, they are still very important, especially when it comes to construction, crafting, hull repair and ammunition " +
					"printing (especially for Electromagnetic Acceleration Weapons). Sometimes metals also consumed during expeditions, when assembly " +
					"of specialized EVA equipment is needed." + "\n\n" +
					"<color=lime>" + "Metals can be produced via <color=orange>Blast Furnace</color> module, by consuming synthetics, explosives and " +
					"minor amount of exotic matter. Information about acquisition of synthetics, explosives and exotics can be found in relevant entries " +
					"of the Help Section (F1). In addition, metals can be acquired through processing of rich asteroids, buying it from trade stations or " +
					"metal traders and looting it from hostile ships after battles." + "</color>";
				if (txt.name == "synthetics" && txt.text == "Synthetics") txt.text = "Synthetic Compounds";
				if (txt.name == "Text" && txt.text == "Synthetics") txt.text = "Synthetic Compounds";
				if (txt.name == "DescriptionText" && txt.text.Contains("Synthethics is a general category for all kinds"))
					txt.text = "Synthetics is a general category for all kinds of ceramics, plastics, electronic components, artificial substances and " +
					"consumer goods. Just as metals, synthetics aren't critically important, but still very important when it comes to module repairs, " +
					"drones maintenance, modules crafting and printing some types of ammunitions. Synthetics also can be used during some EVA events " +
					"that require crewmembers to print some temporary equipment or single use ammunition." + "\n\n" +
					"<color=lime>" + "Synthetics can be easily produced by <color=orange>Synthetics Printer</color> module, as long as you have constant " +
					"supply of organics for it. Please refer to \"Organic Substances\" entry in Help Section (F1) for this. In addition, you can acquire " +
					"synthetics from some EVA events, trade stations, synthetics traders and even by looting it from hostile ships after battles." + "</color>";
				if (txt.name == "explosives" && txt.text == "Explosives") txt.text = "Explosive Materials";
				if (txt.name == "Text" && txt.text == "Explosives") txt.text = "Explosive Materials";
				if (txt.name == "DescriptionText" && txt.text.Contains("Explosives are used as ammo for most"))
					txt.text = "Explosive materials is a basic resource and is epitome of creativity and sentient ingenuity of how to deliver peace and " +
					"democracy to all other sentient (and not so much) species that don't cherish or respect them. Mostly used to print all kinds of " +
					"ammunition for non-energy weapons, especially resource hungry rocket launcher platforms. The Mothership AI also uses explosives " +
					"automatically to print mines, cheap missiles and bombs during conflict events that happen off-screen." + "\n\n" +
					"<color=lime>" + "As long as you got steady supply of synthetics and starfuel you can easily produce explosives via <color=orange>" +
					"Ordnance Factory</color> module. Regarding synthetics and starfuel production you can read relevant entries in Help Section (F1). " +
					"You also can acquire explosives from some EVA events, buy from trade stations or explosive traders and even loot it from hostile " +
					"ships." + "</color>";
				if (txt.name == "exotics" && txt.text == "Exotic Substances") txt.text = "Rare & Exotic Matter";
				if (txt.name == "Text" && txt.text == "Exotics") txt.text = "Rare & Exotic Matter";
				if (txt.name == "DescriptionText" && txt.text.Contains("Exotics are most useful for crafting"))
					txt.text = "Exotic matter is universal category of resources that includes Antimatter, various kinds of Dark Matter, miniature " +
					"chunks of Neutron and Pulsar stars, and everything else that defies known laws of physics and very expensive to acquire. Often used " +
					"in production of high-tech components, crafting of exotic modules, printing of specialized ammunition and even as alternative " +
					"currency to the xenodata credits. Also exotic matter is core component of any warp drive module." + "\n\n" +
					"<color=lime>" + "Unlike other resources, exotic matter is very difficult to acquire. Beside inefficient production via <color=orange>" +
					"Exotics XMT-Purifier</color> module, exotic matter can be acquired from specialized <color=orange>Laboratories</color>, exotic " +
					"<color=orange>Greenhouses</color>, warp animal remains and rarely by looting hostile ships after battles." + "</color>";
				if (txt.name == "credits" && txt.text == "(Xeno)Data Credits") txt.text = "Xenodata Credits";
				if (txt.name == "Text" && txt.text == "(Xeno)Data credits") txt.text = "Xenodata Credits";
				if (txt.name == "DescriptionText" && txt.text.Contains("Xenodata credits, usually called just"))
					txt.text = "Xenodata credits, also known as xenodata or just credits. It is the most respected form of intergalactic currency. " +
					"It uses a semi-intelligent digital algorithm to convert any data with knowledge value into a universally priced form, thus almost " +
					"any exploration brings some sort of revenue in form of xenodata." + "\n\n" +
					"<color=lime>" + "There are multiple way to earn credits, beside exploration. Actively working <color=orange>Laboratories</color> " +
					"and <color=orange>Cryodream Bays</color> will generate xenodata during travel, <color=orange>Quantum Processor</color> module " +
					"can convert exotic matter into xenodata after deep analysis, albeit inefficiently. You also can acquire credits by selling resources " +
					"or by looting remains of hostile ships after battles." + "</color>";
				if (txt.name == "fate points" && txt.text == "Fate Points") txt.text = "Fate Points & Destiny";
				if (txt.name == "Text" && txt.text == "Fate points") txt.text = "Fate Points & Destiny";
				if (txt.name == "saveresources" && txt.text == "Saving resources") txt.text = "Additional Mod Info (FFU:BE)";
				if (txt.name == "Text" && txt.text == "Saving resources") txt.text = "Additional Mod Information (FFU:BE)";
				if (txt.name == "Text" && txt.text.Contains("To save organics, send unused crewmembers into crysoleep"))
					txt.text = "<color=lime>" + "Research Progress: research progress defines tier of modules, when they are crafted. It increases " +
					"only when you have active and crewed <color=orange>Laboratory</color> module(s) on your ship. Working crewmembers' <color=orange>" +
					"Science Skill</color> level considerably affects speed of the research progress." + "</color>";
				if (txt.name == "Text" && txt.text.Contains("Garden modules produce organics while travelling"))
					txt.text = "<color=lime>" + "Crafting Proficiency: every time you craft module, even if result is inferior, crafting proficiency " +
					"of that module increases. With increase in crafting proficiency of the module, there is higher chance for module to get <color=orange>" +
					"positive</color> modifier and lower chance to get <color=orange>negative</color> modifier." + "</color>";
				if (txt.name == "Text" && txt.text.Contains("Material convertors convert different resources"))
					txt.text = "<color=lime>" + "Reverse Engineering: every time you scrap module, if it's blueprint isn't stored in the database, " +
					"you will attempt to reverse engineer it (unless you already on it). You also can rotate reverse engineering query " +
					"with <color=orange>PAGE UP</color> and <color=orange>PAGE DOWN</color> while mouse is hovering over research icon." + "</color>";
				if (txt.name == "Text" && txt.text.Contains("During battles, try using more energy weapons"))
					txt.text = "<color=lime>" + "Local Forces Strength: every time you defeat <color=orange>Interdiction Fleet</color> that came " +
					"to intercept you, Military Strength of Local Forces slightly rises. Known strength levels: " + 
					FFU_BE_Mod_Discovery.GetHostileFleetsLevel(0) + ", " + FFU_BE_Mod_Discovery.GetHostileFleetsLevel(1) + ", " +
					FFU_BE_Mod_Discovery.GetHostileFleetsLevel(2) + ", " + FFU_BE_Mod_Discovery.GetHostileFleetsLevel(3) + ", " +
					FFU_BE_Mod_Discovery.GetHostileFleetsLevel(4) + ", " + FFU_BE_Mod_Discovery.GetHostileFleetsLevel(5) + ", " +
					FFU_BE_Mod_Discovery.GetHostileFleetsLevel(6) + ", " + FFU_BE_Mod_Discovery.GetHostileFleetsLevel(7) + ", " +
					FFU_BE_Mod_Discovery.GetHostileFleetsLevel(8) + " and " + FFU_BE_Mod_Discovery.GetHostileFleetsLevel(9) + ".</color>";
				if (txt.name == "shop" && txt.text == "Trade Stations") txt.text = "Trade Stations & Traders";
				if (txt.name == "Text" && txt.text == "Trade stations") txt.text = "Trade Stations & Traders";
				if (txt.name == "DescriptionText" && txt.text.Contains("Trade stations are a good place to sell resources"))
					txt.text = "Trade stations are a good place to sell resources for credits. Some stations also sell ship repair " +
					"services, modules and crew. It is cheaper to repair your ship in stations than manually by crew." + "\n\n" +
					"If you need extra credits to buy something, consider scrapping less useful modules and selling the gained resources. Modules " +
					"cannot be sold whole and must be scrapped into raw resources before selling.";
				if (txt.name == "SOS" && txt.text == "SOS Signal") txt.text = "SOS Signal Beacon (FFU:BE)";
				if (txt.name == "Text" && txt.text == "SOS signal") txt.text = "SOS Signal Beacon";
				if (txt.name == "DescriptionText" && txt.text.Contains("Not enough fuel for warping to next starsystem?"))
					txt.text = "Not enough organics and life support system is about to give in? Not enough fuel for warping to next star " +
					"system? Not enough metals to repair hull that is about to break apart? Not enough synthetics to fix leaking reactor? Last " +
					"explosive ordnance were spent 5 light years ago?" + "\n\n" +
					"Worry not! Just active SOS Signal Beacon and hope the one that will detect it is peaceful trader and not another " +
					"bloodthirsty warp creature or band of angry slavers that haven't seen profit for last 42 years." + "\n\n" +
					"<color=lime>" + "Be warned, every time you activate SOS Signal Beacon, there is a chance that <color=orange>Military " +
					"Strength</color> of the <color=orange>Local Forces</color> might rise, as they might mistake your SOS Signal as trapping " +
					"attempt, sign for invasion start or even hidden illegal contraband notification." + "</color>";
				if (txt.name == "pirates" && txt.text == "Space Pirates") txt.text = "Space Pirates & Slavers";
				if (txt.name == "Text" && txt.text == "Space pirates") txt.text = "Space Pirates & Slavers";
				if (txt.name == "DescriptionText" && txt.text.Contains("Pirates are individuals who"))
					txt.text = "Pirates are individuals who (even after all the technological progress) have still not learned the basics " +
					"of respecting the safety of other sentients. And Slavers are individuals who have still not learned basics of living " +
					"rights of other sentients. Neither of them deserves respect." + "\n\n" +
					"However, pirates and slavers are still very useful part of society, especially as a source of information about other " +
					"pirates, their hideouts and legitimate loot filled with resources, credits, rare exotic substances and even unknown " +
					"artifacts. As result, hunting down Pirates and Slavers earns not only respect and bounty, but also various " +
					"resources salvaged from wrecks of their ships.";
				if (dumpObjectLists) Debug.Log("[Game Text] " + txt.name + ": " + txt.text);
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
					"mod for <color=#4fd376>Shortest Trip to Earth</color>, because original amount of <color=#cc0000>death and desperation</color> " +
					"was not enough and you decided to go full IDDQD." + "\n\n" +
						"Bleeding Edge Main Features:" + "\n" +
						" - Completely New In-Game Mechanics" + "\n" +
						" - Modules, Crew & Firearms Rebalance" + "\n" +
						" - Module Reversing, Research & Tiers" + "\n" +
						" - Local Forces Awareness & Response" + "\n" +
						" - Reworked Boarding & Module Looting" + "\n" +
						" - Mod Added Features Info (<color=orange>F1</color> hotkey)" + "\n" +
					"\n" + "Special thanks goes to <color=#4fd376>Interactive Fate</color> for creating this art piece and helping me with modding it, " +
					"thus allowing me to make this unforgiving mod for it.";
				if (txt.text.ToLower().Contains("we offer you an opportunity to unlock"))
					txt.text = "<size=14>\nCongratulations! You found a secret cow level. Nah, I'm kidding, there is no cow level. If you found this " +
						"page, it means you probably already know about mod's configuration file existence." + "\n\n" +
						"Anyway, you can <color=#3366ff>reset all data and just unlock all ships</color> or <color=#ff3333>reset all data and unlock " +
						"all ships with all perks</color> depending on mod's configuration. To do it just follow (no, not a white rabbit) IDKFA and " +
						"take the pill.\n</size>";
				if (dumpObjectLists) Debug.Log("[Welcome Text] " + txt.name + ": " + txt.text);
			}
		}
		public static float GetDifficultyDamageMax() {
			if (WorldRules.Impermanent.beginnerStartingBonus) return 0.5f;
			else if (WorldRules.Impermanent.ironman) return 0.9f;
			else return 0.7f;
		}
		public static float GetDifficultyModifier() {
			if (WorldRules.Impermanent.beginnerStartingBonus) return 0.5f;
			else if (WorldRules.Impermanent.ironman) return 2f;
			else return 1f;
		}
		public static int GetDifficultySetting() {
			if (WorldRules.Impermanent.beginnerStartingBonus) return 1;
			else if (WorldRules.Impermanent.ironman) return 3;
			else return 2;
		}
		public static float GetHealthPercent(ShipModule shipModule) {
			return Mathf.Clamp(shipModule.Health / (float)shipModule.MaxHealth, 0.0001f, 1f);
		}
		public static float GetHealthEffect(ShipModule shipModule, float hMult = 1f) {
			return (1f - (shipModule.Health / (float)shipModule.MaxHealth)) * hMult;
		}
		public static bool DamagedButWorking(ShipModule shipModule) {
			return GetHealthPercent(shipModule) >= moduleDamageThreshold;
		}
		public static float GetResearchFromRVG(ResourceValueGroup mOutput) {
			return (mOutput.credits + mOutput.organics + mOutput.fuel + mOutput.metals + mOutput.synthetics + mOutput.explosives) / researchCommonDivisor + mOutput.exotics / researchRareDivisor;
		}
		public static float GetReverseFromRVG(ResourceValueGroup mOutput) {
			return GetResearchFromRVG(mOutput) / reverseResearchDivisor;
		}
		public static void GetComponentsListTree(Text tObject) {
			if (tObject == null) return;
			GetComponentsListTree(tObject.transform.parent.parent);
		}
		public static void GetComponentsListTree(GameObject tObject) {
			if (tObject == null) return;
			GetComponentsListTree(tObject.transform);
		}
		public static void GetComponentsListTree(ModuleEffectItem tObject) {
			if (tObject == null) return;
			GetComponentsListTree(tObject.transform);
		}
		public static void GetComponentsListTree(Transform tObject) {
			if (tObject == null) return;
			try { GetComponentsListTree(tObject, 0, 0); } catch (System.Exception ex) { Debug.LogWarning(ex.ToString()); }
		}
		private static void GetComponentsListTree(Transform tObject, int cOrder, int childNum) {
			if (tObject == null) return;
			StringBuilder itemSpacing = new StringBuilder();
			for (int i = 0; i < cOrder; i++) itemSpacing.Append("  ");
			if (cOrder == 0) Debug.LogWarning($"[ROOT] {tObject.ToString()}");
			else Debug.LogWarning($"{itemSpacing.ToString()}[{childNum}] {tObject.ToString()}");
			for (int i = 0; i < tObject.GetComponents<object>().Length; i++) Debug.LogWarning($"{itemSpacing.ToString()}  - {tObject.GetComponents<object>()[i]?.ToString()}");
			for (int i = 0; i < tObject.childCount; i++) GetComponentsListTree(tObject.GetChild(i), cOrder + 1, i);
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
			float rollValue = Random.Range(0f, 100f);
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
			if (moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) return moduleEmissionPrefabs[shipModule.PrefabId];
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
		public static bool ModuleEmitsEnergy(ShipModule shipModule) {
			if (!(shipModule != null)) return false;
			switch (shipModule.type) {
				case ShipModule.Type.Bridge: return shipModule.Bridge != null && shipModule.turnedOn;
				case ShipModule.Type.PointDefence: return shipModule.PointDefence != null && shipModule.turnedOn;
				case ShipModule.Type.ShieldGen: return shipModule.ShieldGen != null && shipModule.turnedOn;
				case ShipModule.Type.Dronebay: case ShipModule.Type.Medbay: return shipModule.Medbay != null && shipModule.turnedOn;
				case ShipModule.Type.Cryosleep: return shipModule.Cryosleep != null && shipModule.turnedOn;
				case ShipModule.Type.ResearchLab: return shipModule.Research != null && shipModule.turnedOn;
				case ShipModule.Type.Garden: return shipModule.GardenModule != null && shipModule.turnedOn;
				case ShipModule.Type.Sensor: return shipModule.Sensor != null && shipModule.turnedOn;
				case ShipModule.Type.MaterialsConverter: return shipModule.MaterialsConverter != null && shipModule.turnedOn;
				case ShipModule.Type.Reactor: return shipModule.Reactor != null && shipModule.turnedOn;
				case ShipModule.Type.PassiveECM: return shipModule.ECM != null && shipModule.turnedOn;
				case ShipModule.Type.StealthDecryptor: return shipModule.StealthDecryptor != null && shipModule.turnedOn;
				case ShipModule.Type.Weapon: return shipModule.Weapon != null && shipModule.turnedOn;
				case ShipModule.Type.Weapon_Nuke: return shipModule.Weapon != null;
				case ShipModule.Type.Engine: return shipModule.Engine != null && shipModule.turnedOn;
				case ShipModule.Type.Warp: return shipModule.Warp != null;
				default: return false;
			}
		}
		public static float GetModuleEnergyEmission(ShipModule shipModule, bool isStatic = false) {
			if (!(shipModule != null)) return 0f;
			Core.BonusMod moduleMofidier = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			switch (shipModule.type) {
				case ShipModule.Type.Bridge:
				if (shipModule.Bridge != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.PowerConsumed / 2f * shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.PointDefence:
				if (shipModule.PointDefence != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.PointDefence.coverRadius) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.ShieldGen:
				if (shipModule.ShieldGen != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.ShieldGen.MaxShieldAdd / 5f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Dronebay: case ShipModule.Type.Medbay:
				if (shipModule.Medbay != null && (shipModule.turnedOn || isStatic)) return (shipModule.PowerConsumed + (shipModule.Medbay.resourcesPerHp.organics +
					shipModule.Medbay.resourcesPerHp.fuel + shipModule.Medbay.resourcesPerHp.metals + shipModule.Medbay.resourcesPerHp.synthetics +
					shipModule.Medbay.resourcesPerHp.explosives + shipModule.Medbay.resourcesPerHp.exotics * 10f + shipModule.Medbay.resourcesPerHp.credits / 10f) *
					shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Cryosleep:
				if (shipModule.Cryosleep != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.PowerConsumed / 2f * shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.ResearchLab:
				if (shipModule.Research != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + (shipModule.Research.producedPerSkillPoint.organics + shipModule.Research.producedPerSkillPoint.fuel +
					shipModule.Research.producedPerSkillPoint.metals + shipModule.Research.producedPerSkillPoint.synthetics +
					shipModule.Research.producedPerSkillPoint.explosives + shipModule.Research.producedPerSkillPoint.exotics * 10 +
					shipModule.Research.producedPerSkillPoint.credits) * shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Garden:
				if (shipModule.GardenModule != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + (shipModule.GardenModule.producedPerSkillPoint.organics + shipModule.GardenModule.producedPerSkillPoint.fuel +
					shipModule.GardenModule.producedPerSkillPoint.metals + shipModule.GardenModule.producedPerSkillPoint.synthetics +
					shipModule.GardenModule.producedPerSkillPoint.explosives + shipModule.GardenModule.producedPerSkillPoint.exotics * 10 +
					shipModule.GardenModule.producedPerSkillPoint.credits) * shipModule.CurrentLocalOpsCount) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Sensor:
				if (shipModule.Sensor != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.Sensor.sectorRadarRange / 10f + shipModule.Sensor.starmapRadarRange) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.MaterialsConverter:
				if (shipModule.MaterialsConverter != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.MaterialsConverter.consume.organics +
					shipModule.MaterialsConverter.consume.fuel + shipModule.MaterialsConverter.consume.metals + shipModule.MaterialsConverter.consume.synthetics +
					shipModule.MaterialsConverter.consume.explosives + shipModule.MaterialsConverter.consume.exotics * 10f + shipModule.MaterialsConverter.consume.credits / 10f +
					shipModule.MaterialsConverter.produce.organics + shipModule.MaterialsConverter.produce.fuel + shipModule.MaterialsConverter.produce.metals +
					shipModule.MaterialsConverter.produce.synthetics + shipModule.MaterialsConverter.produce.explosives + shipModule.MaterialsConverter.produce.exotics * 10f +
					shipModule.MaterialsConverter.produce.credits / 10f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Reactor:
				if (shipModule.Reactor != null && shipModule.IsOvercharged && (shipModule.turnedOn || isStatic))
					return (shipModule.Reactor.powerCapacity + shipModule.Reactor.overchargePowerCapacityAdd) * GetModuleEnergyEmissionMult(shipModule);
				else if (shipModule.Reactor != null && (shipModule.turnedOn || isStatic))
					return shipModule.Reactor.powerCapacity * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.PassiveECM:
				if (shipModule.ECM != null && (shipModule.turnedOn || isStatic))
					return shipModule.PowerConsumed / (moduleMofidier == Core.BonusMod.Sustained ? 0.5f :
					moduleMofidier == Core.BonusMod.Unstable ? 2f : 1f) * GetModuleEnergyEmissionMult(shipModule) *
					FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shipModule), Core.BonusType.Default) *
					(moduleMofidier == Core.BonusMod.Enhanced ? 1.2f : moduleMofidier == Core.BonusMod.Deficient ? 0.5f : 1f);
				else return 0f;
				case ShipModule.Type.StealthDecryptor:
				if (shipModule.StealthDecryptor != null && (shipModule.turnedOn || isStatic))
					return shipModule.PowerConsumed / (moduleMofidier == Core.BonusMod.Sustained ? 0.5f : 
					moduleMofidier == Core.BonusMod.Unstable ? 2f : 1f) * GetModuleEnergyEmissionMult(shipModule) *
					FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shipModule), Core.BonusType.Default) *
					(moduleMofidier == Core.BonusMod.Enhanced ? 2f : moduleMofidier == Core.BonusMod.Deficient ? 0.5f : 1f);
				else return 0f;
				case ShipModule.Type.Weapon:
				if (shipModule.Weapon != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.Weapon.resourcesPerShot.fuel + shipModule.Weapon.resourcesPerShot.explosives * 2f +
					shipModule.Weapon.resourcesPerShot.exotics * 10f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Weapon_Nuke:
				if (shipModule.Weapon != null)
					return (shipModule.craftCost.fuel + shipModule.craftCost.explosives * 2f + shipModule.craftCost.exotics * 10f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Engine:
				if (shipModule.Engine != null && shipModule.IsOvercharged && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.overchargePowerNeed + shipModule.Engine.ConsumedPerDistance.fuel * 100f) * GetModuleEnergyEmissionMult(shipModule);
				else if (shipModule.Engine != null && (shipModule.turnedOn || isStatic))
					return (shipModule.PowerConsumed + shipModule.Engine.ConsumedPerDistance.fuel * 100f) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				case ShipModule.Type.Warp:
				if (shipModule.Warp != null)
					return (shipModule.PowerConsumed + shipModule.Warp.activationFuel) * GetModuleEnergyEmissionMult(shipModule);
				else return 0f;
				default: return 0f;
			}
		}
		public static string GetModuleEmissionValues(ShipModule shipModule) {
			if (shipModule == null) return null;
			float emissionMin = 0f;
			float emissionMax = 0f;
			Core.BonusMod moduleMofidier = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			switch (shipModule.type) {
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				var mBayResPerHP = shipModule.Medbay != null ? shipModule.Medbay.resourcesPerHp : new ResourceValueGroup();
				emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
				emissionMax = (shipModule.PowerConsumed + (mBayResPerHP.organics + mBayResPerHP.fuel +
				mBayResPerHP.metals + mBayResPerHP.synthetics + mBayResPerHP.explosives + mBayResPerHP.exotics * 10f +
				mBayResPerHP.credits / 10f) * shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				break;
				case ShipModule.Type.Bridge:
				emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
				emissionMax = (shipModule.PowerConsumed + shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				break;
				case ShipModule.Type.Cryosleep:
				emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
				emissionMax = (shipModule.PowerConsumed + shipModule.PowerConsumed / 2f * shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				break;
				case ShipModule.Type.ResearchLab:
				var rLabResPerSP = shipModule.Research != null ? shipModule.Research.producedPerSkillPoint : new ResourceValueGroup();
				emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
				emissionMax = (shipModule.PowerConsumed + (rLabResPerSP.organics + rLabResPerSP.fuel +
				rLabResPerSP.metals + rLabResPerSP.synthetics + rLabResPerSP.explosives + rLabResPerSP.exotics * 10 +
				rLabResPerSP.credits) * shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				break;
				case ShipModule.Type.Garden:
				var gFarmResPerSP = shipModule.GardenModule != null ? shipModule.GardenModule.producedPerSkillPoint : new ResourceValueGroup();
				emissionMin = shipModule.PowerConsumed * GetModuleEnergyEmissionMult(shipModule);
				emissionMax = (shipModule.PowerConsumed + (gFarmResPerSP.organics + gFarmResPerSP.fuel +
				gFarmResPerSP.metals + gFarmResPerSP.synthetics + gFarmResPerSP.explosives + gFarmResPerSP.exotics * 10 +
				gFarmResPerSP.credits) * shipModule.OperatorSpots.Length) * GetModuleEnergyEmissionMult(shipModule);
				break;
				case ShipModule.Type.Reactor:
				emissionMin = shipModule.Reactor.powerCapacity * GetModuleEnergyEmissionMult(shipModule);
				emissionMax = (shipModule.Reactor.powerCapacity + shipModule.Reactor.overchargePowerCapacityAdd) * GetModuleEnergyEmissionMult(shipModule);
				break;
				case ShipModule.Type.Engine:
				emissionMin = (shipModule.PowerConsumed + shipModule.Engine.ConsumedPerDistance.fuel * 100f) * GetModuleEnergyEmissionMult(shipModule);
				emissionMax = (shipModule.PowerConsumed + shipModule.overchargePowerNeed + shipModule.Engine.ConsumedPerDistance.fuel * 100f) * GetModuleEnergyEmissionMult(shipModule);
				break;
				case ShipModule.Type.PointDefence:
				case ShipModule.Type.ShieldGen:
				case ShipModule.Type.Sensor:
				case ShipModule.Type.MaterialsConverter:
				case ShipModule.Type.PassiveECM:
				case ShipModule.Type.StealthDecryptor:
				case ShipModule.Type.Weapon:
				case ShipModule.Type.Weapon_Nuke:
				case ShipModule.Type.Warp:
				emissionMin = GetModuleEnergyEmission(shipModule, true);
				break;
				default: emissionMin = 0f; emissionMax = 0f; break;
			}
			StringBuilder emissionText = new StringBuilder();
			if (emissionMin != 0f) emissionText.Append($"{emissionMin:0.#}").Append($"{Core.TT("m")}³");
			if (emissionMax != 0f) emissionText.Append(" ~ ").Append($"{emissionMax:0.#}").Append($"{Core.TT("m")}³");
			return emissionText.ToString();
		}
		public static void RecalculateEnergyEmission() {
			try {
				if (PlayerDatas.Me != null && PlayerDatas.Me.Flagship != null) {
					energyEmission = 0;
					foreach (ModuleSlotRoot slotRoot in PlayerDatas.Me.Flagship.ModuleSlotRoots) {
						try {
							if (slotRoot != null && slotRoot.Module != null && !slotRoot.Module.IsPacked && !slotRoot.Module.IsUnpacking)
								energyEmission += GetModuleEnergyEmission(slotRoot.Module);
							if (debugMode) Debug.LogWarning(slotRoot.Module.name + ": " + GetModuleEnergyEmission(slotRoot.Module));
						} catch { }
					}
					energyEmission *= GetFlagshipEmissionModifier();
					if (energyEmission < 100f) energyEmission = 100f;
				}
			} catch { }
		}
		public static float GetFlagshipEmissionModifier() {
			if (PlayerDatas.Me != null && PlayerDatas.Me.Flagship != null) return 1f + PlayerDatas.Me.Flagship.ModuleSlotRoots.Count * GetDifficultyModifier() / 100f;
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
			if (shipModule.name.Contains("bossweapon")) return true;
			else if (shipModule.name.Contains("tutorial")) return true;
			else if (shipModule.name.Contains("artifact")) return true;
			else return sectorViableModuleIDs[sectorNum].Contains(shipModule.PrefabId);
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
			if (refModule == null || !prefabModdedModulesList.Any()) return null;
			string lookupType = "";
			string lookupSubType = "";
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
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
				return GetRandomModuleType(refModule.type, sectorNum, lookupType, lookupSubType);
				case ShipModule.Type.Weapon_Nuke:
				if (refModule.displayName.Contains("Kinetic")) lookupType = "Kinetic";
				else if (refModule.displayName.Contains("Energy")) lookupType = "Energy";
				else if (refModule.displayName.Contains("Thermal")) lookupType = "Thermal";
				else if (refModule.displayName.Contains("Tactical")) lookupType = "Tactical";
				else if (refModule.displayName.Contains("Chemical")) lookupType = "Chemical";
				else if (refModule.displayName.Contains("Boarding")) lookupType = "Boarding";
				else if (refModule.displayName.Contains("Strategic")) lookupType = "Strategic";
				return GetRandomModuleType(refModule.type, sectorNum, lookupType);
				case ShipModule.Type.PointDefence:
				if (refModule.displayName.Contains("Capacitor")) lookupType = "Capacitor";
				else if (refModule.displayName.Contains("Generator")) lookupType = "Generator";
				return GetRandomModuleType(refModule.type, sectorNum, lookupType);
				case ShipModule.Type.Medbay:
				case ShipModule.Type.Dronebay:
				if (refModule.displayName.Contains("Drone")) lookupType = "Drone";
				else if (refModule.displayName.Contains("Medical")) lookupType = "Medical";
				else if (refModule.displayName.Contains("Restoration")) lookupType = "Restoration";
				return GetRandomModuleType(refModule.type, sectorNum, lookupType);
				case ShipModule.Type.Cryosleep:
				if (refModule.displayName.Contains("Cryodream")) lookupType = "Cryodream";
				else if (refModule.displayName.Contains("Cryosleep")) lookupType = "Cryosleep";
				return GetRandomModuleType(refModule.type, sectorNum, lookupType);
				default: return GetRandomModuleType(refModule.type, sectorNum);
			}
		}
		public static ShipModule GetRandomModuleType(ShipModule.Type moduleType, int sectorNum, string mType, string mSubType) {
			List<ShipModule> refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[sectorNum].Contains(x.PrefabId) && x.displayName.Contains(mType) && x.displayName.Contains(mSubType)).ToList();
			if (!refList.Any()) refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[sectorNum].Contains(x.PrefabId) && x.displayName.Contains(mType)).ToList();
			if (!refList.Any()) refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[sectorNum].Contains(x.PrefabId)).ToList();
			if (!refList.Any()) refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[0].Contains(x.PrefabId)).ToList();
			return Core.RandomItemFromList(refList, null);
		}
		public static ShipModule GetRandomModuleType(ShipModule.Type moduleType, int sectorNum, string mType) {
			List<ShipModule> refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[sectorNum].Contains(x.PrefabId) && x.displayName.Contains(mType)).ToList();
			if (!refList.Any()) refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[sectorNum].Contains(x.PrefabId)).ToList();
			if (!refList.Any()) refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[0].Contains(x.PrefabId)).ToList();
			return Core.RandomItemFromList(refList, null);
		}
		public static ShipModule GetRandomModuleType(ShipModule.Type moduleType, int sectorNum) {
			List<ShipModule> refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[sectorNum].Contains(x.PrefabId)).ToList();
			if (!refList.Any()) refList = prefabModdedModulesList.Where(x => x.type == moduleType && sectorViableModuleIDs[0].Contains(x.PrefabId)).ToList();
			return Core.RandomItemFromList(refList, null);
		}
		public static ShipModule GetRandomModuleType(ShipModule.Type moduleType) {
			return Core.RandomItemFromList(prefabModdedModulesList.Where(x => x.type == moduleType).ToList(), null);
		}
		public static void SetViableForSectors(int modulePrefabID, params int[] sectorNumbers) {
			if (!sectorViableModuleIDs[0].Contains(modulePrefabID)) sectorViableModuleIDs[0].Add(modulePrefabID);
			foreach (int sectorNumber in sectorNumbers) if (!sectorViableModuleIDs[sectorNumber].Contains(modulePrefabID)) sectorViableModuleIDs[sectorNumber].Add(modulePrefabID);
		}
		public static void SetViableForSectors(int modulePrefabID) {
			if (!sectorViableModuleIDs[0].Contains(modulePrefabID)) sectorViableModuleIDs[0].Add(modulePrefabID);
		}
	}
}