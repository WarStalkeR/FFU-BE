﻿using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_CryoBays {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("dream recorder 1 DIY")) return idx; idx++;
			if (moduleName.Contains("dream recorder 1 rats")) return idx; idx++;
			if (moduleName.Contains("dream recorder 2")) return idx; idx++;
			if (moduleName.Contains("dream recorder 4x weird biotech")) return idx; idx++;
			if (moduleName.Contains("cryosleep 6x human standard")) return idx; idx++;
			if (moduleName.Contains("cryosleep 1 DIY")) return idx; idx++;
			if (moduleName.Contains("cryosleep 2x human small")) return idx; idx++;
			if (moduleName.Contains("cryosleep 3x rats armor")) return idx; idx++;
			if (moduleName.Contains("cryosleep 3x medical")) return idx; idx++;
			if (moduleName.Contains("cryosleep 4x alien family")) return idx; idx++;
			if (moduleName.Contains("cryosleep 8x insect")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("dream recorder 1 DIY");
				moduleList.Add("cryosleep 1 DIY");
				return moduleList;
				case 2:
				moduleList.Add("dream recorder 1 DIY");
				moduleList.Add("dream recorder 1 rats");
				moduleList.Add("cryosleep 1 DIY");
				moduleList.Add("cryosleep 2x human small");
				return moduleList;
				case 3:
				moduleList.Add("dream recorder 1 rats");
				moduleList.Add("dream recorder 2");
				moduleList.Add("cryosleep 2x human small");
				moduleList.Add("cryosleep 3x rats armor");
				return moduleList;
				case 4:
				moduleList.Add("dream recorder 2");
				moduleList.Add("cryosleep 3x rats armor");
				moduleList.Add("cryosleep 3x medical");
				return moduleList;
				case 5:
				moduleList.Add("dream recorder 2");
				moduleList.Add("dream recorder 4x weird biotech");
				moduleList.Add("cryosleep 3x medical");
				moduleList.Add("cryosleep 4x alien family");
				return moduleList;
				case 6:
				moduleList.Add("dream recorder 4x weird biotech");
				moduleList.Add("cryosleep 4x alien family");
				moduleList.Add("cryosleep 8x insect");
				return moduleList;
				case 7:
				moduleList.Add("dream recorder 4x weird biotech");
				moduleList.Add("cryosleep 4x alien family");
				moduleList.Add("cryosleep 8x insect");
				return moduleList;
				case 8:
				moduleList.Add("dream recorder 4x weird biotech");
				moduleList.Add("cryosleep 6x human standard");
				moduleList.Add("cryosleep 8x insect");
				return moduleList;
				case 9:
				moduleList.Add("cryosleep 6x human standard");
				moduleList.Add("cryosleep 8x insect");
				return moduleList;
				case 10:
				moduleList.Add("cryosleep 6x human standard");
				moduleList.Add("cryosleep 8x insect");
				return moduleList;
				default:
				moduleList.Add("dream recorder 1 DIY");
				moduleList.Add("dream recorder 1 rats");
				moduleList.Add("dream recorder 2");
				moduleList.Add("dream recorder 4x weird biotech");
				moduleList.Add("cryosleep 6x human standard");
				moduleList.Add("cryosleep 1 DIY");
				moduleList.Add("cryosleep 2x human small");
				moduleList.Add("cryosleep 3x rats armor");
				moduleList.Add("cryosleep 3x medical");
				moduleList.Add("cryosleep 4x alien family");
				moduleList.Add("cryosleep 8x insect");
				return moduleList;
			}
		}
		public static void UpdateCryosleepModule(ShipModule shipModule) {
			string colorDream = "d966ff";
			string colorSleep = "ff66d9";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "dream recorder 1 DIY":
				shipModule.displayName = "Makeshift <color=#" + colorDream + "ff>Cryodream Bay</color>";
				shipModule.description = "Crew sleeping in this makeshift cryodream recorder requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, organics = 200f, metals = 150f, synthetics = 100f, exotics = 1f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 300f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 800f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 200f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 500f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 5;
				break;
				case "dream recorder 1 rats":
				shipModule.displayName = "Imperial <color=#" + colorDream + "ff>Cryodream Bay</color>";
				shipModule.description = "Crew sleeping in this armored cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, organics = 350f, metals = 350f, synthetics = 250f, exotics = 2f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 200f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 600f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 150f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 350f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case "dream recorder 2":
				shipModule.displayName = "Standard <color=#" + colorDream + "ff>Cryodream Bay</color>";
				shipModule.description = "Crew sleeping in this low capacity cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, organics = 750f, metals = 500f, synthetics = 350f, exotics = 3f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 150f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 400f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 150f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 250f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 15;
				break;
				case "dream recorder 4x weird biotech":
				shipModule.displayName = "Advanced <color=#" + colorDream + "ff>Cryodream Bay</color>";
				shipModule.description = "Crew sleeping in this medium capacity cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, organics = 1500f, metals = 1250f, synthetics = 750f, exotics = 5f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 100f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 250f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 100f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 200f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 6;
				shipModule_maxHealth = 20;
				break;
				case "cryosleep 6x human standard":
				shipModule.displayName = "Exploration <color=#" + colorDream + "ff>Cryodream Bay</color>";
				shipModule.description = "Crew sleeping in this high capacity cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, organics = 2500f, metals = 2000f, synthetics = 1500f, exotics = 10f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 100f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 150f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 100f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 150f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 30;
				break;
				case "cryosleep 1 DIY":
				shipModule.displayName = "Makeshift <color=#" + colorSleep + "ff>Cryosleep Bay</color>";
				shipModule.description = "Crew sleeping in this makeshift cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, organics = 150f, metals = 125f, synthetics = 75f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 250f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 700f;
				shipModule.powerConsumed = 1;
				shipModule_maxHealth = 5;
				break;
				case "cryosleep 2x human small":
				shipModule.displayName = "Standard <color=#" + colorSleep + "ff>Cryosleep Bay</color>";
				shipModule.description = "Crew sleeping in this low capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, organics = 300f, metals = 250f, synthetics = 150f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 175f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 500f;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case "cryosleep 3x rats armor":
				shipModule.displayName = "Imperial <color=#" + colorSleep + "ff>Cryosleep Bay</color>";
				shipModule.description = "Crew sleeping in this armored medium capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, organics = 500f, metals = 350f, synthetics = 250f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 150f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 450f;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 20;
				break;
				case "cryosleep 3x medical":
				shipModule.displayName = "Medical <color=#" + colorSleep + "ff>Cryosleep Bay</color>";
				shipModule.description = "Crew sleeping in this medical medium capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, organics = 1000f, metals = 350f, synthetics = 250f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 10f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 50f;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 15;
				break;
				case "cryosleep 4x alien family":
				shipModule.displayName = "Luxurious <color=#" + colorSleep + "ff>Cryosleep Bay</color>";
				shipModule.description = "Crew sleeping in this luxurious medium capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, organics = 750f, metals = 500f, synthetics = 350f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 100f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 200f;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 20;
				break;
				case "cryosleep 8x insect":
				shipModule.displayName = "Military <color=#" + colorSleep + "ff>Cryosleep Bay</color>";
				shipModule.description = "Crew sleeping in this military high capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, organics = 1000f, metals = 750f, synthetics = 500f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 50f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 100f;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 40;
				break;
				default: shipModule.displayName = "(CRYOSLEEP) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}