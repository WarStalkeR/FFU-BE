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
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorPointDef}ff>Standard CIWS</color>");
				shipModule.description = Core.TT($"Improvised close-in weapon system that made from spare weapon. Can intercept missiles, projectiles, asteroids and boarding pods at low range. Has very long reload time.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 500f, synthetics = 300f };
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
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = Core.TT($"Ancient <color=#{colorPointDef}ff>Standard CIWS</color>");
				shipModule.description = Core.TT($"Decommissioned close-in weapon system that was manufactured centuries ago. Can intercept missiles, projectiles, asteroids and boarding pods at low range with mediocre rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 700f, synthetics = 500f };
				shipModule.PointDefence.coverRadius = 12.0f;
				shipModule.PointDefence.reloadInterval = 1.9f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = ProcessDLC.GetAsteroidDeflection(shipModule.PrefabId);
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 20;
				break;
				case 106454213: //3 Rat PD 2
				if (initItemData) ProcessDLC.ApplySectorViablility(shipModule.PrefabId);
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = Core.TT($"Imperial <color=#{colorPointDef}ff>Standard CIWS</color>");
				shipModule.description = Core.TT($"Close-in weapon system that was developed by Rat Empire. Can intercept missiles, projectiles, asteroids and boarding pods at mediocre, but still lacking as point defense.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 700f };
				shipModule.PointDefence.coverRadius = 13.0f;
				shipModule.PointDefence.reloadInterval = 1.8f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 1;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.3f;
				shipModule.asteroidDeflectionPercentAdd = ProcessDLC.GetAsteroidDeflection(shipModule.PrefabId);
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 25;
				break;
				case 804479599: //6 Squid PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = Core.TT($"Biochemical <color=#{colorPointDef}ff>Advanced CIWS</color>");
				shipModule.description = Core.TT($"Organic close-in weapon system that was grown in special environment. Can intercept missiles, projectiles, asteroids and boarding pods at moderate range with decent rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, organics = 1500f, synthetics = 1000f, exotics = 2f };
				shipModule.PointDefence.coverRadius = 14.0f;
				shipModule.PointDefence.reloadInterval = 1.65f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 2;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = ProcessDLC.GetAsteroidDeflection(shipModule.PrefabId);
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 30;
				break;
				case 583909453: //4 Insectoid PD
				if (initItemData) ProcessDLC.ApplySectorViablility(shipModule.PrefabId);
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = Core.TT($"Marauder <color=#{colorPointDef}ff>Advanced CIWS</color>");
				shipModule.description = Core.TT($"Close-in weapon system that is used by various unlawful organizations. Can intercept missiles, projectiles, asteroids and boarding pods at decent range with good rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 6f };
				shipModule.PointDefence.coverRadius = 16.0f;
				shipModule.PointDefence.reloadInterval = 1.5f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 2;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = ProcessDLC.GetAsteroidDeflection(shipModule.PrefabId);
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 35;
				break;
				case 1468502746: //5 Human PD
				if (initItemData) ProcessDLC.ApplySectorViablility(shipModule.PrefabId);
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, ProcessDLC.GetEmission(shipModule.PrefabId));
				shipModule.displayName = Core.TT($"Phalanx <color=#{colorPointDef}ff>Advanced CIWS</color>");
				shipModule.description = Core.TT($"Military issued close-in weapon system for ships at intensive conflict zones. Can intercept missiles, projectiles, asteroids and boarding pods at good range with great rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 3000f, synthetics = 2000f, exotics = 10f };
				shipModule.PointDefence.coverRadius = 18.0f;
				shipModule.PointDefence.reloadInterval = ProcessDLC.GetReloadInterval(shipModule.PrefabId);
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = ProcessDLC.GetProjectileDamage(shipModule.PrefabId);
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.2f;
				shipModule.asteroidDeflectionPercentAdd = ProcessDLC.GetAsteroidDeflection(shipModule.PrefabId);
				shipModule.powerConsumed = ProcessDLC.GetPowerConsumption(shipModule.PrefabId);
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 40;
				break;
				case 1381757148: //7 Red PD
				if (initItemData) ProcessDLC.ApplySectorViablility(shipModule.PrefabId);
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = Core.TT($"Commercial <color=#{colorPointDef}ff>Tactical CIWS</color>");
				shipModule.description = Core.TT($"A close-in weapon system that was developed for sake of profit and is sold to anybody who can afford it. Can intercept incoming targets at good range with high rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 4000f, synthetics = 3000f, exotics = 14f };
				shipModule.PointDefence.coverRadius = ProcessDLC.GetCoverRadius(shipModule.PrefabId);
				shipModule.PointDefence.reloadInterval = ProcessDLC.GetReloadInterval(shipModule.PrefabId);
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 3;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = ProcessDLC.GetProjectileLifetime(shipModule.PrefabId);
				shipModule.asteroidDeflectionPercentAdd = ProcessDLC.GetAsteroidDeflection(shipModule.PrefabId);
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 45;
				break;
				case 507685108: //8 Chunk PD
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8, 9);
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = Core.TT($"Zweihander <color=#{colorPointDef}ff>Tactical CIWS</color>");
				shipModule.description = Core.TT($"Heavily armored close-in weapon system that is mainly used heavily armored ships such as assault cruisers. Can intercept incoming targets at great range with very high rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 4500f, synthetics = 3500f, exotics = 20f };
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
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = Core.TT($"Parallax <color=#{colorPointDef}ff>Tactical CIWS</color>");
				shipModule.description = Core.TT($"Advanced close-in weapon system filled to the brim with advanced tracking and targeting modules. Can intercept incoming targets at extreme range with very high rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 5000f, synthetics = 4000f, exotics = 26f };
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
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.2f);
				shipModule.displayName = Core.TT($"Prismatic <color=#{colorPointDef}ff>Tactical CIWS</color>");
				shipModule.description = Core.TT($"Semi-organic close-in weapon system that is mainly made from exotic interconnected crystalline cells. Can intercept incoming targets at good range with excellent rate.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 2000f, organics = 4000f, metals = 2000f, synthetics = 5000f, exotics = 32f };
				shipModule.PointDefence.coverRadius = 20.0f;
				shipModule.PointDefence.reloadInterval = 1.5f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = 5;
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 20;
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 35;
				break;
				case 938711464: //2 Tiger PD
				if (initItemData) ProcessDLC.ApplySectorViablility(shipModule.PrefabId);
				if (!FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Contains(shipModule.PrefabId)) FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.CIWS].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, ProcessDLC.GetEmission(shipModule.PrefabId));
				shipModule.displayName = Core.TT($"Iron Dome <color=#{colorPointDef}ff>Tactical CIWS</color>");
				shipModule.description = Core.TT($"Best close-in weapon system that used on ships participating in most dangerous expeditions. Can perfectly intercept missiles, projectiles, asteroids and boarding pods.");
				shipModule.craftCost = ProcessDLC.GetCraftingCost(shipModule.PrefabId);
				shipModule.PointDefence.coverRadius = 25.0f;
				shipModule.PointDefence.reloadInterval = 1.0f;
				shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg = ProcessDLC.GetProjectileDamage(shipModule.PrefabId);
				shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime = 0.1f;
				shipModule.asteroidDeflectionPercentAdd = 30;
				shipModule.powerConsumed = ProcessDLC.GetPowerConsumption(shipModule.PrefabId);
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 50;
				break;
				default:
				Debug.LogWarning($"[NEW DEFENSE] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(DEFENSE) {shipModule.name}";
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
		public class ProcessDLC {
			public static void ApplySectorViablility(int moduleId) {
				switch (moduleId) {
					case 106454213: //3 Rat PD 2
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(moduleId, 3, 4);
					else FFU_BE_Defs.SetViableForSectors(moduleId, 3, 4, 5);
					break;
					case 583909453: //4 Insectoid PD
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(moduleId, 5, 6);
					else FFU_BE_Defs.SetViableForSectors(moduleId, 5, 6, 7);
					break;
					case 1468502746: //5 Human PD
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(moduleId, 5, 6, 7);
					else FFU_BE_Defs.SetViableForSectors(moduleId, 6, 7, 8);
					break;
					case 1381757148: //7 Red PD
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(moduleId, 6, 7, 8);
					else FFU_BE_Defs.SetViableForSectors(moduleId, 7, 8, 9);
					break;
					case 938711464: //2 Tiger PD
					if (FFU_BE_Defs.flagDLC_OldEnm) FFU_BE_Defs.SetViableForSectors(moduleId, 9, 10);
					else FFU_BE_Defs.SetViableForSectors(moduleId, 8, 9, 10);
					break;
				}
			}
			public static ResourceValueGroup GetCraftingCost(int moduleId) {
				switch (moduleId) {
					case 938711464: //2 Tiger PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return new ResourceValueGroup { fuel = 2500f, metals = 7000f, synthetics = 6000f, exotics = 40f };
					else return new ResourceValueGroup { fuel = 1500f, metals = 5500f, synthetics = 4500f, exotics = 20f };
					default: return new ResourceValueGroup { fuel = 1000f, metals = 2000f, synthetics = 2000f, exotics = 20f };
				}
			}
			public static float GetCoverRadius(int moduleId) {
				switch (moduleId) {
					case 1381757148: //7 Red PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 20f;
					else return 21f;
					default: return 10f;
				}
			}
			public static float GetReloadInterval(int moduleId) {
				switch (moduleId) {
					case 1468502746: //5 Human PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 1.4f;
					else return 1.35f;
					case 1381757148: //7 Red PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 1.3f;
					else return 1.2f;
					default: return 2.5f;
				}
			}
			public static int GetProjectileDamage(int moduleId) {
				switch (moduleId) {
					case 1468502746: //5 Human PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 3;
					else return 2;
					case 938711464: //2 Tiger PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 5;
					else return 3;
					default: return 1;
				}
			}
			public static float GetProjectileLifetime(int moduleId) {
				switch (moduleId) {
					case 1381757148: //7 Red PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 0.2f;
					else return 0.1f;
					default: return 0.5f;
				}
			}
			public static int GetAsteroidDeflection(int moduleId) {
				switch (moduleId) {
					case 687853920: //1 Rat PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 8;
					else return 10;
					case 106454213: //3 Rat PD 2
					if (FFU_BE_Defs.flagDLC_OldEnm) return 10;
					else return 12;
					case 804479599: //6 Squid PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 12;
					else return 15;
					case 583909453: //4 Insectoid PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 15;
					else return 18;
					case 1468502746: //5 Human PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 18;
					else return 21;
					case 1381757148: //7 Red PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 21;
					else return 25;
					default: return 5;
				}
			}
			public static int GetPowerConsumption(int moduleId) {
				switch (moduleId) {
					case 1468502746: //5 Human PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 3;
					else return 2;
					case 938711464: //2 Tiger PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 5;
					else return 3;
					default: return 1;
				}
			}
			public static float GetEmission(int moduleId) {
				switch (moduleId) {
					case 1468502746: //5 Human PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 1.8f;
					else return 1.6f;
					case 938711464: //2 Tiger PD
					if (FFU_BE_Defs.flagDLC_OldEnm) return 2.2f;
					else return 1.8f;
					default: return 1f;
				}
			}
		}
	}
}