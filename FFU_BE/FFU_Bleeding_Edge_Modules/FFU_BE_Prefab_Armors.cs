using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Armors {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("integrity 0 DIY metal")) return idx; idx++;
			if (moduleName.Contains("integrity 0 DIY biotech")) return idx; idx++;
			if (moduleName.Contains("integrity 0 DIY plastic")) return idx; idx++;
			if (moduleName.Contains("integrity 0 DIY scaled")) return idx; idx++;
			if (moduleName.Contains("integrity 0 DIY carbon")) return idx; idx++;
			if (moduleName.Contains("integrity 01 bronze")) return idx; idx++;
			if (moduleName.Contains("integrity 01 silver")) return idx; idx++;
			if (moduleName.Contains("integrity 0 ancient")) return idx; idx++;
			if (moduleName.Contains("integrity 03 bio tissue")) return idx; idx++;
			if (moduleName.Contains("integrity 04 jade scales")) return idx; idx++;
			if (moduleName.Contains("integrity 05 blue scales")) return idx; idx++;
			if (moduleName.Contains("integrity 06 big green scales")) return idx; idx++;
			if (moduleName.Contains("integrity 06 spideraa")) return idx; idx++;
			if (moduleName.Contains("integrity 00 Ratty")) return idx; idx++;
			if (moduleName.Contains("integrity tiger")) return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("integrity 0 DIY metal");
				moduleList.Add("integrity 0 DIY biotech");
				moduleList.Add("integrity 0 DIY plastic");
				return moduleList;
				case 2:
				moduleList.Add("integrity 0 DIY plastic");
				moduleList.Add("integrity 0 DIY scaled");
				moduleList.Add("integrity 0 DIY carbon");
				return moduleList;
				case 3:
				moduleList.Add("integrity 0 DIY carbon");
				moduleList.Add("integrity 01 bronze");
				moduleList.Add("integrity 01 silver");
				return moduleList;
				case 4:
				moduleList.Add("integrity 01 bronze");
				moduleList.Add("integrity 01 silver");
				moduleList.Add("integrity 0 ancient");
				return moduleList;
				case 5:
				moduleList.Add("integrity 01 silver");
				moduleList.Add("integrity 0 ancient");
				moduleList.Add("integrity 03 bio tissue");
				return moduleList;
				case 6:
				moduleList.Add("integrity 03 bio tissue");
				moduleList.Add("integrity 04 jade scales");
				moduleList.Add("integrity 05 blue scales");
				return moduleList;
				case 7:
				moduleList.Add("integrity 05 blue scales");
				moduleList.Add("integrity 06 big green scales");
				moduleList.Add("integrity 06 spideraa");
				return moduleList;
				case 8:
				moduleList.Add("integrity 06 spideraa");
				moduleList.Add("integrity 00 Ratty");
				moduleList.Add("integrity tiger");
				return moduleList;
				case 9:
				moduleList.Add("integrity 06 spideraa");
				moduleList.Add("integrity 00 Ratty");
				moduleList.Add("integrity tiger");
				return moduleList;
				case 10:
				moduleList.Add("integrity 00 Ratty");
				moduleList.Add("integrity tiger");
				return moduleList;
				default:
				moduleList.Add("integrity 0 DIY metal");
				moduleList.Add("integrity 0 DIY biotech");
				moduleList.Add("integrity 0 DIY plastic");
				moduleList.Add("integrity 0 DIY scaled");
				moduleList.Add("integrity 0 DIY carbon");
				moduleList.Add("integrity 01 bronze");
				moduleList.Add("integrity 01 silver");
				moduleList.Add("integrity 0 ancient");
				moduleList.Add("integrity 03 bio tissue");
				moduleList.Add("integrity 04 jade scales");
				moduleList.Add("integrity 05 blue scales");
				moduleList.Add("integrity 06 big green scales");
				moduleList.Add("integrity 06 spideraa");
				moduleList.Add("integrity 00 Ratty");
				moduleList.Add("integrity tiger");
				return moduleList;
			}
		}
		public static void UpdateArmorModule(ShipModule shipModule) {
			string colorArmor = "dbdb70";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "integrity 0 DIY metal":
				shipModule.displayName = "Makeshift <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from metal scrap and other useless junk. While it provides very basic degree of protection, it is still better then nothing at all.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 100f };
				shipModule.asteroidDeflectionPercentAdd = 5;
				shipModule.shipEvasionPercentAdd = -1;
				shipModule.maxHealthAdd = 30;
				shipModule_maxHealth = 60;
				break;
				case "integrity 0 DIY biotech":
				shipModule.displayName = "Organic <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from compressed simple organic fiber. Just a little bit better then makeshift integrity armor, but better nonetheless.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, organics = 300f, synthetics = 125f };
				shipModule.asteroidDeflectionPercentAdd = 6;
				shipModule.shipEvasionPercentAdd = -1;
				shipModule.maxHealthAdd = 40;
				shipModule_maxHealth = 68;
				break;
				case "integrity 0 DIY plastic":
				shipModule.displayName = "Synthetic <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from semi-elastic synthetic plates. Provides more or less decent degree of protection, but still far cry from proper integrity armor.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 50f, synthetics = 450f };
				shipModule.asteroidDeflectionPercentAdd = 8;
				shipModule.shipEvasionPercentAdd = -1;
				shipModule.maxHealthAdd = 50;
				shipModule_maxHealth = 76;
				break;
				case "integrity 0 DIY scaled":
				shipModule.displayName = "Composite <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from multiple metal-synthetic composite layers, thus has decent flexibility and durability. Provides decent degree of protection.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 175f, metals = 500f, synthetics = 250f };
				shipModule.asteroidDeflectionPercentAdd = 10;
				shipModule.shipEvasionPercentAdd = -2;
				shipModule.maxHealthAdd = 60;
				shipModule_maxHealth = 84;
				break;
				case "integrity 0 DIY carbon":
				shipModule.displayName = "Carboninte <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from thin synthesized carbon-fiber layers. Has good durability and light weight. Provides decent degree of protection.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 225f, metals = 300f, synthetics = 300f, organics = 300f, exotics = 1f };
				shipModule.asteroidDeflectionPercentAdd = 12;
				shipModule.shipEvasionPercentAdd = -2;
				shipModule.maxHealthAdd = 70;
				shipModule_maxHealth = 92;
				break;
				case "integrity 01 bronze":
				shipModule.displayName = "Reactive <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from metallic segments filled with mini-explosive packages that detonate on projectile's impact and use released energy to divert incoming kinetic force.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 600f, synthetics = 400f, explosives = 100f, exotics = 1f };
				shipModule.asteroidDeflectionPercentAdd = 14;
				shipModule.shipEvasionPercentAdd = -3;
				shipModule.maxHealthAdd = 85;
				shipModule_maxHealth = 100;
				break;
				case "integrity 01 silver":
				shipModule.displayName = "Titanite <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from multiple layers of tempered titanium alloy. Production and maintenance costs are higher then normal, but provides good degree of protection.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 375f, metals = 1000f, synthetics = 500f, exotics = 2f };
				shipModule.asteroidDeflectionPercentAdd = 16;
				shipModule.shipEvasionPercentAdd = -3;
				shipModule.maxHealthAdd = 100;
				shipModule_maxHealth = 110;
				break;
				case "integrity 0 ancient":
				shipModule.displayName = "Ceramite <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from heavily tempered overlapped ceramic plates. Provides good degree of protection. Partially erased bluish omega symbols can be seen at some places.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 450f, metals = 1250f, synthetics = 750f, organics = 500f, exotics = 3f };
				shipModule.asteroidDeflectionPercentAdd = 19;
				shipModule.shipEvasionPercentAdd = -4;
				shipModule.maxHealthAdd = 120;
				shipModule_maxHealth = 120;
				break;
				case "integrity 03 bio tissue":
				shipModule.displayName = "Biontite <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from multiple interconnected living microfibers. Has good flexibility and provides very degree of protection. Don't worry, it won't spawn creep.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 550f, metals = 250f, synthetics = 1250f, organics = 1500f, exotics = 4f };
				shipModule.asteroidDeflectionPercentAdd = 22;
				shipModule.shipEvasionPercentAdd = -4;
				shipModule.maxHealthAdd = 140;
				shipModule_maxHealth = 130;
				break;
				case "integrity 04 jade scales":
				shipModule.displayName = "Refractive <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from special segments that use explosive kinetic energy to dampen incoming kinetic force with receiving damage. Provides serious degree of protection.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 700f, metals = 1750f, synthetics = 1500f, explosives = 250f, exotics = 5f };
				shipModule.asteroidDeflectionPercentAdd = 25;
				shipModule.shipEvasionPercentAdd = -5;
				shipModule.maxHealthAdd = 165;
				shipModule_maxHealth = 140;
				break;
				case "integrity 05 blue scales":
				shipModule.displayName = "Crystalline <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from unknown beautiful crystalline fibers that can store ambient energy to strengthen itself even further. Provides great degree of protection.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 850f, metals = 2250f, synthetics = 1750f, exotics = 7f };
				shipModule.asteroidDeflectionPercentAdd = 28;
				shipModule.shipEvasionPercentAdd = -5;
				shipModule.maxHealthAdd = 190;
				shipModule_maxHealth = 150;
				break;
				case "integrity 06 big green scales":
				shipModule.displayName = "Dragonscale <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from unknown material of organic origin that has great durability and flexibility at the same time. Equipping it won't turn your ship into dragon slayer.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 1500f, synthetics = 1500f, organics = 2000f, exotics = 10f };
				shipModule.asteroidDeflectionPercentAdd = 32;
				shipModule.shipEvasionPercentAdd = -6;
				shipModule.maxHealthAdd = 215;
				shipModule_maxHealth = 160;
				break;
				case "integrity 06 spideraa":
				shipModule.displayName = "Megacyte <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from material with unknown properties that has quite an aggressive external appearance. Lack of aesthetics doesn't make it any less durable.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 2500f, synthetics = 3500f, explosives = 500f, exotics = 15f };
				shipModule.asteroidDeflectionPercentAdd = 36;
				shipModule.shipEvasionPercentAdd = -7;
				shipModule.maxHealthAdd = 240;
				shipModule_maxHealth = 180;
				break;
				case "integrity 00 Ratty":
				shipModule.displayName = "Adamantite <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Made from strongest existing alloy that was ripped off from something that resembles interstellar drifting gothic cathedral. Provides immense degree of protection.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 4500f, synthetics = 2500f, exotics = 20f };
				shipModule.asteroidDeflectionPercentAdd = 40;
				shipModule.shipEvasionPercentAdd = -8;
				shipModule.maxHealthAdd = 270;
				shipModule_maxHealth = 200;
				break;
				case "integrity tiger":
				shipModule.displayName = "Nanometric <color=#" + colorArmor + "ff>Integrity Armor</color>";
				shipModule.description = "Experimental armor made from active nanomachines that almost instantly react to any type of incoming damage to negate it. Provides immense degree of protection.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 5000f, synthetics = 3500f, exotics = 25f };
				shipModule.asteroidDeflectionPercentAdd = 50;
				shipModule.shipEvasionPercentAdd = -10;
				shipModule.maxHealthAdd = 300;
				shipModule_maxHealth = 225;
				break;
				default: shipModule.displayName = "(ARMOR) " + shipModule.displayName; break;
			}
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
