using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Sensors {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 930742757) return idx; idx++; //sensor 0-C diy
			if (moduleID == 2117018739) return idx; idx++; //sensor 1-L DIY
			if (moduleID == 948524677) return idx; idx++; //sensor 2 saucer old
			if (moduleID == 1084722255) return idx; idx++; //sensor 3 L terran simple
			if (moduleID == 1995820130) return idx; idx++; //sensor 3 planty
			if (moduleID == 2063928716) return idx; idx++; //sensor 4 saucer new
			if (moduleID == 1536566470) return idx; idx++; //sensor 5 EB saucer s1
			if (moduleID == 1451617742) return idx; idx++; //sensor 8 sunpanel old s1
			if (moduleID == 1241054343) return idx; idx++; //sensor 5 futu saucer s1
			if (moduleID == 171954196) return idx; idx++; //sensor 10 terran s2
			if (moduleID == 204974912) return idx; idx++; //sensor 11 blue adv s2
			if (moduleID == 680853891) return idx; idx++; //sensor 11 sophisiticated s2
			if (moduleID == 588186350) return idx; idx++; //sensor 12 spideraa
			if (moduleID == 524731680) return idx; idx++; //sensor 11 seashell s2
			if (moduleID == 160051026) return idx; idx++; //sensor 10 tiger
			if (moduleID == 171954197) return idx; idx++; //sensor 9 sunpanel new s2
			return idx + 100;
		}
		public static void UpdateSensorModule(ShipModule shipModule, bool initItemData) {
			string colorSensor = "4dff79";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 930742757: //sensor 0-C diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Makeshift <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Literally made form scraps and printed metal plates. Provides only very limited navigation capabilities, but still better then going blind.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 100f, synthetics = 75f };
				shipModule.Sensor.sectorRadarRange = 80;
				shipModule.Sensor.starmapRadarRange = 8;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 5;
				break;
				case 2117018739: //sensor 1-L DIY
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Salvaged <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Made from salvaged parts of expired or broken down sensory arrays. Navigation capabilities are little bit better, but still very limited.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 150f, synthetics = 125f };
				shipModule.Sensor.sectorRadarRange = 100;
				shipModule.Sensor.starmapRadarRange = 10;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 6;
				break;
				case 948524677: //sensor 2 saucer old
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = "Ancient <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "A couple centuries old sensor array that been though every imaginable situation possible. Still in workable condition and provides basic navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 250f, synthetics = 175f };
				shipModule.Sensor.sectorRadarRange = 120;
				shipModule.Sensor.starmapRadarRange = 12;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 7;
				break;
				case 1084722255: //sensor 3 L terran simple
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = "Civilian <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Installed on most civilian vessels due to low purchase barrier and cheap maintenance costs. Provides somewhat decent navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 175f, metals = 400f, synthetics = 250f };
				shipModule.Sensor.sectorRadarRange = 140;
				shipModule.Sensor.starmapRadarRange = 14;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 8;
				break;
				case 1995820130: //sensor 3 planty
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Bionic <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Sensor array of organic origin. Grown artificially in special environment, but contains all necessary ports for proper interfacing with spaceship's systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, organics = 600f, synthetics = 400f };
				shipModule.Sensor.sectorRadarRange = 160;
				shipModule.Sensor.starmapRadarRange = 16;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 9;
				break;
				case 2063928716: //sensor 4 saucer new
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Modern <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Freshly manufactured and mass produced sensor array. Mostly installed on more serious vessels. Provides decent navigation and detection capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 750f, synthetics = 500f };
				shipModule.Sensor.sectorRadarRange = 180;
				shipModule.Sensor.starmapRadarRange = 18;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 10;
				break;
				case 1536566470: //sensor 5 EB saucer s1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.7f);
				shipModule.displayName = "Commercial <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Sensor array that was developed for sake of profit and sold to anybody who can afford it. Private manufacturing will lead to breach of copyright agreement and lawsuit.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 450f, metals = 1000f, synthetics = 750f, exotics = 1f };
				shipModule.Sensor.sectorRadarRange = 200;
				shipModule.Sensor.starmapRadarRange = 20;
				shipModule.starmapStealthDetectionLevelMax = 1;
				shipModule.shipAccuracyPercentAdd = 2;
				shipModule.powerConsumed = 6;
				shipModule_maxHealth = 11;
				break;
				case 1451617742: //sensor 8 sunpanel old s1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.7f);
				shipModule.displayName = "Auspex <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "More advanced sensor array with built-in targeting assistance system and basic anti-cloaking capabilities. Has good navigation and detection capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, metals = 1500f, synthetics = 500f, exotics = 2f };
				shipModule.Sensor.sectorRadarRange = 230;
				shipModule.Sensor.starmapRadarRange = 23;
				shipModule.starmapStealthDetectionLevelMax = 1;
				shipModule.shipAccuracyPercentAdd = 4;
				shipModule.powerConsumed = 6;
				shipModule_maxHealth = 12;
				break;
				case 1241054343: //sensor 5 futu saucer s1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Refraction <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Sensor array that uses refraction method to scan and detect all kinds of natural and artificial objects in space. Has very good navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 1750f, synthetics = 750f, exotics = 3f };
				shipModule.Sensor.sectorRadarRange = 260;
				shipModule.Sensor.starmapRadarRange = 26;
				shipModule.starmapStealthDetectionLevelMax = 2;
				shipModule.shipAccuracyPercentAdd = 6;
				shipModule.powerConsumed = 7;
				shipModule_maxHealth = 14;
				break;
				case 171954196: //sensor 10 terran s2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Tempest <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Sensor array that utilizes tempest architecture deep space for unidentified objects and lock onto them. Has excellent navigation and detection capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 900f, metals = 2250f, synthetics = 1000f, exotics = 5f };
				shipModule.Sensor.sectorRadarRange = 290;
				shipModule.Sensor.starmapRadarRange = 29;
				shipModule.starmapStealthDetectionLevelMax = 2;
				shipModule.shipAccuracyPercentAdd = 8;
				shipModule.powerConsumed = 7;
				shipModule_maxHealth = 16;
				break;
				case 204974912: //sensor 11 blue adv s2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = "Exotic <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Mostly built from exotic elements that resonate between each other and allow to use this resonance for scanning. Has great navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1050f, metals = 750f, synthetics = 500f, exotics = 50f };
				shipModule.Sensor.sectorRadarRange = 320;
				shipModule.Sensor.starmapRadarRange = 32;
				shipModule.starmapStealthDetectionLevelMax = 3;
				shipModule.shipAccuracyPercentAdd = 10;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 18;
				break;
				case 680853891: //sensor 11 sophisiticated s2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = "Multi-Spectrum <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Uses multi-spectrum mirrors array to discover and lock on targets or coordinates at great distances. Has great navigation, detection and targeting capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 2750f, synthetics = 1750f, exotics = 7f };
				shipModule.Sensor.sectorRadarRange = 350;
				shipModule.Sensor.starmapRadarRange = 35;
				shipModule.starmapStealthDetectionLevelMax = 3;
				shipModule.shipAccuracyPercentAdd = 12;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 20;
				break;
				case 588186350: //sensor 12 spideraa
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = "Repulsor <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Uses kinetic energy and unknown principles to send low-amplitude kinetic waves in a sonar-like way to discovered and lock on to targets at great distances.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 3000f, synthetics = 2500f, exotics = 10f };
				shipModule.Sensor.sectorRadarRange = 380;
				shipModule.Sensor.starmapRadarRange = 38;
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 14;
				shipModule.powerConsumed = 9;
				shipModule_maxHealth = 23;
				break;
				case 524731680: //sensor 11 seashell s2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = "Subspace <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Has built-in working subspace radio modulator that emits subspace waves that allow to detected objects at great distances. Almost perfect navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 3500f, synthetics = 2750f, exotics = 15f };
				shipModule.Sensor.sectorRadarRange = 420;
				shipModule.Sensor.starmapRadarRange = 42;
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 17;
				shipModule.powerConsumed = 9;
				shipModule_maxHealth = 26;
				break;
				case 160051026: //sensor 10 tiger
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.3f);
				shipModule.displayName = "Multi-Wave <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Utilizes harmony resonance technology that allows to gather exact data from resonance wave emissions that generated by great majority of interstellar objects.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 2000f, metals = 4000f, synthetics = 3000f, exotics = 20f };
				shipModule.Sensor.sectorRadarRange = 460;
				shipModule.Sensor.starmapRadarRange = 46;
				shipModule.starmapStealthDetectionLevelMax = 5;
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.powerConsumed = 10;
				shipModule_maxHealth = 30;
				break;
				case 171954197: //sensor 9 sunpanel new s2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.3f);
				shipModule.displayName = "Multi-Phased <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Has multitude of integrated mechanisms, which observe time and space at different phases that in confluence allow easy detection of any objects at immense distances.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 2500f, metals = 4500f, synthetics = 3500f, exotics = 25f };
				shipModule.Sensor.sectorRadarRange = 500;
				shipModule.Sensor.starmapRadarRange = 50;
				shipModule.starmapStealthDetectionLevelMax = 5;
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.powerConsumed = 10;
				shipModule_maxHealth = 35;
				break;
				case 168562189: //long range sensor 2 old tutorial
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Damaged <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "This sensor array has been though a lot. Amount of impacts and damage it received isn't any less then hull of any long serving border patrol battleship.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, synthetics = 250f };
				shipModule.Sensor.sectorRadarRange = 150;
				shipModule.Sensor.starmapRadarRange = 15;
				shipModule.starmapStealthDetectionLevelMax = 1;
				shipModule.shipAccuracyPercentAdd = 1;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 5;
				break;
				default:
				Debug.LogWarning($"[NEW SENSOR] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(SENSOR) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
