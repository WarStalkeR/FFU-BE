using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Storages {
		public static int SortModules(int moduleID) {
			int idx = 0;
			//Multi
			if (moduleID == 825891570) return idx; idx++; //multicontainer DIY EE
			if (moduleID == 1404265275) return idx; idx++; //multicontainer DIY FO
			if (moduleID == 1158881065) return idx; idx++; //multicontainer FExo DIY armor
			if (moduleID == 1380487708) return idx; idx++; //multicontainer MS-1
			if (moduleID == 1384130728) return idx; idx++; //multicontainer biotec-scaled FO
			if (moduleID == 1008150789) return idx; idx++; //multicontainer ESM-1
			if (moduleID == 426751082) return idx; idx++; //multicontainer ESM-2
			if (moduleID == 1165288718) return idx; idx++; //multicontainer FEO-1
			if (moduleID == 1165288404) return idx; idx++; //multicontainer FOO-1
			if (moduleID == 1366723332) return idx; idx++; //multicontainer MFE retro futu
			if (moduleID == 1366723326) return idx; idx++; //multicontainer MFO retro futu
			if (moduleID == 1973225425) return idx; idx++; //multicontainer OMS biotech
			if (moduleID == 1847976825) return idx; idx++; //multicontainer FSEE biotech
			if (moduleID == 2141167320) return idx; idx++; //multicontainer FOS biotec
			if (moduleID == 920367928) return idx; idx++; //multicontainer OME mechanical
			if (moduleID == 619214127) return idx; idx++; //multicontainer FE armor
			if (moduleID == 1904770087) return idx; idx++; //multicontainer FSE biotech
			if (moduleID == 1270396661) return idx; idx++; //multicontainer EOME spideraa
														   //Organics
			if (moduleID == 1449641283) return idx; idx++; //organics container 0 diy
			if (moduleID == 812439290) return idx; idx++; //organics container 1 bio
			if (moduleID == 940750901) return idx; idx++; //organics container 1 small
			if (moduleID == 82212496) return idx; idx++; //organics container 2 medium
			if (moduleID == 1530196661) return idx; idx++; //organics container 3 large
			if (moduleID == 1906398666) return idx; idx++; //organics container 4 extra large
			if (moduleID == 1969497769) return idx; idx++; //organics container 5 ultra large
														   //Fuel
			if (moduleID == 1477762477) return idx; idx++; //fuel container 0 diy
			if (moduleID == 1140021200) return idx; idx++; //fuel container 1 bio
			if (moduleID == 1391027202) return idx; idx++; //fuel container 1
			if (moduleID == 809627495) return idx; idx++; //fuel container 2
			if (moduleID == 228227788) return idx; idx++; //fuel container 3
			if (moduleID == 3058441) return idx; idx++; //fuel container 4
			if (moduleID == 1569142382) return idx; idx++; //fuel container 5
			if (moduleID == 1061408062) return idx; idx++; //fuel container tiger
														   //Metals
			if (moduleID == 340918825) return idx; idx++; //metals container 0 diy
			if (moduleID == 349484391) return idx; idx++; //metals container 1 small
			if (moduleID == 1448463490) return idx; idx++; //metals container 2 medium
			if (moduleID == 851515731) return idx; idx++; //metals container 3 large
			if (moduleID == 350762646) return idx; idx++; //metals container 4 extralarge
														  //Synthetics
			if (moduleID == 165493307) return idx; idx++; //synthetics container 0 diy
			if (moduleID == 620471997) return idx; idx++; //synthetics container1 small
			if (moduleID == 376986556) return idx; idx++; //synthetics container2 medium
			if (moduleID == 637430109) return idx; idx++; //synthetics container3 large
														  //Explosives
			if (moduleID == 271236703) return idx; idx++; //explosives container 0 diy
			if (moduleID == 96469373) return idx; idx++; //explosives container 1 small
			if (moduleID == 907034562) return idx; idx++; //explosives container 2 medium
			if (moduleID == 311517981) return idx; idx++; //explosives container 3 large
														  //Exotics
			if (moduleID == 168523420) return idx; idx++; //exotics container 0 diy
			if (moduleID == 19531542) return idx; idx++; //exotics container 1 small
			if (moduleID == 584489047) return idx; idx++; //exotics container 2 medium
			if (moduleID == 1606402988) return idx; idx++; //exotics container 3 large
			return idx + 100;
		}
		public static void UpdateStorageModule(ShipModule shipModule, bool initItemData) {
			string colorMulti = "cccccc";
			string colorContOrg = "ccddcc";
			string colorContFul = "ddcccc";
			string colorContMet = "ccccdd";
			string colorContSyn = "ccdddd";
			string colorContExp = "ddddcc";
			string colorContExo = "ddccdd";
			shipModule.Container.MaxOrganics = 0;
			shipModule.Container.MaxFuel = 0;
			shipModule.Container.MaxMetals = 0;
			shipModule.Container.MaxSynthetics = 0;
			shipModule.Container.MaxExplosives = 0;
			shipModule.Container.MaxExotics = 0;
			shipModule.Container.organicsCanLeak = false;
			shipModule.Container.fuelCanLeak = false;
			shipModule.Container.metalsCanLeak = false;
			shipModule.Container.syntheticsCanLeak = false;
			shipModule.Container.explosivesCanLeak = false;
			shipModule.Container.exoticsCanLeak = false;
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 825891570: //multicontainer DIY EE
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift XE <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases explosives and exotics storage capacity. If breached, explosives and exotics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 150f, synthetics = 100f };
				shipModule.Container.MaxExplosives = 3000;
				shipModule.Container.MaxExotics = 300;
				shipModule.Container.explosivesCanLeak = true;
				shipModule.Container.exoticsCanLeak = true;
				shipModule_maxHealth = 45;
				break;
				case 1404265275: //multicontainer DIY FO
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift FO <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases fuel and organics storage capacity. If breached, starfuel and organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 150f, synthetics = 100f };
				shipModule.Container.MaxOrganics = 3000;
				shipModule.Container.MaxFuel = 3000;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 45;
				break;
				case 1158881065: //multicontainer FExo DIY armor
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift FE <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases fuel and exotics storage capacity. If breached, starfuel and exotics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 100f };
				shipModule.Container.MaxFuel = 3000;
				shipModule.Container.MaxExotics = 300;
				shipModule.Container.fuelCanLeak = true;
				shipModule.Container.exoticsCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 1380487708: //multicontainer MS-1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Standard MS <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Storage container that increases metals and synthetics storage capacity. If breached, synthetics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 750f, exotics = 2f };
				shipModule.Container.MaxMetals = 7500;
				shipModule.Container.MaxSynthetics = 7500;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 1384130728: //multicontainer biotec-scaled FO
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Standard FO <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Storage container that increases fuel and organics storage capacity. If breached, starfuel and organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 750f, exotics = 2f };
				shipModule.Container.MaxOrganics = 7500;
				shipModule.Container.MaxFuel = 7500;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 1008150789: //multicontainer ESM-1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Standard XSM <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Storage container that increases metals and synthetics storage capacity. If breached, synthetics and explosives will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 750f, exotics = 2f };
				shipModule.Container.MaxMetals = 5000;
				shipModule.Container.MaxSynthetics = 5000;
				shipModule.Container.MaxExplosives = 5000;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule.Container.explosivesCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 426751082: //multicontainer ESM-2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital XSM <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases explosives, metals and synthetics storage capacity. If breached, synthetics and explosives will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 1750f, synthetics = 1250f, exotics = 3f };
				shipModule.Container.MaxMetals = 8500;
				shipModule.Container.MaxSynthetics = 8500;
				shipModule.Container.MaxExplosives = 8500;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule.Container.explosivesCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 1165288718: //multicontainer FEO-1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital FEO <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases fuel, exotics and organics storage capacity. If breached, starfuel, organics and exotics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 1750f, synthetics = 1250f, exotics = 3f };
				shipModule.Container.MaxOrganics = 8500;
				shipModule.Container.MaxFuel = 8500;
				shipModule.Container.MaxExotics = 850;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.fuelCanLeak = true;
				shipModule.Container.exoticsCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 1165288404: //multicontainer FOO-1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital FOO <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases fuel and organics storage capacity. If breached, starfuel and organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 1750f, synthetics = 1250f, exotics = 3f };
				shipModule.Container.MaxOrganics = 16000;
				shipModule.Container.MaxFuel = 9000;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 1366723332: //multicontainer MFE retro futu
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital MFX <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases metals, fuel and explosives storage capacity. If breached, starfuel and explosives will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxFuel = 7500;
				shipModule.Container.MaxMetals = 7500;
				shipModule.Container.MaxExplosives = 10000;
				shipModule.Container.fuelCanLeak = true;
				shipModule.Container.explosivesCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 1366723326: //multicontainer MFO retro futu
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital MFO <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases metals, fuel and organics storage capacity. If breached, starfuel and organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 10000;
				shipModule.Container.MaxFuel = 7500;
				shipModule.Container.MaxMetals = 7500;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 1973225425: //multicontainer OMS biotech
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital OMS <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases organics, metals and synthetics storage capacity. If breached, organics and synthetics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 9000;
				shipModule.Container.MaxMetals = 9000;
				shipModule.Container.MaxSynthetics = 7000;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 1847976825: //multicontainer FSEE biotech
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital FSXE <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases fuel, synthetics, explosives and exotics storage capacity. If breached, starfuel, synthetics, explosives and exotics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxFuel = 9000;
				shipModule.Container.MaxSynthetics = 2000;
				shipModule.Container.MaxExplosives = 9000;
				shipModule.Container.MaxExotics = 500;
				shipModule.Container.fuelCanLeak = true;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule.Container.explosivesCanLeak = true;
				shipModule.Container.exoticsCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 2141167320: //multicontainer FOS biotec
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital FOS <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases fuel, organics and synthetics storage capacity. If breached, starfuel, organics and synthetics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxFuel = 8250;
				shipModule.Container.MaxOrganics = 8250;
				shipModule.Container.MaxSynthetics = 8250;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.fuelCanLeak = true;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 920367928: //multicontainer OME mechanical
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital OME <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases organics, metals and exotics storage capacity. If breached, organics and exotics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 9000;
				shipModule.Container.MaxMetals = 9000;
				shipModule.Container.MaxExotics = 700;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.exoticsCanLeak = true;
				shipModule_maxHealth = 105;
				break;
				case 619214127: //multicontainer FE armor
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Armored FX <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Armored storage container that increases fuel and explosives storage capacity. Specialized mechanisms prevent resource leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1500f, synthetics = 1000f, exotics = 4f };
				shipModule.Container.MaxFuel = 7500;
				shipModule.Container.MaxExplosives = 7500;
				shipModule_maxHealth = 135;
				break;
				case 1904770087: //multicontainer FSE biotech
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Armored FSE <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Armored storage container that increases fuel, synthetics and exotics storage capacity. Specialized mechanisms prevent resource leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1500f, synthetics = 1000f, exotics = 4f };
				shipModule.Container.MaxFuel = 5000;
				shipModule.Container.MaxSynthetics = 5000;
				shipModule.Container.MaxExotics = 500;
				shipModule_maxHealth = 135;
				break;
				case 1270396661: //multicontainer EOME spideraa
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Multi].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Exotic XOME <color=#{colorMulti}ff>Multi-Container</color>");
				shipModule.description = Core.TT($"Exotic storage container that increases explosives, organics, metals and exotics storage capacity. If breached, organics, metals, explosives and exotics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 5000;
				shipModule.Container.MaxMetals = 5000;
				shipModule.Container.MaxExplosives = 5000;
				shipModule.Container.MaxExotics = 500;
				shipModule.Container.organicsCanLeak = true;
				shipModule.Container.metalsCanLeak = true;
				shipModule.Container.explosivesCanLeak = true;
				shipModule.Container.exoticsCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 1449641283: //organics container 0 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorContOrg}ff>Organics Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases organics storage capacity. If breached, organics will start to leak out. If breached, organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxOrganics = 3000;
				shipModule.Container.organicsCanLeak = true;
				shipModule_maxHealth = 30;
				break;
				case 812439290: //organics container 1 bio
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Bionic <color=#{colorContOrg}ff>Organics Container</color>");
				shipModule.description = Core.TT($"Bionic storage container that increases organics storage capacity. Regenerating organic tissue of this container prevents organics leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, organics = 400f, synthetics = 250f };
				shipModule.Container.MaxOrganics = 4500;
				shipModule_maxHealth = 60;
				break;
				case 940750901: //organics container 1 small
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Small <color=#{colorContOrg}ff>Organics Container</color>");
				shipModule.description = Core.TT($"Small storage container that increases organics storage capacity. If breached, organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxOrganics = 4000;
				shipModule.Container.organicsCanLeak = true;
				shipModule_maxHealth = 45;
				break;
				case 82212496: //organics container 2 medium
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Medium <color=#{colorContOrg}ff>Organics Container</color>");
				shipModule.description = Core.TT($"Medium storage container that increases organics storage capacity. If breached, organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxOrganics = 8000;
				shipModule.Container.organicsCanLeak = true;
				shipModule_maxHealth = 60;
				break;
				case 1530196661: //organics container 3 large
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Large <color=#{colorContOrg}ff>Organics Container</color>");
				shipModule.description = Core.TT($"Large storage container that increases organics storage capacity. If breached, organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxOrganics = 12000;
				shipModule.Container.organicsCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 1906398666: //organics container 4 extra large
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Huge <color=#{colorContOrg}ff>Organics Container</color>");
				shipModule.description = Core.TT($"Huge storage container that increases organics storage capacity. If breached, organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxOrganics = 20000;
				shipModule.Container.organicsCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 1969497769: //organics container 5 ultra large
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Organics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital <color=#{colorContOrg}ff>Organics Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases organics storage capacity. If breached, organics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 1500f, synthetics = 1000f, exotics = 3f };
				shipModule.Container.MaxOrganics = 30000;
				shipModule.Container.organicsCanLeak = true;
				shipModule_maxHealth = 90;
				break;
				case 1477762477: //fuel container 0 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases fuel storage capacity. If breached, starfuel will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxFuel = 3000;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 30;
				break;
				case 1140021200: //fuel container 1 bio
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Bionic <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Bionic storage container that increases fuel storage capacity. Regenerating organic tissue of this container prevents starfuel leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, organics = 400f, synthetics = 250f };
				shipModule.Container.MaxFuel = 4500;
				shipModule_maxHealth = 60;
				break;
				case 1391027202: //fuel container 1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Small <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Small storage container that increases fuel storage capacity. If breached, starfuel will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxFuel = 4000;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 45;
				break;
				case 809627495: //fuel container 2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Medium <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Medium storage container that increases fuel storage capacity. If breached, starfuel will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxFuel = 8000;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 60;
				break;
				case 228227788: //fuel container 3
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Large <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Large storage container that increases fuel storage capacity. If breached, starfuel will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxFuel = 12000;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 3058441: //fuel container 4
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Huge <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Huge storage container that increases fuel storage capacity. If breached, starfuel will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxFuel = 20000;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 1569142382: //fuel container 5
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Capital <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases fuel storage capacity. If breached, starfuel will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 1500f, synthetics = 1000f, exotics = 3f };
				shipModule.Container.MaxFuel = 30000;
				shipModule.Container.fuelCanLeak = true;
				shipModule_maxHealth = 90;
				break;
				case 1061408062: //fuel container tiger
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Starfuel].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Dreadnought <color=#{colorContFul}ff>Starfuel Container</color>");
				shipModule.description = Core.TT($"Massive storage container that increases fuel storage capacity. Specialized mechanisms prevent starfuel leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1000f, exotics = 3f };
				shipModule.Container.MaxFuel = 30000;
				shipModule_maxHealth = 150;
				break;
				case 340918825: //metals container 0 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorContMet}ff>Metals Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases metals storage capacity. So brittle, that even with simple breach metals will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxMetals = 3000;
				shipModule.Container.metalsCanLeak = true;
				shipModule_maxHealth = 30;
				break;
				case 349484391: //metals container 1 small
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Small <color=#{colorContMet}ff>Metals Container</color>");
				shipModule.description = Core.TT($"Small storage container that increases metals storage capacity. Sturdy enough to ensure that no metals leak occur, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxMetals = 4000;
				shipModule_maxHealth = 45;
				break;
				case 1448463490: //metals container 2 medium
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Medium <color=#{colorContMet}ff>Metals Container</color>");
				shipModule.description = Core.TT($"Medium storage container that increases metals storage capacity. Sturdy enough to ensure that no metals leak occur, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxMetals = 8000;
				shipModule_maxHealth = 60;
				break;
				case 851515731: //metals container 3 large
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Large <color=#{colorContMet}ff>Metals Container</color>");
				shipModule.description = Core.TT($"Large storage container that increases metals storage capacity. Sturdy enough to ensure that no metals leak occur, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxMetals = 12000;
				shipModule_maxHealth = 75;
				break;
				case 350762646: //metals container 4 extralarge
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Metals].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Huge <color=#{colorContMet}ff>Metals Container</color>");
				shipModule.description = Core.TT($"Huge storage container that increases metals storage capacity. Sturdy enough to ensure that no metals leak occur, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxMetals = 20000;
				shipModule_maxHealth = 90;
				break;
				case 165493307: //synthetics container 0 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorContSyn}ff>Synthetics Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases synthetics storage capacity. If breached, synthetics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxSynthetics = 3000;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule_maxHealth = 30;
				break;
				case 620471997: //synthetics container1 small
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Medium <color=#{colorContSyn}ff>Synthetics Container</color>");
				shipModule.description = Core.TT($"Medium storage container that increases synthetics storage capacity. If breached, synthetics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxSynthetics = 8000;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule_maxHealth = 60;
				break;
				case 376986556: //synthetics container2 medium
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Large <color=#{colorContSyn}ff>Synthetics Container</color>");
				shipModule.description = Core.TT($"Large storage container that increases synthetics storage capacity. If breached, synthetics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxSynthetics = 12000;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 637430109: //synthetics container3 large
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Synthetics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Huge <color=#{colorContSyn}ff>Synthetics Container</color>");
				shipModule.description = Core.TT($"Huge storage container that increases synthetics storage capacity. If breached, synthetics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxSynthetics = 20000;
				shipModule.Container.syntheticsCanLeak = true;
				shipModule_maxHealth = 90;
				break;
				case 271236703: //explosives container 0 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorContExp}ff>Explosives Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases explosives storage capacity. If breached, explosives will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxExplosives = 3000;
				shipModule.Container.explosivesCanLeak = true;
				shipModule_maxHealth = 30;
				break;
				case 96469373: //explosives container 1 small
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Medium <color=#{colorContExp}ff>Explosives Container</color>");
				shipModule.description = Core.TT($"Medium storage container that increases explosives storage capacity. If breached, explosives will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxExplosives = 8000;
				shipModule.Container.explosivesCanLeak = true;
				shipModule_maxHealth = 60;
				break;
				case 907034562: //explosives container 2 medium
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Large <color=#{colorContExp}ff>Explosives Container</color>");
				shipModule.description = Core.TT($"Large storage container that increases explosives storage capacity. If breached, explosives will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxExplosives = 12000;
				shipModule.Container.explosivesCanLeak = true;
				shipModule_maxHealth = 75;
				break;
				case 311517981: //explosives container 3 large
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exoplosives].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Huge <color=#{colorContExp}ff>Explosives Container</color>");
				shipModule.description = Core.TT($"Huge storage container that increases explosives storage capacity. If breached, explosives will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxExplosives = 20000;
				shipModule.Container.explosivesCanLeak = true;
				shipModule_maxHealth = 90;
				break;
				case 168523420: //exotics container 0 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorContExo}ff>Exotics Container</color>");
				shipModule.description = Core.TT($"Makeshift storage container that increases exotics storage capacity. If breached, exotics will start to leak out.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxExotics = 300;
				shipModule.Container.exoticsCanLeak = true;
				shipModule_maxHealth = 30;
				break;
				case 19531542: //exotics container 1 small
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Small <color=#{colorContExo}ff>Exotics Container</color>");
				shipModule.description = Core.TT($"Small storage container that increases exotics storage capacity. Specialized mechanisms prevent exotics leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxExotics = 400;
				shipModule_maxHealth = 45;
				break;
				case 584489047: //exotics container 2 medium
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Medium <color=#{colorContExo}ff>Exotics Container</color>");
				shipModule.description = Core.TT($"Medium storage container that increases exotics storage capacity. Specialized mechanisms prevent exotics leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxExotics = 800;
				shipModule_maxHealth = 60;
				break;
				case 1606402988: //exotics container 3 large
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				if (!FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Contains(shipModule.PrefabId)) FFU_BE_Defs.cargoTypeIDs[Core.CargoType.Exotics].Add(shipModule.PrefabId);
				shipModule.displayName = Core.TT($"Large <color=#{colorContExo}ff>Exotics Container</color>");
				shipModule.description = Core.TT($"Large storage container that increases exotics storage capacity. Specialized mechanisms prevent exotics leak, even if containment was breached.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxExotics = 1200;
				shipModule_maxHealth = 75;
				break;
				case 1925655786: //fuel container 3 exotic artifact
				shipModule.displayName = Core.TT($"Fuel Container Artifact");
				shipModule.description = Core.TT($"Fuel container storage of completely alien origin. Unique containment mechanism prevents fuel leak in case of even severe damage.");
				shipModule.Container.MaxFuel = 6750;
				shipModule_maxHealth = 50;
				break;
				default:
				Debug.LogWarning($"[NEW STORAGE] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(STORAGE) {shipModule.name}";
				break;
			}
			if (shipModule.Container.MaxExotics > 0) shipModule.Container.MaxExotics = Mathf.RoundToInt(shipModule.Container.MaxExotics * FFU_BE_Defs.containerSizeMultiplier);
			if (shipModule.Container.MaxExplosives > 0) shipModule.Container.MaxExplosives = Mathf.RoundToInt(shipModule.Container.MaxExplosives * FFU_BE_Defs.containerSizeMultiplier);
			if (shipModule.Container.MaxFuel > 0) shipModule.Container.MaxFuel = Mathf.RoundToInt(shipModule.Container.MaxFuel * FFU_BE_Defs.containerSizeMultiplier);
			if (shipModule.Container.MaxMetals > 0) shipModule.Container.MaxMetals = Mathf.RoundToInt(shipModule.Container.MaxMetals * FFU_BE_Defs.containerSizeMultiplier);
			if (shipModule.Container.MaxOrganics > 0) shipModule.Container.MaxOrganics = Mathf.RoundToInt(shipModule.Container.MaxOrganics * FFU_BE_Defs.containerSizeMultiplier);
			if (shipModule.Container.MaxSynthetics > 0) shipModule.Container.MaxSynthetics = Mathf.RoundToInt(shipModule.Container.MaxSynthetics * FFU_BE_Defs.containerSizeMultiplier);
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}