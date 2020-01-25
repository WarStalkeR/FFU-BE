using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Engines {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("engine 0 diy")) return idx; idx++;
			if (moduleName.Contains("engine 01 brittle")) return idx; idx++;
			if (moduleName.Contains("engine 01 primitive")) return idx; idx++;
			if (moduleName.Contains("engine 2 rats")) return idx; idx++;
			if (moduleName.Contains("engine 2.5 classic")) return idx; idx++;
			if (moduleName.Contains("engine 2 floral")) return idx; idx++;
			if (moduleName.Contains("engine 01 tiger")) return idx; idx++;
			if (moduleName.Contains("engine 2.5 weird")) return idx; idx++;
			if (moduleName.Contains("engine 2.5 terran")) return idx; idx++;
			if (moduleName.Contains("engine 03 emperor banks")) return idx; idx++;
			if (moduleName.Contains("engine 04 red")) return idx; idx++;
			if (moduleName.Contains("engine 03 bioship")) return idx; idx++;
			if (moduleName.Contains("engine 2 large robust")) return idx; idx++;
			if (moduleName.Contains("engine 4 spideraa")) return idx; idx++;
			if (moduleName.Contains("engine 04 xblack")) return idx; idx++;
			if (moduleName.Contains("engine 2 F-gulper")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("engine 0 diy");
				moduleList.Add("engine 01 brittle");
				moduleList.Add("engine 01 primitive");
				return moduleList;
				case 2:
				moduleList.Add("engine 01 primitive");
				moduleList.Add("engine 2 rats");
				moduleList.Add("engine 2.5 classic");
				return moduleList;
				case 3:
				moduleList.Add("engine 2.5 classic");
				moduleList.Add("engine 2 floral");
				moduleList.Add("engine 01 tiger");
				return moduleList;
				case 4:
				moduleList.Add("engine 01 tiger");
				moduleList.Add("engine 2.5 weird");
				moduleList.Add("engine 2.5 terran");
				return moduleList;
				case 5:
				moduleList.Add("engine 2.5 terran");
				moduleList.Add("engine 03 emperor banks");
				moduleList.Add("engine 04 red");
				return moduleList;
				case 6:
				moduleList.Add("engine 03 emperor banks");
				moduleList.Add("engine 04 red");
				moduleList.Add("engine 03 bioship");
				return moduleList;
				case 7:
				moduleList.Add("engine 04 red");
				moduleList.Add("engine 03 bioship");
				moduleList.Add("engine 2 large robust");
				return moduleList;
				case 8:
				moduleList.Add("engine 2 large robust");
				moduleList.Add("engine 4 spideraa");
				moduleList.Add("engine 04 xblack");
				return moduleList;
				case 9:
				moduleList.Add("engine 4 spideraa");
				moduleList.Add("engine 04 xblack");
				moduleList.Add("engine 2 F-gulper");
				return moduleList;
				case 10:
				moduleList.Add("engine 04 xblack");
				moduleList.Add("engine 2 F-gulper");
				return moduleList;
				default:
				moduleList.Add("engine 0 diy");
				moduleList.Add("engine 01 brittle");
				moduleList.Add("engine 01 primitive");
				moduleList.Add("engine 2 rats");
				moduleList.Add("engine 2.5 classic");
				moduleList.Add("engine 2 floral");
				moduleList.Add("engine 01 tiger");
				moduleList.Add("engine 2.5 weird");
				moduleList.Add("engine 2.5 terran");
				moduleList.Add("engine 03 emperor banks");
				moduleList.Add("engine 04 red");
				moduleList.Add("engine 03 bioship");
				moduleList.Add("engine 2 large robust");
				moduleList.Add("engine 4 spideraa");
				moduleList.Add("engine 04 xblack");
				moduleList.Add("engine 2 F-gulper");
				return moduleList;
			}
		}
		public static void UpdateEngineModule(ShipModule shipModule) {
			string colorEngine = "ffd24d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var shipModule_Engine_consumedPerDistance = AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "engine 0 diy":
				shipModule.displayName = "Makeshift <color=#" + colorEngine + "ff>Chemical Engine</color>";
				shipModule.description = "Assembled from the metal plates, synthetic blocks and high-tech scrap. Good alternative solution in case if ship has no engine at all. Fragile and inefficient.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 100f, synthetics = 75f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.75f };
				shipModule.asteroidDeflectionPercentAdd = 10;
				shipModule.shipEvasionPercentAdd = 1;
				shipModule.starmapSpeedAdd = 10;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 10;
				break;
				case "engine 01 brittle":
				shipModule.displayName = "Mass-Produced <color=#" + colorEngine + "ff>Chemical Engine</color>";
				shipModule.description = "Based on open-source blueprints and mass-produced. Questionable quality, low durability and completely inefficient fuel consumption leave much to be desired.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 200f, synthetics = 150f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.71f };
				shipModule.asteroidDeflectionPercentAdd = 11;
				shipModule.shipEvasionPercentAdd = 1;
				shipModule.starmapSpeedAdd = 11;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 15;
				break;
				case "engine 01 primitive":
				shipModule.displayName = "Ancient <color=#" + colorEngine + "ff>Fission Engine</color>";
				shipModule.description = "One of the first fission engines ever created. Constant usage of couple past centuries wearied it down considerably. Has somewhat mediocre performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 300f, synthetics = 275f, exotics = 1f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.67f };
				shipModule.asteroidDeflectionPercentAdd = 12;
				shipModule.shipEvasionPercentAdd = 2;
				shipModule.starmapSpeedAdd = 12;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 20;
				break;
				case "engine 2 rats":
				shipModule.displayName = "Imperial <color=#" + colorEngine + "ff>Fission Engine</color>";
				shipModule.description = "The only engine ever developed by the Rat Empire. It was designed after failing attempts to reverse salvaged fission engines. Has average performance at best.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, synthetics = 350f, exotics = 2f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.63f };
				shipModule.asteroidDeflectionPercentAdd = 13;
				shipModule.shipEvasionPercentAdd = 3;
				shipModule.starmapSpeedAdd = 13;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 25;
				break;
				case "engine 2.5 classic":
				shipModule.displayName = "Modern <color=#" + colorEngine + "ff>Fission Engine</color>";
				shipModule.description = "Most commonly manufactured fission engine. Installed on almost all decent ships. Has decent performance, decent fuel efficiency and decent durability.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 750f, synthetics = 500f, exotics = 3f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.59f };
				shipModule.asteroidDeflectionPercentAdd = 14;
				shipModule.shipEvasionPercentAdd = 4;
				shipModule.starmapSpeedAdd = 14;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 30;
				break;
				case "engine 2 floral":
				shipModule.displayName = "Organic <color=#" + colorEngine + "ff>Biochemical Engine</color>";
				shipModule.description = "Organic engine that uses unique biochemical reaction that rivals fission energy emission to generate thrust. Has very decent performance and fuel efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, organics = 1000f, synthetics = 750f, exotics = 4f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.55f };
				shipModule.asteroidDeflectionPercentAdd = 16;
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.starmapSpeedAdd = 15;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 30;
				break;
				case "engine 01 tiger":
				shipModule.displayName = "Industrial <color=#" + colorEngine + "ff>Fusion Engine</color>";
				shipModule.description = "Heavy fusion engine that mostly installed on big industrial ships that require a lot of thrust power to move. Has good performance and high durability.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1250f, synthetics = 875f, exotics = 5f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.52f };
				shipModule.asteroidDeflectionPercentAdd = 18;
				shipModule.shipEvasionPercentAdd = 6;
				shipModule.starmapSpeedAdd = 16;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 35;
				break;
				case "engine 2.5 weird":
				shipModule.displayName = "Exotic <color=#" + colorEngine + "ff>Biochemical Engine</color>";
				shipModule.description = "Organic engine with built-in exotic material matrix uses unique biochemical reaction that rivals fusion energy emission to generate thrust. Has good performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, organics = 1500f, synthetics = 1000f, exotics = 7f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.49f };
				shipModule.asteroidDeflectionPercentAdd = 20;
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.starmapSpeedAdd = 17;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 35;
				break;
				case "engine 2.5 terran":
				shipModule.displayName = "Military Navy <color=#" + colorEngine + "ff>Fusion Engine</color>";
				shipModule.description = "Very heavy and durable fusion engine that commonly utilized by serious military organizations, especially Terran Navy. Very good performance and great durability.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 800f, metals = 2000f, synthetics = 1375f, exotics = 9f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.46f };
				shipModule.asteroidDeflectionPercentAdd = 22;
				shipModule.shipEvasionPercentAdd = 8;
				shipModule.starmapSpeedAdd = 18;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 40;
				break;
				case "engine 03 emperor banks":
				shipModule.displayName = "Commercial <color=#" + colorEngine + "ff>Plasma Engine</color>";
				shipModule.description = "Engine that was developed for sake of profit and is sold to anybody who can afford it. Private manufacturing will lead to breach of copyright agreement and lawsuit.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2500f, synthetics = 1750f, exotics = 11f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.43f };
				shipModule.asteroidDeflectionPercentAdd = 24;
				shipModule.shipEvasionPercentAdd = 9;
				shipModule.starmapSpeedAdd = 19;
				shipModule.powerConsumed = 7;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 40;
				break;
				case "engine 04 red":
				shipModule.displayName = "Interceptor <color=#" + colorEngine + "ff>Plasma Engine</color>";
				shipModule.description = "Can you imagine it? Somebody managed to properly reverse engineer commercial version and recreate even better engine that not within reach of these copyright agreements.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 3000f, synthetics = 2250f, exotics = 13f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.40f };
				shipModule.asteroidDeflectionPercentAdd = 26;
				shipModule.shipEvasionPercentAdd = 10;
				shipModule.starmapSpeedAdd = 20;
				shipModule.powerConsumed = 7;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 40;
				break;
				case "engine 03 bioship":
				shipModule.displayName = "Heavy Ion <color=#" + colorEngine + "ff>Prismatic Engine</color>";
				shipModule.description = "Houses set of prismatic mirrors that accelerate speed of ion energy emission to the levels that surpass plasma energy, thus generating high thrust with great efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 3750f, synthetics = 2750f, exotics = 15f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.37f };
				shipModule.asteroidDeflectionPercentAdd = 28;
				shipModule.shipEvasionPercentAdd = 11;
				shipModule.starmapSpeedAdd = 22;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 45;
				break;
				case "engine 2 large robust":
				shipModule.displayName = "Prototype <color=#" + colorEngine + "ff>Antimatter Engine</color>";
				shipModule.description = "Prototype engine with heavy armoring to ensure stability when using antimatter energy emission to generate thrust. Has great fuel efficiency and high durability.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 4500f, synthetics = 3250f, exotics = 20f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.34f };
				shipModule.asteroidDeflectionPercentAdd = 31;
				shipModule.shipEvasionPercentAdd = 12;
				shipModule.starmapSpeedAdd = 24;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 45;
				break;
				case "engine 4 spideraa":
				shipModule.displayName = "Repulsor <color=#" + colorEngine + "ff>Meta-Kinetic Engine</color>";
				shipModule.description = "Engine that uses kinetic energy and unknown principles that rival antimatter energy emission to generate thrust. Has great performance and amazing fuel efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 2000f, metals = 5750f, synthetics = 4000f, exotics = 25f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.31f };
				shipModule.asteroidDeflectionPercentAdd = 34;
				shipModule.shipEvasionPercentAdd = 13;
				shipModule.starmapSpeedAdd = 26;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 50;
				break;
				case "engine 04 xblack":
				shipModule.displayName = "Assault <color=#" + colorEngine + "ff>Antimatter Engine</color>";
				shipModule.description = "Combat oriented engine that uses antimatter energy emission to generate thrust. Mostly installed on heavy ships that need to move fast. Has excellent performance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 2500f, metals = 6500f, synthetics = 4500f, exotics = 35f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.28f };
				shipModule.asteroidDeflectionPercentAdd = 37;
				shipModule.shipEvasionPercentAdd = 14;
				shipModule.starmapSpeedAdd = 28;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 50;
				break;
				case "engine 2 F-gulper":
				shipModule.displayName = "Particle-Folding <color=#" + colorEngine + "ff>Quantum Engine</color>";
				shipModule.description = "Experimental exploration engine that uses particle-folding quantum technology to move through interstellar void. Has amazing performance and perfect fuel efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 3000f, metals = 7500f, synthetics = 5000f, exotics = 50f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.25f };
				shipModule.asteroidDeflectionPercentAdd = 40;
				shipModule.shipEvasionPercentAdd = 15;
				shipModule.starmapSpeedAdd = 30;
				shipModule.powerConsumed = 10;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 50;
				break;
				default: shipModule.displayName = "(ENGINE) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
