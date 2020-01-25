using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Converters {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "synthetics cooker 1") return idx; idx++;
			if (moduleName == "fuel processor 1B") return idx; idx++;
			if (moduleName == "explosives combinator 1") return idx; idx++;
			if (moduleName == "fuel processor 2") return idx; idx++;
			if (moduleName == "explosives combinator tiger") return idx; idx++;
			if (moduleName == "explosives combinator diy") return idx; idx++;
			if (moduleName == "oilcake converter") return idx; idx++;
			if (moduleName == "fuel combinator 1A old") return idx; idx++;
			if (moduleName == "biotech explosives recycler") return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("synthetics cooker 1");
				return moduleList;
				case 2:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("oilcake converter");
				return moduleList;
				case 3:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("oilcake converter");
				moduleList.Add("fuel combinator 1A old");
				return moduleList;
				case 4:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("oilcake converter");
				moduleList.Add("fuel combinator 1A old");
				return moduleList;
				case 5:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("explosives combinator 1");
				moduleList.Add("explosives combinator diy");
				moduleList.Add("oilcake converter");
				moduleList.Add("fuel combinator 1A old");
				return moduleList;
				case 6:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("explosives combinator 1");
				moduleList.Add("fuel processor 2");
				moduleList.Add("explosives combinator diy");
				moduleList.Add("oilcake converter");
				moduleList.Add("fuel combinator 1A old");
				return moduleList;
				case 7:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("explosives combinator 1");
				moduleList.Add("fuel processor 2");
				moduleList.Add("explosives combinator diy");
				moduleList.Add("oilcake converter");
				moduleList.Add("biotech explosives recycler");
				return moduleList;
				case 8:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("explosives combinator 1");
				moduleList.Add("fuel processor 2");
				moduleList.Add("explosives combinator tiger");
				moduleList.Add("explosives combinator diy");
				moduleList.Add("biotech explosives recycler");
				return moduleList;
				case 9:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("explosives combinator 1");
				moduleList.Add("fuel processor 2");
				moduleList.Add("explosives combinator tiger");
				moduleList.Add("explosives combinator diy");
				moduleList.Add("biotech explosives recycler");
				return moduleList;
				case 10:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("explosives combinator 1");
				moduleList.Add("fuel processor 2");
				moduleList.Add("explosives combinator tiger");
				moduleList.Add("explosives combinator diy");
				moduleList.Add("biotech explosives recycler");
				return moduleList;
				default:
				moduleList.Add("synthetics cooker 1");
				moduleList.Add("fuel processor 1B");
				moduleList.Add("explosives combinator 1");
				moduleList.Add("fuel processor 2");
				moduleList.Add("explosives combinator tiger");
				moduleList.Add("explosives combinator diy");
				moduleList.Add("oilcake converter");
				moduleList.Add("fuel combinator 1A old");
				moduleList.Add("biotech explosives recycler");
				return moduleList;
			}
		}
		public static void UpdateConverterModule(ShipModule shipModule) {
			string colorFactory = "dbc470";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "synthetics cooker 1":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Synthetics Printer</color>";
				shipModule.description = "Converts organics into synthetics through ultrahigh temperature processing. Has built-in recipes library for tens of thousands of different substances.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { organics = 72f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { synthetics = 48f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "fuel processor 1B":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Fuel Refinery</color>";
				shipModule.description = "Combines organics and synthetics into starfuel through ultrahigh pressure processing. Has built-in data library that allows to create 100% compatible fuel."; ;
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { organics = 36f, synthetics = 36f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { fuel = 48f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "explosives combinator 1":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Ordnance Factory</color>";
				shipModule.description = "Uses starfuel and synthetics to manufacture various ordnances automatically. Has built-in blueprint library for all existing of ordnance types, including exotic ones.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { fuel = 18f, synthetics = 54f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { explosives = 48f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "fuel processor 2":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Blast Furnace</color>";
				shipModule.description = "Utilizes small amount of exotics with explosives as catalyst to process synthetics into various alloys. Has built-in data library that allows to create any possible metal.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { explosives = 9f, synthetics = 62f, exotics = 1f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { metals = 48f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "explosives combinator tiger":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Exotics XMT-Purifier</color>";
				shipModule.description = "Processes and purifies essence of all received materials into pure and stable exotic matter. Compared to other industrial facilities, has very slow production speed.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { organics = 10f, fuel = 10f, metals = 10f, synthetics = 10f, explosives = 10f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { exotics = 2f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "explosives combinator diy":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Quantum Processor</color>";
				shipModule.description = "Extremely advanced and powerful processing unit that uses quantum intangibility to analyze exotic matter and derive viable xenodata from it. Has poor production efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { exotics = 12f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { credits = 300f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "oilcake converter":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Oilcake Converter</color>";
				shipModule.description = "Purifies starfuel from hazardous elements and converts it into organics. Comes with built-in cake printer. Certified and suitable for wedding and other happy occasions.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { fuel = 48f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { organics = 48f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "fuel combinator 1A old":
				shipModule.displayName = "Industrial <color=#" + colorFactory + "ff>Ordnance Recycler</color>";
				shipModule.description = "Recycles explosives into starfuel through fail-safe processing methods.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { explosives = 48f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { fuel = 48f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 30;
				break;
				case "biotech explosives recycler":
				shipModule.displayName = "Biotic <color=#" + colorFactory + "ff>Ordnance Recycler</color>";
				shipModule.description = "Recycles explosives into organics by 'digesting' it.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, organics = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.MaterialsConverter.consume = new ResourceValueGroup { explosives = 24f };
				shipModule.MaterialsConverter.produce = new ResourceValueGroup { organics = 48f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 20;
				break;
				default: shipModule.displayName = "(CONVERTER) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
