using RST;
using HarmonyLib;
using System.Reflection;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Miscellaneous {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "artifactmodule tec 33 biostasis nice worm") return idx; idx++;
			if (moduleName == "artifactmodule tec 11 biostasis") return idx; idx++;
			if (moduleName == "artifactmodule tec 17 broken screen gizmo, data") return idx; idx++;
			if (moduleName == "artifactmodule tec 25 broken screen gizmo") return idx; idx++;
			if (moduleName == "artifactmodule tec 32 broken container gizmo") return idx; idx++;
			if (moduleName == "artifactmodule tec 37 ripped quarter of a dome") return idx; idx++;
			if (moduleName == "artifactmodule tec 36 broken gizmo") return idx; idx++;
			if (moduleName == "artifactmodule tec 34 data core grammofon") return idx; idx++;
			if (moduleName == "artifactmodule tec 35 data core makk") return idx; idx++;
			if (moduleName == "artifactmodule nat bluecrystal") return idx; idx++;
			if (moduleName == "artifactmodule nat eleriumite") return idx; idx++;
			if (moduleName == "artifactmodule nat rahn") return idx; idx++;
			if (moduleName == "artifactmodule nat redcrystal") return idx; idx++;
			if (moduleName == "artifactmodule nat whitecrystal") return idx; idx++;
			if (moduleName == "artifactmodule nat young eleriumite") return idx; idx++;
			if (moduleName == "artifactmodule10 rahn tutorial") return idx; idx++;
			if (moduleName == "artifactmodule nat bone") return idx; idx++;
			if (moduleName == "artifactmodule nat skull") return idx; idx++;
			if (moduleName == "artifactmodule nat fossilbug") return idx; idx++;
			//if (moduleName == "artifactmodule tec 33 biostasis nice worm") return idx; idx++;
			//if (moduleName == "artifactmodule tec 11 biostasis") return idx; idx++;
			//if (moduleName == "artifactmodule tec 17 broken screen gizmo, data") return idx; idx++;
			//if (moduleName == "artifactmodule tec 25 broken screen gizmo") return idx; idx++;
			//if (moduleName == "artifactmodule tec 32 broken container gizmo") return idx; idx++;
			//if (moduleName == "artifactmodule tec 37 ripped quarter of a dome") return idx; idx++;
			//if (moduleName == "artifactmodule tec 36 broken gizmo") return idx; idx++;
			//if (moduleName == "artifactmodule tec 34 data core grammofon") return idx; idx++;
			//if (moduleName == "artifactmodule tec 35 data core makk") return idx; idx++;
			if (moduleName == "artifactmodule tec 24 broken warp gizmo ECM") return idx; idx++;
			if (moduleName == "artifactmodule tec 31 data core node small lamp dome") return idx; idx++;
			if (moduleName == "artifactmodule tec biotech eyeball asteroid predictor") return idx; idx++;
			if (moduleName == "artifactmodule tec 21 data core rectangle gizmo") return idx; idx++;
			if (moduleName == "artifactmodule tec 12 data square gizmo with minidomes") return idx; idx++;
			if (moduleName == "artifactmodule tec screamer egg ECM") return idx; idx++;
			if (moduleName == "artifactmodule tec green slime integrity") return idx; idx++;
			if (moduleName == "artifactmodule tec metal rainbow integrity") return idx; idx++;
			if (moduleName == "artifactmodule tec 22 metal synt gizmo ECM") return idx; idx++;
			if (moduleName == "artifactmodule tec 23 metal gizmo with light") return idx; idx++;
			if (moduleName == "artifactmodule tec 28 data core giant chip ECM internal") return idx; idx++;
			if (moduleName == "artifactmodule tec 39 accuracy advanced data core") return idx; idx++;
			if (moduleName == "artifactmodule tec engine booster 1") return idx; idx++;
			if (moduleName == "artifactmodule tec 38 accuracy datacore manysquares") return idx; idx++;
			if (moduleName == "artifactmodule tec 13 data core brassdome ECM") return idx; idx++;
			if (moduleName == "artifactmodule tec engine booster 2") return idx; idx++;
			if (moduleName == "artifactmodule tec ingergity and asteroid predictor") return idx; idx++;
			if (moduleName == "long range sensor 2 old (tutorial, not saveable)") return idx; idx++;
			if (moduleName == "bossweapon insectoid ship") return idx; idx++;
			if (moduleName == "bossweapon weirdaxer") return idx; idx++;
			if (moduleName == "storage container 3x4") return idx; idx++;
			return 999;
		}
		public static void UpdateMsicModule(ShipModule shipModule) {
			string colorCache = "add8e6";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			shipModule.asteroidDeflectionPercentAdd = 0;
			shipModule.shipAccuracyPercentAdd = 0;
			shipModule.shipEvasionPercentAdd = 0;
			shipModule.starmapSpeedAdd = 0;
			shipModule.maxHealthAdd = 0;
			shipModule.powerConsumed = 0;
			switch (Core.GetOriginalName(shipModule.name)) {
				case "artifactmodule tec 33 biostasis nice worm":
				shipModule.displayName = "Mechanical <color=#" + colorCache + "ff>Upgrades</color> Cache";
				shipModule.description = "Upgrades cache that contains upgrades sets that increase health of drones and robots by certain amount. To apply: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, exotics = 10f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 11 biostasis":
				shipModule.displayName = "Biological <color=#" + colorCache + "ff>Implants</color> Cache";
				shipModule.description = "Implants cache that contains implant sets that increase health of biological crewmembers by certain amount. To apply: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, organics = 500f, exotics = 10f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 17 broken screen gizmo, data":
				shipModule.displayName = "CQC Class <color=#" + colorCache + "ff>Weapons</color> Cache";
				shipModule.description = "Weapon cache that contains full sets of Power Fists, Dual Welders, Napalm Guns and Toxic Guns. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 500f, synthetics = 500f, explosives = 500f, exotics = 15f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 25 broken screen gizmo":
				shipModule.displayName = "Kinetic Type <color=#" + colorCache + "ff>Weapons</color> Cache";
				shipModule.description = "Weapon cache that contains full sets of Revolvers, Pistols, SMGs, Shotguns, Rifles, Autocannon, Breacher Cannons and Railguns. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 250f, explosives = 500f, exotics = 10f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 32 broken container gizmo":
				shipModule.displayName = "Laser Type <color=#" + colorCache + "ff>Weapons</color> Cache";
				shipModule.description = "Weapon cache that contains full sets of Laser Pistols, Laser Rifles and Laser Cannons. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 750f, synthetics = 1250f, exotics = 15f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 37 ripped quarter of a dome":
				shipModule.displayName = "Energy Type <color=#" + colorCache + "ff>Weapons</color> Cache";
				shipModule.description = "Weapon cache that contains full sets of Blaster Pistols, Blaster Rifles, Warp Ray Guns and Particle Guns. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 750f, synthetics = 1250f, exotics = 20f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 36 broken gizmo":
				shipModule.displayName = "Backup Class <color=#" + colorCache + "ff>Weapons</color> Cache";
				shipModule.description = "Weapon cache that contains full sets Revolvers, Assault Pistols and Laser Pistols. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 750f, synthetics = 250f, explosives = 250f, exotics = 5f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 34 data core grammofon":
				shipModule.displayName = "Tactical Class <color=#" + colorCache + "ff>Weapons</color> Cache";
				shipModule.description = "Weapon cache that contains full sets Assault SMGs, Assault Rifles, Assault Shotguns and Laser Rifles. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 500f, explosives = 500f, exotics = 15f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 35 data core makk":
				shipModule.displayName = "Assault Class <color=#" + colorCache + "ff>Weapons</color> Cache";
				shipModule.description = "Weapon cache that contains full sets Autocannons, Breacher Cannons, Assault Railguns and Laser Cannons. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 2000f, synthetics = 1000f, explosives = 1000f, exotics = 25f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule nat bluecrystal":
				shipModule.displayName = "Yellow Exotic Crystal";
				shipModule.scrapGet = new ResourceValueGroup { metals = 2000f, exotics = 100f, credits = 500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat eleriumite":
				shipModule.displayName = "Volatile Crystal";
				shipModule.scrapGet = new ResourceValueGroup { fuel = 2000f, explosives = 3000f, credits = 375f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat rahn":
				shipModule.displayName = "Beige Exotic Crystal";
				shipModule.scrapGet = new ResourceValueGroup { fuel = 1750f, exotics = 75f, credits = 750f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat redcrystal":
				shipModule.displayName = "Lilac Exotic Crystal";
				shipModule.scrapGet = new ResourceValueGroup { synthetics = 2000f, exotics = 150f, credits = 1750f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat whitecrystal":
				shipModule.displayName = "White Exotic Crystal";
				shipModule.scrapGet = new ResourceValueGroup { fuel = 1000f, metals = 1500f, exotics = 125, credits = 2500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat young eleriumite":
				shipModule.displayName = "Eleriumite Crystal";
				shipModule.scrapGet = new ResourceValueGroup { fuel = 1500f, metals = 1250f, explosives = 2500f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule10 rahn tutorial":
				shipModule.displayName = "Solidified Exotic Essence";
				shipModule.scrapGet = new ResourceValueGroup { exotics = 750f, credits = 7500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat bone":
				shipModule.displayName = "Fossilized Bone";
				shipModule.scrapGet = new ResourceValueGroup { organics = 1750f, metals = 1250f, exotics = 50f, credits = 1500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat skull":
				shipModule.displayName = "Fossilized Skull";
				shipModule.scrapGet = new ResourceValueGroup { organics = 1750f, synthetics = 1250f, exotics = 50f, credits = 1500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "artifactmodule nat fossilbug":
				shipModule.displayName = "Fossilized Insectoid";
				shipModule.scrapGet = new ResourceValueGroup { organics = 1750f, explosives = 1250f, exotics = 50f, credits = 1500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				/*case "artifactmodule tec 33 biostasis nice worm":
				shipModule.displayName = "Light Biostasis Unit";
				shipModule.scrapGet = new ResourceValueGroup { organics = 2500f, explosives = 750f, metals = 750f, synthetics = 750f, exotics = 25f, credits = 1750f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 11 biostasis":
				shipModule.displayName = "Heavy Biostasis Unit";
				shipModule.scrapGet = new ResourceValueGroup { organics = 3750f, explosives = 1250f, metals = 1250f, synthetics = 1250f, exotics = 50f, credits = 2500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 17 broken screen gizmo, data":
				shipModule.displayName = "Data Projector Device";
				shipModule.scrapGet = new ResourceValueGroup { metals = 2000f, synthetics = 1000f, fuel = 750f, exotics = 35f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 25 broken screen gizmo":
				shipModule.displayName = "Active Matrix Device";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1000f, synthetics = 2000f, fuel = 750f, exotics = 35f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 32 broken container gizmo":
				shipModule.displayName = "Sealed Container Device";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1000f, synthetics = 1000f, fuel = 1750f, exotics = 35f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 37 ripped quarter of a dome":
				shipModule.displayName = "Broken External Shielding";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1750f, synthetics = 750f, exotics = 25f, credits = 500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 36 broken gizmo":
				shipModule.displayName = "Broken Temporal Coils";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1750f, synthetics = 750f, exotics = 25f, credits = 500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 34 data core grammofon":
				shipModule.displayName = "Antique Memory Unit";
				shipModule.scrapGet = new ResourceValueGroup { metals = 750f, synthetics = 1250f, exotics = 5f, credits = 5000f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 35 data core makk":
				shipModule.displayName = "Ancient Memory Unit";
				shipModule.scrapGet = new ResourceValueGroup { metals = 750f, synthetics = 1250f, exotics = 5f, credits = 5000f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;*/
				case "artifactmodule tec 24 broken warp gizmo ECM":
				shipModule.displayName = "Damaged Warp Coils";
				shipModule.scrapGet = new ResourceValueGroup { synthetics = 1250f, exotics = 15f, credits = 1750f };
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 31 data core node small lamp dome":
				shipModule.displayName = "External Observation Unit";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1250f, exotics = 15f, credits = 1750f };
				shipModule.maxHealthAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec biotech eyeball asteroid predictor":
				shipModule.displayName = "Asteroid Prediction Unit";
				shipModule.scrapGet = new ResourceValueGroup { organics = 1250f, exotics = 15f, credits = 1750f };
				shipModule.asteroidDeflectionPercentAdd = 10;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 21 data core rectangle gizmo":
				shipModule.displayName = "Solid State Data Core";
				shipModule.scrapGet = new ResourceValueGroup { metals = 750f, synthetics = 2750f, exotics = 10f, credits = 1250f };
				shipModule.maxHealthAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec 12 data square gizmo with minidomes":
				shipModule.displayName = "Matrix Data Core";
				shipModule.scrapGet = new ResourceValueGroup { metals = 2750f, synthetics = 750f, exotics = 10f, credits = 1250f };
				shipModule.maxHealthAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec screamer egg ECM":
				shipModule.displayName = "Organic Disruption Emitter";
				shipModule.scrapGet = new ResourceValueGroup { organics = 2750f, synthetics = 1750f, exotics = 15f, credits = 2250f };
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case "artifactmodule tec green slime integrity":
				shipModule.displayName = "Pseudo-Creep Coating Array";
				shipModule.scrapGet = new ResourceValueGroup { organics = 3750f, synthetics = 1250f, exotics = 5f, credits = 2000f };
				shipModule.maxHealthAdd = 25;
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 125;
				break;
				case "artifactmodule tec metal rainbow integrity":
				shipModule.displayName = "Prismatic Mirror Array";
				shipModule.scrapGet = new ResourceValueGroup { metals = 3750f, synthetics = 1250f, exotics = 5f, credits = 2000f };
				shipModule.maxHealthAdd = 25;
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 125;
				break;
				case "artifactmodule tec 22 metal synt gizmo ECM":
				shipModule.displayName = "Dampener Data Core";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1250f, synthetics = 1250f, exotics = 15f, credits = 2500f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 23 metal gizmo with light":
				shipModule.displayName = "Suppressor Data Core";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1250f, synthetics = 1250f, exotics = 15f, credits = 2500f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 28 data core giant chip ECM internal":
				shipModule.displayName = "Processing Data Core";
				shipModule.scrapGet = new ResourceValueGroup { metals = 500f, synthetics = 2000f, exotics = 15f, credits = 2500f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 39 accuracy advanced data core":
				shipModule.displayName = "Enumeration Processing Unit";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1500f, synthetics = 1000f, exotics = 15f, credits = 2500f };
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec engine booster 1":
				shipModule.displayName = "Fuel Optimization Unit";
				shipModule.scrapGet = new ResourceValueGroup { metals = 2000f, synthetics = 500f, exotics = 15f, credits = 2500f };
				shipModule.starmapSpeedAdd = 5f;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case "artifactmodule tec 38 accuracy datacore manysquares":
				shipModule.displayName = "Array Processing Unit";
				shipModule.scrapGet = new ResourceValueGroup { metals = 1000f, synthetics = 4000f, exotics = 25f, credits = 5000f };
				shipModule.shipAccuracyPercentAdd = 40;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case "artifactmodule tec 13 data core brassdome ECM":
				shipModule.displayName = "Disruptor Data Core";
				shipModule.scrapGet = new ResourceValueGroup { metals = 3500f, synthetics = 1500f, exotics = 25f, credits = 5000f };
				shipModule.shipEvasionPercentAdd = 10;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case "artifactmodule tec engine booster 2":
				shipModule.displayName = "Engine Thermal Shielding";
				shipModule.scrapGet = new ResourceValueGroup { metals = 4000f, synthetics = 1000f, exotics = 25f, credits = 5000f };
				shipModule.starmapSpeedAdd = 10;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case "artifactmodule tec ingergity and asteroid predictor":
				shipModule.displayName = "Collision Detection Unit";
				shipModule.scrapGet = new ResourceValueGroup { metals = 2500f, synthetics = 2500f, exotics = 25f, credits = 5000f };
				shipModule.asteroidDeflectionPercentAdd = 50;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case "storage container 3x4":
				shipModule.displayName = "Modular Storage Compartment";
				shipModule.description = "Universal storage unit that stores disassembled modules in highly compact form and requires quite some time to assemble them back. Also holds answer to the Ultimate Question of Life, the Universe, and Everything.";
				shipModule.Storage.slotCount = 12;
				shipModule.Storage.gridWorldSpacing = 0.0064f;
				shipModule.type = ShipModule.Type.Storage;
				shipModule_maxHealth = 1000;
				typeof(StorageModule).GetField("modulePositionsInGrid", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, new int[] {
					-89,   98,  -45,   98,    0,   98,   45,   98,  90,   98,  141,   98,  183,   98,
					-89,    0,  -45,    0,    0,    0,   45,    0,  90,    0,  141,    0,  183,    0,
					-89, - 98,  -45, - 98,    0, - 98,   45, - 98,  90, - 98,  141, - 98,  183, - 98,
					-89,   49,  -45,   49,    0,   49,   45,   49,  90,   49,  141,   49,  183,   49,
					-89,  -49,  -45,  -49,    0,  -49,   45,  -49,  90,  -49,  141,  -49,  183,  -49,
					-89,    1,  -45,    1,    0,    1,   45,    1,  90,    1,  141,    1,  183,    1,
					-88,   98,  -44,   98,    1,   98,   44,   98,  91,   98,  142,   98,  184,   98,
					-88,    0,  -44,    0,    1,    0,   44,    0,  91,    0,  142,    0,  184,    0,
					-88, - 98,  -44, - 98,    1, - 98,   44, - 98,  91, - 98,  142, - 98,  184, - 98,
					-88,   49,  -44,   49,    1,   49,   44,   49,  91,   49,  142,   49,  184,   49,
					-88,  -49,  -44,  -49,    1,  -49,   44,  -49,  91,  -49,  142,  -49,  184,  -49,
					-88,    1,  -44,    1,    1,    1,   44,    1,  91,    1,  142,    1,  184,    1,
					-87,   98,  -43,   98,    2,   98,   43,   98,  92,   98,  143,   98,  185,   98,
					-87,    0,  -43,    0,    2,    0,   43,    0,  92,    0,  143,    0,  185,    0,
					-87, - 98,  -43, - 98,    2, - 98,   43, - 98,  92, - 98,  143, - 98,  185, - 98,
					-87,   49,  -43,   49,    2,   49,   43,   49,  92,   49,  143,   49,  185,   49,
					-87,  -49,  -43,  -49,    2,  -49,   43,  -49,  92,  -49,  143,  -49,  185,  -49,
					-87,    1,  -43,    1,    2,    1,   43,    1,  92,    1,  143,    1,  185,    1,
					-86,   98,  -42,   98,    3,   98,   42,   98,  93,   98,  144,   98,  186,   98,
					-86,    0,  -42,    0,    3,    0,   42,    0,  93,    0,  144,    0,  186,    0,
					-86, - 98,  -42, - 98,    3, - 98,   42, - 98,  93, - 98,  144, - 98,  186, - 98,
					-86,   49,  -42,   49,    3,   49,   42,   49,  93,   49,  144,   49,  186,   49,
					-86,  -49,  -42,  -49,    3,  -49,   42,  -49,  93,  -49,  144,  -49,  186,  -49,
					-86,    1,  -42,    1,    3,    1,   42,    1,  93,    1,  144,    1,  186,    1,
					-85,   98,  -41,   98,    4,   98,   41,   98,  94,   98,  145,   98,  187,   98,
					-85,    0,  -41,    0,    4,    0,   41,    0,  94,    0,  145,    0,  187,    0,
					-85, - 98,  -41, - 98,    4, - 98,   41, - 98,  94, - 98,  145, - 98,  187, - 98,
					-85,   49,  -41,   49,    4,   49,   41,   49,  94,   49,  145,   49,  187,   49,
					-85,  -49,  -41,  -49,    4,  -49,   41,  -49,  94,  -49,  145,  -49,  187,  -49,
					-85,    1,  -41,    1,    4,    1,   41,    1,  94,    1,  145,    1,  187,    1,
				});
				break;
				default: shipModule.displayName = "(MISC) " + shipModule.displayName; break;
			}
			if (shipModule.type != ShipModule.Type.Storage && !shipModule.displayName.Contains("Cache")) {
				shipModule.craftCost.fuel = shipModule.scrapGet.fuel * 2;
				shipModule.craftCost.organics = shipModule.scrapGet.organics * 2;
				shipModule.craftCost.synthetics = shipModule.scrapGet.synthetics * 2;
				shipModule.craftCost.metals = shipModule.scrapGet.metals * 2;
				shipModule.craftCost.explosives = shipModule.scrapGet.explosives * 2;
				shipModule.craftCost.exotics = shipModule.scrapGet.exotics * 2;
			}
			FFU_BE_Mod_Modules.UpdateCommonStatsCore(shipModule);
		}
	}
}
