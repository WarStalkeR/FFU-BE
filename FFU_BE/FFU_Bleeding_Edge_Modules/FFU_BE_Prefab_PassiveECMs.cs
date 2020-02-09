using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_PassiveECMs {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("ECM 0 DIY")) return idx; idx++;
			if (moduleName.Contains("ECM 0 terran old")) return idx; idx++;
			if (moduleName.Contains("ECM 0 ancient")) return idx; idx++;
			if (moduleName.Contains("ECM 03 insectoid")) return idx; idx++;
			if (moduleName.Contains("ECM 01 terran")) return idx; idx++;
			if (moduleName.Contains("ECM 03 biotech")) return idx; idx++;
			if (moduleName.Contains("ECM 02 terran")) return idx; idx++;
			if (moduleName.Contains("ECM 04 spideraa")) return idx; idx++;
			if (moduleName.Contains("ECM 03 terran")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("ECM 0 DIY");
				return moduleList;
				case 2:
				moduleList.Add("ECM 0 DIY");
				moduleList.Add("ECM 0 terran old");
				return moduleList;
				case 3:
				moduleList.Add("ECM 0 terran old");
				moduleList.Add("ECM 0 ancient");
				return moduleList;
				case 4:
				moduleList.Add("ECM 0 ancient");
				moduleList.Add("ECM 03 insectoid");
				return moduleList;
				case 5:
				moduleList.Add("ECM 03 insectoid");
				moduleList.Add("ECM 01 terran");
				return moduleList;
				case 6:
				moduleList.Add("ECM 01 terran");
				moduleList.Add("ECM 03 biotech");
				return moduleList;
				case 7:
				moduleList.Add("ECM 03 biotech");
				moduleList.Add("ECM 02 terran");
				return moduleList;
				case 8:
				moduleList.Add("ECM 02 terran");
				moduleList.Add("ECM 04 spideraa");
				return moduleList;
				case 9:
				moduleList.Add("ECM 04 spideraa");
				moduleList.Add("ECM 03 terran");
				return moduleList;
				case 10:
				moduleList.Add("ECM 03 terran");
				return moduleList;
				default:
				moduleList.Add("ECM 0 DIY");
				moduleList.Add("ECM 0 terran old");
				moduleList.Add("ECM 0 ancient");
				moduleList.Add("ECM 03 insectoid");
				moduleList.Add("ECM 01 terran");
				moduleList.Add("ECM 03 biotech");
				moduleList.Add("ECM 02 terran");
				moduleList.Add("ECM 04 spideraa");
				moduleList.Add("ECM 03 terran");
				return moduleList;
			}
		}
		public static void UpdateCountermeasureModule(ShipModule shipModule) {
			string colorCounter = "4dd2ff";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "ECM 0 DIY":
				shipModule.displayName = "Makeshift <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array that was made from salvage and scrap materials. Although has very questionable quality, still manages somewhat to disrupt hostile targeting systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 200f, synthetics = 50f, exotics = 1f };
				shipModule.shipEvasionPercentAdd = 1;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 15;
				break;
				case "ECM 0 terran old":
				shipModule.displayName = "Ancient <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Was manufactured centuries ago and used in every imaginable war and military operation. Heavily wearied down, but still can disrupt hostile targeting systems to certain extent.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 75f, exotics = 2f };
				shipModule.shipEvasionPercentAdd = 2;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 18;
				break;
				case "ECM 0 ancient":
				shipModule.displayName = "Imperial <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "A rare case of technology that was designed and manufactured by Rat Empire from scratch. Has mediocre quality, but still can be used to disrupt hostile targeting systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 125f, exotics = 3f };
				shipModule.shipEvasionPercentAdd = 3;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 20;
				break;
				case "ECM 03 insectoid":
				shipModule.displayName = "Velocity <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Created by marauders and pirates from various salvaged parts of other ECM arrays, but with professional touch. Has average jamming efficiency of hostile targeting systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 700f, synthetics = 175f, exotics = 4f };
				shipModule.shipEvasionPercentAdd = 4;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 22;
				break;
				case "ECM 01 terran":
				shipModule.displayName = "Reflector <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Manufactured with specialized mirror array that constantly emits ship's reflections that has some chance to fool enemy targeting systems with decent efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1000f, synthetics = 250f, exotics = 5f };
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 6;
				shipModule_maxHealth = 24;
				break;
				case "ECM 03 biotech":
				shipModule.displayName = "Bionic <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array or organic origin. Grown up in special environment and contains all ports for proper interfacing. Has good jamming efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, organics = 1300f, synthetics = 325f, exotics = 7f };
				shipModule.shipEvasionPercentAdd = 6;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 7;
				shipModule_maxHealth = 27;
				break;
				case "ECM 02 terran":
				shipModule.displayName = "Prismatic <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array with built-in prismatic emitters that literally blind hostile targeting systems and sensors. Has very good jamming efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1700f, synthetics = 425f, exotics = 10f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 8;
				shipModule_maxHealth = 31;
				break;
				case "ECM 04 spideraa":
				shipModule.displayName = "Repulsor <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array that uses kinetic energy and unknown principles to disrupt hostile targeting systems and sensors. Has great jamming efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 2500f, synthetics = 625f, exotics = 15f };
				shipModule.shipEvasionPercentAdd = 8;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 9;
				shipModule_maxHealth = 35;
				break;
				case "ECM 03 terran":
				shipModule.displayName = "Quantum <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "This electronic countermeasure array constantly produces quantum chaff with intangibility effect that disrupts hostile targeting systems and sensors with excellent efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 4000f, synthetics = 1000f, exotics = 25f };
				shipModule.shipEvasionPercentAdd = 10;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 40;
				break;
				case "ECM 02.2 ancient artifact, slicer dicer":
				shipModule.displayName = "ECM Array Artifact";
				shipModule_maxHealth = 50;
				break;
				default: shipModule.displayName = "(ECM) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
