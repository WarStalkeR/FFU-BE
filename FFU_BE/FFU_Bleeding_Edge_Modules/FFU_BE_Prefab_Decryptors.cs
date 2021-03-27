using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Decryptors {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 1769741276) return idx; idx++; //Stealth decryptor 1 diy
			if (moduleID == 1276182165) return idx; idx++; //Stealth decryptor 1 ventilator
			if (moduleID == 1107135249) return idx; idx++; //Stealth decryptor 1 ivory old
			if (moduleID == 1799114982) return idx; idx++; //Stealth decryptor 1 rats
			if (moduleID == 1276182163) return idx; idx++; //Stealth decryptor 2 new human tec
			if (moduleID == 1451295920) return idx; idx++; //Stealth decryptor 3 bio
			if (moduleID == 29772476) return idx; idx++; //Stealth decryptor 2 biobrain
			if (moduleID == 1276182160) return idx; idx++; //Stealth decryptor 3 newest human tec
			return idx + 100;
		}
		public static void UpdateDecryptorModule(ShipModule shipModule, bool initItemData) {
			string colorTarget = "4dffa6";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 1769741276: //Stealth decryptor 1 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -22.0f);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Made from tech scraps and simple exotic-based processing unit. Works as if it will break down at any moment. Unstable and can be disrupted by simple impact.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 100f, synthetics = 150f, exotics = 1f };
				shipModule.starmapStealthDetectionLevelMax = 1;
				shipModule.shipAccuracyPercentAdd = 5;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 1;
				shipModule_maxHealth = 5;
				break;
				case 1276182165: //Stealth decryptor 1 ventilator
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -22.6f);
				shipModule.displayName = Core.TT($"Civilian <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Manufactured by civilian equipment suppliers. Has improved exotic-based processing unit that can be used for simple dissipation of emitted energy by ship modules.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 150f, synthetics = 250f, exotics = 2f };
				shipModule.starmapStealthDetectionLevelMax = 2;
				shipModule.shipAccuracyPercentAdd = 8;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 7;
				break;
				case 1107135249: //Stealth decryptor 1 ivory old
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -23.2f);
				shipModule.displayName = Core.TT($"Ancient <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Was manufactured and intensively used centuries ago. Houses very advanced, but heavily damaged exotic-based processing unit. Has low performance due to wearied down state.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 250f, synthetics = 500f, exotics = 3f };
				shipModule.starmapStealthDetectionLevelMax = 3;
				shipModule.shipAccuracyPercentAdd = 11;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 10;
				break;
				case 1799114982: //Stealth decryptor 1 rats
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -23.8f);
				shipModule.displayName = Core.TT($"Imperial <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Manufactured in Rat Empire with older stealth generators as template. Uses decent exotic-based processing unit, but due to lack of proper programming has questionable performance.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 400f, synthetics = 750f, exotics = 4f };
				shipModule.starmapStealthDetectionLevelMax = 3;
				shipModule.shipAccuracyPercentAdd = 15;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 13;
				break;
				case 1276182163: //Stealth decryptor 2 new human tec
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -24.4f);
				shipModule.displayName = Core.TT($"Modern <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Modern and mass produced stealth generator that mostly used in active military units. Uses very advanced exotic-based processing unit and has good operational performance.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 450f, metals = 650f, synthetics = 1000f, exotics = 5f };
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 15;
				break;
				case 1451295920: //Stealth decryptor 3 bio
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -25.0f);
				shipModule.displayName = Core.TT($"Bionic <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Stealth generator of organic origin. Cloned in special environment and uses organic/exotic-based processing unit for emitted energy dissipation. Has excellent performance.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, organics = 1000f, synthetics = 1500f, exotics = 7f };
				shipModule.starmapStealthDetectionLevelMax = 4;
				shipModule.shipAccuracyPercentAdd = 25;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 18;
				break;
				case 29772476: //Stealth decryptor 2 biobrain
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -25.6f);
				shipModule.displayName = Core.TT($"Hybrid <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Stealth generator that houses experimental organic/exotic-based processing unit within hard metallic/synthetic shell for emitted energy dissipation. Has great operational performance.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 1000f, synthetics = 2000f, organics = 500f, exotics = 10f };
				shipModule.starmapStealthDetectionLevelMax = 5;
				shipModule.shipAccuracyPercentAdd = 30;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 22;
				break;
				case 1276182160: //Stealth decryptor 3 newest human tec
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Stealth].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -26.2f);
				shipModule.displayName = Core.TT($"Phased <color=#{colorTarget}ff>Stealth Generator</color>");
				shipModule.description = Core.TT($"Simultaneously processes received data from multiple observation phases with its ultra-advanced exotic-based processing unit to perfectly dissipate energy emitted by the ship.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 1500f, synthetics = 2750f, exotics = 15f };
				shipModule.starmapStealthDetectionLevelMax = 5;
				shipModule.shipAccuracyPercentAdd = 40;
				shipModule.powerConsumed = 10;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 25;
				break;
				default:
				Debug.LogWarning($"[NEW STEALTH] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(STEALTH) {shipModule.name}";
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}