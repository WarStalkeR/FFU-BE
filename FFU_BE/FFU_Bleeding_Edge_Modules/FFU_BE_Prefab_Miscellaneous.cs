using RST;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Miscellaneous {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 685017033) return idx; idx++; //artifactmodule tec 33 biostasis nice worm
			if (moduleID == 957508477) return idx; idx++; //artifactmodule tec 11 biostasis
			if (moduleID == 1745395900) return idx; idx++; //artifactmodule tec 17 broken screen gizmo, data
			if (moduleID == 179311957) return idx; idx++; //artifactmodule tec 25 broken screen gizmo
			if (moduleID == 760711671) return idx; idx++; //artifactmodule tec 32 broken container gizmo
			if (moduleID == 656277331) return idx; idx++; //artifactmodule tec 37 ripped quarter of a dome
			if (moduleID == 760711667) return idx; idx++; //artifactmodule tec 36 broken gizmo
			if (moduleID == 1279608160) return idx; idx++; //artifactmodule tec 34 data core grammofon
			if (moduleID == 1316302015) return idx; idx++; //artifactmodule tec 35 data core makk
			if (moduleID == 2016575469) return idx; idx++; //artifactmodule nat bluecrystal
			if (moduleID == 1567870807) return idx; idx++; //artifactmodule nat eleriumite
			if (moduleID == 1689256804) return idx; idx++; //artifactmodule nat rahn
			if (moduleID == 1270337569) return idx; idx++; //artifactmodule nat redcrystal
			if (moduleID == 951480953) return idx; idx++; //artifactmodule nat whitecrystal
			if (moduleID == 193928381) return idx; idx++; //artifactmodule nat young eleriumite
			if (moduleID == 606853666) return idx; idx++; //artifactmodule10 rahn tutorial
			if (moduleID == 1696261283) return idx; idx++; //artifactmodule nat bone
			if (moduleID == 1666228140) return idx; idx++; //artifactmodule nat skull
			if (moduleID == 874868118) return idx; idx++; //artifactmodule nat fossilbug
			//if (moduleID == 685017033) return idx; idx++; //artifactmodule tec 33 biostasis nice worm
			//if (moduleID == 957508477) return idx; idx++; //artifactmodule tec 11 biostasis
			//if (moduleID == 1745395900) return idx; idx++; //artifactmodule tec 17 broken screen gizmo, data
			//if (moduleID == 179311957) return idx; idx++; //artifactmodule tec 25 broken screen gizmo
			//if (moduleID == 760711671) return idx; idx++; //artifactmodule tec 32 broken container gizmo
			//if (moduleID == 656277331) return idx; idx++; //artifactmodule tec 37 ripped quarter of a dome
			//if (moduleID == 760711667) return idx; idx++; //artifactmodule tec 36 broken gizmo
			//if (moduleID == 1279608160) return idx; idx++; //artifactmodule tec 34 data core grammofon
			//if (moduleID == 1316302015) return idx; idx++; //artifactmodule tec 35 data core makk
			if (moduleID == 177900583) return idx; idx++; //artifactmodule tec 24 broken warp gizmo ECM
			if (moduleID == 1664024110) return idx; idx++; //artifactmodule tec 31 data core node small lamp dome
			if (moduleID == 374327078) return idx; idx++; //artifactmodule tec biotech eyeball asteroid predictor
			if (moduleID == 179311961) return idx; idx++; //artifactmodule tec 21 data core rectangle gizmo
			if (moduleID == 1745395905) return idx; idx++; //artifactmodule tec 12 data square gizmo with minidomes
			if (moduleID == 1919746609) return idx; idx++; //artifactmodule tec screamer egg ECM
			if (moduleID == 389977561) return idx; idx++; //artifactmodule tec green slime integrity
			if (moduleID == 1986591663) return idx; idx++; //artifactmodule tec metal rainbow integrity
			if (moduleID == 179311964) return idx; idx++; //artifactmodule tec 22 metal synt gizmo ECM
			if (moduleID == 179311963) return idx; idx++; //artifactmodule tec 23 metal gizmo with light ECM
			if (moduleID == 1985410647) return idx; idx++; //artifactmodule tec 28 data core giant chip ECM internal
			if (moduleID == 1776726075) return idx; idx++; //artifactmodule tec 39 accuracy advanced data core
			if (moduleID == 1971358425) return idx; idx++; //artifactmodule tec engine booster 1
			if (moduleID == 1392338414) return idx; idx++; //artifactmodule tec 38 accuracy datacore manysquares
			if (moduleID == 1745395904) return idx; idx++; //artifactmodule tec 13 data core brassdome ECM
			if (moduleID == 266571173) return idx; idx++; //artifactmodule tec engine booster 2
			if (moduleID == 674530774) return idx; idx++; //artifactmodule tec ingergity and asteroid predictor
			if (moduleID == 1934368951) return idx; idx++; //weapon EMP perm DLC
			if (moduleID == 1801315413) return idx; idx++; //bossweapon insectoid ship
			if (moduleID == 1088715096) return idx; idx++; //bossweapon weirdaxer
			if (moduleID == 1819161633) return idx; idx++; //storage container 3x4
			return idx + 100;
		}
		public static void UpdateMsicModule(ShipModule shipModule, bool initItemData) {
			string colorCache = "add8e6";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			shipModule.asteroidDeflectionPercentAdd = 0;
			shipModule.shipAccuracyPercentAdd = 0;
			shipModule.shipEvasionPercentAdd = 0;
			shipModule.starmapSpeedAdd = 0;
			shipModule.maxHealthAdd = 0;
			shipModule.powerConsumed = 0;
			switch (shipModule.PrefabId) {
				case 685017033: //artifactmodule tec 33 biostasis nice worm
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Upgrades].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Upgrades].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Mechanical <color=#" + colorCache + "ff>Upgrades</color> Cache");
				shipModule.description = Core.TT($"Upgrades cache that contains upgrades sets that increase health of drones and robots by certain amount. To apply: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, exotics = 10f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case 957508477: //artifactmodule tec 11 biostasis
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Implants].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Implants].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Biological <color=#" + colorCache + "ff>Implants</color> Cache");
				shipModule.description = Core.TT($"Implants cache that contains implant sets that increase health of biological crewmembers by certain amount. To apply: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, organics = 500f, exotics = 10f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case 1745395900: //artifactmodule tec 17 broken screen gizmo, data
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"CQC Class <color=#" + colorCache + "ff>Weapons</color> Cache");
				shipModule.description = Core.TT($"Weapon cache that contains full sets of close combat weapons used by boarding parties of various forces. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 500f, synthetics = 500f, explosives = 500f, exotics = 15f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case 179311957: //artifactmodule tec 25 broken screen gizmo
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Kinetic Type <color=#" + colorCache + "ff>Weapons</color> Cache");
				shipModule.description = Core.TT($"Weapon cache that contains full sets of kinetic weapons beloved by undeveloped empires or nostalgia seekers. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 250f, explosives = 500f, exotics = 10f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case 760711671: //artifactmodule tec 32 broken container gizmo
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Laser Type <color=#" + colorCache + "ff>Weapons</color> Cache");
				shipModule.description = Core.TT($"Weapon cache that contains full sets of laser weapons that mainly used by Terran Alliance military and special forces. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 750f, synthetics = 1250f, exotics = 15f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 75;
				break;
				case 656277331: //artifactmodule tec 37 ripped quarter of a dome
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Energy Type <color=#" + colorCache + "ff>Weapons</color> Cache");
				shipModule.description = Core.TT($"Weapon cache that contains full sets of exotic and even potentially volatile weaponry beloved by alien enforcers. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 750f, synthetics = 1250f, exotics = 20f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 75;
				break;
				case 760711667: //artifactmodule tec 36 broken gizmo
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Backup Class <color=#" + colorCache + "ff>Weapons</color> Cache");
				shipModule.description = Core.TT($"Weapon cache that contains full sets backup weaponry in case if somebody managed to get onto spaceship with only fists. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 750f, synthetics = 250f, explosives = 250f, exotics = 5f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case 1279608160: //artifactmodule tec 34 data core grammofon
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Tactical Class <color=#" + colorCache + "ff>Weapons</color> Cache");
				shipModule.description = Core.TT($"Weapon cache that contains full sets of tactical weaponry that effective in dealing with most situation and enemies alike. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 500f, explosives = 500f, exotics = 15f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case 1316302015: //artifactmodule tec 35 data core makk
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Default].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Assault Class <color=#" + colorCache + "ff>Weapons</color> Cache");
				shipModule.description = Core.TT($"Weapon cache that contains full sets of assault weaponry that allow their owner to solve any problem with pure violence. To equip: pack it, bring crew close to Engine Module and scrap it. Amount of sets depends on cache's tier.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 2000f, synthetics = 1000f, explosives = 1000f, exotics = 25f };
				shipModule.scrapGet = new ResourceValueGroup { };
				shipModule_maxHealth = 75;
				break;
				case 2016575469: //artifactmodule nat bluecrystal
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Yellow Exotic Crystal");
				shipModule.scrapGet = new ResourceValueGroup { metals = 2000f, exotics = 100f, credits = 500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 1567870807: //artifactmodule nat eleriumite
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Volatile Crystal");
				shipModule.scrapGet = new ResourceValueGroup { fuel = 2000f, explosives = 3000f, credits = 375f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 1689256804: //artifactmodule nat rahn
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Beige Exotic Crystal");
				shipModule.scrapGet = new ResourceValueGroup { fuel = 1750f, exotics = 75f, credits = 750f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 1270337569: //artifactmodule nat redcrystal
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Lilac Exotic Crystal");
				shipModule.scrapGet = new ResourceValueGroup { synthetics = 2000f, exotics = 150f, credits = 1750f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 951480953: //artifactmodule nat whitecrystal
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"White Exotic Crystal");
				shipModule.scrapGet = new ResourceValueGroup { fuel = 1000f, metals = 1500f, exotics = 125, credits = 2500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 193928381: //artifactmodule nat young eleriumite
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Eleriumite Crystal");
				shipModule.scrapGet = new ResourceValueGroup { fuel = 1500f, metals = 1250f, explosives = 2500f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 606853666: //artifactmodule10 rahn tutorial
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Solidified Exotic Essence");
				shipModule.scrapGet = new ResourceValueGroup { exotics = 750f, credits = 7500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 1696261283: //artifactmodule nat bone
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Fossilized Bone");
				shipModule.scrapGet = new ResourceValueGroup { organics = 1750f, metals = 1250f, exotics = 50f, credits = 1500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 1666228140: //artifactmodule nat skull
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Fossilized Skull");
				shipModule.scrapGet = new ResourceValueGroup { organics = 1750f, synthetics = 1250f, exotics = 50f, credits = 1500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case 874868118: //artifactmodule nat fossilbug
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Fossilized Insectoid");
				shipModule.scrapGet = new ResourceValueGroup { organics = 1750f, explosives = 1250f, exotics = 50f, credits = 1500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				/*case 685017033: //artifactmodule tec 33 biostasis nice worm
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Light Biostasis Unit");
				shipModule.scrapGet = new ResourceValueGroup { organics = 2500f, explosives = 750f, metals = 750f, synthetics = 750f, exotics = 25f, credits = 1750f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 957508477: //artifactmodule tec 11 biostasis
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Heavy Biostasis Unit");
				shipModule.scrapGet = new ResourceValueGroup { organics = 3750f, explosives = 1250f, metals = 1250f, synthetics = 1250f, exotics = 50f, credits = 2500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 1745395900: //artifactmodule tec 17 broken screen gizmo, data
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Data Projector Device");
				shipModule.scrapGet = new ResourceValueGroup { metals = 2000f, synthetics = 1000f, fuel = 750f, exotics = 35f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 179311957: //artifactmodule tec 25 broken screen gizmo
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Active Matrix Device");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1000f, synthetics = 2000f, fuel = 750f, exotics = 35f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 760711671: //artifactmodule tec 32 broken container gizmo
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Sealed Container Device");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1000f, synthetics = 1000f, fuel = 1750f, exotics = 35f, credits = 1250f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 656277331: //artifactmodule tec 37 ripped quarter of a dome
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Broken External Shielding");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1750f, synthetics = 750f, exotics = 25f, credits = 500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 760711667: //artifactmodule tec 36 broken gizmo
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Broken Temporal Coils");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1750f, synthetics = 750f, exotics = 25f, credits = 500f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 1279608160: //artifactmodule tec 34 data core grammofon
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Antique Memory Unit");
				shipModule.scrapGet = new ResourceValueGroup { metals = 750f, synthetics = 1250f, exotics = 5f, credits = 5000f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;
				case 1316302015: //artifactmodule tec 35 data core makk
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Ancient Memory Unit");
				shipModule.scrapGet = new ResourceValueGroup { metals = 750f, synthetics = 1250f, exotics = 5f, credits = 5000f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 50;
				break;*/
				case 177900583: //artifactmodule tec 24 broken warp gizmo ECM
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Damaged Warp Coils");
				shipModule.scrapGet = new ResourceValueGroup { synthetics = 1250f, exotics = 15f, credits = 1750f };
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case 1664024110: //artifactmodule tec 31 data core node small lamp dome
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"External Observation Unit");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1250f, exotics = 15f, credits = 1750f };
				shipModule.maxHealthAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case 374327078: //artifactmodule tec biotech eyeball asteroid predictor
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Asteroid Prediction Unit");
				shipModule.scrapGet = new ResourceValueGroup { organics = 1250f, exotics = 15f, credits = 1750f };
				shipModule.asteroidDeflectionPercentAdd = 10;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case 179311961: //artifactmodule tec 21 data core rectangle gizmo
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Solid State Data Core");
				shipModule.scrapGet = new ResourceValueGroup { metals = 750f, synthetics = 2750f, exotics = 10f, credits = 1250f };
				shipModule.maxHealthAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case 1745395905: //artifactmodule tec 12 data square gizmo with minidomes
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Matrix Data Core");
				shipModule.scrapGet = new ResourceValueGroup { metals = 2750f, synthetics = 750f, exotics = 10f, credits = 1250f };
				shipModule.maxHealthAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case 1919746609: //artifactmodule tec screamer egg ECM
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Organic Disruption Emitter");
				shipModule.scrapGet = new ResourceValueGroup { organics = 2750f, synthetics = 1750f, exotics = 15f, credits = 2250f };
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 50;
				break;
				case 389977561: //artifactmodule tec green slime integrity
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Pseudo-Creep Coating Array");
				shipModule.scrapGet = new ResourceValueGroup { organics = 3750f, synthetics = 1250f, exotics = 5f, credits = 2000f };
				shipModule.maxHealthAdd = 25;
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 125;
				break;
				case 1986591663: //artifactmodule tec metal rainbow integrity
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Prismatic Mirror Array");
				shipModule.scrapGet = new ResourceValueGroup { metals = 3750f, synthetics = 1250f, exotics = 5f, credits = 2000f };
				shipModule.maxHealthAdd = 25;
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 125;
				break;
				case 179311964: //artifactmodule tec 22 metal synt gizmo ECM
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Dampener Data Core");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1250f, synthetics = 1250f, exotics = 15f, credits = 2500f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case 179311963: //artifactmodule tec 23 metal gizmo with light ECM
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Suppressor Data Core");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1250f, synthetics = 1250f, exotics = 15f, credits = 2500f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case 1985410647: //artifactmodule tec 28 data core giant chip ECM internal
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Processing Data Core");
				shipModule.scrapGet = new ResourceValueGroup { metals = 500f, synthetics = 2000f, exotics = 15f, credits = 2500f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case 1776726075: //artifactmodule tec 39 accuracy advanced data core
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Enumeration Processing Unit");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1500f, synthetics = 1000f, exotics = 15f, credits = 2500f };
				shipModule.shipAccuracyPercentAdd = 20;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case 1971358425: //artifactmodule tec engine booster 1
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Fuel Optimization Unit");
				shipModule.scrapGet = new ResourceValueGroup { metals = 2000f, synthetics = 500f, exotics = 15f, credits = 2500f };
				shipModule.starmapSpeedAdd = 5f;
				shipModule.maxHealthAdd = 15;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 75;
				break;
				case 1392338414: //artifactmodule tec 38 accuracy datacore manysquares
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Array Processing Unit");
				shipModule.scrapGet = new ResourceValueGroup { metals = 1000f, synthetics = 4000f, exotics = 25f, credits = 5000f };
				shipModule.shipAccuracyPercentAdd = 40;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case 1745395904: //artifactmodule tec 13 data core brassdome ECM
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Disruptor Data Core");
				shipModule.scrapGet = new ResourceValueGroup { metals = 3500f, synthetics = 1500f, exotics = 25f, credits = 5000f };
				shipModule.shipEvasionPercentAdd = 10;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case 266571173: //artifactmodule tec engine booster 2
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Engine Thermal Shielding");
				shipModule.scrapGet = new ResourceValueGroup { metals = 4000f, synthetics = 1000f, exotics = 25f, credits = 5000f };
				shipModule.starmapSpeedAdd = 10;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case 674530774: //artifactmodule tec ingergity and asteroid predictor
				if (!FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Contains(shipModule.PrefabId)) FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Artifact].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Collision Detection Unit");
				shipModule.scrapGet = new ResourceValueGroup { metals = 2500f, synthetics = 2500f, exotics = 25f, credits = 5000f };
				shipModule.asteroidDeflectionPercentAdd = 50;
				shipModule.maxHealthAdd = 35;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 100;
				break;
				case 1819161636: //storage container 3x3
				case 1819161633: //storage container 3x4
				shipModule.displayName = Core.TT($"Modular Storage Compartment");
				shipModule.description = Core.TT($"Universal storage unit that stores disassembled modules in highly compact form and requires quite some time to assemble them back. Also holds answer to the Ultimate Question of Life, the Universe, and Everything.");
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
				default:
				Debug.LogWarning($"[NEW MISC] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(MISC) {shipModule.name}";
				break;
			}
			if (shipModule.type != ShipModule.Type.Storage && !shipModule.displayName.Contains("Cache")) {
				shipModule.craftCost.fuel = shipModule.scrapGet.fuel * 2;
				shipModule.craftCost.organics = shipModule.scrapGet.organics * 2;
				shipModule.craftCost.synthetics = shipModule.scrapGet.synthetics * 2;
				shipModule.craftCost.metals = shipModule.scrapGet.metals * 2;
				shipModule.craftCost.explosives = shipModule.scrapGet.explosives * 2;
				shipModule.craftCost.exotics = shipModule.scrapGet.exotics * 2;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStatsCore(shipModule);
		}
	}
}