using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Laboratories {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("lab module diy x2")) return idx; idx++;
			if (moduleName.Contains("lab rats x3")) return idx; idx++;
			if (moduleName.Contains("lab module x3")) return idx; idx++;
			if (moduleName.Contains("lab 1xgood")) return idx; idx++;
			return idx + 100;
		}
		public static void UpdateLaboratoryModule(ShipModule shipModule, bool initItemData) {
			string colorLab = "4dffff";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "lab module diy x2":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Makeshift <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "Laboratory for scientific research. Crew assigned to it will generate xenodata during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 1f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 150f, exotics = 5f };
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 15;
				break;
				case "lab rats x3":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.4f);
				shipModule.displayName = "Imperial <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "Laboratory for scientific research. Crew assigned to it will generate xenodata during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 2f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 750f, exotics = 10f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 25;
				break;
				case "lab module x3":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.8f);
				shipModule.displayName = "Complex <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "Laboratory for scientific research. Crew assigned to it will generate xenodata during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 3f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 2000f, exotics = 20f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 20;
				break;
				case "lab 1xgood":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 3.2f);
				shipModule.displayName = "Quantum <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "A very efficient and powerful laboratory for scientific research. Crew assigned to it will generate xenodata and exotics during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 5f, exotics = 0.1f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 5000f, synthetics = 3500f, exotics = 50f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 20;
				break;
				default:
				Debug.LogWarning($"[NEW LABORATORY] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(LABORATORY) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
