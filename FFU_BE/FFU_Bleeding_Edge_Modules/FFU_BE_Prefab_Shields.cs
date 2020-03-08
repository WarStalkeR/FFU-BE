using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Shields {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("shield 1 diy")) return idx; idx++;
			if (moduleName.Contains("shield 1 round old")) return idx; idx++;
			if (moduleName.Contains("shield 2 manualrats")) return idx; idx++;
			if (moduleName.Contains("shield 2 round")) return idx; idx++;
			if (moduleName.Contains("shield 2 small,single")) return idx; idx++;
			if (moduleName.Contains("shield 3 brass, single")) return idx; idx++;
			if (moduleName.Contains("shield 3 threespace")) return idx; idx++;
			if (moduleName.Contains("shield 4 greendome")) return idx; idx++;
			if (moduleName.Contains("shield 5 spideraa")) return idx; idx++;
			if (moduleName.Contains("shield 4 solitary")) return idx; idx++;
			if (moduleName.Contains("shield tigership")) return idx; idx++;
			if (moduleName.Contains("shieldbat 0 diy")) return idx; idx++;
			if (moduleName.Contains("shieldbat 1 diy")) return idx; idx++;
			if (moduleName.Contains("shieldbat 1.5 rats diy")) return idx; idx++;
			if (moduleName.Contains("shieldbat 2 rats")) return idx; idx++;
			if (moduleName.Contains("shieldbat 2 terran")) return idx; idx++;
			if (moduleName.Contains("shieldbat 4 alien fragile")) return idx; idx++;
			if (moduleName.Contains("shieldbat 3 gmo biotech")) return idx; idx++;
			if (moduleName.Contains("shieldbat 4 EB")) return idx; idx++;
			if (moduleName.Contains("shieldbat 5 floral")) return idx; idx++;
			if (moduleName.Contains("shieldbat 3 generic alien")) return idx; idx++;
			if (moduleName.Contains("shieldbat tiger")) return idx; idx++;
			return 999;
		}
		public static void UpdateShieldModule(ShipModule shipModule, bool initItemData) {
			string colorShieldGen = "4d79ff";
			string colorShieldCap = "4da6ff";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "shield 1 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.1f);
				shipModule.displayName = "Makeshift <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that was created from high-tech scrap and unstable power cores. Weak, unstable, power-hungry with low recharge speed, but better then nothing.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 150f, synthetics = 250f, exotics = 1f };
				shipModule.ShieldGen.reloadInterval = 6f;
				shipModule.ShieldGen.maxShieldAdd = 10;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 1;
				shipModule_maxHealth = 25;
				break;
				case "shield 1 round old":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.05f);
				shipModule.displayName = "Ancient <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "A couple centuries old shield generator that been through every battle imaginable. Looks battered and unstable, but still properly works if powered on.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 250f, synthetics = 350f, exotics = 2f };
				shipModule.ShieldGen.reloadInterval = 5.5f;
				shipModule.ShieldGen.maxShieldAdd = 13;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 1;
				shipModule_maxHealth = 27;
				break;
				case "shield 2 manualrats":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Imperial <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator of questionable quality manufactured by the Rat Empire. Its only merit that it works without breaking down and has very low maintenance requirements.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 400f, synthetics = 600f, exotics = 3f };
				shipModule.ShieldGen.reloadInterval = 5f;
				shipModule.ShieldGen.maxShieldAdd = 16;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 30;
				break;
				case "shield 2 round":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.95f);
				shipModule.displayName = "Modern <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Freshly designed and manufactured shield generator that yet show signs of wear. Mostly used on civilian vessels due to the ease of acquisition and decent quality.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 750f, synthetics = 1250f, exotics = 4f };
				shipModule.ShieldGen.reloadInterval = 4.5f;
				shipModule.ShieldGen.maxShieldAdd = 19;
				shipModule.powerConsumed = 7;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 34;
				break;
				case "shield 2 small,single":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = "Fission <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that uses fission energy directly without any conversion to generate and maintain protective field around the ship. Has decent stability.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 450f, metals = 1000f, synthetics = 1500f, exotics = 5f };
				shipModule.ShieldGen.reloadInterval = 4f;
				shipModule.ShieldGen.maxShieldAdd = 22;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 38;
				break;
				case "shield 3 brass, single":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.85f);
				shipModule.displayName = "Aegis <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that uses aegis projection method and formula to generate protective field. Has good stability, but manufactured on per-request basis.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, metals = 1250f, synthetics = 2250f, exotics = 7f };
				shipModule.ShieldGen.reloadInterval = 3.5f;
				shipModule.ShieldGen.maxShieldAdd = 25;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 42;
				break;
				case "shield 3 threespace":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Fusion <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that uses even more volatile fusion energy to generate and maintain protective barrier. Loss of stability due to damage leads to critical consequences.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 800f, metals = 1750f, synthetics = 2750f, exotics = 10f };
				shipModule.ShieldGen.reloadInterval = 3f;
				shipModule.ShieldGen.maxShieldAdd = 28;
				shipModule.powerConsumed = 10;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 46;
				break;
				case "shield 4 greendome":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.75f);
				shipModule.displayName = "Antimatter <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that uses unstable antimatter directly to create and maintain shields. As long as integrity isn't breached, spaceship won't turn into beautiful fireworks.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2500f, synthetics = 3500f, exotics = 15f };
				shipModule.ShieldGen.reloadInterval = 2.5f;
				shipModule.ShieldGen.maxShieldAdd = 32;
				shipModule.powerConsumed = 11;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 50;
				break;
				case "shield 5 spideraa":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.7f);
				shipModule.displayName = "Repulsor <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that uses kinetic energy and unknown principles to generate and maintain strong barrier around ship. Stable and almost perfectly integrity-wise fail-safe.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 3250f, synthetics = 4250f, exotics = 20f };
				shipModule.ShieldGen.reloadInterval = 2f;
				shipModule.ShieldGen.maxShieldAdd = 36;
				shipModule.powerConsumed = 13;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 55;
				break;
				case "shield 4 solitary":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.65f);
				shipModule.displayName = "Void-Wave <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that manipulates sub-dimensional energies to generate and maintain extremely strong protective barrier around ship. Not to be confused with Gellar field.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 4000f, synthetics = 5000f, exotics = 25f };
				shipModule.ShieldGen.reloadInterval = 1.5f;
				shipModule.ShieldGen.maxShieldAdd = 40;
				shipModule.powerConsumed = 14;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 60;
				break;
				case "shield tigership":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Zero Point <color=#" + colorShieldGen + "ff>Shield Generator</color>";
				shipModule.description = "Shield generator that indefinitely harnesses energy from quantum fluctuation at zero point state in order to generate and maintain experimental protective field around ship.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 2000f, metals = 6000f, synthetics = 8000f, exotics = 35f };
				shipModule.ShieldGen.reloadInterval = 1f;
				shipModule.ShieldGen.maxShieldAdd = 50;
				shipModule.powerConsumed = 15;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 75;
				break;
				case "shieldbat 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Makeshift <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that was created from high-tech scrap and expired power capacitors. Weak, unstable and power-hungry, but still better then nothing.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 75f, synthetics = 125f, exotics = 1f };
				shipModule.ShieldGen.maxShieldAdd = 30;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 1;
				shipModule_maxHealth = 10;
				break;
				case "shieldbat 1 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.75f);
				shipModule.displayName = "Salvaged <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that made from salvageable parts of other expired shield capacitors. Has questionable quality and stability, but still good alternative to makeshift variant.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 125f, synthetics = 175f, exotics = 2f };
				shipModule.ShieldGen.maxShieldAdd = 39;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 1;
				shipModule_maxHealth = 13;
				break;
				case "shieldbat 1.5 rats diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.7f);
				shipModule.displayName = "Fission <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that uses fission energy directly without any conversion to strengthen already existing protective field around the ship. Has decent stability.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 200f, synthetics = 300f, exotics = 3f };
				shipModule.ShieldGen.maxShieldAdd = 48;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 16;
				break;
				case "shieldbat 2 rats":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.65f);
				shipModule.displayName = "Imperial <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "This shield capacitor is a rare case of Rat Empire technological genius, when original stolen technology was surpassed by technology derived from it.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 375f, synthetics = 625f, exotics = 4f };
				shipModule.ShieldGen.maxShieldAdd = 57;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 19;
				break;
				case "shieldbat 2 terran":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Fusion <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that uses even more volatile fusion energy to strengthen already existing protective barrier. If damaged, it might lead to critical consequences.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 225f, metals = 500f, synthetics = 750f, exotics = 5f };
				shipModule.ShieldGen.maxShieldAdd = 66;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 22;
				break;
				case "shieldbat 4 alien fragile":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.55f);
				shipModule.displayName = "Exotic <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that uses matrix of interconnected exotic elements to strengthen already existing protective barrier. Very optimized, stable and fail-safe.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 625f, synthetics = 1125f, exotics = 6f };
				shipModule.ShieldGen.maxShieldAdd = 75;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 25;
				break;
				case "shieldbat 3 gmo biotech":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = "Antimatter <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that uses unstable antimatter directly to strengthen already existing shields. If heavily damaged, might turn spaceship into beautiful fireworks.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 875f, synthetics = 1375f, exotics = 7f };
				shipModule.ShieldGen.maxShieldAdd = 84;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 28;
				break;
				case "shieldbat 4 EB":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.45f);
				shipModule.displayName = "Commercial <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that was developed for sake of profit and sold to anybody who can afford it. Private manufacturing will lead to breach of copyright agreement and lawsuit.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1250f, synthetics = 1750f, exotics = 8f };
				shipModule.ShieldGen.maxShieldAdd = 96;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 32;
				break;
				case "shieldbat 5 floral":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = "Bionic <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor of organic origin that uses pure environmental energies to strengthen already existing shields. Energy efficient, stable, fail-safe and will not spawn creep.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 625f, metals = 1125f, synthetics = 1625f, exotics = 10f, organics = 1000f };
				shipModule.ShieldGen.maxShieldAdd = 108;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 36;
				break;
				case "shieldbat 3 generic alien":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.35f);
				shipModule.displayName = "Void-Wave <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that manipulates sub-dimensional energies to strengthen already existing extremely strong protective barrier around ship. Has nothing to do with immaterium.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 2000f, synthetics = 2500f, exotics = 15f };
				shipModule.ShieldGen.maxShieldAdd = 120;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 40;
				break;
				case "shieldbat tiger":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.3f);
				shipModule.displayName = "Zero Point <color=#" + colorShieldCap + "ff>Shield Capacitor</color>";
				shipModule.description = "Shield capacitor that indefinitely harnesses energy from quantum fluctuation at zero point state in order to strengthen already existing experimental protective field around ship.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 3000f, synthetics = 4000f, exotics = 20f };
				shipModule.ShieldGen.maxShieldAdd = 150;
				shipModule.powerConsumed = 10;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 50;
				break;
				case "shield decoy 1":
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.1f);
				shipModule.displayName = "Decoy Shield Generator";
				shipModule.description = "A highly armored shield capacitor with low capacity that somewhat strengthens ships integrity and already existing shields. Appears as shield generator to the enemy sensors.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 1000f };
				shipModule.ShieldGen.maxShieldAdd = 5;
				shipModule.powerConsumed = 0;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 100;
				break;
				default:
				Debug.LogWarning($"[NEW SHIELD] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(SHIELD) " + shipModule.displayName;
				break;
			}
			shipModule.ShieldGen.maxShieldAdd = Mathf.RoundToInt(shipModule.ShieldGen.maxShieldAdd * FFU_BE_Defs.shieldBonusMult);
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
