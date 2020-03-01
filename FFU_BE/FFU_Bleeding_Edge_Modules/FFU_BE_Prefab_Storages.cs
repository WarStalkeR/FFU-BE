using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Storages {
		public static int SortModules(string moduleName) {
			int idx = 0;
			//Multi
			if (moduleName.Contains("multicontainer DIY EE")) return idx; idx++;
			if (moduleName.Contains("multicontainer DIY FO")) return idx; idx++;
			if (moduleName.Contains("multicontainer FExo DIY armor")) return idx; idx++;
			if (moduleName.Contains("multicontainer MS-1")) return idx; idx++;
			if (moduleName.Contains("multicontainer biotec-scaled FO")) return idx; idx++;
			if (moduleName.Contains("multicontainer ESM-1")) return idx; idx++;
			if (moduleName.Contains("multicontainer ESM-2")) return idx; idx++;
			if (moduleName.Contains("multicontainer FEO-1")) return idx; idx++;
			if (moduleName.Contains("multicontainer FOO-1")) return idx; idx++;
			if (moduleName.Contains("multicontainer MFE retro futu")) return idx; idx++;
			if (moduleName.Contains("multicontainer MFO retro futu")) return idx; idx++;
			if (moduleName.Contains("multicontainer OMS biotech")) return idx; idx++;
			if (moduleName.Contains("multicontainer FSEE biotech")) return idx; idx++;
			if (moduleName.Contains("multicontainer FOS biotec")) return idx; idx++;
			if (moduleName.Contains("multicontainer OME mechanical")) return idx; idx++;
			if (moduleName.Contains("multicontainer FE armor")) return idx; idx++;
			if (moduleName.Contains("multicontainer FSE biotech")) return idx; idx++;
			if (moduleName.Contains("multicontainer EOME spideraa")) return idx; idx++;
			//Organics
			if (moduleName.Contains("organics container 0 diy")) return idx; idx++;
			if (moduleName.Contains("organics container 1 bio")) return idx; idx++;
			if (moduleName.Contains("organics container 1 small")) return idx; idx++;
			if (moduleName.Contains("organics container 2 medium")) return idx; idx++;
			if (moduleName.Contains("organics container 3 large")) return idx; idx++;
			if (moduleName.Contains("organics container 4 extra large")) return idx; idx++;
			if (moduleName.Contains("organics container 5 ultra large")) return idx; idx++;
			//Fuel
			if (moduleName.Contains("fuel container 0 diy")) return idx; idx++;
			if (moduleName.Contains("fuel container 1 bio")) return idx; idx++;
			if (moduleName.Contains("fuel container 1")) return idx; idx++;
			if (moduleName.Contains("fuel container 2")) return idx; idx++;
			if (moduleName.Contains("fuel container 3")) return idx; idx++;
			if (moduleName.Contains("fuel container 4")) return idx; idx++;
			if (moduleName.Contains("fuel container 5")) return idx; idx++;
			if (moduleName.Contains("fuel container tiger")) return idx; idx++;
			//Metals
			if (moduleName.Contains("metals container 0 diy")) return idx; idx++;
			if (moduleName.Contains("metals container 1 small")) return idx; idx++;
			if (moduleName.Contains("metals container 2 medium")) return idx; idx++;
			if (moduleName.Contains("metals container 3 large")) return idx; idx++;
			if (moduleName.Contains("metals container 4 extralarge")) return idx; idx++;
			//Synthetics
			if (moduleName.Contains("synthetics container 0 diy")) return idx; idx++;
			if (moduleName.Contains("synthetics container1 small")) return idx; idx++;
			if (moduleName.Contains("synthetics container2 medium")) return idx; idx++;
			if (moduleName.Contains("synthetics container3 large")) return idx; idx++;
			//Explosives
			if (moduleName.Contains("explosives container 0 diy")) return idx; idx++;
			if (moduleName.Contains("explosives container 1 small")) return idx; idx++;
			if (moduleName.Contains("explosives container 2 medium")) return idx; idx++;
			if (moduleName.Contains("explosives container 3 large")) return idx; idx++;
			//Exotics
			if (moduleName.Contains("exotics container 0 diy")) return idx; idx++;
			if (moduleName.Contains("exotics container 1 small")) return idx; idx++;
			if (moduleName.Contains("exotics container 2 medium")) return idx; idx++;
			if (moduleName.Contains("exotics container 3 large")) return idx; idx++;
			return 999;
		}
		public static void UpdateStorageModule(ShipModule shipModule, bool initItemData) {
			string colorMulti = "cccccc";
			string colorContOrg = "cccccc";
			string colorContFul = "cccccc";
			string colorContMet = "cccccc";
			string colorContSyn = "cccccc";
			string colorContExp = "cccccc";
			string colorContExo = "cccccc";
			shipModule.Container.MaxOrganics = 0;
			shipModule.Container.MaxFuel = 0;
			shipModule.Container.MaxMetals = 0;
			shipModule.Container.MaxSynthetics = 0;
			shipModule.Container.MaxExplosives = 0;
			shipModule.Container.MaxExotics = 0;
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "multicontainer DIY EE":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift XE <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Makeshift storage container that increases explosives and exotics storage capacity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 150f, synthetics = 100f };
				shipModule.Container.MaxExplosives = 3000;
				shipModule.Container.MaxExotics = 300;
				shipModule_maxHealth = 45;
				break;
				case "multicontainer DIY FO":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift FO <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Makeshift storage container that increases fuel and organics storage capacity. If breached, fuel and organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 150f, synthetics = 100f };
				shipModule.Container.MaxOrganics = 3000;
				shipModule.Container.MaxFuel = 3000;
				shipModule_maxHealth = 45;
				break;
				case "multicontainer FExo DIY armor":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift FE <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Makeshift storage container that increases fuel and exotics storage capacity. Reinforced architecture improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 100f };
				shipModule.Container.MaxFuel = 3000;
				shipModule.Container.MaxExotics = 300;
				shipModule_maxHealth = 75;
				break;
				case "multicontainer MS-1":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Standard MS <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Storage container that increases metals and synthetics storage capacity. Reinforced architecture improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 750f, exotics = 2f };
				shipModule.Container.MaxMetals = 7500;
				shipModule.Container.MaxSynthetics = 7500;
				shipModule_maxHealth = 75;
				break;
				case "multicontainer biotec-scaled FO":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Standard FO <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Storage container that increases fuel and organics storage capacity. Reinforced architecture improves container's integrity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 750f, exotics = 2f };
				shipModule.Container.MaxOrganics = 7500;
				shipModule.Container.MaxFuel = 7500;
				shipModule_maxHealth = 75;
				break;
				case "multicontainer ESM-1":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Standard XSM <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Storage container that increases metals and synthetics storage capacity. Reinforced architecture improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 750f, exotics = 2f };
				shipModule.Container.MaxMetals = 5000;
				shipModule.Container.MaxSynthetics = 5000;
				shipModule.Container.MaxExplosives = 5000;
				shipModule_maxHealth = 75;
				break;
				case "multicontainer ESM-2":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital XSM <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases explosives, metals and synthetics storage capacity. Compound alloy structure improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 1750f, synthetics = 1250f, exotics = 3f };
				shipModule.Container.MaxMetals = 8500;
				shipModule.Container.MaxSynthetics = 8500;
				shipModule.Container.MaxExplosives = 8500;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer FEO-1":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital FEO <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases fuel, exotics and organics storage capacity. Compound alloy structure improves container's integrity. If breached, fuel and organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 1750f, synthetics = 1250f, exotics = 3f };
				shipModule.Container.MaxOrganics = 8500;
				shipModule.Container.MaxFuel = 8500;
				shipModule.Container.MaxExotics = 850;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer FOO-1":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital FOO <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases fuel and organics storage capacity. Compound alloy structure improves container's integrity. If breached, fuel and organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 1750f, synthetics = 1250f, exotics = 3f };
				shipModule.Container.MaxOrganics = 16000;
				shipModule.Container.MaxFuel = 9000;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer MFE retro futu":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital MFX <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases metals, fuel and explosives storage capacity. Compound alloy structure improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxFuel = 7500;
				shipModule.Container.MaxMetals = 7500;
				shipModule.Container.MaxExplosives = 10000;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer MFO retro futu":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital MFO <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases metals, fuel and organics storage capacity. Compound alloy structure improves container's integrity. If breached, fuel and organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 10000;
				shipModule.Container.MaxFuel = 7500;
				shipModule.Container.MaxMetals = 7500;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer OMS biotech":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital OMS <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases organics, metals and synthetics storage capacity. Compound alloy structure improves container's integrity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 9000;
				shipModule.Container.MaxMetals = 9000;
				shipModule.Container.MaxSynthetics = 7000;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer FSEE biotech":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital FSXE <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases fuel, synthetics, explosives and exotics storage capacity. Compound alloy structure improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxFuel = 9000;
				shipModule.Container.MaxSynthetics = 2000;
				shipModule.Container.MaxExplosives = 9000;
				shipModule.Container.MaxExotics = 500;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer FOS biotec":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital FOS <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases fuel, organics and synthetics storage capacity. Compound alloy structure improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxFuel = 8250;
				shipModule.Container.MaxOrganics = 8250;
				shipModule.Container.MaxSynthetics = 8250;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer OME mechanical":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital OME <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Massive storage container that increases organics, metals and exotics storage capacity. Compound alloy structure improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 9000;
				shipModule.Container.MaxMetals = 9000;
				shipModule.Container.MaxExotics = 700;
				shipModule_maxHealth = 105;
				break;
				case "multicontainer FE armor":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Armored FX <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Armored storage container that increases fuel and explosives storage capacity. Heavy compound bulkheads improve container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1500f, synthetics = 1000f, exotics = 4f };
				shipModule.Container.MaxFuel = 7500;
				shipModule.Container.MaxExplosives = 7500;
				shipModule_maxHealth = 135;
				break;
				case "multicontainer FSE biotech":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Armored FSE <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Armored storage container that increases fuel, synthetics and exotics storage capacity. Heavy compound bulkheads improve container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1500f, synthetics = 1000f, exotics = 4f };
				shipModule.Container.MaxFuel = 5000;
				shipModule.Container.MaxSynthetics = 5000;
				shipModule.Container.MaxExotics = 500;
				shipModule_maxHealth = 135;
				break;
				case "multicontainer EOME spideraa":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Exotic XOME <color=#" + colorMulti + "ff>Multicontainer</color>";
				shipModule.description = "Exotic storage container that increases explosives, organics, metals and exotics storage capacity. Exotic container's design improves ship's armor. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 2000f, synthetics = 1500f, exotics = 5f };
				shipModule.Container.MaxOrganics = 5000;
				shipModule.Container.MaxMetals = 5000;
				shipModule.Container.MaxExplosives = 5000;
				shipModule.Container.MaxExotics = 500;
				shipModule_maxHealth = 75;
				break;
				case "organics container 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift <color=#" + colorContOrg + "ff>Organics Container</color>";
				shipModule.description = "Makeshift storage container that increases organics storage capacity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxOrganics = 3000;
				shipModule_maxHealth = 30;
				break;
				case "organics container 1 bio":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Bionic <color=#" + colorContOrg + "ff>Organics Container</color>";
				shipModule.description = "Bionic storage container that increases organics storage capacity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, organics = 400f, synthetics = 250f };
				shipModule.Container.MaxOrganics = 4500;
				shipModule_maxHealth = 60;
				break;
				case "organics container 1 small":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Small <color=#" + colorContOrg + "ff>Organics Container</color>";
				shipModule.description = "Small storage container that increases organics storage capacity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxOrganics = 4000;
				shipModule_maxHealth = 45;
				break;
				case "organics container 2 medium":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Medium <color=#" + colorContOrg + "ff>Organics Container</color>";
				shipModule.description = "Medium storage container that increases organics storage capacity. Robust design improves container's integrity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxOrganics = 8000;
				shipModule_maxHealth = 60;
				break;
				case "organics container 3 large":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Large <color=#" + colorContOrg + "ff>Organics Container</color>";
				shipModule.description = "Large storage container that increases organics storage capacity. Reinforced architecture improves container's integrity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxOrganics = 12000;
				shipModule_maxHealth = 75;
				break;
				case "organics container 4 extra large":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Huge <color=#" + colorContOrg + "ff>Organics Container</color>";
				shipModule.description = "Huge storage container that increases organics storage capacity. Reinforced architecture improves container's integrity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxOrganics = 20000;
				shipModule_maxHealth = 75;
				break;
				case "organics container 5 ultra large":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital <color=#" + colorContOrg + "ff>Organics Container</color>";
				shipModule.description = "Massive storage container that increases organics storage capacity. Compound alloy structure improves container's integrity. If breached, organics will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 1500f, synthetics = 1000f, exotics = 3f };
				shipModule.Container.MaxOrganics = 30000;
				shipModule_maxHealth = 90;
				break;
				case "fuel container 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Makeshift storage container that increases fuel storage capacity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxFuel = 3000;
				shipModule_maxHealth = 30;
				break;
				case "fuel container 1 bio":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Bionic <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Bionic storage container that increases fuel storage capacity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, organics = 400f, synthetics = 250f };
				shipModule.Container.MaxFuel = 4500;
				shipModule_maxHealth = 60;
				break;
				case "fuel container 1":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Small <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Small storage container that increases fuel storage capacity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxFuel = 4000;
				shipModule_maxHealth = 45;
				break;
				case "fuel container 2":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Medium <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Medium storage container that increases fuel storage capacity. Robust design improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxFuel = 8000;
				shipModule_maxHealth = 60;
				break;
				case "fuel container 3":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Large <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Large storage container that increases fuel storage capacity. Reinforced architecture improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxFuel = 12000;
				shipModule_maxHealth = 75;
				break;
				case "fuel container 4":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Huge <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Huge storage container that increases fuel storage capacity. Reinforced architecture improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxFuel = 20000;
				shipModule_maxHealth = 75;
				break;
				case "fuel container 5":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Capital <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Massive storage container that increases fuel storage capacity. Compound alloy structure improves container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 1500f, synthetics = 1000f, exotics = 3f };
				shipModule.Container.MaxFuel = 30000;
				shipModule_maxHealth = 90;
				break;
				case "fuel container tiger":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Dreadnought <color=#" + colorContFul + "ff>Fuel Container</color>";
				shipModule.description = "Massive storage container that increases fuel storage capacity. Nanocomposite structure greatly increases container's integrity. If breached, fuel will start to leak out.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1000f, exotics = 3f };
				shipModule.Container.MaxFuel = 30000;
				shipModule_maxHealth = 150;
				break;
				case "metals container 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift <color=#" + colorContMet + "ff>Metals Container</color>";
				shipModule.description = "Makeshift storage container that increases metals storage capacity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxMetals = 3000;
				shipModule_maxHealth = 30;
				break;
				case "metals container 1 small":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Small <color=#" + colorContMet + "ff>Metals Container</color>";
				shipModule.description = "Small storage container that increases metals storage capacity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxMetals = 4000;
				shipModule_maxHealth = 45;
				break;
				case "metals container 2 medium":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Medium <color=#" + colorContMet + "ff>Metals Container</color>";
				shipModule.description = "Medium storage container that increases metals storage capacity. Robust design improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxMetals = 8000;
				shipModule_maxHealth = 60;
				break;
				case "metals container 3 large":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Large <color=#" + colorContMet + "ff>Metals Container</color>";
				shipModule.description = "Large storage container that increases metals storage capacity. Reinforced architecture improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxMetals = 12000;
				shipModule_maxHealth = 75;
				break;
				case "metals container 4 extralarge":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Huge <color=#" + colorContMet + "ff>Metals Container</color>";
				shipModule.description = "Huge storage container that increases metals storage capacity. Compound alloy structure improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxMetals = 20000;
				shipModule_maxHealth = 90;
				break;
				case "synthetics container 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift <color=#" + colorContSyn + "ff>Synthetics Container</color>";
				shipModule.description = "Makeshift storage container that increases synthetics storage capacity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxSynthetics = 3000;
				shipModule_maxHealth = 30;
				break;
				case "synthetics container1 small":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Medium <color=#" + colorContSyn + "ff>Synthetics Container</color>";
				shipModule.description = "Medium storage container that increases synthetics storage capacity. Robust design improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxSynthetics = 8000;
				shipModule_maxHealth = 60;
				break;
				case "synthetics container2 medium":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Large <color=#" + colorContSyn + "ff>Synthetics Container</color>";
				shipModule.description = "Large storage container that increases synthetics storage capacity. Reinforced architecture improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxSynthetics = 12000;
				shipModule_maxHealth = 75;
				break;
				case "synthetics container3 large":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Huge <color=#" + colorContSyn + "ff>Synthetics Container</color>";
				shipModule.description = "Huge storage container that increases synthetics storage capacity. Compound alloy structure improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxSynthetics = 20000;
				shipModule_maxHealth = 90;
				break;
				case "explosives container 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift <color=#" + colorContExp + "ff>Explosives Container</color>";
				shipModule.description = "Makeshift storage container that increases explosives storage capacity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxExplosives = 3000;
				shipModule_maxHealth = 30;
				break;
				case "explosives container 1 small":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Medium <color=#" + colorContExp + "ff>Explosives Container</color>";
				shipModule.description = "Medium storage container that increases explosives storage capacity. Robust design improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxExplosives = 8000;
				shipModule_maxHealth = 60;
				break;
				case "explosives container 2 medium":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Large <color=#" + colorContExp + "ff>Explosives Container</color>";
				shipModule.description = "Large storage container that increases explosives storage capacity. Reinforced architecture improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxExplosives = 12000;
				shipModule_maxHealth = 75;
				break;
				case "explosives container 3 large":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Huge <color=#" + colorContExp + "ff>Explosives Container</color>";
				shipModule.description = "Huge storage container that increases explosives storage capacity. Compound alloy structure improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1100f, synthetics = 700f, exotics = 1f };
				shipModule.Container.MaxExplosives = 20000;
				shipModule_maxHealth = 90;
				break;
				case "exotics container 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Makeshift <color=#" + colorContExo + "ff>Exotics Container</color>";
				shipModule.description = "Makeshift storage container that increases exotics storage capacity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 75f, synthetics = 50f };
				shipModule.Container.MaxExotics = 300;
				shipModule_maxHealth = 30;
				break;
				case "exotics container 1 small":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Small <color=#" + colorContExo + "ff>Exotics Container</color>";
				shipModule.description = "Small storage container that increases exotics storage capacity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 200f };
				shipModule.Container.MaxExotics = 400;
				shipModule_maxHealth = 45;
				break;
				case "exotics container 2 medium":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Medium <color=#" + colorContExo + "ff>Exotics Container</color>";
				shipModule.description = "Medium storage container that increases exotics storage capacity. Robust design improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 350f };
				shipModule.Container.MaxExotics = 800;
				shipModule_maxHealth = 60;
				break;
				case "exotics container 3 large":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId);
				shipModule.displayName = "Large <color=#" + colorContExo + "ff>Exotics Container</color>";
				shipModule.description = "Large storage container that increases exotics storage capacity. Reinforced architecture improves container's integrity.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 750f, synthetics = 500f };
				shipModule.Container.MaxExotics = 1200;
				shipModule_maxHealth = 75;
				break;
				case "fuel container 3 exotic artifact":
				shipModule.displayName = "Fuel Container Artifact";
				shipModule.Container.MaxFuel = 6750;
				shipModule_maxHealth = 50;
				break;
				default:
				Debug.LogWarning($"[NEW STORAGE] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(STORAGE) " + shipModule.displayName;
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
