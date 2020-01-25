﻿using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Sensors {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("sensor 0-C diy")) return idx; idx++;
			if (moduleName.Contains("sensor 1-L DIY")) return idx; idx++;
			if (moduleName.Contains("sensor 2 saucer old")) return idx; idx++;
			if (moduleName.Contains("sensor 3 L terran simple")) return idx; idx++;
			if (moduleName.Contains("sensor 3 planty")) return idx; idx++;
			if (moduleName.Contains("sensor 4 saucer new")) return idx; idx++;
			if (moduleName.Contains("sensor 5 EB saucer s1")) return idx; idx++;
			if (moduleName.Contains("sensor 8 sunpanel old s1")) return idx; idx++;
			if (moduleName.Contains("sensor 5 futu saucer s1")) return idx; idx++;
			if (moduleName.Contains("sensor 10 terran s2")) return idx; idx++;
			if (moduleName.Contains("sensor 11 blue adv s2")) return idx; idx++;
			if (moduleName.Contains("sensor 11 sophisiticated s2")) return idx; idx++;
			if (moduleName.Contains("sensor 12 spideraa")) return idx; idx++;
			if (moduleName.Contains("sensor 11 seashell s2")) return idx; idx++;
			if (moduleName.Contains("sensor 9 sunpanel new s2")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("sensor 0-C diy");
				moduleList.Add("sensor 1-L DIY");
				moduleList.Add("sensor 2 saucer old");
				return moduleList;
				case 2:
				moduleList.Add("sensor 1-L DIY");
				moduleList.Add("sensor 2 saucer old");
				moduleList.Add("sensor 3 L terran simple");
				return moduleList;
				case 3:
				moduleList.Add("sensor 3 L terran simple");
				moduleList.Add("sensor 3 planty");
				moduleList.Add("sensor 4 saucer new");
				return moduleList;
				case 4:
				moduleList.Add("sensor 4 saucer new");
				moduleList.Add("sensor 5 EB saucer s1");
				moduleList.Add("sensor 8 sunpanel old s1");
				return moduleList;
				case 5:
				moduleList.Add("sensor 8 sunpanel old s1");
				moduleList.Add("sensor 5 futu saucer s1");
				moduleList.Add("sensor 10 terran s2");
				return moduleList;
				case 6:
				moduleList.Add("sensor 10 terran s2");
				moduleList.Add("sensor 11 blue adv s2");
				moduleList.Add("sensor 11 sophisiticated s2");
				return moduleList;
				case 7:
				moduleList.Add("sensor 11 sophisiticated s2");
				moduleList.Add("sensor 12 spideraa");
				moduleList.Add("sensor 11 seashell s2");
				return moduleList;
				case 8:
				moduleList.Add("sensor 11 sophisiticated s2");
				moduleList.Add("sensor 12 spideraa");
				moduleList.Add("sensor 11 seashell s2");
				moduleList.Add("sensor 9 sunpanel new s2");
				return moduleList;
				case 9:
				moduleList.Add("sensor 12 spideraa");
				moduleList.Add("sensor 11 seashell s2");
				moduleList.Add("sensor 9 sunpanel new s2");
				return moduleList;
				case 10:
				moduleList.Add("sensor 11 seashell s2");
				moduleList.Add("sensor 9 sunpanel new s2");
				return moduleList;
				default:
				moduleList.Add("sensor 0-C diy");
				moduleList.Add("sensor 1-L DIY");
				moduleList.Add("sensor 2 saucer old");
				moduleList.Add("sensor 3 L terran simple");
				moduleList.Add("sensor 3 planty");
				moduleList.Add("sensor 4 saucer new");
				moduleList.Add("sensor 5 EB saucer s1");
				moduleList.Add("sensor 8 sunpanel old s1");
				moduleList.Add("sensor 5 futu saucer s1");
				moduleList.Add("sensor 10 terran s2");
				moduleList.Add("sensor 11 blue adv s2");
				moduleList.Add("sensor 11 sophisiticated s2");
				moduleList.Add("sensor 12 spideraa");
				moduleList.Add("sensor 11 seashell s2");
				moduleList.Add("sensor 9 sunpanel new s2");
				return moduleList;
			}
		}
		public static void UpdateSensorModule(ShipModule shipModule) {
			string colorSensor = "4dff79";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "sensor 0-C diy":
				shipModule.displayName = "Makeshift <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Literally made form scraps and printed metal plates. Provides only very limited navigation capabilities, but still better then going blind.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 100f, synthetics = 75f };
				shipModule.Sensor.sectorRadarRange = 80;
				shipModule.Sensor.starmapRadarRange = 8;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 5;
				break;
				case "sensor 1-L DIY":
				shipModule.displayName = "Salvaged <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Made from salvaged parts of expired or broken down sensory arrays. Navigation capabilities are little bit better, but still very limited.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 150f, synthetics = 125f };
				shipModule.Sensor.sectorRadarRange = 100;
				shipModule.Sensor.starmapRadarRange = 10;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 6;
				break;
				case "sensor 2 saucer old":
				shipModule.displayName = "Ancient <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "A couple centuries old sensor array that been though every imaginable situation possible. Still in workable condition and provides basic navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 250f, synthetics = 175f };
				shipModule.Sensor.sectorRadarRange = 120;
				shipModule.Sensor.starmapRadarRange = 12;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 7;
				break;
				case "sensor 3 L terran simple":
				shipModule.displayName = "Civilian <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Installed on most civilian vessels due to low purchase barrier and cheap maintenance costs. Provides somewhat decent navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 175f, metals = 400f, synthetics = 250f };
				shipModule.Sensor.sectorRadarRange = 140;
				shipModule.Sensor.starmapRadarRange = 14;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 8;
				break;
				case "sensor 3 planty":
				shipModule.displayName = "Bionic <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Sensor array of organic origin. Grown artificially in special environment, but contains all necessary ports for proper interfacing with spaceship's systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, organics = 600f, synthetics = 400f };
				shipModule.Sensor.sectorRadarRange = 160;
				shipModule.Sensor.starmapRadarRange = 16;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 9;
				break;
				case "sensor 4 saucer new":
				shipModule.displayName = "Modern <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Freshly manufactured and mass produced sensor array. Mostly installed on more serious vessels. Provides decent navigation and detection capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 750f, synthetics = 500f };
				shipModule.Sensor.sectorRadarRange = 180;
				shipModule.Sensor.starmapRadarRange = 18;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 10;
				break;
				case "sensor 5 EB saucer s1":
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
				case "sensor 8 sunpanel old s1":
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
				case "sensor 5 futu saucer s1":
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
				case "sensor 10 terran s2":
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
				case "sensor 11 blue adv s2":
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
				case "sensor 11 sophisiticated s2":
				shipModule.displayName = "Multi-Spectrum <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Uses multi-spectrum mirrors array to discover and lock on targets or coordinates at great distances. Has great navigation, detection and targeting capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 2750f, synthetics = 1750f, exotics = 7f };
				shipModule.Sensor.sectorRadarRange = 360;
				shipModule.Sensor.starmapRadarRange = 36;
				shipModule.starmapStealthDetectionLevelMax = 3;
				shipModule.shipAccuracyPercentAdd = 12;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 20;
				break;
				case "sensor 12 spideraa":
				shipModule.displayName = "Repulsor <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Uses kinetic energy and unknown principles to send low-amplitude kinetic waves in a sonar-like way to discovered and lock on to targets at great distances.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 3000f, synthetics = 2500f, exotics = 10f };
				shipModule.Sensor.sectorRadarRange = 400;
				shipModule.Sensor.starmapRadarRange = 40;
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 14;
				shipModule.powerConsumed = 9;
				shipModule_maxHealth = 23;
				break;
				case "sensor 11 seashell s2":
				shipModule.displayName = "Subspace <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Has built-in working subspace radio modulator that emits subspace waves that allow to detected objects at great distances. Almost perfect navigation capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 3500f, synthetics = 2750f, exotics = 15f };
				shipModule.Sensor.sectorRadarRange = 450;
				shipModule.Sensor.starmapRadarRange = 45;
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 17;
				shipModule.powerConsumed = 9;
				shipModule_maxHealth = 26;
				break;
				case "sensor 9 sunpanel new s2":
				shipModule.displayName = "Multi-Phased <color=#" + colorSensor + "ff>Sensor Array</color>";
				shipModule.description = "Has multitude of integrated mechanisms, which observe time and space at different phases that in confluence allow easy detection of any objects at immense distances.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 2000f, metals = 4000f, synthetics = 3000f, exotics = 20f };
				shipModule.Sensor.sectorRadarRange = 500;
				shipModule.Sensor.starmapRadarRange = 50;
				shipModule.starmapStealthDetectionLevelMax = 5;
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.powerConsumed = 10;
				shipModule_maxHealth = 30;
				break;
				case "long range sensor 2 old (tutorial, not saveable)":
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
				default: shipModule.displayName = "(SENSOR) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}