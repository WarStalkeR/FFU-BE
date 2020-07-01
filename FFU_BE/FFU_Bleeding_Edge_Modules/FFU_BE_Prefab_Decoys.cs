using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Decoys {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "shield decoy 1") return idx; idx++;
			if (moduleName == "weapondecoy1") return idx; idx++;
			if (moduleName == "weapondecoy_alien") return idx; idx++;
			return idx + 100;
		}
		public static void UpdateDecoyModule(ShipModule shipModule, bool initItemData) {
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "weapondecoy1":
				shipModule.displayName = "Decoy Ordnance Armament";
				shipModule.description = "A highly armored hardpoint that strengthens ship's integrity. Manufactured in order to fool hostile targeting systems. Appears as weapons to the enemy sensors.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 1000f };
				shipModule.maxHealthAdd = 20;
				shipModule_maxHealth = 100;
				break;
				case "weapondecoy_alien":
				shipModule.displayName = "Decoy Alien Armament";
				shipModule.description = "A highly armored hardpoint that strengthens ship's integrity. Manufactured in order to fool hostile targeting systems. Appears as unknown alien weapon to the enemy sensors.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 1500f };
				shipModule.maxHealthAdd = 30;
				shipModule_maxHealth = 150;
				break;
				default:
				Debug.LogWarning($"[NEW DECOY] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(DECOY) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStatsCore(shipModule);
		}
	}
}
