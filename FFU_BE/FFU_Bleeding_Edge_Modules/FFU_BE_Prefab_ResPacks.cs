using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_ResPacks {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 760167696) return idx; idx++; //organics pack
			if (moduleID == 453797399) return idx; idx++; //fuel pack
			if (moduleID == 1581569285) return idx; idx++; //metal pack
			if (moduleID == 345284781) return idx; idx++; //synth pack
			if (moduleID == 813048445) return idx; idx++; //explosives pack
			if (moduleID == 124199597) return idx; idx++; //exotics pack
			if (moduleID == 89687050) return idx; idx++; //medical pack organics, synth
			if (moduleID == 2025144458) return idx; idx++; //general pack organics, synth, metal
			if (moduleID == 57217862) return idx; idx++; //compressed exotics pack
			return idx + 100;
		}
		public static void UpdateResourcePackModule(ShipModule shipModule, bool initItemData) {
			switch (shipModule.PrefabId) {
				case 760167696: //organics pack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Organics Pack");
				shipModule.craftCost = new ResourceValueGroup { organics = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 5000f };
				break;
				case 453797399: //fuel pack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Starfuel Pack");
				shipModule.craftCost = new ResourceValueGroup { fuel = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { fuel = 5000f };
				break;
				case 1581569285: //metal pack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Metals Pack");
				shipModule.craftCost = new ResourceValueGroup { metals = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { metals = 5000f };
				break;
				case 345284781: //synth pack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Synthetics Pack");
				shipModule.craftCost = new ResourceValueGroup { synthetics = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { synthetics = 5000f };
				break;
				case 813048445: //explosives pack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Explosives Pack");
				shipModule.craftCost = new ResourceValueGroup { explosives = 5000f };
				shipModule.scrapGet = new ResourceValueGroup { explosives = 5000f };
				break;
				case 124199597: //exotics pack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Exotics Pack");
				shipModule.craftCost = new ResourceValueGroup { exotics = 500f };
				shipModule.scrapGet = new ResourceValueGroup { exotics = 500f };
				break;
				case 89687050: //medical pack organics, synth
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Medical Pack");
				shipModule.description = Core.TT($"Selection of carbon-organic substances and synthetic materials for 3D-printers for various needs. Provides organics and synthetics when scrapped.");
				shipModule.craftCost = new ResourceValueGroup { organics = 3500f, synthetics = 3500f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 3500f, synthetics = 3500f };
				break;
				case 2025144458: //general pack organics, synth, metal
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Military Pack");
				shipModule.description = Core.TT($"Selection of carbon-organic substances, synthetic materials for 3D-printers and rare metals for various needs. Provides organics, synthetics and metals when scrapped.");
				shipModule.craftCost = new ResourceValueGroup { organics = 2500f, synthetics = 2500f, metals = 2500f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 2500f, synthetics = 2500f, metals = 2500f };
				break;
				case 57217862: //compressed exotics pack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.ResPack].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Artificer Pack");
				shipModule.description = Core.TT($"Package that contains all resource types, including extremely rare exotics substances. Use with caution. Provides large amount of every resource type when scrapped.");
				shipModule.craftCost = new ResourceValueGroup { organics = 2000f, fuel = 2000f, metals = 2000f, synthetics = 2000f, explosives = 2000f, exotics = 200f };
				shipModule.scrapGet = new ResourceValueGroup { organics = 2000f, fuel = 2000f, metals = 2000f, synthetics = 2000f, explosives = 2000f, exotics = 200f };
				break;
				default:
				Debug.LogWarning($"[NEW PACK] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(PACK) {shipModule.name}";
				break;
			}
			FFU_BE_Mod_Modules.RecalcModuleShopPrice(shipModule);
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = 100;
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "health") = 100;
		}
	}
}