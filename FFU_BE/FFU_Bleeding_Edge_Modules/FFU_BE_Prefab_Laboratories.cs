using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Laboratories {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("lab module diy x2")) return idx; idx++;
			if (moduleName.Contains("lab rats x3")) return idx; idx++;
			if (moduleName.Contains("lab module x3")) return idx; idx++;
			if (moduleName.Contains("lab 1xgood")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("lab module diy x2");
				return moduleList;
				case 2:
				moduleList.Add("lab module diy x2");
				moduleList.Add("lab rats x3");
				return moduleList;
				case 3:
				moduleList.Add("lab module diy x2");
				moduleList.Add("lab rats x3");
				return moduleList;
				case 4:
				moduleList.Add("lab rats x3");
				return moduleList;
				case 5:
				moduleList.Add("lab rats x3");
				moduleList.Add("lab module x3");
				return moduleList;
				case 6:
				moduleList.Add("lab module x3");
				return moduleList;
				case 7:
				moduleList.Add("lab module x3");
				moduleList.Add("lab 1xgood");
				return moduleList;
				case 8:
				moduleList.Add("lab module x3");
				moduleList.Add("lab 1xgood");
				return moduleList;
				case 9:
				moduleList.Add("lab 1xgood");
				return moduleList;
				case 10:
				moduleList.Add("lab 1xgood");
				return moduleList;
				default:
				moduleList.Add("lab module diy x2");
				moduleList.Add("lab rats x3");
				moduleList.Add("lab module x3");
				moduleList.Add("lab 1xgood");
				return moduleList;
			}
		}
		public static void UpdateLaboratoryModule(ShipModule shipModule) {
			string colorLab = "4dffff";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "lab module diy x2":
				shipModule.displayName = "Makeshift <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "Laboratory for scientific research. Crew assigned to it will generate xenodata during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 1f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 150f, exotics = 5f };
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 15;
				break;
				case "lab rats x3":
				shipModule.displayName = "Imperial <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "Laboratory for scientific research. Crew assigned to it will generate xenodata during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 2f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 750f, exotics = 10f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 25;
				break;
				case "lab module x3":
				shipModule.displayName = "Complex <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "Laboratory for scientific research. Crew assigned to it will generate xenodata during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 3f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 2000f, exotics = 20f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 20;
				break;
				case "lab 1xgood":
				shipModule.displayName = "Quantum <color=#" + colorLab + "ff>Laboratory</color>";
				shipModule.description = "A very efficient and powerful laboratory for scientific research. Crew assigned to it will generate xenodata and exotics during interstellar travel, based on their science skill.";
				shipModule.Research.producedPerSkillPoint = new ResourceValueGroup { credits = 5f, exotics = 0.1f };
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 5000f, synthetics = 3500f, exotics = 50f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 20;
				break;
				default: shipModule.displayName = "(LABORATORY) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
