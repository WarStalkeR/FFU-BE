using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_HealthBays {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("dronebay 0 diy")) return idx; idx++;
			if (moduleName.Contains("dronebay 1 basic")) return idx; idx++;
			if (moduleName.Contains("medbay0 diy")) return idx; idx++;
			if (moduleName.Contains("medbay1 Rat")) return idx; idx++;
			if (moduleName.Contains("medbay2 startversion")) return idx; idx++;
			if (moduleName.Contains("medbay3 nanorepair")) return idx; idx++;
			if (moduleName.Contains("medbay5 biofluid bath")) return idx; idx++;
			if (moduleName.Contains("medbay6 biological")) return idx; idx++;
			if (moduleName.Contains("medbay4 stem celler")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("dronebay 0 diy");
				moduleList.Add("medbay0 diy");
				return moduleList;
				case 2:
				moduleList.Add("dronebay 0 diy");
				moduleList.Add("medbay0 diy");
				moduleList.Add("medbay1 Rat");
				return moduleList;
				case 3:
				moduleList.Add("dronebay 0 diy");
				moduleList.Add("medbay1 Rat");
				moduleList.Add("medbay2 startversion");
				return moduleList;
				case 4:
				moduleList.Add("dronebay 0 diy");
				moduleList.Add("medbay2 startversion");
				moduleList.Add("medbay3 nanorepair");
				return moduleList;
				case 5:
				moduleList.Add("dronebay 0 diy");
				moduleList.Add("dronebay 1 basic");
				moduleList.Add("medbay3 nanorepair");
				return moduleList;
				case 6:
				moduleList.Add("dronebay 1 basic");
				moduleList.Add("medbay3 nanorepair");
				moduleList.Add("medbay5 biofluid bath");
				return moduleList;
				case 7:
				moduleList.Add("dronebay 1 basic");
				moduleList.Add("medbay5 biofluid bath");
				moduleList.Add("medbay6 biological");
				return moduleList;
				case 8:
				moduleList.Add("dronebay 1 basic");
				moduleList.Add("medbay6 biological");
				moduleList.Add("medbay4 stem celler");
				return moduleList;
				case 9:
				moduleList.Add("dronebay 1 basic");
				moduleList.Add("medbay4 stem celler");
				return moduleList;
				case 10:
				moduleList.Add("dronebay 1 basic");
				moduleList.Add("medbay4 stem celler");
				return moduleList;
				default:
				moduleList.Add("dronebay 0 diy");
				moduleList.Add("dronebay 1 basic");
				moduleList.Add("medbay0 diy");
				moduleList.Add("medbay1 Rat");
				moduleList.Add("medbay2 startversion");
				moduleList.Add("medbay3 nanorepair");
				moduleList.Add("medbay5 biofluid bath");
				moduleList.Add("medbay6 biological");
				moduleList.Add("medbay4 stem celler");
				return moduleList;
			}
		}
		public static void UpdateHealthBayModule(ShipModule shipModule) {
			string colorCrew = "ff668c";
			string colorDrone = "ff668c";
			string colorBoth = "ff668c";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "dronebay 0 diy":
				shipModule.displayName = "Makeshift <color=#" + colorDrone + "ff>Drone Bay</color>";
				shipModule.Medbay.secondsPerHp = 5f;
				shipModule.Medbay.resourcesPerHp.synthetics = 15f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 150f, exotics = 1f };
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case "dronebay 1 basic":
				shipModule.displayName = "Industrial <color=#" + colorDrone + "ff>Drone Bay</color>";
				shipModule.Medbay.secondsPerHp = 2f;
				shipModule.Medbay.resourcesPerHp.synthetics = 5f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 2000f, synthetics = 1250f, exotics = 10f };
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 40;
				break;
				case "medbay0 diy":
				shipModule.displayName = "Makeshift <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 10f;
				shipModule.Medbay.resourcesPerHp.organics = 15f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 150f, exotics = 1f };
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case "medbay1 Rat":
				shipModule.displayName = "Ancient <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 7f;
				shipModule.Medbay.resourcesPerHp.organics = 15f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 750f, synthetics = 250f, exotics = 2f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 15;
				break;
				case "medbay2 startversion":
				shipModule.displayName = "Nanite <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 5f;
				shipModule.Medbay.resourcesPerHp.organics = 12f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 500f, exotics = 4f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 20;
				break;
				case "medbay3 nanorepair":
				shipModule.displayName = "Modern <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 3f;
				shipModule.Medbay.resourcesPerHp.organics = 10f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 750f, exotics = 6f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 30;
				break;
				case "medbay5 biofluid bath":
				shipModule.displayName = "Aura <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 2f;
				shipModule.Medbay.resourcesPerHp.organics = 7f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1500f, synthetics = 1000f, exotics = 8f };
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 35;
				break;
				case "medbay6 biological":
				shipModule.displayName = "Biotic <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 2f;
				shipModule.Medbay.resourcesPerHp.organics = 5f;
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, organics = 2000f, synthetics = 1250f, exotics = 10f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "medbay4 stem celler":
				shipModule.displayName = "Genesis <color=#" + colorBoth + "ff>Restoration Bay</color>";
				shipModule.description = "Universal restoration bay that consumes synthetics and organics at the same time to replace damaged cells & mechanic components on subatomic levels.";
				shipModule.Medbay.secondsPerHp = 1f;
				shipModule.Medbay.resourcesPerHp.organics = 2f;
				shipModule.Medbay.resourcesPerHp.synthetics = 2f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet, Crewmember.Type.Drone };
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 40;
				break;
				default: shipModule.displayName = "(HEALTH) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
