using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_PointDefences {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 893617597) return idx; idx++; //0 DIY PD
			if (moduleID == 687853920) return idx; idx++; //1 Rat PD
			if (moduleID == 106454213) return idx; idx++; //3 Rat PD 2
			if (moduleID == 804479599) return idx; idx++; //6 Squid PD
			if (moduleID == 583909453) return idx; idx++; //4 Insectoid PD
			if (moduleID == 1468502746) return idx; idx++; //5 Human PD
			if (moduleID == 1381757148) return idx; idx++; //7 Red PD
			if (moduleID == 507685108) return idx; idx++; //8 Chunk PD
			if (moduleID == 1230723452) return idx; idx++; //10 laser PD
			if (moduleID == 1495856276) return idx; idx++; //8 Crystal PD
			if (moduleID == 938711464) return idx; idx++; //2 Tiger PD
			return idx + 100;
		}
		public static void UpdatePointDefModule(ShipModule shipModule, bool initItemData) {
			string colorPointDef = "ffa64d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 893617597: //0 DIY PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = "Makeshift <color=#" + colorPointDef + "ff>Standard CIWS</color>";
				shipModule.description = "Improvised close-in weapon system that made from spare weapon. Can intercept missiles, projectiles, asteroids and boarding pods at low range. Has very long reload time.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 250f, synthetics = 150f };
				shipModule.PointDefence.coverRadius = 10.0f;
				shipModule.PointDefence.reloadInterval = 2.0f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = 5;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 15;
				break;
				case 687853920: //1 Rat PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = "Ancient <color=#" + colorPointDef + "ff>Standard CIWS</color>";
				shipModule.description = "Decommissioned close-in weapon system that was manufactured centuries ago. Can intercept missiles, projectiles, asteroids and boarding pods at low range with mediocre rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 350f, synthetics = 250f };
				shipModule.PointDefence.coverRadius = 12.0f;
				shipModule.PointDefence.reloadInterval = 1.9f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = FFU_BE_Defs.flagDLC_OldEnm ? 8 : 10;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 20;
				break;
				case 106454213: //3 Rat PD 2
				if (initItemData) {
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4);
					else FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5); }
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = "Imperial <color=#" + colorPointDef + "ff>Standard CIWS</color>";
				shipModule.description = "Close-in weapon system that was developed by Rat Empire. Can intercept missiles, projectiles, asteroids and boarding pods at mediocre, but still lacking as point defense.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, synthetics = 350f };
				shipModule.PointDefence.coverRadius = 13.0f;
				shipModule.PointDefence.reloadInterval = 1.8f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = FFU_BE_Defs.flagDLC_OldEnm ? 10 : 12;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 25;
				break;
				case 804479599: //6 Squid PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Biochemical <color=#" + colorPointDef + "ff>Advanced CIWS</color>";
				shipModule.description = "Organic close-in weapon system that was grown in special environment. Can intercept missiles, projectiles, asteroids and boarding pods at moderate range with decent rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, organics = 750f, synthetics = 500f, exotics = 1f };
				shipModule.PointDefence.coverRadius = 14.0f;
				shipModule.PointDefence.reloadInterval = 1.65f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 2;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = FFU_BE_Defs.flagDLC_OldEnm ? 12 : 15;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 30;
				break;
				case 583909453: //4 Insectoid PD
				if (initItemData) {
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6);
					else FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7); }
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Marauder <color=#" + colorPointDef + "ff>Advanced CIWS</color>";
				shipModule.description = "Close-in weapon system that is used by various unlawful organizations. Can intercept missiles, projectiles, asteroids and boarding pods at decent range with good rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1000f, synthetics = 750f, exotics = 3f };
				shipModule.PointDefence.coverRadius = 16.0f;
				shipModule.PointDefence.reloadInterval = 1.5f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 2;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = FFU_BE_Defs.flagDLC_OldEnm ? 15 : 18;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 35;
				break;
				case 1468502746: //5 Human PD
				if (initItemData) {
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
					else FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8); }
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, FFU_BE_Defs.flagDLC_OldEnm ? 1.8f : 1.6f);
				shipModule.displayName = "Phalanx <color=#" + colorPointDef + "ff>Advanced CIWS</color>";
				shipModule.description = "Military issued close-in weapon system for ships at intensive conflict zones. Can intercept missiles, projectiles, asteroids and boarding pods at good range with great rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 1500f, synthetics = 1000f, exotics = 5f };
				shipModule.PointDefence.coverRadius = 18.0f;
				shipModule.PointDefence.reloadInterval = FFU_BE_Defs.flagDLC_OldEnm ? 1.4f : 1.35f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = FFU_BE_Defs.flagDLC_OldEnm ? 3 : 2;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = FFU_BE_Defs.flagDLC_OldEnm ? 18 : 21;
				shipModule.powerConsumed = FFU_BE_Defs.flagDLC_OldEnm ? 3 : 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 40;
				break;
				case 1381757148: //7 Red PD
				if (initItemData) {
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
					else FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9); }
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Commercial <color=#" + colorPointDef + "ff>Tactical CIWS</color>";
				shipModule.description = "A close-in weapon system that was developed for sake of profit and is sold to anybody who can afford it. Can intercept incoming targets at good range with high rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2000f, synthetics = 1500f, exotics = 7f };
				shipModule.PointDefence.coverRadius = FFU_BE_Defs.flagDLC_OldEnm ? 20.0f : 21.0f;
				shipModule.PointDefence.reloadInterval = FFU_BE_Defs.flagDLC_OldEnm ? 1.3f : 1.2f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 3;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = FFU_BE_Defs.flagDLC_OldEnm ? 0.2f : 0.1f;
				shipModule.asteroidDeflectionPercentAdd = FFU_BE_Defs.flagDLC_OldEnm ? 21 : 25;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 45;
				break;
				case 507685108: //8 Chunk PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8, 9);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Zweihander <color=#" + colorPointDef + "ff>Tactical CIWS</color>";
				shipModule.description = "Heavily armored close-in weapon system that is mainly used heavily armored ships such as assault cruisers. Can intercept incoming targets at great range with very high rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 2250f, synthetics = 1750f, exotics = 10f };
				shipModule.PointDefence.coverRadius = 22.0f;
				shipModule.PointDefence.reloadInterval = 1.2f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 4;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 23;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 75;
				break;
				case 1230723452: //10 laser PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Parallax <color=#" + colorPointDef + "ff>Tactical CIWS</color>";
				shipModule.description = "Advanced close-in weapon system filled to the brim with advanced tracking and targeting modules. Can intercept incoming targets at extreme range with very high rate.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 2500f, synthetics = 2000f, exotics = 13f };
				shipModule.PointDefence.coverRadius = 24.0f;
				shipModule.PointDefence.reloadInterval = 1.1f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 4;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 27;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 45;
				break;
				case 1495856276: //8 Crystal PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.2f);
				shipModule.displayName = "Prismatic <color=#" + colorPointDef + "ff>Tactical CIWS</color>";
				shipModule.description = "Semi-organic close-in weapon system that is mainly made from exotic interconnected crystalline cells. Can intercept incoming targets at good range with excellent rate.";
				shipModule.craftCost = new ResourceValueGroup { organics = 2000f, fuel = 2000f, metals = 1000f, synthetics = 2500f, exotics = 16f };
				shipModule.PointDefence.coverRadius = 20.0f;
				shipModule.PointDefence.reloadInterval = 1.5f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 5;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 20;
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 35;
				break;
				case 938711464: //2 Tiger PD
				if (initItemData) {
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 9, 10);
					else FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10); }
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, FFU_BE_Defs.flagDLC_OldEnm ? 2.2f : 1.8f);
				shipModule.displayName = "Iron Dome <color=#" + colorPointDef + "ff>Tactical CIWS</color>";
				shipModule.description = "Best close-in weapon system that used on ships participating in most dangerous expeditions. Can perfectly intercept missiles, projectiles, asteroids and boarding pods.";
				if (FFU_BE_Defs.flagDLC_OldEnm) shipModule.craftCost = new ResourceValueGroup { fuel = 2500f, metals = 3500f, synthetics = 3000f, exotics = 20f };
				else shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 2750f, synthetics = 2250f, exotics = 10f };
				shipModule.PointDefence.coverRadius = 25.0f;
				shipModule.PointDefence.reloadInterval = 1.0f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = FFU_BE_Defs.flagDLC_OldEnm ? 5 : 3;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 30;
				shipModule.powerConsumed = FFU_BE_Defs.flagDLC_OldEnm ? 5 : 3;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 50;
				break;
				default:
				Debug.LogWarning($"[NEW DEFENSE] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(DEFENSE) " + shipModule.displayName;
				break;
			}
			shipModule.craftCost.organics *= 2;
			shipModule.craftCost.metals *= 2;
			shipModule.craftCost.synthetics *= 2;
			shipModule.craftCost.explosives *= 2;
			shipModule.craftCost.exotics *= 2;
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
