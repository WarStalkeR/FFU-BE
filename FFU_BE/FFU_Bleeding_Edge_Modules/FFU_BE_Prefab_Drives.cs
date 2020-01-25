using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Drives {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("warp 0 DIY")) return idx; idx++;
			if (moduleName.Contains("warp 01 greencrystal")) return idx; idx++;
			if (moduleName.Contains("warp 05 spiralcrystal")) return idx; idx++;
			if (moduleName.Contains("warp 02 bluecrystal")) return idx; idx++;
			if (moduleName.Contains("warp 03 neoncrystal")) return idx; idx++;
			if (moduleName.Contains("warp 05 rotor metal")) return idx; idx++;
			if (moduleName.Contains("warp 04 emperorbanks")) return idx; idx++;
			if (moduleName.Contains("warp 06 rotor blue")) return idx; idx++;
			if (moduleName.Contains("warp 09 spideraa")) return idx; idx++;
			if (moduleName.Contains("warp 07 rotor glass")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("warp 0 DIY");
				moduleList.Add("warp 01 greencrystal");
				return moduleList;
				case 2:
				moduleList.Add("warp 01 greencrystal");
				moduleList.Add("warp 05 spiralcrystal");
				return moduleList;
				case 3:
				moduleList.Add("warp 05 spiralcrystal");
				moduleList.Add("warp 02 bluecrystal");
				return moduleList;
				case 4:
				moduleList.Add("warp 02 bluecrystal");
				moduleList.Add("warp 03 neoncrystal");
				return moduleList;
				case 5:
				moduleList.Add("warp 03 neoncrystal");
				moduleList.Add("warp 05 rotor metal");
				return moduleList;
				case 6:
				moduleList.Add("warp 05 rotor metal");
				moduleList.Add("warp 04 emperorbanks");
				return moduleList;
				case 7:
				moduleList.Add("warp 04 emperorbanks");
				moduleList.Add("warp 06 rotor blue");
				return moduleList;
				case 8:
				moduleList.Add("warp 09 spideraa");
				moduleList.Add("warp 07 rotor glass");
				return moduleList;
				case 9:
				moduleList.Add("warp 09 spideraa");
				moduleList.Add("warp 07 rotor glass");
				return moduleList;
				case 10:
				moduleList.Add("warp 09 spideraa");
				moduleList.Add("warp 07 rotor glass");
				return moduleList;
				default:
				moduleList.Add("warp 0 DIY");
				moduleList.Add("warp 01 greencrystal");
				moduleList.Add("warp 05 spiralcrystal");
				moduleList.Add("warp 02 bluecrystal");
				moduleList.Add("warp 03 neoncrystal");
				moduleList.Add("warp 05 rotor metal");
				moduleList.Add("warp 04 emperorbanks");
				moduleList.Add("warp 06 rotor blue");
				moduleList.Add("warp 09 spideraa");
				moduleList.Add("warp 07 rotor glass");
				return moduleList;
			}
		}
		public static void UpdateWarpDriveModule(ShipModule shipModule) {
			string colorDrive = "b366ff";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "warp 0 DIY":
				shipModule.displayName = "Makeshift <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Made from spare exotics, high-tech scraps and salvaged power cores. Has very long spin-up time and horrible fuel consumption. Used, when there are no other alternatives.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 150f, synthetics = 150f, exotics = 1f };
				shipModule.Warp.activationFuel = 75;
				shipModule.Warp.reloadInterval = 50;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 20;
				break;
				case "warp 01 greencrystal":
				shipModule.displayName = "Fission <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Basic warp drive that uses fission energy to recharge warp coils in order to initiate jump. Spin-up time is still very long, but fuel consumption is a little bit better.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 300f, synthetics = 300f, exotics = 2f };
				shipModule.Warp.activationFuel = 65;
				shipModule.Warp.reloadInterval = 50;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 24;
				break;
				case "warp 05 spiralcrystal":
				shipModule.displayName = "Biochemical <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Organic warp drive that uses unidentified biochemical reactions to recharge warp coils for further jump initiation. Long spin-up time and mediocre fuel consumption.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, organics = 500f, synthetics = 500f, exotics = 3f };
				shipModule.Warp.activationFuel = 60;
				shipModule.Warp.reloadInterval = 45;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 26;
				break;
				case "warp 02 bluecrystal":
				shipModule.displayName = "Immaterium <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Exotic warp drive that uses feeds on immaterium energy to recharge warp coils in order to initiate jump. Long spin-up time and better then average fuel consumption.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 750f, synthetics = 750f, exotics = 4f };
				shipModule.Warp.activationFuel = 55;
				shipModule.Warp.reloadInterval = 45;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 28;
				break;
				case "warp 03 neoncrystal":
				shipModule.displayName = "Prismatic <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Warp drive that uses prismatic mirrors to concentrate energy in the warp coils to recharge them. Has decent spin-up time and decent fuel consumption efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, metals = 1250f, synthetics = 1250f, exotics = 5f };
				shipModule.Warp.activationFuel = 50;
				shipModule.Warp.reloadInterval = 40;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 30;
				break;
				case "warp 05 rotor metal":
				shipModule.displayName = "Fusion <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Warp drive that uses pure and unprocessed fusion energy to recharge warp coils for further jump initiation. Has good spin-up time and optimized fuel consumption.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 800f, metals = 1750f, synthetics = 1750f, exotics = 7f };
				shipModule.Warp.activationFuel = 45;
				shipModule.Warp.reloadInterval = 35;
				shipModule.powerConsumed = 7;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 33;
				break;
				case "warp 04 emperorbanks":
				shipModule.displayName = "Commerical <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Warp drive that was developed for sake of profit and is sold to anybody who can afford it. Private manufacturing will lead to breach of copyright agreement and lawsuit.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2250f, synthetics = 2250f, exotics = 10f };
				shipModule.Warp.activationFuel = 40;
				shipModule.Warp.reloadInterval = 30;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 36;
				break;
				case "warp 06 rotor blue":
				shipModule.displayName = "Antimatter <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Warp drive that uses unstable antimatter energy to recharge warp coils for further jump initiation. Has great spin-up time and very optimized fuel consumption.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 3000f, synthetics = 3000f, exotics = 15f };
				shipModule.Warp.activationFuel = 35;
				shipModule.Warp.reloadInterval = 25;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 39;
				break;
				case "warp 09 spideraa":
				shipModule.displayName = "Repulsor <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "Warp drive that uses kinetic energy and unknown principles to recharge warp coils for further jumping. Has amazing spin-up time and near perfect fuel consumption.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 4000f, synthetics = 4000f, exotics = 20f };
				shipModule.Warp.activationFuel = 30;
				shipModule.Warp.reloadInterval = 25;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 41;
				break;
				case "warp 07 rotor glass":
				shipModule.displayName = "Quantum <color=#" + colorDrive + "ff>Warp Drive</color>";
				shipModule.description = "This warp drive is more a hyper-drive then just a warp drive. It uses quantum energy to fold space and move through it. Has near perfect spin-up time and excellent fuel consumption.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 5000f, synthetics = 5000f, exotics = 25f };
				shipModule.Warp.activationFuel = 25;
				shipModule.Warp.reloadInterval = 20;
				shipModule.powerConsumed = 10;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 45;
				break;
				default: shipModule.displayName = "(DRIVE) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
