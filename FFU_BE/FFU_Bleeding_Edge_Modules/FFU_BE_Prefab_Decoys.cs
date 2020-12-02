using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Decoys {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 2047550720) return idx; idx++; //shield decoy 1
			if (moduleID == 340864347) return idx; idx++; //weapondecoy1
			if (moduleID == 1505324046) return idx; idx++; //weapondecoy_alien
			return idx + 100;
		}
		public static void UpdateDecoyModule(ShipModule shipModule, bool initItemData) {
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 340864347: //weapondecoy1
				shipModule.displayName = "Decoy Ordnance Armament";
				shipModule.description = "A highly armored hardpoint that strengthens ship's integrity. Manufactured in order to fool hostile targeting systems. Appears as weapons to the enemy sensors.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 1000f };
				shipModule.maxHealthAdd = 20;
				shipModule_maxHealth = 100;
				break;
				case 1505324046: //weapondecoy_alien
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
