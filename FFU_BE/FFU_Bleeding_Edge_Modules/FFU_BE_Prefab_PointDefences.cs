﻿using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_PointDefences {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "0 DIY PD") return idx; idx++;
			if (moduleName == "1 Rat PD") return idx; idx++;
			if (moduleName == "3 Rat PD 2") return idx; idx++;
			if (moduleName == "6 Squid PD") return idx; idx++;
			if (moduleName == "4 Insectoid PD") return idx; idx++;
			if (moduleName == "5 Human PD") return idx; idx++;
			if (moduleName == "7 Red PD") return idx; idx++;
			if (moduleName == "2 Tiger PD") return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("0 DIY PD");
				moduleList.Add("1 Rat PD");
				return moduleList;
				case 2:
				moduleList.Add("0 DIY PD");
				moduleList.Add("1 Rat PD");
				moduleList.Add("3 Rat PD 2");
				return moduleList;
				case 3:
				moduleList.Add("1 Rat PD");
				moduleList.Add("3 Rat PD 2");
				return moduleList;
				case 4:
				moduleList.Add("1 Rat PD");
				moduleList.Add("3 Rat PD 2");
				moduleList.Add("6 Squid PD");
				return moduleList;
				case 5:
				moduleList.Add("3 Rat PD 2");
				moduleList.Add("6 Squid PD");
				moduleList.Add("4 Insectoid PD");
				return moduleList;
				case 6:
				moduleList.Add("3 Rat PD 2");
				moduleList.Add("6 Squid PD");
				moduleList.Add("4 Insectoid PD");
				return moduleList;
				case 7:
				moduleList.Add("6 Squid PD");
				moduleList.Add("4 Insectoid PD");
				moduleList.Add("5 Human PD");
				return moduleList;
				case 8:
				moduleList.Add("4 Insectoid PD");
				moduleList.Add("5 Human PD");
				moduleList.Add("7 Red PD");
				return moduleList;
				case 9:
				moduleList.Add("5 Human PD");
				moduleList.Add("7 Red PD");
				moduleList.Add("2 Tiger PD");
				return moduleList;
				case 10:
				moduleList.Add("7 Red PD");
				moduleList.Add("2 Tiger PD");
				return moduleList;
				default:
				moduleList.Add("0 DIY PD");
				moduleList.Add("1 Rat PD");
				moduleList.Add("3 Rat PD 2");
				moduleList.Add("6 Squid PD");
				moduleList.Add("4 Insectoid PD");
				moduleList.Add("5 Human PD");
				moduleList.Add("7 Red PD");
				moduleList.Add("2 Tiger PD");
				return moduleList;
			}
		}
		public static void UpdatePointDefModule(ShipModule shipModule) {
			string colorPointDef = "ffa64d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "0 DIY PD":
				shipModule.displayName = "Makeshift <color=#" + colorPointDef + "ff>Standard CIWS</color>";
				shipModule.description = "Improvised close-in weapon system that made from spare weapon. Can intercept missiles, projectiles, asteroids and boarding pods at low range. Has very long reload time.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 250f, synthetics = 150f };
				shipModule.PointDefence.coverRadius = 10.0f;
				shipModule.PointDefence.reloadInterval = 2.0f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = 5;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 15;
				break;
				case "1 Rat PD":
				shipModule.displayName = "Ancient <color=#" + colorPointDef + "ff>Standard CIWS</color>";
				shipModule.description = "Decommissioned close-in weapon system that was manufactured centuries ago. Can intercept missiles, projectiles, asteroids and boarding pods at low range with mediocre rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 350f, synthetics = 250f };
				shipModule.PointDefence.coverRadius = 12.0f;
				shipModule.PointDefence.reloadInterval = 1.9f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = 10;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 20;
				break;
				case "3 Rat PD 2":
				shipModule.displayName = "Imperial <color=#" + colorPointDef + "ff>Standard CIWS</color>";
				shipModule.description = "Close-in weapon system that was developed by Rat Empire. Can intercept missiles, projectiles, asteroids and boarding pods at mediocre, but still lacking as point defense.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, synthetics = 350f };
				shipModule.PointDefence.coverRadius = 13.0f;
				shipModule.PointDefence.reloadInterval = 1.8f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = 12;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 25;
				break;
				case "6 Squid PD":
				shipModule.displayName = "Biochemical <color=#" + colorPointDef + "ff>Advanced CIWS</color>";
				shipModule.description = "Organic close-in weapon system that was grown in special environment. Can intercept missiles, projectiles, asteroids and boarding pods at moderate range with decent rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, organics = 750f, synthetics = 500f, exotics = 1f };
				shipModule.PointDefence.coverRadius = 14.0f;
				shipModule.PointDefence.reloadInterval = 1.65f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 2;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = 15;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 30;
				break;
				case "4 Insectoid PD":
				shipModule.displayName = "Marauder <color=#" + colorPointDef + "ff>Advanced CIWS</color>";
				shipModule.description = "Close-in weapon system that is used by various unlawful organizations. Can intercept missiles, projectiles, asteroids and boarding pods at decent range with good rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1000f, synthetics = 750f, exotics = 3f };
				shipModule.PointDefence.coverRadius = 16.0f;
				shipModule.PointDefence.reloadInterval = 1.5f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 2;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = 18;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 35;
				break;
				case "5 Human PD":
				shipModule.displayName = "Phalanx <color=#" + colorPointDef + "ff>Advanced CIWS</color>";
				shipModule.description = "Military issued close-in weapon system for ships at intensive conflict zones. Can intercept missiles, projectiles, asteroids and boarding pods at good range with great rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 1500f, synthetics = 1000f, exotics = 5f };
				shipModule.PointDefence.coverRadius = 18.0f;
				shipModule.PointDefence.reloadInterval = 1.35f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 2;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = 21;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 40;
				break;
				case "7 Red PD":
				shipModule.displayName = "Commercial <color=#" + colorPointDef + "ff>Tactical CIWS</color>";
				shipModule.description = "A close-in weapon system that was developed for sake of profit and is sold to anybody who can afford it. Can intercept incoming targets at great range with excellent rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2000f, synthetics = 1500f, exotics = 7f };
				shipModule.PointDefence.coverRadius = 21.0f;
				shipModule.PointDefence.reloadInterval = 1.2f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 3;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 25;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 45;
				break;
				case "2 Tiger PD":
				shipModule.displayName = "Iron Dome <color=#" + colorPointDef + "ff>Tactical CIWS</color>";
				shipModule.description = "Best close-in weapon system that used on ships participating in most dangerous expeditions. Can perfectly intercept missiles, projectiles, asteroids and boarding pods.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 2750f, synthetics = 2250f, exotics = 10f };
				shipModule.PointDefence.coverRadius = 25.0f;
				shipModule.PointDefence.reloadInterval = 1.0f;
				shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg = 3;
				shipModule.PointDefence.projectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 30;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 50;
				break;
				default: shipModule.displayName = "(DEFENSE) " + shipModule.displayName; break;
			}
			shipModule.craftCost.organics *= 2;
			shipModule.craftCost.metals *= 2;
			shipModule.craftCost.synthetics *= 2;
			shipModule.craftCost.explosives *= 2;
			shipModule.craftCost.exotics *= 2;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
