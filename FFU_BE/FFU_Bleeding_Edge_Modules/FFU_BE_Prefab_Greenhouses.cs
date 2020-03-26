using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Greenhouses {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "garden 1 DIY") return idx; idx++;
			if (moduleName == "garden 2 minigrow") return idx; idx++;
			if (moduleName == "garden 3 shroomery") return idx; idx++;
			if (moduleName == "garden 5 greenhouse") return idx; idx++;
			if (moduleName == "garden 4 greenhouse") return idx; idx++;
			if (moduleName == "garden 6 synthethics") return idx; idx++;
			return idx + 100;
		}
		public static void UpdateGreenhouseModule(ShipModule shipModule, bool initItemData) {
			string colorGarden = "4dff4d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "garden 1 DIY":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Makeshift <color=#" + colorGarden + "ff>Greenery</color>";
				shipModule.description = "A very fragile artificial environment for growing bio-engineered lichen. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 100f, fuel = 50f, metals = 50f, synthetics = 75f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 3f };
				shipModule.powerConsumed = 1;
				shipModule_maxHealth = 5;
				break;
				case "garden 2 minigrow":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Standard <color=#" + colorGarden + "ff>Greenery</color>";
				shipModule.description = "Artificial environment for growing bio-engineered plants. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 200f, fuel = 100f, metals = 150f, synthetics = 250f, exotics = 1f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 2f };
				shipModule.powerConsumed = 1;
				shipModule_maxHealth = 10;
				break;
				case "garden 3 shroomery":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Mushroom <color=#" + colorGarden + "ff>Hothouse</color>";
				shipModule.description = "Artificial environment for growing bio-engineered mushrooms. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 300f, fuel = 200f, metals = 300f, synthetics = 500f, exotics = 2f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 4f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 15;
				break;
				case "garden 5 greenhouse":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.2f);
				shipModule.displayName = "Farmland <color=#" + colorGarden + "ff>Greenhouse</color>";
				shipModule.description = "Artificial environment for growing bio-engineered plants with best operator capacity. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 400f, fuel = 300f, metals = 500f, synthetics = 900f, exotics = 3f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 5f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 20;
				break;
				case "garden 4 greenhouse":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.6f);
				shipModule.displayName = "Replicator <color=#" + colorGarden + "ff>Greenhouse</color>";
				shipModule.description = "Artificial environment for growing bio-engineered plants with best growth rate. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 500f, fuel = 350f, metals = 750f, synthetics = 1250f, exotics = 5f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 8f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 20;
				break;
				case "garden 6 synthethics":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 3.2f);
				shipModule.displayName = "Exogenetic <color=#" + colorGarden + "ff>Greenhouse</color>";
				shipModule.description = "Artificial environment for growing highly nutritious bio-engineered exotic plants. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 1000f, fuel = 500f, metals = 1000f, synthetics = 1500f, exotics = 10f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 25f, exotics = 0.3f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 25;
				break;
				default:
				Debug.LogWarning($"[NEW GARDEN] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(GARDEN) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
