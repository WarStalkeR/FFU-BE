using RST;
using HarmonyLib;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Decoys {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "shield decoy 1") return idx; idx++;
			if (moduleName == "weapondecoy1") return idx; idx++;
			return 999;
		}
		public static void UpdateDecoyModule(ShipModule shipModule) {
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "weapondecoy1":
				shipModule.displayName = "Decoy Ordnance Armament";
				shipModule.description = "A highly armored hardpoint that strengthens ship's integrity. Manufactured in order to fool hostile targeting systems. Appears as weapons to the enemy sensors.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 1000f };
				shipModule.maxHealthAdd = 20;
				shipModule_maxHealth = 100;
				break;
				default: shipModule.displayName = "(DECOY) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStatsCore(shipModule);
		}
	}
}
