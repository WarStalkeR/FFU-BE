using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Decryptors {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("Stealth decryptor 1 diy")) return idx; idx++;
			if (moduleName.Contains("Stealth decryptor 1 ventilator")) return idx; idx++;
			if (moduleName.Contains("Stealth decryptor 1 ivory old")) return idx; idx++;
			if (moduleName.Contains("Stealth decryptor 1 rats")) return idx; idx++;
			if (moduleName.Contains("Stealth decryptor 2 new human tec")) return idx; idx++;
			if (moduleName.Contains("Stealth decryptor 3 bio")) return idx; idx++;
			if (moduleName.Contains("Stealth decryptor 2 biobrain")) return idx; idx++;
			if (moduleName.Contains("Stealth decryptor 3 newest human tec")) return idx; idx++;
			return 999;
		}
		public static void UpdateDecryptorModule(ShipModule shipModule, bool initItemData) {
			string colorTarget = "4dffa6";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "Stealth decryptor 1 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Makeshift <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Made from tech scraps and simple exotic-based processing unit. Works as if it will break down at any moment. Unstable and can be disrupted by simple impact.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 100f, synthetics = 150f, exotics = 1f };
				shipModule.starmapStealthDetectionLevelMax = 1;
				shipModule.shipAccuracyPercentAdd = 5;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 1;
				shipModule_maxHealth = 5;
				break;
				case "Stealth decryptor 1 ventilator":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Civilian <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Manufactured by civilian equipment suppliers. Has improved exotic-based processing unit that can be used for simple dissipation of emitted energy by ship modules.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 150f, synthetics = 250f, exotics = 2f };
				shipModule.starmapStealthDetectionLevelMax = 2;
				shipModule.shipAccuracyPercentAdd = 8;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 7;
				break;
				case "Stealth decryptor 1 ivory old":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Ancient <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Was manufactured and intensively used centuries ago. Houses very advanced, but heavily damaged exotic-based processing unit. Has low performance due to wearied down state.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 250f, synthetics = 500f, exotics = 3f };
				shipModule.starmapStealthDetectionLevelMax = 3;
				shipModule.shipAccuracyPercentAdd = 11;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 10;
				break;
				case "Stealth decryptor 1 rats":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Imperial <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Manufactured in Rat Empire with older stealth generators as template. Uses decent exotic-based processing unit, but due to lack of proper programming has questionable performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 400f, synthetics = 750f, exotics = 4f };
				shipModule.starmapStealthDetectionLevelMax = 3;
				shipModule.shipAccuracyPercentAdd = 15;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 13;
				break;
				case "Stealth decryptor 2 new human tec":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Modern <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Modern and mass produced stealth generator that mostly used in active military units. Uses very advanced exotic-based processing unit and has good operational performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 450f, metals = 650f, synthetics = 1000f, exotics = 5f };
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 15;
				break;
				case "Stealth decryptor 3 bio":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Bionic <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Stealth generator of organic origin. Cloned in special environment and uses organic/exotic-based processing unit for emitted energy dissipation. Has excellent performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, organics = 1000f, synthetics = 1500f, exotics = 7f };
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 25;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 18;
				break;
				case "Stealth decryptor 2 biobrain":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Hybrid <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Stealth generator that houses experimental organic/exotic-based processing unit within hard metallic/synthetic shell for emitted energy dissipation. Has great operational performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 1000f, synthetics = 2000f, organics = 500f, exotics = 10f };
				shipModule.starmapStealthDetectionLevelMax = 5;
				shipModule.shipAccuracyPercentAdd = 30;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 22;
				break;
				case "Stealth decryptor 3 newest human tec":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Phased <color=#" + colorTarget + "ff>Stealth Generator</color>";
				shipModule.description = "Simultaneously processes received data from multiple observation phases with its ultra-advanced exotic-based processing unit to perfectly dissipate energy emitted by the ship.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 1500f, synthetics = 2750f, exotics = 15f };
				shipModule.starmapStealthDetectionLevelMax = 5;
				shipModule.shipAccuracyPercentAdd = 40;
				shipModule.powerConsumed = 10;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 25;
				break;
				default:
				Debug.LogWarning($"[NEW STEALTH] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(STEALTH) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
