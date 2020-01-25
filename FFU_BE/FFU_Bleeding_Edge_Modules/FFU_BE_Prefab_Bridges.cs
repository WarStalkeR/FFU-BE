using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Bridges {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "bridge 1crew DIY") return idx; idx++;
			if (moduleName == "bridge 1crew insectoid") return idx; idx++;
			if (moduleName == "bridge 1crew") return idx; idx++;
			if (moduleName == "bridge 2crew") return idx; idx++;
			if (moduleName == "bridge 2crew tiger") return idx; idx++;
			if (moduleName == "bridge 3crew") return idx; idx++;
			if (moduleName == "bridge 3crew floral") return idx; idx++;
			if (moduleName == "bridge 3crew plastarmor") return idx; idx++;
			if (moduleName == "bridge blackspider") return idx; idx++;
			if (moduleName == "bridge 3crew metalarmor") return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("bridge 1crew DIY");
				moduleList.Add("bridge 1crew insectoid");
				return moduleList;
				case 2:
				moduleList.Add("bridge 1crew DIY");
				moduleList.Add("bridge 1crew insectoid");
				moduleList.Add("bridge 1crew");
				return moduleList;
				case 3:
				moduleList.Add("bridge 1crew insectoid");
				moduleList.Add("bridge 1crew");
				moduleList.Add("bridge 2crew");
				return moduleList;
				case 4:
				moduleList.Add("bridge 1crew");
				moduleList.Add("bridge 2crew");
				moduleList.Add("bridge 2crew tiger");
				return moduleList;
				case 5:
				moduleList.Add("bridge 2crew");
				moduleList.Add("bridge 2crew tiger");
				moduleList.Add("bridge 3crew");
				return moduleList;
				case 6:
				moduleList.Add("bridge 2crew tiger");
				moduleList.Add("bridge 3crew");
				moduleList.Add("bridge 3crew floral");
				return moduleList;
				case 7:
				moduleList.Add("bridge 3crew");
				moduleList.Add("bridge 3crew floral");
				moduleList.Add("bridge 3crew plastarmor");
				return moduleList;
				case 8:
				moduleList.Add("bridge 3crew floral");
				moduleList.Add("bridge 3crew plastarmor");
				moduleList.Add("bridge blackspider");
				return moduleList;
				case 9:
				moduleList.Add("bridge 3crew plastarmor");
				moduleList.Add("bridge blackspider");
				moduleList.Add("bridge 3crew metalarmor");
				return moduleList;
				case 10:
				moduleList.Add("bridge blackspider");
				moduleList.Add("bridge 3crew metalarmor");
				return moduleList;
				default:
				moduleList.Add("bridge 1crew DIY");
				moduleList.Add("bridge 1crew insectoid");
				moduleList.Add("bridge 1crew");
				moduleList.Add("bridge 2crew");
				moduleList.Add("bridge 3crew");
				moduleList.Add("bridge 3crew floral");
				moduleList.Add("bridge 3crew plastarmor");
				moduleList.Add("bridge blackspider");
				moduleList.Add("bridge 3crew metalarmor");
				return moduleList;
			}
		}
		public static void UpdateBridgeModule(ShipModule shipModule) {
			string colorBridge = "ff794d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "bridge 1crew DIY":
				shipModule.displayName = "Makeshift <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Made from high-tech scrap and other salvage to work as at least basic command and operations center of the ship. Very limited capabilities, but still better then nothing.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f, exotics = 1f };
				shipModule.shipAccuracyPercentAdd = 2;
				shipModule.powerConsumed = 1;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 30;
				break;
				case "bridge 1crew insectoid":
				shipModule.displayName = "Ancient <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "One of the first command bridges. Manufactured centuries ago, when FTL technology was still in infancy. Due to wearied down state, its efficiency is mediocre at beast.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, synthetics = 350f, exotics = 3f };
				shipModule.shipAccuracyPercentAdd = 3;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 8;
				shipModule_maxHealth = 40;
				break;
				case "bridge 1crew":
				shipModule.displayName = "Frigate <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Standard issue command bridge that commonly used in almost all ships. Has decent processing capabilities to properly operate most of small and medium sized vessels.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 750f, synthetics = 500f, exotics = 5f };
				shipModule.shipAccuracyPercentAdd = 4;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 50;
				break;
				case "bridge 2crew":
				shipModule.displayName = "Destroyer <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Mostly manufactured for military organization per request. Often can be found installed on border patrol or interceptor ships due to good processing capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 1250f, synthetics = 850f, exotics = 7f };
				shipModule.shipAccuracyPercentAdd = 6;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 12;
				shipModule_maxHealth = 60;
				break;
				case "bridge 2crew tiger":
				shipModule.displayName = "Tactical <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Developed and manufactured by Terran Alliance on per invoice basis. Mostly installed on command and control vessels that require very specific processing capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1500f, synthetics = 100f, exotics = 8f };
				shipModule.shipAccuracyPercentAdd = 8;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 14;
				shipModule_maxHealth = 70;
				break;
				case "bridge 3crew":
				shipModule.displayName = "Cruiser <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Used at combat-oriented ships that actively participate in interstellar wars. Has proper targeting assisting modules and great warfare-oriented processing capabilities.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, metals = 2000f, synthetics = 1250f, exotics = 10f };
				shipModule.shipAccuracyPercentAdd = 10;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 16;
				shipModule_maxHealth = 80;
				break;
				case "bridge 3crew floral":
				shipModule.displayName = "Biouplink <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Command bridge of organic origin. Grown in special environment, but has full range of ports and connections to perfectly interface with almost any existing ship class.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, organics = 3000f, synthetics = 2000f, exotics = 15f };
				shipModule.shipAccuracyPercentAdd = 12;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 18;
				shipModule_maxHealth = 90;
				break;
				case "bridge 3crew plastarmor":
				shipModule.displayName = "Battleship <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Mostly installed on heavy combat vessels, where excellent warfare-oriented capabilities is a necessity. Beside excellent capabilities it is also heavily armored.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 4000f, synthetics = 2500f, exotics = 20f };
				shipModule.shipAccuracyPercentAdd = 14;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 20;
				shipModule_maxHealth = 100;
				break;
				case "bridge blackspider":
				shipModule.displayName = "Hiveworld <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Command bridge manufactured with a neural interfacing by design. Allows all operators almost unite their consciousness to exponentially increase their performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 5750f, synthetics = 3250f, exotics = 30f };
				shipModule.shipAccuracyPercentAdd = 16;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 22;
				shipModule_maxHealth = 120;
				break;
				case "bridge 3crew metalarmor":
				shipModule.displayName = "Dreadnought <color=#" + colorBridge + "ff>Command Bridge</color>";
				shipModule.description = "Needed, when ship is a hulking monstrosity armed to the utmost limit. Shielded by heavy adamantite plates to ensure that ship will continue operate under any circumstances.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 2000f, metals = 7500f, synthetics = 5000f, exotics = 50f };
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 25;
				shipModule_maxHealth = 150;
				break;
				default: shipModule.displayName = "(BRIDGE) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
