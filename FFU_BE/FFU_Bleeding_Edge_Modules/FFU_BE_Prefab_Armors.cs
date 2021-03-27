using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Armors {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 429768775) return idx; idx++; //integrity 0 DIY metal
			if (moduleID == 1030243901) return idx; idx++; //integrity 0 DIY biotech
			if (moduleID == 1391715479) return idx; idx++; //integrity 0 DIY plastic
			if (moduleID == 1683167527) return idx; idx++; //integrity 0 DIY scaled
			if (moduleID == 1626770136) return idx; idx++; //integrity 0 DIY carbon
			if (moduleID == 1955952396) return idx; idx++; //integrity 01 bronze
			if (moduleID == 786297542) return idx; idx++; //integrity 01 silver
			if (moduleID == 786297541) return idx; idx++; //integrity 0 ancient
			if (moduleID == 1152326902) return idx; idx++; //integrity 01 bio tissue
			if (moduleID == 716815312) return idx; idx++; //integrity 04 jade scales
			if (moduleID == 2071389332) return idx; idx++; //integrity 05 blue scales
			if (moduleID == 1152328828) return idx; idx++; //integrity 06 big green scales
			if (moduleID == 989518264) return idx; idx++; //integrity 06 spideraa
			if (moduleID == 786297539) return idx; idx++; //integrity 00 Ratty
			if (moduleID == 1196638242) return idx; idx++; //integrity tiger
			return idx + 100;
		}
		public static void UpdateArmorModule(ShipModule shipModule, bool initItemData) {
			string colorArmor = "dbdb70";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 429768775: //integrity 0 DIY metal
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from metal scrap and other useless junk. While it provides very basic degree of protection, it is still better then nothing at all.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 100f };
				shipModule.asteroidDeflectionPercentAdd = 5;
				shipModule.shipEvasionPercentAdd = -1;
				shipModule.maxHealthAdd = 30;
				shipModule_maxHealth = 60;
				break;
				case 1030243901: //integrity 0 DIY biotech
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Organic <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from compressed simple organic fiber. Just a little bit better then makeshift integrity armor, but better nonetheless.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, organics = 300f, synthetics = 125f };
				shipModule.asteroidDeflectionPercentAdd = 6;
				shipModule.shipEvasionPercentAdd = -1;
				shipModule.maxHealthAdd = 40;
				shipModule_maxHealth = 68;
				break;
				case 1391715479: //integrity 0 DIY plastic
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Synthetic <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from semi-elastic synthetic plates. Provides more or less decent degree of protection, but still far cry from proper integrity armor.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 50f, synthetics = 450f };
				shipModule.asteroidDeflectionPercentAdd = 8;
				shipModule.shipEvasionPercentAdd = -1;
				shipModule.maxHealthAdd = 50;
				shipModule_maxHealth = 76;
				break;
				case 1683167527: //integrity 0 DIY scaled
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Composite <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from multiple metal-synthetic composite layers, thus has decent flexibility and durability. Provides decent degree of protection.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 175f, metals = 500f, synthetics = 250f };
				shipModule.asteroidDeflectionPercentAdd = 10;
				shipModule.shipEvasionPercentAdd = -2;
				shipModule.maxHealthAdd = 60;
				shipModule_maxHealth = 84;
				break;
				case 1626770136: //integrity 0 DIY carbon
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Carboninte <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from thin synthesized carbon-fiber layers. Has good durability and light weight. Provides decent degree of protection.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 225f, metals = 300f, synthetics = 300f, organics = 300f, exotics = 1f };
				shipModule.asteroidDeflectionPercentAdd = 12;
				shipModule.shipEvasionPercentAdd = -2;
				shipModule.maxHealthAdd = 70;
				shipModule_maxHealth = 92;
				break;
				case 1955952396: //integrity 01 bronze
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Reactive <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from metallic segments filled with mini-explosive packages that detonate on projectile's impact and use released energy to divert incoming kinetic force.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 600f, synthetics = 400f, explosives = 100f, exotics = 1f };
				shipModule.asteroidDeflectionPercentAdd = 14;
				shipModule.shipEvasionPercentAdd = -3;
				shipModule.maxHealthAdd = 85;
				shipModule_maxHealth = 100;
				break;
				case 786297542: //integrity 01 silver
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Titanite <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from multiple layers of tempered titanium alloy. Production and maintenance costs are higher then normal, but provides good degree of protection.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 375f, metals = 1000f, synthetics = 500f, exotics = 2f };
				shipModule.asteroidDeflectionPercentAdd = 16;
				shipModule.shipEvasionPercentAdd = -3;
				shipModule.maxHealthAdd = 100;
				shipModule_maxHealth = 110;
				break;
				case 786297541: //integrity 0 ancient
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Ceramite <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from heavily tempered overlapped ceramic plates. Provides good degree of protection. Partially erased bluish omega symbols can be seen at some places.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 450f, metals = 1250f, synthetics = 750f, organics = 500f, exotics = 3f };
				shipModule.asteroidDeflectionPercentAdd = 19;
				shipModule.shipEvasionPercentAdd = -4;
				shipModule.maxHealthAdd = 120;
				shipModule_maxHealth = 120;
				break;
				case 1152326902: //integrity 01 bio tissue
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Biontite <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from multiple interconnected living microfibers. Has good flexibility and provides very degree of protection. Don't worry, it won't spawn creep.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 550f, metals = 250f, synthetics = 1250f, organics = 1500f, exotics = 4f };
				shipModule.asteroidDeflectionPercentAdd = 22;
				shipModule.shipEvasionPercentAdd = -4;
				shipModule.maxHealthAdd = 140;
				shipModule_maxHealth = 130;
				break;
				case 716815312: //integrity 04 jade scales
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Refractive <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from special segments that use explosive kinetic energy to dampen incoming kinetic force with receiving damage. Provides serious degree of protection.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 700f, metals = 1750f, synthetics = 1500f, explosives = 250f, exotics = 5f };
				shipModule.asteroidDeflectionPercentAdd = 25;
				shipModule.shipEvasionPercentAdd = -5;
				shipModule.maxHealthAdd = 165;
				shipModule_maxHealth = 140;
				break;
				case 2071389332: //integrity 05 blue scales
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Crystalline <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from unknown beautiful crystalline fibers that can store ambient energy to strengthen itself even further. Provides great degree of protection.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 850f, metals = 2250f, synthetics = 1750f, exotics = 7f };
				shipModule.asteroidDeflectionPercentAdd = 28;
				shipModule.shipEvasionPercentAdd = -5;
				shipModule.maxHealthAdd = 190;
				shipModule_maxHealth = 150;
				break;
				case 1152328828: //integrity 06 big green scales
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Dragonscale <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from unknown material of organic origin that has great durability and flexibility at the same time. Equipping it won't turn your ship into dragon slayer.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 1500f, synthetics = 1500f, organics = 2000f, exotics = 10f };
				shipModule.asteroidDeflectionPercentAdd = 32;
				shipModule.shipEvasionPercentAdd = -6;
				shipModule.maxHealthAdd = 215;
				shipModule_maxHealth = 160;
				break;
				case 989518264: //integrity 06 spideraa
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Megacyte <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from material with unknown properties that has quite an aggressive external appearance. Lack of aesthetics doesn't make it any less durable.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 2500f, synthetics = 3500f, explosives = 500f, exotics = 15f };
				shipModule.asteroidDeflectionPercentAdd = 36;
				shipModule.shipEvasionPercentAdd = -7;
				shipModule.maxHealthAdd = 240;
				shipModule_maxHealth = 180;
				break;
				case 786297539: //integrity 00 Ratty
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Adamantite <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Made from strongest existing alloy that was ripped off from something that resembles interstellar drifting gothic cathedral. Provides immense degree of protection.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 4500f, synthetics = 2500f, exotics = 20f };
				shipModule.asteroidDeflectionPercentAdd = 40;
				shipModule.shipEvasionPercentAdd = -8;
				shipModule.maxHealthAdd = 270;
				shipModule_maxHealth = 200;
				break;
				case 1196638242: //integrity tiger
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Contains(shipModule.PrefabId)) FFU_BE_Defs.survivalTypeIDs[Core.SurvivalType.Armor].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Nanometric <color=#{colorArmor}ff>Integrity Armor</color>");
				shipModule.description = Core.TT($"Experimental armor made from active nanomachines that almost instantly react to any type of incoming damage to negate it. Provides immense degree of protection.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 5000f, synthetics = 3500f, exotics = 25f };
				shipModule.asteroidDeflectionPercentAdd = 50;
				shipModule.shipEvasionPercentAdd = -10;
				shipModule.maxHealthAdd = 300;
				shipModule_maxHealth = 225;
				break;
				default:
				Debug.LogWarning($"[NEW ARMOR] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(ARMOR) {shipModule.name}";
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}