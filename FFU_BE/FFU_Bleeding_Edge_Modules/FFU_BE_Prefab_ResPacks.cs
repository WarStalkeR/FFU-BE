using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_ResPacks {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "organics pack") return idx; idx++;
			if (moduleName == "fuel pack") return idx; idx++;
			if (moduleName == "metal pack") return idx; idx++;
			if (moduleName == "synth pack") return idx; idx++;
			if (moduleName == "explosives pack") return idx; idx++;
			if (moduleName == "exotics pack") return idx; idx++;
			if (moduleName == "medical pack organics, synth") return idx; idx++;
			if (moduleName == "general pack organics, synth, metal") return idx; idx++;
			if (moduleName == "compressed exotics pack") return idx; idx++;
			return 999;
		}
		public static void UpdateResourcePackModule(ShipModule shipModule, bool initItemData) {
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "organics pack":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Organics Pack";
				shipModule.craftCost = new ResourceValueGroup { organics = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 5000f };
				break;
				case "fuel pack":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Starfuel Pack";
				shipModule.craftCost = new ResourceValueGroup { fuel = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { fuel = 5000f };
				break;
				case "metal pack":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Metals Pack";
				shipModule.craftCost = new ResourceValueGroup { metals = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { metals = 5000f };
				break;
				case "synth pack":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Synthetics Pack";
				shipModule.craftCost = new ResourceValueGroup { synthetics = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { synthetics = 5000f };
				break;
				case "explosives pack":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Explosives Pack";
				shipModule.craftCost = new ResourceValueGroup { explosives = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { explosives = 5000f };
				break;
				case "exotics pack":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Exotics Pack";
				shipModule.craftCost = new ResourceValueGroup { exotics = 500f };
				shipModule.scrapGet = new ResourceValueGroup { exotics = 500f };
				break;
				case "medical pack organics, synth":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Medical Supply Pack";
				shipModule.description = "Selection of carbon-organic substances and synthetic materials for 3D-printers for various needs. Provides organics and synthetics when scrapped.";
				shipModule.craftCost = new ResourceValueGroup { organics = 3500f, synthetics = 3500f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 3500f, synthetics = 3500f };
				break;
				case "general pack organics, synth, metal":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Military Supply Pack";
				shipModule.description = "Selection of carbon-organic substances, synthetic materials for 3D-printers and rare metals for various needs. Provides organics, synthetics and metals when scrapped.";
				shipModule.craftCost = new ResourceValueGroup { organics = 2500f, synthetics = 2500f, metals = 2500f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 2500f, synthetics = 2500f, metals = 2500f };
				break;
				case "compressed exotics pack":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 0);
				shipModule.displayName = "Artificer Supply Pack";
				shipModule.description = "Package that contains all resource types, including extremely rare exotics substances. Use with caution. Provides large amount of every resource type when scrapped.";
				shipModule.craftCost = new ResourceValueGroup { organics = 2000f, fuel = 2000f, metals = 2000f, synthetics = 2000f, explosives = 2000f, exotics = 200f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 2000f, fuel = 2000f, metals = 2000f, synthetics = 2000f, explosives = 2000f, exotics = 200f };
				break;
				default:
				Debug.LogWarning($"[NEW PACK] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(PACK) " + shipModule.displayName;
				break;
			}
			FFU_BE_Mod_Modules.RecalcModuleShopPrice(shipModule);
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = 10;
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "health") = 10;
		}
	}
}