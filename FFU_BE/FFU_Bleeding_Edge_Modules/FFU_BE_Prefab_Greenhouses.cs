using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Greenhouses {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "garden 1 DIY") return idx; idx++;
			if (moduleName == "garden 2 minigrow") return idx; idx++;
			if (moduleName == "garden 3 shroomery") return idx; idx++;
			if (moduleName == "garden 4 greenhouse") return idx; idx++;
			if (moduleName == "garden 5 greenhouse") return idx; idx++;
			if (moduleName == "garden 6 synthethics") return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("garden 1 DIY");
				moduleList.Add("garden 2 minigrow");
				return moduleList;
				case 2:
				moduleList.Add("garden 1 DIY");
				moduleList.Add("garden 2 minigrow");
				return moduleList;
				case 3:
				moduleList.Add("garden 2 minigrow");
				moduleList.Add("garden 3 shroomery");
				return moduleList;
				case 4:
				moduleList.Add("garden 2 minigrow");
				moduleList.Add("garden 3 shroomery");
				return moduleList;
				case 5:
				moduleList.Add("garden 2 minigrow");
				moduleList.Add("garden 3 shroomery");
				moduleList.Add("garden 4 greenhouse");
				moduleList.Add("garden 5 greenhouse");
				return moduleList;
				case 6:
				moduleList.Add("garden 3 shroomery");
				moduleList.Add("garden 4 greenhouse");
				moduleList.Add("garden 5 greenhouse");
				return moduleList;
				case 7:
				moduleList.Add("garden 3 shroomery");
				moduleList.Add("garden 4 greenhouse");
				moduleList.Add("garden 5 greenhouse");
				return moduleList;
				case 8:
				moduleList.Add("garden 4 greenhouse");
				moduleList.Add("garden 5 greenhouse");
				return moduleList;
				case 9:
				moduleList.Add("garden 4 greenhouse");
				moduleList.Add("garden 5 greenhouse");
				return moduleList;
				case 10:
				moduleList.Add("garden 4 greenhouse");
				moduleList.Add("garden 5 greenhouse");
				return moduleList;
				default:
				moduleList.Add("garden 1 DIY");
				moduleList.Add("garden 2 minigrow");
				moduleList.Add("garden 3 shroomery");
				moduleList.Add("garden 4 greenhouse");
				moduleList.Add("garden 5 greenhouse");
				return moduleList;
			}
		}
		public static void UpdateGreenhouseModule(ShipModule shipModule) {
			string colorGarden = "4dff4d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "garden 1 DIY":
				shipModule.displayName = "Makeshift <color=#" + colorGarden + "ff>Greenery</color>";
				shipModule.description = "A very fragile artificial environment for growing bio-engineered lichen. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 100f, fuel = 50f, metals = 50f, synthetics = 75f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 3f };
				shipModule.powerConsumed = 1;
				shipModule_maxHealth = 5;
				break;
				case "garden 2 minigrow":
				shipModule.displayName = "Standard <color=#" + colorGarden + "ff>Greenery</color>";
				shipModule.description = "Artificial environment for growing bio-engineered plants. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 200f, fuel = 100f, metals = 150f, synthetics = 250f, exotics = 1f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 2f };
				shipModule.powerConsumed = 1;
				shipModule_maxHealth = 10;
				break;
				case "garden 3 shroomery":
				shipModule.displayName = "Mushroom <color=#" + colorGarden + "ff>Hothouse</color>";
				shipModule.description = "Artificial environment for growing bio-engineered mushrooms. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 300f, fuel = 200f, metals = 300f, synthetics = 500f, exotics = 2f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 4f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 15;
				break;
				case "garden 4 greenhouse":
				shipModule.displayName = "Accelerated <color=#" + colorGarden + "ff>Greenhouse</color>";
				shipModule.description = "Artificial environment for growing bio-engineered plants with best growth rate. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 500f, fuel = 350f, metals = 750f, synthetics = 1250f, exotics = 5f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 7f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 20;
				break;
				case "garden 5 greenhouse":
				shipModule.displayName = "Luxurious <color=#" + colorGarden + "ff>Greenhouse</color>";
				shipModule.description = "Artificial environment for growing bio-engineered plants with best operator capacity. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 500f, fuel = 350f, metals = 750f, synthetics = 1250f, exotics = 5f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 5f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 20;
				break;
				case "garden 6 synthethics":
				shipModule.displayName = "Exogenetic <color=#" + colorGarden + "ff>Greenhouse</color>";
				shipModule.description = "Artificial environment for growing highly nutritious bio-engineered exotic plants. Uses excess heat generated during interstellar travel for production.";
				shipModule.craftCost = new ResourceValueGroup { organics = 1000f, fuel = 500f, metals = 1000f, synthetics = 1500f, exotics = 10f };
				shipModule.GardenModule.producedPerSkillPoint = new ResourceValueGroup { organics = 25f, exotics = 1f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 25;
				break;
				default: shipModule.displayName = "(GREENHOUSE) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
